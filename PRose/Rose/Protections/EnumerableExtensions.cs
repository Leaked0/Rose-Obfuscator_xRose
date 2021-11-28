using System;
using System.Collections.Generic;

namespace Rose.Protections
{
	// Token: 0x02000056 RID: 86
	public static class EnumerableExtensions
	{
		// Token: 0x06000112 RID: 274 RVA: 0x0000B728 File Offset: 0x00009928
		public static T Random<T>(this IEnumerable<T> input)
		{
			return EnumerableHelper.Random<T>(input);
		}
	}
}
