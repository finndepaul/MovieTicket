using MovieTicket.Application.DataTransferObjs.TranslationType;

namespace MovieTicket.BlazorServer.Services.Interfaces.ITranslationTypeService
{
    public interface ITranslationTypeService
    {
        Task<List<TranslationTypeDto>> GetAllTranslationTypes();
    }
}
