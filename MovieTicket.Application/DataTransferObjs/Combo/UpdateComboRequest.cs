using MovieTicket.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace MovieTicket.Application.DataTransferObjs.Combo
{
    public class UpdateComboRequest
    {
        [Required(ErrorMessage = "Tên là bắt buộc.")]
        [StringLength(100, ErrorMessage = "Độ dài tên không được vượt quá 100.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Giá là bắt buộc.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Giá phải lớn hơn 0.")]
        public decimal? Price { get; set; }

        [StringLength(500, ErrorMessage = "Độ dài mô tả không được quá 500.")]
        public string? Description { get; set; }

        public string? Image { get; set; }

        [Required(ErrorMessage = "Trạng thái Combo là bắt buộc.")]
        public ComboStatus? comboStatus { get; set; }
    }
}