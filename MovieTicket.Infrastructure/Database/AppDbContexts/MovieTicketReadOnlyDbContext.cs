using Microsoft.EntityFrameworkCore;
using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Entitis;
using MovieTicket.Domain.Enums;
using MovieTicket.Infrastructure.Extensions;

namespace MovieTicket.Infrastructure.Database.AppDbContexts;

public class MovieTicketReadOnlyDbContext : DbContext
{
    public MovieTicketReadOnlyDbContext()
    {
    }

    public MovieTicketReadOnlyDbContext(DbContextOptions<MovieTicketReadOnlyDbContext> options)
        : base(options)
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

    #endregion DbSet

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
        SeedingData(modelBuilder);
    }

	private void SeedingData(ModelBuilder modelBuilder)
	{
		//Account
		Random random = new Random();
		List<Account> accounts = new List<Account>();
		accounts.Add(new Account()
		{
			Id = Guid.Parse("fd36705c-0610-4c30-9cfb-e5827b3f3d78"),
			Username = "Admin",
			Password = Hash.EncryptPassword("abc123"),
			Role = Domain.Enums.AccountRole.Admin, // 1, 2, or 3
			Avatar = $"avatar1.png",
			Name = "AdminTest",
			Phone = "000-000-000",
			Email = "azusachan307@gmail.com",
			Status = Domain.Enums.AccountStatus.Active, // 0 or 1
			CreateDate = new DateTime(2023, 8, 1).AddDays(10)
		});
		accounts.Add(new Account()
		{
			Id = Guid.Parse("35ff4cc4-7823-4ffb-95e4-c2e73dace190"),
			Username = "Client",
			Password = Hash.EncryptPassword("abc123"),
			Role = Domain.Enums.AccountRole.User, // 1, 2, or 3
			Avatar = $"avatar2.png",
			Name = "ClientTest",
			Phone = "000-000-000",
			Email = "azusachan309@gmail.com",
			Status = Domain.Enums.AccountStatus.Active, // 0 or 1
			CreateDate = new DateTime(2023, 8, 1).AddDays(10)
		});
		for (int i = 1; i <= 30; i++)
		{
			accounts.Add(new Account
			{
				Id = Guid.NewGuid(),
				Username = $"user{i}",
				Password = Hash.EncryptPassword($"password{i}"),
				Role = Domain.Enums.AccountRole.User, // 1, 2, or 3
				Avatar = $"avatar{i}.png",
				Name = $"User {i}",
				Phone = $"123-456-789{i}",
				Email = $"user{i}@example.com",
				Status = Domain.Enums.AccountStatus.Active, // 0 or 1
				CreateDate = new DateTime(2023, 8, 1).AddDays(i)
			});
		}
		modelBuilder.Entity<Account>().HasData(accounts);
		//Membership

		var membership = new Membership()
		{
			Id = Guid.Parse("35ff4cc4-7823-4ffb-95e4-c2e73dace190"),
			Point = 0,
			Status = Domain.Enums.MembershipStatus.Active,
		};
		modelBuilder.Entity<Membership>().HasData(membership);


		//Film
		List<Film> films = new List<Film>();
		for (int i = 1; i <= 30; i++)
		{
			Film film = new Film
			{
				Id = Guid.NewGuid(),
				Name = $"Film {i}",
				EnglishName = $"Film {i} (English)",
				Trailer = $"https://example.com/trailer{i}.mp4",
				Description = $"This is a description for Film {i}.",
				Gerne = i % 2 == 0 ? "Action" : "Comedy",
				Director = $"Director {i}",
				Cast = $"Actor {i}, Actress {i}",
				Rating = i % 5 + 1,
				StartDate = new DateTime(2023, (i % 12) + 1, (i % 28) + 1),
				ReleaseYear = 2023,
				RunningTime = (i % 120) + 60,
				Status = Domain.Enums.FilmStatus.NowShowing,
				Nation = i % 2 == 0 ? "USA" : "Japan",
				Poster = $"film_fake.jpg",
				Language = i % 2 == 0 ? "English" : "Japanese",
				CreatDate = new DateTime(2023, 8, 1).AddDays(i)
			};

			films.Add(film);
		}
		modelBuilder.Entity<Film>().HasData(films);
		//CinemaCenter
		List<CinemaCenter> cinemaCenters = new List<CinemaCenter>();
		for (int i = 1; i <= 30; i++)
		{
			CinemaCenter cinemaCenter = new CinemaCenter
			{
				Id = Guid.NewGuid(),
				Name = $"Cinema Center {i}",
				Address = $"Address {i}"
			};

			cinemaCenters.Add(cinemaCenter);
		}
		modelBuilder.Entity<CinemaCenter>().HasData(cinemaCenters);
		//Combo 
		List<Combo> combos = new List<Combo>();
		for (int i = 1; i <= 30; i++)
		{
			Combo combo = new Combo
			{
				Id = Guid.NewGuid(),
				Name = $"Combo {i}",
				Price = (i % 10) * 10000,
			};
			combos.Add(combo);
		}
		modelBuilder.Entity<Combo>().HasData(combos);
		//Promotion
		List<Promotion> promotions = new List<Promotion>();
		for (int i = 1; i <= 30; i++)
		{
			Promotion promotion = new Promotion
			{
				Id = Guid.NewGuid(),
				Title = $"Title {i}"
			};

			promotions.Add(promotion);
		}
		modelBuilder.Entity<Promotion>().HasData(promotions);
		//ScreeningDay 
		List<ScreeningDay> screeningDays = new List<ScreeningDay>() {
			new ScreeningDay
			{
				Id = Guid.Parse("d51bee9b-54c3-4a3c-a06a-7c3940852f57"),
				Day ="T2-CN"
			},
			new ScreeningDay
			{
				Id = Guid.Parse("7136ed84-69f4-46dc-a784-857bb2c91c42"),
				Day ="T2-T6"
			},
			new ScreeningDay
			{
				Id = Guid.Parse("e4f8f494-4e25-4966-806a-7b8843d79b6b"),
				Day ="T7-CN"
			},
		};
		modelBuilder.Entity<ScreeningDay>().HasData(screeningDays);
		//SeatType
		List<SeatType> seatTypes = new List<SeatType>()
			{
				new SeatType()
				{
					Id = Guid.Parse("e548fd61-3d84-4104-b15e-f13d5d7d53ed"),
					Name = "Normal"
				},
				new SeatType()
				{
					Id = Guid.Parse("d997b27a-ddb7-4ad1-a1cd-c2bd00c50cb9"),
					Name = "VIP"
				},
				new SeatType()
				{
					Id = Guid.Parse("428edc6b-0862-4623-b038-ac505fd554bc"),
					Name = "Couple"
				}
			};
		modelBuilder.Entity<SeatType>().HasData(seatTypes);
		//CinemaType
		List<CinemaType> cinemaTypes = new List<CinemaType>() {
				new CinemaType
				{
					Id = Guid.Parse("e85df49a-e99d-4727-917f-28ca67bf33ec"),
					Name = "2D"
				},
				new CinemaType
				{
					Id = Guid.Parse("fbe455d5-c40e-432e-9b28-edac59f7e481"),
					Name = "Gold Class"
				},
				new CinemaType
				{
					Id = Guid.Parse("03846649-c852-443c-9f5c-f935343318d5"),
					Name = "Premium Class"
				}
			};
		modelBuilder.Entity<CinemaType>().HasData(cinemaTypes);
		//Schedule
		List<Schedule> schedules = new List<Schedule>();
		for (int i = 1; i <= 30; i++)
		{
			Schedule schedule = new Schedule
			{
				Id = Guid.NewGuid(),
				FilmId = films[i - 1].Id,
				StartDate = new DateTime(2023, 8, 1).AddDays(i),
				EndDate = new DateTime(2023, 8, 1).AddDays(i + 1),
				Type = (ScheduleType)Enum.GetValues(typeof(ScheduleType)).GetValue(random.Next(0, Enum.GetValues(typeof(ScheduleType)).Length)),
				Status = ScheduleStatus.Showing
			};
			schedules.Add(schedule);
		}
		modelBuilder.Entity<Schedule>().HasData(schedules);
		//ScreenType
		List<ScreenType> screenTypes = new List<ScreenType>() {
				new ScreenType
				{
					Id = Guid.Parse("2b18932d-3074-4ba9-9d4b-97b09feac482"),
					Type = "2D"
				},
				new ScreenType
				{
					Id = Guid.Parse("36bbb6d8-eda5-4353-9f9c-765e24ff0122"),
					Type = "3D"
				},
				new ScreenType
				{
					Id = Guid.Parse("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"),
					Type = "IMAX"
				}
			};
		modelBuilder.Entity<ScreenType>().HasData(screenTypes);
		//TicketPrice
		List<TicketPrice> ticketPrice = new List<TicketPrice>();
		for (int i = 1; i <= 30; i++)
		{
			TicketPrice ticket = new TicketPrice
			{
				Id = Guid.NewGuid(),
				Price = (i % 10) * 10000,
				SeatTypeId = seatTypes[random.Next(0, seatTypes.Count)].Id,
				ScreeningDayId = screeningDays[random.Next(0, screeningDays.Count)].Id,
				CinemaTypeId = cinemaTypes[random.Next(0, cinemaTypes.Count)].Id,
				ScreenTypeId = screenTypes[random.Next(0, screenTypes.Count)].Id,
				Status = TicketPriceStatus.Active
			};
			ticketPrice.Add(ticket);
		}
		modelBuilder.Entity<TicketPrice>().HasData(ticketPrice);
		//TranslationType
		List<TranslationType> translationTypes = new List<TranslationType>() {
				new TranslationType
				{
					Id = Guid.Parse("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30"),
					Type = "Phụ đề"
				},
				new TranslationType
				{
					Id = Guid.Parse("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf"),
					Type = "Phụ đề và Lồng tiếng"
				}
			};
		modelBuilder.Entity<TranslationType>().HasData(translationTypes);
		//Cinema
		List<Cinema> cinemas = new List<Cinema>();
		for (int i = 1; i <= 30; i++)
		{
			Cinema cinema = new Cinema
			{
				Id = Guid.NewGuid(),
				CinemaTypeId = cinemaTypes[random.Next(0, cinemaTypes.Count)].Id,
				CinemaCenterId = cinemaCenters[i - 1].Id,
				Name = $"Cinema {i}",
				Column = 10,
				Row = 10,
				MaxSeatCapacity = 100,
				Description = $"Description for Cinema {i}"
			};
			cinemas.Add(cinema);
		}
		modelBuilder.Entity<Cinema>().HasData(cinemas);
		//ShowTime
		List<ShowTime> showTimes = new List<ShowTime>();
		for (int i = 1; i <= 30; i++)
		{

			ShowTime showTime = new ShowTime
			{
				Id = Guid.NewGuid(),
				ScheduleId = schedules[i - 1].Id,
				FilmId = schedules[i - 1].FilmId,

				CinemaId = cinemas[i - 1].Id,
				CinemaCenterId = cinemas[i - 1].CinemaCenterId,

				ScreenTypeId = screenTypes[random.Next(0, screenTypes.Count)].Id,
				TranslationTypeId = translationTypes[random.Next(0, translationTypes.Count)].Id,
				StartTime = new DateTime(2024, 10, 1).AddDays(i),
				EndTime = new DateTime(2024, 10, 1).AddHours(2),
				Desciption = $"Description for ShowTime {i}",
				Status = ShowtimeStatus.Showing
			};
			showTimes.Add(showTime);

		}
		modelBuilder.Entity<ShowTime>().HasData(showTimes);
		//Ticket
		List<Bill> bills = new List<Bill>();
		for (int i = 1; i <= 30; i++)
		{
			Bill bill = new Bill
			{
				Id = Guid.NewGuid(),
				TotalMoney = (i % 10) * 10000,
				CreateTime = new DateTime(2024, 10, 1).AddDays(i),
				BarCode = $"barcode{i}.jpg",
				Status = BillStatus.Paid,
				ActivationStatus = true,
				MembershipId = Guid.Parse("35ff4cc4-7823-4ffb-95e4-c2e73dace190"),
				VoucherId = null,
			};
			bills.Add(bill);
		}
		modelBuilder.Entity<Bill>().HasData(bills);
		//Seat
		List<Seat> seats = new List<Seat>();
		int? rows = cinemas[0].Row;  // Số hàng từ A đến N
		int? cols = cinemas[0].Column;  // Số cột từ 1 đến 16

		// Vòng lặp qua từng hàng
		for (int row = 0; row < rows; row++)
		{
			// Lấy ký tự tương ứng từ 'A' bắt đầu từ ASCII 65
			char rowChar = (char)('A' + row);

			// Vòng lặp qua từng cột
			for (int col = 1; col <= cols; col++)
			{
				// In ra chữ và số tương ứng với hàng và cột
			
					Seat seat = new Seat
					{
						Id = Guid.NewGuid(),
						CinemaId = cinemas[0].Id,
						SeatTypeId = seatTypes[0].Id,
						Position = $"{rowChar}{col}",
						Status = SeatStatus.Available,
					};
					seats.Add(seat);
				
			}

		}
		modelBuilder.Entity<Seat>().HasData(seats);
		//Ticket
		List<Ticket> tickets = new List<Ticket>();
		for (int i = 1; i <= 30; i++)
		{
			Ticket ticket = new Ticket
			{
				Id = Guid.NewGuid(),
				SeatId = seats[random.Next(0, seats.Count)].Id,
				ShowTimeId = showTimes[i - 1].Id,
				BillId = bills[i - 1].Id,
				Qrcode = $"qrcode{i}.jpg",
				Status = TicketStatus.Used,
				TicketPriceId = ticketPrice[i - 1].Id,
				CinemaCenterId = cinemaCenters[random.Next(0, cinemaCenters.Count)].Id,
				Description = $"Description for Ticket {i}"
			};
			tickets.Add(ticket);
		}
		modelBuilder.Entity<Ticket>().HasData(tickets);
	}



}
