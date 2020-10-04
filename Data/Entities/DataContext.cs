﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JETech.SIC.Core.Data;

namespace JETech.SIC.Core.Data.Entities
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext() : base()
        {
        }

        public DataContext(DbContextOptions<DataContext> opcions):base(opcions)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-GO9IDF3;Database=SIC;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }
    }
}
