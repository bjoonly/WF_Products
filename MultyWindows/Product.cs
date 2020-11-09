using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultyWindows
{[Serializable]
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Country { get; set; }
        public int Discount { get; set; }
        public Product(string name = "No name", double price = 0.0, int quantity = 0, string country = "No country", int dicsount = 0)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
            Country = country;
            Discount = dicsount;
        }
        public override string ToString()
        {
            return $"{Name}\n{Price}\n{Quantity}\n{Country}\n{Discount}";
               

        }
    }
}
