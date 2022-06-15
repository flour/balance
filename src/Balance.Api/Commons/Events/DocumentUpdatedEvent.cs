using Balance.Api.Commons.Enums;

namespace Balance.Api.Commons.Events;

public class DocumentUpdatedEvent
{
    public Guid DocumentId { get; set; }
    public OperationStatus Status { get; set; }
    public DateTime Stamp { get; set; }
}