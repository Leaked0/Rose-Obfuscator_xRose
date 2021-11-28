using System;
using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Rose.Protections
{
	// Token: 0x02000035 RID: 53
	internal class Blocks
	{
		// Token: 0x060000A0 RID: 160 RVA: 0x00008918 File Offset: 0x00006B18
		public static List<Block> Block(MethodDef method)
		{
			Block block = new Block();
			List<Block> list = new List<Block>();
			IEnumerator<Instruction> enumerator = method.Body.Instructions.GetEnumerator();
			int num;
			block.Number = num;
			int num2 = 0;
			Stack<ExceptionHandler> stack = new Stack<ExceptionHandler>();
			List<Instruction> list2 = new List<Instruction>(method.Body.Instructions);
			block = new Block();
			block.Instructions.Add(Instruction.Create(OpCodes.Nop));
			list.Add(block);
			num = 0;
			try
			{
				do
				{
					Instruction instruction = enumerator.Current;
					foreach (ExceptionHandler exceptionHandler in method.Body.ExceptionHandlers)
					{
						if (exceptionHandler.HandlerStart == instruction || exceptionHandler.TryStart == instruction || exceptionHandler.FilterStart == instruction)
						{
							stack.Push(exceptionHandler);
						}
					}
					foreach (ExceptionHandler exceptionHandler2 in method.Body.ExceptionHandlers)
					{
						if (exceptionHandler2.HandlerEnd == instruction || exceptionHandler2.TryEnd == instruction)
						{
							stack.Pop();
						}
					}
					int num3;
					int num4;
					instruction.CalculateStackUsage(out num3, out num4);
					block.Instructions.Add(instruction);
					num2 += num3 - num4;
					if (num3 == 0 && instruction.OpCode != OpCodes.Nop && (num2 == 0 || instruction.OpCode == OpCodes.Ret) && stack.Count == 0)
					{
						num = (block.Number = num + 1);
						list.Add(block);
						block = new Block();
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
			return list;
		}
	}
}
