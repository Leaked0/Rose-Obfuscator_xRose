using System;
using dnlib.DotNet;

namespace Rose.Protections
{
	// Token: 0x02000004 RID: 4
	internal static class AddJunk
	{
		// Token: 0x0600000F RID: 15 RVA: 0x00002D68 File Offset: 0x00000F68
		public static void Execute(ModuleDefMD module)
		{
			TypeDefUser item2;
			int num2;
			TypeDefUser item4;
			for (;;)
			{
				if (xd.renamertype == "Symbols")
				{
					goto IL_13;
				}
				goto IL_C1;
				IL_F7:
				if (!(xd.renamertype == "Numbers"))
				{
					continue;
				}
				break;
				IL_13:
				if (!(xd.renamertype == "Ascii"))
				{
					goto IL_F7;
				}
				TypeDefUser item = new TypeDefUser(RUtils.RandomSymbols(xd.thelength), module.CorLibTypes.Object.TypeDefOrRef);
				module.Types.Add(item);
				module.Types.Add(item2);
				TypeDefUser item3;
				module.Types.Add(item3);
				item3 = new TypeDefUser(RUtils.RandomChinese(xd.thelength), module.CorLibTypes.Object.TypeDefOrRef);
				int num = Convert.ToInt32(10);
				IL_C1:
				if (xd.renamertype == "Chinese")
				{
					if (num2 < num)
					{
						goto IL_13;
					}
					module.Types.Add(item4);
				}
				num2++;
				goto IL_F7;
			}
			item2 = new TypeDefUser(RUtils.GenerateRandomString2(xd.thelength), module.CorLibTypes.Object.TypeDefOrRef);
			item4 = new TypeDefUser(RUtils.RandomNum(xd.thelength), module.CorLibTypes.Object.TypeDefOrRef);
			num2 = 0;
		}
	}
}
