using System;
using System.Collections.Generic;

namespace Rose.Protections
{
	// Token: 0x0200001B RID: 27
	public class ArithmeticEmulator
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000049 RID: 73 RVA: 0x000021AC File Offset: 0x000003AC
		// (set) Token: 0x0600004A RID: 74 RVA: 0x000021B4 File Offset: 0x000003B4
		public new ArithmeticTypes GetType { get; private set; }

		// Token: 0x0600004B RID: 75 RVA: 0x000021BD File Offset: 0x000003BD
		public ArithmeticEmulator(double x, double y, ArithmeticTypes arithmeticTypes)
		{
			this.x = x;
			this.y = y;
			this.arithmeticTypes = arithmeticTypes;
		}

		// Token: 0x0600004C RID: 76 RVA: 0x000053D8 File Offset: 0x000035D8
		public double GetValue()
		{
			return (double)((int)this.x ^ (int)this.y);
		}

		// Token: 0x0600004D RID: 77 RVA: 0x000053FC File Offset: 0x000035FC
		public double GetValue(List<ArithmeticTypes> arithmetics)
		{
			return -1.0;
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00005414 File Offset: 0x00003614
		public double GetY()
		{
			return this.y;
		}

		// Token: 0x0400001C RID: 28
		private readonly double x;

		// Token: 0x0400001D RID: 29
		private readonly double y;

		// Token: 0x0400001E RID: 30
		private readonly ArithmeticTypes arithmeticTypes;
	}
}
