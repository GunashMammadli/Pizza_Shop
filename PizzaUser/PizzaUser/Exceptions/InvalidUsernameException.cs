﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaUser.Exceptions
{
    public class InvalidUsernameException : Exception
    {
        public InvalidUsernameException()
        {
        }

        public InvalidUsernameException(string? message) : base(message)
        {
        }
    }
}
