using MovieTicket.Application.DataTransferObjs.Ticket;
using MovieTicket.BlazorServer.Services.Interfaces;

namespace MovieTicket.BlazorServer.Services.Implements
{
    public class TicketService : ITicketService
    {
        private readonly HttpClient _http;

        public TicketService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<TicketDto>> GetListTicketByBillIdAsync(Guid billId)
        {
            var reponse = await _http.GetFromJsonAsync<List<TicketDto>>($"api/Ticket/GetListTicketByBillId?billId={billId}");
            return reponse;
        }
        public async Task<List<TicketDto>> GetListTicketByShowTimeIdAsync(Guid showTimeId)
        {
            try
            {
                var response = await _http.GetFromJsonAsync<List<TicketDto>>($"api/Ticket/GetListTicketByShowTimeId?showTimeId={showTimeId}");
                return response ?? new List<TicketDto>();
            }
            catch (HttpRequestException ex)
            {
                // Log the exception (ex) here if needed
                return new List<TicketDto>();
            }
        }
    }
}
