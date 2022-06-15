using System.ComponentModel.DataAnnotations;
using Balance.Api.Commons.Enums;

namespace Balance.Api.Commons.Domain;

public class OperationTemplate
{
    public int Id { get; set; }
    public OperationType Type { get; set; }
    
    [MaxLength(100)] public string DisplayName { get; set; }
    [MaxLength(512)] public string Description { get; set; }

    public bool Active { get; set; }

    public DateTime Created { get; set; } = DateTime.UtcNow;
    public DateTime Updated { get; set; } = DateTime.UtcNow;
}