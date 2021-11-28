using System;
using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Rose.Protections
{
	// Token: 0x02000053 RID: 83
	public static class ProxyMeth
	{
		// Token: 0x0600010B RID: 267 RVA: 0x0000F644 File Offset: 0x0000D844
		public static void ScanMemberRef(ModuleDef module)
		{
			using (IEnumerator<TypeDef> enumerator = module.Types.GetEnumerator())
			{
				do
				{
					TypeDef typeDef = enumerator.Current;
					foreach (MethodDef methodDef in typeDef.Methods)
					{
						if (methodDef.HasBody && methodDef.Body.HasInstructions)
						{
							int num;
							do
							{
								if (methodDef.Body.Instructions[num].OpCode == OpCodes.Call)
								{
									try
									{
										MemberRef memberRef = (MemberRef)methodDef.Body.Instructions[num].Operand;
										if (!memberRef.HasThis)
										{
											ProxyMeth.MemberRefList.Add(memberRef);
										}
									}
									catch
									{
									}
								}
								num++;
							}
							while (num < methodDef.Body.Instructions.Count - 1);
						}
					}
				}
				while (enumerator.MoveNext());
			}
		}

		// Token: 0x0600010C RID: 268 RVA: 0x0000F81C File Offset: 0x0000DA1C
		public static MethodDef GenerateSwitch(MemberRef original, ModuleDef md)
		{
			MethodDef result;
			try
			{
				List<TypeSig> list = original.MethodSig.Params.ToList<TypeSig>();
				list.Add(md.CorLibTypes.Int32);
				MethodImplAttributes implFlags = MethodImplAttributes.IL;
				MethodAttributes flags = MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.Static | MethodAttributes.HideBySig;
				MethodDef methodDef = new MethodDefUser(string.Format("ProxyMeth{0}", ProxyMeth.rand.Next(0, int.MinValue)), MethodSig.CreateStatic(original.MethodSig.RetType, list.ToArray()), implFlags, flags)
				{
					Body = new CilBody()
				};
				methodDef.Body.Variables.Add(new Local(md.CorLibTypes.Int32));
				methodDef.Body.Variables.Add(new Local(md.CorLibTypes.Int32));
				methodDef.Body.Instructions.Add(Instruction.Create(OpCodes.Ldarg_0));
				List<Instruction> list2 = new List<Instruction>();
				Instruction instruction = new Instruction(OpCodes.Switch);
				methodDef.Body.Instructions.Add(instruction);
				Instruction instruction2 = new Instruction(OpCodes.Br_S);
				methodDef.Body.Instructions.Add(instruction2);
				int num2;
				do
				{
					int num;
					do
					{
						methodDef.Body.Instructions.Add(Instruction.Create(OpCodes.Ldarg, methodDef.Parameters[num]));
						if (num == 0)
						{
							list2.Add(Instruction.Create(OpCodes.Ldarg, methodDef.Parameters[num]));
						}
						num++;
					}
					while (num <= original.MethodSig.Params.Count - 1);
					Instruction item = Instruction.Create(OpCodes.Ldc_I4, num2);
					methodDef.Body.Instructions.Add(item);
					methodDef.Body.Instructions.Add(Instruction.Create(OpCodes.Ret));
					num2++;
				}
				while (num2 < 5);
				Instruction instruction3 = Instruction.Create(OpCodes.Ldnull);
				methodDef.Body.Instructions.Add(instruction3);
				methodDef.Body.Instructions.Add(Instruction.Create(OpCodes.Ret));
				instruction2.Operand = instruction3;
				instruction.Operand = list2;
				result = methodDef;
			}
			catch
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600010D RID: 269 RVA: 0x0000FB2C File Offset: 0x0000DD2C
		public static void Execute(ModuleDef module)
		{
			ProxyMeth.ScanMemberRef(module);
			using (IEnumerator<TypeDef> enumerator = module.GetTypes().GetEnumerator())
			{
				do
				{
					TypeDef typeDef = enumerator.Current;
					if (!typeDef.IsGlobalModuleType)
					{
						MethodDef[] array = typeDef.Methods.ToArray<MethodDef>();
						int num;
						do
						{
							MethodDef methodDef = array[num];
							if (methodDef.HasBody && !methodDef.Name.Contains("ProxyMeth"))
							{
								IList<Instruction> instructions = methodDef.Body.Instructions;
								int num2;
								do
								{
									if (methodDef.Body.Instructions[num2].OpCode == OpCodes.Call)
									{
										try
										{
											MemberRef original = (MemberRef)methodDef.Body.Instructions[num2].Operand;
											if (!original.HasThis)
											{
												MethodDef methodDef2 = ProxyMeth.GenerateSwitch(original, module);
												methodDef.DeclaringType.Methods.Add(methodDef2);
												instructions[num2].OpCode = OpCodes.Call;
												instructions[num2].Operand = methodDef2;
												int value = ProxyMeth.rand.Next(0, 5);
												int num3;
												Func<MemberRef, bool> <>9__0;
												do
												{
													if (methodDef2.Body.Instructions[num3].OpCode == OpCodes.Ldc_I4)
													{
														if (string.Compare(methodDef2.Body.Instructions[num3].Operand.ToString(), value.ToString(), StringComparison.Ordinal) != 0)
														{
															methodDef2.Body.Instructions[num3].OpCode = OpCodes.Call;
															Instruction instruction = methodDef2.Body.Instructions[num3];
															IEnumerable<MemberRef> memberRefList = ProxyMeth.MemberRefList;
															Func<MemberRef, bool> predicate;
															if ((predicate = <>9__0) == null)
															{
																predicate = (<>9__0 = (MemberRef m) => m.MethodSig.Params.Count == original.MethodSig.Params.Count);
															}
															instruction.Operand = memberRefList.Where(predicate).ToList<MemberRef>().Random<MemberRef>();
														}
														else
														{
															methodDef2.Body.Instructions[num3].OpCode = OpCodes.Call;
															methodDef2.Body.Instructions[num3].Operand = original;
														}
													}
													num3++;
												}
												while (num3 < methodDef2.Body.Instructions.Count - 1);
												methodDef.Body.Instructions.Insert(num2, Instruction.CreateLdcI4(value));
											}
										}
										catch
										{
										}
									}
									num2++;
								}
								while (num2 < instructions.Count);
							}
							num++;
						}
						while (num < array.Length);
					}
				}
				while (enumerator.MoveNext());
			}
		}

		// Token: 0x04000060 RID: 96
		public static Random rand;

		// Token: 0x04000061 RID: 97
		public static List<MemberRef> MemberRefList;
	}
}
