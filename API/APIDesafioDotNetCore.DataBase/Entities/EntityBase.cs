namespace APIDesafioDotNetCore.BancoDeDados.Entities
{
    /// <summary>
    /// Entity base class
    /// </summary>
    public abstract class EntityBase
    {
        /// <summary>
        /// Init a <see cref="EntityBase"/> object
        /// </summary>
        /// <param name="createdAt">Object criation date</param>
        /// <param name="updatedAt">Object update date</param>
        public EntityBase(DateTime createdAt, DateTime updatedAt)
        {
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        /// <summary>
        /// Object criation date
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Object update date
        /// </summary>
        public DateTime UpdatedAt { get; set; }
    }
}
