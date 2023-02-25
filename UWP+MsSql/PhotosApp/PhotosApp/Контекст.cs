using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotosApp
{
    public class Контекст : DbContext
    {
        public DbSet<Фотографии> Фотографии { get; set; }
        public DbSet<Комментарий> Комментарий { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Комментарий>((pc =>
            {
                pc.HasNoKey();
            }));
            modelBuilder.Entity<Фотографии>((pc =>
            {
                pc.HasNoKey();
            }));
        }
        public Контекст()
        {
            Database.EnsureCreated();

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=DB_PhotosAndComm.db");
        }
    }
}
