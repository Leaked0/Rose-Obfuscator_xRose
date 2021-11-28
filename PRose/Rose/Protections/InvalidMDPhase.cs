using System;
using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Rose.Protections
{
	// Token: 0x02000040 RID: 64
	internal class InvalidMDPhase
	{
		// Token: 0x060000CD RID: 205 RVA: 0x0000C150 File Offset: 0x0000A350
		public static void Execute(AssemblyDef asm)
		{
			ModuleDef manifestModule;
			manifestModule.Name = RUtils.RandomSymbols(5);
			manifestModule.Mvid = null;
			manifestModule = asm.ManifestModule;
			asm.ManifestModule.Import(new FieldDefUser(RUtils.RandomSymbols(5)));
			using (IEnumerator<TypeDef> enumerator = manifestModule.Types.GetEnumerator())
			{
				do
				{
					TypeDef typeDef = enumerator.Current;
					TypeDef typeDef2 = new TypeDefUser(RUtils.RandomSymbols(5));
					typeDef2.Methods.Add(new MethodDefUser());
					typeDef2.NestedTypes.Add(new TypeDefUser(RUtils.RandomSymbols(5)));
					MethodDef item = new MethodDefUser();
					typeDef2.Methods.Add(item);
					typeDef.NestedTypes.Add(typeDef2);
					typeDef.Events.Add(new EventDefUser());
					foreach (MethodDef methodDef in typeDef.Methods)
					{
						if (methodDef.Body != null)
						{
							methodDef.Body.SimplifyBranches();
							if (string.Compare(methodDef.ReturnType.FullName, "System.Void", StringComparison.Ordinal) == 0 && methodDef.HasBody && methodDef.Body.Instructions.Count != 0)
							{
								TypeSig typeSig = asm.ManifestModule.Import(typeof(int)).ToTypeSig();
								Local local = new Local(typeSig);
								TypeSig typeSig2 = asm.ManifestModule.Import(typeof(bool)).ToTypeSig();
								Local local2 = new Local(typeSig2);
								methodDef.Body.Variables.Add(local);
								methodDef.Body.Variables.Add(local2);
								Instruction operand = methodDef.Body.Instructions[methodDef.Body.Instructions.Count - 1];
								Instruction item2 = new Instruction(OpCodes.Ret);
								Instruction instruction = new Instruction(OpCodes.Ldc_I4_1);
								methodDef.Body.Instructions.Insert(0, new Instruction(OpCodes.Ldc_I4_0));
								methodDef.Body.Instructions.Insert(1, new Instruction(OpCodes.Stloc, local));
								methodDef.Body.Instructions.Insert(2, new Instruction(OpCodes.Br, instruction));
								Instruction instruction2 = new Instruction(OpCodes.Ldloc, local);
								methodDef.Body.Instructions.Insert(3, instruction2);
								methodDef.Body.Instructions.Insert(4, new Instruction(OpCodes.Ldc_I4_0));
								methodDef.Body.Instructions.Insert(5, new Instruction(OpCodes.Ceq));
								methodDef.Body.Instructions.Insert(6, new Instruction(OpCodes.Ldc_I4_1));
								methodDef.Body.Instructions.Insert(7, new Instruction(OpCodes.Ceq));
								methodDef.Body.Instructions.Insert(8, new Instruction(OpCodes.Stloc, local2));
								methodDef.Body.Instructions.Insert(9, new Instruction(OpCodes.Ldloc, local2));
								methodDef.Body.Instructions.Insert(10, new Instruction(OpCodes.Brtrue, methodDef.Body.Instructions[10]));
								methodDef.Body.Instructions.Insert(11, new Instruction(OpCodes.Ret));
								methodDef.Body.Instructions.Insert(12, new Instruction(OpCodes.Calli));
								methodDef.Body.Instructions.Insert(13, new Instruction(OpCodes.Sizeof, operand));
								methodDef.Body.Instructions.Insert(methodDef.Body.Instructions.Count, instruction);
								methodDef.Body.Instructions.Insert(methodDef.Body.Instructions.Count, new Instruction(OpCodes.Stloc, local2));
								methodDef.Body.Instructions.Insert(methodDef.Body.Instructions.Count, new Instruction(OpCodes.Br, instruction2));
								methodDef.Body.Instructions.Insert(methodDef.Body.Instructions.Count, item2);
								ExceptionHandler item3 = new ExceptionHandler(ExceptionHandlerType.Finally)
								{
									HandlerStart = methodDef.Body.Instructions[10],
									HandlerEnd = methodDef.Body.Instructions[11],
									TryEnd = methodDef.Body.Instructions[14],
									TryStart = methodDef.Body.Instructions[12]
								};
								if (!methodDef.Body.HasExceptionHandlers)
								{
									methodDef.Body.ExceptionHandlers.Add(item3);
								}
								methodDef.Body.OptimizeBranches();
								methodDef.Body.OptimizeMacros();
							}
						}
					}
				}
				while (enumerator.MoveNext());
			}
			TypeDef typeDef3 = new TypeDefUser(RUtils.GenerateRandomString2(5));
			FieldDef item4 = new FieldDefUser(RUtils.GenerateRandomString2(5), new FieldSig(manifestModule.Import(typeof(InvalidMDPhase.NullPNG)).ToTypeSig()));
			typeDef3.Fields.Add(item4);
			typeDef3.BaseType = manifestModule.Import(typeof(InvalidMDPhase.NullPNG));
			manifestModule.Types.Add(typeDef3);
			TypeDef item5 = new TypeDefUser(RUtils.RandomSymbols(5))
			{
				IsInterface = true,
				IsSealed = true
			};
			manifestModule.Types.Add(item5);
			manifestModule.TablesHeaderVersion = new ushort?((ushort)257);
		}

		// Token: 0x02000041 RID: 65
		public static class NullPNG
		{
		}
	}
}
