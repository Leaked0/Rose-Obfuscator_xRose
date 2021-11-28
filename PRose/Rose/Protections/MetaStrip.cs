using System;
using System.Collections.Generic;
using dnlib.DotNet;

namespace Rose.Protections
{
	// Token: 0x02000045 RID: 69
	internal class MetaStrip
	{
		// Token: 0x060000D5 RID: 213 RVA: 0x00008F44 File Offset: 0x00007144
		public static bool CanRename(object obj)
		{
			iAnalyze iAnalyze;
			for (;;)
			{
				if (!(obj is MethodDef))
				{
					goto IL_34;
				}
				iAnalyze = new FieldDefAnalyzer();
				IL_03:
				if (!(obj is FieldDef))
				{
					goto IL_5F;
				}
				iAnalyze = new TypeDefAnalyzer();
				iAnalyze = new EventDefAnalyzer();
				if (!(obj is TypeDef))
				{
					continue;
				}
				iAnalyze = new MethodDefAnalyzer();
				IL_34:
				if (obj is EventDef)
				{
					break;
				}
				goto IL_03;
			}
			return false;
			IL_5F:
			if (iAnalyze != null)
			{
			}
			return iAnalyze.Execute(obj);
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x00008FC4 File Offset: 0x000071C4
		public static void Execute(ModuleDefMD module)
		{
			using (IEnumerator<CustomAttribute> enumerator = module.Assembly.CustomAttributes.GetEnumerator())
			{
				do
				{
					CustomAttribute customAttribute = enumerator.Current;
					if (MetaStrip.CanRename(customAttribute))
					{
						module.Assembly.CustomAttributes.Remove(customAttribute);
					}
				}
				while (enumerator.MoveNext());
			}
			module.Mvid = null;
			module.Name = null;
			foreach (TypeDef typeDef in module.Types)
			{
				foreach (CustomAttribute customAttribute2 in typeDef.CustomAttributes)
				{
					if (MetaStrip.CanRename(customAttribute2))
					{
						typeDef.CustomAttributes.Remove(customAttribute2);
					}
				}
				foreach (MethodDef methodDef in typeDef.Methods)
				{
					foreach (CustomAttribute customAttribute3 in methodDef.CustomAttributes)
					{
						if (MetaStrip.CanRename(customAttribute3))
						{
							methodDef.CustomAttributes.Remove(customAttribute3);
						}
					}
				}
				foreach (PropertyDef propertyDef in typeDef.Properties)
				{
					foreach (CustomAttribute customAttribute4 in propertyDef.CustomAttributes)
					{
						if (MetaStrip.CanRename(customAttribute4))
						{
							propertyDef.CustomAttributes.Remove(customAttribute4);
						}
					}
				}
				foreach (FieldDef fieldDef in typeDef.Fields)
				{
					foreach (CustomAttribute customAttribute5 in fieldDef.CustomAttributes)
					{
						if (MetaStrip.CanRename(customAttribute5))
						{
							fieldDef.CustomAttributes.Remove(customAttribute5);
						}
					}
				}
				foreach (EventDef eventDef in typeDef.Events)
				{
					foreach (CustomAttribute customAttribute6 in eventDef.CustomAttributes)
					{
						if (MetaStrip.CanRename(customAttribute6))
						{
							eventDef.CustomAttributes.Remove(customAttribute6);
						}
					}
				}
			}
		}
	}
}
