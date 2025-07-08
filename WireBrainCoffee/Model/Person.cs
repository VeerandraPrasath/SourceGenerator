using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WireBrainCoffee.Model
{
    public class Person
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public override string ToString()
        {
            return $"FirstName:{FirstName}; LastName:{LastName}";
        }
    }
}
