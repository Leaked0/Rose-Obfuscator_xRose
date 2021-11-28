using System;
using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Rose.Helper
{
	// Token: 0x02000070 RID: 112
	internal static class extension
	{
		// Token: 0x0600015F RID: 351 RVA: 0x00015268 File Offset: 0x00013468
		public static MethodDef copyMethod(this MethodDef originMethod, ModuleDefMD mod)
		{
			extension.InjectContext injectContext = new extension.InjectContext(mod, mod);
			MethodDefUser methodDefUser;
			if (originMethod.ImplMap != null)
			{
				methodDefUser.Parameters.UpdateParameterTypes();
				methodDefUser = new MethodDefUser
				{
					Signature = injectContext.Importer.Import(originMethod.Signature)
				};
				methodDefUser.Name = Guid.NewGuid().ToString().Replace("-", string.Empty);
			}
			IEnumerator<CustomAttribute> enumerator = originMethod.CustomAttributes.GetEnumerator();
			methodDefUser.ImplMap = new ImplMapUser(new ModuleRefUser(injectContext.TargetModule, originMethod.ImplMap.Module.Name), originMethod.ImplMap.Name, originMethod.ImplMap.Attributes);
			try
			{
				do
				{
					CustomAttribute customAttribute = enumerator.Current;
					methodDefUser.CustomAttributes.Add(new CustomAttribute((ICustomAttributeType)injectContext.Importer.Import(customAttribute.Constructor)));
				}
				while (enumerator.MoveNext());
			}
			finally
			{
				if (enumerator != null)
				{
					enumerator.Dispose();
				}
			}
			if (originMethod.HasBody)
			{
				methodDefUser.Body = new CilBody(originMethod.Body.InitLocals, new List<Instruction>(), new List<ExceptionHandler>(), new List<Local>());
				methodDefUser.Body.MaxStack = originMethod.Body.MaxStack;
				Dictionary<object, object> bodyMap = new Dictionary<object, object>();
				foreach (Local local in originMethod.Body.Variables)
				{
					Local local2 = new Local(injectContext.Importer.Import(local.Type));
					methodDefUser.Body.Variables.Add(local2);
					local2.Name = local.Name;
					bodyMap[local] = local2;
				}
				foreach (Instruction instruction in originMethod.Body.Instructions)
				{
					Instruction instruction2 = new Instruction(instruction.OpCode, instruction.Operand);
					instruction2.SequencePoint = instruction.SequencePoint;
					if (instruction2.Operand is IType)
					{
						instruction2.Operand = injectContext.Importer.Import((IType)instruction2.Operand);
					}
					else if (instruction2.Operand is IMethod)
					{
						instruction2.Operand = injectContext.Importer.Import((IMethod)instruction2.Operand);
					}
					else if (instruction2.Operand is IField)
					{
						instruction2.Operand = injectContext.Importer.Import((IField)instruction2.Operand);
					}
					methodDefUser.Body.Instructions.Add(instruction2);
					bodyMap[instruction] = instruction2;
				}
				Func<Instruction, Instruction> <>9__0;
				foreach (Instruction instruction3 in methodDefUser.Body.Instructions)
				{
					if (instruction3.Operand != null && bodyMap.ContainsKey(instruction3.Operand))
					{
						instruction3.Operand = bodyMap[instruction3.Operand];
					}
					else if (instruction3.Operand is Instruction[])
					{
						Instruction instruction4 = instruction3;
						IEnumerable<Instruction> source = (Instruction[])instruction3.Operand;
						Func<Instruction, Instruction> selector;
						if ((selector = <>9__0) == null)
						{
							selector = (<>9__0 = (Instruction target) => (Instruction)bodyMap[target]);
						}
						instruction4.Operand = source.Select(selector).ToArray<Instruction>();
					}
				}
				foreach (ExceptionHandler exceptionHandler in originMethod.Body.ExceptionHandlers)
				{
					methodDefUser.Body.ExceptionHandlers.Add(new ExceptionHandler(exceptionHandler.HandlerType)
					{
						CatchType = ((exceptionHandler.CatchType == null) ? null : ((ITypeDefOrRef)injectContext.Importer.Import(exceptionHandler.CatchType))),
						TryStart = (Instruction)bodyMap[exceptionHandler.TryStart],
						TryEnd = (Instruction)bodyMap[exceptionHandler.TryEnd],
						HandlerStart = (Instruction)bodyMap[exceptionHandler.HandlerStart],
						HandlerEnd = (Instruction)bodyMap[exceptionHandler.HandlerEnd],
						FilterStart = ((exceptionHandler.FilterStart == null) ? null : ((Instruction)bodyMap[exceptionHandler.FilterStart]))
					});
				}
				methodDefUser.Body.SimplifyMacros(methodDefUser.Parameters);
			}
			return methodDefUser;
		}

		// Token: 0x02000071 RID: 113
		private class InjectContext : ImportResolver
		{
			// Token: 0x06000160 RID: 352 RVA: 0x000024F6 File Offset: 0x000006F6
			public InjectContext(ModuleDef module, ModuleDef target)
			{
				this.OriginModule = module;
				this.TargetModule = target;
				this.importer = new Importer(target, ImporterOptions.TryToUseTypeDefs);
				this.importer.Resolver = this;
			}

			// Token: 0x17000017 RID: 23
			// (get) Token: 0x06000161 RID: 353 RVA: 0x00002530 File Offset: 0x00000730
			public Importer Importer
			{
				get
				{
					return this.importer;
				}
			}

			// Token: 0x06000162 RID: 354 RVA: 0x00002538 File Offset: 0x00000738
			public override TypeDef Resolve(TypeDef typeDef)
			{
				if (this.Map.ContainsKey(typeDef))
				{
					return (TypeDef)this.Map[typeDef];
				}
				return null;
			}

			// Token: 0x06000163 RID: 355 RVA: 0x0000255B File Offset: 0x0000075B
			public override MethodDef Resolve(MethodDef methodDef)
			{
				if (this.Map.ContainsKey(methodDef))
				{
					return (MethodDef)this.Map[methodDef];
				}
				return null;
			}

			// Token: 0x06000164 RID: 356 RVA: 0x0000257E File Offset: 0x0000077E
			public override FieldDef Resolve(FieldDef fieldDef)
			{
				if (this.Map.ContainsKey(fieldDef))
				{
					return (FieldDef)this.Map[fieldDef];
				}
				return null;
			}

			// Token: 0x0400007B RID: 123
			public readonly Dictionary<IDnlibDef, IDnlibDef> Map = new Dictionary<IDnlibDef, IDnlibDef>();

			// Token: 0x0400007C RID: 124
			public readonly ModuleDef OriginModule;

			// Token: 0x0400007D RID: 125
			public readonly ModuleDef TargetModule;

			// Token: 0x0400007E RID: 126
			private readonly Importer importer;
		}
	}
}
