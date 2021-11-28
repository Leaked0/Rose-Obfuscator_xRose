using System;
using System.Runtime.InteropServices;

namespace Rose.Protections
{
	// Token: 0x0200004E RID: 78
	internal class HeaderErasePacker
	{
		// Token: 0x060000F9 RID: 249
		[DllImport("kernel32.dll")]
		private static extern IntPtr ZeroMemory(IntPtr addr, IntPtr size);

		// Token: 0x060000FA RID: 250
		[DllImport("kernel32.dll")]
		private static extern IntPtr VirtualProtect(IntPtr lpAddress, IntPtr dwSize, IntPtr flNewProtect, ref IntPtr lpflOldProtect);

		// Token: 0x060000FB RID: 251
		[DllImport("kernel32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr GetModuleHandle(string lpModuleName);

		// Token: 0x060000FC RID: 252 RVA: 0x0000E4EC File Offset: 0x0000C6EC
		public static void KOISZ()
		{
			IntPtr moduleHandle;
			HeaderErasePacker.ZeroMemory(moduleHandle, (IntPtr)4096);
			IntPtr intPtr;
			HeaderErasePacker.VirtualProtect(moduleHandle, (IntPtr)4096, (IntPtr)4, ref intPtr);
			intPtr = (IntPtr)0;
			moduleHandle = HeaderErasePacker.GetModuleHandle(null);
		}
	}
}
