using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Rose.Protections
{
	// Token: 0x0200002A RID: 42
	public class Tanh : iFunction
	{
		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000077 RID: 119 RVA: 0x00002229 File Offset: 0x00000429
		public override ArithmeticTypes ArithmeticTypes
		{
			get
			{
				return ArithmeticTypes.Tanh;
			}
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00007EB8 File Offset: 0x000060B8
		public override ArithmeticVT Arithmetic(Instruction instruction, ModuleDef module)
		{
			return null;
		}
	}
}
