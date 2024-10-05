namespace MovieTicket.Application.DataTransferObjs.Auth
{
    public record CustomeUserClaims(string Username = null!, string Email = null!, string Role = null!);
}