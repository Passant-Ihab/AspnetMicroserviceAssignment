namespace Products.Application.Exceptions
{
    public class EntityNotFoundException : ApplicationException
    {
        public EntityNotFoundException(string name, object key): base($"Couldn't find entity \"{name}\" ({key})") { }
    }
}
