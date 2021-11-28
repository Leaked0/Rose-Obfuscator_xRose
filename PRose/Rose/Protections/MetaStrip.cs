using System;
using System.Collections.Generic;
using dnlib.DotNet;

namespace Rose.Protections
{
	// Token: 0x02000045 RID: 69
	internal class MetaStrip
	{
		// Token: 0x060000D5 RID: 213 RVA: 0x0000CA4C File Offset: 0x0000AC4C
		public static bool CanRename(object obj)
		{
			iAnalyze iAnalyze;
			for (;;)
			{
				if (!(obj is MethodDef))
				{
					goto IL_D6;
				}
				iAnalyze = new FieldDefAnalyzer();
				IL_59:
				if (!(obj is FieldDef))
				{
					goto IL_128;
				}
				iAnalyze = new TypeDefAnalyzer();
				iAnalyze = new EventDefAnalyzer();
				if (!(obj is TypeDef))
				{
					continue;
				}
				iAnalyze = new MethodDefAnalyzer();
				IL_D6:
				if (obj is EventDef)
				{
					break;
				}
				goto IL_59;
			}
			return false;
			IL_128:
			if (iAnalyze == null)
			{
			}
			return iAnalyze.Execute(obj);
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x0000CBB8 File Offset: 0x0000ADB8
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
