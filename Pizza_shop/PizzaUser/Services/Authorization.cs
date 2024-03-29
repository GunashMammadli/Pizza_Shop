﻿using PizzaUser.Database;
using PizzaUser.Exceptions;
using PizzaUser.Models;
using System.Text.RegularExpressions;

namespace PizzaUser.Services
{
    public static class Authorization
    {
        public static void SignUp()
        {
            try
            {
                Users users = new Users();

                Console.Write("Enter Name: ");
                users.Name = Console.ReadLine();
                for (int i = 0; i < users.Name.Length; i++)
                {
                    if (string.IsNullOrWhiteSpace(users.Name) || users.Name.Length < 3 || users.Name.Length > 16)
                    {
                        throw new UserNameInvalid("\nName length must be greater than 3 and less than 16.!!!");
                    }
                    if (users.Name[i] < 65 || users.Name[i] > 122)
                    {
                        throw new UserNameInvalid("\nInput string value.!!!");
                    }
                }
                Console.Write("Enter Surname: ");
                users.Surname = Console.ReadLine();
                for (int i = 0; i < users.Surname.Length; i++)
                {
                    if (string.IsNullOrWhiteSpace(users.Surname) || users.Surname.Length < 3 || users.Surname.Length > 16)
                    {
                        throw new UserSurnameInvalid("\nSurname length must be greater than 3 and less than 16.!!!");
                    }
                    if (users.Surname[i] < 65 || users.Surname[i] > 122)
                    {
                        throw new UserSurnameInvalid("\nInput string value.!!!");
                    }
                }
                Console.Write("Enter Username: ");
                users.Username = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(users.Username) || users.Username.Length < 6 || users.Username.Length > 12)
                {
                    throw new UserUsernameInvalid("\nUsername length must be greater than 6 and less than 12.!!!");
                }
                else
                {
                    foreach (var user in PizzaDatabase.users)
                    {
                        if (user.Username == users.Username)
                        {
                            throw new UserExistException("\nThis user already exists.!!!");
                        }
                    }
                }

                Console.Write("Enter Password: ");
                users.Password = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(users.Password) || !Regex.IsMatch(users.Password, @"^(?=.?[A-Z])(?=.?[a-z])(?=.*?[0-9]).{6,16}$"))
                {
                    throw new PasswordInvalid("\nPassword must be 6-16 in length, contain at least 1 uppercase, 1 lowercase letter and at least 1 number.");
                }
                UserServices.AddUser(users);

                Console.WriteLine($"\nUser {users.Username} Created...");

            }
            catch (UserNameInvalid ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (UserExistException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (UserSurnameInvalid ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (UserUsernameInvalid ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (PasswordInvalid ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
