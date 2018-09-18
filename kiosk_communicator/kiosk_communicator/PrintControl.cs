using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System.Runtime.CompilerServices;
using System.Printing;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using ds_rx1_print_library;

namespace kiosk_communicator
{
    class PrintControl
    {
        private static string sPrinterName;
        private static string PortName;
        private static int PortNum;

        public delegate void MessageDisplayHandler(string text);
        public event MessageDisplayHandler messageReceived;

        public static string PrinterName
        {
            get
            {
                return sPrinterName;
            }
            set
            {
                sPrinterName = value;
                PortName = GetCvPort.GetPortName(ref sPrinterName);
            }
        }

        public static int PortNumber
        {
            get
            {
                return PortNum;
            }
            set
            {
                PortNum = value;
            }
        }

        public PrintControl()
        {
            CwdInfo.SetVersionCheckInfo();
            CyStat.PrgEnv = CyStat.CheckEnvironment() != 32 ? (object)new ClassForEnvironment64() : (object)new ClassForEnvironment32();
            initialSetting();
        }

        private static void initialSetting()
        {
            GetCvPort.PrinterNum = (short)0;

            try
            {
                foreach (object installedPrinter in PrinterSettings.InstalledPrinters)
                {
                    string strPrinterDeviceName = Conversions.ToString(installedPrinter);
                    string port = GetCvPort.GetPortName(ref strPrinterDeviceName);
                    string command;

                    if (Operators.CompareString(port, "", false) != 0)
                    {
                        object prgEnv1 = CyStat.PrgEnv;
                        System.Type local1 = null;
                        command = "CvInitialize";
                        object[] objArray1 = new object[1]
                        {
                            (object) port
                        };
                        object[] Arguments1 = objArray1;
                        // ISSUE: variable of the null type
                        string[] local2 = null;
                        // ISSUE: variable of the null type
                        System.Type[] local3 = null;
                        bool[] flagArray1 = new bool[1] { true };
                        bool[] CopyBack1 = flagArray1;
                        object obj = NewLateBinding.LateGet(prgEnv1, (System.Type)local1, command, Arguments1, (string[])local2, (System.Type[])local3, CopyBack1);
                        if (flagArray1[0])
                            port = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray1[0]), typeof(string));
                        int num1 = Conversions.ToInteger(obj);

                        object prgEnv2 = CyStat.PrgEnv;
                        // ISSUE: variable of the null type
                        System.Type local4 = null;
                        command = "CvGetStatus";
                        object[] objArray2 = new object[1]
                        {
                                 (object) num1
                        };
                        object[] Arguments2 = objArray2;
                        // ISSUE: variable of the null type
                        string[] local5 = null;
                        // ISSUE: variable of the null type
                        System.Type[] local6 = null;
                        bool[] flagArray2 = new bool[1] { true };
                        bool[] CopyBack2 = flagArray2;
                        object Left2 = NewLateBinding.LateGet(prgEnv2, (System.Type)local4, command, Arguments2, (string[])local5, (System.Type[])local6, CopyBack2);
                        if (flagArray2[0])
                            num1 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray2[0]), typeof(int));
                        // ISSUE: variable of a boxed type

