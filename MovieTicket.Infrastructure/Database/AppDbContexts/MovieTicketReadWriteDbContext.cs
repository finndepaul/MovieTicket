using Microsoft.EntityFrameworkCore;
using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Entitis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Infrastructure.Database.AppDbContexts
{
    public class MovieTicketReadWriteDbContext : DbContext
    {
        public MovieTicketReadWriteDbContext(DbContextOptions options) : base(options)
        {
        }

        public MovieTicketReadWriteDbContext()
        {
        }
        #region DbSet
        public virtual DbSet<Account> Accounts { get; set; }

        public virtual DbSet<Bill> Bills { get; set; }

        public virtual DbSet<BillCombo> BillCombos { get; set; }

        public virtual DbSet<Cinema> Cinemas { get; set; }

        public virtual DbSet<CinemaCenter> CinemaCenters { get; set; }

        public virtual DbSet<CinemaType> CinemaTypes { get; set; }

        public virtual DbSet<Combo> Combos { get; set; }

        public virtual DbSet<ConfirmedEmail> ConfirmedEmails { get; set; }

        public virtual DbSet<Film> Films { get; set; }

        public virtual DbSet<FilmScreenType> FilmScreenTypes { get; set; }

        public virtual DbSet<FilmTranslationType> FilmTranslationTypes { get; set; }

        public virtual DbSet<Membership> Memberships { get; set; }

        public virtual DbSet<Promotion> Promotions { get; set; }

        public virtual DbSet<PromotionDetail> PromotionDetails { get; set; }

        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

        public virtual DbSet<Schedule> Schedules { get; set; }

        public virtual DbSet<ScreenType> ScreenTypes { get; set; }

        public virtual DbSet<ScreeningDay> ScreeningDays { get; set; }

        public virtual DbSet<Seat> Seats { get; set; }

        public virtual DbSet<SeatType> SeatTypes { get; set; }

        public virtual DbSet<ShowTime> ShowTimes { get; set; }

        public virtual DbSet<Ticket> Tickets { get; set; }

        public virtual DbSet<TicketPrice> TicketPrices { get; set; }

        public virtual DbSet<TranslationType> TranslationTypes { get; set; }

        public virtual DbSet<Voucher> Vouchers { get; set; }

        public virtual DbSet<VoucherDetail> VoucherDetails { get; set; }
        public virtual DbSet<BillSeat> BillSeats { get; set; }

        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Đăng:
            //optionsBuilder.UseSqlServer("Data Source=SURINRIN\\SQLEXPRESS01;Initial Catalog=MovieTicket;Integrated Security=True;TrustServerCertificate=true");

            // Trung:
            //optionsBuilder.UseSqlServer("Data Source=ISORA;Initial Catalog=MovieTicket;Integrated Security=True;TrustServerCertificate=true");

            // Toản:
            //optionsBuilder.UseSqlServer("Data Source=LAPTOP-JMN439Q3\\SQLEXPRESS02;Initial Catalog=MovieTicket;Integrated Security=True;TrustServerCertificate=true");

            // Vũ:
            //optionsBuilder.UseSqlServer("Data Source=VUHOPE;Initial Catalog=MovieTicket;Integrated Security=True;TrustServerCertificate=true");

            // Đông:
            //optionsBuilder.UseSqlServer("Data Source=DESKTOP-V6M0EF7\\SQLEXPRESS;Initial Catalog=MovieTicket;Integrated Security=True;TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MovieTicketReadWriteDbContext).Assembly);
        }
    }
}
