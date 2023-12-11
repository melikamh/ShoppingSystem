namespace ShoppingSystem.Domain.Repositories
{
    public interface IUnitOfWork
    {
        int SaveChanges(CancellationToken cancellationToken = default);
    }
}
