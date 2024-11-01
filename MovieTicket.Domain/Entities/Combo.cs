using MovieTicket.Domain.Enums;

namespace MovieTicket.Domain.Entities;

public class Combo
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public decimal? Price { get; set; }

    public string? Description { get; set; }

    public string? Image { get; set; }
    public ComboStatus? comboStatus { get; set; }
    public virtual ICollection<BillCombo> BillCombos { get; set; } = new List<BillCombo>();
}