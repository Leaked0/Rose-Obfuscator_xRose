using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace PRose.Properties
{
	// Token: 0x0200007A RID: 122
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
	[CompilerGenerated]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x1700001D RID: 29
		// (get) Token: 0x060001B3 RID: 435 RVA: 0x000026C9 File Offset: 0x000008C9
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x040000FA RID: 250
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
