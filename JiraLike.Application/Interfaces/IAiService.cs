namespace JiraLike.Application.Interfaces
{
    public interface IAiService
    {
        Task<string> Generate(string prompt);
    }
}
