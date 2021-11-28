using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Rose.Protections
{
	// Token: 0x0200002D RID: 45
	public class Sub : iFunction
	{
		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000080 RID: 128 RVA: 0x00002234 File Offset: 0x00000434
		public override ArithmeticTypes ArithmeticTypes
		{
			get
			{
				return ArithmeticTypes.Sub;
			}
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00008144 File Offset: 0x00006344
		public override ArithmeticVT Arithmetic(Instruction instruction, ModuleDef module)
		{
			return null;
		}
	}
}
