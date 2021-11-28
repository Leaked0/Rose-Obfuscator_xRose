using System;
using System.Collections.Generic;
using dnlib.DotNet;

namespace Rose.Protections
{
	// Token: 0x0200003E RID: 62
	public static class Hidenamespaces
	{
		// Token: 0x060000CA RID: 202 RVA: 0x000084E4 File Offset: 0x000066E4
		public static void Execute(ModuleDefMD md)
		{
			using (IEnumerator<TypeDef> enumerator = md.Types.GetEnumerator())
			{
				do
				{
					TypeDef typeDef = enumerator.Current;
					typeDef.Namespace = "";
				}
				while (enumerator.MoveNext());
			}
		}
	}
}
