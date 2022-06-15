using Balance.Api.DataAccess.Repositories;

namespace Balance.Api.DataAccess.Internals;

internal class AccountsRepository : IAccountsRepository
{
    private readonly AppDbContext _context;

    public AccountsRepository(AppDbContext context)
    {
        _context = context;
    }
}