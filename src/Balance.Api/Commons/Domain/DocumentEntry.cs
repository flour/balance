namespace Balance.Api.Commons.Domain;

public class DocumentEntry
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid DocumentId { get; set; }
    
    public decimal Credit { get; set; }
    public decimal Debit { get; set; }

    public int Order { get; set; }
    public int DebitFactor { get; set; }
    public int CreditFactor { get; set; }

    public Document Document { get; set; }
}