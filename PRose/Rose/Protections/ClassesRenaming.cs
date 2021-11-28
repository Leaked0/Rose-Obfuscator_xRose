using System;
using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Rose.Protections
{
	// Token: 0x02000058 RID: 88
	public class ClassesRenaming : IRenaming
	{
		// Token: 0x06000115 RID: 277 RVA: 0x00010238 File Offset: 0x0000E438
		public ModuleDefMD Rename(ModuleDefMD module)
		{
			using (IEnumerator<TypeDef> enumerator = module.GetTypes().GetEnumerator())
			{
				do
				{
					TypeDef typeDef = enumerator.Current;
					if (!typeDef.IsGlobalModuleType && !(typeDef.Name == "GeneratedInternalTypeHelper") && !(typeDef.Name == "Resources") && !(typeDef.Name == "Settings"))
					{
						string s;
						if (ClassesRenaming._names.TryGetValue(typeDef.Name, out s))
						{
							typeDef.Name = s;
						}
						else
						{
							if (xd.renamertype == "Ascii")
							{
								string value = RUtils.GenerateRandomString2(xd.thelength);
								ClassesRenaming._names.Add(typeDef.Name, value);
								typeDef.Name = RUtils.GenerateRandomString2(xd.thelength);
							}
							if (xd.renamertype == "Numbers")
							{
								string value2 = RUtils.RandomNum(xd.thelength);
								ClassesRenaming._names.Add(typeDef.Name, value2);
								typeDef.Name = RUtils.RandomNum(xd.thelength);
							}
							if (xd.renamertype == "Symbols")
							{
								string value3 = RUtils.RandomSymbols(xd.thelength);
								ClassesRenaming._names.Add(typeDef.Name, value3);
								typeDef.Name = RUtils.RandomSymbols(xd.thelength);
							}
							if (xd.renamertype == "Chinese")
							{
								string value4 = RUtils.RandomChinese(xd.thelength);
								ClassesRenaming._names.Add(typeDef.Name, value4);
								typeDef.Name = RUtils.RandomChinese(xd.thelength);
							}
						}
					}
				}
				while (enumerator.MoveNext());
			}
			return ClassesRenaming.ApplyChangesToResources(module);
		}

		// Token: 0x06000116 RID: 278 RVA: 0x000104D4 File Offset: 0x0000E6D4
		private static ModuleDefMD ApplyChangesToResources(ModuleDefMD module)
		{
			using (IEnumerator<Resource> enumerator = module.Resources.GetEnumerator())
			{
				do
				{
					Resource resource = enumerator.Current;
					foreach (KeyValuePair<string, string> keyValuePair in ClassesRenaming._names)
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
								foreach (KeyValuePair<string, string> keyValuePair2 in ClassesRenaming._names)
								{
									if (instructions[num].Operand.ToString().Contains(keyValuePair2.Key))
									{
										instructions[num].Operand = instructions[num].Operand.ToString().Replace(keyValuePair2.Key, keyValuePair2.Value);
									}
								}
							}
							num++;
						}
						while (num < instructions.Count);
					}
				}
			}
			return module;
		}

		// Token: 0x04000065 RID: 101
		private static Dictionary<string, string> _names = new Dictionary<string, string>();
	}
}
