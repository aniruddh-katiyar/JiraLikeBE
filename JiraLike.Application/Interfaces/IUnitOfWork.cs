namespace JiraLike.Application.Interfaces
{
    using System.Threading.Tasks;

    public interface IUnitOfWork
    {
        Task SaveChangesAsync(CancellationToken ck);
    }
}
