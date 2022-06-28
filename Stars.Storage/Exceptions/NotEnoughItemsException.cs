namespace Stars.Storage.Exceptions;

public class NotEnoughItemsException : Exception
{
    public int Id { get; init; }
    
    public NotEnoughItemsException(int id)
    {
        Id = id;
    }
}