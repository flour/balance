using System.ComponentModel.DataAnnotations;
using Balance.Api.Commons.Enums;

namespace Balance.Api.Commons.Domain;

public class Account
{
    public Guid Id { get; set; }
    public int OwnerId { get; set; }
    public int AccountChartId { get; set; }
    [MaxLength(255)] public string Name { get; set; }
    public AccountStatus Status { get; set; }

    public decimal BalanceFact { get; set; }
    public decimal BalanceReserved { get; set; }
    public decimal BalancePlan { get; set; }

    public DateTime Created { get; set; } = DateTime.UtcNow;
    public DateTime Updated { get; set; } = DateTime.UtcNow;

    public Owner Owner { get; set; }
    public AccountChart AccountChart { get; set; }
}