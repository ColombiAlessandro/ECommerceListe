using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_oop_ecommerce_basic.model
{
    public class Penne : Cartoleria
    {
        string funzionamento { get; set; }
        public Penne(string id, string name, string prod, string descr, float price, string funzionamento) : base(id, name, prod, descr, price)
        {
            this.funzionamento = funzionamento;
        }
        public Penne(string id) : base(id)
        {
            funzionamento = "";
        }
        public Penne(Cartoleria prodotto) : base(prodotto)
        {
            funzionamento = "";
        }
        override public Product Clone()
        {
            return new Penne(this);
        }

    }
}