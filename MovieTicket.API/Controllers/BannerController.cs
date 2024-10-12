using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieTicket.Application.DataTransferObjs.Banner;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
using MovieTicket.Application.Interfaces.Repositories.ReadWrite;
using static MovieTicket.Infrastructure.Extensions.DefaultValue;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieTicket.API.Controllers
{
    [Route(API_Route.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class BannerController : ControllerBase
    {
        private readonly IBannerReadWriteRepository _bannerReadWrite;
        private readonly IBannerReadOnlyRepository _bannerReadOnly;
        private readonly IMapper _mapper;

        public BannerController(IBannerReadWriteRepository bannerReadWrite, IBannerReadOnlyRepository bannerReadOnly, IMapper mapper)
        {
            _bannerReadWrite = bannerReadWrite;
            _bannerReadOnly = bannerReadOnly;
            _mapper = mapper;
        }

        // GET: api/<BannerController>
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var banners = await _bannerReadOnly.GetAllAsync();
            return Ok(banners);
        }

        // GET api/<BannerController>/5
        [HttpGet]
        public async Task<ActionResult> GetById(Guid id)
        {
            var banner = await _bannerReadOnly.GetByIdAsync(id);
            return Ok(banner);
        }

        // POST api/<BannerController>
        [HttpPost]
        public async Task<ActionResult> CreateBanner(BannerCreateRequest request)
        {
            var create = await _bannerReadWrite.Create(request);
            return Ok(create);
        }

        // PUT api/<BannerController>/5
        [HttpPut]
        public async Task<ActionResult> UpdateBanner(BannerUpdateRequest request)
        {
            var update = await _bannerReadWrite.Update(request);
            return Ok(update);
        }

        [HttpDelete]
        public async Task<ActionResult> HardDelete(Guid id)
        {
            var result = await _bannerReadWrite.HardDelete(id);
            return Ok(result);
        }
    }
}