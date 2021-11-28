using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Rose.Protections
{
	// Token: 0x0200000D RID: 13
	internal static class AntiDump
	{
		// Token: 0x06000023 RID: 35
		[DllImport("kernel32.dll")]
		private unsafe static extern bool VirtualProtect(byte* lpAddress, int dwSize, uint flNewProtect, out uint lpflOldProtect);

		// Token: 0x06000024 RID: 36 RVA: 0x0000375C File Offset: 0x0000195C
		public unsafe static void ZETRO()
		{
			uint[] array;
			uint[] array2;
			byte* ptr;
			byte* ptr4;
			int num6;
			ushort num8;
			int num12;
			uint num24;
			if (0U >= array[0] + array2[0])
			{
				byte* ptr7;
				byte* ptr8;
				for (;;)
				{
					IL_BC3:
					int num;
					num++;
					ptr += 6;
					byte* ptr2;
					*(int*)ptr2 = 1818522734;
					byte* ptr3;
					*(int*)(ptr3 + (IntPtr)3 * 4) = 0;
					int num2 = 0;
					ptr4 = (ptr4 + 7L) & -4L;
					uint num3;
					int num4;
					uint num5;
					uint[] array3;
					int num7;
					uint num9;
					int num10;
					byte* ptr6;
					int num14;
					uint num15;
					int num17;
					int num19;
					Module module;
					uint num20;
					int num21;
					int num22;
					byte* ptr10;
					byte* ptr9;
					int num26;
					uint num27;
					byte* ptr11;
					for (;;)
					{
						AntiDump.VirtualProtect(ptr4, 8, 64U, out num3);
						*(int*)ptr3 = 0;
						if (*(uint*)(ptr - 120) == 0U)
						{
							goto IL_6D6;
						}
						*(short*)(ptr2 + (IntPtr)4 * 2) = 108;
						if (num4 < 11)
						{
							goto IL_AC2;
						}
						num5 = num5 - array[num6] + array3[num6];
						if (num7 < (int)num8)
						{
							goto IL_8D2;
						}
						ptr4 += 4;
						num9 = num9 - array[num7] + array3[num7];
						array2[num10] = *(uint*)(ptr + 8);
						int num11;
						byte* ptr5;
						if (num >= (int)num8)
						{
							array3[num10] = *(uint*)(ptr + 20);
							num11++;
							num9 = *(uint*)(ptr5 + 12);
							goto IL_547;
						}
						goto IL_439;
						IL_466:
						AntiDump.VirtualProtect(ptr6, 8, 64U, out num3);
						ptr6 += 2;
						ushort num13;
						if (num12 < (int)num13)
						{
							continue;
						}
						ptr4++;
						if (*ptr6 != 0)
						{
							goto IL_4B1;
						}
						goto IL_C2C;
						IL_530:
						if (array[num14] > num15)
						{
							goto IL_960;
						}
						int num16;
						if (num16 < (int)num8)
						{
							goto IL_547;
						}
						ptr6 += 3;
						if (num17 < 11)
						{
							goto IL_A60;
						}
						*(int*)(ptr7 + (IntPtr)3 * 4) = 0;
						num12 = 0;
						ushort num18;
						if (*ptr4 != 0)
						{
							*ptr4 = 0;
							num18 = *(ushort*)ptr;
							ptr += 40;
							num19++;
							ptr6 = (ptr6 + 7L) & -4L;
							array[num10] = *(uint*)(ptr + 12);
							if (num6 < (int)num8)
							{
								goto IL_519;
							}
							ptr2[10] = 0;
							ptr4 += 4;
							if (module.FullyQualifiedName[0] == '<')
							{
								goto IL_C5C;
							}
							num20 = *(uint*)ptr5;
							*(int*)(ptr2 + 4) = 1852404846;
							array2 = new uint[(int)num8];
							Marshal.Copy(new byte[8], 0, (IntPtr)((void*)ptr), 8);
							num21++;
							if (num21 >= 8)
							{
								ushort num23;
								if (num22 >= (int)num23)
								{
									AntiDump.VirtualProtect(ptr4, 4, 64U, out num3);
									ptr3 = ptr8 + num24;
									ptr4 += *(uint*)ptr4;
									array3 = new uint[(int)num8];
									ptr9 = ptr8 + *(uint*)(ptr10 + 12);
									num17++;
									*(int*)(ptr3 + (IntPtr)2 * 4) = 0;
									ptr6++;
									goto IL_6B5;
								}
								goto IL_466;
							}
						}
						AntiDump.VirtualProtect(ptr6, 4, 64U, out num3);
						num6 = 0;
						ptr4 += 2;
						if (*ptr4 != 0)
						{
							goto IL_C6B;
						}
						if (*ptr6 == 0)
						{
							goto Block_10;
						}
						IL_266:
						*ptr6 = 0;
						Marshal.Copy(new byte[8], 0, (IntPtr)((void*)ptr), 8);
						if (num14 >= (int)num8)
						{
							num15 = num15 - array[num14] + array3[num14];
							*(int*)ptr2 = 1866691662;
							goto IL_4B1;
						}
						goto IL_530;
						IL_439:
						if (array[num] <= num24)
						{
							num17 = 0;
							ptr2 = stackalloc byte[checked(unchecked((UIntPtr)11) * 1)];
							goto IL_466;
						}
						goto IL_BC3;
						IL_4B1:
						*ptr6 = 0;
						AntiDump.VirtualProtect(ptr3, 72, 64U, out num3);
						num8 = *(ushort*)ptr;
						int num25;
						if (num25 < (int)num8)
						{
							goto IL_841;
						}
						if (num2 < (int)num8)
						{
							goto IL_507;
						}
						do
						{
							AntiDump.VirtualProtect(ptr4, 4, 64U, out num3);
							*(int*)ptr4 = 0;
							num13 = (ushort)(*ptr4);
							if (num19 < 11)
							{
								goto IL_92D;
							}
							ptr += 14;
							num19 = 0;
							if (num11 < 11)
							{
								goto IL_4EE;
							}
							num5 = *(uint*)(ptr3 + 8);
							num24 = num24 - array[num] + array3[num];
						}
						while (num26 < 8);
						num10 = 0;
						if (num27 >= array[num2] + array2[num2])
						{
							goto IL_B5C;
						}
						ptr6 += 12;
						ptr2[10] = 0;
						ptr6 += 4;
						num11 = 0;
						ptr += 40;
						if (*ptr6 != 0)
						{
							break;
						}
						num4++;
						*(int*)ptr7 = 0;
						if (num5 < array[num6] + array2[num6])
						{
							AntiDump.VirtualProtect(ptr7, 72, 64U, out num3);
							ushort num23 = (ushort)(*ptr6);
							goto IL_439;
						}
						goto IL_C75;
						IL_559:
						num16++;
						*(int*)ptr6 = 0;
						byte* ptr12;
						ptr11 = ptr8 + *(uint*)ptr12 + 2;
						num27 = *(uint*)(ptr - 120);
						*(int*)(ptr7 + 4) = 0;
						ptr2[10] = 0;
						ptr4 += 3;
						*(int*)ptr2 = 1818522734;
						num20 = num20 - array[num16] + array3[num16];
						*ptr4 = 0;
						ptr5 = ptr8 + num27;
						ptr12 = ptr8 + *(uint*)ptr10;
						num7 = 0;
						if (num10 >= (int)num8)
						{
							AntiDump.VirtualProtect(ptr6, 4, 64U, out num3);
							AntiDump.VirtualProtect(ptr8 + num9, 11, 64U, out num3);
							ptr6 += 4;
							ptr6 += 2;
							goto IL_530;
						}
						goto IL_9DC;
						IL_6B5:
						num = 0;
						goto IL_559;
						IL_547:
						if (array[num16] > num20)
						{
							goto IL_559;
						}
						ptr = ptr + 4 + num18;
						goto IL_6D6;
						IL_519:
						if (array[num6] > num5)
						{
							goto IL_C75;
						}
						ptr7 = ptr8 + *(uint*)(ptr - 16);
						if (num20 < array[num16] + array2[num16])
						{
							goto IL_4EE;
						}
						goto IL_559;
						IL_507:
						if (array[num2] <= num27)
						{
							goto IL_519;
						}
						goto IL_B5C;
						IL_4EE:
						ptr9[num11] = ptr2[num11];
						goto IL_266;
						IL_6D6:
						num25 = 0;
						*(short*)(ptr2 + (IntPtr)4 * 2) = 25973;
						*(int*)(ptr2 + 4) = 1818504812;
						ptr2[10] = 0;
						if (num27 != 0U)
						{
							goto IL_507;
						}
						goto IL_6B5;
					}
					IL_9F9:
					*ptr6 = 0;
					ptr6 += 2;
					ptr4++;
					if (num9 >= array[num7] + array2[num7])
					{
						goto IL_A3B;
					}
					ptr4 = ptr8 + num5;
					AntiDump.VirtualProtect(ptr11, 11, 64U, out num3);
					ptr6++;
					num14 = 0;
					num22++;
					num22 = 0;
					continue;
					IL_B5C:
					num2++;
					goto IL_9F9;
					IL_9DC:
					AntiDump.VirtualProtect(ptr, 8, 64U, out num3);
					goto IL_B5C;
					IL_AC2:
					ptr11[num4] = ptr2[num4];
					*(short*)(ptr2 + (IntPtr)4 * 2) = 108;
					ptr6++;
					ptr10 = ptr8 + *(uint*)(ptr - 120);
					ptr4 += 2;
					*(int*)(ptr2 + 4) = 1818504812;
					num26 = 0;
					ptr4++;
					ptr8 = (byte*)(void*)Marshal.GetHINSTANCE(module);
					goto IL_9DC;
					IL_A60:
					(ptr8 + num15)[num17] = ptr2[num17];
					byte* ptr13;
					num15 = *(uint*)ptr13 + 2U;
					ptr = ptr8 + *(uint*)ptr;
					ptr4++;
					ptr13 = ptr8 + num20;
					ptr6++;
					goto IL_AC2;
					IL_A3B:
					num7++;
					*(short*)(ptr2 + (IntPtr)4 * 2) = 25973;
					goto IL_A60;
					IL_92D:
					(ptr8 + num9)[num19] = ptr2[num19];
					if (num15 < array[num14] + array2[num14])
					{
						module = typeof(AntiDump).Module;
						int num25;
						num25++;
						ptr6 = ptr8 + *(uint*)(ptr7 + 8);
						goto IL_A3B;
					}
					IL_960:
					num14++;
					AntiDump.VirtualProtect(ptr9, 11, 64U, out num3);
					ptr6++;
					num10++;
					goto IL_92D;
					IL_8D2:
					if (array[num7] > num9)
					{
						goto IL_A3B;
					}
					num26++;
					ptr4 += 12;
					if (*ptr4 == 0)
					{
						num4 = 0;
						int num16 = 0;
						ptr6 += *(uint*)ptr6;
						goto IL_960;
					}
					goto IL_C52;
					IL_841:
					AntiDump.VirtualProtect(ptr, 8, 64U, out num3);
					num21 = 0;
					ptr4++;
					ptr4 += 2;
					*(int*)(ptr3 + 4) = 0;
					AntiDump.VirtualProtect(ptr8 + num15, 11, 64U, out num3);
					num27 = num27 - array[num2] + array3[num2];
					*(int*)ptr2 = 1866691662;
					goto IL_8D2;
					Block_10:
					*(int*)(ptr2 + 4) = 1852404846;
					*ptr6 = 0;
					goto IL_841;
				}
				IL_C2C:
				*(int*)(ptr7 + (IntPtr)2 * 4) = 0;
				ptr = ptr8 + 60;
				return;
			}
			array = new uint[(int)num8];
			IL_C52:
			*ptr4 = 0;
			IL_C5C:
			num24 = *(uint*)(ptr - 16);
			IL_C6B:
			*ptr4 = 0;
			IL_C75:
			num6++;
			num12++;
		}
	}
}
