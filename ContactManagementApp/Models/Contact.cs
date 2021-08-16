using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ContactManagementApp.Models
{
    public class ContactContext : DbContext
    {
       public ContactContext() : base("ContactConnection")
        {

        }

        public DbSet<Person> People { get; set; }
    }
}