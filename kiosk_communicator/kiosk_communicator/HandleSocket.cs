using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;

namespace kiosk_communicator
{
    class HandleSocket
    {
        TcpClient clientSocket;
        int clientNo;
        Thread thread;

        public void startClient(TcpClient ClientSocket, int clientNo)
        {
            this.clientSocket = ClientSocket;
            this.clientNo = clientNo;

            thread = new Thread(getMessageFromService);
            thread.IsBackground = true;
            thread.Start();
        }

        public delegate void MessageDisplayHandler(string text);
        public event MessageDisplayHandler messageReceived;

        public delegate void CalculateClientCounter();
        public event CalculateClientCounter OnCalculated;

        private void getMessageFromService()
        {
            NetworkStream stream = null;

            try
            {
                byte[] buffer = new byte[1024];
                string msg = string.Empty;
                string strCommand = string.Empty;
                int bytes = 0;
                int MessageCount = 0;
                string strReturn = "";
                int intStatus = -1;
                PrintControl printControl = new PrintControl();

                while (true)
                {
                    if ((clientSocket != null) && (clientSocket.Connected))
                    {
                        try
                        {
                            MessageCount++;
                            stream = clientSocket.GetStream();
                            bytes = stream.Read(buffer, 0, buffer.Length);
                            strCommand = Encoding.UTF8.GetString(buffer, 0, bytes);
                            
                            if (!string.IsNullOrEmpty(strCommand))
                            {
                                if (messageReceived != null)
                                {
                                    msg = "Data Received : " + strCommand;
                                    messageReceived(msg);
                                }

                                switch (strCommand)
                                {
                                    case "CheckPrint":
                                        intStatus = PrintControl.setPresentStatus();
                                        strReturn = PrintControl.GetInformation();
                                        break;
                                }

                                byte[] sbuffer = Encoding.UTF8.GetBytes(intStatus.ToString() + "," + strReturn);
                                stream.Write(sbuffer, 0, sbuffer.Length);
                                stream.Flush();

                                if (messageReceived != null)
                                {
                                    messageReceived("Return value : " + intStatus.ToString() + "," + strReturn);
                                }
                            }
                            else
                            {
                                thread.Abort();
                            }
                        }
                        catch(Exception ex)
                        {
                            LogClass log = new LogClass();
                            string[] lines = { DateTime.Now.ToString(), "Function Name : " + System.Reflection.MethodBase.GetCurrentMethod().Name, ex.ToString() };
                            log.writeLog(lines);
                        }
                    }
                    else
                    {
                        thread.Abort();
                    }
                }
            }
            catch (SocketException ex)
            {
                if (clientSocket != null)
                {
                    byte[] sbuffer = Encoding.UTF8.GetBytes("ERR" + "," + ex.Message);
                    stream.Write(sbuffer, 0, sbuffer.Length);
                    messageReceived("Error happened(function : getMessageFromService) - " + ex.Message);
                }

                if (OnCalculated != null)
                {
                    OnCalculated();
                }

                clientSocket.Close();
                clientSocket.Dispose();

                LogClass log = new LogClass();
                string[] lines = { DateTime.Now.ToString(), "Function Name : " + System.Reflection.MethodBase.GetCurrentMethod().Name, ex.ToString() };
                log.writeLog(lines);
            }
            catch (Exception ex)
            {
                if (OnCalculated != null)
                {
                    OnCalculated();
                }

                LogClass log = new LogClass();
                string[] lines = { DateTime.Now.ToString(), "Function Name : " + System.Reflection.MethodBase.GetCurrentMethod().Name, ex.ToString() };
                log.writeLog(lines);
            }
        }
    }
}
