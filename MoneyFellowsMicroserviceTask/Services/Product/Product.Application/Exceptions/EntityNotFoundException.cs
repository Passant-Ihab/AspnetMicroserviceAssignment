namespace Products.Application.Exceptions
{
    /// <summary>
    /// Custom exception for the generic exceptions
    /// </summary>
    public class EntityNotFoundException : ApplicationException
    {
        public EntityNotFoundException(string name, object key): base($"Couldn't find entity \"{name}\" ({key})") { }
    }
}
