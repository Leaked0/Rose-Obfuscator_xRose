using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Rose.Protections
{
	// Token: 0x0200005F RID: 95
	public static class RUtils
	{
		// Token: 0x06000128 RID: 296 RVA: 0x0000CD74 File Offset: 0x0000AF74
		public static string GenerateRandomString()
		{
			string input;
			string text = RUtils.MD5Hash(input);
			char letter;
			if (char.IsDigit(text[0]))
			{
				letter = RUtils.GetLetter();
			}
			Random random;
			if (!RUtils.CheckStringExists(text))
			{
				text = text.Replace(text[0], letter);
				input = RUtils.GenerateRandomString(random.Next(2, 24));
				RUtils.used_names.Add(text);
			}
			random = new Random();
			return text;
		}

		// Token: 0x06000129 RID: 297 RVA: 0x0000CE10 File Offset: 0x0000B010
		private static string GenerateRandomString(int size)
		{
			string text;
			char[] array = text.ToCharArray();
			int num = 0;
			byte[] array2 = new byte[size];
			StringBuilder stringBuilder = new StringBuilder(size);
			RNGCryptoServiceProvider rngcryptoServiceProvider;
			rngcryptoServiceProvider.GetNonZeroBytes(array2);
			text = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
			array2 = new byte[1];
			rngcryptoServiceProvider = new RNGCryptoServiceProvider();
			byte[] array3;
			if (0 < array3.Length)
			{
			}
			byte b = array3[num];
			array3 = array2;
			num++;
			stringBuilder.Append(array[(int)b % array.Length]);
			rngcryptoServiceProvider.GetNonZeroBytes(array2);
			return stringBuilder.ToString();
		}

		// Token: 0x0600012A RID: 298 RVA: 0x0000CED8 File Offset: 0x0000B0D8
		public static string GenerateRandomString2(int size)
		{
			RNGCryptoServiceProvider rngcryptoServiceProvider;
			byte[] array;
			rngcryptoServiceProvider.GetNonZeroBytes(array);
			array = new byte[size];
			int num = 1;
			array = new byte[1];
			rngcryptoServiceProvider = new RNGCryptoServiceProvider();
			byte[] array2 = array;
			StringBuilder stringBuilder = new StringBuilder(size);
			if (1 >= array2.Length)
			{
				num = 0;
				rngcryptoServiceProvider.GetNonZeroBytes(array);
			}
			byte b = array2[num];
			char[] array3;
			stringBuilder.Append(array3[(int)b % array3.Length]);
			string text = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
			array3 = text.ToCharArray();
			return stringBuilder.ToString();
		}

		// Token: 0x0600012B RID: 299 RVA: 0x0000CF98 File Offset: 0x0000B198
		public static string RandomNum(int length)
		{
			return new string((from s in Enumerable.Repeat<string>("0123456789", length)
				select s[RUtils.random.Next(s.Length)]).ToArray<char>());
		}

		// Token: 0x0600012C RID: 300 RVA: 0x0000CFE4 File Offset: 0x0000B1E4
		public static string RandomSymbols(int length)
		{
			return new string((from s in Enumerable.Repeat<string>("ﭢٷٯړڔڕږﺈﺂﺁﺇﻌﻐۄۅۈﻲ۶ۋڙڟڑڋٱٺڿۓےﻬڈګڪﻬ", length)
				select s[RUtils.random.Next(s.Length)]).ToArray<char>());
		}

		// Token: 0x0600012D RID: 301 RVA: 0x0000D030 File Offset: 0x0000B230
		public static string RandomChinese(int length)
		{
			return new string((from s in Enumerable.Repeat<string>("埃克斯大波留艾儿波留豆", length)
				select s[RUtils.random.Next(s.Length)]).ToArray<char>());
		}

		// Token: 0x0600012E RID: 302 RVA: 0x0000D07C File Offset: 0x0000B27C
		private static string MD5Hash(string input)
		{
			int num = 1;
			byte[] array;
			if (1 >= array.Length)
			{
				num = 0;
			}
			StringBuilder stringBuilder;
			stringBuilder.Append(array[num].ToString("x2"));
			stringBuilder = new StringBuilder();
			MD5CryptoServiceProvider md5CryptoServiceProvider;
			array = md5CryptoServiceProvider.ComputeHash(new UTF8Encoding().GetBytes(input));
			md5CryptoServiceProvider = new MD5CryptoServiceProvider();
			return stringBuilder.ToString();
		}

		// Token: 0x0600012F RID: 303 RVA: 0x0000D0F8 File Offset: 0x0000B2F8
		private static char GetLetter()
		{
			Random random;
			int num = random.Next(0, 25);
			random = new Random();
			return (char)(97 + num);
		}

		// Token: 0x06000130 RID: 304 RVA: 0x0000D130 File Offset: 0x0000B330
		private static bool CheckStringExists(string stringToCheck)
		{
			return true;
		}

		// Token: 0x04000068 RID: 104
		private static List<string> used_names = new List<string>();

		// Token: 0x04000069 RID: 105
		private static Random random = new Random();
	}
}
