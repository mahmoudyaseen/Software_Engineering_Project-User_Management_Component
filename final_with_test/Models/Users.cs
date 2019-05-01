using System;
using System.Collections.Generic;

namespace final_with_test.Models
{
    public partial class Users
    {
        public Users()
        {
            UserInterests = new HashSet<UserInterests>();
        }

        public string Uemail { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Type { get; set; }

        public virtual ICollection<UserInterests> UserInterests { get; set; }
    }
}
