using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace ds_rx1_print_library
{
    [StandardModule]
    public class CyStat
    {
        public const int GROUP_USUALLY = 65536;
        public const int GROUP_SETTING = 131072;
        public const int GROUP_HARDWARE = 262144;
        public const int GROUP_SYSTEM = 524288;
        public const int GROUP_FLSHPROG = 1048576;
        public const int STATUS_ERROR = -2147483648;
        public const int STATUS_USUALLY_IDLE = 65537;
        public const int STATUS_USUALLY_PRINTING = 65538;
        public const int STATUS_USUALLY_STANDSTILL = 65540;
        public const int STATUS_USUALLY_PAPER_END = 65544;
        public const int STATUS_USUALLY_RIBBON_END = 65552;
        public const int STATUS_USUALLY_COOLING = 65568;
        public const int STATUS_USUALLY_MOTCOOLING = 65600;
        public const int STATUS_SETTING_COVER_OPEN = 131073;
        public const int STATUS_SETTING_PAPER_JAM = 131074;
        public const int STATUS_SETTING_RIBBON_ERR = 131076;
        public const int STATUS_SETTING_PAPER_ERR = 131080;
        public const int STATUS_SETTING_DATA_ERR = 131088;
        public const int STATUS_SETTING_SCRAPBOX_ERR = 131104;
        public const int STATUS_HARDWARE_ERR01 = 262145;
        public const int STATUS_HARDWARE_ERR02 = 262146;
        public const int STATUS_HARDWARE_ERR03 = 262148;
        public const int STATUS_HARDWARE_ERR04 = 262152;
        public const int STATUS_HARDWARE_ERR05 = 262160;
        public const int STATUS_HARDWARE_ERR06 = 262176;
        public const int STATUS_HARDWARE_ERR07 = 262208;
        public const int STATUS_HARDWARE_ERR08 = 262272;
        public const int STATUS_HARDWARE_ERR09 = 262400;
        public const int STATUS_HARDWARE_ERR10 = 262656;
        public const int STATUS_SYSTEM_ERR01 = 524289;
        public const int STATUS_FLSHPROG_IDLE = 1048577;
        public const int STATUS_FLSHPROG_WRITING = 1048578;
        public const int STATUS_FLSHPROG_FINISHED = 1048580;
        public const int STATUS_FLSHPROG_DATA_ERR1 = 1048584;
        public const int STATUS_FLSHPROG_DEVICE_ERR1 = 1048592;
        public const int STATUS_FLSHPROG_OTHERS_ERR1 = 1048608;
        public const int CVG_USUALLY = 65536;
        public const int CVG_SETTING = 131072;
        public const int CVG_HARDWARE = 262144;
        public const int CVG_SYSTEM = 524288;
        public const int CVG_FLSHPROG = 1048576;
        public const int CVSTATUS_ERROR = -2147483648;
        public const int CVS_USUALLY_IDLE = 65537;
        public const int CVS_USUALLY_PRINTING = 65538;
        public const int CVS_USUALLY_STANDSTILL = 65540;
        public const int CVS_USUALLY_PAPER_END = 65544;
        public const int CVS_USUALLY_RIBBON_END = 65552;
        public const int CVS_USUALLY_COOLING = 65568;
        public const int CVS_USUALLY_MOTCOOLING = 65600;
        public const int CVS_SETTING_COVER_OPEN = 131073;
        public const int CVS_SETTING_PAPER_JAM = 131074;
        public const int CVS_SETTING_RIBBON_ERR = 131076;
        public const int CVS_SETTING_PAPER_ERR = 131080;
        public const int CVS_SETTING_DATA_ERR = 131088;
        public const int CVS_SETTING_SCRAP_ERR = 131104;
        public const int CVS_HARDWARE_ERR01 = 262145;
        public const int CVS_HARDWARE_ERR02 = 262146;
        public const int CVS_HARDWARE_ERR03 = 262148;
        public const int CVS_HARDWARE_ERR04 = 262152;
        public const int CVS_HARDWARE_ERR05 = 262160;
        public const int CVS_HARDWARE_ERR06 = 262176;
        public const int CVS_HARDWARE_ERR07 = 262208;
        public const int CVS_HARDWARE_ERR08 = 262272;
        public const int CVS_HARDWARE_ERR09 = 262400;
        public const int CVS_HARDWARE_ERR10 = 262656;
        public const int CVS_SYSTEM_ERR01 = 524289;
        public const int CVS_FLSHPROG_IDLE = 1048577;
        public const int CVS_FLSHPROG_WRITING = 1048578;
        public const int CVS_FLSHPROG_FINISHED = 1048580;
        public const int CVS_FLSHPROG_DATA_ERR1 = 1048584;
        public const int CVS_FLSHPROG_DEVICE_ERR1 = 1048592;
        public const int CVS_FLSHPROG_OTHERS_ERR1 = 1048608;
        public const short CUTTER_MODE_STANDARD = 0;
        public const short CUTTER_MODE_NONSCRAP = 1;
        public const short CWD_300DPI = 0;
        public const short CWD_600DPI = 1;
        public const int RIBBON_NUM_OFFSET = 50;
        public static object PrgEnv;
        public static int OS_Version;
        public const int OSV_NotCompatible = 0;
        public const int OSV_Vista = 6;
        public const int OSV_Win10 = 10;

        [DebuggerNonUserCode]
        static CyStat()
        {
        }

        public static int CheckEnvironment()
        {
            OperatingSystem osVersion = Environment.OSVersion;
            CyStat.OS_Version = osVersion.Platform != PlatformID.Win32NT ? 0 : osVersion.Version.Major;
            return IntPtr.Size == 4 ? 32 : 64;
        }

        public static int SetCommand(int lPortNum, string Cmd, int dwCmdLen)
        {
            GCHandle gcHandle = GCHandle.Alloc((object)Encoding.GetEncoding(65001).GetBytes(Cmd), GCHandleType.Pinned);
            int int32 = gcHandle.AddrOfPinnedObject().ToInt32();
            object prgEnv = CyStat.PrgEnv;
            // ISSUE: variable of the null type
            Type local1 = null;
            string MemberName = "SetCommand_";
            object[] objArray = new object[3]
            {
                (object) lPortNum,
                (object) int32,
                (object) dwCmdLen
            };
            object[] Arguments = objArray;
            // ISSUE: variable of the null type
            string[] local2 = null;
            // ISSUE: variable of the null type
            Type[] local3 = null;
            bool[] flagArray = new bool[3] { true, true, true };
            bool[] CopyBack = flagArray;
            object obj = NewLateBinding.LateGet(prgEnv, (Type)local1, MemberName, Arguments, (string[])local2, (Type[])local3, CopyBack);
            if (flagArray[0])
                lPortNum = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(int));
            if (flagArray[1])
            {
                int num = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[1]), typeof(int));
            }
            if (flagArray[2])
                dwCmdLen = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[2]), typeof(int));
            int integer = Conversions.ToInteger(obj);
            gcHandle.Free();
            return integer;
        }

        public static int GetCommand(int lPortNum, string Cmd, int dwCmdLen, ref string rb, int dwRetBuffSize, ref int dwRetLen)
        {
            GCHandle gcHandle1 = GCHandle.Alloc((object)Encoding.GetEncoding(65001).GetBytes(Cmd), GCHandleType.Pinned);
            GCHandle gcHandle2 = GCHandle.Alloc((object)dwRetLen, GCHandleType.Pinned);
            int int32_1 = gcHandle1.AddrOfPinnedObject().ToInt32();
            int int32_2 = gcHandle1.AddrOfPinnedObject().ToInt32();
            object prgEnv = CyStat.PrgEnv;
            // ISSUE: variable of the null type
            Type local1 = null;
            string MemberName = "GetCommand_";
            object[] objArray = new object[6]
            {
                (object) lPortNum,
                (object) int32_1,
                (object) dwCmdLen,
                (object) rb,
                (object) dwRetBuffSize,
                (object) int32_2
            };
            object[] Arguments = objArray;
            // ISSUE: variable of the null type
            string[] local2 = null;
            // ISSUE: variable of the null type
            Type[] local3 = null;
            bool[] flagArray = new bool[6]
            {
                true,
                true,
                true,
                true,
                true,
                true
            };
            bool[] CopyBack = flagArray;
            object obj = NewLateBinding.LateGet(prgEnv, (Type)local1, MemberName, Arguments, (string[])local2, (Type[])local3, CopyBack);
            if (flagArray[0])
                lPortNum = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(int));
            if (flagArray[1])
            {
                int num1 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[1]), typeof(int));
            }
            if (flagArray[2])
                dwCmdLen = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[2]), typeof(int));
            if (flagArray[3])
                rb = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[3]), typeof(string));
            if (flagArray[4])
                dwRetBuffSize = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[4]), typeof(int));
            if (flagArray[5])
            {
                int num2 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[5]), typeof(int));
            }
            int integer = Conversions.ToInteger(obj);
            gcHandle1.Free();
            gcHandle2.Free();
            return integer;
        }

        public static int GetCommandEX(int lPortNum, string Cmd, int dwCmdLen, ref string rb, int dwRetBuffSize)
        {
            GCHandle gcHandle = GCHandle.Alloc((object)Encoding.GetEncoding(65001).GetBytes(Cmd), GCHandleType.Pinned);
            int int32 = gcHandle.AddrOfPinnedObject().ToInt32();
            object prgEnv = CyStat.PrgEnv;
            // ISSUE: variable of the null type
            Type local1 = null;
            string MemberName = "GetCommandEX_";
            object[] objArray = new object[5]
            {
                (object) lPortNum,
                (object) int32,
                (object) dwCmdLen,
                (object) rb,
                (object) dwRetBuffSize
            };
            object[] Arguments = objArray;
            // ISSUE: variable of the null type
            string[] local2 = null;
            // ISSUE: variable of the null type
            Type[] local3 = null;
            bool[] flagArray = new bool[5]
            {
                true,
                true,
                true,
                true,
                true
            };
            bool[] CopyBack = flagArray;
            object obj = NewLateBinding.LateGet(prgEnv, (Type)local1, MemberName, Arguments, (string[])local2, (Type[])local3, CopyBack);
            if (flagArray[0])
                lPortNum = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(int));
            if (flagArray[1])
            {
                int num = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[1]), typeof(int));
            }
            if (flagArray[2])
                dwCmdLen = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[2]), typeof(int));
            if (flagArray[3])
                rb = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[3]), typeof(string));
            if (flagArray[4])
                dwRetBuffSize = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[4]), typeof(int));
            int integer = Conversions.ToInteger(obj);
            gcHandle.Free();
            return integer;
        }

        public static int SetFirmwDataWrite(int lPortNum, byte[] ByteArray, int dwLen)
        {
            GCHandle gcHandle = GCHandle.Alloc((object)ByteArray, GCHandleType.Pinned);
            int int32 = gcHandle.AddrOfPinnedObject().ToInt32();
            object prgEnv = CyStat.PrgEnv;
            // ISSUE: variable of the null type
            Type local1 = null;
            string MemberName = "SetFirmwDataWrite_";
            object[] objArray = new object[3]
            {
                (object) lPortNum,
                (object) int32,
                (object) dwLen
            };
            object[] Arguments = objArray;
            // ISSUE: variable of the null type
            string[] local2 = null;
            // ISSUE: variable of the null type
            Type[] local3 = null;
            bool[] flagArray = new bool[3] { true, true, true };
            bool[] CopyBack = flagArray;
            object obj = NewLateBinding.LateGet(prgEnv, (Type)local1, MemberName, Arguments, (string[])local2, (Type[])local3, CopyBack);
            if (flagArray[0])
                lPortNum = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(int));
            if (flagArray[1])
            {
                int num = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[1]), typeof(int));
            }
            if (flagArray[2])
                dwLen = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[2]), typeof(int));
            int integer = Conversions.ToInteger(obj);
            gcHandle.Free();
            return integer;
        }

        public static int SetColorDataVersion(int lPortNum, string Cmd, int dwCmdLen)
        {
            GCHandle gcHandle = GCHandle.Alloc((object)Encoding.GetEncoding(65001).GetBytes(Cmd), GCHandleType.Pinned);
            int int32 = gcHandle.AddrOfPinnedObject().ToInt32();
            object prgEnv = CyStat.PrgEnv;
            // ISSUE: variable of the null type
            Type local1 = null;
            string MemberName = "SetColorDataVersion_";
            object[] objArray = new object[3]
            {
                (object) lPortNum,
                (object) int32,
                (object) dwCmdLen
            };
            object[] Arguments = objArray;
            // ISSUE: variable of the null type
            string[] local2 = null;
            // ISSUE: variable of the null type
            Type[] local3 = null;
            bool[] flagArray = new bool[3] { true, true, true };
            bool[] CopyBack = flagArray;
            object obj = NewLateBinding.LateGet(prgEnv, (Type)local1, MemberName, Arguments, (string[])local2, (Type[])local3, CopyBack);
            if (flagArray[0])
                lPortNum = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(int));
            if (flagArray[1])
            {
                int num = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[1]), typeof(int));
            }
            if (flagArray[2])
                dwCmdLen = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[2]), typeof(int));
            int integer = Conversions.ToInteger(obj);
            gcHandle.Free();
            return integer;
        }

        public static int SetColorDataWrite(int lPortNum, byte[] ByteArray, int dwLen)
        {
            GCHandle gcHandle = GCHandle.Alloc((object)ByteArray, GCHandleType.Pinned);
            int int32 = gcHandle.AddrOfPinnedObject().ToInt32();
            object prgEnv = CyStat.PrgEnv;
            // ISSUE: variable of the null type
            Type local1 = null;
            string MemberName = "SetColorDataWrite_";
            object[] objArray = new object[3]
            {
                (object) lPortNum,
                (object) int32,
                (object) dwLen
            };
            object[] Arguments = objArray;
            // ISSUE: variable of the null type
            string[] local2 = null;
            // ISSUE: variable of the null type
            Type[] local3 = null;
            bool[] flagArray = new bool[3] { true, true, true };
            bool[] CopyBack = flagArray;
            object obj = NewLateBinding.LateGet(prgEnv, (Type)local1, MemberName, Arguments, (string[])local2, (Type[])local3, CopyBack);
            if (flagArray[0])
                lPortNum = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(int));
            if (flagArray[1])
            {
                int num = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[1]), typeof(int));
            }
            if (flagArray[2])
                dwLen = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[2]), typeof(int));
            int integer = Conversions.ToInteger(obj);
            gcHandle.Free();
            return integer;
        }
    }
}
