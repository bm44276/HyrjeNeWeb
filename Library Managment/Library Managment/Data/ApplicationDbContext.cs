﻿using Library_Managment.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library_Managment.Data {
    public class ApplicationDbContext : IdentityDbContext <UserNewData>{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {
        }
        public DbSet<Book> Books { get; set; }
    }
}
