using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using final_with_test.Models;

namespace final_with_test.Models
{
    public class StoreAppContext : DbContext, IStoreAppContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        //public StoreAppContext() : base("name=StoreAppContext")
        //{

        //}

        public StoreAppContext()
        {
            this.Database.Connection.ConnectionString = @"server=DESKTOP-C7J5RLQ;database=UserManagement;Integrated Security=True;";
        }

        public DbSet<Company> Company { get; set; }
        public DbSet<CompanyInterests> CompanyInterests { get; set; }
        public DbSet<UserInterests> UserInterests { get; set; }
        public DbSet<Users> Users { get; set; }

        public void MarkAsModified(Company item)
        {
            Entry(item).State = EntityState.Modified;
        }

        public void MarkAsModified(Users item)
        {
            Entry(item).State = EntityState.Modified;
        }
    }
}
