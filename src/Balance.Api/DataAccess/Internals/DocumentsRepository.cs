using Balance.Api.DataAccess.Repositories;

namespace Balance.Api.DataAccess.Internals;

internal class DocumentsRepository : IDocumentsRepository
{
    private readonly AppDbContext _context;

    public DocumentsRepository(AppDbContext context)
    {
        _context = context;
    }
}