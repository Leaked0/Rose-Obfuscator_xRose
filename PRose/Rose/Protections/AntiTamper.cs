using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using Rose.Helper;

namespace Rose.Protections
{
	// Token: 0x02000016 RID: 22
	public static class AntiTamper
	{
		// Token: 0x0600003A RID: 58 RVA: 0x00006670 File Offset: 0x00004870
		public static void Sha256(string filePath)
		{
			FileStream fileStream = new FileStream(filePath, FileMode.Append);
			byte[] array = SHA256.Create().ComputeHash(File.ReadAllBytes(filePath));
			try
			{
				fileStream.Write(array, 0, array.Length);
			}
			finally
			{
				if (fileStream != null)
				{
					((IDisposable)fileStream).Dispose();
				}
			}
		}

		// Token: 0x0600003B RID: 59 RVA: 0x0000671C File Offset: 0x0000491C
		public static void Execute(ModuleDef module)
		{
			ModuleDefMD moduleDefMD = ModuleDefMD.Load(typeof(EofAntiTamper).Module);
			TypeDef typeDef = moduleDefMD.ResolveTypeDef(MDToken.ToRID(typeof(EofAntiTamper).MetadataToken));
			IEnumerable<IDnlibDef> source = InjectHelper.Inject(typeDef, module.GlobalType, module);
			MethodDef methodDef = module.GlobalType.FindOrCreateStaticConstructor();
			MethodDef method2;
			methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method2));
			IEnumerator<MethodDef> enumerator = module.GlobalType.Methods.GetEnumerator();
			method2 = (MethodDef)source.Single((IDnlibDef method) => method.Name == "MARWA");
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
