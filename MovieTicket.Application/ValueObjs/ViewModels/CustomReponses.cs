namespace MovieTicket.Application.ValueObjs.ViewModels
{
    public class CustomReponses
    {
        public record LoginRespone(bool Flag = false, string Message = null!, string JWTToken = null!);
        public record RegisterResponse(bool Flag = false, string Message = null!);
    }
}