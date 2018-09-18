using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ds_rx1_print_library
{
    [StandardModule]
    public class pJob
    {
        private const int STANDARD_RIGHTS_REQUIRED = 983040;
        private const int PRINTER_ACCESS_ADMINISTER = 4;
        private const int PRINTER_ACCESS_USE = 8;
        private const int PRINTER_ALL_ACCESS = 983052;
        public const int PRINTER_CONTROL_PAUSE = 1;
        public const int PRINTER_CONTROL_RESUME = 2;
        public const int PRINTER_CONTROL_PURGE = 3;

        [DebuggerNonUserCode]
        static pJob()
        {
        }

        [DllImport("winspool.Drv", EntryPoint = "OpenPrinterW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        private static extern bool OpenPrinter(string src, ref IntPtr hPrinter, ref pJob.PRINTER_DEFAULTS pd);

        [DllImport("winspool.Drv", EntryPoint = "EnumJobsA", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        private static extern int EnumJobs(int hPrinter, int FirstJob, int NoJobs, int Level, ref IntPtr pJob, int cdBuf, ref int pcbNeeded, ref int pcReturned);

        [DllImport("winspool.Drv", EntryPoint = "SetPrinterA", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        private static extern int SetPrinter(int hPrinter, int Level, ref IntPtr pPrinter, int Command);

        [DllImport("winspool.Drv", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        private static extern bool ClosePrinter(IntPtr hPrinter);

        [DllImport("kernel32", SetLastError = true)]
        private static extern void Sleep(int dwMilliseconds);

        public static bool CheckPrnJob(string pName)
        {
            int num1 = 0;
            int num2 = 10;
            int num3 = 1;
            pJob.PRINTER_DEFAULTS pd = new PRINTER_DEFAULTS();
            pd.DesiredAccess = 983052;
            IntPtr hPrinter1 = new IntPtr();
            bool flag;
            if (-(pJob.OpenPrinter(pName, ref hPrinter1, ref pd) ? 1 : 0) == 0)
            {
                flag = true;
            }
            else
            {
                int hPrinter2 = (int)hPrinter1;
                int FirstJob = num1;
                int NoJobs = num2;
                int Level = num3;
                IntPtr zero = IntPtr.Zero;
                ref IntPtr local1 = ref zero;
                int cdBuf = 0;
                int num4 = new int();
                ref int local2 = ref num4;
                int num5 = new int();
                ref int local3 = ref num5;
                int num6 = pJob.EnumJobs(hPrinter2, FirstJob, NoJobs, Level, ref local1, cdBuf, ref local2, ref local3);
                num6 = -(pJob.ClosePrinter(hPrinter1) ? 1 : 0);
                flag = num4 != 0;
            }
            return flag;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct PRINTER_DEFAULTS
        {
            public IntPtr pDatatype;
            public IntPtr pDevMode;
            public int DesiredAccess;
        }
    }
}
