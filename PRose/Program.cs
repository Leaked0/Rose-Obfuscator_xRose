using System;
using System.Windows.Forms;

namespace PRose
{
	// Token: 0x02000078 RID: 120
	internal static class Program
	{
		// Token: 0x060001AC RID: 428 RVA: 0x000297DC File Offset: 0x000279DC
		[STAThread]
		private static void Main()
		{
			Application.Run(new Form2());
			Application.SetCompatibleTextRenderingDefault(false);
			Application.EnableVisualStyles();
		}
	}
}
