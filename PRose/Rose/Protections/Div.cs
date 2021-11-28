using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Rose.Protections
{
	// Token: 0x0200001F RID: 31
	public class Div : iFunction
	{
		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000056 RID: 86 RVA: 0x00002202 File Offset: 0x00000402
		public override ArithmeticTypes ArithmeticTypes
		{
			get
			{
				return ArithmeticTypes.Div;
			}
		}

		// Token: 0x06000057 RID: 87 RVA: 0x000054E8 File Offset: 0x000036E8
		public override ArithmeticVT Arithmetic(Instruction instruction, ModuleDef module)
		{
			if (!ArithmeticUtils.CheckArithmetic(instruction))
			{
				return null;
			}
			ArithmeticEmulator arithmeticEmulator = new ArithmeticEmulator((double)instruction.GetLdcI4Value(), ArithmeticUtils.GetY((double)instruction.GetLdcI4Value()), this.ArithmeticTypes);
			return new ArithmeticVT(new Value(arithmeticEmulator.GetValue(), arithmeticEmulator.GetY()), new Token(OpCodes.Div), this.ArithmeticTypes);
		}
	}
}
