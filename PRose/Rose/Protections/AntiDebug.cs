using System;
using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using Rose.Helper;

namespace Rose.Protections
{
	// Token: 0x02000007 RID: 7
	public static class AntiDebug
	{
		// Token: 0x06000015 RID: 21 RVA: 0x000039F4 File Offset: 0x00001BF4
		public static void Execute(ModuleDef module)
		{
			ModuleDefMD moduleDefMD = ModuleDefMD.Load(typeof(AntiDebugSafe).Module);
			MethodDef methodDef;
			MethodDef method2;
			methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
			IEnumerable<IDnlibDef> source;
			method2 = (MethodDef)source.Single((IDnlibDef method) => method.Name == "xEQAW");
			TypeDef typeDef;
			source = InjectHelper.Inject(typeDef, module.GlobalType, module);
			typeDef = moduleDefMD.ResolveTypeDef(MDToken.ToRID(typeof(AntiDebugSafe).MetadataToken));
			methodDef = module.GlobalType.FindOrCreateStaticConstructor();
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
