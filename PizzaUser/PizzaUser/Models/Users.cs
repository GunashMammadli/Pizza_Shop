using PizzaUser.Exceptions;

namespace PizzaUser.Models
{
    public class Users
    {
        private static string _name;
        private static string _password;
        private static int _id;
        public int Id;
        public Users()
        {
            _id++;
            Id = _id;
        }
        public string Name { 
            get => _name; 
            set 
            {
                if (value.Length < 3 || value.Length > 16) throw new UserNameInvalid("Name length must be greater than 3 and less than 16!!!");
            } 
        }
        public string Surname { get; set; }
        public string Password {
            get => _password;
            set
            {
                if (value.Length < 6 || value.Length > 16) throw new UserNameInvalid("Password length must be greater than 6 and less than 16!!!");
            }
        }

        public override string ToString()
        {
            return $"{Id}. {Name} {Surname}";
        }
    }
}
