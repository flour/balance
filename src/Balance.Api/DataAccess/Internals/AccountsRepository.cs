using Balance.Api.Commons.Domain;
using Balance.Api.DataAccess.Repositories;

namespace Balance.Api.DataAccess.Internals;

internal class AccountsRepository : BaseRepository<Account>, IAccountsRepository
{
    private readonly AppDbContext _context;

    public AccountsRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}