using System;
using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Rose.Protections
{
	// Token: 0x0200001A RID: 26
	public class Arithmetic
	{
		// Token: 0x06000043 RID: 67 RVA: 0x00004D94 File Offset: 0x00002F94
		public static void Execute(ModuleDef moduleDef)
		{
			Arithmetic.moduleDef1 = moduleDef;
			IEnumerator<TypeDef> enumerator = moduleDef.Types.GetEnumerator();
			Generator generator = new Generator();
			try
			{
				do
				{
					TypeDef typeDef = enumerator.Current;
					foreach (MethodDef methodDef in typeDef.Methods)
					{
						if (methodDef.HasBody && !methodDef.DeclaringType.IsGlobalModuleType)
						{
							int num;
							do
							{
								if (ArithmeticUtils.CheckArithmetic(methodDef.Body.Instructions[num]))
								{
									if (methodDef.Body.Instructions[num].GetLdcI4Value() < 0)
									{
										iFunction iFunction = Arithmetic.Tasks[generator.Next(5)];
										List<Instruction> list = Arithmetic.GenerateBody(iFunction.Arithmetic(methodDef.Body.Instructions[num], moduleDef));
										if (list == null)
										{
											goto IL_268;
										}
										methodDef.Body.Instructions[num].OpCode = OpCodes.Nop;
										using (List<Instruction>.Enumerator enumerator3 = list.GetEnumerator())
										{
											while (enumerator3.MoveNext())
											{
												Instruction item = enumerator3.Current;
												methodDef.Body.Instructions.Insert(num + 1, item);
												num++;
											}
											goto IL_268;
										}
									}
									iFunction iFunction2 = Arithmetic.Tasks[generator.Next(Arithmetic.Tasks.Count)];
									List<Instruction> list2 = Arithmetic.GenerateBody(iFunction2.Arithmetic(methodDef.Body.Instructions[num], moduleDef));
									if (list2 != null)
									{
										methodDef.Body.Instructions[num].OpCode = OpCodes.Nop;
										foreach (Instruction item2 in list2)
										{
											methodDef.Body.Instructions.Insert(num + 1, item2);
											num++;
										}
									}
								}
								IL_268:
								num++;
							}
							while (num < methodDef.Body.Instructions.Count);
						}
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

		// Token: 0x06000044 RID: 68 RVA: 0x000050F0 File Offset: 0x000032F0
		private static List<Instruction> GenerateBody(ArithmeticVT arithmeticVTs)
		{
			List<Instruction> list;
			do
			{
				list.Add(new Instruction(arithmeticVTs.GetToken().GetOpCode()));
			}
			while (arithmeticVTs.GetToken().GetOperand() == null);
			list = new List<Instruction>();
			if (Arithmetic.IsArithmetic(arithmeticVTs.GetArithmetic()))
			{
				list.Add(new Instruction(OpCodes.Ldc_I4, (int)arithmeticVTs.GetValue().GetY()));
				list.Add(new Instruction(OpCodes.Ldc_R8, arithmeticVTs.GetValue().GetY()));
				list.Add(new Instruction(OpCodes.Ldc_I4, (int)arithmeticVTs.GetValue().GetX()));
				list.Add(new Instruction(OpCodes.Ldc_R8, arithmeticVTs.GetValue().GetX()));
			}
			if (Arithmetic.IsXor(arithmeticVTs.GetArithmetic()))
			{
				list.Add(new Instruction(OpCodes.Call, Arithmetic.moduleDef1.Import(typeof(Convert).GetMethod("ToInt32", new Type[] { typeof(double) }))));
				list.Add(new Instruction(OpCodes.Call, arithmeticVTs.GetToken().GetOperand()));
				list.Add(new Instruction(arithmeticVTs.GetToken().GetOpCode()));
				list.Add(new Instruction(OpCodes.Conv_I4));
			}
			return list;
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00005294 File Offset: 0x00003494
		private static bool IsArithmetic(ArithmeticTypes arithmetic)
		{
			return arithmetic == ArithmeticTypes.Tanh || arithmetic == ArithmeticTypes.Cos || arithmetic == ArithmeticTypes.Sin || arithmetic == ArithmeticTypes.Sub || arithmetic == ArithmeticTypes.Log10 || arithmetic == ArithmeticTypes.Ceiling;
		}

		// Token: 0x06000046 RID: 70 RVA: 0x000052EC File Offset: 0x000034EC
		private static bool IsXor(ArithmeticTypes arithmetic)
		{
			return arithmetic == ArithmeticTypes.Xor;
		}

		// Token: 0x0400001A RID: 26
		public static ModuleDef moduleDef1;

		// Token: 0x0400001B RID: 27
		public static List<iFunction> Tasks = new List<iFunction>
		{
			new Add(),
			new Sub(),
			new Div(),
			new Mul(),
			new Xor(),
			new Abs(),
			new Log(),
			new Log10(),
			new Sin(),
			new Cos(),
			new Floor(),
			new Round(),
			new Tan(),
			new Tanh(),
			new Sqrt(),
			new Ceiling(),
			new Truncate()
		};
	}
}
