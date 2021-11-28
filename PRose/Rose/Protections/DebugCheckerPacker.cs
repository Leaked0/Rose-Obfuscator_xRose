using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Rose.Protections
{
	// Token: 0x0200004D RID: 77
	internal class DebugCheckerPacker
	{
		// Token: 0x060000F6 RID: 246
		[DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool IsDebuggerPresent();

		// Token: 0x060000F7 RID: 247 RVA: 0x0000E40C File Offset: 0x0000C60C
		public static void XERPO()
		{
			Stopwatch stopwatch;
			if (stopwatch.ElapsedMilliseconds > 2500L)
			{
				Application.Exit();
				for (;;)
				{
					stopwatch.Stop();
					Application.Exit();
					Application.Exit();
					while (DebugCheckerPacker.IsDebuggerPresent())
					{
						if (Debugger.IsAttached)
						{
							goto Block_3;
						}
					}
				}
				Block_3:
				stopwatch = Stopwatch.StartNew();
			}
		}
	}
}
