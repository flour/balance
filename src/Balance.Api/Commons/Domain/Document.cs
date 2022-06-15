using Balance.Api.Commons.Enums;

namespace Balance.Api.Commons.Domain;

public class Document
{
    public Guid Id { get; set; } = new();
    public int ClientFromId { get; set; }
    public int ClientToId { get; set; }

    public Guid AccountFromId { get; set; }
    public Guid AccountToId { get; set; }

    public decimal AmountFrom { get; set; }
    public decimal AmountTo { get; set; }
    public decimal Fee { get; set; }

    public OperationStatus Status { get; set; }
    public OperationType Type { get; set; }

    public DateTime Created { get; set; } = DateTime.UtcNow;
    public DateTime Updated { get; set; } = DateTime.UtcNow;

    public Account AccountFrom { get; set; }
    public Account AccountTo { get; set; }
    public List<DocumentEntry> Entries { get; set; } = new();
}