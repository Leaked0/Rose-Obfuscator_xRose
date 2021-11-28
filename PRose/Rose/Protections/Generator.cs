using System;

namespace Rose.Protections
{
	// Token: 0x0200002F RID: 47
	public class Generator
	{
		// Token: 0x06000086 RID: 134 RVA: 0x00005720 File Offset: 0x00003920
		public Generator()
		{
			this.random = new Random(Guid.NewGuid().GetHashCode());
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00005754 File Offset: 0x00003954
		public int Next()
		{
			return this.random.Next(int.MaxValue);
		}

		// Token: 0x06000088 RID: 136 RVA: 0x00005774 File Offset: 0x00003974
		public int Next(int value)
		{
			return this.random.Next(value);
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00005794 File Offset: 0x00003994
		public int Next(int min, int max)
		{
			return this.random.Next(min, max);
		}

		// Token: 0x04000035 RID: 53
		private readonly Random random;
	}
}
