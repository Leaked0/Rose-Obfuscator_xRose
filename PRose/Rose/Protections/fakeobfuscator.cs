using System;
using dnlib.DotNet;

namespace Rose.Protections
{
	// Token: 0x0200003C RID: 60
	internal static class fakeobfuscator
	{
		// Token: 0x060000C6 RID: 198 RVA: 0x0000B5AC File Offset: 0x000097AC
		public static void Execute(ModuleDefMD module)
		{
			int num;
			do
			{
				TypeDefUser typeDefUser = new TypeDefUser(fakeobfuscator.attrib[num], fakeobfuscator.attrib[num], module.CorLibTypes.Object.TypeDefOrRef);
				num++;
				module.Types.Add(typeDefUser);
				typeDefUser.Attributes = TypeAttributes.WindowsRuntime;
			}
			while (num < fakeobfuscator.attrib.Length);
			num = 0;
		}

		// Token: 0x04000052 RID: 82
		private static string[] attrib = new string[]
		{
			RUtils.RandomSymbols(xd.thelength),
			"RoseObfuscator",
			"ObfuscatedByRose",
			"Yano",
			"Xenocode",
			"PoweredByAttribute",
			"ObfuscatedByGoliath",
			"NineRays.Obfuscator.Evaluation",
			"NetGuard",
			"dotNetProtector",
			"DotNetPatcher",
			"Dotfuscator",
			"CryptoObfuscator",
			"BabelObfuscator"
		};
	}
}
