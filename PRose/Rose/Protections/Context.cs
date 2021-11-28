using System;
using dnlib.DotNet;

namespace Rose.Protections
{
	// Token: 0x02000006 RID: 6
	public class Context
	{
		// Token: 0x06000014 RID: 20 RVA: 0x0000399C File Offset: 0x00001B9C
		public Context(ModuleDef moduleDef)
		{
			this.ManifestModule = moduleDef.Assembly.ManifestModule;
			this.GlobalType = this.ManifestModule.GlobalType;
			this.Imp = new Importer(this.ManifestModule);
			this.ctor = this.GlobalType.FindOrCreateStaticConstructor();
		}

		// Token: 0x04000008 RID: 8
		public ModuleDef ManifestModule;

		// Token: 0x04000009 RID: 9
		public TypeDef GlobalType;

		// Token: 0x0400000A RID: 10
		public Importer Imp;

		// Token: 0x0400000B RID: 11
		public MethodDef ctor;
	}
}
