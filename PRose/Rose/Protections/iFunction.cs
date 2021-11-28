using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Rose.Protections
{
	// Token: 0x02000030 RID: 48
	public abstract class iFunction
	{
		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600008A RID: 138
		public abstract ArithmeticTypes ArithmeticTypes { get; }

		// Token: 0x0600008B RID: 139
		public abstract ArithmeticVT Arithmetic(Instruction instruction, ModuleDef module);
	}
}
