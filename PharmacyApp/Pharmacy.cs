using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp
{
    public class Pharmacy
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Telephone { get; set; }
        public Pharmacy(string name, string address, int telephone)
        {
            Name = name;
            Address = address;
            Telephone = telephone;
        }

        public Pharmacy()
        {
            
            Name = " ";
            Address = " ";
            Telephone = 0;
        }

    }
}
