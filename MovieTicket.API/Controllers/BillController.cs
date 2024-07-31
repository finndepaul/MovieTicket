using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieTicket.Application.DataTransferObjs.Bill;
using MovieTicket.Application.DataTransferObjs.Combo;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
using MovieTicket.Application.Interfaces.Repositories.ReadWrite;
using MovieTicket.Domain.Entities;
using static MovieTicket.Infrastructure.Extensions.DefaultValue;

namespace MovieTicket.API.Controllers
{
    [Route(API_Route.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class BillController : Controller
    {
        private readonly IBillReadOnlyRepository billReadOnly;
        private readonly IBillReadWriteRepository billReadWrite;
        private readonly IMapper mapper;

        public BillController(IBillReadOnlyRepository billReadOnly,IBillReadWriteRepository billReadWrite,IMapper mapper)
        {
            this.billReadOnly = billReadOnly;
            this.billReadWrite = billReadWrite;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var billModels = billReadOnly.GetAllAsync();
            return Ok(billModels);
        }
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            var billModel = await billReadOnly.GetByIdAsync(id);
            return Ok(billModel);
        }
        [HttpGet]
        public IActionResult GetAllBillWithCombo()
        {
            var billModels = billReadOnly.GetAllWithCombosAsync();
            return Ok(billModels);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBillRequest createBillRequest)
        {
            var billModel = await billReadWrite.CreateAsync(createBillRequest);
            return Ok(billModel);
        }
        [HttpPut]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateBillRequest updateBillRequest)
        {
            var billModel = await billReadWrite.UpdateAsync(id, updateBillRequest);
            return Ok(billModel);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var billModel = await billReadWrite.DeleteAsync(id);
            return Ok(billModel);
        }
    }

}
