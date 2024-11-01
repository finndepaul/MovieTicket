using MovieTicket.Application.DataTransferObjs.Combo;
namespace MovieTicket.BlazorServer.Services.Interfaces
{
    public interface IComboService
    {
        Task<List<ComboDto>> GetAll();
        Task<ComboDto> GetById(Guid id);
        Task<ComboDto> Create(CreateComboRequest combo);
        Task<ComboDto> Update(Guid id, UpdateComboRequest combo);
        Task<ComboDto> Delete(Guid id);
    }
}
