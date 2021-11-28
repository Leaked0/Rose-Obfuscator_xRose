using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using dnlib.DotNet;
using dnlib.DotNet.Writer;
using ns1;
using Rose.Protections;

namespace PRose
{
	// Token: 0x02000076 RID: 118
	public partial class Form1 : Form
	{
		// Token: 0x06000179 RID: 377 RVA: 0x00002672 File Offset: 0x00000872
		public Form1()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600017A RID: 378 RVA: 0x00016B50 File Offset: 0x00014D50
		private void Form1_Load(object sender, EventArgs e)
		{
			xd.renamertype = "Ascii";
			base.Opacity = 0.9;
			this.siticonePanel5.AllowDrop = true;
			this.siticonePanel8.AllowDrop = true;
			this.assemblytext.AllowDrop = true;
			this.AsciiType.Checked = true;
			this.SNKText.Text = Directory.GetCurrentDirectory() + "\\snk.snk";
			base.Activate();
			this.SNKText.AllowDrop = true;
		}

		// Token: 0x0600017B RID: 379
		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

		// Token: 0x0600017C RID: 380
		[DllImport("user32.dll")]
		public static extern bool ReleaseCapture();

		// Token: 0x0600017D RID: 381 RVA: 0x00016C98 File Offset: 0x00014E98
		private void movelbl_MouseDown(object sender, MouseEventArgs e)
		{
			Form1.ReleaseCapture();
			Form1.SendMessage(base.Handle, 161, 2, 0);
		}

		// Token: 0x0600017E RID: 382 RVA: 0x00016C98 File Offset: 0x00014E98
		private void movelbl2_MouseDown(object sender, MouseEventArgs e)
		{
			Form1.ReleaseCapture();
			Form1.SendMessage(base.Handle, 161, 2, 0);
		}

		// Token: 0x0600017F RID: 383 RVA: 0x00016C98 File Offset: 0x00014E98
		private void siticoneLabel2_MouseDown(object sender, MouseEventArgs e)
		{
			Form1.ReleaseCapture();
			Form1.SendMessage(base.Handle, 161, 2, 0);
		}

		// Token: 0x06000180 RID: 384 RVA: 0x00016C98 File Offset: 0x00014E98
		private void movepnl_MouseDown(object sender, MouseEventArgs e)
		{
			Form1.ReleaseCapture();
			Form1.SendMessage(base.Handle, 161, 2, 0);
		}

		// Token: 0x06000181 RID: 385 RVA: 0x00016D00 File Offset: 0x00014F00
		private void siticoneLabel8_MouseDown(object sender, MouseEventArgs e)
		{
			Form1.SendMessage(base.Handle, 161, 2, 0);
			Form1.ReleaseCapture();
		}

		// Token: 0x06000182 RID: 386 RVA: 0x00016C98 File Offset: 0x00014E98
		private void siticoneLabel16_MouseDown(object sender, MouseEventArgs e)
		{
			Form1.ReleaseCapture();
			Form1.SendMessage(base.Handle, 161, 2, 0);
		}

		// Token: 0x06000183 RID: 387 RVA: 0x00016D68 File Offset: 0x00014F68
		private void exit_Click(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}

		// Token: 0x06000184 RID: 388 RVA: 0x00016DA8 File Offset: 0x00014FA8
		private void min_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
		}

		// Token: 0x06000185 RID: 389 RVA: 0x00016DEC File Offset: 0x00014FEC
		private void renamer_CheckedChanged(object sender, EventArgs e)
		{
			if (this.renamer.Checked)
			{
				this.renamer2.Checked = false;
			}
		}

		// Token: 0x06000186 RID: 390 RVA: 0x00016E54 File Offset: 0x00015054
		private void renamer2_CheckedChanged(object sender, EventArgs e)
		{
			this.renamer.Checked = false;
			if (this.renamer2.Checked)
			{
			}
		}

		// Token: 0x06000187 RID: 391 RVA: 0x00016EBC File Offset: 0x000150BC
		private void packer_CheckedChanged(object sender, EventArgs e)
		{
			this.atamper.Checked = false;
			this.virt.Checked = false;
			this.apacker.Checked = false;
			if (this.packer.Checked)
			{
			}
		}

		// Token: 0x06000188 RID: 392 RVA: 0x00016F68 File Offset: 0x00015168
		private void apacker_CheckedChanged(object sender, EventArgs e)
		{
			this.invalidmd.Checked = false;
			if (this.apacker.Checked)
			{
				this.packer.Checked = false;
				this.hmethods.Checked = false;
				this.virt.Checked = false;
				this.atamper.Checked = false;
			}
		}

