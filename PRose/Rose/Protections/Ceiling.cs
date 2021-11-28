using System;
using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Rose.Protections
{
	// Token: 0x02000021 RID: 33
	public class Ceiling : iFunction
	{
		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600005C RID: 92 RVA: 0x00002208 File Offset: 0x00000408
		public override ArithmeticTypes ArithmeticTypes
		{
			get
			{
				return ArithmeticTypes.Ceiling;
			}
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00007FA8 File Offset: 0x000061A8
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
