namespace PizzaUser.Exceptions
{
    internal class UserNameInvalid : Exception
    {
        public UserNameInvalid()
        {
        }

        public UserNameInvalid(string? message) : base(message)
        {
        }
    }
}