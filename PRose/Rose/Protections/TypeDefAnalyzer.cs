using System;
using dnlib.DotNet;

namespace Rose.Protections
{
	// Token: 0x02000047 RID: 71
	public class TypeDefAnalyzer : iAnalyze
	{
		// Token: 0x060000DA RID: 218 RVA: 0x00009494 File Offset: 0x00007694
		public override bool Execute(object context)
		{
			TypeDef typeDef;
			return !typeDef.IsRuntimeSpecialName && !typeDef.IsGlobalModuleType;
		}
	}
}
