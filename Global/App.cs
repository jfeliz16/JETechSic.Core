using JETech.SIC.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace JETech.SIC.Core
{
    public class App
    {
        private static DataContext _dataContext;

        public static DataContext CurrentDataContext
        {
            get
            {
                if (_dataContext == null)
                {
                    _dataContext = new DataContext();
                }
                return _dataContext;
            }
        }
    }
}
