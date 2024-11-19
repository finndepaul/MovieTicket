namespace MovieTicket.Application.DataTransferObjs.Auth
{
	public record CustomUserClaims(string Username = null!, string Email = null!, string Role = null!, string UserId = null!);
}