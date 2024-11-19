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
    }
}
