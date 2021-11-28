using System;
using System.Collections.Generic;
using dnlib.DotNet;

namespace Rose.Protections
{
	// Token: 0x0200005E RID: 94
	public class PropertiesRenaming : IRenaming
	{
		// Token: 0x06000126 RID: 294 RVA: 0x00011710 File Offset: 0x0000F910
		public ModuleDefMD Rename(ModuleDefMD module)
		{
			using (IEnumerator<TypeDef> enumerator = module.GetTypes().GetEnumerator())
			{
				do
				{
					TypeDef typeDef = enumerator.Current;
					if (!typeDef.IsGlobalModuleType)
					{
						foreach (PropertyDef propertyDef in typeDef.Properties)
						{
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
					}
				}
				while (enumerator.MoveNext());
			}
			return module;
		}
	}
}
