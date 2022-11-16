using MARVEL.COMICS.REPOSITORY.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MARVEL.COMICS.REPOSITORY.Context
{
    public partial class ComicsContext : DbContext
    {
        public ComicsContext() { }

        public ComicsContext(DbContextOptions<ComicsContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=COMICS;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<USERS>().HasKey(u => u.ID);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        #region [ TABLES ]

        public virtual DbSet<APPLICATIONS> APPLICATIONS { get; set; }

        public virtual DbSet<USERS> USERS { get; set; }

        public virtual DbSet<READING_LIST> READING_LIST { get; set; }

        #endregion [ TABLES ]
    }
}
