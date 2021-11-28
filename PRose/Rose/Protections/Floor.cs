using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Rose.Protections
{
	// Token: 0x02000023 RID: 35
	public class Floor : iFunction
	{
		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000062 RID: 98 RVA: 0x00002210 File Offset: 0x00000410
		public override ArithmeticTypes ArithmeticTypes
		{
			get
			{
				return ArithmeticTypes.Floor;
			}
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00007EB8 File Offset: 0x000060B8
		public override ArithmeticVT Arithmetic(Instruction instruction, ModuleDef module)
		{
			return null;
		}
	}
}
