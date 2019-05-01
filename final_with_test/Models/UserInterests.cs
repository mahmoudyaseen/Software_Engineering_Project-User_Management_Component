using System;
using System.Collections.Generic;

namespace final_with_test.Models
{
    public partial class UserInterests
    {
        public string Uemail { get; set; }
        public string Interest { get; set; }

        public virtual Users UemailNavigation { get; set; }
    }
}
