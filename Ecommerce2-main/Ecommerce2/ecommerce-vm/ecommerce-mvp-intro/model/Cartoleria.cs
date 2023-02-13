using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_oop_ecommerce_basic.model
{
    public class Cartoleria : Product
    {
        public Cartoleria(string id, string name, string prod, string descr, float price) : base(id, name, prod, descr, price)
        {
        }
        public Cartoleria(string id) : base(id)
        {
        }
        public Cartoleria(Cartoleria prodotto) : base(prodotto)
        {
        }
        override public Product Clone()
        {
            return new Cartoleria(this);
        }
        public override float getScontato()
        {
            if((DateTime.Now.Day % 2) == 0)
            {
                return base.getScontato() / 100 * 97;
            }
            return base.getScontato();
        }
    }
}
