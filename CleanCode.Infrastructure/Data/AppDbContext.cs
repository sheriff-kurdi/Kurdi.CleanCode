using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using CleanCode.Core.Entities;
namespace CleanCode.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
               => options.UseSqlite("Data Source=blogging.db");
        public DbSet<Employee> employees { get; set; }
    }
}
