using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieTicket.Application.DataTransferObjs.TicketPrice;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
using MovieTicket.Application.Interfaces.Repositories.ReadWrite;
using static MovieTicket.Infrastructure.Extensions.DefaultValue;

namespace MovieTicket.API.Controllers
{
    [Route(API_Route.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class TicketPriceController : ControllerBase
    {
        private readonly ITicketPriceReadOnlyRepository _ticketPriceReadOnlyRepository;
        private readonly ITicketPriceReadWriteReponsitory _ticketPriceReadWriteRepository;

        public TicketPriceController(ITicketPriceReadOnlyRepository ticketPriceReadOnlyRepository, ITicketPriceReadWriteReponsitory ticketPriceReadWriteRepository)
        {
            _ticketPriceReadOnlyRepository = ticketPriceReadOnlyRepository;
            _ticketPriceReadWriteRepository = ticketPriceReadWriteRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetTicketPrice(Guid id, CancellationToken cancellationToken)
        {
            var result = await _ticketPriceReadOnlyRepository.GetByIdAsync(id);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetListTicketPrice([FromQuery]TicketPriceWithPaginationRequest request, CancellationToken cancellationToken)
        {
            var result = await _ticketPriceReadOnlyRepository.GetListAsync(request, cancellationToken);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTicketPrice(TicketPriceCreateRequest request, CancellationToken cancellationToken)
        {
            var result = await _ticketPriceReadWriteRepository.Create(request, cancellationToken);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTicketPrice(TicketPriceUpdateRequest request, CancellationToken cancellationToken)
        {
            var result = await _ticketPriceReadWriteRepository.Update(request, cancellationToken);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteTicketPrice(Guid id, CancellationToken cancellationToken)
        {
            var result = await _ticketPriceReadWriteRepository.Delete(id, cancellationToken);
            return Ok(result);
        }
        
    }
}
