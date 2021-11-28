using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Rose.Protections
{
	// Token: 0x02000024 RID: 36
	public class Log : iFunction
	{
		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000065 RID: 101 RVA: 0x00002214 File Offset: 0x00000414
		public override ArithmeticTypes ArithmeticTypes
		{
			get
			{
				return ArithmeticTypes.Log;
			}
		}

		// Token: 0x06000066 RID: 102 RVA: 0x0000555C File Offset: 0x0000375C
		public override ArithmeticVT Arithmetic(Instruction instruction, ModuleDef module)
		{
			return null;
		}
	}
}
