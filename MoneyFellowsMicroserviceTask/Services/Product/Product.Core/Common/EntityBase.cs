namespace Products.Core.Common
{
    /// <summary>
    /// Entity base class contains the base properties that should exist on any entity
    /// </summary>
    public class EntityBase
    {
        public int Id { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string LastModifiedBy { get; set; }

        public DateTime LastModifiedDate { get; set; }

    }
}
