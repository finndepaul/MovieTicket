using MovieTicket.Application.DataTransferObjs.Combo;

namespace MovieTicket.Application.Interfaces.Repositories.ReadWrite
{
    public interface IComboReadWriteRepository
    {
        Task<ComboDto> CreateAsync(CreateComboRequest addComboRequest);

        Task<ComboDto?> UpdateAsync(Guid id, UpdateComboRequest updateComboRequest);

        Task<ComboDto?> DeleteAsync(Guid id);
    }
}