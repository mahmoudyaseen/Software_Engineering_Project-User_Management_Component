using System;
using System.Collections.Generic;

namespace final_with_test.Models
{
    public partial class Company
    {
        public Company()
        {
            CompanyInterests = new HashSet<CompanyInterests>();
        }

        public string Cemail { get; set; }
        public string Password { get; set; }
        public string Cname { get; set; }
        public string Location { get; set; }
        public int NumberOfEmplyees { get; set; }

        public virtual ICollection<CompanyInterests> CompanyInterests { get; set; }
    }
}
