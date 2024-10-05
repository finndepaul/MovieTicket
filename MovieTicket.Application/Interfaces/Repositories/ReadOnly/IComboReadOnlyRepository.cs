using MovieTicket.Application.DataTransferObjs.Combo;

namespace MovieTicket.Application.Interfaces.Repositories.ReadOnly
{
    public interface IComboReadOnlyRepository
    {
        Task<IQueryable<ComboDto>> GetAllAsync();

        Task<ComboDto?> GetByIdAsync(Guid id);
    }
}