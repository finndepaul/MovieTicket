using MovieTicket.Application.DataTransferObjs.Combo;
using MovieTicket.Application.ValueObjs.ViewModels;

namespace MovieTicket.Application.Interfaces.Repositories.ReadWrite
{
    public interface IComboReadWriteRepository
    {
        Task<ResponseObject<ComboDto>> CreateAsync(CreateComboRequest addComboRequest);

        Task<ResponseObject<ComboDto>?> UpdateAsync(Guid id, UpdateComboRequest updateComboRequest);

        Task<ComboDto?> DeleteAsync(Guid id);
    }
}