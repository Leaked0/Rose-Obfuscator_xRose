using System;
using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using Rose.Helper;

namespace Rose.Protections
{
	// Token: 0x0200000A RID: 10
	public class AntiDebug2
	{
		// Token: 0x0600001B RID: 27 RVA: 0x000035CC File Offset: 0x000017CC
		public static void Execute(ModuleDef module)
		{
			AntiDebug2.debuggerMethod.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, AntiDebug2.debuggerMethod));
			TypeDef typeDef;
			IEnumerable<IDnlibDef> source = InjectHelper.Inject(typeDef, module.GlobalType, module);
			ModuleDefMD moduleDefMD = ModuleDefMD.Load(typeof(DebugChecker).Module);
			AntiDebug2.debuggerMethod = (MethodDef)source.Single((IDnlibDef method) => method.Name == "CEKQW");
			typeDef = moduleDefMD.ResolveTypeDef(MDToken.ToRID(typeof(DebugChecker).MetadataToken));
			using (IEnumerator<MethodDef> enumerator = module.GlobalType.Methods.GetEnumerator())
			{
				MethodDef methodDef;
				for (;;)
				{
					methodDef = enumerator.Current;
					if (methodDef.Name == ".ctor")
					{
						break;
					}
					if (!enumerator.MoveNext())
					{
						goto IL_108;
					}
				}
				module.GlobalType.Remove(methodDef);
				IL_108:;
			}
		}

		// Token: 0x0400000E RID: 14
		private static MethodDef debuggerMethod;
	}
}
