using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace manage_kiosk
{
    public partial class monitoring : System.Web.UI.Page
    {
        static Socket socket;
        static int port = 8888;

        private enum exeCommend
        {
            CheckPrint = 1,
            CheckLog = 2
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        private void getPrintInfor()
        {

            RX1_Info.StatForm rx1 = new RX1_Info.StatForm();

            showMessage("");
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                socket.Connect(ipep);
                byte[] data = Encoding.UTF8.GetBytes(exeCommend.CheckPrint.ToString());
                socket.Send(data);
                //socket.Close();

                Byte[] _data = new Byte[1024];
                socket.Receive(_data);
                String strReturnvalue = Encoding.UTF8.GetString(_data);
                setPrinterInformation(strReturnvalue);
            }
            catch(Exception ex)
            {
                showMessage(ex.Message);
            }
            
        }

        private void setPrinterInformation(string data)
        {
            if (data != "ERR")
            {
                string[] arr = data.Split(',');

                string msg = "";
                string strSize = "";
                string strTot = "";
                string strPrintedCnt = "";

                try
                {
                    msg = messageList.getMessage(int.Parse(arr[0]));
                    strSize = arr[1];
                    strTot = arr[2];
                    strPrintedCnt = arr[3];
                }
                catch(Exception ex)
                {

                }
            } else
            {
                showMessage("KIOSK ERROR");
            }
        }

        protected void btnGetInfo_Click(object sender, EventArgs e)
        {
            getPrintInfor();
        }

        protected void btnStatusPrint_Click(object sender, EventArgs e)
        {
            
        }

        private void showMessage(string msg)
        {
            lblShowMessage.Text = msg;
        }
    }
}