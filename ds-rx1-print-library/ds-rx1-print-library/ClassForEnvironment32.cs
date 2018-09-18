using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ds_rx1_print_library
{
    public class ClassForEnvironment32
    {
        [DebuggerNonUserCode]
        public ClassForEnvironment32()
        {
        }

        [DllImport("CyStat.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int CvInitialize([MarshalAs(UnmanagedType.LPWStr)] string pszPortName);

        [DllImport("CyStat.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int CvGetVersion(int lPortNum, [MarshalAs(UnmanagedType.VBByRefStr)] ref string s);

        [DllImport("CyStat.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int CvGetSensorInfo(int lPortNum, [MarshalAs(UnmanagedType.VBByRefStr)] ref string s);

        [DllImport("CyStat.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int CvGetMedia(int lPortNum, [MarshalAs(UnmanagedType.VBByRefStr)] ref string s);

        [DllImport("CyStat.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int CvGetStatus(int lPortNum);

        [DllImport("CyStat.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int CvGetPQTY(int lPortNum);

        [DllImport("CyStat.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int CvGetCounterL(int lPortNum);

        [DllImport("CyStat.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int CvGetCounterA(int lPortNum);

        [DllImport("CyStat.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int CvGetCounterB(int lPortNum);

        [DllImport("CyStat.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int CvGetMediaCounter(int lPortNum);

        [DllImport("CyStat.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int CvGetMediaColorOffset(int lPortNum);

        [DllImport("CyStat.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int CvGetMediaLotNo(int lPortNum, [MarshalAs(UnmanagedType.VBByRefStr)] ref string s);

        [DllImport("CyStat.dll", EntryPoint = "CvSetColorDataVersion", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int CvSetColorDataVersion_(int lPortNum, int lpBuff, int bLen);

        [DllImport("CyStat.dll", EntryPoint = "SetColorDataWrite", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int CvSetColorDataWrite_(int lPortNum, int lpBuff, int bLen);

        [DllImport("CyStat.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int CvGetColorDataVersion(int lPortNum, [MarshalAs(UnmanagedType.VBByRefStr)] ref string s);

        [DllImport("CyStat.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int CvSetColorDataClear(int lPortNum);

        [DllImport("CyStat.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int CvGetColorDataChecksum(int lPortNum, [MarshalAs(UnmanagedType.VBByRefStr)] ref string s);

        [DllImport("CyStat.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int CvGetSerialNo(int lPortNum, [MarshalAs(UnmanagedType.VBByRefStr)] ref string s);

        [DllImport("CyStat.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int CvGetResolutionH(int lPortNum);

        [DllImport("CyStat.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int CvGetResolutionV(int lPortNum);

        [DllImport("CyStat.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int CvGetFreeBuffer(int lPortNum);

        [DllImport("CyStat.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int CvSetClearCounterA(int lPortNum);

        [DllImport("CyStat.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int CvSetClearCounterB(int lPortNum);

        [DllImport("CyStat.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int CvSetFirmwUpdateMode(int lPortNum);

        [DllImport("CyStat.dll", EntryPoint = "SetFirmwDataWrite", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int CvSetFirmwDataWrite_(int lPortNum, int lpBuff, int bLen);

        [DllImport("CyStat.dll", EntryPoint = "CvSetCommand", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int CvSetCommand_(int lPortNum, int lpCmd, int dwCmdLen);

        [DllImport("CyStat.dll", EntryPoint = "CvGetCommand", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int CvGetCommand_(int lPortNum, int lpCmd, int dwCmdLen, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpRetBuff, int dwRetBuffSize, ref int lpdwRetLen);

        [DllImport("CyStat.dll", EntryPoint = "CvGetCommandEX", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int CvGetCommandEX_(int lPortNum, int lpCmd, int dwCmdLen, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpRetBuff, int dwRetBuffSize);

        [DllImport("CyStat.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int PortInitialize([MarshalAs(UnmanagedType.LPWStr)] string pszPortName);

        [DllImport("CyStat.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int PortInitializeEX([MarshalAs(UnmanagedType.LPWStr)] string pszPortName, [MarshalAs(UnmanagedType.LPWStr)] string pszPrinterName);

        [DllImport("CyStat.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int RegisterPrinterName(int lPortNum, [MarshalAs(UnmanagedType.LPWStr)] string pszPrinterName);

        [DllImport("CyStat.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int GetFirmwVersion(int lPortNum, [MarshalAs(UnmanagedType.VBByRefStr)] ref string s);

        [DllImport("CyStat.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int GetSensorInfo(int lPortNum, [MarshalAs(UnmanagedType.VBByRefStr)] ref string s);

        [DllImport("CyStat.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int GetMedia(int lPortNum, [MarshalAs(UnmanagedType.VBByRefStr)] ref string s);

        [DllImport("CyStat.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int GetStatus(int lPortNum);

        [DllImport("CyStat.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int GetPQTY(int lPortNum);

        [DllImport("CyStat.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int GetCounterL(int lPortNum);

        [DllImport("CyStat.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int GetCounterA(int lPortNum);

        [DllImport("CyStat.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int GetCounterB(int lPortNum);

        [DllImport("CyStat.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int GetCounterP(int lPortNum);

        [DllImport("CyStat.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int GetCounterMatte(int lPortNum);

        [DllImport("CyStat.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int GetCounterM(int lPortNum);

        [DllImport("CyStat.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int GetMediaCounter(int lPortNum);

        [DllImport("CyStat.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int GetMediaCounter_R(int lPortNum);

        [DllImport("CyStat.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int GetMediaColorOffset(int lPortNum);

        [DllImport("CyStat.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int GetMediaLotNo(int lPortNum, [MarshalAs(UnmanagedType.VBByRefStr)] ref string s);

        [DllImport("CyStat.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int GetMediaIdSetInfo(int lPortNum);

        [DllImport("CyStat.dll", EntryPoint = "SetColorDataVersion", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int SetColorDataVersion_(int lPortNum, int lpBuff, int bLen);

        [DllImport("CyStat.dll", EntryPoint = "SetColorDataWrite", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int SetColorDataWrite_(int lPortNum, int lpBuff, int bLen);

        [DllImport("CyStat.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int GetColorDataVersion(int lPortNum, [MarshalAs(UnmanagedType.VBByRefStr)] ref string s);

        [DllImport("CyStat.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int SetColorDataClear(int lPortNum);

        [DllImport("CyStat.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int GetColorDataChecksum(int lPortNum, [MarshalAs(UnmanagedType.VBByRefStr)] ref string s);

        [DllImport("CyStat.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int GetSerialNo(int lPortNum, [MarshalAs(UnmanagedType.VBByRefStr)] ref string s);

        [DllImport("CyStat.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int GetResolutionH(int lPortNum);

        [DllImport("CyStat.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int GetResolutionV(int lPortNum);

        [DllImport("CyStat.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int GetFreeBuffer(int lPortNum);

        [DllImport("CyStat.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int SetClearCounterA(int lPortNum);

        [DllImport("CyStat.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int SetClearCounterB(int lPortNum);

        [DllImport("CyStat.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int SetClearCounterM(int lPortNum);

        [DllImport("CyStat.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int SetCounterP(int lPortNum, int Counter);

        [DllImport("CyStat.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int SetFirmwUpdateMode(int lPortNum);

        [DllImport("CyStat.dll", EntryPoint = "SetFirmwDataWrite", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int SetFirmwDataWrite_(int lPortNum, int lpBuff, int bLen);

        [DllImport("CyStat.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int SetCutterMode(int lPortNum, int d);

        [DllImport("CyStat.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int SetRetentionMode(int lPortNum, int d);

        [DllImport("CyStat.dll", EntryPoint = "SetCommand", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int SetCommand_(int lPortNum, int lpCmd, int dwCmdLen);

        [DllImport("CyStat.dll", EntryPoint = "GetCommand", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int GetCommand_(int lPortNum, int lpCmd, int dwCmdLen, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpRetBuff, int dwRetBuffSize, ref int lpdwRetLen);

        [DllImport("CyStat.dll", EntryPoint = "GetCommandEX", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int GetCommandEX_(int lPortNum, int lpCmd, int dwCmdLen, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpRetBuff, int dwRetBuffSize);

        [DllImport("CyStat.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int GetRfidMediaClass(int lPortNum, [MarshalAs(UnmanagedType.VBByRefStr)] ref string s);

        [DllImport("CyStat.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int GetRfidReserveData(int lPortNum, [MarshalAs(UnmanagedType.VBByRefStr)] ref string s, int dwPage);

        [DllImport("CyStat.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int GetInitialMediaCount(int lPortNum);

        [DllImport("CyStat.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int GetMediaCountOffset(int lPortNum);

        [DllImport("CyStat.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern bool SetUSBSerialEnable(int lPortNum, uint dwEnable);

        [DllImport("CyStat.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int GetUSBSerialEnable(int lPortNum);
    }
}
