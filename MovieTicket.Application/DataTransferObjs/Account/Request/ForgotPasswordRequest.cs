namespace MovieTicket.Application.DataTransferObjs.Account.Request
{
    public class ForgotPasswordRequest
    {
        public Guid AccountId { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPW { get; set; }
    }
}