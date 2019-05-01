using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using final_with_test.Models;

namespace final_with_test.Models
{
    public interface IStoreAppContext : IDisposable
    {
        int SaveChanges();

        DbSet<Company> Company { get; }
        DbSet<CompanyInterests> CompanyInterests { get; }
        DbSet<UserInterests> UserInterests { get; }
        DbSet<Users> Users { get; }

        void MarkAsModified(Company item);

        void MarkAsModified(Users item);

    }
}
