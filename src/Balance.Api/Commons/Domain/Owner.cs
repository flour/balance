using System.ComponentModel.DataAnnotations;
using Balance.Api.Commons.Enums;

namespace Balance.Api.Commons.Domain;

public class Owner
{
    public int Id { get; set; }
    [MaxLength(255)] public string Name { get; set; }
    public OwnerType Type { get; set; }
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public DateTime Updated { get; set; } = DateTime.UtcNow;

    public List<Account> Accounts { get; set; } = new();
}