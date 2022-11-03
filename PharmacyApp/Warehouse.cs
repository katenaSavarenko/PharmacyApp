using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp
{
    internal class Warehouse
    {
        public string NamePharmacy { get; set; }
        public string Name { get; set; }

        public Warehouse()
        {
            this.NamePharmacy = "";
            this.Name = "";
        }
    }
}
