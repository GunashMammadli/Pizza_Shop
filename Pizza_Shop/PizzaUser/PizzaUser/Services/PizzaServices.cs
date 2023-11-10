using PizzaUser.Database;
using PizzaUser.Models;

namespace PizzaUser.PizzaServices
{
    public static class PizzaServices
    {
        public static void AddPizza(Products pizza)
        {
            PizzaDatabase.products.Add(pizza);
        }

        public static void GetAllPizza() 
        {
            PizzaDatabase.products.ForEach(delegate (Products pizza)
            {
                Console.WriteLine(pizza);
            });
        }

        public static Products UpProductById(int Id)
        {
            var delegat = PizzaDatabase.products.FindAll(p => p.Id == Id);
            foreach (var item in delegat)
            {
                return item;
            }
            return null;
        }

        public static void RemovePizza(int pizzaId)
        {
            Products pizzaToRemove = PizzaDatabase.products.FirstOrDefault(pizza => pizza.Id == pizzaId);

            if (pizzaToRemove != null)
            {
                PizzaDatabase.products.Remove(pizzaToRemove);
                Console.WriteLine($"{pizzaToRemove.PizzaName} removed successfully.");
            }
            else
            {
                Console.WriteLine("Pizza not found.");
            }
        }

        public static void AddBasket(int id, int count)
        {
            foreach (var item in PizzaDatabase.products.FindAll(p => p.Id == id))
            {
                item.Price = item.Price * count;
                PizzaDatabase.basket.Add(item);
                
            }
        }

        public static void AllBasket()
        {
            PizzaDatabase.basket.ForEach(delegate (Products products) 
            {
                Console.WriteLine(products);
            });
        }

        public static void RemoveFromBasket(int productId)
        {
            Products itemToRemove = PizzaDatabase.basket.FirstOrDefault(item => item.Id == productId);

            if (itemToRemove != null)
            {
                PizzaDatabase.basket.Remove(itemToRemove);
                Console.WriteLine($"{itemToRemove.PizzaName} removed from the basket.");
            }
            else
            {
                Console.WriteLine("Item not found in the basket.");
            }
        }
    }
}
