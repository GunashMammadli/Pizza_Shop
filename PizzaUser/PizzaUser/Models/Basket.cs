using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaUser.Models
{
    internal class Basket : Products
    {
        private static int _id;
        public int Id;
        public Basket()
        {
            _id++;
            Id = _id;
        }
        public string PizzaName { get; set; }
        public int Price { get; set; }

        public override string ToString()
        {
            return $"{Id}. {PizzaName} {Price}$";
        }
    }
}
