using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieTicket.Application.DataTransferObjs.Combo;
using MovieTicket.Application.DataTransferObjs.Film;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
using MovieTicket.Application.Interfaces.Repositories.ReadWrite;
using MovieTicket.Application.ValueObjs.Paginations;
using static MovieTicket.Infrastructure.Extensions.DefaultValue;

namespace MovieTicket.API.Controllers
{
    [Route(API_Route.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class ComboController : Controller
    {
        private readonly IComboReadOnlyRepository comboReadOnly;
        private readonly IComboReadWriteRepository comboReadWrite;
        private readonly IMapper mapper;

        public ComboController(IComboReadOnlyRepository comboReadOnly, IComboReadWriteRepository comboReadWrite, IMapper mapper)
        {
            this.comboReadOnly = comboReadOnly;
            this.comboReadWrite = comboReadWrite;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await comboReadOnly.GetAllAsync());
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPaging([FromQuery] PagingParameters pagingParameters)
        {
            var result = await comboReadOnly.GetAllPaging(pagingParameters);
            var data = result.Item.ToList();
            return Ok(new PageList<ComboDto>(data.ToList(),
                result.MetaData.TotalCount,
                result.MetaData.CurrentPage,
                result.MetaData.PageSize));
        }
        [HttpGet]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var result = await comboReadOnly.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateComboRequest request)
        {
            var comboDTOs = await comboReadWrite.CreateAsync(request);
            return Ok(comboDTOs);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateComboRequest request)
        {
            var comboDTOs = await comboReadWrite.UpdateAsync(id, request);
            return Ok(comboDTOs);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var comboDTOs = await comboReadWrite.DeleteAsync(id);
            return Ok(comboDTOs);
        }
    }
}