using PizzaUser.Database;
using PizzaUser.Models;
using PizzaUser.PizzaServices;
using PizzaUser.Services;
using static System.Net.Mime.MediaTypeNames;
using Colorful;
using Console = Colorful.Console;
using System.Drawing;

namespace PizzaUser
{
    public class Program
    {
        static void Main(string[] args)
        {
                string logo = @"  __  __                                                 _         ____  _                  
 |  \/  | __ _ _ __ ___  _ __ ___   __ _       _ __ ___ (_) __ _  |  _ \(_)__________ _ ___ 
 | |\/| |/ _` | '_ ` _ \| '_ ` _ \ / _` |_____| '_ ` _ \| |/ _` | | |_) | |_  /_  / _` / __|
 | |  | | (_| | | | | | | | | | | | (_| |_____| | | | | | | (_| | |  __/| |/ / / / (_| \__ \
 |_|  |_|\__,_|_| |_| |_|_| |_| |_|\__,_|     |_| |_| |_|_|\__,_| |_|   |_/___/___\__,_|___/";
                Console.WriteLine(logo, Color.Red);
                string bar = "Welcome to Mamma-Mia Pizzas...";
                for (int i = 0; i < bar.Length; i++)
                {
                    Console.SetCursorPosition(i, 5);
                    Console.WriteLine(bar[i], Color.Red);
                    Thread.Sleep(100);
                }
            while (true)
            {
                
            Bc:
                Console.WriteLine("\nChoose from below option: \n1. Sign up. \n2. Login. \n3. Exit", Color.Yellow);
                int choose = Convert.ToInt32(Console.ReadLine());
                switch (choose)
                {
                    case 1:

                        Users users = new Users();

                        Console.WriteLine("Name: ");
                        users.Name = Console.ReadLine();
                        Console.WriteLine("Password: ");
                        users.Password = Console.ReadLine();

                        UserServices.AddUser(users);

                        break;
                    case 2:
                        Console.WriteLine("Adi daxil edin: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Sifre daxil edin: ");
                        string password = Console.ReadLine();

                        foreach (var item in PizzaDatabase.users)
                        {
                            if (name == item.Name && password == item.Password)
                            {
                                Dc:
                                Console.WriteLine("Choose from below option: \n1. Look pizzas. \n2. Order pizza. \n3. Exit", Color.Yellow);
                                int choose1 = Convert.ToInt32(Console.ReadLine());

                                switch(choose1)
                                {
                                    case 1:
                                        PizzaServices.PizzaServices.GetAllPizza();
                                        break;
                                    case 3:
                                        goto Bc;
                                        break;
                                }
                                goto Dc;
                            }
                            else
                            {
                                Console.WriteLine("Bele user yoxdu");
                            }
                        }

                        if (name == "admin" && password == "admin")
                        {
                            Abc:
                            Console.WriteLine("\nChoose from below option: \n1. Pizzas. \n2. Users. \n3. Logout Admin", Color.Red);
                            int chooseadmin = Convert.ToInt32(Console.ReadLine());
                            switch (chooseadmin)
                            {
                                case 1:
                                    choose3:
                                    Console.WriteLine("\nChoose from below option: \n1. All pizza. \n2. Add pizza. \n3. Edit pizza by ID. \n4. Back");
                                    int choose3 = Convert.ToInt32(Console.ReadLine());
                                    switch (choose3) {  
                                        case 1:

                                            PizzaServices.PizzaServices.GetAllPizza();

                                            break;
                                        case 2:
                                            
                                            Products pizza = new Products();

                                            Console.WriteLine("Pizza Name: ");
                                            pizza.PizzaName = Console.ReadLine();
                                            Console.WriteLine("Pizza Price: ");
                                            pizza.Price = Convert.ToInt32(Console.ReadLine());

                                            PizzaServices.PizzaServices.AddPizza(pizza);

                                            break;
                                        case 3:
                                            Console.WriteLine("Edit id input: ");
                                            int editinp = Convert.ToInt32(Console.ReadLine());

                                            Products updatedProduct = PizzaServices.PizzaServices.UpProductById(editinp);
                                            Console.WriteLine("Name: ");
                                            updatedProduct.PizzaName = Console.ReadLine();
                                            Console.WriteLine("Price: ");
                                            updatedProduct.Price = Convert.ToInt32(Console.ReadLine());

                                            Console.WriteLine("Update successfull!!!");
                                            break;
                                        case 4:
                                            goto Abc;
                                            break;
                                    }
                                    goto choose3;
                                    break;
                                case 2:
                                    UserServices.AllUsers();
                                    break;
                                case 3:
                                    goto Bc;
                                    break;
                            }
                            goto Abc;
                        }

                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}