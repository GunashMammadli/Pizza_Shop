using PizzaUser.Exceptions;
using System.Text.RegularExpressions;

namespace PizzaUser.Models
{
    public class Users
    {
        private static int _id;
        public int Id { get; }
        private string _name;
        private string _surname;
        private string _username;
        private int _age;
        private string _phoneNumber;
        private string _password;
        public string Name
        {
            get => _name;
            set
            {
                if (value.Length < 2 || value.Length > 16) throw new InvalidNameException("Name length must be between 3 and 15");
            }
        }
        public int Age
        {
            get => _age;
            set
            {
                if (value <= 18) throw new InvalidAgeException("Age must be greater than 18");
            }
        }
        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                if (!Regex.IsMatch(value, @"^\+994-(50)|(51)|(55)|(10)|(70)|(77)-[0-9]{3}-[0-9]{4}")) 
                    throw new InvalidPhoneNumberException("Invalid Phone Number");
            }
        }
        public string Password
        {
            get => _password;
            set
            {
                if (value.Length < 8 || !Regex.IsMatch(value, @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{8,}$"))
                    throw new InvalidPasswordException("Invalid Password");
            }
        }

        public string Surname
        {
            get => _surname;
            set
            {
                if (value.Length < 2 || value.Length > 16) throw new InvalidSurnameException("Surname length must be between 3 and 15");
            }
        }
        public string Username
        {
            get => _username;
            set
            {
                if (value.Length < 2 || value.Length > 17) throw new InvalidUsernameException("Username length must be between 3 and 16");
            }
        }

        public Users()
        {
            _id++;
            Id = _id;
        }

        public Users(string name, string surname, string username, int age, string password) : this()
        {
            Name = name;
            Surname = surname;
            Username = username;
            Age = age;
            Password = password;
        }


        public override string ToString()
        {
            return $"{Id}. {Name} {Surname} {Username}";
        }
    }
}
