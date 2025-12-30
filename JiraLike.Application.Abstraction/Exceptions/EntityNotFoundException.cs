/// <summary>
/// Represents a Custom Exception.
/// Used when entity is not exist.
/// </summary>
namespace JiraLike.Application.Abstraction.Exceptions
{
    public sealed class EntityNotFoundException<TEntity> : Exception
        where TEntity : class
    {
        public object Key { get; }

        public EntityNotFoundException(object key)
            : base($"{typeof(TEntity).Name} with identifier '{key}' was not found.")
        {
            Key = key;
        }
    }
}
