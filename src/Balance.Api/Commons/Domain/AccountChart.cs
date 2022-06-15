using System.ComponentModel.DataAnnotations;

namespace Balance.Api.Commons.Domain;

public class AccountChart
{
    public int Id { get; set; }
    [MaxLength(10)] public string Number { get; set; }
    public bool Active { get; set; }
    public bool NegativeAllowed { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }

    public List<Account> Accounts { get; set; } = new();
}