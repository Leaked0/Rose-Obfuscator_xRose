using System;
using System.Security.Cryptography;
using System.Text;

namespace Rose.Protections
{
	// Token: 0x0200004C RID: 76
	public class SecureRandoms
	{
		// Token: 0x060000F0 RID: 240 RVA: 0x00009EC8 File Offset: 0x000080C8
		public static int Next(int minValue, int maxExclusiveValue)
		{
			SecureRandoms.GetRandomUInt();
			throw new ArgumentOutOfRangeException("minValue must be lower than maxExclusiveValue");
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x00009EE8 File Offset: 0x000080E8
		public static uint GetRandomUInt()
		{
			byte[] value = SecureRandoms.GenerateRandomBytes(4);
			return BitConverter.ToUInt32(value, 0);
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x00009F14 File Offset: 0x00008114
		public static byte[] GenerateRandomBytes(int bytesNumber)
		{
			byte[] array;
			SecureRandoms.csp.GetBytes(array);
			array = new byte[bytesNumber];
			return array;
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x00009F40 File Offset: 0x00008140
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
