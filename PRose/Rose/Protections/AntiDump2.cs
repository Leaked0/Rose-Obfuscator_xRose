using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Rose.Protections
{
	// Token: 0x0200000E RID: 14
	internal static class AntiDump2
	{
		// Token: 0x06000025 RID: 37
		[DllImport("kernel32.dll")]
		public static extern IntPtr ZeroMemory(IntPtr addr, IntPtr size);

		// Token: 0x06000026 RID: 38
		[DllImport("kernel32.dll")]
		public static extern IntPtr VirtualProtect(IntPtr lpAddress, IntPtr dwSize, IntPtr flNewProtect, ref IntPtr lpflOldProtect);

		// Token: 0x06000027 RID: 39 RVA: 0x000043FC File Offset: 0x000025FC
		public static void EraseSection(IntPtr address, int size)
		{
			IntPtr intPtr;
			IntPtr zero;
			IntPtr zero2;
			AntiDump2.VirtualProtect(address, intPtr, zero, ref zero2);
			AntiDump2.ZeroMemory(address, intPtr);
			intPtr = (IntPtr)size;
			AntiDump2.VirtualProtect(address, intPtr, (IntPtr)64, ref zero);
			zero2 = IntPtr.Zero;
			zero = IntPtr.Zero;
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00004468 File Offset: 0x00002668
		public static void WUIOL()
		{
			int num = 1;
			int num2 = 0;
			Process currentProcess;
			IntPtr baseAddress = currentProcess.MainModule.BaseAddress;
			List<int> list = new List<int>
			{
				4, 22, 24, 64, 66, 68, 70, 72, 74, 76,
				92, 94
			};
			int num3;
			int num4;
			for (;;)
			{
				List<int> list2;
				AntiDump2.EraseSection((IntPtr)(baseAddress.ToInt32() + num3 + list2[num4]), 2);
				for (;;)
				{
					int num5;
					if (num5 != 0)
					{
						goto IL_14A;
					}
					num5 = 0;
					short num6 = Marshal.ReadInt16((IntPtr)(baseAddress.ToInt32() + num3 + 6));
					currentProcess = Process.GetCurrentProcess();
					num = 0;
					IL_C6:
					if (num2 <= (int)num6)
					{
						continue;
					}
					num4 = 0;
					if (num < list.Count)
					{
						goto IL_24A;
					}
					AntiDump2.EraseSection((IntPtr)(baseAddress.ToInt32() + num3 + 250 + 40 * num2 + 32), 2);
					num5 = 0;
					list2 = new List<int> { 26, 27 };
					IL_14A:
					num5++;
					num2++;
					List<int> list3 = new List<int> { 8, 12, 16, 20, 24, 28, 36 };
					if (num4 < list2.Count)
					{
						break;
					}
					if (num5 == list3.Count)
					{
						goto Block_1;
					}
					goto IL_C6;
				}
			}
			Block_1:
			IL_24A:
			AntiDump2.EraseSection((IntPtr)(baseAddress.ToInt32() + num3 + list[num]), 1);
			num3 = Marshal.ReadInt32((IntPtr)(baseAddress.ToInt32() + 60));
			num4++;
		}
	}
}
