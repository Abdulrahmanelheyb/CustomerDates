using ObjectLayer;
using System;

namespace CustomerDates
{
    public class UniqueCode
    {
        private static string Gchars = null;
        private static string last = null;
        private static void RandomChars()
        {
            last = null;
            char[] CharCodeArray = Gchars.ToCharArray();
            Random rdm = new Random();
            int Charindex;

            do
            {
                Charindex = rdm.Next(0, 11);
                if (CharCodeArray[Charindex] != '*')
                {
                    last += CharCodeArray[Charindex].ToString();
                }
                else
                {

                }
                CharCodeArray[Charindex] = '*';

            } while (last.Length != 11);
            
        }
        public static bool GetCode(Device device)
        {
            Gchars = null;
            bool rlt = false;
            
            if (string.IsNullOrEmpty(device.CustomerName) == false && string.IsNullOrWhiteSpace(device.CustomerName) == false && device.CustomerName.Length >= 2)
            {
                Gchars += device.CustomerName[device.CustomerName.Length - 1].ToString() + device.CustomerName[device.CustomerName.Length - 2].ToString();
            }
            else { throw new Exception(""); }

            if (string.IsNullOrEmpty(device.CustomerPhoneNumber) == false && string.IsNullOrWhiteSpace(device.CustomerPhoneNumber) ==false && device.CustomerPhoneNumber.Length >= 11)
            {
                Gchars = Gchars + device.CustomerPhoneNumber[ device.CustomerPhoneNumber.Length -1].ToString() + device.CustomerPhoneNumber[device.CustomerPhoneNumber.Length - 2].ToString() + device.CustomerPhoneNumber[device.CustomerPhoneNumber.Length -3].ToString() + device.CustomerPhoneNumber[device.CustomerPhoneNumber.Length -4].ToString();
            }
            else { throw new Exception(""); }

            if (string.IsNullOrEmpty(device.Model) == false && string.IsNullOrWhiteSpace(device.Model) == false && device.Model.Length >= 4)
            {
                Gchars += device.Model[device.Model.Length -1].ToString() + device.Model[device.Model.Length -2].ToString();
            }
            else { throw new Exception(""); }

            if (string.IsNullOrEmpty(device.SerialNumber) == false && string.IsNullOrWhiteSpace(device.SerialNumber) == false)
            {
                Gchars += device.SerialNumber[device.SerialNumber.Length -1].ToString() + device.SerialNumber[device.SerialNumber.Length -2].ToString();
            }
            else
            {
                if(device.CustomerName.Length >5)
                {
                    Gchars += device.CustomerName[device.CustomerName.Length - 3].ToString() + device.CustomerName[device.CustomerName.Length - 4].ToString();
                }

                if (device.Model.Length >4)
                {
                    Gchars += device.Model[device.Model.Length - 3].ToString() + device.Model[device.Model.Length - 4].ToString();
                }
            }

            if (Gchars != null)
            {
                
                if (Gchars.Length == 11)
                {
                    RandomChars();
                }
                else
                {
                    char[] abcchars = { 'A','B' ,'C' ,'D' ,'E' ,'F' ,'G' 
                            ,'H' ,'I' ,'J' ,'K' ,'L' ,'M' ,'N' ,'O' ,'P' 
                            ,'Q' ,'R' ,'S' ,'T' ,'U' ,'V' ,'W' ,'X' ,'Y' ,'Z'};

                    Random rdmabc = new Random();
                    int index = rdmabc.Next(0, 26);
                    Gchars += abcchars[index];
                    RandomChars();

                }
                if(last != null)
                device.DeviceInformationCode = last.ToUpper();
            }
            else { throw new Exception(""); }
            return rlt;
        }
    }
}
