using System;
using System.Runtime.InteropServices;

namespace Rose.Protections
{
	// Token: 0x02000015 RID: 21
	internal class HeaderErase
	{
		// Token: 0x06000035 RID: 53
		[DllImport("kernel32.dll")]
		private static extern IntPtr ZeroMemory(IntPtr addr, IntPtr size);

		// Token: 0x06000036 RID: 54
		[DllImport("kernel32.dll")]
		private static extern IntPtr VirtualProtect(IntPtr lpAddress, IntPtr dwSize, IntPtr flNewProtect, ref IntPtr lpflOldProtect);

		// Token: 0x06000037 RID: 55
		[DllImport("kernel32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr GetModuleHandle(string lpModuleName);

		// Token: 0x06000038 RID: 56 RVA: 0x000065C4 File Offset: 0x000047C4
		public static void OIURC()
		{
			IntPtr moduleHandle = HeaderErase.GetModuleHandle(null);
			IntPtr intPtr;
			HeaderErase.VirtualProtect(moduleHandle, (IntPtr)4096, (IntPtr)4, ref intPtr);
			HeaderErase.ZeroMemory(moduleHandle, (IntPtr)4096);
			intPtr = (IntPtr)0;
		}
	}
}
