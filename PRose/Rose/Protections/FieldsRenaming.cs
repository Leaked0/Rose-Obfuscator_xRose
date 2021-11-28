using System;
using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Rose.Protections
{
	// Token: 0x02000059 RID: 89
	public class FieldsRenaming : IRenaming
	{
		// Token: 0x06000119 RID: 281 RVA: 0x0000BEF4 File Offset: 0x0000A0F4
		public ModuleDefMD Rename(ModuleDefMD module)
		{
			using (IEnumerator<TypeDef> enumerator = module.GetTypes().GetEnumerator())
			{
				do
				{
					TypeDef typeDef = enumerator.Current;
					if (!typeDef.IsGlobalModuleType)
					{
						using (IEnumerator<FieldDef> enumerator2 = typeDef.Fields.GetEnumerator())
						{
							while (enumerator2.MoveNext())
							{
								FieldDef fieldDef = enumerator2.Current;
								string s;
								if (FieldsRenaming._names.TryGetValue(fieldDef.Name, out s))
								{
									fieldDef.Name = s;
								}
								else
								{
									if (xd.renamertype == "Ascii")
									{
										string value = RUtils.GenerateRandomString2(xd.thelength);
										FieldsRenaming._names.Add(fieldDef.Name, value);
										fieldDef.Name = RUtils.GenerateRandomString2(xd.thelength);
									}
									if (xd.renamertype == "Numbers")
									{
										string value2 = RUtils.RandomNum(xd.thelength);
										FieldsRenaming._names.Add(fieldDef.Name, value2);
										fieldDef.Name = RUtils.RandomNum(xd.thelength);
									}
									if (xd.renamertype == "Symbols")
									{
										string value3 = RUtils.RandomSymbols(xd.thelength);
										FieldsRenaming._names.Add(fieldDef.Name, value3);
										fieldDef.Name = RUtils.RandomSymbols(xd.thelength);
									}
									if (xd.renamertype == "Chinese")
									{
										string value4 = RUtils.RandomChinese(xd.thelength);
										FieldsRenaming._names.Add(fieldDef.Name, value4);
										fieldDef.Name = RUtils.RandomChinese(xd.thelength);
									}
								}
							}
							goto IL_20;
						}
						continue;
					}
					IL_20:;
				}
				while (enumerator.MoveNext());
			}
			return FieldsRenaming.ApplyChangesToResources(module);
		}

		// Token: 0x0600011A RID: 282 RVA: 0x0000C16C File Offset: 0x0000A36C
		private static ModuleDefMD ApplyChangesToResources(ModuleDefMD module)
		{
			using (IEnumerator<TypeDef> enumerator = module.GetTypes().GetEnumerator())
			{
				do
				{
					TypeDef typeDef = enumerator.Current;
					if (!typeDef.IsGlobalModuleType)
					{
						using (IEnumerator<MethodDef> enumerator2 = typeDef.Methods.GetEnumerator())
						{
							while (enumerator2.MoveNext())
							{
								MethodDef methodDef = enumerator2.Current;
								if (!(methodDef.Name != "InitializeComponent"))
								{
									IList<Instruction> instructions = methodDef.Body.Instructions;
									int num;
									do
									{
										if (instructions[num].OpCode == OpCodes.Ldstr)
										{
											using (Dictionary<string, string>.Enumerator enumerator3 = FieldsRenaming._names.GetEnumerator())
											{
												while (enumerator3.MoveNext())
												{
													KeyValuePair<string, string> keyValuePair = enumerator3.Current;
													if (keyValuePair.Key == instructions[num].Operand.ToString())
													{
														instructions[num].Operand = keyValuePair.Value;
													}
												}
												goto IL_87;
											}
											continue;
										}
										IL_87:
										num++;
									}
									while (num < instructions.Count - 3);
								}
							}
							goto IL_20;
						}
						continue;
					}
					IL_20:;
				}
				while (enumerator.MoveNext());
			}
			return module;
		}

		// Token: 0x04000066 RID: 102
		private static Dictionary<string, string> _names = new Dictionary<string, string>();
	}
}
