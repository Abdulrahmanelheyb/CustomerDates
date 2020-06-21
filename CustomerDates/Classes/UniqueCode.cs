using System;

namespace CustomerDates
{
    class UniqueCode
    {

        private static string gchars;
        public static void GetChars()
        {
            if(Globals.cdname != "" && Globals.cdname != "Name-Surname" && Globals.cdname.Length >=3)
            {
                gchars = Globals.cdname.Substring(0, 3);
            }
            else { return; }

            if (Globals.cdphone != "" && Globals.cdphone != "Phone Number" && Globals.cdphone.Length >=11)
            {
                gchars = gchars + Globals.cdphone[7] + Globals.cdphone[8] + Globals.cdphone[9] + Globals.cdphone[10];
            }
            else { return; }

            if (Globals.cdmodel != "" && Globals.cdmodel != "Model" && Globals.cdmodel.Length >=4)
            {
                gchars += Globals.cdmodel[3];
            }
            else { return; }

            
            if (Globals.cdprice != null && Globals.cdprice != "Price")
            {
                gchars += Globals.cdprice[0];
            }
            else
            {
                int num1 = Globals.cdmodel.Length;
                gchars += Globals.cdmodel[num1 - 1];
            }

            if (Globals.serialnumber != null && Globals.serialnumber !="S/N")
            {
                gchars += Globals.serialnumber.Substring(0, 2);
            }
            else
            {
                int num2 = Globals.cdname.Length;
                gchars = gchars + Globals.cdname[num2 - 1] + Globals.cdname[num2 - 2];
            }

        }
        public static void RamdomChars()
        {
            if(gchars != null)
            {
                if(gchars.Length >=3)
                {
                    char[] CharCodeArray = gchars.ToCharArray();
                    Random rdm = new Random();
                    int Charindex;
                    string last = null;
                    do
                    {
                        Charindex = rdm.Next(0, 11);
                        if (CharCodeArray[Charindex] != '*')
                        {
                            last = last + CharCodeArray[Charindex].ToString();
                        }
                        else
                        {

                        }
                        CharCodeArray[Charindex] = '*';

                    } while (last.Length != 11);
                    Globals.infoprencode = last.ToUpper();
                }
                
            }
            else { return; }
            
        }
    }
}
