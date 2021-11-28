using System;
using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using dnlib.DotNet.Writer;

namespace Rose.Protections
{
	// Token: 0x02000005 RID: 5
	public class AntiDe4dot
	{
		// Token: 0x06000010 RID: 16 RVA: 0x000033E4 File Offset: 0x000015E4
		public static void Execute1(AssemblyDef mod)
		{
			using (IEnumerator<ModuleDef> enumerator = mod.Modules.GetEnumerator())
			{
				do
				{
					ModuleDef moduleDef = enumerator.Current;
					InterfaceImplUser item = new InterfaceImplUser(moduleDef.GlobalType);
					int num;
					do
					{
						TypeDefUser typeDefUser = new TypeDefUser(string.Empty, RUtils.GenerateRandomString2(5), moduleDef.CorLibTypes.GetTypeRef("System", "Attribute"));
						InterfaceImplUser item2 = new InterfaceImplUser(typeDefUser);
						moduleDef.Types.Add(typeDefUser);
						typeDefUser.Interfaces.Add(item2);
						typeDefUser.Interfaces.Add(item);
						num++;
					}
					while (num < 1);
				}
				while (enumerator.MoveNext());
			}
		}

		// Token: 0x06000011 RID: 17 RVA: 0x0000351C File Offset: 0x0000171C
		public static void Execute2(Context context, ModuleDef moduleDef)
		{
			TypeDef typeDef;
			MethodDefUser methodDefUser;
			int num;
			do
			{
				typeDef = new TypeDefUser(null, RUtils.GenerateRandomString2(5), moduleDef.CorLibTypes.GetTypeRef("System", "Attribute"));
				typeDef.Methods.Add(methodDefUser);
				methodDefUser.Body.Instructions.Add(OpCodes.Call.ToInstruction(new MemberRefUser(moduleDef, ".cctor", MethodSig.CreateInstance(moduleDef.CorLibTypes.Void), typeDef)));
				methodDefUser.Body.Instructions.Add(OpCodes.Ldarg_0.ToInstruction());
			}
			while (num < 1);
			MethodDefUser methodDefUser2;
			methodDefUser2.Body.Instructions.Add(OpCodes.Call.ToInstruction(new MemberRefUser(moduleDef, ".ctor", MethodSig.CreateInstance(moduleDef.CorLibTypes.Void), typeDef)));
			typeDef.Methods.Add(methodDefUser2);
			methodDefUser.Body.Instructions.Add(OpCodes.Ret.ToInstruction());
			moduleDef.Types.Add(typeDef);
			num++;
			num = 0;
			InterfaceImpl item;
			typeDef.Interfaces.Add(item);
			methodDefUser2.Body.Instructions.Add(OpCodes.Ret.ToInstruction());
			methodDefUser.Body.MaxStack = 1;
			item = new InterfaceImplUser(moduleDef.GlobalType);
			methodDefUser = new MethodDefUser(".cctor", MethodSig.CreateInstance(moduleDef.CorLibTypes.Void, moduleDef.CorLibTypes.String), MethodImplAttributes.IL, MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName)
			{
				Body = new CilBody()
			};
			methodDefUser2.Body.Instructions.Add(OpCodes.Ldarg_0.ToInstruction());
			InterfaceImpl item2;
			typeDef.Interfaces.Add(item2);
			item2 = new InterfaceImplUser(typeDef);
			methodDefUser2.Body.MaxStack = 1;
			methodDefUser2 = new MethodDefUser(".ctor", MethodSig.CreateInstance(moduleDef.CorLibTypes.Void, moduleDef.CorLibTypes.String), MethodImplAttributes.IL, MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName)
			{
				Body = new CilBody()
			};
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00003900 File Offset: 0x00001B00
		public static ModuleWriterOptions Execute(ModuleDef moduleDef)
		{
			Context context;
			ModuleWriterOptions moduleWriterOptions = new ModuleWriterOptions(context.ManifestModule);
			context = new Context(moduleDef);
			AntiDe4dot.Execute2(context, moduleDef);
			moduleWriterOptions.Logger = DummyLogger.NoThrowInstance;
			return moduleWriterOptions;
		}
	}
}
