using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using dnlib.DotNet.Writer;

// Token: 0x02000002 RID: 2
public static class Context
{
	// Token: 0x06000001 RID: 1 RVA: 0x000026F0 File Offset: 0x000008F0
	public static void LoadModule(string filename)
	{
		try
		{
			Context.FileName = filename;
			byte[] data = File.ReadAllBytes(filename);
			ModuleContext context = ModuleDef.CreateModuleContext();
			Context.module = ModuleDefMD.Load(data, context);
			foreach (AssemblyRef assemblyRef in Context.module.GetAssemblyRefs())
			{
			}
		}
		catch
		{
		}
	}

	// Token: 0x06000002 RID: 2 RVA: 0x00002790 File Offset: 0x00000990
	public static void SaveModule()
	{
		try
		{
			string filename = string.Concat(new string[]
			{
				Path.GetDirectoryName(Context.FileName),
				"\\",
				Path.GetFileNameWithoutExtension(Context.FileName),
				Path.GetExtension(Context.FileName)
			});
			if (Context.module.IsILOnly)
			{
				ModuleWriterOptions moduleWriterOptions = new ModuleWriterOptions(Context.module);
				moduleWriterOptions.MetaDataOptions.Flags = MetaDataFlags.PreserveAll;
				moduleWriterOptions.MetaDataLogger = DummyLogger.NoThrowInstance;
				Context.module.Write(filename, moduleWriterOptions);
			}
			else
			{
				NativeModuleWriterOptions nativeModuleWriterOptions = new NativeModuleWriterOptions(Context.module);
				nativeModuleWriterOptions.MetaDataOptions.Flags = MetaDataFlags.PreserveAll;
				nativeModuleWriterOptions.MetaDataLogger = DummyLogger.NoThrowInstance;
				Context.module.NativeWrite(filename, nativeModuleWriterOptions);
			}
		}
		catch (ModuleWriterException)
		{
		}
		Console.ReadLine();
	}

	// Token: 0x06000003 RID: 3 RVA: 0x0000289C File Offset: 0x00000A9C
	public static byte[] Compress(byte[] data)
	{
		MemoryStream memoryStream;
		DeflateStream deflateStream = new DeflateStream(memoryStream, CompressionLevel.Optimal);
		memoryStream = new MemoryStream();
		try
		{
			deflateStream.Write(data, 0, data.Length);
		}
		finally
		{
			if (deflateStream != null)
			{
				((IDisposable)deflateStream).Dispose();
			}
		}
		return memoryStream.ToArray();
	}

	// Token: 0x06000004 RID: 4 RVA: 0x00002908 File Offset: 0x00000B08
	public static void PackerPhase()
	{
		ModuleDefMD moduleDefMD;
		moduleDefMD.EncId = Context.module.EncId;
		string text = Context.RandomString(20);
		moduleDefMD.EncBaseId = Context.module.EncBaseId;
		MethodDef entryPoint = moduleDefMD.EntryPoint;
		moduleDefMD.TablesHeaderVersion = Context.module.TablesHeaderVersion;
		Instruction instruction = (from op in entryPoint.Body.Instructions
			where op.OpCode == OpCodes.Ldstr && op.Operand.ToString().Equals("xROSE")
			select op).First<Instruction>();
		moduleDefMD.Characteristics = Context.module.Characteristics;
		moduleDefMD.DllCharacteristics = Context.module.DllCharacteristics;
		moduleDefMD = ModuleDefMD.Load(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\ROSED.exe");
		moduleDefMD.RuntimeVersion = Context.module.RuntimeVersion;
		byte[] ilasByteArray;
		moduleDefMD.Resources.Add(new EmbeddedResource(text, Context.Encrypt(Context.GetCurrentModule(Context.module), ilasByteArray)));
		Instruction instruction2;
		instruction2.Operand = entryPoint.MDToken.ToInt32();
		instruction.Operand = text;
		moduleDefMD.Win32Resources = Context.module.Win32Resources;
		moduleDefMD.Machine = Context.module.Machine;
		Context.module = moduleDefMD;
		instruction2 = (from op in entryPoint.Body.Instructions
			where op.OpCode == OpCodes.Ldc_I4 && op.GetLdcI4Value() == 123456789
			select op).First<Instruction>();
		ilasByteArray = Assembly.Load(Context.GetCurrentModule(moduleDefMD)).ManifestModule.ResolveMethod(entryPoint.MDToken.ToInt32()).GetMethodBody().GetILAsByteArray();
		moduleDefMD.Generation = Context.module.Generation;
		moduleDefMD.Cor20HeaderRuntimeVersion = Context.module.Cor20HeaderRuntimeVersion;
		moduleDefMD.Kind = Context.module.Kind;
		moduleDefMD.Cor20HeaderFlags = Context.module.Cor20HeaderFlags;
	}

	// Token: 0x06000005 RID: 5 RVA: 0x00002B54 File Offset: 0x00000D54
	public static byte[] GetCurrentModule(ModuleDefMD module)
	{
		MemoryStream memoryStream;
		byte[] array;
		memoryStream.Read(array, 0, (int)memoryStream.Length);
		NativeModuleWriterOptions nativeModuleWriterOptions;
		nativeModuleWriterOptions.MetaDataLogger = DummyLogger.NoThrowInstance;
		ModuleWriterOptions moduleWriterOptions = new ModuleWriterOptions(module);
		moduleWriterOptions.MetaDataOptions.Flags = MetaDataFlags.PreserveAll;
		module.NativeWrite(memoryStream, nativeModuleWriterOptions);
		module.Write(memoryStream, moduleWriterOptions);
		memoryStream = new MemoryStream();
		if (module.IsILOnly)
		{
			array = new byte[memoryStream.Length];
			memoryStream.Position = 0L;
			moduleWriterOptions.MetaDataLogger = DummyLogger.NoThrowInstance;
		}
		nativeModuleWriterOptions = new NativeModuleWriterOptions(module);
		nativeModuleWriterOptions.MetaDataOptions.Flags = MetaDataFlags.PreserveAll;
		return array;
	}

	// Token: 0x06000006 RID: 6 RVA: 0x00002C3C File Offset: 0x00000E3C
	public static byte[] Encrypt(byte[] plain, byte[] Key)
	{
		int num = 1;
		int num2 = 0;
		int num3;
		if (0 >= Key.Length)
		{
			num3++;
			do
			{
				plain[num] ^= Key[num % Key.Length];
				if (num2 < 5)
				{
					break;
				}
				num3 = 0;
			}
			while (num < plain.Length);
			num = 0;
		}
		plain[num] = (byte)((int)plain[num] ^ ((((int)Key[num3] << num2) ^ num3) + num));
		num2++;
		return plain;
	}

	// Token: 0x06000007 RID: 7 RVA: 0x00002D0C File Offset: 0x00000F0C
	public static string RandomString(int length)
	{
		return new string((from s in Enumerable.Repeat<string>("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", length)
			select s[Context.random.Next(s.Length)]).ToArray<char>());
	}

	// Token: 0x06000008 RID: 8 RVA: 0x00002D58 File Offset: 0x00000F58
	public static void Welcome()
	{
	}

	// Token: 0x04000001 RID: 1
	private static Random random = new Random();

	// Token: 0x04000002 RID: 2
	public static ModuleDefMD module = null;

	// Token: 0x04000003 RID: 3
	public static string FileName = null;
}
