using System;
using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Rose.Protections
{
	// Token: 0x0200004B RID: 75
	internal class RandomOutlinedMethods : SecureRandoms
	{
		// Token: 0x060000ED RID: 237 RVA: 0x00009B38 File Offset: 0x00007D38
		public static void Execute(ModuleDef module)
		{
			using (IEnumerator<TypeDef> enumerator = module.Types.GetEnumerator())
			{
				do
				{
					TypeDef typeDef = enumerator.Current;
					MethodDef[] array = typeDef.Methods.ToArray<MethodDef>();
					int num;
					do
					{
						MethodDef source_method = array[num];
						if (xd.renamertype == "Ascii")
						{
							MethodDef item = RandomOutlinedMethods.CreateReturnMethodDef(RUtils.GenerateRandomString2(xd.thelength), source_method);
							MethodDef item2 = RandomOutlinedMethods.CreateReturnMethodDef(SecureRandoms.Next(10, 20), source_method);
							typeDef.Methods.Add(item);
							typeDef.Methods.Add(item2);
						}
						if (xd.renamertype == "Numbers")
						{
							MethodDef item3 = RandomOutlinedMethods.CreateReturnMethodDef(RUtils.RandomNum(xd.thelength), source_method);
							MethodDef item4 = RandomOutlinedMethods.CreateReturnMethodDef(SecureRandoms.Next(5, 20), source_method);
							typeDef.Methods.Add(item3);
							typeDef.Methods.Add(item4);
						}
						if (xd.renamertype == "Symbols")
						{
							MethodDef item5 = RandomOutlinedMethods.CreateReturnMethodDef(RUtils.RandomSymbols(xd.thelength), source_method);
							MethodDef item6 = RandomOutlinedMethods.CreateReturnMethodDef(SecureRandoms.Next(5, 20), source_method);
							typeDef.Methods.Add(item5);
							typeDef.Methods.Add(item6);
						}
						if (xd.renamertype == "Chinese")
						{
							MethodDef item7 = RandomOutlinedMethods.CreateReturnMethodDef(RUtils.RandomChinese(xd.thelength), source_method);
							MethodDef item8 = RandomOutlinedMethods.CreateReturnMethodDef(SecureRandoms.Next(5, 20), source_method);
							typeDef.Methods.Add(item7);
							typeDef.Methods.Add(item8);
						}
						num++;
					}
					while (num < array.Length);
				}
				while (enumerator.MoveNext());
			}
		}

		// Token: 0x060000EE RID: 238 RVA: 0x00009DA4 File Offset: 0x00007FA4
		public static MethodDef CreateReturnMethodDef(object value, MethodDef source_method)
		{
			MethodDef methodDef;
			methodDef.Body.Instructions.Add(Instruction.Create(OpCodes.Ldc_I4, (int)value));
			CorLibTypeSig retType = source_method.Module.CorLibTypes.Int32;
			if (!(value is int))
			{
				goto IL_FD;
			}
			IL_7A:
			methodDef = new MethodDefUser(RUtils.GenerateRandomString2(xd.thelength), MethodSig.CreateStatic(retType), MethodImplAttributes.IL, MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.Static | MethodAttributes.HideBySig)
			{
				Body = new CilBody()
			};
			retType = source_method.Module.CorLibTypes.String;
			IL_C7:
			if (!(value is string))
			{
				goto IL_7A;
			}
			retType = null;
			methodDef.Body.Instructions.Add(Instruction.Create(OpCodes.Ldstr, (string)value));
			IL_FD:
			if (value is string)
			{
			}
			methodDef.Body.Instructions.Add(new Instruction(OpCodes.Ret));
			if (value is int)
			{
				return methodDef;
			}
			goto IL_C7;
		}
	}
}