                        PrinterName = strPrinterDeviceName;
                        PortName = port;
                        PortNumber = num1;
                    }
                }
            }
            catch (Exception ex)
            {
                LogClass log = new LogClass();
                string[] lines = { DateTime.Now.ToString(), "Function Name : " + System.Reflection.MethodBase.GetCurrentMethod().Name, ex.ToString() };
                log.writeLog(lines);
            }
        }

        public static int setPresentStatus()
        {
            object prgEnv = CyStat.PrgEnv;
            // ISSUE: variable of the null type
            System.Type local1 = null;
            string MemberName = "CvGetStatus";
            object[] objArray = new object[1]
            {
                (object) PortNum
            };
            object[] Arguments = objArray;
            // ISSUE: variable of the null type
            string[] local2 = null;
            // ISSUE: variable of the null type
            System.Type[] local3 = null;
            bool[] flagArray = new bool[1] { true };
            bool[] CopyBack = flagArray;
            int integer = -1;

            try
            {
                object obj = NewLateBinding.LateGet(prgEnv, (System.Type)local1, MemberName, Arguments, (string[])local2, (System.Type[])local3, CopyBack);
                if (flagArray[0])
                {
                    PortNum = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(int));
                }
                    
                integer = Conversions.ToInteger(obj);
            }
            catch(Exception ex)
            {
                LogClass log = new LogClass();
                string[] lines = { DateTime.Now.ToString(), "Function Name : " + System.Reflection.MethodBase.GetCurrentMethod().Name, ex.ToString() };
                log.writeLog(lines);
            }
            
            return integer;
        }

        public static string GetInformation()
        {
            string str = new string(char.MinValue, (int)byte.MaxValue);
            string strSize = "", strTot = "", strPrinted = "";

            object prgEnv1 = CyStat.PrgEnv;
            // ISSUE: variable of the null type
            System.Type local1 = null;
            string MemberName1 = "GetCounterL";
            object[] objArray1 = new object[1]
            {
                (object) PortNumber
            };
            object[] Arguments1 = objArray1;
            // ISSUE: variable of the null type
            string[] local2 = null;
            // ISSUE: variable of the null type
            System.Type[] local3 = null;
            bool[] flagArray1 = new bool[1] { true };
            bool[] CopyBack1 = flagArray1;
            object obj1 = NewLateBinding.LateGet(prgEnv1, (System.Type)local1, MemberName1, Arguments1, (string[])local2, (System.Type[])local3, CopyBack1);
            if (flagArray1[0])
                PortNum = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray1[0]), typeof(int));
            int integer1 = Conversions.ToInteger(obj1);
            strTot = integer1 < 0 ? "" : Convert.ToString((object)integer1);
            object prgEnv2 = CyStat.PrgEnv;
            // ISSUE: variable of the null type
            System.Type local4 = null;
            string MemberName2 = "GetMedia";
            object[] objArray2 = new object[2]
            {
              (object) PortNum,
              (object) str
            };
            object[] Arguments2 = objArray2;
            // ISSUE: variable of the null type
            string[] local5 = null;
            // ISSUE: variable of the null type
            System.Type[] local6 = null;
            bool[] flagArray2 = new bool[2] { true, true };
            bool[] CopyBack2 = flagArray2;
            object obj2 = NewLateBinding.LateGet(prgEnv2, (System.Type)local4, MemberName2, Arguments2, (string[])local5, (System.Type[])local6, CopyBack2);
            if (flagArray2[0])
                PortNum = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray2[0]), typeof(int));
            if (flagArray2[1])
                str = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray2[1]), typeof(string));
            int m = 0;
            if (Conversions.ToInteger(obj2) >= 0)
            {
                m = checked((int)Math.Round(Conversion.Val(str.Substring(2, 3))));
                strSize = GetMediaName(m);
            }
            else
                strSize = "";
            if ((m >= 200) & (m <= 510))
            {
                object prgEnv3 = CyStat.PrgEnv;
                // ISSUE: variable of the null type
                System.Type local7 = null;
                string MemberName3 = "GetMediaCountOffset";
                object[] objArray3 = new object[1]
                {
                        (object) PortNum
                };
                object[] Arguments3 = objArray3;
                // ISSUE: variable of the null type
                string[] local8 = null;
                // ISSUE: variable of the null type
                System.Type[] local9 = null;
                bool[] flagArray3 = new bool[1] { true };
                bool[] CopyBack3 = flagArray3;
                object obj3 = NewLateBinding.LateGet(prgEnv3, (System.Type)local7, MemberName3, Arguments3, (string[])local8, (System.Type[])local9, CopyBack3);
                if (flagArray3[0])
                    PortNum = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray3[0]), typeof(int));
                int num = Conversions.ToInteger(obj3);
                if (num <= -1)
                    num = 50;
                object prgEnv4 = CyStat.PrgEnv;
                // ISSUE: variable of the null type
                System.Type local10 = null;
                string MemberName4 = "GetMediaCounter";
                object[] objArray4 = new object[1]
                {
                        (object) PortNum
                };
                object[] Arguments4 = objArray4;
                // ISSUE: variable of the null type
                string[] local11 = null;
                // ISSUE: variable of the null type
                System.Type[] local12 = null;
                bool[] flagArray4 = new bool[1] { true };
                bool[] CopyBack4 = flagArray4;
                object obj4 = NewLateBinding.LateGet(prgEnv4, (System.Type)local10, MemberName4, Arguments4, (string[])local11, (System.Type[])local12, CopyBack4);
                if (flagArray4[0])
                    PortNum = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray4[0]), typeof(int));
                int integer2 = Conversions.ToInteger(obj4);
                strPrinted = integer2 < 0 ? "" : Convert.ToString((object)(integer2 < num ? 0 : checked(integer2 - num)));

                object prgEnv5 = CyStat.PrgEnv;
                // ISSUE: variable of the null type
                System.Type local13 = null;
                string MemberName5 = "GetInitialMediaCount";
                object[] objArray5 = new object[1]
                {
                        (object) PortNum
                };
                object[] Arguments5 = objArray5;
                // ISSUE: variable of the null type
                string[] local14 = null;
                // ISSUE: variable of the null type
                System.Type[] local15 = null;
                bool[] flagArray5 = new bool[1] { true };
                bool[] CopyBack5 = flagArray5;
                object obj5 = NewLateBinding.LateGet(prgEnv5, (System.Type)local13, MemberName5, Arguments5, (string[])local14, (System.Type[])local15, CopyBack5);
                if (flagArray5[0])
                    PortNum = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray5[0]), typeof(int));
                int integer3 = Conversions.ToInteger(obj5);
                strTot = integer3 < num ? "---" : Conversion.Str((object)checked(integer3 - num));
            }
            else
            {
                strSize = "";
                strTot = "";
            }

            return strSize + "," + strTot + "," + strPrinted;
        }

        private static string GetMediaName(int m)
        {
            string str;
            switch (m)
            {
                case 0:
                    str = "---";
                    break;
                case 200:
                    str = "5x3.5";
                    break;
                case 210:
                    str = "5x7";
                    break;
                case 301:
                    str = "6x4";
                    break;
                case 310:
                    str = "6x8";
                    break;
                case 400:
                    str = "6x9";
                    break;
                case 500:
                    str = "8x10";
                    break;
                case 510:
                    str = "8x12";
                    break;
                default:
                    str = "---";
                    break;
            }
            return str;
        }
    }
}
