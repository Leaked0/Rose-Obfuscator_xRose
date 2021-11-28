using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Rose.Protections
{
	// Token: 0x02000028 RID: 40
	public class Sqrt : iFunction
	{
		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000071 RID: 113 RVA: 0x00002221 File Offset: 0x00000421
		public override ArithmeticTypes ArithmeticTypes
		{
			get
			{
				return ArithmeticTypes.Sqrt;
			}
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00007EB8 File Offset: 0x000060B8
		public override ArithmeticVT Arithmetic(Instruction instruction, ModuleDef module)
		{
			return null;
		}
	}
}
