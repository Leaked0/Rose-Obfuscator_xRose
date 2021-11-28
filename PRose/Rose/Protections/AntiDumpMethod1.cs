using System;
using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using Rose.Helper;

namespace Rose.Protections
{
	// Token: 0x0200000F RID: 15
	public static class AntiDumpMethod1
	{
		// Token: 0x06000029 RID: 41 RVA: 0x00006050 File Offset: 0x00004250
		public static void Execute(ModuleDef module)
		{
			IEnumerable<IDnlibDef> source;
			MethodDef method2 = (MethodDef)source.Single((IDnlibDef method) => method.Name == "ZETRO");
			ModuleDefMD moduleDefMD;
			TypeDef typeDef = moduleDefMD.ResolveTypeDef(MDToken.ToRID(typeof(AntiDump).MetadataToken));
			IEnumerator<MethodDef> enumerator = module.GlobalType.Methods.GetEnumerator();
			MethodDef methodDef = module.GlobalType.FindOrCreateStaticConstructor();
			methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
			source = InjectHelper.Inject(typeDef, module.GlobalType, module);
			moduleDefMD = ModuleDefMD.Load(typeof(AntiDump).Module);
			try
			{
				MethodDef methodDef2;
				for (;;)
				{
					methodDef2 = enumerator.Current;
					if (!(methodDef2.Name != ".ctor"))
					{
						break;
					}
					if (!enumerator.MoveNext())
					{
						goto Block_4;
					}
				}
				module.GlobalType.Remove(methodDef2);
				Block_4:;
			}
			finally
			{
				if (enumerator != null)
				{
					enumerator.Dispose();
				}
			}
		}
	}
}
