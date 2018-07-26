using CMS.Domain.Core;
using CMS.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Infrastructure
{
    public class SchoolDbContext : DbContext, IDbContext
    {
        public SchoolDbContext()
            : base("name=db_student")
        { }
        public DbSet<Student> student { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>();
            modelBuilder.Entity<Grade>();

            base.OnModelCreating(modelBuilder);
        }


    }
}
