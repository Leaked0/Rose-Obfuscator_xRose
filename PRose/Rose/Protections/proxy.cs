using System;
using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using Rose.Helper;

namespace Rose.Protections
{
	// Token: 0x02000051 RID: 81
	internal class proxy
	{
		// Token: 0x06000106 RID: 262 RVA: 0x0000EE50 File Offset: 0x0000D050
		public static void Execute(ModuleDefMD mod)
		{
			int num = 0;
			int num2 = 1;
			do
			{
				using (IEnumerator<TypeDef> enumerator = mod.Types.GetEnumerator())
				{
					do
					{
						TypeDef typeDef = enumerator.Current;
						if (!typeDef.IsGlobalModuleType)
						{
							int count = typeDef.Methods.Count;
							int num3;
							do
							{
								MethodDef methodDef = typeDef.Methods[num3];
								if (methodDef.HasBody)
								{
									IList<Instruction> instructions = methodDef.Body.Instructions;
									int num4;
									do
									{
										if (instructions[num4].OpCode == OpCodes.Call)
										{
											try
											{
												MethodDef methodDef2 = instructions[num4].Operand as MethodDef;
												if (methodDef2.FullName.Contains(mod.Assembly.Name))
												{
													if (methodDef2.Parameters.Count != 0)
													{
														if (methodDef2.Parameters.Count <= 4)
														{
															MethodDef methodDef3 = methodDef2.copyMethod(mod);
															TypeDef declaringType = methodDef2.DeclaringType;
															declaringType.Methods.Add(methodDef3);
															proxy.proxyMethod.Add(methodDef3);
															proxy.Clonesignature(methodDef2, methodDef3);
															CilBody cilBody = new CilBody();
															cilBody.Instructions.Add(OpCodes.Nop.ToInstruction());
															int num5;
															do
															{
																Parameter parameter = methodDef2.Parameters[num5];
																switch (num5)
																{
																case 0:
																	cilBody.Instructions.Add(OpCodes.Ldarg_0.ToInstruction());
																	break;
																case 1:
																	cilBody.Instructions.Add(OpCodes.Ldarg_1.ToInstruction());
																	break;
																case 2:
																	cilBody.Instructions.Add(OpCodes.Ldarg_2.ToInstruction());
																	break;
																case 3:
																	cilBody.Instructions.Add(OpCodes.Ldarg_3.ToInstruction());
																	break;
																}
																num5++;
															}
															while (num5 < methodDef2.Parameters.Count);
															cilBody.Instructions.Add(Instruction.Create(OpCodes.Call, methodDef3));
															cilBody.Instructions.Add(OpCodes.Ret.ToInstruction());
															methodDef2.Body = cilBody;
														}
													}
												}
											}
											catch (Exception)
											{
											}
										}
										num4++;
									}
									while (num4 < instructions.Count);
								}
								num3++;
							}
							while (num3 < count);
						}
					}
					while (enumerator.MoveNext());
				}
				num++;
			}
			while (num < num2);
		}

		// Token: 0x06000107 RID: 263 RVA: 0x0000F208 File Offset: 0x0000D408
		public static MethodDef Clonesignature(MethodDef from, MethodDef to)
		{
			if (from.IsHideBySig)
			{
				to.Attributes = from.Attributes;
				to.IsHideBySig = true;
			}
			return to;
		}

		// Token: 0x0400005F RID: 95
		public static List<MethodDef> proxyMethod = new List<MethodDef>();
	}
}
