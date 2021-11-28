using System;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Rose.Protections
{
	// Token: 0x02000062 RID: 98
	internal class Calli
	{
		// Token: 0x06000138 RID: 312 RVA: 0x00012ACC File Offset: 0x00010CCC
		public static void Execute(ModuleDef module)
		{
			MethodDef methodDef;
			if (methodDef.IsConstructor)
			{
				goto IL_409;
			}
			int num = 0;
			if (methodDef.FullName.Contains(".My"))
			{
				goto IL_409;
			}
			IL_7F:
			MethodDef[] array;
			methodDef = array[num];
			if (methodDef.FullName.Contains("My."))
			{
				goto IL_409;
			}
			TypeDef typeDef;
			array = typeDef.Methods.ToArray<MethodDef>();
			if (!methodDef.HasBody)
			{
				goto IL_409;
			}
			TypeDef[] array2 = module.Types.ToArray<TypeDef>();
			int num2 = 0;
			int num3 = 0;
			if (!methodDef.Body.HasInstructions || methodDef.DeclaringType.IsGlobalModuleType)
			{
				goto IL_409;
			}
			IL_19B:
			typeDef = array2[num3];
			if (!methodDef.FullName.Contains("Costura"))
			{
				do
				{
					try
					{
						if (!methodDef.Body.Instructions[num2].ToString().Contains("ISupportInitialize") && (methodDef.Body.Instructions[num2].OpCode == OpCodes.Call || methodDef.Body.Instructions[num2].OpCode == OpCodes.Callvirt || methodDef.Body.Instructions[num2].OpCode == OpCodes.Ldloc_S))
						{
							if (!methodDef.Body.Instructions[num2].ToString().Contains("Object") && (methodDef.Body.Instructions[num2].OpCode == OpCodes.Call || methodDef.Body.Instructions[num2].OpCode == OpCodes.Callvirt || methodDef.Body.Instructions[num2].OpCode == OpCodes.Ldloc_S))
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
					catch (Exception)
					{
					}
					num2++;
				}
				while (num2 < methodDef.Body.Instructions.Count - 1);
			}
			IL_409:
			num++;
			if (num < array.Length)
			{
				goto IL_7F;
			}
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
			goto IL_19B;
		}
	}
}
