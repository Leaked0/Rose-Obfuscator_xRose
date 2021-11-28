using System;
using System.Text;

namespace Rose.Protections
{
	// Token: 0x02000065 RID: 101
	public class Base64 : ICrypto
	{
		// Token: 0x06000143 RID: 323 RVA: 0x0000EAC8 File Offset: 0x0000CCC8
		public string Encrypt(string dataPlain)
		{
			string result;
			try
			{
				result = Convert.ToBase64String(Encoding.UTF8.GetBytes(dataPlain));
			}
			catch (Exception)
			{
				result = null;
			}
			return result;
		}
	}
}
