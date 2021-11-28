using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Rose.Protections
{
	// Token: 0x0200001E RID: 30
	public class Add : iFunction
	{
		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000053 RID: 83 RVA: 0x000021F7 File Offset: 0x000003F7
		public override ArithmeticTypes ArithmeticTypes
		{
			get
			{
				return ArithmeticTypes.Add;
			}
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00007D60 File Offset: 0x00005F60
		public override ArithmeticVT Arithmetic(Instruction instruction, ModuleDef module)
		{
			if (!ArithmeticUtils.CheckArithmetic(instruction))
			{
				return null;
			}
			ArithmeticEmulator arithmeticEmulator = new ArithmeticEmulator((double)instruction.GetLdcI4Value(), ArithmeticUtils.GetY((double)instruction.GetLdcI4Value()), this.ArithmeticTypes);
			return new ArithmeticVT(new Value(arithmeticEmulator.GetValue(), arithmeticEmulator.GetY()), new Token(OpCodes.Add), this.ArithmeticTypes);
		}
	}
}
