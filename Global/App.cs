using JETech.SIC.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace JETech.SIC.Core
{
    public class App
    {
        public static DbContext CurrentDbContext { get; set; }
    }
}
