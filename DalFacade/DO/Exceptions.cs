namespace DO;

[Serializable]
//Specific Object does not exist.
public class DalDoesNotExistException : Exception
{
    public DalDoesNotExistException(string? message) : base(message) { }
}
//Specific Object already exist.
public class DalAlreadyExistsException : Exception
{
    public DalAlreadyExistsException(string? message) : base(message) { }
}
//Objects does not exist at all.
public class DalsDoesNotExistException : Exception
{
    public DalsDoesNotExistException(string? message) : base(message) { }
}
