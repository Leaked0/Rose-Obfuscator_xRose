using System;
using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Rose.Protections
{
	// Token: 0x02000036 RID: 54
	internal class ControlFlow
	{
		// Token: 0x060000A2 RID: 162 RVA: 0x00005B4C File Offset: 0x00003D4C
		public static void Execute(ModuleDefMD Module)
		{
			MethodDef methodDef;
			if (methodDef.HasBody)
			{
				goto IL_0E;
			}
			int num;
			TypeDef typeDef;
			do
			{
				IL_1C7:
				num++;
				ControlFlow.ExecuteMethod4(methodDef, Module);
				num = 0;
				if (typeDef == Module.GlobalType)
				{
					goto IL_0E;
				}
			}
			while (methodDef.Name.StartsWith("get_"));
			ControlFlow.ExecuteMethod(methodDef, Module);
			ControlFlow.ExecuteMethod3(methodDef, Module);
			int num2;
			if (num2 >= Module.Types.Count)
			{
				goto IL_174;
			}
			goto IL_14F;
			IL_0E:
			num2++;
			ControlFlow.ExecuteMethod(methodDef, Module);
			ControlFlow.ExecuteMethod6(methodDef, Module);
			do
			{
				methodDef = typeDef.Methods[num];
				if (methodDef.Name.StartsWith("set_"))
				{
					goto IL_1C7;
				}
				if (xd.cflowint == 1)
				{
					ControlFlow.ExecuteMethod4(methodDef, Module);
				}
				if (xd.cflowint != 2)
				{
					goto IL_114;
				}
				ControlFlow.ExecuteMethod2(methodDef, Module);
				if (methodDef.IsConstructor)
				{
					goto IL_1C7;
				}
				ControlFlow.ExecuteMethod3(methodDef, Module);
				ControlFlow.ExecuteMethod3(methodDef, Module);
				ControlFlow.ExecuteMethod2(methodDef, Module);
				methodDef.Body.SimplifyBranches();
			}
			while (num < typeDef.Methods.Count);
			ControlFlow.ExecuteMethod2(methodDef, Module);
			ControlFlow.ExecuteMethod(methodDef, Module);
			IL_114:
			if (xd.cflowint == 3)
			{
				ControlFlow.ExecuteMethod(methodDef, Module);
				num2 = 0;
				ControlFlow.ExecuteMethod(methodDef, Module);
			}
			if (xd.cflowint != 4)
			{
				goto IL_174;
			}
			IL_14F:
			typeDef = Module.Types[num2];
			ControlFlow.ExecuteMethod2(methodDef, Module);
			goto IL_1C7;
			IL_174:
			if (xd.cflowint == 5)
			{
				return;
			}
			goto IL_1C7;
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x00005D58 File Offset: 0x00003F58
		public static void ExecuteMethod4(MethodDef method, ModuleDefMD Module)
		{
			method.Body.SimplifyMacros(method.Parameters);
			Instruction instruction2;
			Instruction instruction = Instruction.Create(OpCodes.Br, instruction2);
			instruction2 = Instruction.Create(OpCodes.Nop);
			method.Body.Instructions.Clear();
			List<Block> blocks = Blocks.Block(method);
			Local local = new Local(Module.CorLibTypes.UInt32);
			blocks = ControlFlow.Randomize(blocks);
			method.Body.Variables.Add(local);
			using (List<Instruction>.Enumerator enumerator = ControlFlow.Calc(0).GetEnumerator())
			{
				do
				{
					Instruction item = enumerator.Current;
					method.Body.Instructions.Add(item);
				}
				while (enumerator.MoveNext());
			}
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Stloc, local));
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Br, instruction));
			method.Body.Instructions.Add(instruction2);
			IEnumerable<Block> blocks4 = blocks;
			Func<Block, bool> <>9__0;
			Func<Block, bool> predicate;
			if ((predicate = <>9__0) == null)
			{
				Func<Block, bool> <>9__1;
				predicate = (<>9__0 = delegate(Block block)
				{
					IEnumerable<Block> blocks3 = blocks;
					Func<Block, bool> predicate3;
					if ((predicate3 = <>9__1) == null)
					{
						predicate3 = (<>9__1 = (Block x) => x.Number == blocks.Count - 1);
					}
					return block != blocks3.Single(predicate3);
				});
			}
			foreach (Block block2 in blocks4.Where(predicate))
			{
				method.Body.Instructions.Add(Instruction.Create(OpCodes.Ldloc, local));
				foreach (Instruction item2 in ControlFlow.Calc(block2.Number))
				{
					method.Body.Instructions.Add(item2);
				}
				method.Body.Instructions.Add(Instruction.Create(OpCodes.Ceq));
				Instruction instruction3 = Instruction.Create(OpCodes.Nop);
				method.Body.Instructions.Add(Instruction.Create(OpCodes.Brfalse, instruction3));
				foreach (Instruction item3 in block2.Instructions)
				{
					method.Body.Instructions.Add(item3);
				}
				foreach (Instruction item4 in ControlFlow.Calc(block2.Number + 1))
				{
					method.Body.Instructions.Add(item4);
				}
				method.Body.Instructions.Add(Instruction.Create(OpCodes.Stloc, local));
				method.Body.Instructions.Add(instruction3);
			}
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Ldloc, local));
			foreach (Instruction item5 in ControlFlow.Calc(blocks.Count - 1))
			{
				method.Body.Instructions.Add(item5);
			}
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Ceq));
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Brfalse, instruction));
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Br, blocks.Single((Block x) => x.Number == blocks.Count - 1).Instructions[0]));
			method.Body.Instructions.Add(instruction);
			IEnumerable<Block> blocks2 = blocks;
			Func<Block, bool> <>9__3;
			Func<Block, bool> predicate2;
			if ((predicate2 = <>9__3) == null)
			{
				predicate2 = (<>9__3 = (Block x) => x.Number == blocks.Count - 1);
			}
			foreach (Instruction item6 in blocks2.Single(predicate2).Instructions)
			{
				method.Body.Instructions.Add(item6);
			}
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x0000634C File Offset: 0x0000454C
		public static void ExecuteMethod6(MethodDef method, ModuleDefMD Module)
		{
			List<Block> blocks = ControlFlow.Randomize(blocks);
			Instruction instruction = Instruction.Create(OpCodes.Nop);
			Local local;
			method.Body.Variables.Add(local);
			List<Instruction>.Enumerator enumerator = ControlFlow.Calc(0).GetEnumerator();
			Instruction instruction2 = Instruction.Create(OpCodes.Br, instruction);
			blocks = Blocks.Block(method);
			method.Body.SimplifyMacros(method.Parameters);
			local = new Local(Module.CorLibTypes.Int16);
			method.Body.Instructions.Clear();
			try
			{
				do
				{
					Instruction item = enumerator.Current;
					method.Body.Instructions.Add(item);
				}
				while (enumerator.MoveNext());
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Stloc, local));
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Br, instruction2));
			method.Body.Instructions.Add(instruction);
			IEnumerable<Block> blocks4 = blocks;
			Func<Block, bool> <>9__0;
			Func<Block, bool> predicate;
			if ((predicate = <>9__0) == null)
			{
				Func<Block, bool> <>9__1;
				predicate = (<>9__0 = delegate(Block block)
				{
					IEnumerable<Block> blocks3 = blocks;
					Func<Block, bool> predicate3;
					if ((predicate3 = <>9__1) == null)
					{
						predicate3 = (<>9__1 = (Block x) => x.Number == blocks.Count - 1);
					}
					return block != blocks3.Single(predicate3);
				});
			}
			foreach (Block block2 in blocks4.Where(predicate))
			{
				method.Body.Instructions.Add(Instruction.Create(OpCodes.Ldloc, local));
				foreach (Instruction item2 in ControlFlow.Calc(block2.Number))
				{
					method.Body.Instructions.Add(item2);
				}
				method.Body.Instructions.Add(Instruction.Create(OpCodes.Ceq));
				Instruction instruction3 = Instruction.Create(OpCodes.Nop);
				method.Body.Instructions.Add(Instruction.Create(OpCodes.Brfalse, instruction3));
				foreach (Instruction item3 in block2.Instructions)
				{
					method.Body.Instructions.Add(item3);
				}
				foreach (Instruction item4 in ControlFlow.Calc(block2.Number + 1))
				{
					method.Body.Instructions.Add(item4);
				}
				method.Body.Instructions.Add(Instruction.Create(OpCodes.Stloc, local));
				method.Body.Instructions.Add(instruction3);
			}
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Ldloc, local));
			foreach (Instruction item5 in ControlFlow.Calc(blocks.Count - 1))
			{
				method.Body.Instructions.Add(item5);
			}
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Ceq));
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Brfalse, instruction2));
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Br, blocks.Single((Block x) => x.Number == blocks.Count - 1).Instructions[0]));
			method.Body.Instructions.Add(instruction2);
			IEnumerable<Block> blocks2 = blocks;
			Func<Block, bool> <>9__3;
			Func<Block, bool> predicate2;
			if ((predicate2 = <>9__3) == null)
			{
				predicate2 = (<>9__3 = (Block x) => x.Number == blocks.Count - 1);
			}
			foreach (Instruction item6 in blocks2.Single(predicate2).Instructions)
			{
				method.Body.Instructions.Add(item6);
			}
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x00006940 File Offset: 0x00004B40
		public static void ExecuteMethod3(MethodDef method, ModuleDefMD Module)
		{
			List<Block> blocks = Blocks.Block(method);
			Instruction instruction2;
			Instruction instruction = Instruction.Create(OpCodes.Br, instruction2);
			blocks = ControlFlow.Randomize(blocks);
			method.Body.SimplifyMacros(method.Parameters);
			instruction2 = Instruction.Create(OpCodes.Nop);
			Local local;
			method.Body.Variables.Add(local);
			method.Body.Instructions.Clear();
			List<Instruction>.Enumerator enumerator = ControlFlow.Calc(0).GetEnumerator();
			local = new Local(Module.CorLibTypes.UInt16);
			try
			{
				do
				{
					Instruction item = enumerator.Current;
					method.Body.Instructions.Add(item);
				}
				while (enumerator.MoveNext());
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Stloc, local));
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Br, instruction));
			method.Body.Instructions.Add(instruction2);
			IEnumerable<Block> blocks4 = blocks;
			Func<Block, bool> <>9__0;
			Func<Block, bool> predicate;
			if ((predicate = <>9__0) == null)
			{
				Func<Block, bool> <>9__1;
				predicate = (<>9__0 = delegate(Block block)
				{
					IEnumerable<Block> blocks3 = blocks;
					Func<Block, bool> predicate3;
					if ((predicate3 = <>9__1) == null)
					{
						predicate3 = (<>9__1 = (Block x) => x.Number == blocks.Count - 1);
					}
					return block != blocks3.Single(predicate3);
				});
			}
			foreach (Block block2 in blocks4.Where(predicate))
			{
				method.Body.Instructions.Add(Instruction.Create(OpCodes.Ldloc, local));
				foreach (Instruction item2 in ControlFlow.Calc(block2.Number))
				{
					method.Body.Instructions.Add(item2);
				}
				method.Body.Instructions.Add(Instruction.Create(OpCodes.Ceq));
				Instruction instruction3 = Instruction.Create(OpCodes.Nop);
				method.Body.Instructions.Add(Instruction.Create(OpCodes.Brfalse, instruction3));
				foreach (Instruction item3 in block2.Instructions)
				{
					method.Body.Instructions.Add(item3);
				}
				foreach (Instruction item4 in ControlFlow.Calc(block2.Number + 1))
				{
					method.Body.Instructions.Add(item4);
				}
				method.Body.Instructions.Add(Instruction.Create(OpCodes.Stloc, local));
				method.Body.Instructions.Add(instruction3);
			}
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Ldloc, local));
			foreach (Instruction item5 in ControlFlow.Calc(blocks.Count - 1))
			{
				method.Body.Instructions.Add(item5);
			}
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Ceq));
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Brfalse, instruction));
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Br, blocks.Single((Block x) => x.Number == blocks.Count - 1).Instructions[0]));
			method.Body.Instructions.Add(instruction);
			IEnumerable<Block> blocks2 = blocks;
			Func<Block, bool> <>9__3;
			Func<Block, bool> predicate2;
			if ((predicate2 = <>9__3) == null)
			{
				predicate2 = (<>9__3 = (Block x) => x.Number == blocks.Count - 1);
			}
			foreach (Instruction item6 in blocks2.Single(predicate2).Instructions)
			{
				method.Body.Instructions.Add(item6);
			}
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x00006F34 File Offset: 0x00005134
		public static void ExecuteMethod2(MethodDef method, ModuleDefMD Module)
		{
			Instruction instruction = Instruction.Create(OpCodes.Nop);
			Instruction instruction2 = Instruction.Create(OpCodes.Br, instruction);
			Local local;
			method.Body.Variables.Add(local);
			local = new Local(Module.CorLibTypes.IntPtr);
			List<Block> blocks = ControlFlow.Randomize(blocks);
			blocks = Blocks.Block(method);
			method.Body.Instructions.Clear();
			List<Instruction>.Enumerator enumerator = ControlFlow.Calc(0).GetEnumerator();
			method.Body.SimplifyMacros(method.Parameters);
			try
			{
				do
				{
					Instruction item = enumerator.Current;
					method.Body.Instructions.Add(item);
				}
				while (enumerator.MoveNext());
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Stloc, local));
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Br, instruction2));
			method.Body.Instructions.Add(instruction);
			IEnumerable<Block> blocks4 = blocks;
			Func<Block, bool> <>9__0;
			Func<Block, bool> predicate;
			if ((predicate = <>9__0) == null)
			{
				Func<Block, bool> <>9__1;
				predicate = (<>9__0 = delegate(Block block)
				{
					IEnumerable<Block> blocks3 = blocks;
					Func<Block, bool> predicate3;
					if ((predicate3 = <>9__1) == null)
					{
						predicate3 = (<>9__1 = (Block x) => x.Number == blocks.Count - 1);
					}
					return block != blocks3.Single(predicate3);
				});
			}
			foreach (Block block2 in blocks4.Where(predicate))
			{
				method.Body.Instructions.Add(Instruction.Create(OpCodes.Ldloc, local));
				foreach (Instruction item2 in ControlFlow.Calc(block2.Number))
				{
					method.Body.Instructions.Add(item2);
				}
				method.Body.Instructions.Add(Instruction.Create(OpCodes.Ceq));
				Instruction instruction3 = Instruction.Create(OpCodes.Nop);
				method.Body.Instructions.Add(Instruction.Create(OpCodes.Brfalse, instruction3));
				foreach (Instruction item3 in block2.Instructions)
				{
					method.Body.Instructions.Add(item3);
				}
				foreach (Instruction item4 in ControlFlow.Calc(block2.Number + 1))
				{
					method.Body.Instructions.Add(item4);
				}
				method.Body.Instructions.Add(Instruction.Create(OpCodes.Stloc, local));
				method.Body.Instructions.Add(instruction3);
			}
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Ldloc, local));
			foreach (Instruction item5 in ControlFlow.Calc(blocks.Count - 1))
			{
				method.Body.Instructions.Add(item5);
			}
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Ceq));
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Brfalse, instruction2));
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Br, blocks.Single((Block x) => x.Number == blocks.Count - 1).Instructions[0]));
			method.Body.Instructions.Add(instruction2);
			IEnumerable<Block> blocks2 = blocks;
			Func<Block, bool> <>9__3;
			Func<Block, bool> predicate2;
			if ((predicate2 = <>9__3) == null)
			{
				predicate2 = (<>9__3 = (Block x) => x.Number == blocks.Count - 1);
			}
			foreach (Instruction item6 in blocks2.Single(predicate2).Instructions)
			{
				method.Body.Instructions.Add(item6);
			}
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x00007528 File Offset: 0x00005728
		public static void ExecuteMethod(MethodDef method, ModuleDefMD Module)
		{
			Instruction instruction2;
			Instruction instruction = Instruction.Create(OpCodes.Br, instruction2);
			Local local;
			method.Body.Variables.Add(local);
			List<Block> blocks = ControlFlow.Randomize(blocks);
			List<Instruction>.Enumerator enumerator = ControlFlow.Calc(0).GetEnumerator();
			instruction2 = Instruction.Create(OpCodes.Nop);
			method.Body.Instructions.Clear();
			local = new Local(Module.CorLibTypes.UIntPtr);
			blocks = Blocks.Block(method);
			method.Body.SimplifyMacros(method.Parameters);
			try
			{
				do
				{
					Instruction item = enumerator.Current;
					method.Body.Instructions.Add(item);
				}
				while (enumerator.MoveNext());
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Stloc, local));
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Br, instruction));
			method.Body.Instructions.Add(instruction2);
			IEnumerable<Block> blocks4 = blocks;
			Func<Block, bool> <>9__0;
			Func<Block, bool> predicate;
			if ((predicate = <>9__0) == null)
			{
				Func<Block, bool> <>9__1;
				predicate = (<>9__0 = delegate(Block block)
				{
					IEnumerable<Block> blocks3 = blocks;
					Func<Block, bool> predicate3;
					if ((predicate3 = <>9__1) == null)
					{
						predicate3 = (<>9__1 = (Block x) => x.Number == blocks.Count - 1);
					}
					return block != blocks3.Single(predicate3);
				});
			}
			foreach (Block block2 in blocks4.Where(predicate))
			{
				method.Body.Instructions.Add(Instruction.Create(OpCodes.Ldloc, local));
				foreach (Instruction item2 in ControlFlow.Calc(block2.Number))
				{
					method.Body.Instructions.Add(item2);
				}
				method.Body.Instructions.Add(Instruction.Create(OpCodes.Ceq));
				Instruction instruction3 = Instruction.Create(OpCodes.Nop);
				method.Body.Instructions.Add(Instruction.Create(OpCodes.Brfalse, instruction3));
				foreach (Instruction item3 in block2.Instructions)
				{
					method.Body.Instructions.Add(item3);
				}
				foreach (Instruction item4 in ControlFlow.Calc(block2.Number + 1))
				{
					method.Body.Instructions.Add(item4);
				}
				method.Body.Instructions.Add(Instruction.Create(OpCodes.Stloc, local));
				method.Body.Instructions.Add(instruction3);
			}
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Ldloc, local));
			foreach (Instruction item5 in ControlFlow.Calc(blocks.Count - 1))
			{
				method.Body.Instructions.Add(item5);
			}
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Ceq));
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Brfalse, instruction));
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Br, blocks.Single((Block x) => x.Number == blocks.Count - 1).Instructions[0]));
			method.Body.Instructions.Add(instruction);
			IEnumerable<Block> blocks2 = blocks;
			Func<Block, bool> <>9__3;
			Func<Block, bool> predicate2;
			if ((predicate2 = <>9__3) == null)
			{
				predicate2 = (<>9__3 = (Block x) => x.Number == blocks.Count - 1);
			}
			foreach (Instruction item6 in blocks2.Single(predicate2).Instructions)
			{
				method.Body.Instructions.Add(item6);
			}
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x00007B1C File Offset: 0x00005D1C
		public static List<Block> Randomize(List<Block> input)
		{
			List<Block> list = new List<Block>();
			using (List<Block>.Enumerator enumerator = input.GetEnumerator())
			{
				do
				{
					Block item = enumerator.Current;
					list.Insert(ControlFlow.Random.Next(0, list.Count), item);
				}
				while (enumerator.MoveNext());
			}
			return list;
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00007BA4 File Offset: 0x00005DA4
		public static List<Instruction> Calc(int value)
		{
			List<Instruction> list;
			list.Add(Instruction.Create(OpCodes.Ldc_I4, value));
			list = new List<Instruction>();
			return list;
		}

		// Token: 0x060000AA RID: 170 RVA: 0x00007BD8 File Offset: 0x00005DD8
		public static void AddJump(IList<Instruction> instrs, Instruction target)
		{
			instrs.Add(Instruction.Create(OpCodes.Br, target));
		}

		// Token: 0x0400003D RID: 61
		public static Random Random = new Random();
	}
}
