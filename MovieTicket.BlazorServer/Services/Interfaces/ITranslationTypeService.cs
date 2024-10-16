using MovieTicket.Application.DataTransferObjs.TranslationType;

namespace MovieTicket.BlazorServer.Services.Interfaces
{
    public interface ITranslationTypeService
    {
        Task<List<TranslationTypeDto>> GetAllTranslationTypes();
    }
}
