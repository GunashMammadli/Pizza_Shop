namespace PizzaUser.Exceptions
{
    public class UserExistException : System.Exception
    {
        public UserExistException()
        {
        }

        public UserExistException(string? message) : base(message)
        {
        }
    }
}
