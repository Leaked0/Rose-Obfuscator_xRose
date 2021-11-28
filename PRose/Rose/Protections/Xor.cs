using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Rose.Protections
{
	// Token: 0x0200002E RID: 46
	public class Xor : iFunction
	{
		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000083 RID: 131 RVA: 0x00002237 File Offset: 0x00000437
		public override ArithmeticTypes ArithmeticTypes
		{
			get
			{
				return ArithmeticTypes.Xor;
			}
		}

		// Token: 0x06000084 RID: 132 RVA: 0x000056A8 File Offset: 0x000038A8
		public override ArithmeticVT Arithmetic(Instruction instruction, ModuleDef module)
		{
			Generator generator = new Generator();
			if (!ArithmeticUtils.CheckArithmetic(instruction))
			{
				return null;
			}
			ArithmeticEmulator arithmeticEmulator = new ArithmeticEmulator((double)instruction.GetLdcI4Value(), (double)generator.Next(), this.ArithmeticTypes);
			return new ArithmeticVT(new Value(arithmeticEmulator.GetValue(), arithmeticEmulator.GetY()), new Token(OpCodes.Xor), this.ArithmeticTypes);
		}
	}
}
