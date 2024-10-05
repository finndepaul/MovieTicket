namespace MovieTicket.Application.DataTransferObjs.Auth
{
    public class LoginDto
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}