using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DayaAcces.Model
{
    public class ModelContext : DbContext
    {
        public ModelContext(DbContextOptions<ModelContext> options)
        : base(options)
        {



        }
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Notes> Notess { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
               .HasKey(u => u.Id);
            modelBuilder.Entity<Notes>().HasOne(n => n.User).WithMany(u => u.Note).HasForeignKey(n => n.UserId);


            // Додаємо початкові дані до таблиці MyEntities
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Dimon", Login = "login", Password = "password" },
                new User { Id = 2, Name = "Pashka", Login = "login1", Password = "password1" }
            );
            modelBuilder.Entity<Notes>().HasData(
               new Notes { Id = 1, Info = "Dimon Info1", Date = new DateTime(2023, 7, 20, 18, 30, 25), UserId = 1 },
               new Notes { Id = 2, Info = "Pashka Info1", Date = new DateTime(2024, 7, 20, 18, 30, 25), UserId = 2 }
           );
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder
            .UseLazyLoadingProxies()
            .UseSqlServer(@"Data Source=DESKTOP-F8JLP97;Initial Catalog=Kursovaya-2;Integrated Security = true;TrustServerCertificate=True");

        }
    }
}
