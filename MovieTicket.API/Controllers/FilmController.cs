using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieTicket.Application.DataTransferObjs.Film;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
using MovieTicket.Application.Interfaces.Repositories.ReadWrite;
using MovieTicket.Domain.Entities;
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

        // GET: api/<FilmController>
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var data = await _filmReadOnlyRepository.GetAllFilm();
            return Ok(data);
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