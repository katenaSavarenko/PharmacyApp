using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp
{
    internal class Product
    {
        public string Name { get; set; }

        public Product(string name)
        {
            this.Name = name;
        }

        public Product()
        {
            this.Name = "Товар 1";
        }

    }
}
