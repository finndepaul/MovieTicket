using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MovieTicket.Application.DataTransferObjs.CinemaCenter;
using MovieTicket.Application.Interfaces.Repositories.ReadWrite;
using MovieTicket.Application.ValueObjs.ViewModels;
using MovieTicket.Domain.Entities;
using MovieTicket.Infrastructure.Database.AppDbContexts;

namespace MovieTicket.Infrastructure.Implements.Repositories.ReadWrite
{
    public class CinemaCenterReadWriteRepository : ICinemaCenterReadWriteRepository
    {
        private readonly MovieTicketReadWriteDbContext _movieTicket;

        public CinemaCenterReadWriteRepository(MovieTicketReadWriteDbContext movieTicket)
        {
            _movieTicket = movieTicket;
        }

        public async Task<ResponseObject<CinemaCenter>> Create(CinemaCenter cinemaCenter)
        {
            // Check tồn tại
            var cinemaCenterItem = await _movieTicket.CinemaCenters.FirstOrDefaultAsync(x => x.Name == cinemaCenter.Name);
            if (cinemaCenter == null)
            {
                return new ResponseObject<CinemaCenter>
                {
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Rạp chiếu không được để trống",
                    Data = null
                };
            }
            // Check tồn tại
            if (cinemaCenterItem != null)
            {
                return new ResponseObject<CinemaCenter>
                {
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Tên rạp chiếu đã tồn tại",
                    Data = null
                };
            }
            cinemaCenter.Id = Guid.NewGuid();
            await _movieTicket.AddAsync(cinemaCenter);
            await _movieTicket.SaveChangesAsync();
            return new ResponseObject<CinemaCenter>
            {
                Status = StatusCodes.Status200OK,
                Message = "Tạo thành công",
                Data = cinemaCenter
            };
        }

		public async Task<ResponseObject<CinemaCenter>> Delete(Guid id)
		{
			// Tìm CinemaCenter cần xóa
			var cinemaCenter = await _movieTicket.CinemaCenters.FindAsync(id);
			if (cinemaCenter == null)
			{
				return new ResponseObject<CinemaCenter>
				{
					Data = null,
					Status = StatusCodes.Status400BadRequest,
					Message = "Không tìm rạp chiếu"
				};
			}
			
			var hasReferences = await _movieTicket.Cinemas.AnyAsync(c => c.CinemaCenterId == id); 
			if (hasReferences)
			{
				return new ResponseObject<CinemaCenter>
				{
					Data = null,
					Status = StatusCodes.Status400BadRequest,
					Message = "Không thể xóa Cinema Center vì nó được tham chiếu đến Cinema"
				};
			}

			// Xóa CinemaCenter
			_movieTicket.CinemaCenters.Remove(cinemaCenter);
			await _movieTicket.SaveChangesAsync();

			return new ResponseObject<CinemaCenter>
			{
				Data = cinemaCenter,
				Status = StatusCodes.Status200OK,
				Message = "Xóa rạp chiếu thành công"
			};
		}


		public async Task<ResponseObject<CinemaCenter>> Update(Guid id, CinemaCenterUpdateRequest cinemaCenter)
		{
			var cinemaCenterItem = await _movieTicket.CinemaCenters.FindAsync(id);

			if (cinemaCenterItem == null)
			{
				return new ResponseObject<CinemaCenter>
				{
					Data = null,
					Status = StatusCodes.Status400BadRequest,
					Message = "Rạp chiếu không tồn tại"
				};
			}

			var duplicateNameCheck = await _movieTicket.CinemaCenters
				.AnyAsync(c => c.Name == cinemaCenter.Name && c.Id != id);

			if (duplicateNameCheck)
			{
				return new ResponseObject<CinemaCenter>
				{
					Data = null,
					Status = StatusCodes.Status400BadRequest,
					Message = "Tên rạp chiếu đã tồn tại"
				};
			}

			cinemaCenterItem.Name = cinemaCenter.Name;
			cinemaCenterItem.Address = cinemaCenter.Address;
			cinemaCenterItem.AddresCity = cinemaCenter.AddresCity;
            cinemaCenterItem.AddressMap = cinemaCenter.AddressMap;

			_movieTicket.CinemaCenters.Update(cinemaCenterItem);
			await _movieTicket.SaveChangesAsync();

			return new ResponseObject<CinemaCenter>
			{
				Data = cinemaCenterItem,
				Status = StatusCodes.Status200OK,
				Message = "Update thành công"
			};
		}

	}
}