﻿using Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class MusicDbContext: DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories {get;set;}
        public DbSet<Rating> Ratings {get;set;}
    }
}
