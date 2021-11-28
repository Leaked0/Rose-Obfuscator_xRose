using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Rose.Protections
{
	// Token: 0x02000020 RID: 32
	public class Abs : iFunction
	{
		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000059 RID: 89 RVA: 0x00002205 File Offset: 0x00000405
		public override ArithmeticTypes ArithmeticTypes
		{
			get
			{
				return ArithmeticTypes.Abs;
			}
		}

		// Token: 0x0600005A RID: 90 RVA: 0x0000555C File Offset: 0x0000375C
		public override ArithmeticVT Arithmetic(Instruction instruction, ModuleDef module)
		{
			return null;
		}
	}
}
