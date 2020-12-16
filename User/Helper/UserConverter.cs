using JETech.SIC.Core.Data.Entities;
using JETech.SIC.Core.User.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace JETech.SIC.Core.User.Helper
{
    public class UserConverter
    {
        public static Data.Entities.User ToUser(UserModel model) 
        {
            return new Data.Entities.User
            {                
                UserName = model.UserName,
                Email = model.UserName                
            };
        }
    }
}
