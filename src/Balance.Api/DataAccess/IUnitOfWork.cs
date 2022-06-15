using Balance.Api.DataAccess.Repositories;

namespace Balance.Api.DataAccess;

public interface IUnitOfWork
{
    IAccountsRepository Accounts { get; }
    IDocumentsRepository Documents { get; }
}