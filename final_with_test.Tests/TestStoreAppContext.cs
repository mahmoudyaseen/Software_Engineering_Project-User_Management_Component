using final_with_test.Controllers;
using final_with_test.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace final_with_test.Tests
{
    public class TestStoreAppContext : IStoreAppContext
    {
        public TestStoreAppContext()
        {
            this.Users = new TestUserDbSet();
            this.Company = new TestCompanyDbSet();
        }


        public DbSet<Company> Company { get; set; }

        public DbSet<CompanyInterests> CompanyInterests { get; set; }

        public DbSet<UserInterests> UserInterests { get; set; }

        public DbSet<Users> Users { get; set; }

        public int SaveChanges()
        {
            return 0;
        }

        public void Dispose() { }

        public void MarkAsModified(Company item) { }

        public void MarkAsModified(Users item) { }
    }
}
