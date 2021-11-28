using System;
using dnlib.DotNet;

namespace Rose.Protections
{
	// Token: 0x02000004 RID: 4
	internal static class AddJunk
	{
		// Token: 0x0600000F RID: 15 RVA: 0x00003158 File Offset: 0x00001358
		public static void Execute(ModuleDefMD module)
		{
			TypeDefUser item2;
			int num2;
			TypeDefUser item4;
			for (;;)
			{
				if (xd.renamertype == "Symbols")
				{
					goto IL_2A;
				}
				goto IL_13A;
				IL_1B3:
				if (xd.renamertype == "Numbers")
				{
					break;
				}
				continue;
				IL_2A:
				if (!(xd.renamertype == "Ascii"))
				{
					goto IL_1B3;
				}
				TypeDefUser item = new TypeDefUser(RUtils.RandomSymbols(xd.thelength), module.CorLibTypes.Object.TypeDefOrRef);
				module.Types.Add(item);
				module.Types.Add(item2);
				TypeDefUser item3;
				module.Types.Add(item3);
				item3 = new TypeDefUser(RUtils.RandomChinese(xd.thelength), module.CorLibTypes.Object.TypeDefOrRef);
				int num = Convert.ToInt32(10);
				IL_13A:
				if (xd.renamertype == "Chinese")
				{
					if (num2 < num)
					{
						goto IL_2A;
					}
					module.Types.Add(item4);
				}
				num2++;
				goto IL_1B3;
			}
			item2 = new TypeDefUser(RUtils.GenerateRandomString2(xd.thelength), module.CorLibTypes.Object.TypeDefOrRef);
			item4 = new TypeDefUser(RUtils.RandomNum(xd.thelength), module.CorLibTypes.Object.TypeDefOrRef);
			num2 = 0;
		}
	}
}
