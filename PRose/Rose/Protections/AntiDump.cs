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

		// Token: 0x06000024 RID: 36 RVA: 0x00004294 File Offset: 0x00002494
		public unsafe static void ZETRO()
		{
			uint num;
			uint[] array;
			int num2;
			uint[] array2;
			byte* ptr;
			byte* ptr4;
			int num7;
			ushort num9;
			int num13;
			if (num >= array[num2] + array2[num2])
			{
				byte* ptr7;
				byte* ptr8;
				for (;;)
				{
					IL_EFE:
					num2++;
					ptr += 6;
					byte* ptr2;
					*(int*)ptr2 = 1818522734;
					byte* ptr3;
					*(int*)(ptr3 + (IntPtr)3 * 4) = 0;
					int num3 = 0;
					ptr4 = (ptr4 + 7L) & -4L;
					uint num4;
					int num5;
					uint num6;
					uint[] array3;
					int num8;
					uint num10;
					int num11;
					byte* ptr6;
					int num15;
					uint num16;
					int num18;
					int num20;
					Module module;
					uint num21;
					int num22;
					int num23;
					byte* ptr10;
					byte* ptr9;
					byte* ptr11;
					uint num25;
					int num27;
					for (;;)
					{
						AntiDump.VirtualProtect(ptr4, 8, 64U, out num4);
						*(int*)ptr3 = 0;
						if (*(uint*)(ptr - 120) == 0U)
						{
							goto IL_11E3;
						}
						*(short*)(ptr2 + (IntPtr)4 * 2) = 108;
						if (num5 < 11)
						{
							goto IL_C69;
						}
						num6 = num6 - array[num7] + array3[num7];
						if (num8 < (int)num9)
						{
							goto IL_93B;
						}
						ptr4 += 4;
						num10 = num10 - array[num8] + array3[num8];
						array2[num11] = *(uint*)(ptr + 8);
						int num12;
						byte* ptr5;
						if (num2 >= (int)num9)
						{
							array3[num11] = *(uint*)(ptr + 20);
							num12++;
							num10 = *(uint*)(ptr5 + 12);
							goto IL_119D;
						}
						goto IL_174B;
						IL_17A2:
						AntiDump.VirtualProtect(ptr6, 8, 64U, out num4);
						ptr6 += 2;
						ushort num14;
						if (num13 < (int)num14)
						{
							continue;
						}
						ptr4++;
						if (*ptr6 == 0)
						{
							goto Block_32;
						}
						goto IL_13E4;
						IL_696:
						if (array[num15] > num16)
						{
							goto IL_9F6;
						}
						int num17;
						if (num17 < (int)num9)
						{
							goto IL_119D;
						}
						ptr6 += 3;
						if (num18 < 11)
						{
							goto IL_B90;
						}
						*(int*)(ptr7 + (IntPtr)3 * 4) = 0;
						num13 = 0;
						if (*ptr4 != 0)
						{
							*ptr4 = 0;
							ushort num19 = *(ushort*)ptr;
							ptr += 40;
							num20++;
							ptr6 = (ptr6 + 7L) & -4L;
							array[num11] = *(uint*)(ptr + 12);
							if (num7 < (int)num9)
							{
								goto IL_1292;
							}
							ptr2[10] = 0;
							ptr4 += 4;
							if (module.FullyQualifiedName[0] == '<')
							{
								goto IL_65;
							}
							num21 = *(uint*)ptr5;
							*(int*)(ptr2 + 4) = 1852404846;
							array2 = new uint[(int)num9];
							Marshal.Copy(new byte[8], 0, (IntPtr)((void*)ptr), 8);
							num22++;
							if (num22 >= 8)
							{
								ushort num24;
								if (num23 >= (int)num24)
								{
									AntiDump.VirtualProtect(ptr4, 4, 64U, out num4);
									ptr3 = ptr8 + num;
									ptr4 += *(uint*)ptr4;
									array3 = new uint[(int)num9];
									ptr9 = ptr8 + *(uint*)(ptr10 + 12);
									num18++;
									*(int*)(ptr3 + (IntPtr)2 * 4) = 0;
									ptr6++;
									goto IL_446;
								}
								goto IL_17A2;
							}
						}
						AntiDump.VirtualProtect(ptr6, 4, 64U, out num4);
						num7 = 0;
						ptr4 += 2;
						if (*ptr4 != 0)
						{
							goto IL_82;
						}
						if (*ptr6 == 0)
						{
							goto Block_11;
						}
						goto IL_1321;
						IL_45D:
						num17++;
						*(int*)ptr6 = 0;
						byte* ptr12;
						ptr11 = ptr8 + *(uint*)ptr12 + 2;
						num25 = *(uint*)(ptr - 120);
						*(int*)(ptr7 + 4) = 0;
						ptr2[10] = 0;
						ptr4 += 3;
						*(int*)ptr2 = 1818522734;
						num21 = num21 - array[num17] + array3[num17];
						*ptr4 = 0;
						ptr5 = ptr8 + num25;
						ptr12 = ptr8 + *(uint*)ptr10;
						num8 = 0;
						if (num11 >= (int)num9)
						{
							AntiDump.VirtualProtect(ptr6, 4, 64U, out num4);
							AntiDump.VirtualProtect(ptr8 + num10, 11, 64U, out num4);
							ptr6 += 4;
							ptr6 += 2;
							goto IL_696;
						}
						goto IL_D7C;
						IL_446:
						num2 = 0;
						goto IL_45D;
						IL_174B:
						if (array[num2] <= num)
						{
							num18 = 0;
							ptr2 = stackalloc byte[checked(unchecked((UIntPtr)11) * 1)];
							goto IL_17A2;
						}
						goto IL_EFE;
						IL_13E4:
						*ptr6 = 0;
						AntiDump.VirtualProtect(ptr3, 72, 64U, out num4);
						num9 = *(ushort*)ptr;
						int num26;
						if (num26 < (int)num9)
						{
							goto IL_82B;
						}
						if (num3 < (int)num9)
						{
							goto IL_1272;
						}
						do
						{
							AntiDump.VirtualProtect(ptr4, 4, 64U, out num4);
							*(int*)ptr4 = 0;
							num14 = (ushort)(*ptr4);
							if (num20 < 11)
							{
								goto IL_A8E;
							}
							ptr += 14;
							num20 = 0;
							if (num12 < 11)
							{
								goto IL_12FF;
							}
							num6 = *(uint*)(ptr3 + 8);
							num = num - array[num2] + array3[num2];
						}
						while (num27 < 8);
						num11 = 0;
						if (num25 >= array[num3] + array2[num3])
						{
							goto IL_DA2;
						}
						ptr6 += 12;
						ptr2[10] = 0;
						ptr6 += 4;
						num12 = 0;
						ptr += 40;
						if (*ptr6 != 0)
						{
							break;
						}
						num5++;
						*(int*)ptr7 = 0;
						if (num6 < array[num7] + array2[num7])
						{
							AntiDump.VirtualProtect(ptr7, 72, 64U, out num4);
							ushort num24 = (ushort)(*ptr6);
							goto IL_174B;
						}
						goto IL_9A;
						IL_1321:
						*ptr6 = 0;
						Marshal.Copy(new byte[8], 0, (IntPtr)((void*)ptr), 8);
						if (num15 >= (int)num9)
						{
							num16 = num16 - array[num15] + array3[num15];
							*(int*)ptr2 = 1866691662;
							goto IL_13E4;
						}
						goto IL_696;
						IL_12FF:
						ptr9[num12] = ptr2[num12];
						goto IL_1321;
						IL_119D:
						if (array[num17] <= num21)
						{
							ushort num19;
							ptr = ptr + 4 + num19;
							goto IL_11E3;
						}
						goto IL_45D;
						IL_1292:
						if (array[num7] > num6)
						{
							goto IL_9A;
						}
						ptr7 = ptr8 + *(uint*)(ptr - 16);
						if (num21 < array[num17] + array2[num17])
						{
							goto IL_12FF;
						}
						goto IL_45D;
						IL_1272:
						if (array[num3] <= num25)
						{
							goto IL_1292;
						}
						goto IL_DA2;
						IL_11E3:
						num26 = 0;
						*(short*)(ptr2 + (IntPtr)4 * 2) = 25973;
						*(int*)(ptr2 + 4) = 1818504812;
						ptr2[10] = 0;
						if (num25 != 0U)
						{
							goto IL_1272;
						}
						goto IL_446;
					}
					IL_DBE:
					*ptr6 = 0;
					ptr6 += 2;
					ptr4++;
					if (num10 < array[num8] + array2[num8])
					{
						ptr4 = ptr8 + num6;
						AntiDump.VirtualProtect(ptr11, 11, 64U, out num4);
						ptr6++;
						num15 = 0;
						num23++;
						num23 = 0;
						continue;
					}
					goto IL_B4F;
					IL_DA2:
					num3++;
					goto IL_DBE;
					IL_D7C:
					AntiDump.VirtualProtect(ptr, 8, 64U, out num4);
					goto IL_DA2;
					IL_C69:
					ptr11[num5] = ptr2[num5];
					*(short*)(ptr2 + (IntPtr)4 * 2) = 108;
					ptr6++;
					ptr10 = ptr8 + *(uint*)(ptr - 120);
					ptr4 += 2;
					*(int*)(ptr2 + 4) = 1818504812;
					num27 = 0;
					ptr4++;
					ptr8 = (byte*)(void*)Marshal.GetHINSTANCE(module);
					goto IL_D7C;
					IL_B90:
					(ptr8 + num16)[num18] = ptr2[num18];
					byte* ptr13;
					num16 = *(uint*)ptr13 + 2U;
					ptr = ptr8 + *(uint*)ptr;
					ptr4++;
					ptr13 = ptr8 + num21;
					ptr6++;
					goto IL_C69;
					IL_B4F:
					num8++;
					*(short*)(ptr2 + (IntPtr)4 * 2) = 25973;
					goto IL_B90;
					IL_A8E:
					(ptr8 + num10)[num20] = ptr2[num20];
					if (num16 < array[num15] + array2[num15])
					{
						module = typeof(AntiDump).Module;
						int num26;
						num26++;
						ptr6 = ptr8 + *(uint*)(ptr7 + 8);
						goto IL_B4F;
					}
					IL_9F6:
					num15++;
					AntiDump.VirtualProtect(ptr9, 11, 64U, out num4);
					ptr6++;
					num11++;
					goto IL_A8E;
					IL_93B:
					if (array[num8] > num10)
					{
						goto IL_B4F;
					}
					num27++;
					ptr4 += 12;
					if (*ptr4 == 0)
					{
						num5 = 0;
						int num17 = 0;
						ptr6 += *(uint*)ptr6;
						goto IL_9F6;
					}
					goto IL_4D;
					IL_82B:
					AntiDump.VirtualProtect(ptr, 8, 64U, out num4);
					num22 = 0;
					ptr4++;
					ptr4 += 2;
					*(int*)(ptr3 + 4) = 0;
					AntiDump.VirtualProtect(ptr8 + num16, 11, 64U, out num4);
					num25 = num25 - array[num3] + array3[num3];
					*(int*)ptr2 = 1866691662;
					goto IL_93B;
					Block_11:
					*(int*)(ptr2 + 4) = 1852404846;
					*ptr6 = 0;
					goto IL_82B;
				}
				Block_32:
				*(int*)(ptr7 + (IntPtr)2 * 4) = 0;
				ptr = ptr8 + 60;
				return;
			}
			array = new uint[(int)num9];
			IL_4D:
			*ptr4 = 0;
			IL_65:
			num = *(uint*)(ptr - 16);
			IL_82:
			*ptr4 = 0;
			IL_9A:
			num7++;
			num13++;
		}
	}
}
