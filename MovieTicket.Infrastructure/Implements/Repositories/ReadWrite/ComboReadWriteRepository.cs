using AutoMapper;
using MovieTicket.Application.DataTransferObjs.Combo;
using MovieTicket.Application.Interfaces.Repositories.ReadWrite;
using MovieTicket.Domain.Entities;
using MovieTicket.Infrastructure.Database.AppDbContexts;

namespace MovieTicket.Infrastructure.Implements.Repositories.ReadWrite
{
    public class ComboReadWriteRepository : IComboReadWriteRepository
    {
        private readonly MovieTicketReadWriteDbContext dbContext;
        private readonly IMapper mapper;

        public ComboReadWriteRepository(MovieTicketReadWriteDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<ComboDto> CreateAsync(CreateComboRequest addComboRequest)
        {
            if (addComboRequest == null) // Kiểm tra nếu addComboRequest là null
            {
                throw new ArgumentNullException(nameof(addComboRequest), "AddComboRequest cannot be null."); // Ném ra ngoại lệ nếu addComboRequest là null
            }

            var combo = mapper.Map<Combo>(addComboRequest); // Ánh xạ từ AddComboRequest sang Combo
            if (combo == null) // Kiểm tra nếu combo là null
            {
                throw new InvalidOperationException("Mapping resulted in a null Combo entity."); // Ném ra ngoại lệ nếu ánh xạ trả về null
            }

            await dbContext.Combos.AddAsync(combo);
            await dbContext.SaveChangesAsync();

            return mapper.Map<ComboDto>(combo) ?? throw new InvalidOperationException("Mapping resulted in a null ComboDto."); // Ánh xạ từ Combo sang ComboDto và trả về, nếu null thì ném ra ngoại lệ
        }

        public async Task<ComboDto?> DeleteAsync(Guid id)
        {
            if (id == Guid.Empty) // Kiểm tra nếu id là Guid.Empty
            {
                throw new ArgumentException("Invalid ID.", nameof(id)); // Ném ra ngoại lệ nếu id không hợp lệ
            }

            var result = await dbContext.Combos.FindAsync(id); // Tìm combo theo id
            if (result == null) // Kiểm tra nếu không tìm thấy combo
            {
                return null; // Trả về null nếu không tìm thấy combo
            }

            dbContext.Combos.Remove(result);
            await dbContext.SaveChangesAsync();
            return mapper.Map<ComboDto>(result);
        }

        public async Task<ComboDto?> UpdateAsync(Guid id, UpdateComboRequest updateComboRequest)
        {
            if (id == Guid.Empty) // Kiểm tra nếu id là Guid.Empty
            {
                throw new ArgumentException("Invalid ID.", nameof(id)); // Ném ra ngoại lệ nếu id không hợp lệ
            }

            if (updateComboRequest == null) // Kiểm tra nếu updateComboRequest là null
            {
                throw new ArgumentNullException(nameof(updateComboRequest), "UpdateComboRequest cannot be null."); // Ném ra ngoại lệ nếu updateComboRequest là null
            }

            var result = await dbContext.Combos.FindAsync(id); // Tìm combo theo id
            if (result == null) // Kiểm tra nếu không tìm thấy combo
            {
                return null; // Trả về null nếu không tìm thấy combo
            }

            mapper.Map(updateComboRequest, result);
            await dbContext.SaveChangesAsync();
            return mapper.Map<ComboDto>(result);
        }
    }
}