using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Storage;
using System;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1.Data
{
    internal class DatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectString = "Server=localhost;Database=test;uid=root;Password=;";
                optionsBuilder.UseMySql(connectString);
            }
        }
        public DbSet<SinhVienModels> SinhVien {  get; set; }
    }
}
