using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using ns1;

namespace PRose
{
	// Token: 0x02000077 RID: 119
	public partial class Form2 : Form
	{
		// Token: 0x060001A6 RID: 422 RVA: 0x00002680 File Offset: 0x00000880
		public Form2()
		{
			this.InitializeComponent();
		}

		// Token: 0x060001A7 RID: 423 RVA: 0x0002815C File Offset: 0x0002635C
		private void Form2_Load(object sender, EventArgs e)
		{
			base.Opacity = 0.9;
		}

		// Token: 0x060001A8 RID: 424 RVA: 0x000281A4 File Offset: 0x000263A4
		private void obfuscate_Click(object sender, EventArgs e)
		{
			base.Hide();
			Form form;
			form.Show();
			form = new Form1();
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x00016D68 File Offset: 0x00014F68
		private void siticoneButton1_Click(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}
	}
}
