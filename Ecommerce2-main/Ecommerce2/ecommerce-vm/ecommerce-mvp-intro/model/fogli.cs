using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_oop_ecommerce_basic.model
{
    public class fogli : Cartoleria
    {
        string grammatura { get; set; }
        public fogli(string id, string name, string prod, string descr, float price, string grammatura) : base(id, name, prod, descr, price)
        {
            this.grammatura = grammatura;
        }
        public fogli(string id) : base(id)
        {
            grammatura = "";
        }
        public fogli(Cartoleria prodotto) : base(prodotto)
        {
            grammatura = "";
        }
        override public Product Clone()
        {
            return new fogli(this);
        }

    }
}
