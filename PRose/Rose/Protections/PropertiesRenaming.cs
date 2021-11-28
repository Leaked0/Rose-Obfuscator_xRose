using System;
using System.Collections.Generic;
using dnlib.DotNet;

namespace Rose.Protections
{
	// Token: 0x0200005E RID: 94
	public class PropertiesRenaming : IRenaming
	{
		// Token: 0x06000126 RID: 294 RVA: 0x0000CBDC File Offset: 0x0000ADDC
		public ModuleDefMD Rename(ModuleDefMD module)
		{
			using (IEnumerator<TypeDef> enumerator = module.GetTypes().GetEnumerator())
			{
				do
				{
					TypeDef typeDef = enumerator.Current;
					if (!typeDef.IsGlobalModuleType)
					{
						using (IEnumerator<PropertyDef> enumerator2 = typeDef.Properties.GetEnumerator())
						{
							while (enumerator2.MoveNext())
							{
								PropertyDef propertyDef = enumerator2.Current;
								if (xd.renamertype == "Ascii")
								{
									propertyDef.Name = RUtils.GenerateRandomString2(xd.thelength);
								}
								if (xd.renamertype == "Numbers")
								{
									propertyDef.Name = RUtils.RandomNum(xd.thelength);
								}
								if (xd.renamertype == "Symbols")
								{
									propertyDef.Name = RUtils.RandomSymbols(xd.thelength);
								}
								if (xd.renamertype == "Chinese")
								{
									propertyDef.Name = RUtils.RandomChinese(xd.thelength);
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
	}
}
