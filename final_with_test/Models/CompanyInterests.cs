using System;
using System.Collections.Generic;

namespace final_with_test.Models
{
    public partial class CompanyInterests
    {
        public string Cemail { get; set; }
        public string Interest { get; set; }

        public virtual Company CemailNavigation { get; set; }
    }
}
