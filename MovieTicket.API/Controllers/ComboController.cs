using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieTicket.Application.DataTransferObjs.Combo;
using MovieTicket.Application.Interfaces.Services.ReadOnly;
using MovieTicket.Application.Interfaces.Services.ReadWrite;
using MovieTicket.Domain.Entities;
using static MovieTicket.Infrastructure.Extensions.DefaultValue;

namespace MovieTicket.API.Controllers
{
    [Route(API_Route.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class ComboController : Controller
    {
        private readonly IRComboService rService;
        private readonly IRWComboService rWService;
        private readonly IMapper mapper;

        public ComboController(IRComboService rService, IRWComboService rWService, IMapper mapper)
        {
            this.rService = rService;
            this.rWService = rWService;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAllAsync()
        {
            var comboModel = rService.GetAllAsync();
            var comboDTOs = mapper.Map<List<ComboDTOs>>(comboModel);
            return Ok(comboDTOs.AsQueryable());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var comboModel = await rService.GetByIdAsync(id);
            if (comboModel == null)
            {
                return NotFound();
            }
            var comboDTOs = mapper.Map<ComboDTOs>(comboModel);
            return Ok(comboDTOs);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(AddComboRequestDTOs request)
        {
            // Mapping DTOs to Model
            var comboModel = mapper.Map<Combo>(request);
            // Create new Combo
            comboModel = await rWService.CreateAsync(comboModel);
            // Mapping Model to DTOs
            var comboDTOs = mapper.Map<ComboDTOs>(comboModel);
            return Ok(comboDTOs);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateComboRequestDTOs request)
        {
            // Mapping DTOs to Model
            var comboModel = mapper.Map<Combo>(request);
            // Update Combo
            comboModel = await rWService.UpdateAsync(id, comboModel);
            // Mapping Model to DTOs
            var comboDTOs = mapper.Map<ComboDTOs>(comboModel);
            return Ok(comboDTOs);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            // Delete Combo
            var comboModel = await rWService.DeleteAsync(id);
            if (comboModel == null)
            {
                return NotFound();
            }
            // Mapping Model to DTOs
            var comboDTOs = mapper.Map<ComboDTOs>(comboModel);
            return Ok(comboDTOs);
        }
    }

}
