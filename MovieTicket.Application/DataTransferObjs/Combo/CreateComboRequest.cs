using MovieTicket.Domain.Enums;

namespace MovieTicket.Application.DataTransferObjs.Combo
{
    public class CreateComboRequest
    {
        public string? Name { get; set; }

        public decimal? Price { get; set; }
        public string? Description { get; set; }

        public string? Image { get; set; }
        public ComboStatus? comboStatus { get; set; }
    }
}