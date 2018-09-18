using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Runtime.CompilerServices;

namespace ds_rx1_print_library
{
    [StandardModule]
    public class CwdInfo
    {
        private static string rb = new string(char.MinValue, 512);
        private static CwdInfo.VERSION_CHECK_INFO[] VerChkInfo = new CwdInfo.VERSION_CHECK_INFO[2];
        private const short ESC = 27;
        private const short MODEL_N = 2;
        private const short MODEL_DSRX1 = 0;
        private const short MODEL_CY = 1;
        public const string MODEL_NAME = "DS-RX1";
        public const string SUB_MODEL_NAME = "CY";

        public static void SetVersionCheckInfo()
        {
            CwdInfo.VerChkInfo[0].RomModel = "DS-RX1";
            CwdInfo.VerChkInfo[0].RomModelDigit = (short)3;
            CwdInfo.VerChkInfo[0].RomVer = 1.0;
            CwdInfo.VerChkInfo[1].RomModel = "CY";
            CwdInfo.VerChkInfo[1].RomModelDigit = (short)2;
            CwdInfo.VerChkInfo[1].RomVer = 1.0;
        }

        public static string GetCwdVersion(int PortNum, short dpi)
        {
            string str1 = dpi != (short)300 ? "CWD600_Version" : "CWD300_Version";
            string str2 = "TBL_RD";
            ref string local1 = ref str2;
            ref string local2 = ref str1;
            int num = -1;
            ref int local3 = ref num;
            string Expression = CwdInfo.SetCommandStr(ref local1, ref local2, ref local3);
            object prgEnv = CyStat.PrgEnv;
            // ISSUE: variable of the null type
            Type local4 = null;
            string MemberName = "CvGetCommandEX_";
            object[] objArray = new object[5]
            {
        (object) PortNum,
        (object) Expression,
        (object) Strings.Len(Expression),
        (object) CwdInfo.rb,
        (object) 512
            };
            object[] Arguments = objArray;
            // ISSUE: variable of the null type
            string[] local5 = null;
            // ISSUE: variable of the null type
            Type[] local6 = null;
            bool[] flagArray = new bool[5]
            {
        true,
        true,
        false,
        true,
        false
            };
            bool[] CopyBack = flagArray;
            object obj = NewLateBinding.LateGet(prgEnv, (Type)local4, MemberName, Arguments, (string[])local5, (Type[])local6, CopyBack);
            if (flagArray[0])
                PortNum = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(int));
            if (flagArray[1])
            {
                string str3 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[1]), typeof(string));
            }
            if (flagArray[3])
                CwdInfo.rb = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[3]), typeof(string));
            int integer = Conversions.ToInteger(obj);
            return integer < 0 ? "" : CwdInfo.rb.Substring(0, integer).Trim();
        }

        public static string GetCwdCheckSum(int PortNum, short dpi)
        {
            string str1 = dpi != (short)300 ? "CWD600_Checksum" : "CWD300_Checksum";
            string str2 = "TBL_RD";
            ref string local1 = ref str2;
            ref string local2 = ref str1;
            int num1 = -1;
            ref int local3 = ref num1;
            string Expression = CwdInfo.SetCommandStr(ref local1, ref local2, ref local3);
            object prgEnv = CyStat.PrgEnv;
            // ISSUE: variable of the null type
            Type local4 = null;
            string MemberName = "CvGetCommandEX_";
            object[] objArray = new object[5]
            {
        (object) PortNum,
        (object) Expression,
        (object) Strings.Len(Expression),
        (object) CwdInfo.rb,
        (object) 512
            };
            object[] Arguments = objArray;
            // ISSUE: variable of the null type
            string[] local5 = null;
            // ISSUE: variable of the null type
            Type[] local6 = null;
            bool[] flagArray = new bool[5]
            {
        true,
        true,
        false,
        true,
        false
            };
            bool[] CopyBack = flagArray;
            object obj = NewLateBinding.LateGet(prgEnv, (Type)local4, MemberName, Arguments, (string[])local5, (Type[])local6, CopyBack);
            if (flagArray[0])
                PortNum = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(int));
            if (flagArray[1])
            {
                string str3 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[1]), typeof(string));
            }
            if (flagArray[3])
                CwdInfo.rb = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[3]), typeof(string));
            long num2 = Conversions.ToLong(obj);
            return num2 < 0L ? "" : CwdInfo.rb.Substring(0, checked((int)num2)).Trim();
        }

        public static bool CwdInfoCom_RomVerCheck(int PortNum)
        {
            return false;
        }

        public static string SetCommandStr(ref string s1, ref string s2, ref int ar)
        {
            string str = "\x001BP" + s1.PadRight(6, ' ') + s2.PadRight(16, ' ');
            return ar >= 0 ? str + Strings.Format((object)ar, "00000000") : str + Strings.Space(8);
        }

        public struct VERSION_CHECK_INFO
        {
            public string RomModel;
            public short RomModelDigit;
            public double RomVer;
        }
    }
}
