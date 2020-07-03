using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataManagement;

namespace BusinessLayer
{
    public class CheckLogin
    {
        public static bool CheckUser(string username , string password)
        {
            bool result = false;
            try
            {
                string _username = null;
                string _password = null;

                if (!string.IsNullOrEmpty(username) == true && !string.IsNullOrWhiteSpace(username))
                {
                    _username = username;
                }
                else
                {
                    throw new Exception("User name is not correct");
                }

                if (!string.IsNullOrEmpty(password) || !string.IsNullOrWhiteSpace(password))
                {
                    _password = password;
                }
                else
                {
                    throw new Exception("Password is not correct");
                }
                result = Login.LoginUser(_username, _password);
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return result;
        }
    }
}
