using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Rose.Protections
{
	// Token: 0x02000029 RID: 41
	public class Tan : iFunction
	{
		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000074 RID: 116 RVA: 0x00002225 File Offset: 0x00000425
		public override ArithmeticTypes ArithmeticTypes
		{
			get
			{
				return ArithmeticTypes.Tan;
			}
		}

		// Token: 0x06000075 RID: 117 RVA: 0x0000555C File Offset: 0x0000375C
		public override ArithmeticVT Arithmetic(Instruction instruction, ModuleDef module)
		{
			return null;
		}
	}
}
