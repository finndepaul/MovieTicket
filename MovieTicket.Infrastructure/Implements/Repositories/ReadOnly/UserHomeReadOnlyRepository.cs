using Microsoft.EntityFrameworkCore;
using MovieTicket.Application.DataTransferObjs.UserHome;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
using MovieTicket.Domain.Enums;
using MovieTicket.Infrastructure.Database.AppDbContexts;

namespace MovieTicket.Infrastructure.Implements.Repositories.ReadOnly
{
    public class UserHomeReadOnlyRepository : IUserHomeReadOnlyRepository
    {
        private readonly MovieTicketReadOnlyDbContext _context;

        public UserHomeReadOnlyRepository(MovieTicketReadOnlyDbContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<UserHomeDto>> GetAllFilmForUserHome()
        {
            return (from f in _context.Films
                    join s in _context.Schedules on f.Id equals s.FilmId into scheduleGroup
                    from sg in scheduleGroup.DefaultIfEmpty() // Left Join
                    where sg == null || sg.Status != ScheduleStatus.Ended
                    select new UserHomeDto
                    {
                        Id = f.Id,
                        Poster = f.Poster,
                        Name = f.Name,
                        Gerne = f.Gerne,
                        RunningTime = f.RunningTime,
                        SType = sg != null ? sg.Type : null, // Nếu không có lịch chiếu, giá trị sẽ là null
                        Rating = f.Rating,
                        StartDate = f.StartDate// Nếu không có lịch chiếu, giá trị sẽ là null
                    }).AsNoTracking();
        }

        public async Task<int> GetPointOfMembershipAsync(Guid accountId, CancellationToken cancellationToken)
        {
            var member = _context.Memberships.FirstOrDefault(x => x.AccountId == accountId); // đã đăng nhập đc là tìm thấy
            return member.Point.Value;
        }
    }
}