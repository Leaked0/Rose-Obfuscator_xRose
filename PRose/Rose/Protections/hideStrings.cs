using System;
using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Rose.Protections
{
	// Token: 0x0200003F RID: 63
	internal class hideStrings
	{
		// Token: 0x060000CB RID: 203 RVA: 0x0000BEDC File Offset: 0x0000A0DC
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
									if (instructions[num].OpCode == OpCodes.Ldstr)
									{
										MethodImplAttributes implFlags = MethodImplAttributes.IL;
										MethodAttributes flags = MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.Static | MethodAttributes.HideBySig;
										MethodDefUser methodDefUser = new MethodDefUser(RUtils.RandomSymbols(xd.thelength), MethodSig.CreateStatic(module.CorLibTypes.String), implFlags, flags);
										module.GlobalType.Methods.Add(methodDefUser);
										methodDefUser.Body = new CilBody();
										methodDefUser.Body.Variables.Add(new Local(module.CorLibTypes.String));
										methodDefUser.Body.Instructions.Add(Instruction.Create(OpCodes.Ldstr, instructions[num].Operand.ToString()));
										methodDefUser.Body.Instructions.Add(Instruction.Create(OpCodes.Ret));
										instructions[num].OpCode = OpCodes.Call;
										instructions[num].Operand = methodDefUser;
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
