namespace Products.Core.Common
{
    /// <summary>
    /// Entity base class contains the base properties that should exist on any entity
    /// </summary>
    public class EntityBase
    {
        public int Id { get; protected set; }

        public string CreatedBy { get; protected set; }

        public DateTime CreatedDate { get; protected set; }

        public string LastModifiedBy { get; protected set; }

        public DateTime LastModifiedDate { get; protected set; }

    }
}
