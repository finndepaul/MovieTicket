using MovieTicket.Application.DataTransferObjs.TranslationType;
using WebUI.Services.Interfaces;
using System.Net.Http;
using System.Net.Http.Json;

namespace WebUI.Services.Implements
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
