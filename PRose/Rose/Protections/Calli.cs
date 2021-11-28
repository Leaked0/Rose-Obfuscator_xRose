using System;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Rose.Protections
{
	// Token: 0x02000062 RID: 98
	internal class Calli
	{
		// Token: 0x06000138 RID: 312 RVA: 0x0000DA90 File Offset: 0x0000BC90
		public static void Execute(ModuleDef module)
		{
			MethodDef methodDef;
			int num;
			if (!methodDef.IsConstructor)
			{
				num = 0;
				if (!methodDef.FullName.Contains(".My"))
				{
					goto IL_46;
				}
			}
			IL_29:
			num++;
			MethodDef[] array;
			if (num >= array.Length)
			{
				goto IL_2D2;
			}
			IL_46:
			methodDef = array[num];
			if (methodDef.FullName.Contains("My."))
			{
				goto IL_29;
			}
			TypeDef typeDef;
			array = typeDef.Methods.ToArray<MethodDef>();
			if (!methodDef.HasBody)
			{
				goto IL_29;
			}
			TypeDef[] array2 = module.Types.ToArray<TypeDef>();
			int num2 = 0;
			int num3 = 0;
			if (!methodDef.Body.HasInstructions || methodDef.DeclaringType.IsGlobalModuleType)
			{
				goto IL_29;
			}
			IL_CF:
			typeDef = array2[num3];
			if (!methodDef.FullName.Contains("Costura"))
			{
				do
				{
					try
					{
						if (!methodDef.Body.Instructions[num2].ToString().Contains("ISupportInitialize"))
						{
							if (methodDef.Body.Instructions[num2].OpCode == OpCodes.Call || methodDef.Body.Instructions[num2].OpCode == OpCodes.Callvirt || methodDef.Body.Instructions[num2].OpCode == OpCodes.Ldloc_S)
							{
								if (!methodDef.Body.Instructions[num2].ToString().Contains("Object"))
								{
									if (methodDef.Body.Instructions[num2].OpCode == OpCodes.Call || methodDef.Body.Instructions[num2].OpCode == OpCodes.Callvirt || methodDef.Body.Instructions[num2].OpCode == OpCodes.Ldloc_S)
									{
										try
										{
											MemberRef memberRef = (MemberRef)methodDef.Body.Instructions[num2].Operand;
											methodDef.Body.Instructions[num2].OpCode = OpCodes.Calli;
											methodDef.Body.Instructions[num2].Operand = memberRef.MethodSig;
											methodDef.Body.Instructions.Insert(num2, Instruction.Create(OpCodes.Ldftn, memberRef));
										}
										catch (Exception)
										{
										}
									}
								}
							}
						}
						goto IL_35E;
					}
					catch (Exception)
					{
						goto IL_35E;
					}
					goto IL_2D2;
					IL_35E:
					num2++;
				}
				while (num2 < methodDef.Body.Instructions.Count - 1);
				goto IL_29;
			}
			goto IL_29;
			IL_2D2:
			foreach (MethodDef methodDef2 in module.GlobalType.Methods)
			{
				if (!(methodDef2.Name != ".ctor"))
				{
					module.GlobalType.Remove(methodDef2);
					break;
				}
			}
			num3++;
			if (num3 >= array2.Length)
			{
				return;
			}
			goto IL_CF;
		}
	}
}
