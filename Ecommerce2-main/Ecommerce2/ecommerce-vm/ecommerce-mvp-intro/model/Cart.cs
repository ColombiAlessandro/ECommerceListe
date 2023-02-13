using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_oop_ecommerce_basic.model
{
    //base version by Marco Borelli Nov 2022
    //extended and modified by olprofesur Nov-Dic 2022
    public class Cart
    {
        //attributes
        private float totale=0;
        private float totale_S=0;
        private const int MAXCARR = 999;
        private string _id;
        private List<Product> _prod;

        //properties
        public string Id
        {
            get
            {
                return _id;
            }
            private set
            {
                if (value != null)
                    _id = value;
                else
                    throw new Exception("Invalid Id");
            }
        }
        public float getTotale()
        {
            return totale;
        }
        public float getTotale_S()
        {
            return totale_S;
        }
        public List<Product> Products
        {
            get
            {
                List<Product> p = new List<Product>();
                foreach (Product product in _prod)
                {
                    p.Add(product.Clone());
                }
                return p;
            }
            
        }

        //constructors
        public Cart(string id)
        {
            this.Id = id;
            _prod = new List<Product>();
            Clear();
        }

        //copy constrcutor for clone
        protected Cart(Cart c) : this(c.Id)
        {
            Id = c.Id;
            foreach(Product p in c.Products)
            {
                this.Products.Add(p.Clone());
            }


        }

        public Cart Clone()
        {
            return new Cart(this);
        }

        //metodi specifici
        public void Clear()
        {
            for (int i = 0; i < _prod.Count; i++)
                _prod[i] = null;
        }
        public void Add(Product p)
        {
            if (Products.Count == MAXCARR)
            {
                throw new Exception("Unable to add, MAX dimension of internal array reached");
            }

            if (p != null) {
                Products.Add(p);
                totale = totale + p.Price;
                totale_S = totale_S + p.getScontato();
            }
            else{
                throw new Exception("Invalid product");

        }
            
    
        }


        public int IndexOf(Product q)
        {
            return Products.IndexOf(q);
        }

        public void Modify(Product p)
        {
            int i = IndexOf(p);
            if (i>=0)
            {
                _prod[i] = p.Clone();
            }
            else
                throw new Exception("Product not found");
        }

        public Product Remove(Product p)
        {
            Remove(p);
            return p;
        }
    }
}
