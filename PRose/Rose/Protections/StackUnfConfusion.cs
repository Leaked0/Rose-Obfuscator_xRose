using System;
using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Rose.Protections
{
	// Token: 0x02000063 RID: 99
	internal class StackUnfConfusion
	{
		// Token: 0x0600013A RID: 314 RVA: 0x0000DE7C File Offset: 0x0000C07C
		public static void Execute(ModuleDef mod)
		{
			using (IEnumerator<TypeDef> enumerator = mod.Types.GetEnumerator())
			{
				do
				{
					TypeDef typeDef = enumerator.Current;
					foreach (MethodDef methodDef in typeDef.Methods)
					{
						MethodDef methodDef2 = methodDef;
						if (methodDef2 != null && !methodDef2.HasBody)
						{
							break;
						}
						CilBody body = methodDef2.Body;
						Instruction instruction = body.Instructions[0];
						Instruction instruction2 = Instruction.Create(OpCodes.Br_S, instruction);
						Instruction item = Instruction.Create(OpCodes.Pop);
						Random random = new Random();
						Instruction item2;
						switch (random.Next(0, 5))
						{
						case 0:
							item2 = Instruction.Create(OpCodes.Ldnull);
							break;
						case 1:
							item2 = Instruction.Create(OpCodes.Ldc_I4_0);
							break;
						case 2:
							item2 = Instruction.Create(OpCodes.Ldstr, RUtils.GenerateRandomString());
							break;
						case 3:
							item2 = Instruction.Create(OpCodes.Ldc_I8, (long)((ulong)random.Next()));
							break;
						default:
							item2 = Instruction.Create(OpCodes.Ldc_I8, (long)random.Next());
							break;
						}
						body.Instructions.Insert(0, item2);
						body.Instructions.Insert(1, item);
						body.Instructions.Insert(2, instruction2);
						foreach (ExceptionHandler exceptionHandler in body.ExceptionHandlers)
						{
							if (exceptionHandler.TryStart == instruction)
							{
								exceptionHandler.TryStart = instruction2;
							}
							else if (exceptionHandler.HandlerStart == instruction)
							{
								exceptionHandler.HandlerStart = instruction2;
							}
							else if (exceptionHandler.FilterStart == instruction)
							{
								exceptionHandler.FilterStart = instruction2;
							}
						}
					}
				}
				while (enumerator.MoveNext());
			}
		}
	}
}
