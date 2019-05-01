using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using final_with_test.Models;

namespace final_with_test.Tests
{
    class TestUserDbSet : TestDbSet<Users>
    {
        public override Users Find(params object[] keyValues)
        {
            return this.SingleOrDefault(product => product.Uemail == (string)keyValues.Single());
        }
    }

}
