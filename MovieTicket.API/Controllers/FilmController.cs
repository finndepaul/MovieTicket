using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieTicket.Application.DataTransferObjs.Film;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
using MovieTicket.Application.Interfaces.Repositories.ReadWrite;
using MovieTicket.Application.ValueObjs.Paginations;
using MovieTicket.Domain.Entities;
using ZXing;
using static MovieTicket.Infrastructure.Extensions.DefaultValue;

namespace MovieTicket.API.Controllers
{
    [Route(API_Route.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly IFilmReadWriteRepository _filmReadWriteRepository;
        private readonly IFilmReadOnlyRepository _filmReadOnlyRepository;

        public FilmController(IFilmReadWriteRepository filmReadWriteRepository,IFilmReadOnlyRepository filmReadOnlyRepository)
        {   
            _filmReadOnlyRepository = filmReadOnlyRepository;
            _filmReadWriteRepository = filmReadWriteRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllPaging([FromQuery]PagingParameters pagingParameters)
        {
            var result = await _filmReadOnlyRepository.GetFilmPageList(pagingParameters);
            var data = result.Item.ToList();
            return Ok(new PageList<FilmDto>(data.ToList(),
                result.MetaData.TotalCount,
                result.MetaData.CurrentPage,
                result.MetaData.PageSize));
        }
        // GET: api/<FilmController>
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var data = await _filmReadOnlyRepository.GetAllFilm();
            return Ok(data);
        }
        [HttpGet]
        public async Task<ActionResult> FilteringFilms([FromQuery] string? name,
          [FromQuery] int? releaseYear,[FromQuery] DateTime? createDate,[FromQuery] DateTime? startDate, 
          [FromQuery] PagingParameters pagingParameters)
        {
            var result = await _filmReadOnlyRepository.FilterFilms(name, 
                releaseYear, createDate, startDate, pagingParameters); 
            var data = result.Item.ToList();
            return Ok(new PageList<FilmDto>(data.ToList(),
                result.MetaData.TotalCount,
                result.MetaData.CurrentPage,
                result.MetaData.PageSize));
        }
        // GET api/<FilmController>/5
        [HttpGet]
        public async Task<ActionResult> GetById(Guid id)
        {
            var data = await _filmReadOnlyRepository.GetFilmById(id);
            return Ok(data);
        }

        // POST api/<FilmController>
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] FilmCreateRequest film)
        {
            var data = await _filmReadWriteRepository.CreateFilm(film);
            return Ok(data);
        }

        // PUT api/<FilmController>/5
        [HttpPut]
        public async Task<ActionResult> Update(Guid id, [FromBody] FilmUpdateRequest film)
        {
            var data = await _filmReadWriteRepository.UpdateFilm(id, film);
            return Ok(data);
        }

        // DELETE api/<FilmController>/5
        [HttpDelete]
        public async Task<ActionResult> Delete(Guid id)
        {
            var data = await _filmReadWriteRepository.DeleteFilm(id);
            return Ok(data);
        }
    }
}