using MovieTicket.Application.DataTransferObjs.TranslationType;

namespace WebUI.Services.Interfaces;
public interface ITranslationTypeService
{
    Task<List<TranslationTypeDto>> GetAllTranslationTypes();
}

