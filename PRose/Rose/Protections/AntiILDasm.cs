using System;
using dnlib.DotNet;

namespace Rose.Protections
{
	// Token: 0x02000019 RID: 25
	public class AntiILDasm
	{
		// Token: 0x06000041 RID: 65 RVA: 0x00004D1C File Offset: 0x00002F1C
		public static void Execute(ModuleDefMD module)
		{
			TypeRef typeRef = module.CorLibTypes.GetTypeRef("System.Runtime.CompilerServices", "SuppressIldasmAttribute");
			CustomAttribute item;
			module.CustomAttributes.Add(item);
			MemberRefUser ctor = new MemberRefUser(module, ".ctor", MethodSig.CreateInstance(module.CorLibTypes.Void), typeRef);
			item = new CustomAttribute(ctor);
		}
	}
}
