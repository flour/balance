using Balance.Api.Commons.Enums;

namespace Balance.Api.Commons.Events;

public class DocumentCreatedEvent
{
    public Guid Id { get; set; }

    public int ClientFromId { get; set; }
    public int ClientToId { get; set; }

    public Guid AccountFromId { get; set; }
    public Guid AccountToId { get; set; }

    public decimal AmountFrom { get; set; }
    public decimal AmountTo { get; set; }
    public decimal Fee { get; set; }

    public OperationStatus Status { get; set; }

    public DateTime Stamp { get; set; }
}