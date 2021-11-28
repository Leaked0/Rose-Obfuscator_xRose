using System;

namespace Rose.Protections
{
	// Token: 0x0200001D RID: 29
	public class ArithmeticVT
	{
		// Token: 0x0600004F RID: 79 RVA: 0x000021DA File Offset: 0x000003DA
		public ArithmeticVT(Value value, Token token, ArithmeticTypes arithmeticTypes)
		{
			this.value = value;
			this.token = token;
			this.arithmeticTypes = arithmeticTypes;
		}

		// Token: 0x06000050 RID: 80 RVA: 0x0000542C File Offset: 0x0000362C
		public Value GetValue()
		{
			return this.value;
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00005444 File Offset: 0x00003644
		public Token GetToken()
		{
			return this.token;
		}

		// Token: 0x06000052 RID: 82 RVA: 0x0000545C File Offset: 0x0000365C
		public ArithmeticTypes GetArithmetic()
		{
			return this.arithmeticTypes;
		}

		// Token: 0x04000032 RID: 50
		private readonly Value value;

		// Token: 0x04000033 RID: 51
		private readonly Token token;

		// Token: 0x04000034 RID: 52
		private readonly ArithmeticTypes arithmeticTypes;
	}
}
