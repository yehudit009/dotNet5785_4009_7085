namespace DO;

[Serializable]
//אובייקט לא קיים
public class DalDoesNotExistException : Exception
{
    public DalDoesNotExistException(string? message) : base(message) { }
}
//אובייקט קיים
public class DalAlreadyExistsException : Exception
{
    public DalAlreadyExistsException(string? message) : base(message) { }
}
//לא קיימים לי אובייקטים כלל
public class DalsDoesNotExistException : Exception
{
    public DalsDoesNotExistException(string? message) : base(message) { }
}
