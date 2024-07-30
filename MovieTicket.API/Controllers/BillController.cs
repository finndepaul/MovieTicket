using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieTicket.Application.DataTransferObjs.Bill;
using MovieTicket.Application.DataTransferObjs.Combo;
using MovieTicket.Application.Interfaces.Services.ReadOnly;
using MovieTicket.Application.Interfaces.Services.ReadWrite;
using MovieTicket.Domain.Entities;
using static MovieTicket.Infrastructure.Extensions.DefaultValue;

namespace MovieTicket.API.Controllers
{
    [Route(API_Route.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class BillController : Controller
    {
        private readonly IRBillService rBillService;
        private readonly IRWBillService rWBillService;
        private readonly IMapper mapper;

        public BillController(IRBillService rBillService, IRWBillService rWBillService, IMapper mapper)
        {
            this.rBillService = rBillService;
            this.rWBillService = rWBillService;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var billModels = rBillService.GetAllAsync();
            var billDTOs = billModels.Select(bill => new BillWithComboDTOs
            {
                Id = bill.Id,
                TotalMoney = bill.TotalMoney,
                CreateTime = bill.CreateTime,
                BarCode = bill.BarCode,
                Status = bill.Status,
                Combos = bill.BillCombos.Select(bc => new ComboDTOs
                {
                    Id = bc.Combo.Id,
                    Name = bc.Combo.Name,
                    Price = bc.Combo.Price
                }).ToList()
            }).ToList();

            return Ok(billDTOs);
        }
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var billModel = await rBillService.GetByIdAsync(id);
            if (billModel == null)
            {
                return NotFound();
            }
            var billDTOs = mapper.Map<BillDTOs>(billModel);
            return Ok(billDTOs);
        }
        [HttpGet("{id}")]
        public IActionResult GetBillByCombo(Guid id)
        {
            var comboModel = mapper.Map<List<ComboDTOs>>(rBillService.GetBillByCombo(id));
            if (comboModel == null)
            {
                return NotFound();
            }
            return Ok(comboModel);

        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] AddBillRequestDTOs addBillRequestDTOs)
        {
            var billModel = mapper.Map<Bill>(addBillRequestDTOs);
            billModel = await rWBillService.CreateAsync(billModel, addBillRequestDTOs.ComboIds);
            var billDTOs = mapper.Map<BillDTOs>(billModel);
            return Ok(billDTOs);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromQuery] Guid id, [FromBody] UpdateBillRequestDTOs updateBillRequestDTOs)
        {
            var billModel = mapper.Map<Bill>(updateBillRequestDTOs);
            billModel = await rWBillService.UpdateAsync(id, billModel, updateBillRequestDTOs.ComboIds);
            var billDTOs = mapper.Map<BillDTOs>(billModel);
            return Ok(billDTOs);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var billModel = await rWBillService.DeleteAsync(id);
            if (billModel == null)
            {
                return NotFound();
            }
            var billDTOs = mapper.Map<BillDTOs>(billModel);
            return Ok(billDTOs);
        }
    }

}
