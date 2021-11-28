using System;
using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using Rose.Helper;

namespace Rose.Protections
{
	// Token: 0x02000067 RID: 103
	public static class Enc
	{
		// Token: 0x06000146 RID: 326 RVA: 0x000141D4 File Offset: 0x000123D4
		private static MethodDef InjectMethod(ModuleDef module, string methodName)
		{
			ModuleDefMD moduleDefMD;
			TypeDef typeDef = moduleDefMD.ResolveTypeDef(MDToken.ToRID(typeof(DecryptionHelper).MetadataToken));
			moduleDefMD = ModuleDefMD.Load(typeof(DecryptionHelper).Module);
			IEnumerator<MethodDef> enumerator = module.GlobalType.Methods.GetEnumerator();
			IEnumerable<IDnlibDef> source = InjectHelper.Inject(typeDef, module.GlobalType, module);
			MethodDef result = (MethodDef)source.Single((IDnlibDef method) => method.Name == methodName);
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
						goto Block_3;
					}
				}
				module.GlobalType.Remove(methodDef);
				Block_3:;
			}
			finally
			{
				if (enumerator != null)
				{
					enumerator.Dispose();
				}
			}
			return result;
		}

		// Token: 0x06000147 RID: 327 RVA: 0x00014374 File Offset: 0x00012574
		public static ModuleDef EncryptStrings(ModuleDef inModule)
		{
			MethodDef methodDef = Enc.InjectMethod(inModule, "qUSxo");
			IEnumerator<TypeDef> enumerator = inModule.Types.GetEnumerator();
			ICrypto crypto = new Base64();
			try
			{
				do
				{
					TypeDef typeDef = enumerator.Current;
					if (!typeDef.IsGlobalModuleType && !(typeDef.Name == "Resources") && !(typeDef.Name == "Settings"))
					{
						foreach (MethodDef methodDef2 in typeDef.Methods)
						{
							if (methodDef2.HasBody && methodDef2 != methodDef)
							{
								methodDef2.Body.KeepOldMaxStack = true;
								int num;
								do
								{
									if (methodDef2.Body.Instructions[num].OpCode == OpCodes.Ldstr)
									{
										string dataPlain = methodDef2.Body.Instructions[num].Operand.ToString();
										methodDef2.Body.Instructions[num].Operand = crypto.Encrypt(dataPlain);
										methodDef2.Body.Instructions.Insert(num + 1, new Instruction(OpCodes.Call, methodDef));
									}
									num++;
								}
								while (num < methodDef2.Body.Instructions.Count);
								methodDef2.Body.SimplifyBranches();
								methodDef2.Body.OptimizeBranches();
							}
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
			return inModule;
		}
	}
}
