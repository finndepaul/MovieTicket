using MovieTicket.Application.DataTransferObjs.TranslationType;
using MovieTicket.BlazorServer.Services.Interfaces.ITranslationTypeService;
using System.Net.Http;

namespace MovieTicket.BlazorServer.Services.Implements.TranslationTypeService
{
    public class TranslationTypeService : ITranslationTypeService
    {
        private readonly HttpClient _httpClient;

        public TranslationTypeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<TranslationTypeDto>> GetAllTranslationTypes()
        {
            return await _httpClient.GetFromJsonAsync<List<TranslationTypeDto>>("api/TranslationType/GetAll");
        }
    }
}
