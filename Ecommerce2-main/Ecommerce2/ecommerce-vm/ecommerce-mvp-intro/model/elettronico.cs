using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_oop_ecommerce_basic.model
{
    public class elettronico : Product
    {

        private string codice_modello { get; set; }
        public elettronico(string id, string name, string prod, string descr, float price, string codice_modello) : base(id, name, prod, descr, price)
        {
            this.codice_modello = codice_modello;
        }
        public elettronico(string id, string name, string prod, string descr, string codice_modello) : base(id, name, prod, descr)
        {
            this.codice_modello = codice_modello;
        }
        public elettronico(elettronico prodotto) : base(prodotto)
        {
            codice_modello = "";
        }
        public elettronico(string id) : base(id)
        {
            codice_modello = "";
        }
        override public Product Clone()
        {
            return new elettronico(this);
        }
       override public float getScontato()
        {
           float temp = base.getScontato();
            DateTime today = DateTime.Today;
            if (today.DayOfWeek == DayOfWeek.Monday)
            {
                
                temp=(Price / 100)*95;
                return temp ;
            }
            return base.getScontato();
        }
    }
}

