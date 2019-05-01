using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using final_with_test.Controllers;
using final_with_test.Models;

namespace final_with_test.Tests
{
    class TestCompanyDbSet : TestDbSet<Company>
    {
        public override Company Find(params object[] keyValues)
        {
            return this.SingleOrDefault(product => product.Cemail == (string)keyValues.Single());
        }
    }
}
