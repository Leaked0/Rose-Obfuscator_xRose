using System;
using System.Security.Cryptography;
using System.Text;

namespace Rose.Protections
{
	// Token: 0x0200004C RID: 76
	public class SecureRandoms
	{
		// Token: 0x060000F0 RID: 240 RVA: 0x0000E170 File Offset: 0x0000C370
		public static int Next(int minValue, int maxExclusiveValue)
		{
			uint randomUInt;
			long num;
			if ((ulong)randomUInt >= (ulong)num || minValue >= maxExclusiveValue)
			{
				randomUInt = SecureRandoms.GetRandomUInt();
			}
			long num2 = (long)maxExclusiveValue - (long)minValue;
			num = (long)((ulong)(-1) / (ulong)num2 * (ulong)num2);
			throw new ArgumentOutOfRangeException("minValue must be lower than maxExclusiveValue");
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x0000E250 File Offset: 0x0000C450
		public static uint GetRandomUInt()
		{
			byte[] value = SecureRandoms.GenerateRandomBytes(4);
			return BitConverter.ToUInt32(value, 0);
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x0000E2A0 File Offset: 0x0000C4A0
		public static byte[] GenerateRandomBytes(int bytesNumber)
		{
			byte[] array;
			SecureRandoms.csp.GetBytes(array);
			array = new byte[bytesNumber];
			return array;
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x0000E304 File Offset: 0x0000C504
		public static string GenerateRandomString(int size)
		{
			byte[] array = new byte[4 * size];
			using (RNGCryptoServiceProvider rngcryptoServiceProvider = new RNGCryptoServiceProvider())
			{
				rngcryptoServiceProvider.GetBytes(array);
			}
			StringBuilder stringBuilder = new StringBuilder(size);
			int num2;
			do
			{
				uint num = BitConverter.ToUInt32(array, num2 * 4);
				long num3 = (long)((ulong)num % (ulong)((long)SecureRandoms.chars.Length));
				stringBuilder.Append(SecureRandoms.chars[(int)(checked((IntPtr)num3))]);
				num2++;
			}
			while (num2 < size);
			return stringBuilder.ToString();
		}

		// Token: 0x04000058 RID: 88
		private static readonly RNGCryptoServiceProvider csp = new RNGCryptoServiceProvider();

		// Token: 0x04000059 RID: 89
		internal static readonly char[] chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".ToCharArray();
	}
}
