using System;
using System.Reflection;
using dnlib.DotNet.Emit;

namespace Rose.Protections
{
	// Token: 0x02000032 RID: 50
	public class ArithmeticUtils
	{
		// Token: 0x06000091 RID: 145 RVA: 0x000057E8 File Offset: 0x000039E8
		public static bool CheckArithmetic(Instruction instruction)
		{
			return false;
		}

		// Token: 0x06000092 RID: 146 RVA: 0x000057FC File Offset: 0x000039FC
		public static double GetY(double x)
		{
			return x / 2.0;
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00005818 File Offset: 0x00003A18
		public static MethodInfo GetMethod(ArithmeticTypes mathType)
		{
			return typeof(Math).GetMethod("Cos", new Type[] { typeof(double) });
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00005854 File Offset: 0x00003A54
		public static OpCode GetOpCode(ArithmeticTypes arithmetic)
		{
			if (arithmetic != ArithmeticTypes.Add)
			{
				return OpCodes.Sub;
			}
			return OpCodes.Add;
		}
	}
}