		// Token: 0x06000189 RID: 393 RVA: 0x00017054 File Offset: 0x00015254
		private void virt_CheckedChanged(object sender, EventArgs e)
		{
			this.virt.Checked = false;
			if (this.virt.Checked)
			{
			}
		}

		// Token: 0x0600018A RID: 394 RVA: 0x000170BC File Offset: 0x000152BC
		private void signer_CheckedChanged(object sender, EventArgs e)
		{
			this.virt.Checked = false;
			if (this.signer.Checked)
			{
			}
		}

		// Token: 0x0600018B RID: 395 RVA: 0x00017124 File Offset: 0x00015324
		private void atamper_CheckedChanged(object sender, EventArgs e)
		{
			this.packer.Checked = false;
			if (this.atamper.Checked)
			{
				this.apacker.Checked = false;
				this.virt.Checked = false;
			}
		}

		// Token: 0x0600018C RID: 396 RVA: 0x000171D0 File Offset: 0x000153D0
		private void invalidmd_CheckedChanged(object sender, EventArgs e)
		{
			this.apacker.Checked = false;
			this.virt.Checked = false;
			if (this.invalidmd.Checked)
			{
			}
		}

		// Token: 0x0600018D RID: 397 RVA: 0x0001725C File Offset: 0x0001545C
		private void hmethods_CheckedChanged(object sender, EventArgs e)
		{
			this.virt.Checked = false;
			if (this.hmethods.Checked)
			{
				this.apacker.Checked = false;
			}
		}

		// Token: 0x0600018E RID: 398 RVA: 0x000172E8 File Offset: 0x000154E8
		private void BaseSenc_CheckedChanged(object sender, EventArgs e)
		{
			if (this.BaseSenc.Checked)
			{
				this.cconfusion.Checked = false;
			}
		}

		// Token: 0x0600018F RID: 399 RVA: 0x00017350 File Offset: 0x00015550
		private void cconfusion_CheckedChanged(object sender, EventArgs e)
		{
			if (this.cconfusion.Checked)
			{
				this.BaseSenc.Checked = false;
			}
		}

		// Token: 0x06000190 RID: 400 RVA: 0x000173B8 File Offset: 0x000155B8
		private void alllength_ValueChanged(object sender, EventArgs e)
		{
			xd.thelength = this.alllength.Value;
			this.siticoneLabel19.Text = this.alllength.Value.ToString();
		}

		// Token: 0x06000191 RID: 401 RVA: 0x00017438 File Offset: 0x00015638
		private void checkall_Click(object sender, EventArgs e)
		{
			this.mstrip.Checked = true;
			this.hmethods.Checked = true;
			this.pmobf.Checked = true;
			this.BaseSenc.Checked = true;
			this.adump.Checked = true;
			this.cryptosenc.Checked = true;
			this.renamer.Checked = true;
			this.pint.Checked = true;
			this.pobf.Checked = true;
			this.hnamespaces.Checked = true;
			this.uncheckall.Visible = true;
			this.checkall.Visible = false;
			this.ade4dot.Checked = true;
			this.asciisenc.Checked = true;
			this.cconfusion.Checked = true;
			this.adebug.Checked = true;
			this.invalidmd.Checked = true;
			this.ajunk.Checked = true;
			this.omethods.Checked = true;
			this.aildasm.Checked = true;
			this.fobf.Checked = true;
			this.hstr.Checked = true;
			this.mutation.Checked = true;
			this.atamper.Checked = true;
			this.arith.Checked = true;
			this.cflow.Checked = true;
			this.sconfusion.Checked = true;
		}

		// Token: 0x06000192 RID: 402 RVA: 0x000177DC File Offset: 0x000159DC
		private void uncheckall_Click(object sender, EventArgs e)
		{
			this.hnamespaces.Checked = false;
			this.adebug.Checked = false;
			this.asciisenc.Checked = false;
			this.hmethods.Checked = false;
			this.ajunk.Checked = false;
			this.pobf.Checked = false;
			this.ade4dot.Checked = false;
			this.hstr.Checked = false;
			this.mutation.Checked = false;
			this.arith.Checked = false;
			this.renamer.Checked = false;
			this.aildasm.Checked = false;
			this.adump.Checked = false;
			this.cconfusion.Checked = false;
			this.uncheckall.Visible = false;
			this.mstrip.Checked = false;
			this.cflow.Checked = false;
			this.invalidmd.Checked = false;
			this.checkall.Visible = true;
			this.cryptosenc.Checked = false;
			this.pmobf.Checked = false;
			this.pint.Checked = false;
			this.atamper.Checked = false;
			this.omethods.Checked = false;
			this.sconfusion.Checked = false;
			this.BaseSenc.Checked = false;
			this.fobf.Checked = false;
		}

