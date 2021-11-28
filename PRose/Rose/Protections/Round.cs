using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Rose.Protections
{
	// Token: 0x02000026 RID: 38
	public class Round : iFunction
	{
		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600006B RID: 107 RVA: 0x0000221A File Offset: 0x0000041A
		public override ArithmeticTypes ArithmeticTypes
		{
			get
			{
				return ArithmeticTypes.Round;
			}
		}

		// Token: 0x0600006C RID: 108 RVA: 0x0000555C File Offset: 0x0000375C
		public override ArithmeticVT Arithmetic(Instruction instruction, ModuleDef module)
		{
			return null;
		}
	}
}
