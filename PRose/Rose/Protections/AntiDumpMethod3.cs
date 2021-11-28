using System;
using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using Rose.Helper;

namespace Rose.Protections
{
	// Token: 0x02000013 RID: 19
	public static class AntiDumpMethod3
	{
		// Token: 0x06000031 RID: 49 RVA: 0x000049A8 File Offset: 0x00002BA8
		public static void InjectEraseMethod(ModuleDef module)
		{
			IEnumerable<IDnlibDef> source;
			AntiDumpMethod3.eraseMethod = (MethodDef)source.Single((IDnlibDef method) => method.Name == "OIURC");
			ModuleDefMD moduleDefMD = ModuleDefMD.Load(typeof(HeaderErase).Module);
			IEnumerator<MethodDef> enumerator = module.GlobalType.Methods.GetEnumerator();
			TypeDef typeDef;
			source = InjectHelper.Inject(typeDef, module.GlobalType, module);
			AntiDumpMethod3.eraseMethod.Body.Instructions.Insert(AntiDumpMethod3.eraseMethod.Body.Instructions.Count - 2, Instruction.Create(OpCodes.Call, AntiDumpMethod3.eraseMethod));
			typeDef = moduleDefMD.ResolveTypeDef(MDToken.ToRID(typeof(HeaderErase).MetadataToken));
			try
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
						goto IL_11D;
					}
				}
				module.GlobalType.Remove(methodDef);
				IL_11D:;
			}
			finally
			{
				if (enumerator != null)
				{
					enumerator.Dispose();
				}
			}
		}

		// Token: 0x04000015 RID: 21
		private static MethodDef eraseMethod;
	}
}
