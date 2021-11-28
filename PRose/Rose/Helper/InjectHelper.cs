using System;
using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Rose.Helper
{
	// Token: 0x02000073 RID: 115
	public static class InjectHelper
	{
		// Token: 0x06000167 RID: 359 RVA: 0x000159E4 File Offset: 0x00013BE4
		private static TypeDefUser Clone(TypeDef origin)
		{
			IEnumerator<GenericParam> enumerator;
			do
			{
				enumerator = origin.GenericParameters.GetEnumerator();
			}
			while (origin.ClassLayout == null);
			TypeDefUser typeDefUser = new TypeDefUser(origin.Namespace, origin.Name);
			typeDefUser.Attributes = origin.Attributes;
			typeDefUser.ClassLayout = new ClassLayoutUser(origin.ClassLayout.PackingSize, origin.ClassSize);
			try
			{
				do
				{
					GenericParam genericParam = enumerator.Current;
					typeDefUser.GenericParameters.Add(new GenericParamUser(genericParam.Number, genericParam.Flags, "-"));
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
			return typeDefUser;
		}

		// Token: 0x06000168 RID: 360 RVA: 0x00015B3C File Offset: 0x00013D3C
		private static MethodDefUser Clone(MethodDef origin)
		{
			MethodDefUser methodDefUser = new MethodDefUser(origin.Name, null, origin.ImplAttributes, origin.Attributes);
			using (IEnumerator<GenericParam> enumerator = origin.GenericParameters.GetEnumerator())
			{
				do
				{
					GenericParam genericParam = enumerator.Current;
					methodDefUser.GenericParameters.Add(new GenericParamUser(genericParam.Number, genericParam.Flags, "-"));
				}
				while (enumerator.MoveNext());
			}
			return methodDefUser;
		}

		// Token: 0x06000169 RID: 361 RVA: 0x00015C2C File Offset: 0x00013E2C
		private static FieldDefUser Clone(FieldDef origin)
		{
			return new FieldDefUser(origin.Name, null, origin.Attributes);
		}

		// Token: 0x0600016A RID: 362 RVA: 0x00015C80 File Offset: 0x00013E80
		private static TypeDef PopulateContext(TypeDef typeDef, InjectHelper.InjectContext ctx)
		{
			IDnlibDef dnlibDef;
			TypeDef typeDef2;
			IEnumerator<TypeDef> enumerator;
			do
			{
				typeDef2 = (TypeDef)dnlibDef;
				ctx.Map[typeDef] = typeDef2;
				typeDef2 = InjectHelper.Clone(typeDef);
				enumerator = typeDef.NestedTypes.GetEnumerator();
			}
			while (ctx.Map.TryGetValue(typeDef, out dnlibDef));
			try
			{
				do
				{
					TypeDef typeDef3 = enumerator.Current;
					typeDef2.NestedTypes.Add(InjectHelper.PopulateContext(typeDef3, ctx));
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
			foreach (MethodDef methodDef in typeDef.Methods)
			{
				typeDef2.Methods.Add((MethodDef)(ctx.Map[methodDef] = InjectHelper.Clone(methodDef)));
			}
			foreach (FieldDef fieldDef in typeDef.Fields)
			{
				typeDef2.Fields.Add((FieldDef)(ctx.Map[fieldDef] = InjectHelper.Clone(fieldDef)));
			}
			return typeDef2;
		}

		// Token: 0x0600016B RID: 363 RVA: 0x00015ED8 File Offset: 0x000140D8
		private static void CopyTypeDef(TypeDef typeDef, InjectHelper.InjectContext ctx)
		{
			IEnumerator<InterfaceImpl> enumerator = typeDef.Interfaces.GetEnumerator();
			TypeDef typeDef2;
			typeDef2.BaseType = (ITypeDefOrRef)ctx.Importer.Import(typeDef.BaseType);
			typeDef2 = (TypeDef)ctx.Map[typeDef];
			try
			{
				do
				{
					InterfaceImpl interfaceImpl = enumerator.Current;
					typeDef2.Interfaces.Add(new InterfaceImplUser((ITypeDefOrRef)ctx.Importer.Import(interfaceImpl.Interface)));
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
		}

		// Token: 0x0600016C RID: 364 RVA: 0x00016000 File Offset: 0x00014200
		private static void CopyMethodDef(MethodDef methodDef, InjectHelper.InjectContext ctx)
		{
			MethodDef methodDef2;
			methodDef2.ImplMap = new ImplMapUser(new ModuleRefUser(ctx.TargetModule, methodDef.ImplMap.Module.Name), methodDef.ImplMap.Name, methodDef.ImplMap.Attributes);
			methodDef2 = (MethodDef)ctx.Map[methodDef];
			IEnumerator<CustomAttribute> enumerator;
			do
			{
				enumerator = methodDef.CustomAttributes.GetEnumerator();
				methodDef2.Signature = ctx.Importer.Import(methodDef.Signature);
			}
			while (methodDef.ImplMap == null);
			methodDef2.Parameters.UpdateParameterTypes();
			try
			{
				do
				{
					CustomAttribute customAttribute = enumerator.Current;
					methodDef2.CustomAttributes.Add(new CustomAttribute((ICustomAttributeType)ctx.Importer.Import(customAttribute.Constructor)));
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
			if (methodDef.HasBody)
			{
				methodDef2.Body = new CilBody(methodDef.Body.InitLocals, new List<Instruction>(), new List<ExceptionHandler>(), new List<Local>());
				methodDef2.Body.MaxStack = methodDef.Body.MaxStack;
				Dictionary<object, object> bodyMap = new Dictionary<object, object>();
				foreach (Local local in methodDef.Body.Variables)
				{
					Local local2 = new Local(ctx.Importer.Import(local.Type));
					methodDef2.Body.Variables.Add(local2);
					bodyMap[local] = local2;
				}
				foreach (Instruction instruction in methodDef.Body.Instructions)
				{
					Instruction instruction2 = new Instruction(instruction.OpCode, instruction.Operand);
					if (instruction2.Operand is IType)
					{
						instruction2.Operand = ctx.Importer.Import((IType)instruction2.Operand);
					}
					else if (instruction2.Operand is IMethod)
					{
						instruction2.Operand = ctx.Importer.Import((IMethod)instruction2.Operand);
					}
					else if (instruction2.Operand is IField)
					{
						instruction2.Operand = ctx.Importer.Import((IField)instruction2.Operand);
					}
					methodDef2.Body.Instructions.Add(instruction2);
					bodyMap[instruction] = instruction2;
				}
				Func<Instruction, Instruction> <>9__0;
				foreach (Instruction instruction3 in methodDef2.Body.Instructions)
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
				foreach (ExceptionHandler exceptionHandler in methodDef.Body.ExceptionHandlers)
				{
					methodDef2.Body.ExceptionHandlers.Add(new ExceptionHandler(exceptionHandler.HandlerType)
					{
						CatchType = ((exceptionHandler.CatchType == null) ? null : ((ITypeDefOrRef)ctx.Importer.Import(exceptionHandler.CatchType))),
						TryStart = (Instruction)bodyMap[exceptionHandler.TryStart],
						TryEnd = (Instruction)bodyMap[exceptionHandler.TryEnd],
						HandlerStart = (Instruction)bodyMap[exceptionHandler.HandlerStart],
						HandlerEnd = (Instruction)bodyMap[exceptionHandler.HandlerEnd],
						FilterStart = ((exceptionHandler.FilterStart == null) ? null : ((Instruction)bodyMap[exceptionHandler.FilterStart]))
					});
				}
				methodDef2.Body.SimplifyMacros(methodDef2.Parameters);
			}
		}

		// Token: 0x0600016D RID: 365 RVA: 0x00016718 File Offset: 0x00014918
		private static void CopyFieldDef(FieldDef fieldDef, InjectHelper.InjectContext ctx)
		{
			FieldDef fieldDef2;
			fieldDef2.Signature = ctx.Importer.Import(fieldDef.Signature);
			fieldDef2 = (FieldDef)ctx.Map[fieldDef];
		}

		// Token: 0x0600016E RID: 366 RVA: 0x000167A0 File Offset: 0x000149A0
		private static void Copy(TypeDef typeDef, InjectHelper.InjectContext ctx, bool copySelf)
		{
			if (copySelf)
			{
			}
			IEnumerator<TypeDef> enumerator = typeDef.NestedTypes.GetEnumerator();
			InjectHelper.CopyTypeDef(typeDef, ctx);
			try
			{
				do
				{
					TypeDef typeDef2 = enumerator.Current;
					InjectHelper.Copy(typeDef2, ctx, true);
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
			foreach (MethodDef methodDef in typeDef.Methods)
			{
				InjectHelper.CopyMethodDef(methodDef, ctx);
			}
			foreach (FieldDef fieldDef in typeDef.Fields)
			{
				InjectHelper.CopyFieldDef(fieldDef, ctx);
			}
		}

		// Token: 0x0600016F RID: 367 RVA: 0x00016934 File Offset: 0x00014B34
		public static TypeDef Inject(TypeDef typeDef, ModuleDef target)
		{
			InjectHelper.InjectContext injectContext;
			InjectHelper.Copy(typeDef, injectContext, true);
			injectContext = new InjectHelper.InjectContext(typeDef.Module, target);
			InjectHelper.PopulateContext(typeDef, injectContext);
			return (TypeDef)injectContext.Map[typeDef];
		}

		// Token: 0x06000170 RID: 368 RVA: 0x000169D4 File Offset: 0x00014BD4
		public static MethodDef Inject(MethodDef methodDef, ModuleDef target)
		{
			InjectHelper.InjectContext injectContext;
			injectContext.Map[methodDef] = InjectHelper.Clone(methodDef);
			injectContext = new InjectHelper.InjectContext(methodDef.Module, target);
			InjectHelper.CopyMethodDef(methodDef, injectContext);
			return (MethodDef)injectContext.Map[methodDef];
		}

		// Token: 0x06000171 RID: 369 RVA: 0x00016A7C File Offset: 0x00014C7C
		public static IEnumerable<IDnlibDef> Inject(TypeDef typeDef, TypeDef newType, ModuleDef target)
		{
			InjectHelper.InjectContext injectContext;
			InjectHelper.Copy(typeDef, injectContext, false);
			injectContext = new InjectHelper.InjectContext(typeDef.Module, target);
			InjectHelper.PopulateContext(typeDef, injectContext);
			injectContext.Map[typeDef] = newType;
			return injectContext.Map.Values.Except(new TypeDef[] { newType });
		}

		// Token: 0x02000074 RID: 116
		private class InjectContext : ImportResolver
		{
			// Token: 0x06000172 RID: 370 RVA: 0x000025B4 File Offset: 0x000007B4
			public InjectContext(ModuleDef module, ModuleDef target)
			{
				this.OriginModule = module;
				this.TargetModule = target;
				this.importer = new Importer(target, ImporterOptions.TryToUseTypeDefs);
				this.importer.Resolver = this;
			}

			// Token: 0x17000018 RID: 24
			// (get) Token: 0x06000173 RID: 371 RVA: 0x000025EE File Offset: 0x000007EE
			public Importer Importer
			{
				get
				{
					return this.importer;
				}
			}

			// Token: 0x06000174 RID: 372 RVA: 0x000025F6 File Offset: 0x000007F6
			public override TypeDef Resolve(TypeDef typeDef)
			{
				if (this.Map.ContainsKey(typeDef))
				{
					return (TypeDef)this.Map[typeDef];
				}
				return null;
			}

			// Token: 0x06000175 RID: 373 RVA: 0x00002619 File Offset: 0x00000819
			public override MethodDef Resolve(MethodDef methodDef)
			{
				if (this.Map.ContainsKey(methodDef))
				{
					return (MethodDef)this.Map[methodDef];
				}
				return null;
			}

			// Token: 0x06000176 RID: 374 RVA: 0x0000263C File Offset: 0x0000083C
			public override FieldDef Resolve(FieldDef fieldDef)
			{
				if (this.Map.ContainsKey(fieldDef))
				{
					return (FieldDef)this.Map[fieldDef];
				}
				return null;
			}

			// Token: 0x04000081 RID: 129
			public readonly Dictionary<IDnlibDef, IDnlibDef> Map = new Dictionary<IDnlibDef, IDnlibDef>();

			// Token: 0x04000082 RID: 130
			public readonly ModuleDef OriginModule;

			// Token: 0x04000083 RID: 131
			public readonly ModuleDef TargetModule;

			// Token: 0x04000084 RID: 132
			private readonly Importer importer;
		}
	}
}
