using PizzaUser.Models;
using PizzaUser.PizzaServices;
using PizzaUser.Services;

namespace PizzaUser
{
    public class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Choose from below option: \n1. Sign up. \n2. Login.");
                int choose = Convert.ToInt32(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        Users users = new Users();

                        users.Name = "Rashad";
                        users.Surname = "Salimov";
                        users.Password = "12345";

                        UserServices.AddUser(users);

                        break;
                    case 2:
                        Console.WriteLine("Adi daxil edin: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Sifre daxil edin: ");
                        string password = Console.ReadLine();

                       
                        break;
                }
            }
        }
    }
}