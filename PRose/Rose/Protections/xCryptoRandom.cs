using System;
using System.Security.Cryptography;

namespace Rose.Protections
{
	// Token: 0x0200006C RID: 108
	public sealed class xCryptoRandom : Random, IDisposable
	{
		// Token: 0x06000151 RID: 337 RVA: 0x000024C3 File Offset: 0x000006C3
		public xCryptoRandom()
		{
		}

		// Token: 0x06000152 RID: 338 RVA: 0x000024C3 File Offset: 0x000006C3
		public xCryptoRandom(int seedIgnored)
		{
		}

		// Token: 0x06000153 RID: 339 RVA: 0x00014A64 File Offset: 0x00012C64
		public override int Next()
		{
			this.cryptoProvider.GetBytes(this.uint32Buffer);
			return BitConverter.ToInt32(this.uint32Buffer, 0) & int.MaxValue;
		}

		// Token: 0x06000154 RID: 340 RVA: 0x00014AC8 File Offset: 0x00012CC8
		public override int Next(int maxValue)
		{
			if (maxValue < 0)
			{
				throw new ArgumentOutOfRangeException("maxValue");
			}
			return this.Next(0, maxValue);
		}

		// Token: 0x06000155 RID: 341 RVA: 0x00014B38 File Offset: 0x00012D38
		public override int Next(int minValue, int maxValue)
		{
			if (minValue > maxValue)
			{
				throw new ArgumentOutOfRangeException("minValue");
			}
			if (minValue == maxValue)
			{
				return minValue;
			}
			long num = (long)(maxValue - minValue);
			long num2 = 4294967296L;
			long num3 = num2 % num;
			uint num4;
			do
			{
				this.cryptoProvider.GetBytes(this.uint32Buffer);
				num4 = BitConverter.ToUInt32(this.uint32Buffer, 0);
			}
			while ((ulong)num4 >= (ulong)(num2 - num3));
			return (int)((long)minValue + (long)((ulong)num4 % (ulong)num));
		}

		// Token: 0x06000156 RID: 342 RVA: 0x00014C3C File Offset: 0x00012E3C
		public override double NextDouble()
		{
			this.cryptoProvider.GetBytes(this.uint32Buffer);
			uint num = BitConverter.ToUInt32(this.uint32Buffer, 0);
			return num / 4294967296.0;
		}

		// Token: 0x06000157 RID: 343 RVA: 0x00014CBC File Offset: 0x00012EBC
		public override void NextBytes(byte[] buffer)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			this.cryptoProvider.GetBytes(buffer);
		}

		// Token: 0x06000158 RID: 344 RVA: 0x00014D34 File Offset: 0x00012F34
		public void Dispose()
		{
			this.InternalDispose();
		}

		// Token: 0x06000159 RID: 345 RVA: 0x00014D74 File Offset: 0x00012F74
		~xCryptoRandom()
		{
			this.InternalDispose();
		}

		// Token: 0x0600015A RID: 346 RVA: 0x00014DC4 File Offset: 0x00012FC4
		private void InternalDispose()
		{
			this.cryptoProvider = null;
			if (this.cryptoProvider != null)
			{
				this.cryptoProvider.Dispose();
			}
		}

		// Token: 0x04000076 RID: 118
		private RNGCryptoServiceProvider cryptoProvider = new RNGCryptoServiceProvider();

		// Token: 0x04000077 RID: 119
		private byte[] uint32Buffer = new byte[4];
	}
}
