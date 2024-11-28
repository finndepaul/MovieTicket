using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MovieTicket.Application.DataTransferObjs;
using MovieTicket.Application.DataTransferObjs.Bill;
using MovieTicket.Application.DataTransferObjs.Film;
using MovieTicket.Application.Interfaces.Repositories.ReadWrite;
using MovieTicket.Application.ValueObjs.ViewModels;
using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Enums;
using MovieTicket.Infrastructure.Database.AppDbContexts;
using System.Linq;

namespace MovieTicket.Infrastructure.Implements.Repositories.ReadWrite
{
    public class FilmReadWriteRepository : IFilmReadWriteRepository
    {   
        private readonly MovieTicketReadWriteDbContext _context;
        private readonly IMapper _mapper;
        public FilmReadWriteRepository(MovieTicketReadWriteDbContext movieTicketReadWriteDbContext, IMapper mapper)
        {
            _context = movieTicketReadWriteDbContext;
            _mapper = mapper;
        }
        public async Task<ResponseObject<FilmDto>> CreateFilm(FilmCreateRequest filmCreateRequest)
        {
            var film = _mapper.Map<Film>(filmCreateRequest);
            film.CreatDate = DateTime.Now.Date.AddHours(DateTime.Now.Hour).AddMinutes(DateTime.Now.Minute);
            await _context.Films.AddAsync(film);

            foreach (var id in filmCreateRequest.ScreenTypeIds)
            {
                var filmScreenType = new FilmScreenType
                {
                    FilmId = film.Id,
                    ScreenTypeId = id
                };
                await _context.FilmScreenTypes.AddAsync(filmScreenType);
            }

            foreach (var id in filmCreateRequest.TranslationTypeIds)
            {
                var filmTranslationType = new FilmTranslationType
                {
                    FilmId = film.Id,
                    TranslationTypeId = id
                };
                await _context.FilmTranslationTypes.AddAsync(filmTranslationType);
            }
            await _context.SaveChangesAsync();
            var filmDto = _mapper.Map<FilmDto>(film);
            return new ResponseObject<FilmDto>
            {
                Data = filmDto,
                Status = StatusCodes.Status201Created,
                Message = "Tạo phim thành công"
            };
        }

        public async Task<ResponseObject<FilmDto>> DeleteFilm(Guid id)
        {
            var film = await (from f in _context.Films
                              .Include(f => f.FilmScreenTypes)
                              .Include(f => f.FilmTranslationTypes)
                              where f.Id == id
                              select f).FirstOrDefaultAsync();

            if (film == null)
            {
                return new ResponseObject<FilmDto>
                {
                    Data = null,
                    Status = StatusCodes.Status404NotFound,
                    Message = "Không tìm thấy phim"
                };
            }

            // Check if there are any schedules associated with the film
            var hasSchedules = await _context.Schedules.AnyAsync(s => s.FilmId == id);
            if (hasSchedules)
            {
                return new ResponseObject<FilmDto>
                {
                    Data = null,
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Không thể xóa phim vì phim có lịch chiếu liên quan. Vui lòng xóa lịch chiếu trước."
                };
            }

            // Remove related FilmScreenTypes
            _context.FilmScreenTypes.RemoveRange(film.FilmScreenTypes);

            // Remove related FilmTranslationTypes
            _context.FilmTranslationTypes.RemoveRange(film.FilmTranslationTypes);

            // Remove the film itself
            _context.Films.Remove(film);

            await _context.SaveChangesAsync();

            return new ResponseObject<FilmDto>
            {
                Data = null,
                Status = StatusCodes.Status200OK,
                Message = "Xóa phim thành công"
            };
        }


        public async Task<ResponseObject<FilmDto>> UpdateFilm(Guid id, FilmUpdateRequest filmUpdateRequest)
        {
            var film = await (from f in _context.Films
                              where f.Id == id
                              select f).FirstOrDefaultAsync();

            if (film == null)
            {
                return new ResponseObject<FilmDto>
                {
                    Data = null,
                    Status = StatusCodes.Status404NotFound,
                    Message = "Không tìm thấy phim"
                };
            }

            // Manually load related entities
            await _context.Entry(film).Collection(f => f.FilmScreenTypes).LoadAsync();
            await _context.Entry(film).Collection(f => f.FilmTranslationTypes).LoadAsync();

            // Update common properties of the film
            _mapper.Map(filmUpdateRequest, film);
            _context.Films.Update(film);

            // Check for changes in FilmScreenTypes
            var currentScreenTypeIds = (from fst in film.FilmScreenTypes
                                        select fst.ScreenTypeId).ToList();
            if (!currentScreenTypeIds.SequenceEqual(filmUpdateRequest.ScreenTypeIds))
            {
                // Remove current FilmScreenTypes if there are changes
                _context.FilmScreenTypes.RemoveRange(film.FilmScreenTypes);

                // Add new FilmScreenTypes
                foreach (var screenTypeId in filmUpdateRequest.ScreenTypeIds)
                {
                    var filmScreenType = new FilmScreenType
                    {
                        FilmId = film.Id,
                        ScreenTypeId = screenTypeId
                    };
                    await _context.FilmScreenTypes.AddAsync(filmScreenType);
                }
            }

            // Check for changes in FilmTranslationTypes
            var currentTranslationTypeIds = (from ftt in film.FilmTranslationTypes
                                             select ftt.TranslationTypeId).ToList();
            if (!currentTranslationTypeIds.SequenceEqual(filmUpdateRequest.TranslationTypeIds))
            {
                // Remove current FilmTranslationTypes if there are changes
                _context.FilmTranslationTypes.RemoveRange(film.FilmTranslationTypes);

                // Add new FilmTranslationTypes
                foreach (var translationTypeId in filmUpdateRequest.TranslationTypeIds)
                {
                    var filmTranslationType = new FilmTranslationType
                    {
                        FilmId = film.Id,
                        TranslationTypeId = translationTypeId
                    };
                    await _context.FilmTranslationTypes.AddAsync(filmTranslationType);
                }
            }

            await _context.SaveChangesAsync();

            var filmDto = _mapper.Map<FilmDto>(film);

            return new ResponseObject<FilmDto>
            {
                Data = filmDto,
                Status = StatusCodes.Status200OK,
                Message = "Cập nhật phim thành công"
            };
        }
    }
}