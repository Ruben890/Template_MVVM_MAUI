namespace Appliaction.Interfaces
{
    public interface IUnitOfWork
    {
        Task BeginAsync();
        Task BulkSaveChangesAsync();
        Task CommitAsync();
        Task RollbackAsync();
        Task SaveAsync();
    }
}
