using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PWA_Test.Models
{
    public class Security
    {
        public static string EncryptPassword(string password)
        {
            int l = 0;
            int i;
            char ch;
            string strEncrypt = "";
            password = password.ToUpper();
            for (i = 1; i <= password.Length; i++)
            {
                l = l + (i * (int)(password.Substring(i - 1, 1).ToCharArray()[0]));
            }

            Microsoft.VisualBasic.VBMath.Rnd(-1);
            Microsoft.VisualBasic.VBMath.Randomize(1);

            for (i = 1; i <= password.Length; i++)
            {
                object f;
                int t;
                f = (Microsoft.VisualBasic.VBMath.Rnd() * 100);

                l = (int)(l + Convert.ToInt32(f) * (int)(password.Substring(i - 1, 1).ToCharArray()[0]));
                t = l % 61;
                if (t < 10)
                {
                    ch = (char)(48 + t);
                }
                else if (t < 36)
                {
                    ch = (char)(55 + t);
                }
                else
                {
                    ch = (char)(61 + t);
                }
                strEncrypt += ch;


            }

            return strEncrypt;

        }
    }
}