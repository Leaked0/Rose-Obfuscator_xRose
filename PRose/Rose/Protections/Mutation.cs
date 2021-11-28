using System;
using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Rose.Protections
{
	// Token: 0x02000049 RID: 73
	internal static class Mutation
	{
		// Token: 0x060000E6 RID: 230 RVA: 0x00009614 File Offset: 0x00007814
		public static void Execute(ModuleDefMD moduleDefMd)
		{
			IEnumerator<TypeDef> enumerator = moduleDefMd.GetTypes().GetEnumerator();
			Mutation._moduleDefMd = moduleDefMd;
			CryptoRandom cryptoRandom = new CryptoRandom();
			try
			{
				do
				{
					TypeDef typeDef = enumerator.Current;
					List<MethodDef> list = new List<MethodDef>();
					IEnumerable<MethodDef> methods = typeDef.Methods;
					Func<MethodDef, bool> predicate;
					if ((predicate = Mutation.<>c.<>9__1_0) == null)
					{
						predicate = (Mutation.<>c.<>9__1_0 = (MethodDef x) => x.HasBody);
					}
					foreach (MethodDef methodDef in methods.Where(predicate))
					{
						IList<Instruction> instructions = methodDef.Body.Instructions;
						int num;
						do
						{
							if (instructions[num].IsLdcI4() && Mutation.IsSafe(instructions.ToList<Instruction>(), num))
							{
								MethodDef methodDef2 = null;
								int ldcI4Value = instructions[num].GetLdcI4Value();
								instructions[num].OpCode = OpCodes.Ldc_R8;
								switch (cryptoRandom.Next(0, 0))
								{
								case 0:
									methodDef2 = Mutation.GenerateRefMethod("Floor");
									instructions[num].Operand = Convert.ToDouble((double)ldcI4Value + cryptoRandom.NextDouble());
									break;
								case 1:
									methodDef2 = Mutation.GenerateRefMethod("Sqrt");
									instructions[num].Operand = Math.Pow(Convert.ToDouble(ldcI4Value), 2.0);
									break;
								case 2:
									methodDef2 = Mutation.GenerateRefMethod("Round");
									instructions[num].Operand = Convert.ToDouble(ldcI4Value);
									break;
								}
								instructions.Insert(num + 1, OpCodes.Call.ToInstruction(methodDef2));
								instructions.Insert(num + 2, OpCodes.Conv_I4.ToInstruction());
								num += 2;
								list.Add(methodDef2);
							}
							num++;
						}
						while (num < instructions.Count);
						methodDef.Body.SimplifyMacros(methodDef.Parameters);
					}
					foreach (MethodDef item in list)
					{
						typeDef.Methods.Add(item);
					}
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

		// Token: 0x060000E7 RID: 231 RVA: 0x00009974 File Offset: 0x00007B74
		private static MethodDef GenerateRefMethod(string methodName)
		{
			MethodDefUser methodDefUser;
			CilBody body;
			methodDefUser.Body = body;
			MethodDefUser methodDefUser2;
			methodDefUser = methodDefUser2;
			CilBody cilBody;
			cilBody.Instructions.Add(OpCodes.Ldarg_0.ToInstruction());
			cilBody.Instructions.Add(OpCodes.Ret.ToInstruction());
			methodDefUser.Body.Variables.Add(new Local(Mutation._moduleDefMd.ImportAsTypeSig(typeof(double))));
			methodDefUser2.Signature = new MethodSig
			{
				Params = { Mutation._moduleDefMd.ImportAsTypeSig(typeof(double)) },
				RetType = Mutation._moduleDefMd.ImportAsTypeSig(typeof(double))
			};
			cilBody.Instructions.Add(OpCodes.Stloc_0.ToInstruction());
			body = cilBody;
			cilBody.Instructions.Add(OpCodes.Ldloc_0.ToInstruction());
			cilBody = new CilBody();
			methodDefUser2 = new MethodDefUser(RUtils.RandomSymbols(5), MethodSig.CreateStatic(Mutation._moduleDefMd.ImportAsTypeSig(typeof(double))), MethodAttributes.Private | MethodAttributes.Static | MethodAttributes.HideBySig);
			cilBody.Instructions.Add(OpCodes.Call.ToInstruction(Mutation.GetMethod(typeof(Math), methodName, new Type[] { typeof(double) })));
			return methodDefUser.ResolveMethodDef();
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x000057E8 File Offset: 0x000039E8
		private static bool IsSafe(List<Instruction> instructions, int i)
		{
			return false;
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x00009B10 File Offset: 0x00007D10
		private static IMethod GetMethod(Type type, string methodName, Type[] types)
		{
			return Mutation._moduleDefMd.Import(type.GetMethod(methodName, types));
		}

		// Token: 0x04000055 RID: 85
		private static ModuleDefMD _moduleDefMd;
	}
}
