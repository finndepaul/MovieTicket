namespace MovieTicket.Application.ValueObjs.Paginations;

public class PaginationRequest
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 20;
}