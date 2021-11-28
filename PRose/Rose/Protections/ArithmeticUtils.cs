using System;
using System.Reflection;
using dnlib.DotNet.Emit;

namespace Rose.Protections
{
	// Token: 0x02000032 RID: 50
	public class ArithmeticUtils
	{
		// Token: 0x06000091 RID: 145 RVA: 0x000083F4 File Offset: 0x000065F4
		public static bool CheckArithmetic(Instruction instruction)
		{
			return false;
		}

		// Token: 0x06000092 RID: 146 RVA: 0x00008484 File Offset: 0x00006684
		public static double GetY(double x)
		{
			return x / 2.0;
		}

		// Token: 0x06000093 RID: 147 RVA: 0x000084B8 File Offset: 0x000066B8
		public static MethodInfo GetMethod(ArithmeticTypes mathType)
		{
			return typeof(Math).GetMethod("Cos", new Type[] { typeof(double) });
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00008824 File Offset: 0x00006A24
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
