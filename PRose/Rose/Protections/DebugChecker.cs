using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Rose.Protections
{
	// Token: 0x0200000C RID: 12
	internal class DebugChecker
	{
		// Token: 0x06000020 RID: 32
		[DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool IsDebuggerPresent();

		// Token: 0x06000021 RID: 33 RVA: 0x00003704 File Offset: 0x00001904
		public static void CEKQW()
		{
			Application.Exit();
			Stopwatch stopwatch;
			do
			{
				if (DebugChecker.IsDebuggerPresent())
				{
					Application.Exit();
				}
				stopwatch.Stop();
				if (stopwatch.ElapsedMilliseconds <= 2500L)
				{
					return;
				}
			}
			while (!Debugger.IsAttached);
			Application.Exit();
			stopwatch = Stopwatch.StartNew();
		}
	}
}
