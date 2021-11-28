using System;
using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Rose.Protections
{
	// Token: 0x02000057 RID: 87
	internal class ProxyString
	{
		// Token: 0x06000113 RID: 275 RVA: 0x0000FFAC File Offset: 0x0000E1AC
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
								foreach (Instruction instruction in instructions)
								{
									if (instruction.OpCode == OpCodes.Ldstr)
									{
										MethodImplAttributes implFlags = MethodImplAttributes.IL;
										MethodAttributes flags = MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.Static | MethodAttributes.HideBySig;
										MethodDefUser methodDefUser = new MethodDefUser(RUtils.RandomChinese(xd.thelength), MethodSig.CreateStatic(module.CorLibTypes.String), implFlags, flags);
										module.GlobalType.Methods.Add(methodDefUser);
										methodDefUser.Body = new CilBody();
										methodDefUser.Body.Variables.Add(new Local(module.CorLibTypes.String));
										methodDefUser.Body.Instructions.Add(Instruction.Create(OpCodes.Ldstr, instruction.Operand.ToString()));
										methodDefUser.Body.Instructions.Add(Instruction.Create(OpCodes.Ret));
										instruction.OpCode = OpCodes.Call;
										instruction.Operand = methodDefUser;
									}
								}
							}
						}
					}
				}
				while (enumerator.MoveNext());
			}
		}
	}
}
