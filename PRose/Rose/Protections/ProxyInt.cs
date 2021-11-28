using System;
using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Rose.Protections
{
	// Token: 0x02000052 RID: 82
	public static class ProxyInt
	{
		// Token: 0x0600010A RID: 266 RVA: 0x0000F28C File Offset: 0x0000D48C
		public static void Execute(ModuleDef module)
		{
			using (IEnumerator<TypeDef> enumerator = module.GetTypes().GetEnumerator())
			{
				do
				{
					TypeDef typeDef = enumerator.Current;
					if (!typeDef.IsGlobalModuleType)
					{
						foreach (MethodDef methodDef in typeDef.Methods)
						{
							if (methodDef.HasBody)
							{
								IList<Instruction> instructions = methodDef.Body.Instructions;
								int num;
								do
								{
									if (methodDef.Body.Instructions[num].IsLdcI4())
									{
										MethodImplAttributes implFlags = MethodImplAttributes.IL;
										MethodAttributes flags = MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.Static | MethodAttributes.HideBySig;
										MethodDefUser methodDefUser = new MethodDefUser(RUtils.RandomChinese(5), MethodSig.CreateStatic(module.CorLibTypes.Int32), implFlags, flags);
										module.GlobalType.Methods.Add(methodDefUser);
										methodDefUser.Body = new CilBody();
										methodDefUser.Body.Variables.Add(new Local(module.CorLibTypes.Int32));
										methodDefUser.Body.Instructions.Add(Instruction.Create(OpCodes.Ldc_I4, instructions[num].GetLdcI4Value()));
										methodDefUser.Body.Instructions.Add(Instruction.Create(OpCodes.Ret));
										instructions[num].OpCode = OpCodes.Call;
										instructions[num].Operand = methodDefUser;
									}
									else if (methodDef.Body.Instructions[num].OpCode == OpCodes.Ldc_R4)
									{
										MethodImplAttributes implFlags2 = MethodImplAttributes.IL;
										MethodAttributes flags2 = MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.Static | MethodAttributes.HideBySig;
										MethodDefUser methodDefUser2 = new MethodDefUser(RUtils.RandomChinese(5), MethodSig.CreateStatic(module.CorLibTypes.Double), implFlags2, flags2);
										module.GlobalType.Methods.Add(methodDefUser2);
										methodDefUser2.Body = new CilBody();
										methodDefUser2.Body.Variables.Add(new Local(module.CorLibTypes.Double));
										methodDefUser2.Body.Instructions.Add(Instruction.Create(OpCodes.Ldc_R4, (float)methodDef.Body.Instructions[num].Operand));
										methodDefUser2.Body.Instructions.Add(Instruction.Create(OpCodes.Ret));
										instructions[num].OpCode = OpCodes.Call;
										instructions[num].Operand = methodDefUser2;
									}
									num++;
								}
								while (num < instructions.Count);
							}
						}
					}
				}
				while (enumerator.MoveNext());
			}
		}
	}
}
