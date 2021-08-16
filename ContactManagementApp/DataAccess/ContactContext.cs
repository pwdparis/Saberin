using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContactManagementApp.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ContactManagementApp.DataAccess
{
    public class ContactContext : DbContext

    {
        public ContactContext() : base("ContactConnection")
        { }

        public DbSet<Person> People { get; set;}

        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }

    }
}