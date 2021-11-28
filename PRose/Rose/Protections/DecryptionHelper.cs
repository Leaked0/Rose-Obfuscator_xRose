using System;
using System.Text;

namespace Rose.Protections
{
	// Token: 0x02000066 RID: 102
	internal static class DecryptionHelper
	{
		// Token: 0x06000145 RID: 325 RVA: 0x00014170 File Offset: 0x00012370
		public static string qUSxo(string dataEnc)
		{
			string result;
			try
			{
				result = Encoding.UTF8.GetString(Convert.FromBase64String(dataEnc));
			}
			catch (Exception)
			{
				result = null;
			}
			return result;
		}
	}
}
