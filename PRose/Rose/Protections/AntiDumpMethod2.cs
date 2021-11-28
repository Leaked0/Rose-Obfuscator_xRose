using System;
using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using Rose.Helper;

namespace Rose.Protections
{
	// Token: 0x02000011 RID: 17
	public static class AntiDumpMethod2
	{
		// Token: 0x0600002D RID: 45 RVA: 0x00006224 File Offset: 0x00004424
		public static void Execute(ModuleDef module)
		{
			MethodDef methodDef;
			MethodDef method2;
			methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
			ModuleDefMD moduleDefMD;
			TypeDef typeDef = moduleDefMD.ResolveTypeDef(MDToken.ToRID(typeof(AntiDump2).MetadataToken));
			methodDef = module.GlobalType.FindOrCreateStaticConstructor();
			moduleDefMD = ModuleDefMD.Load(typeof(AntiDump2).Module);
			IEnumerable<IDnlibDef> source;
			method2 = (MethodDef)source.Single((IDnlibDef method) => method.Name == "WUIOL");
			source = InjectHelper.Inject(typeDef, module.GlobalType, module);
			using (IEnumerator<MethodDef> enumerator = module.GlobalType.Methods.GetEnumerator())
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
		}
	}
}
