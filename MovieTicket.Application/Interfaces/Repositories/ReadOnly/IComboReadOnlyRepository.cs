using MovieTicket.Application.DataTransferObjs.Combo;
using MovieTicket.Application.ValueObjs.Paginations;

namespace MovieTicket.Application.Interfaces.Repositories.ReadOnly
{
    public interface IComboReadOnlyRepository
    {
        Task<IQueryable<ComboDto>> GetAllAsync();
        Task<PageList<ComboDto>> GetAllPaging(PagingParameters pagingParameters);
        Task<ComboDto?> GetByIdAsync(Guid id);
    }
}