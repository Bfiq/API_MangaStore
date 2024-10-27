namespace API_Manga_ecommerce.Exceptions;

public class InvalidEmailFormatException : Exception
{
    public InvalidEmailFormatException(string message) : base(message)
    {
    }
}

public class EmailAlreadyExistsException : Exception
{
    public EmailAlreadyExistsException(string message) : base(message)
    {
    }
}