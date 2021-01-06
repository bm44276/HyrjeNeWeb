using Library_Managment.Models;
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
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<TakenBooks> TakenBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);
        }
    }
}
