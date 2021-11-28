using System;
using dnlib.DotNet;

namespace Rose.Protections
{
	// Token: 0x0200005D RID: 93
	public static class NewRenamerObfuscation
	{
		// Token: 0x06000124 RID: 292 RVA: 0x0001157C File Offset: 0x0000F77C
		public static void DoRenaming(ModuleDefMD md)
		{
			md = NewRenamerObfuscation.RenamingObfuscation(md);
		}

		// Token: 0x06000125 RID: 293 RVA: 0x000115C0 File Offset: 0x0000F7C0
		private static ModuleDefMD RenamingObfuscation(ModuleDefMD inModule)
		{
			IRenaming renaming;
			ModuleDefMD moduleDefMD = renaming.Rename(moduleDefMD);
			renaming = new PropertiesRenaming();
			renaming = new NamespacesRenaming();
			renaming = new ClassesRenaming();
			moduleDefMD = inModule;
			moduleDefMD = renaming.Rename(moduleDefMD);
			renaming = new MethodsRenaming();
			renaming = new FieldsRenaming();
			moduleDefMD = renaming.Rename(moduleDefMD);
			moduleDefMD = renaming.Rename(moduleDefMD);
			moduleDefMD = renaming.Rename(moduleDefMD);
			return moduleDefMD;
		}
	}
}
