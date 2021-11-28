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

		// Token: 0x0600017A RID: 378 RVA: 0x00010B58 File Offset: 0x0000ED58
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

		// Token: 0x0600017D RID: 381 RVA: 0x00010C08 File Offset: 0x0000EE08
		private void movelbl_MouseDown(object sender, MouseEventArgs e)
		{
			Form1.ReleaseCapture();
			Form1.SendMessage(base.Handle, 161, 2, 0);
		}

		// Token: 0x0600017E RID: 382 RVA: 0x00010C08 File Offset: 0x0000EE08
		private void movelbl2_MouseDown(object sender, MouseEventArgs e)
		{
			Form1.ReleaseCapture();
			Form1.SendMessage(base.Handle, 161, 2, 0);
		}

		// Token: 0x0600017F RID: 383 RVA: 0x00010C08 File Offset: 0x0000EE08
		private void siticoneLabel2_MouseDown(object sender, MouseEventArgs e)
		{
			Form1.ReleaseCapture();
			Form1.SendMessage(base.Handle, 161, 2, 0);
		}

		// Token: 0x06000180 RID: 384 RVA: 0x00010C08 File Offset: 0x0000EE08
		private void movepnl_MouseDown(object sender, MouseEventArgs e)
		{
			Form1.ReleaseCapture();
			Form1.SendMessage(base.Handle, 161, 2, 0);
		}

		// Token: 0x06000181 RID: 385 RVA: 0x00010C3C File Offset: 0x0000EE3C
		private void siticoneLabel8_MouseDown(object sender, MouseEventArgs e)
		{
			Form1.SendMessage(base.Handle, 161, 2, 0);
			Form1.ReleaseCapture();
		}

		// Token: 0x06000182 RID: 386 RVA: 0x00010C08 File Offset: 0x0000EE08
		private void siticoneLabel16_MouseDown(object sender, MouseEventArgs e)
		{
			Form1.ReleaseCapture();
			Form1.SendMessage(base.Handle, 161, 2, 0);
		}

		// Token: 0x06000183 RID: 387 RVA: 0x00010C70 File Offset: 0x0000EE70
		private void exit_Click(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}

		// Token: 0x06000184 RID: 388 RVA: 0x00010C88 File Offset: 0x0000EE88
		private void min_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
		}

		// Token: 0x06000185 RID: 389 RVA: 0x00010CA4 File Offset: 0x0000EEA4
		private void renamer_CheckedChanged(object sender, EventArgs e)
		{
			if (this.renamer.Checked)
			{
				this.renamer2.Checked = false;
			}
		}

		// Token: 0x06000186 RID: 390 RVA: 0x00010CD4 File Offset: 0x0000EED4
		private void renamer2_CheckedChanged(object sender, EventArgs e)
		{
			this.renamer.Checked = false;
			if (!this.renamer2.Checked)
			{
			}
		}

		// Token: 0x06000187 RID: 391 RVA: 0x00010D04 File Offset: 0x0000EF04
		private void packer_CheckedChanged(object sender, EventArgs e)
		{
			this.atamper.Checked = false;
			this.virt.Checked = false;
			this.apacker.Checked = false;
			if (!this.packer.Checked)
			{
			}
		}

		// Token: 0x06000188 RID: 392 RVA: 0x00010D5C File Offset: 0x0000EF5C
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

		// Token: 0x06000189 RID: 393 RVA: 0x00010DD8 File Offset: 0x0000EFD8
		private void virt_CheckedChanged(object sender, EventArgs e)
		{
			this.virt.Checked = false;
			if (!this.virt.Checked)
			{
			}
		}

		// Token: 0x0600018A RID: 394 RVA: 0x00010E08 File Offset: 0x0000F008
		private void signer_CheckedChanged(object sender, EventArgs e)
		{
			this.virt.Checked = false;
			if (!this.signer.Checked)
			{
			}
		}

		// Token: 0x0600018B RID: 395 RVA: 0x00010E38 File Offset: 0x0000F038
		private void atamper_CheckedChanged(object sender, EventArgs e)
		{
			this.packer.Checked = false;
			if (this.atamper.Checked)
			{
				this.apacker.Checked = false;
				this.virt.Checked = false;
			}
		}

		// Token: 0x0600018C RID: 396 RVA: 0x00010E90 File Offset: 0x0000F090
		private void invalidmd_CheckedChanged(object sender, EventArgs e)
		{
			this.apacker.Checked = false;
			this.virt.Checked = false;
			if (!this.invalidmd.Checked)
			{
			}
		}

		// Token: 0x0600018D RID: 397 RVA: 0x00010ED4 File Offset: 0x0000F0D4
		private void hmethods_CheckedChanged(object sender, EventArgs e)
		{
			this.virt.Checked = false;
			if (this.hmethods.Checked)
			{
				this.apacker.Checked = false;
			}
		}

		// Token: 0x0600018E RID: 398 RVA: 0x00010F18 File Offset: 0x0000F118
		private void BaseSenc_CheckedChanged(object sender, EventArgs e)
		{
			if (this.BaseSenc.Checked)
			{
				this.cconfusion.Checked = false;
			}
		}

		// Token: 0x0600018F RID: 399 RVA: 0x00010F48 File Offset: 0x0000F148
		private void cconfusion_CheckedChanged(object sender, EventArgs e)
		{
			if (this.cconfusion.Checked)
			{
				this.BaseSenc.Checked = false;
			}
		}

		// Token: 0x06000190 RID: 400 RVA: 0x00010F78 File Offset: 0x0000F178
		private void alllength_ValueChanged(object sender, EventArgs e)
		{
			xd.thelength = this.alllength.Value;
			this.siticoneLabel19.Text = this.alllength.Value.ToString();
		}

		// Token: 0x06000191 RID: 401 RVA: 0x00010FC4 File Offset: 0x0000F1C4
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

		// Token: 0x06000192 RID: 402 RVA: 0x000111D4 File Offset: 0x0000F3D4
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

		// Token: 0x06000193 RID: 403 RVA: 0x000113E4 File Offset: 0x0000F5E4
		private void discord_Click(object sender, EventArgs e)
		{
			Clipboard.SetText("xRose#0308");
			DialogResult dialogResult = MessageBox.Show("Discord : xRose#0308" + Environment.NewLine + "Press ok to Copy it .", "Discord", MessageBoxButtons.OK);
			if (dialogResult == DialogResult.OK)
			{
			}
		}

		// Token: 0x06000194 RID: 404 RVA: 0x00011430 File Offset: 0x0000F630
		private void facebook_Click(object sender, EventArgs e)
		{
			Process.Start("https://www.facebook.com/String.xRose");
		}

		// Token: 0x06000195 RID: 405 RVA: 0x00011448 File Offset: 0x0000F648
		private void donation_Click(object sender, EventArgs e)
		{
			Process.Start("https://www.paypal.com/paypalme/inx707");
		}

		// Token: 0x06000196 RID: 406 RVA: 0x00011448 File Offset: 0x0000F648
		private void siticoneLabel9_Click(object sender, EventArgs e)
		{
			Process.Start("https://www.paypal.com/paypalme/inx707");
		}

		// Token: 0x06000197 RID: 407 RVA: 0x00011460 File Offset: 0x0000F660
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

		// Token: 0x06000198 RID: 408 RVA: 0x00011514 File Offset: 0x0000F714
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

		// Token: 0x06000199 RID: 409 RVA: 0x000116B0 File Offset: 0x0000F8B0
		private void assemblytext_DragEnter(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.Copy;
			e.Effect = DragDropEffects.None;
		}

		// Token: 0x0600019A RID: 410 RVA: 0x000116DC File Offset: 0x0000F8DC
		private void obfuscate_Click_1(object sender, EventArgs e)
		{
			global::Context.PackerPhase();
			this.log.Items.Add("Executed : Proxy Obfuscation");
			ModuleDefMD moduleDefMD;
			if (this.signer.Checked)
			{
				StringEncoder.Execute(moduleDefMD);
				goto IL_28C;
			}
			goto IL_976;
			IL_3F:
			if (!this.ade4dot.Checked)
			{
			}
			if (this.mstrip.Checked)
			{
				goto IL_7DA;
			}
			goto IL_749;
			IL_67:
			Watermark.Execute(moduleDefMD);
			this.log.Items.Add("Executed : Anti De4dot");
			AntiDe4dot.Execute1(moduleDefMD.Assembly);
			hideMethods.Execute(moduleDefMD);
			goto IL_6B3;
			IL_108:
			ModuleWriterOptions moduleWriterOptions;
			bool flag;
			if (this.BaseSenc.Checked)
			{
				this.log.Items.Add("Packed Successfully");
				moduleWriterOptions.Logger = DummyLogger.NoThrowInstance;
				AntiDumpMethod1.Execute(moduleDefMD);
				Mutation.Execute(moduleDefMD);
				flag = true;
				this.log.Items.Add("Obfuscated Successfully");
				goto IL_253;
			}
			goto IL_66B;
			IL_17B:
			if (!this.adebug.Checked)
			{
				goto IL_4AB;
			}
			this.log.Items.Add("Executed : Crypto Strings Encryption");
			string text;
			AntiTamper.Sha256(text);
			this.log.Items.Add("Executed : Hide Namespaces");
			ProxyMeth.Execute(moduleDefMD);
			this.log.Items.Clear();
			this.log.Items.Add("Assembly Signed Successfully");
			global::Context.LoadModule(text);
			if (flag)
			{
				goto IL_8E8;
			}
			IL_210:
			if (this.apacker.Checked)
			{
				Arithmetic.Execute(moduleDefMD);
				this.log.Items.Add("Packed Successfully");
				StackUnfConfusion.Execute(moduleDefMD);
				goto IL_4D6;
			}
			goto IL_4C3;
			IL_253:
			string text2;
			ModuleWriterOptions moduleWriterOptions2;
			if (this.cconfusion.Checked)
			{
				moduleDefMD.Write(text2, moduleWriterOptions2);
				this.log.Items.Add("Executed : Proxy Int Obfuscation");
				NewRenamerObfuscation.DoRenaming(moduleDefMD);
				goto IL_7C5;
			}
			IL_266:
			if (this.sconfusion.Checked)
			{
				goto IL_64E;
			}
			IL_279:
			if (this.pobf.Checked)
			{
				this.log.Items.Add("Executed : Mutation");
				goto IL_6E4;
			}
			IL_28C:
			if (this.pmobf.Checked)
			{
				global::Context.SaveModule();
				goto IL_66B;
			}
			goto IL_366;
			IL_2A4:
			if (!this.mutation.Checked)
			{
				goto IL_92A;
			}
			this.log.Items.Add("Executed : Ascii Strings Encryption");
			File.WriteAllBytes(text, Packer2.Pack(text, text, RUtils.GenerateRandomString2(5), true, true));
			this.log.Items.Add("Packed Successfully");
			this.log.Items.Add("Executed : Anti Debug");
			this.log.Items.Add("Executed : Renamer 2");
			this.hmethods.Checked = false;
			moduleWriterOptions2.Logger = DummyLogger.NoThrowInstance;
			IL_366:
			if (!this.pint.Checked)
			{
				goto IL_2A4;
			}
			moduleDefMD.Write(text, moduleWriterOptions);
			IL_38A:
			if (!this.atamper.Checked)
			{
				goto IL_253;
			}
			ProxyInt.Execute(moduleDefMD);
			this.log.Items.Add("Executed : Arithmetic");
			IL_3BF:
			if (!this.aildasm.Checked)
			{
				goto IL_38A;
			}
			if (!this.assembly.EndsWith(".exe"))
			{
				goto IL_524;
			}
			global::Context.LoadModule(text2);
			if (this.packer.Checked)
			{
				goto IL_6A5;
			}
			fakeobfuscator.Execute(moduleDefMD);
			ModuleContext context;
			moduleDefMD = ModuleDefMD.Load(this.assembly, context);
			this.log.Items.Add("Executed : Random Outline Methods");
			this.log.Items.Add("Executed : Proxy Meth Obfuscation");
			RenamerObfuscation.Execute(moduleDefMD);
			text2 = this.assembly + "-ROSED.exe";
			this.log.Items.Add("Executed : Anti Tamper");
			this.log.Items.Add("Executed : Fake Obfuscator");
			global::Context.SaveModule();
			IL_4AB:
			if (this.adump.Checked)
			{
				moduleDefMD = null;
				AntiDe4dot.Execute(moduleDefMD);
				ControlFlow.Execute(moduleDefMD);
				AddJunk.Execute(moduleDefMD);
				AntiDebug2.Execute(moduleDefMD);
				goto IL_846;
			}
			goto IL_3BF;
			IL_4C3:
			StrongNameKey signatureKey;
			if (this.packer.Checked)
			{
				this.log.Items.Add("Assembly Signed Successfully");
				signatureKey = new StrongNameKey(this.SNKText.Text);
				goto IL_92A;
			}
			IL_4D6:
			context = null;
			if (!this.signer.Checked)
			{
				goto IL_53E;
			}
			InvalidMDPhase.Execute(moduleDefMD.Assembly);
			AntiDebug.Execute(moduleDefMD);
			this.log.Items.Add("Executed : Add Junks");
			Calli.Execute(moduleDefMD);
			IL_524:
			if (this.assembly.EndsWith(".dll"))
			{
				goto IL_4C3;
			}
			return;
			IL_53E:
			moduleWriterOptions.MetaDataOptions.Flags = MetaDataFlags.PreserveAll;
			MetaStrip.Execute(moduleDefMD);
			this.log.Items.Add("Executed : Hide Strings");
			goto IL_5BE;
			IL_592:
			AntiDumpMethod3.InjectEraseMethod(moduleDefMD);
			this.log.Items.Add("Executed : Renamer");
			moduleDefMD = null;
			goto IL_210;
			IL_5BE:
			if (!this.hstr.Checked)
			{
				goto IL_17B;
			}
			Enc.EncryptStrings(moduleDefMD);
			if (!this.apacker.Checked)
			{
				goto IL_592;
			}
			File.WriteAllBytes(text2, Packer2.Pack(text2, text2, RUtils.GenerateRandomString2(5), true, true));
			return;
			IL_619:
			if (this.apacker.Checked)
			{
				proxy.Execute(moduleDefMD);
				goto IL_644;
			}
			IL_629:
			if (this.packer.Checked)
			{
				RandomOutlinedMethods.Execute(moduleDefMD);
				this.log.Items.Add("Executed : Meta Strip");
				if (!flag)
				{
					goto IL_619;
				}
				goto IL_889;
			}
			IL_644:
			context = null;
			goto IL_53E;
			IL_64E:
			if (this.cryptosenc.Checked)
			{
				this.log.Items.Add("Executed : Base64 Strings Encryption");
				goto IL_629;
			}
			goto IL_5BE;
			IL_66B:
			if (!this.asciisenc.Checked)
			{
				goto IL_64E;
			}
			moduleWriterOptions.InitializeStrongNameSigning(moduleDefMD, signatureKey);
			this.log.Items.Add("Executed : Hide Methods");
			IL_6A5:
			AntiDumpMethod3.InjectEraseMethod(moduleDefMD);
			goto IL_67;
			IL_6B3:
			if (!this.invalidmd.Checked)
			{
				goto IL_67;
			}
			First.Execute(moduleDefMD);
			this.log.Items.Add("Executed : Control Flow");
			Hidenamespaces.Execute(moduleDefMD);
			StrongNameKey signatureKey2;
			moduleWriterOptions2.InitializeStrongNameSigning(moduleDefMD, signatureKey2);
			this.log.Items.Add("Executed : Calli Confusion");
			if (moduleDefMD.Is32BitRequired)
			{
				goto IL_108;
			}
			goto IL_592;
			IL_6E4:
			if (!this.fobf.Checked)
			{
				goto IL_6B3;
			}
			this.log.Items.Add("Executed : Anti Dump For Packer");
			AntiTamper.Sha256(text2);
			IL_749:
			if (this.hmethods.Checked)
			{
				AssemblyDef assemblyDef = moduleDefMD.Assembly;
				this.log.Items.Add("Obfuscated Successfully");
				context = ModuleDef.CreateModuleContext();
				goto IL_619;
			}
			goto IL_6E4;
			IL_7C5:
			if (this.ajunk.Checked)
			{
				text = this.assembly + "-ROSED.dll";
				this.log.Items.Add("Executed : Invalid Meta Data");
				goto IL_2A4;
			}
			goto IL_3F;
			IL_7DA:
			if (this.renamer2.Checked)
			{
				goto IL_17B;
			}
			goto IL_7C5;
			IL_846:
			if (this.renamer.Checked)
			{
				this.log.Items.Add("Executed : Anti Dump");
				moduleWriterOptions = new ModuleWriterOptions(moduleDefMD);
				goto IL_266;
			}
			goto IL_7DA;
			IL_889:
			if (this.hnamespaces.Checked)
			{
				this.log.Items.Add("Packed Successfully");
				this.invalidmd.Checked = false;
				goto IL_3F;
			}
			goto IL_846;
			IL_8E8:
			if (this.arith.Checked)
			{
				moduleWriterOptions2 = new ModuleWriterOptions(moduleDefMD);
				this.log.Items.Add("Executed : Stack Confusion");
				AntiTamper.Execute(moduleDefMD);
				this.log.Items.Add("Executed : Anti ILDasm");
				goto IL_279;
			}
			goto IL_889;
			IL_92A:
			if (this.cflow.Checked)
			{
				goto IL_976;
			}
			IL_961:
			if (this.omethods.Checked)
			{
				signatureKey2 = new StrongNameKey(this.SNKText.Text);
				AntiILDasm.Execute(moduleDefMD);
				goto IL_108;
			}
			goto IL_8E8;
			IL_976:
			moduleWriterOptions2.MetaDataOptions.Flags = MetaDataFlags.PreserveAll;
			hideStrings.Execute(moduleDefMD);
			flag = false;
			global::Context.PackerPhase();
			goto IL_961;
		}

		// Token: 0x0600019B RID: 411 RVA: 0x00002D58 File Offset: 0x00000F58
		private void cflow_CheckedChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x0600019C RID: 412 RVA: 0x000120B8 File Offset: 0x000102B8
		private void cflowTrackBar_Scroll(object sender, ScrollEventArgs e)
		{
			IL_FF:
			while (this.cflowTrackBar.Value == 5)
			{
				this.cflowStatus.Text = "Normal";
				xd.cflowint = 5;
				for (;;)
				{
					if (this.cflowTrackBar.Value != 3)
					{
						goto IL_28;
					}
					if (this.cflowTrackBar.Value == 1)
					{
						goto IL_28;
					}
					IL_B4:
					if (this.cflowTrackBar.Value == 2)
					{
						break;
					}
					continue;
					IL_28:
					if (this.cflowTrackBar.Value == 4)
					{
						xd.cflowint = 4;
						this.cflowStatus.Text = "Aggressive";
						xd.cflowint = 1;
						xd.cflowint = 3;
						xd.cflowint = 2;
						this.cflowStatus.Text = "Minimum";
						this.cflowStatus.Text = "None";
						this.cflowStatus.Text = "Maximum";
						goto IL_B4;
					}
					goto IL_FF;
				}
				break;
			}
		}

		// Token: 0x0600019D RID: 413 RVA: 0x000121E0 File Offset: 0x000103E0
		private void AsciiType_CheckedChanged(object sender, EventArgs e)
		{
			xd.renamertype = "Ascii";
		}

		// Token: 0x0600019E RID: 414 RVA: 0x000121F8 File Offset: 0x000103F8
		private void NumbersType_CheckedChanged(object sender, EventArgs e)
		{
			xd.renamertype = "Numbers";
		}

		// Token: 0x0600019F RID: 415 RVA: 0x00012210 File Offset: 0x00010410
		private void ChineseType_CheckedChanged(object sender, EventArgs e)
		{
			xd.renamertype = "Chinese";
		}

		// Token: 0x060001A0 RID: 416 RVA: 0x00012228 File Offset: 0x00010428
		private void SymbolsType_CheckedChanged(object sender, EventArgs e)
		{
			xd.renamertype = "Symbols";
		}

		// Token: 0x060001A1 RID: 417 RVA: 0x00012240 File Offset: 0x00010440
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

		// Token: 0x060001A2 RID: 418 RVA: 0x000122CC File Offset: 0x000104CC
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
							text.Substring(startIndex);
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

		// Token: 0x060001A3 RID: 419 RVA: 0x00012400 File Offset: 0x00010600
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
