using PizzaUser.Database;
using PizzaUser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaUser.Services
{
    public static class BasketServices
    {
        public static void AddToBasket(Products pizza)
        {
            Basket basketItem = new Basket
            {
                PizzaName = pizza.PizzaName,
                Price = pizza.Price
            };

            PizzaDatabase.basket.Add(basketItem);
            Console.WriteLine($"{basketItem.PizzaName} added to basket!");
        }

        public static void GetAllItems()
        {
            foreach (var item in PizzaDatabase.basket)
            {
                Console.WriteLine($"{item.PizzaName} {item.Price} ");
            }
        }
    }
}
