using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using Rose.Helper;

namespace Rose.Protections
{
	// Token: 0x0200006A RID: 106
	internal static class StringEncoder
	{
		// Token: 0x0600014B RID: 331 RVA: 0x0000EEC8 File Offset: 0x0000D0C8
		public static void Execute(ModuleDefMD moduleDefMd)
		{
			TypeDef typeDef;
			MethodDef method = InjectHelper.Inject(typeDef, moduleDefMd.GlobalType, moduleDefMd).SingleOrDefault<IDnlibDef>() as MethodDef;
			ModuleDefMD moduleDefMD = ModuleDefMD.Load(typeof(Decoder).Module);
			IEnumerator<TypeDef> enumerator = (from x in moduleDefMd.GetTypes()
				where x.HasMethods
				select x).GetEnumerator();
			typeDef = moduleDefMD.ResolveTypeDef(MDToken.ToRID(typeof(Decoder).MetadataToken));
			CryptoRandom cryptoRandom = new CryptoRandom();
			try
			{
				do
				{
					TypeDef typeDef2 = enumerator.Current;
					IEnumerable<MethodDef> methods = typeDef2.Methods;
					Func<MethodDef, bool> predicate;
					if ((predicate = StringEncoder.<>c.<>9__0_1) == null)
					{
						predicate = (StringEncoder.<>c.<>9__0_1 = (MethodDef x) => x.HasBody);
					}
					foreach (MethodDef methodDef in methods.Where(predicate))
					{
						IList<Instruction> instructions = methodDef.Body.Instructions;
						int num;
						do
						{
							if (instructions[num].OpCode == OpCodes.Ldstr && !string.IsNullOrEmpty(instructions[num].Operand.ToString()))
							{
								int num2 = methodDef.Name.Length + cryptoRandom.Next();
								string operand = StringEncoder.EncryptString(new Tuple<string, int>(instructions[num].Operand.ToString(), num2));
								instructions[num].OpCode = OpCodes.Ldstr;
								instructions[num].Operand = operand;
								instructions.Insert(num + 1, OpCodes.Ldc_I4.ToInstruction(num2));
								instructions.Insert(num + 2, OpCodes.Call.ToInstruction(method));
								num += 2;
							}
							num++;
						}
						while (num < instructions.Count);
						methodDef.Body.SimplifyMacros(methodDef.Parameters);
					}
				}
				while (enumerator.MoveNext());
			}
			finally
			{
				if (enumerator != null)
				{
					enumerator.Dispose();
				}
			}
		}

		// Token: 0x0600014C RID: 332 RVA: 0x0000F1A0 File Offset: 0x0000D3A0
		private static string EncryptString(Tuple<string, int> values)
		{
			int num = 1;
			string item = values.Item1;
			StringBuilder stringBuilder;
			char c;
			stringBuilder.Append(c ^ '\0');
			do
			{
				c = item[num];
			}
			while (num < item.Length);
			stringBuilder = new StringBuilder();
			int item2 = values.Item2;
			return stringBuilder.ToString();
		}
	}
}
