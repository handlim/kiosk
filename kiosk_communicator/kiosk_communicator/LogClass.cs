using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kiosk_communicator
{
    class LogClass
    {
        public void writeLog(string[] lines)
        {
            try
            {
                string[] txt = System.IO.File.ReadAllLines("log.txt");
                string[] allTxt = new string[txt.Length + lines.Length + 1];
                
                for (int i = 0; i < lines.Length; i++)
                {
                    allTxt[i] = lines[i];
                }

                allTxt[lines.Length] = "#########################################################################################################################################################################";

                for (int i = 0; i < txt.Length - 1; i++)
                {
                    allTxt[i + lines.Length +1] = txt[i];
                }
                 
                System.IO.File.WriteAllText("log.txt", "");
                System.IO.File.WriteAllLines("log.txt", allTxt);
            }
            catch 
            {}
        }
    }
}
