using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace PRose.Properties
{
	// Token: 0x02000079 RID: 121
	[CompilerGenerated]
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	[DebuggerNonUserCode]
	internal class Resources
	{
		// Token: 0x060001AD RID: 429 RVA: 0x00002094 File Offset: 0x00000294
		internal Resources()
		{
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x060001AE RID: 430 RVA: 0x0001C51C File Offset: 0x0001A71C
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (Resources.resourceMan == null)
				{
					ResourceManager resourceManager = new ResourceManager("PRose.Properties.Resources", typeof(Resources).Assembly);
					Resources.resourceMan = resourceManager;
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x060001AF RID: 431 RVA: 0x0000268E File Offset: 0x0000088E
		// (set) Token: 0x060001B0 RID: 432 RVA: 0x00002695 File Offset: 0x00000895
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x060001B1 RID: 433 RVA: 0x0000269D File Offset: 0x0000089D
		internal static string asd
		{
			get
			{
				return Resources.ResourceManager.GetString("asd", Resources.resourceCulture);
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x060001B2 RID: 434 RVA: 0x000026B3 File Offset: 0x000008B3
		internal static string XROSE
		{
			get
			{
				return Resources.ResourceManager.GetString("XROSE", Resources.resourceCulture);
			}
		}

		// Token: 0x040000F8 RID: 248
		private static ResourceManager resourceMan;

		// Token: 0x040000F9 RID: 249
		private static CultureInfo resourceCulture;
	}
}
