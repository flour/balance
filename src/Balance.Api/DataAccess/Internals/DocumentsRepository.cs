using Balance.Api.Commons.Domain;
using Balance.Api.DataAccess.Repositories;

namespace Balance.Api.DataAccess.Internals;

internal class DocumentsRepository : BaseRepository<Document>, IDocumentsRepository
{
    private readonly AppDbContext _context;

    public DocumentsRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}