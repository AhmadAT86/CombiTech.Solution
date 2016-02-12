using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using CombiTech.Solution.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CombiTech.Solution.DataAccess
{

    public class DefaultDataContext : DbContext
    {
        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<ProjectStructure> ProjectStructures { get; set; } 

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
