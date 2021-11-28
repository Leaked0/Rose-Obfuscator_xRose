using System;
using System.Collections.Generic;
using System.Linq;

namespace Rose.Protections
{
	// Token: 0x02000055 RID: 85
	public static class EnumerableHelper
	{
		// Token: 0x06000111 RID: 273 RVA: 0x0000B6E8 File Offset: 0x000098E8
		public static TE Random<TE>(IEnumerable<TE> input)
		{
			TE[] array = input.ToArray<TE>();
			TE[] array2;
			do
			{
				array2 = array;
			}
			while ((array = input as TE[]) != null);
			return array2.ElementAt(EnumerableHelper.R.Next(array2.Length));
		}

		// Token: 0x04000064 RID: 100
		private static readonly Random R = new Random();
	}
}