		// Token: 0x06000193 RID: 403 RVA: 0x00017B80 File Offset: 0x00015D80
		private void discord_Click(object sender, EventArgs e)
		{
			Clipboard.SetText("xRose#0308");
			DialogResult dialogResult = MessageBox.Show("Discord : xRose#0308" + Environment.NewLine + "Press ok to Copy it .", "Discord", MessageBoxButtons.OK);
			if (dialogResult == DialogResult.OK)
			{
			}
		}

		// Token: 0x06000194 RID: 404 RVA: 0x00017C10 File Offset: 0x00015E10
		private void facebook_Click(object sender, EventArgs e)
		{
			Process.Start("https://www.facebook.com/String.xRose");
		}

		// Token: 0x06000195 RID: 405 RVA: 0x00017C50 File Offset: 0x00015E50
		private void donation_Click(object sender, EventArgs e)
		{
			Process.Start("https://www.paypal.com/paypalme/inx707");
		}

		// Token: 0x06000196 RID: 406 RVA: 0x00017C50 File Offset: 0x00015E50
		private void siticoneLabel9_Click(object sender, EventArgs e)
		{
			Process.Start("https://www.paypal.com/paypalme/inx707");
		}

		// Token: 0x06000197 RID: 407 RVA: 0x00017C90 File Offset: 0x00015E90
		private void browse_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog;
			openFileDialog.Filter = ".NET Assembly (*.exe)|*.exe|(*.dll)|*.dll";
			openFileDialog = new OpenFileDialog();
			this.assemblytext.Text = openFileDialog.FileName;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				openFileDialog.Title = "Load Assembly";
				this.log.Items.Add("Loaded : " + this.assembly);
				this.assembly = openFileDialog.FileName;
				this.log.Items.Clear();
				openFileDialog.Multiselect = false;
			}
		}

		// Token: 0x06000198 RID: 408 RVA: 0x00017DE0 File Offset: 0x00015FE0
		private void assemblytext_DragDrop(object sender, DragEventArgs e)
		{
			try
			{
				Array array = (Array)e.Data.GetData(DataFormats.FileDrop);
				if (array != null)
				{
					string text = array.GetValue(0).ToString();
					int num = text.LastIndexOf(".");
					int startIndex = text.LastIndexOf("\\");
					if (num != -1)
					{
						string text2 = text.Substring(num);
						text2 = text2.ToLower();
						if (text2 == ".exe" || text2 == ".dll")
						{
							base.Activate();
							this.assemblytext.Text = text;
							this.assembly = this.assemblytext.Text;
							string text3 = text.Substring(startIndex);
							this.log.Items.Clear();
							this.log.Items.Add("Loaded : " + text3.Replace("\\", null));
							this.log.SelectedIndex = 0;
						}
					}
				}
			}
			catch (Exception)
			{
				MessageBox.Show("Please load .net assembly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				this.assemblytext.Clear();
			}
		}

		// Token: 0x06000199 RID: 409 RVA: 0x00017FA0 File Offset: 0x000161A0
		private void assemblytext_DragEnter(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.Copy;
			e.Effect = DragDropEffects.None;
		}

		// Token: 0x0600019A RID: 410 RVA: 0x00018034 File Offset: 0x00016234
		private void obfuscate_Click_1(object sender, EventArgs e)
		{
			global::Context.PackerPhase();
			this.log.Items.Add("Executed : Proxy Obfuscation");
			if (!this.signer.Checked)
			{
				goto IL_4BB;
			}
			ModuleDefMD moduleDefMD;
			StringEncoder.Execute(moduleDefMD);
			IL_7A:
			if (!this.pmobf.Checked)
			{
				goto IL_867;
			}
			global::Context.SaveModule();
			IL_AE:
			if (!this.asciisenc.Checked)
			{
				goto IL_BC3;
			}
			ModuleWriterOptions moduleWriterOptions;
			StrongNameKey signatureKey;
			moduleWriterOptions.InitializeStrongNameSigning(moduleDefMD, signatureKey);
			this.log.Items.Add("Executed : Hide Methods");
			IL_115:
			AntiDumpMethod3.InjectEraseMethod(moduleDefMD);
			IL_12C:
			Watermark.Execute(moduleDefMD);
			this.log.Items.Add("Executed : Anti De4dot");
			AntiDe4dot.Execute1(moduleDefMD.Assembly);
			hideMethods.Execute(moduleDefMD);
			IL_1C3:
			if (!this.invalidmd.Checked)
			{
				goto IL_12C;
			}
			First.Execute(moduleDefMD);
			this.log.Items.Add("Executed : Control Flow");
			Hidenamespaces.Execute(moduleDefMD);
			ModuleWriterOptions moduleWriterOptions2;
			StrongNameKey signatureKey2;
			moduleWriterOptions2.InitializeStrongNameSigning(moduleDefMD, signatureKey2);
			this.log.Items.Add("Executed : Calli Confusion");
			if (moduleDefMD.Is32BitRequired)
			{
				goto IL_57A;
			}
			IL_29B:
			AntiDumpMethod3.InjectEraseMethod(moduleDefMD);
			this.log.Items.Add("Executed : Renamer");
			moduleDefMD = null;
			IL_2EC:
			if (!this.apacker.Checked)
			{
				goto IL_42D;
			}
			Arithmetic.Execute(moduleDefMD);
			this.log.Items.Add("Packed Successfully");
			StackUnfConfusion.Execute(moduleDefMD);
			IL_362:
			ModuleContext context = null;
			if (!this.signer.Checked)
			{
				goto IL_108F;
			}
			InvalidMDPhase.Execute(moduleDefMD.Assembly);
			AntiDebug.Execute(moduleDefMD);
			this.log.Items.Add("Executed : Add Junks");
			Calli.Execute(moduleDefMD);
			IL_407:
			if (!this.assembly.EndsWith(".dll"))
			{
				return;
			}
			IL_42D:
			if (!this.packer.Checked)
			{
				goto IL_362;
			}
			this.log.Items.Add("Assembly Signed Successfully");
			signatureKey = new StrongNameKey(this.SNKText.Text);
			IL_49A:
			if (!this.cflow.Checked)
			{
				goto IL_51D;
			}
			IL_4BB:
			moduleWriterOptions2.MetaDataOptions.Flags = MetaDataFlags.PreserveAll;
			hideStrings.Execute(moduleDefMD);
			bool flag = false;
			global::Context.PackerPhase();
			IL_51D:
			if (!this.omethods.Checked)
			{
				goto IL_E6F;
			}
			signatureKey2 = new StrongNameKey(this.SNKText.Text);
			AntiILDasm.Execute(moduleDefMD);
			IL_57A:
			if (!this.BaseSenc.Checked)
			{
				goto IL_AE;
			}
			this.log.Items.Add("Packed Successfully");
			moduleWriterOptions.Logger = DummyLogger.NoThrowInstance;
			AntiDumpMethod1.Execute(moduleDefMD);
			Mutation.Execute(moduleDefMD);
			flag = true;
			this.log.Items.Add("Obfuscated Successfully");
			IL_64A:
			if (!this.cconfusion.Checked)
			{
				goto IL_BA2;
			}
			string text;
			moduleDefMD.Write(text, moduleWriterOptions2);
			this.log.Items.Add("Executed : Proxy Int Obfuscation");
			NewRenamerObfuscation.DoRenaming(moduleDefMD);
			IL_6C8:
			if (!this.ajunk.Checked)
			{
				goto IL_CEA;
			}
			string text2 = this.assembly + "-ROSED.dll";
			this.log.Items.Add("Executed : Invalid Meta Data");
			IL_735:
			if (!this.mutation.Checked)
			{
				goto IL_49A;
			}
			this.log.Items.Add("Executed : Ascii Strings Encryption");
			File.WriteAllBytes(text2, Packer2.Pack(text2, text2, RUtils.GenerateRandomString2(5), true, true));
			this.log.Items.Add("Packed Successfully");
			this.log.Items.Add("Executed : Anti Debug");
			this.log.Items.Add("Executed : Renamer 2");
			this.hmethods.Checked = false;
			moduleWriterOptions2.Logger = DummyLogger.NoThrowInstance;
			IL_867:
			if (!this.pint.Checked)
			{
				goto IL_735;
			}
			moduleDefMD.Write(text2, moduleWriterOptions);
			IL_8A7:
			if (!this.atamper.Checked)
			{
				goto IL_64A;
			}
			ProxyInt.Execute(moduleDefMD);
			this.log.Items.Add("Executed : Arithmetic");
			IL_906:
			if (!this.aildasm.Checked)
			{
				goto IL_8A7;
			}
			if (!this.assembly.EndsWith(".exe"))
			{
				goto IL_407;
			}
			global::Context.LoadModule(text);
			if (this.packer.Checked)
			{
				goto IL_115;
			}
			fakeobfuscator.Execute(moduleDefMD);
			moduleDefMD = ModuleDefMD.Load(this.assembly, context);
			this.log.Items.Add("Executed : Random Outline Methods");
			this.log.Items.Add("Executed : Proxy Meth Obfuscation");
			RenamerObfuscation.Execute(moduleDefMD);
			text = this.assembly + "-ROSED.exe";
			this.log.Items.Add("Executed : Anti Tamper");
			this.log.Items.Add("Executed : Fake Obfuscator");
			global::Context.SaveModule();
			IL_AAB:
			if (!this.adump.Checked)
			{
				goto IL_906;
			}
			moduleDefMD = null;
			ModuleWriterOptions moduleWriterOptions3 = AntiDe4dot.Execute(moduleDefMD);
			ControlFlow.Execute(moduleDefMD);
			AddJunk.Execute(moduleDefMD);
			AntiDebug2.Execute(moduleDefMD);
			IL_B3F:
			if (!this.renamer.Checked)
			{
				goto IL_D2C;
			}
			this.log.Items.Add("Executed : Anti Dump");
			moduleWriterOptions = new ModuleWriterOptions(moduleDefMD);
			IL_BA2:
			if (!this.sconfusion.Checked)
			{
				goto IL_F23;
			}
			IL_BC3:
			if (!this.cryptosenc.Checked)
			{
				goto IL_10EE;
			}
			this.log.Items.Add("Executed : Base64 Strings Encryption");
			IL_C0B:
			if (!this.packer.Checked)
			{
				goto IL_107C;
			}
			RandomOutlinedMethods.Execute(moduleDefMD);
			this.log.Items.Add("Executed : Meta Strip");
			if (!flag)
			{
				goto IL_1044;
			}
			IL_C81:
			if (!this.hnamespaces.Checked)
			{
				goto IL_B3F;
			}
			this.log.Items.Add("Packed Successfully");
			this.invalidmd.Checked = false;
			IL_CEA:
			if (this.ade4dot.Checked)
			{
			}
			if (!this.mstrip.Checked)
			{
				goto IL_FCA;
			}
			IL_D2C:
			if (!this.renamer2.Checked)
			{
				goto IL_6C8;
			}
			IL_D4D:
			if (!this.adebug.Checked)
			{
				goto IL_AAB;
			}
			this.log.Items.Add("Executed : Crypto Strings Encryption");
			AntiTamper.Sha256(text2);
			this.log.Items.Add("Executed : Hide Namespaces");
			ProxyMeth.Execute(moduleDefMD);
			this.log.Items.Clear();
			this.log.Items.Add("Assembly Signed Successfully");
			global::Context.LoadModule(text2);
			if (!flag)
			{
				goto IL_2EC;
			}
			IL_E6F:
			if (!this.arith.Checked)
			{
				goto IL_C81;
			}
			moduleWriterOptions2 = new ModuleWriterOptions(moduleDefMD);
			this.log.Items.Add("Executed : Stack Confusion");
			AntiTamper.Execute(moduleDefMD);
			this.log.Items.Add("Executed : Anti ILDasm");
			IL_F23:
			if (!this.pobf.Checked)
			{
				goto IL_7A;
			}
			this.log.Items.Add("Executed : Mutation");
			IL_F6B:
			if (!this.fobf.Checked)
			{
				goto IL_1C3;
			}
			this.log.Items.Add("Executed : Anti Dump For Packer");
			AntiTamper.Sha256(text);
			IL_FCA:
			if (!this.hmethods.Checked)
			{
				goto IL_F6B;
			}
			AssemblyDef assemblyDef = moduleDefMD.Assembly;
			this.log.Items.Add("Obfuscated Successfully");
			context = ModuleDef.CreateModuleContext();
			IL_1044:
			if (!this.apacker.Checked)
			{
				goto IL_C0B;
			}
			proxy.Execute(moduleDefMD);
			IL_107C:
			context = null;
			IL_108F:
			moduleWriterOptions.MetaDataOptions.Flags = MetaDataFlags.PreserveAll;
			MetaStrip.Execute(moduleDefMD);
			this.log.Items.Add("Executed : Hide Strings");
			IL_10EE:
			if (!this.hstr.Checked)
			{
				goto IL_D4D;
			}
			Enc.EncryptStrings(moduleDefMD);
			if (!this.apacker.Checked)
			{
				goto IL_29B;
			}
			File.WriteAllBytes(text, Packer2.Pack(text, text, RUtils.GenerateRandomString2(5), true, true));
		}

		// Token: 0x0600019B RID: 411 RVA: 0x000191D4 File Offset: 0x000173D4
		private void cflow_CheckedChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x0600019C RID: 412 RVA: 0x0001926C File Offset: 0x0001746C
		private void cflowTrackBar_Scroll(object sender, ScrollEventArgs e)
		{
			while (this.cflowTrackBar.Value == 5)
			{
				this.cflowStatus.Text = "Normal";
				xd.cflowint = 5;
				for (;;)
				{
					if (this.cflowTrackBar.Value != 3 || this.cflowTrackBar.Value == 1)
					{
						if (this.cflowTrackBar.Value != 4)
						{
							break;
						}
						xd.cflowint = 4;
						this.cflowStatus.Text = "Aggressive";
						xd.cflowint = 1;
						xd.cflowint = 3;
						xd.cflowint = 2;
						this.cflowStatus.Text = "Minimum";
						this.cflowStatus.Text = "None";
						this.cflowStatus.Text = "Maximum";
					}
					if (this.cflowTrackBar.Value == 2)
					{
						return;
					}
				}
			}
		}

		// Token: 0x0600019D RID: 413 RVA: 0x00019470 File Offset: 0x00017670
		private void AsciiType_CheckedChanged(object sender, EventArgs e)
		{
			xd.renamertype = "Ascii";
		}

		// Token: 0x0600019E RID: 414 RVA: 0x000194B0 File Offset: 0x000176B0
		private void NumbersType_CheckedChanged(object sender, EventArgs e)
		{
			xd.renamertype = "Numbers";
		}

		// Token: 0x0600019F RID: 415 RVA: 0x000194F0 File Offset: 0x000176F0
		private void ChineseType_CheckedChanged(object sender, EventArgs e)
		{
			xd.renamertype = "Chinese";
		}

		// Token: 0x060001A0 RID: 416 RVA: 0x00019530 File Offset: 0x00017730
		private void SymbolsType_CheckedChanged(object sender, EventArgs e)
		{
			xd.renamertype = "Symbols";
		}

		// Token: 0x060001A1 RID: 417 RVA: 0x00019570 File Offset: 0x00017770
		private void BrowseSNK_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog;
			this.assembly = openFileDialog.FileName;
			openFileDialog = new OpenFileDialog();
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.SNKText.Text = openFileDialog.FileName;
				openFileDialog.Title = "Load Assembly";
				openFileDialog.Multiselect = false;
				openFileDialog.Filter = "Strong name key (*.snk)|*.snk";
				this.log.Items.Clear();
			}
		}

		// Token: 0x060001A2 RID: 418 RVA: 0x00019688 File Offset: 0x00017888
		private void SNKText_DragDrop(object sender, DragEventArgs e)
		{
			try
			{
				Array array = (Array)e.Data.GetData(DataFormats.FileDrop);
				if (array != null)
				{
					string text = array.GetValue(0).ToString();
					int num = text.LastIndexOf(".");
					int startIndex = text.LastIndexOf("\\");
					if (num != -1)
					{
						string text2 = text.Substring(num);
						text2 = text2.ToLower();
						if (text2 == ".snk")
						{
							base.Activate();
							this.SNKText.Text = text;
							string text3 = text.Substring(startIndex);
							this.log.Items.Clear();
							this.log.SelectedIndex = 0;
						}
					}
				}
			}
			catch (Exception)
			{
				MessageBox.Show("Please load .snk", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				this.SNKText.Clear();
			}
		}

		// Token: 0x060001A3 RID: 419 RVA: 0x000197E4 File Offset: 0x000179E4
		private void SNKText_DragEnter(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.Copy;
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				return;
			}
			e.Effect = DragDropEffects.None;
		}

		// Token: 0x04000087 RID: 135
		public const int WM_NCLBUTTONDOWN = 161;

		// Token: 0x04000088 RID: 136
		public const int HT_CAPTION = 2;

		// Token: 0x04000089 RID: 137
		private string assembly;
	}
}
