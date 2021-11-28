using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Rose.Protections
{
	// Token: 0x0200002C RID: 44
	public class Mul : iFunction
	{
		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600007D RID: 125 RVA: 0x00002231 File Offset: 0x00000431
		public override ArithmeticTypes ArithmeticTypes
		{
			get
			{
				return ArithmeticTypes.Mul;
			}
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00008098 File Offset: 0x00006298
		public override ArithmeticVT Arithmetic(Instruction instruction, ModuleDef module)
		{
			if (!ArithmeticUtils.CheckArithmetic(instruction))
			{
				return null;
			}
			ArithmeticEmulator arithmeticEmulator = new ArithmeticEmulator((double)instruction.GetLdcI4Value(), ArithmeticUtils.GetY((double)instruction.GetLdcI4Value()), this.ArithmeticTypes);
			return new ArithmeticVT(new Value(arithmeticEmulator.GetValue(), arithmeticEmulator.GetY()), new Token(OpCodes.Mul), this.ArithmeticTypes);
		}
	}
}
