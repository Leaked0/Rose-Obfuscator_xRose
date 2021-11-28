using System;
using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Rose.Protections
{
	// Token: 0x02000027 RID: 39
	public class Sin : iFunction
	{
		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600006E RID: 110 RVA: 0x0000221E File Offset: 0x0000041E
		public override ArithmeticTypes ArithmeticTypes
		{
			get
			{
				return ArithmeticTypes.Sin;
			}
		}

		// Token: 0x0600006F RID: 111 RVA: 0x00007FA8 File Offset: 0x000061A8
		public override ArithmeticVT Arithmetic(Instruction instruction, ModuleDef module)
		{
			if (!ArithmeticUtils.CheckArithmetic(instruction))
			{
				return null;
			}
			List<ArithmeticTypes> arithmetics = new List<ArithmeticTypes>
			{
				ArithmeticTypes.Add,
				ArithmeticTypes.Sub
			};
			ArithmeticEmulator arithmeticEmulator = new ArithmeticEmulator((double)instruction.GetLdcI4Value(), ArithmeticUtils.GetY((double)instruction.GetLdcI4Value()), this.ArithmeticTypes);
			return new ArithmeticVT(new Value(arithmeticEmulator.GetValue(arithmetics), arithmeticEmulator.GetY()), new Token(ArithmeticUtils.GetOpCode(arithmeticEmulator.GetType), module.Import(ArithmeticUtils.GetMethod(this.ArithmeticTypes))), this.ArithmeticTypes);
		}
	}
}
