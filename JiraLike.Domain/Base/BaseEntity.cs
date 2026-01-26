/// <summary>
/// Base Entity is abstract bcz it shared.
/// </summary>
namespace JiraLike.Domain.Base
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        
        //SoftDelete
        public bool IsDeleted { get; set; } = false;

        //Audit strategy
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}
