using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieTicket.Application.DataTransferObjs.Bill;
using MovieTicket.Application.DataTransferObjs.Film;
using MovieTicket.Application.DataTransferObjs.TicketPrice;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
using MovieTicket.Application.Interfaces.Repositories.ReadWrite;
using MovieTicket.Application.ValueObjs.Paginations;
using MovieTicket.Domain.Enums;
using ZXing;
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

        public BillController(IBillReadOnlyRepository billReadOnly, IBillReadWriteRepository billReadWrite, IMapper mapper)
        {
            this.billReadOnly = billReadOnly;
            this.billReadWrite = billReadWrite;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserBookingHistory(Guid userId, [FromQuery] PagingParameters pagingParameters, CancellationToken cancellationToken)
        {
            var result = await billReadOnly.GetUserBookingHistoryAsync(userId, pagingParameters, cancellationToken);
            var data = result.Item.ToList();
            return Ok(new PageList<BillsDto>(data.ToList(),
                result.MetaData.TotalCount,
                result.MetaData.CurrentPage,
                result.MetaData.PageSize));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var billModels = await billReadOnly.GetAllAsync();
            return Ok(billModels);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            var billModel = await billReadOnly.GetByIdAsync(id);
            return Ok(billModel);
        }
        [HttpGet]
		public async Task<IActionResult> GetListBillWithPagination([FromQuery] BillWithPaginationRequest request, [FromQuery] PagingParameters pagingParameters,CancellationToken cancellationToken)
		{
			var result = await billReadOnly.GetListBillWithPaginationAsync(request, pagingParameters, cancellationToken);
			var data = result.Item.ToList();
			return Ok(new PageList<BillsDto>(data.ToList(),
				result.MetaData.TotalCount,
				result.MetaData.CurrentPage,
				result.MetaData.PageSize));
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
        [HttpPut]
		public async Task<IActionResult> UpdateStatus(Guid id, BillStatus status)
		{
			var result = await billReadWrite.UpdateStatusAsync(id, status);
			return Ok(result);
		}

	}
}