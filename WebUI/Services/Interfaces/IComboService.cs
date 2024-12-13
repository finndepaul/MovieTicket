using MovieTicket.Application.DataTransferObjs.Combo;
using MovieTicket.Application.ValueObjs.Paginations;
using MovieTicket.Application.ValueObjs.ViewModels;
namespace WebUI.Services.Interfaces
{
    public interface IComboService
    {
        Task<List<ComboDto>> GetAll();
        Task<PageList<ComboDto>> GetAllPaging(PagingParameters pagingParameters);
        Task<ComboDto> GetById(Guid id);
        Task<ResponseObject<ComboDto>> Create(CreateComboRequest combo);
        Task<ResponseObject<ComboDto>> Update(Guid id, UpdateComboRequest combo);
        Task<ComboDto> Delete(Guid id);
    }
}
