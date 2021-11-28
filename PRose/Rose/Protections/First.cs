using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Rose.Protections
{
	// Token: 0x02000064 RID: 100
	public static class First
	{
		// Token: 0x0600013C RID: 316 RVA: 0x00013308 File Offset: 0x00011508
		public static void Execute(ModuleDef md)
		{
			First.StringEncrypting(md);
		}

		// Token: 0x0600013D RID: 317 RVA: 0x00013348 File Offset: 0x00011548
		public static void StringEncrypting(ModuleDef moduleDef)
		{
			TypeDef typeDef = null;
			First.DefType(moduleDef);
			using (IEnumerator<TypeDef> enumerator = moduleDef.Types.GetEnumerator())
			{
				TypeDef typeDef2;
				for (;;)
				{
					typeDef2 = enumerator.Current;
					if (typeDef2.Name == First.x)
					{
						break;
					}
					if (!enumerator.MoveNext())
					{
						goto Block_4;
					}
				}
				typeDef = typeDef2;
				Block_4:;
			}
			foreach (TypeDef typeDef3 in moduleDef.Types)
			{
				foreach (MethodDef methodDef in typeDef3.Methods)
				{
					if (methodDef.Body != null)
					{
						int num;
						do
						{
							if (methodDef.Body.Instructions[num].OpCode == OpCodes.Ldstr)
							{
								string str = methodDef.Body.Instructions[num].Operand.ToString();
								string operand = First.EncryptString(str);
								methodDef.Body.Instructions[num].OpCode = OpCodes.Nop;
								methodDef.Body.Instructions.Insert(num + 1, new Instruction(OpCodes.Ldstr, operand));
								methodDef.Body.Instructions.Insert(num + 2, new Instruction(OpCodes.Call, typeDef.FindMethod(First.y)));
								num += 2;
							}
							methodDef.Body.OptimizeBranches();
							methodDef.Body.SimplifyBranches();
							num++;
						}
						while (num < methodDef.Body.Instructions.Count<Instruction>());
					}
				}
			}
		}

		// Token: 0x0600013E RID: 318 RVA: 0x00013634 File Offset: 0x00011834
		public static void DefType(ModuleDef moduleDef)
		{
			MethodDef methodDef;
			methodDef.Body.Instructions.Add(new Instruction(OpCodes.Ldc_I4_0));
			methodDef.Body.Variables.Locals.Add(new Local(methodDef.Module.CorLibTypes.Int32));
			MethodImplAttributes implFlags = MethodImplAttributes.IL;
			methodDef.Body.Instructions.Add(new Instruction(OpCodes.Ldelema, moduleDef.Import(typeof(byte))));
			methodDef.Body.Instructions.Add(new Instruction(OpCodes.Ldind_U1));
			methodDef.Body.Instructions.Add(new Instruction(OpCodes.Ldloc_1));
			Instruction instruction;
			methodDef.Body.Instructions.Add(new Instruction(OpCodes.Br_S, instruction));
			methodDef.Body.SimplifyBranches();
			methodDef.Body.Instructions.Add(new Instruction(OpCodes.Conv_I4));
			Importer importer = new Importer(moduleDef);
			methodDef.Body.Instructions.Add(new Instruction(OpCodes.Ret));
			methodDef.Body.Instructions.Add(new Instruction(OpCodes.Call, moduleDef.Import(typeof(Encoding).GetMethod("get_ASCII", new Type[0]))));
			Instruction instruction2;
			methodDef.Body.Instructions.Add(instruction2);
			ITypeDefOrRef type;
			methodDef.Body.Variables.Locals.Add(new Local(type.ToTypeSig()));
			methodDef.Body.Instructions.Add(new Instruction(OpCodes.Stloc_1));
			TypeDefUser typeDefUser;
			typeDefUser.Attributes = TypeAttributes.Public | TypeAttributes.Abstract | TypeAttributes.Sealed;
			methodDef.Body.Instructions.Add(new Instruction(OpCodes.Ldloc_1));
			type = importer.Import(typeof(byte[]));
			methodDef.Body.Instructions.Add(new Instruction(OpCodes.Ldloc_0));
			MethodAttributes flags;
			MethodDefUser item = new MethodDefUser(First.y, MethodSig.CreateStatic(moduleDef.CorLibTypes.String, moduleDef.CorLibTypes.String), implFlags, flags);
			methodDef.Body.Instructions.Add(new Instruction(OpCodes.Sub));
			methodDef.Body.Instructions.Add(new Instruction(OpCodes.Ldc_I4_1));
			methodDef.Body.Instructions.Add(new Instruction(OpCodes.Call, moduleDef.Import(typeof(Encoding).GetMethod("get_ASCII", new Type[0]))));
			methodDef.Body.Instructions.Add(new Instruction(OpCodes.Ldarg_0));
			instruction = Instruction.Create(OpCodes.Ldloc_1);
			flags = MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.Static;
			methodDef.Body.Instructions.Add(new Instruction(OpCodes.Callvirt, moduleDef.Import(typeof(Encoding).GetMethod("GetBytes", new Type[] { typeof(string) }))));
			methodDef.MethodBody = new CilBody();
			methodDef = typeDefUser.FindMethod(First.y);
			methodDef.Body.Instructions.Add(new Instruction(OpCodes.Ldloc_0));
			methodDef.Body.Instructions.Add(instruction);
			methodDef.Body.Instructions.Add(new Instruction(OpCodes.Dup));
			FieldDefUser item2 = new FieldDefUser(First.f, new FieldSig(moduleDef.CorLibTypes.Int32), FieldAttributes.FamANDAssem | FieldAttributes.Family | FieldAttributes.Static);
			methodDef.Body.Instructions.Add(new Instruction(OpCodes.Blt_S, instruction2));
			methodDef.Body.Instructions.Add(new Instruction(OpCodes.Ldlen));
			methodDef.Body.Instructions.Add(new Instruction(OpCodes.Ldc_I4_1));
			moduleDef.Types.Add(typeDefUser);
			methodDef.Body.Instructions.Add(new Instruction(OpCodes.Stloc_0));
			methodDef.Body.Instructions.Add(new Instruction(OpCodes.Stloc_1));
			typeDefUser.Fields.Add(item2);
			typeDefUser = new TypeDefUser(First.xx, First.x, moduleDef.CorLibTypes.Object.TypeDefOrRef);
			methodDef.Body.Instructions.Add(new Instruction(OpCodes.Add));
			methodDef.Body.OptimizeBranches();
			typeDefUser.Methods.Add(item);
			methodDef.Body.Instructions.Add(new Instruction(OpCodes.Callvirt, moduleDef.Import(typeof(Encoding).GetMethod("GetString", new Type[] { typeof(byte[]) }))));
			methodDef.Body.Instructions.Add(new Instruction(OpCodes.Stind_I1));
			methodDef.Body.Instructions.Add(new Instruction(OpCodes.Conv_U1));
			instruction2 = Instruction.Create(OpCodes.Ldloc_0);
		}

		// Token: 0x0600013F RID: 319 RVA: 0x00013ED4 File Offset: 0x000120D4
		private static byte[] StrToBytes(string str)
		{
			return Encoding.ASCII.GetBytes(str);
		}

		// Token: 0x06000140 RID: 320 RVA: 0x00013F08 File Offset: 0x00012108
		private static string EncryptString(string str)
		{
			int num;
			num++;
			byte[] array;
			byte[] array3;
			if (num >= array.Length)
			{
				int num2 = num;
				byte[] array2 = array3;
				int num3 = num2;
				array2[num3] += 1;
			}
			array3 = array;
			array = First.StrToBytes(str);
			num = 0;
			return Encoding.ASCII.GetString(array);
		}

		// Token: 0x06000141 RID: 321 RVA: 0x00014008 File Offset: 0x00012208
		private static string DecryptString(string str)
		{
			int num;
			byte[] bytes;
			byte[] array2;
			if (num >= bytes.Length)
			{
				byte[] array = array2;
				int num3;
				int num2 = num3;
				array[num2] -= 1;
				num3 = num;
				num = 0;
			}
			array2 = bytes;
			bytes = Encoding.ASCII.GetBytes(str);
			num++;
			return Encoding.ASCII.GetString(bytes);
		}

		// Token: 0x0400006E RID: 110
		public static string x = RUtils.GenerateRandomString2(5);

		// Token: 0x0400006F RID: 111
		public static string xx = RUtils.GenerateRandomString2(5);

		// Token: 0x04000070 RID: 112
		public static string y = RUtils.GenerateRandomString2(5);

		// Token: 0x04000071 RID: 113
		public static string f = RUtils.GenerateRandomString2(5);
	}
}
