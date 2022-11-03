using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp
{
    class Party
    {
        public int Qty { get; set; }
        public string NameWareHouse { get; set; }
        public string NameProduct { get; set; }
        public string Name { get; set; }
        public Party()
        {
            this.Qty = 0;
            this.Name = "";
            this.NameWareHouse = "";
            this.NameProduct = "";
        }
    }
}
