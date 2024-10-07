namespace MovieTicket.Domain.Entities;

public class Combo
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public decimal? Price { get; set; }
    public virtual ICollection<BillCombo> BillCombos { get; set; } = new List<BillCombo>();
}