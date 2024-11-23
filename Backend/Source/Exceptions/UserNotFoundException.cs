﻿namespace Source.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException() : base("Usuário não encontrado.")
        {
        }

        public UserNotFoundException(string message) : base(message)
        {
        }

        public UserNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
