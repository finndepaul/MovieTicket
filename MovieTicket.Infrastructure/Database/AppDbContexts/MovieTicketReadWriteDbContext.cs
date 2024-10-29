using Bogus;
using Microsoft.EntityFrameworkCore;
using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Entitis;
using MovieTicket.Domain.Enums;
using MovieTicket.Infrastructure.Extensions;

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
        public virtual DbSet<Banner> Banners { get; set; }

        #endregion DbSet

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Đăng:
            //optionsBuilder.UseSqlServer("Data Source=SURINRIN\\SQLEXPRESS01;Initial Catalog=MovieTicket;Integrated Security=True;TrustServerCertificate=true");

            // Trung:
            //optionsBuilder.UseSqlServer("Data Source=MSI\\ISORA;Initial Catalog=MovieTicket;Integrated Security=True;TrustServerCertificate=true");

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
            SeedingDataWithBogus(modelBuilder);
        }



		private void SeedingDataWithBogus(ModelBuilder modelBuilder)
		{
			// Faker for Account
			List<Account> accounts = new List<Account>();
			accounts.Add(new Account()
			{
				Id = Guid.Parse("fd36705c-0610-4c30-9cfb-e5827b3f3d78"),
				Username = "Admin",
				Password = Hash.EncryptPassword("123"),
				Role = Domain.Enums.AccountRole.Admin, // 1, 2, or 3
				Avatar = $"avatar1.png",
				Name = "AdminTest",
				Phone = "000-000-000",
				Email = "azusachan307@gmail.com",
				Status = Domain.Enums.AccountStatus.Active, // 0 or 1
				CreateDate = new DateTime(2024, 10, 1).AddDays(10)
			});
			accounts.Add(new Account()
			{
				Id = Guid.Parse("35ff4cc4-7823-4ffb-95e4-c2e73dace190"),
				Username = "User",
				Password = Hash.EncryptPassword("123"),
				Role = Domain.Enums.AccountRole.User, // 1, 2, or 3
				Avatar = $"avatar2.png",
				Name = "ClientTest",
				Phone = "000-000-000",
				Email = "azusachan309@gmail.com",
				Status = Domain.Enums.AccountStatus.Active, // 0 or 1
				CreateDate = new DateTime(2024, 10, 1).AddDays(10)
			});
			modelBuilder.Entity<Account>().HasData(accounts);

			var filmFaker = new Faker<Film>("vi")
			.RuleFor(f => f.Id, f => Guid.NewGuid())
			.RuleFor(f => f.Name, f => $"Mộ đom đóm (Lần {f.IndexFaker})")
			.RuleFor(f => f.EnglishName, f => $"Grave of the Fireflies (English)")
			.RuleFor(f => f.Trailer, f => "https://youtu.be/p6jOf_uDeH8")
			.RuleFor(f => f.Description, f => f.Lorem.Sentence())
			.RuleFor(f => f.Gerne, f => f.PickRandom("Romantic", "School Love"))
			.RuleFor(f => f.Director, f => f.Name.FullName())
			.RuleFor(f => f.Cast, f => $"{f.Name.FirstName()} {f.Name.LastName()}")
			.RuleFor(f => f.Rating, f => f.PickRandom(12, 16, 18))
			.RuleFor(f => f.StartDate, f => f.Date.Between(new DateTime(2024, 9, 1), new DateTime(2024, 10, 30)))
			.RuleFor(f => f.ReleaseYear, 2024)
			.RuleFor(f => f.RunningTime, f => f.Random.Int(60, 180))
			.RuleFor(f => f.Status, Domain.Enums.FilmStatus.NowShowing)
			.RuleFor(f => f.Nation, f => f.PickRandom("USA", "Japan"))
			.RuleFor(f => f.Poster, "img/posterFilm/film_modomdom.jpg")
			.RuleFor(f => f.Language, f => f.PickRandom("English", "Japanese"))
			.RuleFor(f => f.CreatDate, f => f.Date.Between(new DateTime(2024, 9, 1), new DateTime(2024, 10, 30)));
			// Generate list of films
			var films = filmFaker.Generate(15);
			modelBuilder.Entity<Film>().HasData(films);

			// Faker for Membership
			var membershipFaker = new Faker<Membership>()
				.RuleFor(m => m.Id, Guid.Parse("35ff4cc4-7823-4ffb-95e4-c2e73dace190"))
				.RuleFor(m => m.Point, 0)
				.RuleFor(m => m.Status, Domain.Enums.MembershipStatus.Active);

			modelBuilder.Entity<Membership>().HasData(membershipFaker.Generate(1));

			// Faker for CinemaCenter
			var cinemaCenterFaker = new Faker<CinemaCenter>("vi")
				.RuleFor(c => c.Id, f => Guid.NewGuid())
				.RuleFor(c => c.Name, f => $"VHD Vincom {f.Address.StreetAddress()}")
				.RuleFor(c => c.Address, f => f.Address.FullAddress());
			var cinemaCenters = cinemaCenterFaker.Generate(5);
			modelBuilder.Entity<CinemaCenter>().HasData(cinemaCenters);

			// Faker for Combo
			var comboFaker = new Faker<Combo>()
				.RuleFor(c => c.Id, f => Guid.NewGuid())
				.RuleFor(c => c.Name, f => $"Combo {f.IndexFaker}")
				.RuleFor(c => c.Price, f => f.Random.Int(10000, 100000));
			modelBuilder.Entity<Combo>().HasData(comboFaker.Generate(5));
			// Faker for ScreeningDay (ensure unique values)
			// Faker for ScreeningDay
			var screeningDayList = new List<string> { "T2-CN", "T2-T6", "T7-CN" };
			var screeningDayFaker = new Faker<ScreeningDay>()
				.RuleFor(s => s.Id, f => Guid.NewGuid())
				.RuleFor(s => s.Day, f =>
				{
					var day = screeningDayList.First(); // Lấy phần tử đầu tiên
					screeningDayList.RemoveAt(0); // Loại bỏ phần tử đã chọn để đảm bảo không trùng lặp
					return day;
				});

			var screeningDays = screeningDayFaker.Generate(3); // Sinh ra đúng 3 loại ngày
			modelBuilder.Entity<ScreeningDay>().HasData(screeningDays);

			// Faker for SeatType
			var seatTypeList = new List<string> { "Normal", "VIP", "Couple" };
			var seatTypeFaker = new Faker<SeatType>()
				.RuleFor(s => s.Id, f => Guid.NewGuid())
				.RuleFor(s => s.Name, f =>
				{
					var seatType = seatTypeList.First();
					seatTypeList.RemoveAt(0);
					return seatType;
				});

			var seatTypes = seatTypeFaker.Generate(3); // Sinh ra đúng 3 loại ghế
			modelBuilder.Entity<SeatType>().HasData(seatTypes);

			// Faker for CinemaType
			var cinemaTypeList = new List<string> { "2D", "Gold Class", "Premium Class", "IMAX", "4DX" };
			var cinemaTypeFaker = new Faker<CinemaType>()
				.RuleFor(c => c.Id, f => Guid.NewGuid())
				.RuleFor(c => c.Name, f =>
				{
					var cinemaType = cinemaTypeList.First();
					cinemaTypeList.RemoveAt(0);
					return cinemaType;
				});

			var cinemaTypes = cinemaTypeFaker.Generate(5); // Sinh ra đúng 5 loại rạp chiếu
			modelBuilder.Entity<CinemaType>().HasData(cinemaTypes);

			// Faker for ScreenType
			var screenTypeList = new List<string> { "2D", "4DX", "IMAX", "3D" };
			var screenTypeFaker = new Faker<ScreenType>()
				.RuleFor(s => s.Id, f => Guid.NewGuid())
				.RuleFor(s => s.Type, f =>
				{
					var screenType = screenTypeList.First();
					screenTypeList.RemoveAt(0);
					return screenType;
				});

			var screenTypes = screenTypeFaker.Generate(4); // Sinh ra đúng 4 loại màn hình
			modelBuilder.Entity<ScreenType>().HasData(screenTypes);

			// Faker for TranslationType
			var translationTypeList = new List<string> { "Phụ đề Việt", "Phụ đề Anh - Việt", "Phụ đề Hàn - Việt", "Lồng tiếng Việt" };
			var translationTypeFaker = new Faker<TranslationType>()
				.RuleFor(t => t.Id, f => Guid.NewGuid())
				.RuleFor(t => t.Type, f =>
				{
					var translationType = translationTypeList.First();
					translationTypeList.RemoveAt(0);
					return translationType;
				});

			var translationTypes = translationTypeFaker.Generate(4); // Sinh ra đúng 4 loại dịch thuật
			modelBuilder.Entity<TranslationType>().HasData(translationTypes);

			// Faker for FilmScreenType
			var filmScreenTypeFaker = new List<FilmScreenType>();

			// Bước 1: Đảm bảo mỗi FilmId xuất hiện ít nhất một lần
			foreach (var film in films)
			{
				var filmScreenType = new Faker<FilmScreenType>()
					.RuleFor(f => f.FilmId, f => film.Id)
					.RuleFor(f => f.ScreenTypeId, f => screenTypes[f.Random.Int(0, screenTypes.Count - 1)].Id)
					.Generate();

				filmScreenTypeFaker.Add(filmScreenType);
			}
			// Generate list of film screen types
			modelBuilder.Entity<FilmScreenType>().HasData(filmScreenTypeFaker);
			//fake for FilmTranslationType
			var filmTranslationTypeFaker = new List<FilmTranslationType>();

			// Bước 1: Đảm bảo mỗi FilmId xuất hiện ít nhất một lần
			foreach (var film in films)
			{
				var filmTranslationType = new Faker<FilmTranslationType>()
					.RuleFor(f => f.FilmId, f => film.Id)
					.RuleFor(f => f.TranslationTypeId, f => translationTypes[f.Random.Int(0, translationTypes.Count - 1)].Id)
					.Generate();

				filmTranslationTypeFaker.Add(filmTranslationType);
			}
			// Generate list of film translation types
			modelBuilder.Entity<FilmTranslationType>().HasData(filmTranslationTypeFaker);
			// Faker for Bill
			var billFaker = new Faker<Bill>()
				.RuleFor(b => b.Id, f => Guid.NewGuid())
				.RuleFor(b => b.TotalMoney, f => f.Finance.Amount(50000, 300000))
				.RuleFor(b => b.CreateTime, f => f.Date.Between(new DateTime(2024, 9, 1), new DateTime(2024, 10, 30)))
				.RuleFor(b => b.BarCode, f => $"barcode{f.IndexFaker}.jpg")
				.RuleFor(b => b.Status, BillStatus.Paid)
				.RuleFor(b => b.ActivationStatus, true)
				.RuleFor(b => b.MembershipId, Guid.Parse("35ff4cc4-7823-4ffb-95e4-c2e73dace190"))
				.RuleFor(b => b.VoucherId, (Guid?)null);
			var bills = billFaker.Generate(10);
			modelBuilder.Entity<Bill>().HasData(bills);

			// Faker for Schedule
			var schedules = new List<Schedule>();

			// Bước 1: Đảm bảo mỗi FilmId xuất hiện ít nhất một lần
			foreach (var film in films)
			{
				var schedule = new Faker<Schedule>()
					.RuleFor(s => s.Id, f => Guid.NewGuid())
					.RuleFor(s => s.FilmId, f => film.Id)
					.RuleFor(s => s.StartDate, f => f.Date.Between(new DateTime(2024, 10, 1), DateTime.Now))
				.RuleFor(s => s.EndDate, (f, s) => s.StartDate.AddDays(10))
					.RuleFor(s => s.Type, f => f.PickRandom<ScheduleType>())
					.RuleFor(s => s.Status, ScheduleStatus.Showing)
					.Generate();

				schedules.Add(schedule);
			}
			// Generate list of schedules
			modelBuilder.Entity<Schedule>().HasData(schedules);
			//List<TicketPrice> ticketPrices = new List<TicketPrice>();
			//List<Guid> seatTypeIds = seatTypes.Select(s => s.Id).ToList();
			//List<Guid> screeningDayIds = screeningDays.Select(s => s.Id).ToList();
			//List<Guid> cinemaTypeIds = cinemaTypes.Select(c => c.Id).ToList();
			//List<Guid> screenTypeIds = screenTypes.Select(s => s.Id).ToList();

			//// Sinh ra tất cả các tổ hợp SeatTypeId, ScreeningDayId, CinemaTypeId, ScreenTypeId
			//var combinations = from seat in seatTypeIds
			//				   from day in screeningDayIds
			//				   from cinema in cinemaTypeIds
			//				   from screen in screenTypeIds
			//				   select new { seat, day, cinema, screen };

			//// Chọn 1365 tổ hợp và tạo TicketPrice cho mỗi tổ hợp
			//foreach (var combo in combinations.Take(1365))
			//{
			//	TicketPrice ticket = new TicketPrice
			//	{
			//		Id = Guid.NewGuid(),
			//		Price = 30000, // Tính giá ngẫu nhiên hoặc dựa vào logic của bạn
			//		SeatTypeId = combo.seat,
			//		ScreeningDayId = combo.day,
			//		CinemaTypeId = combo.cinema,
			//		ScreenTypeId = combo.screen,
			//		Status = TicketPriceStatus.Active
			//	};
			//	ticketPrices.Add(ticket);
			//}

			//// Seed dữ liệu vào database
			//modelBuilder.Entity<TicketPrice>().HasData(ticketPrices);
		}


	}
}