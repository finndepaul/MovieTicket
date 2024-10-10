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
            await _context.SaveChangesAsync();
            foreach (var id in filmCreateRequest.ScreenTypeIds)
            {
                var filmScreenType = new FilmScreenType
                {
                    FilmId = film.Id,
                    ScreenTypeId = id
                };
                await _context.FilmScreenTypes.AddAsync(filmScreenType);
                await _context.SaveChangesAsync();
            }

            foreach (var id in filmCreateRequest.TranslationTypeIds)
            {
                var filmTranslationType = new FilmTranslationType
                {
                    FilmId = film.Id,
                    TranslationTypeId = id
                };
                await _context.FilmTranslationTypes.AddAsync(filmTranslationType);
                await _context.SaveChangesAsync();
            }

            var filmDto = _mapper.Map<FilmDto>(film);
            return new ResponseObject<FilmDto>
            {
                Data = filmDto,
                Status = StatusCodes.Status201Created,
                Message = "Film created successfully"
            };
        }

        public async Task<ResponseObject<FilmDto>> DeleteFilm(Guid id)
        {
            var film = await _context.Films.FindAsync(id);
            if (film == null)
            {
                return new ResponseObject<FilmDto>
                {
                    Data = null,
                    Status = StatusCodes.Status404NotFound,
                    Message = "Film not found"
                };
            }

            film.Status = FilmStatus.Ended;
            await _context.SaveChangesAsync();

            var filmDto = _mapper.Map<FilmDto>(film);
            return new ResponseObject<FilmDto>
            {
                Data = filmDto,
                Status = StatusCodes.Status200OK,
                Message = "Film status changed to Deleted"
            };
        }

        public async Task<ResponseObject<FilmDto>> UpdateFilm(Guid id, FilmUpdateRequest filmUpdateRequest)
        {
            var film = await _context.Films
                .Include(f => f.FilmScreenTypes)
                .Include(f => f.FilmTranslationTypes)
                .FirstOrDefaultAsync(f => f.Id == id);
            if (film == null)
            {
                return new ResponseObject<FilmDto>
                {
                    Data = null,
                    Status = StatusCodes.Status404NotFound,
                    Message = "Film not found"
                };

            }

            _mapper.Map(filmUpdateRequest, film);
            _context.Films.Update(film);

            var currentFilmScreenTypes = _context.FilmScreenTypes.Where(fst => fst.FilmId == id);
            _context.FilmScreenTypes.RemoveRange(currentFilmScreenTypes);

            var currentFilmTranslationTypes = _context.FilmTranslationTypes.Where(ftt => ftt.FilmId == id);
            _context.FilmTranslationTypes.RemoveRange(currentFilmTranslationTypes);

            foreach (var screenTypeId in filmUpdateRequest.ScreenTypeIds)
            {
                var filmScreenType = new FilmScreenType
                {
                    FilmId = film.Id,
                    ScreenTypeId = screenTypeId  // Sử dụng screenTypeId từ filmUpdateRequest
                };
                await _context.FilmScreenTypes.AddAsync(filmScreenType);
            }

            // Thêm các FilmTranslationType mới
            foreach (var translationTypeId in filmUpdateRequest.TranslationTypeIds)
            {
                var filmTranslationType = new FilmTranslationType
                {
                    FilmId = film.Id,
                    TranslationTypeId = translationTypeId  // Sử dụng translationTypeId từ filmUpdateRequest
                };
                await _context.FilmTranslationTypes.AddAsync(filmTranslationType);
            }

            await _context.SaveChangesAsync();
            var filmDto = _mapper.Map<FilmDto>(film);
            return new ResponseObject<FilmDto>
            {
                Data = filmDto,
                Status = StatusCodes.Status201Created,
                Message = "Film Update successfully"
            };
        }
    }
}