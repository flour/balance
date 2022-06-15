using Balance.Api.DataAccess.Repositories;

namespace Balance.Api.DataAccess.Internals;

internal class UnitOfWork : IUnitOfWork
{
    private readonly Lazy<IAccountsRepository> _accounts;
    private readonly Lazy<IDocumentsRepository> _documents;

    public UnitOfWork(AppDbContext context)
    {
        _accounts = new Lazy<IAccountsRepository>(() => new AccountsRepository(context));
        _documents = new Lazy<IDocumentsRepository>(() => new DocumentsRepository(context));
    }

    public IAccountsRepository Accounts => _accounts.Value;
    public IDocumentsRepository Documents => _documents.Value;
}