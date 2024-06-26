﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_Model_Library.Exceptions
{
    public class NoCartWithGivenIdException : Exception
    {
        string message;
        public NoCartWithGivenIdException()
        {
            message = "Cart with the given Id is not present";
        }
        public override string Message => message;
    }
}
