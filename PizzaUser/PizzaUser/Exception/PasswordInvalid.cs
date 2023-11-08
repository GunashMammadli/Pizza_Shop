namespace PizzaUser.Exceptions
{
    internal class PasswordInvalid : Exception
    {
        public PasswordInvalid()
        {
        }

        public PasswordInvalid(string? message) : base(message)
        {
        }
    }
}