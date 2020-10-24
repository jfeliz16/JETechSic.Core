using System;
using System.Collections.Generic;
using System.Text;

namespace JETech.SIC.Core.Global
{
    public class Messages
    {        
        public static  string NullField => Resources.Messages.ResourceManager.GetString("NullField");
        public static string UserExist => Resources.Messages.ResourceManager.GetString("UserExist");
        public static string InvalidUser => Resources.Messages.ResourceManager.GetString("InvalidUser");
        public static string PasswordNotMach => Resources.Messages.ResourceManager.GetString("PasswordNotMach");
    }
}
