using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ds_rx1_print_library
{
    [StandardModule]
    public class GetCvPort
    {
        private const int PRINTER_ATTRIBUTE_DEFAULT = 4;
        private const int PRINTER_ATTRIBUTE_ENABLE_BIDI = 2048;
        private const int PRINTER_ATTRIBUTE_WORK_OFFLINE = 1024;
        public static short PrinterNum;

        [DebuggerNonUserCode]
        static GetCvPort()
        {
        }

        [DllImport("kernel32.dll", EntryPoint = "lstrlenA", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        private static extern int lstrlen(IntPtr lpString);

        [DllImport("winspool.Drv", EntryPoint = "OpenPrinterW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        private static extern bool OpenPrinter(string src, ref IntPtr hPrinter, long pd);

        [DllImport("winspool.Drv", EntryPoint = "EnumJobsA", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        private static extern int EnumJobs(int hPrinter, int FirstJob, int NoJobs, int Level, ref IntPtr pJob, int cdBuf, ref int pcbNeeded, ref int pcReturned);

        [DllImport("winspool.Drv", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        private static extern bool ClosePrinter(IntPtr hPrinter);

        [DllImport("winspool.drv", SetLastError = true)]
        private static extern bool GetPrinter(IntPtr hPrinter, int dwLevel, IntPtr pPrinter, int cbBuf, ref int pcbNeeded);

        public static string GetPortName(ref string strPrinterDeviceName)
        {
            int dwLevel = 5;
            IntPtr hPrinter = new IntPtr();
            if (!GetCvPort.OpenPrinter(strPrinterDeviceName, ref hPrinter, (long)IntPtr.Zero))
                throw new Win32Exception(Marshal.GetLastWin32Error());
            IntPtr zero = IntPtr.Zero;
            try
            {
                int pcbNeeded1 = new int();
                GetCvPort.GetPrinter(hPrinter, dwLevel, (IntPtr)Conversions.ToLong((string)null), 0, ref pcbNeeded1);
                if (pcbNeeded1 <= 0)
                    throw new Exception("error!");
                IntPtr pPrinter = Marshal.AllocHGlobal(pcbNeeded1);
                int pcbNeeded2 = new int();
                if (!GetCvPort.GetPrinter(hPrinter, dwLevel, pPrinter, pcbNeeded1, ref pcbNeeded2))
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                GetCvPort.PRINTER_INFO_2 printerInfo = GetCvPort.GetPrinterInfo(strPrinterDeviceName);
                if (((ulong)printerInfo.Attributes & 2048UL & (ulong)-(((long)printerInfo.Attributes & 1024L) == 0L ? 1 : 0)) > 0UL && printerInfo.pDriverName.IndexOf("DS-RX1") != -1)
                    return printerInfo.pPortName;
                return "";
            }
            finally
            {
                GetCvPort.ClosePrinter(hPrinter);
            }
        }

        public static GetCvPort.PRINTER_INFO_2 GetPrinterInfo(string printerName)
        {
            IntPtr hPrinter = new IntPtr();
            if (!GetCvPort.OpenPrinter(printerName, ref hPrinter, (long)IntPtr.Zero))
                throw new Win32Exception(Marshal.GetLastWin32Error());
            IntPtr num = IntPtr.Zero;
            try
            {
                int pcbNeeded1 = new int();
                GetCvPort.GetPrinter(hPrinter, 2, IntPtr.Zero, 0, ref pcbNeeded1);
                if (pcbNeeded1 <= 0)
                    throw new Exception("Fail!!");
                num = Marshal.AllocHGlobal(pcbNeeded1);
                int pcbNeeded2 = new int();
                if (!GetCvPort.GetPrinter(hPrinter, 2, num, pcbNeeded1, ref pcbNeeded2))
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                object structure = Marshal.PtrToStructure(num, typeof(GetCvPort.PRINTER_INFO_2));
                GetCvPort.PRINTER_INFO_2 printerInfo2 = new PRINTER_INFO_2();
                return structure != null ? (GetCvPort.PRINTER_INFO_2)structure : printerInfo2;
            }
            finally
            {
                GetCvPort.ClosePrinter(hPrinter);
                Marshal.FreeHGlobal(num);
            }
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct PRINTER_INFO_5
        {
            public IntPtr pPrinterName;
            public IntPtr pPortName;
            public int Attributes;
            public int DeviceNotSelectedTimeout;
            public int TransmissionRetryTimeout;
        }

        public struct PRINTER_INFO_2
        {
            [MarshalAs(UnmanagedType.LPStr)]
            public string pServerName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pPrinterName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pShareName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pPortName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDriverName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pComment;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pLocation;
            public IntPtr pDevMode;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pSepFile;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pPrintProcessor;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDatatype;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pParameters;
            public IntPtr pSecurityDescriptor;
            public uint Attributes;
            public uint Priority;
            public uint DefaultPriority;
            public uint StartTime;
            public uint UntilTime;
            public uint Status;
            public uint cJobs;
            public uint AveragePPM;
        }
    }
}
