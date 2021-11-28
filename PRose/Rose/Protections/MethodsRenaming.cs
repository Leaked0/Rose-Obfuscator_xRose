using System;
using System.Collections.Generic;
using dnlib.DotNet;

namespace Rose.Protections
{
	// Token: 0x0200005B RID: 91
	public class MethodsRenaming : IRenaming
	{
		// Token: 0x0600011E RID: 286 RVA: 0x0000C374 File Offset: 0x0000A574
		public ModuleDefMD Rename(ModuleDefMD module)
		{
			using (IEnumerator<TypeDef> enumerator = module.GetTypes().GetEnumerator())
			{
				do
				{
					TypeDef typeDef = enumerator.Current;
					if (!typeDef.IsGlobalModuleType && !(typeDef.Name == "GeneratedInternalTypeHelper"))
					{
						using (IEnumerator<MethodDef> enumerator2 = typeDef.Methods.GetEnumerator())
						{
							while (enumerator2.MoveNext())
							{
								MethodDef methodDef = enumerator2.Current;
								if (methodDef.HasBody && !(methodDef.Name == ".ctor") && !(methodDef.Name == ".cctor"))
								{
									if (xd.renamertype == "Ascii")
									{
										methodDef.Name = RUtils.GenerateRandomString2(xd.thelength);
									}
									if (xd.renamertype == "Numbers")
									{
										methodDef.Name = RUtils.RandomNum(xd.thelength);
									}
									if (xd.renamertype == "Symbols")
									{
										methodDef.Name = RUtils.RandomSymbols(xd.thelength);
									}
									if (xd.renamertype == "Chinese")
									{
										methodDef.Name = RUtils.RandomChinese(xd.thelength);
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
			return module;
		}
	}
}
