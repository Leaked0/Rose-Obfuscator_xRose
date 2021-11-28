using System;
using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Rose.Protections
{
	// Token: 0x0200005C RID: 92
	public class NamespacesRenaming : IRenaming
	{
		// Token: 0x06000120 RID: 288 RVA: 0x0000C560 File Offset: 0x0000A760
		public ModuleDefMD Rename(ModuleDefMD module)
		{
			using (IEnumerator<TypeDef> enumerator = module.GetTypes().GetEnumerator())
			{
				do
				{
					TypeDef typeDef = enumerator.Current;
					if (!typeDef.IsGlobalModuleType && !(typeDef.Namespace == ""))
					{
						string text;
						if (NamespacesRenaming._names.TryGetValue(typeDef.Namespace, out text) && xd.renamertype == "Ascii")
						{
							typeDef.Namespace = RUtils.GenerateRandomString2(xd.thelength);
						}
						if (xd.renamertype == "Numbers")
						{
							typeDef.Namespace = RUtils.RandomNum(xd.thelength);
						}
						if (xd.renamertype == "Symbols")
						{
							typeDef.Namespace = RUtils.RandomSymbols(xd.thelength);
						}
						if (xd.renamertype == "Chinese")
						{
							typeDef.Namespace = RUtils.RandomChinese(xd.thelength);
						}
						else
						{
							if (xd.renamertype == "Ascii")
							{
								string value = RUtils.GenerateRandomString2(xd.thelength);
								NamespacesRenaming._names.Add(typeDef.Namespace, value);
								typeDef.Namespace = RUtils.GenerateRandomString2(xd.thelength);
							}
							if (xd.renamertype == "Numbers")
							{
								string value2 = RUtils.RandomNum(xd.thelength);
								NamespacesRenaming._names.Add(typeDef.Namespace, value2);
								typeDef.Namespace = RUtils.RandomNum(xd.thelength);
							}
							if (xd.renamertype == "Symbols")
							{
								string value3 = RUtils.RandomSymbols(xd.thelength);
								NamespacesRenaming._names.Add(typeDef.Namespace, value3);
								typeDef.Namespace = RUtils.RandomSymbols(xd.thelength);
							}
							if (xd.renamertype == "Chinese")
							{
								string value4 = RUtils.RandomChinese(xd.thelength);
								NamespacesRenaming._names.Add(typeDef.Namespace, value4);
								typeDef.Namespace = RUtils.RandomChinese(xd.thelength);
							}
						}
					}
				}
				while (enumerator.MoveNext());
			}
			return NamespacesRenaming.ApplyChangesToResources(module);
		}

		// Token: 0x06000121 RID: 289 RVA: 0x0000C828 File Offset: 0x0000AA28
		private static ModuleDefMD ApplyChangesToResources(ModuleDefMD module)
		{
			using (IEnumerator<Resource> enumerator = module.Resources.GetEnumerator())
			{
				do
				{
					Resource resource = enumerator.Current;
					foreach (KeyValuePair<string, string> keyValuePair in NamespacesRenaming._names)
					{
						if (resource.Name.Contains(keyValuePair.Key))
						{
							resource.Name = resource.Name.Replace(keyValuePair.Key, keyValuePair.Value);
						}
					}
				}
				while (enumerator.MoveNext());
			}
			foreach (TypeDef typeDef in module.GetTypes())
			{
				foreach (PropertyDef propertyDef in typeDef.Properties)
				{
					if (!(propertyDef.Name != "ResourceManager"))
					{
						IList<Instruction> instructions = propertyDef.GetMethod.Body.Instructions;
						int num;
						do
						{
							if (instructions[num].OpCode == OpCodes.Ldstr)
							{
								using (Dictionary<string, string>.Enumerator enumerator5 = NamespacesRenaming._names.GetEnumerator())
								{
									while (enumerator5.MoveNext())
									{
										KeyValuePair<string, string> keyValuePair2 = enumerator5.Current;
										if (instructions[num].ToString().Contains(keyValuePair2.Key))
										{
											instructions[num].Operand = instructions[num].Operand.ToString().Replace(keyValuePair2.Key, keyValuePair2.Value);
										}
									}
									goto IL_147;
								}
								continue;
							}
							IL_147:
							num++;
						}
						while (num < instructions.Count);
					}
				}
			}
			return module;
		}

		// Token: 0x04000067 RID: 103
		private static Dictionary<string, string> _names = new Dictionary<string, string>();
	}
}
