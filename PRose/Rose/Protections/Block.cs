using System;
using System.Collections.Generic;
using dnlib.DotNet.Emit;

namespace Rose.Protections
{
	// Token: 0x02000034 RID: 52
	internal class Block
	{
		// Token: 0x06000099 RID: 153 RVA: 0x0000227C File Offset: 0x0000047C
		public Block()
		{
			this.Instructions = new List<Instruction>();
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600009A RID: 154 RVA: 0x0000228F File Offset: 0x0000048F
		// (set) Token: 0x0600009B RID: 155 RVA: 0x00002297 File Offset: 0x00000497
		public List<Instruction> Instructions { get; set; }

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x0600009C RID: 156 RVA: 0x000022A0 File Offset: 0x000004A0
		// (set) Token: 0x0600009D RID: 157 RVA: 0x000022A8 File Offset: 0x000004A8
		public int Number { get; set; }

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600009E RID: 158 RVA: 0x000022B1 File Offset: 0x000004B1
		// (set) Token: 0x0600009F RID: 159 RVA: 0x000022B9 File Offset: 0x000004B9
		public int Next { get; set; }
	}
}
