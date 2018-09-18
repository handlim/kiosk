using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace kiosk_communicator
{
    public partial class Main : Form
    {
        private Thread listenThread;
        public Socket Server, Client;
        public int sPort;

        TcpListener server = null;
        TcpClient client = null;
        static int counter = 0;

        public Main()
        {
            InitializeComponent();

            IPHostEntry host = Dns.GetHostByName(Dns.GetHostName());
            string myip = host.AddressList[0].ToString();
            txtIP.Text = myip;
        }

        private void InitSocket()
        {
           if (!string.IsNullOrEmpty(sPort.ToString()))
           {
                server = new TcpListener(IPAddress.Any, sPort);
                client = default(TcpClient);
                server.Start();
                printConsole("Start Socket process.");

                while (true)
                {
                    try
                    {
                        counter++;
                        client = server.AcceptTcpClient();

                        HandleSocket h_client = new HandleSocket();
                        h_client.messageReceived += new HandleSocket.MessageDisplayHandler(printConsole);
                        h_client.OnCalculated += new HandleSocket.CalculateClientCounter(CalculateCounter);
                        h_client.startClient(client, counter);
                    }
                    catch (SocketException ex)
                    {
                        LogClass log = new LogClass();
                        string[] lines = { DateTime.Now.ToString(), "Function Name : " + System.Reflection.MethodBase.GetCurrentMethod().Name, ex.ToString() };
                        log.writeLog(lines);
                    }
                    catch (Exception ex)
                    {
                        LogClass log = new LogClass();
                        string[] lines = { DateTime.Now.ToString(), "Function Name : " + System.Reflection.MethodBase.GetCurrentMethod().Name, ex.ToString() };
                        log.writeLog(lines);
                    }
                }
            }
        }

        private void CalculateCounter()
        {
            counter--;
        }
                
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPort.Text))
            {
                sPort = int.Parse(txtPort.Text);
                txtPort.ReadOnly = true;

                listenThread = new Thread(InitSocket);
                listenThread.IsBackground = true;
                listenThread.Start();

                btnStart.Visible = false;
                btnStop.Visible = true;
            }
            else
            {
                MessageBox.Show("포트를 입력하지 않았습니다.");
            }
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            listLog.Items.Clear();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStart.Visible = true;
            btnStop.Visible = false;
            server.Stop();
            
            txtPort.ReadOnly = false;
            listenThread.Abort();
            printConsole("Stop Socket process.");
        }

        private void txtPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar == '-'))
            {
                e.Handled = true;
            }
        }

        public void printConsole(string msg)
        {
            CheckForIllegalCrossThreadCalls = false;
            listLog.Items.Add(string.Format("[{0}] {1}", DateTime.Now.ToString(), msg));
        }
    }
}
