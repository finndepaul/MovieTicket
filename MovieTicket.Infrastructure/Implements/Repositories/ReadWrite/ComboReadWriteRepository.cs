using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MovieTicket.Application.DataTransferObjs.Combo;
using MovieTicket.Application.Interfaces.Repositories.ReadWrite;
using MovieTicket.Application.ValueObjs.ViewModels;
using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Enums;
using MovieTicket.Infrastructure.Database.AppDbContexts;

namespace MovieTicket.Infrastructure.Implements.Repositories.ReadWrite
{
    public class ComboReadWriteRepository : IComboReadWriteRepository
    {
        private readonly MovieTicketReadWriteDbContext _dbContext;
        private readonly IMapper _mapper;

        public ComboReadWriteRepository(MovieTicketReadWriteDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ResponseObject<ComboDto>> CreateAsync(CreateComboRequest addComboRequest)
        {
            if (addComboRequest == null)
            {
                return new ResponseObject<ComboDto>
                {
                    Status = StatusCodes.Status400BadRequest,
                    Message = "AddComboRequest cannot be null.",
                    Data = null
                };
            }

            // Check for duplicate name
            var existingCombo = await _dbContext.Combos
                .FirstOrDefaultAsync(c => c.Name == addComboRequest.Name);
            if (existingCombo != null)
            {
                return new ResponseObject<ComboDto>
                {
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Đã tồn tại một combo có cùng tên.",
                    Data = null
                };
            }

            var combo = _mapper.Map<Combo>(addComboRequest);
            if (combo == null)
            {
                return new ResponseObject<ComboDto>
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Message = "Mapping resulted in a null Combo entity.",
                    Data = null
                };
            }

            combo.ComboStatus = ComboStatus.Available;
            await _dbContext.Combos.AddAsync(combo);
            await _dbContext.SaveChangesAsync();

            var comboDto = _mapper.Map<ComboDto>(combo);
            if (comboDto == null)
            {
                return new ResponseObject<ComboDto>
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Message = "Mapping resulted in a null ComboDto.",
                    Data = null
                };
            }

            return new ResponseObject<ComboDto>
            {
                Status = StatusCodes.Status200OK,
                Message = "Tạo combo thành công",
                Data = comboDto
            };
        }

        public async Task<ComboDto?> DeleteAsync(Guid id)
        {
            if (id == Guid.Empty) // Kiểm tra nếu id là Guid.Empty
            {
                throw new ArgumentException("Invalid ID.", nameof(id)); // Ném ra ngoại lệ nếu id không hợp lệ
            }

            var result = await _dbContext.Combos.FindAsync(id); // Tìm combo theo id
            if (result == null) // Kiểm tra nếu không tìm thấy combo
            {
                return null; // Trả về null nếu không tìm thấy combo
            }

            _dbContext.Combos.Remove(result);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<ComboDto>(result);
        }

        public async Task<ResponseObject<ComboDto>> UpdateAsync(Guid id, UpdateComboRequest updateComboRequest)
        {
            if (id == Guid.Empty)
            {
                return new ResponseObject<ComboDto>
                {
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Invalid ID.",
                    Data = null
                };
            }

            if (updateComboRequest == null)
            {
                return new ResponseObject<ComboDto>
                {
                    Status = StatusCodes.Status400BadRequest,
                    Message = "UpdateComboRequest cannot be null.",
                    Data = null
                };
            }

            var existingCombo = await _dbContext.Combos.FirstOrDefaultAsync(c => c.Name == updateComboRequest.Name && c.Id != id);
            if (existingCombo != null)
            {
                return new ResponseObject<ComboDto>
                {
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Đã tồn tại một combo có cùng tên.",
                    Data = null
                };
            }

            var result = await _dbContext.Combos.FindAsync(id);
            if (result == null)
            {
                return new ResponseObject<ComboDto>
                {
                    Status = StatusCodes.Status404NotFound,
                    Message = "Combo not found.",
                    Data = null
                };
            }

            _mapper.Map(updateComboRequest, result);
            await _dbContext.SaveChangesAsync();

            var comboDto = _mapper.Map<ComboDto>(result);
            if (comboDto == null)
            {
                return new ResponseObject<ComboDto>
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Message = "Mapping resulted in a null ComboDto.",
                    Data = null
                };
            }

            return new ResponseObject<ComboDto>
            {
                Status = StatusCodes.Status200OK,
                Message = "Combo updated successfully.",
                Data = comboDto
            };
        }

    }
}