namespace tut8.Exceptions;

public class CreatedAtException : Exception
{
    public CreatedAtException()
        : base("The date of creation of the request should be greater than the date of the creation of the order")
    {
    }
}