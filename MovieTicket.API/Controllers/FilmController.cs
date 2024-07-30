using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieTicket.Application.DataTransferObjs;
using MovieTicket.Application.Interfaces.Repositories.ReadWrite;
using MovieTicket.Domain.Entities;
using static MovieTicket.Infrastructure.Extensions.DefaultValue;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieTicket.API.Controllers
{
    [Route(API_Route.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly IFilmRepository _filmRepository;
        private readonly IMapper _mapper;
        public FilmController(IFilmRepository filmRepository,IMapper mapper)
        {
            this._filmRepository = filmRepository;
            this._mapper = mapper;
        }
        // GET: api/<FilmController>
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var data = await _filmRepository.GetAllFilm();
            return Ok(data);
        }

        // GET api/<FilmController>/5
        [HttpGet]
        public async Task<ActionResult> GetById(Guid id)
        {
            var data = await _filmRepository.GetFilmById(id);
            return Ok(data);
        }

        // POST api/<FilmController>
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] FilmCreateRequest film)
        {
            var data = await _filmRepository.CreateFilm(_mapper.Map<Film>(film));
            return Ok(data);
        }

        // PUT api/<FilmController>/5
        [HttpPut]
        public async Task<ActionResult> Update(Guid id, [FromBody] FilmUpdateRequest film)
        {
            try
            {
                var data = await _filmRepository.GetFilmById(id);
                if (data == null)
                {
                    return NotFound();
                }
                else
                {
                    data.Name = film.Name;
                    data.EnglishName = film.EnglishName;
                    data.Trailer = film.Trailer;
                    data.Description = film.Description;
                    data.Gerne = film.Gerne;
                    data.Director = film.Director;
                    data.Cast = film.Cast;
                    data.ScreenTypeId = film.ScreenTypeId;
                    data.TranslationTypeId = film.TranslationTypeId;
                    data.Rating = film.Rating;
                    data.StartDate = film.StartDate;
                    data.ReleaseYear = film.ReleaseYear;
                    data.RunningTime = film.RunningTime;
                    data.Status = film.Status;
                    data.Nation = film.Nation;
                    data.Poster = film.Poster;
                    data.Language = film.Language;
                    await _filmRepository.UpdateFilm(data);
                    return Ok(data);
                }
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        // DELETE api/<FilmController>/5
        [HttpDelete]
        public async Task<ActionResult> Delete(Guid id)
        {
            var data = await _filmRepository.DeleteFilm(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
    }
}
