using Bogus;
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
    public virtual DbSet<Coupon> Coupons { get; set; }
    public virtual DbSet<Banner> Banners { get; set; }
    public virtual DbSet<About> Abouts { get; set; }

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
            Avatar = "img/Avatar/avatar.jpg",
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
            Avatar = "img/Avatar/avatar.jpg",
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
        .RuleFor(f => f.StartDate, f => f.Date.Between(DateTime.Now, DateTime.Now.AddDays(10)))
        .RuleFor(f => f.ReleaseYear, 2024)
        .RuleFor(f => f.RunningTime, f => f.Random.Int(60, 180))
        .RuleFor(f => f.Nation, f => f.PickRandom("USA", "Japan"))
        .RuleFor(f => f.Poster, "img/posterFilm/film_modomdom.jpg")
        .RuleFor(f => f.Language, f => f.PickRandom("English", "Japanese"))
        .RuleFor(f => f.CreatDate, DateTime.Now);
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
        List<CinemaCenter> cinemaCenters = new List<CinemaCenter>();

        cinemaCenters.Add(new CinemaCenter()
        {
            Id = Guid.NewGuid(),
            Name = "VHD Vincom Mỹ Đình",
            Address = "Số 1 Mỹ Đình, Nam Từ Liêm,Hà Nội",
            AddressMap = "https://goo.gl/maps/1",
            CreateDate = DateTime.Now,
        });
        cinemaCenters.Add(new CinemaCenter()
        {
            Id = Guid.NewGuid(),
            Name = "VHD Vincom Nguyễn Chí Thanh",
            Address = "Số 1 Nguyễn Chí Thanh, Ba Đình,Hà Nội",
            AddressMap = "https://goo.gl/maps/2",
            CreateDate = DateTime.Now,
        });
        cinemaCenters.Add(new CinemaCenter()
        {
            Id = Guid.NewGuid(),
            Name = "VHD TimeCity",
            Address = "Số 1 Minh Khai, Hai Bà Trưng,Hà Nội",
            AddressMap = "https://goo.gl/maps/2",
            CreateDate = DateTime.Now,
        });
        modelBuilder.Entity<CinemaCenter>().HasData(cinemaCenters);
        // Faker for Combo
        var comboFaker = new Faker<Combo>()
               .RuleFor(c => c.Id, f => Guid.NewGuid())
               .RuleFor(c => c.Name, f => $"Combo {f.IndexFaker}")
               .RuleFor(c => c.Price, 90000)
               .RuleFor(c => c.Description, "02 nước ngọt siêu lớn + 01 bắp hai vị\r\n- Nhận 01 mã dự thưởng có cơ hội trúng Huy Hiệu Vàng kỉ niệm 10 năm đồng hành CGVxCOCA. Chi tiết chương trình tham khảo thêm tại website www.cgv.vn")
               .RuleFor(c => c.ComboStatus, ComboStatus.Available)
               .RuleFor(c => c.Image, "img/Combo/combo.png");

        modelBuilder.Entity<Combo>().HasData(comboFaker.Generate(5));
        // Faker for ScreeningDay (ensure unique values)
        // Faker for ScreeningDay
        var screeningDayList = new List<string> { "T2-T6", "T7-CN" };
        var screeningDayFaker = new Faker<ScreeningDay>()
            .RuleFor(s => s.Id, f => Guid.NewGuid())
            .RuleFor(s => s.Day, f =>
            {
                var day = screeningDayList.First(); // Lấy phần tử đầu tiên
                screeningDayList.RemoveAt(0); // Loại bỏ phần tử đã chọn để đảm bảo không trùng lặp
                return day;
            });

        var screeningDays = screeningDayFaker.Generate(2); // Sinh ra đúng 3 loại ngày
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
            .RuleFor(b => b.TotalMoney, f => f.Finance.Amount(70000, 300000))
            .RuleFor(b => b.CreateTime, f => f.Date.Between(DateTime.Now, DateTime.Now.AddDays(30)))
            .RuleFor(b => b.BarCode, f => $"barcode{f.IndexFaker}.jpg")
            .RuleFor(b => b.Status, BillStatus.Paid)
            .RuleFor(b => b.ActivationStatus, true)
            .RuleFor(b => b.MembershipId, Guid.Parse("35ff4cc4-7823-4ffb-95e4-c2e73dace190"))
            .RuleFor(b => b.CouponId, (Guid?)null);
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
                .RuleFor(s => s.StartDate, f => f.Date.Between(DateTime.Now, DateTime.Now.AddDays(20)))
            .RuleFor(s => s.EndDate, (f, s) => s.StartDate.AddDays(30))
                .RuleFor(s => s.Type, ScheduleType.Regular)
                .RuleFor(s => s.Status, ScheduleStatus.Showing)
                .Generate();

            schedules.Add(schedule);
        }
        // Generate list of schedules
        modelBuilder.Entity<Schedule>().HasData(schedules);
        List<TicketPrice> ticketPrices = new List<TicketPrice>();
        List<Guid> seatTypeIds = seatTypes.Select(s => s.Id).ToList();
        List<Guid> screeningDayIds = screeningDays.Select(s => s.Id).ToList();
        List<Guid> cinemaTypeIds = cinemaTypes.Select(c => c.Id).ToList();
        List<Guid> screenTypeIds = screenTypes.Select(s => s.Id).ToList();

        HashSet<(Guid seat, Guid day, Guid cinema, Guid screen)> uniqueCombinations = new HashSet<(Guid, Guid, Guid, Guid)>();

        var combinations = from seat in seatTypeIds
                           from day in screeningDayIds
                           from cinema in cinemaTypeIds
                           from screen in screenTypeIds
                           select new { seat, day, cinema, screen };

        foreach (var combo in combinations)
        {
            var uniqueKey = (combo.seat, combo.day, combo.cinema, combo.screen);

            if (uniqueCombinations.Contains(uniqueKey)) continue;
            uniqueCombinations.Add(uniqueKey);

            // Set default price
            decimal price = 100000;

            // Identify the screening day (T2-T6 or T7-CN) and assign price accordingly
            var isWeekday = screeningDays.First(sd => sd.Id == combo.day).Day == "T2-T6";

            // Determine the seat type and assign prices based on the day and seat type
            var seatTypeName = seatTypes.First(st => st.Id == combo.seat).Name;

            if (isWeekday)
            {
                switch (seatTypeName)
                {
                    case "Normal":
                        price = 45000;
                        break;

                    case "VIP":
                        price = 50000;
                        break;

                    case "Couple":
                        price = 50000;
                        break;
                }
            }
            else // T7-CN
            {
                switch (seatTypeName)
                {
                    case "Normal":
                        price = 60000;
                        break;

                    case "VIP":
                        price = 65000;
                        break;

                    case "Couple":
                        price = 65000;
                        break;
                }
            }

            TicketPrice ticket = new TicketPrice
            {
                Id = Guid.NewGuid(),
                Price = price,
                SeatTypeId = combo.seat,
                ScreeningDayId = combo.day,
                CinemaTypeId = combo.cinema,
                ScreenTypeId = combo.screen,
                Status = TicketPriceStatus.Active
            };

            ticketPrices.Add(ticket);
        }

        modelBuilder.Entity<TicketPrice>().HasData(ticketPrices);
        var coupon = new List<Coupon>();
        coupon.Add(new Coupon()
        {
            Id = Guid.NewGuid(),
            CouponCode = "HELLOWORLD",
            AmountValue = 25000,
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddDays(30),
            IsActive = false,
        });
        coupon.Add(new Coupon()
        {
            Id = Guid.NewGuid(),
            CouponCode = "VHDKHAITRUONG",
            AmountValue = 25000,
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddDays(30),
            IsActive = false,
        });
        modelBuilder.Entity<Coupon>().HasData(coupon);

        var abouts = new List<About>();

        #region About

        abouts.Add(new About()
        {
            Id = Guid.NewGuid(),
            Title = "Tuyển dụng",
            Content = "<div class=\"container my-5\"><!-- Section giới thiệu --><section class=\"mb-5\"><h2 class=\"text-center mb-4\">V&igrave; sao bạn n&ecirc;n gia nhập ch&uacute;ng t&ocirc;i?</h2><p>Tại VHD Media, ch&uacute;ng t&ocirc;i kh&ocirc;ng chỉ l&agrave; nơi l&agrave;m việc m&agrave; c&ograve;n l&agrave; nơi bạn sống với đam m&ecirc; điện ảnh. Ch&uacute;ng t&ocirc;i mang đến m&ocirc;i trường s&aacute;ng tạo, trẻ trung v&agrave; cơ hội ph&aacute;t triển bản th&acirc;n trong ng&agrave;nh giải tr&iacute; đầy hấp dẫn.</p></section><!-- Section các vị trí tuyển dụng --><section class=\"mb-5\"><h2 class=\"text-center mb-4\">C&aacute;c vị tr&iacute; đang tuyển dụng</h2><div class=\"list-group\"><a href=\"#\" class=\"list-group-item list-group-item-action\"><h5 class=\"mb-1\">Chuy&ecirc;n vi&ecirc;n Marketing</h5><p class=\"mb-1\"><strong>M&ocirc; tả c&ocirc;ng việc:</strong> L&ecirc;n kế hoạch, triển khai c&aacute;c chiến dịch quảng c&aacute;o thu h&uacute;t kh&aacute;ch h&agrave;ng.</p><p class=\"mb-1\"><strong>Y&ecirc;u cầu:</strong> C&oacute; kinh nghiệm tối thiểu 1 năm trong Marketing, y&ecirc;u th&iacute;ch điện ảnh.</p></a> <a href=\"#\" class=\"list-group-item list-group-item-action\"><h5 class=\"mb-1\">Kỹ sư Phần mềm</h5><p class=\"mb-1\"><strong>M&ocirc; tả c&ocirc;ng việc:</strong> Ph&aacute;t triển v&agrave; tối ưu h&oacute;a hệ thống đặt v&eacute; online.</p><p class=\"mb-1\"><strong>Y&ecirc;u cầu:</strong> Th&agrave;nh thạo .NET, Blazor, v&agrave; c&aacute;c c&ocirc;ng nghệ web hiện đại.</p></a> <a href=\"#\" class=\"list-group-item list-group-item-action\"><h5 class=\"mb-1\">Nh&acirc;n vi&ecirc;n chăm s&oacute;c kh&aacute;ch h&agrave;ng</h5><p class=\"mb-1\"><strong>M&ocirc; tả c&ocirc;ng việc:</strong> Hỗ trợ kh&aacute;ch h&agrave;ng đặt v&eacute;, giải đ&aacute;p thắc mắc qua tổng đ&agrave;i.</p><p class=\"mb-1\"><strong>Y&ecirc;u cầu:</strong> Giao tiếp tốt, ki&ecirc;n nhẫn v&agrave; xử l&yacute; t&igrave;nh huống nhanh.</p></a></div></section><!-- Section cách thức ứng tuyển --><section><h2 class=\"text-center mb-4\">C&aacute;ch thức ứng tuyển</h2><p class=\"text-center\">Gửi CV của bạn qua email: <a href=\"mailto:tuyendung@tencongty.com\">tuyendung@VHDMedia.com</a> hoặc li&ecirc;n hệ qua hotline: <strong>0123 456 789</strong>.</p><p class=\"text-center\">Ch&uacute;ng t&ocirc;i rất h&aacute;o hức chờ đ&oacute;n bạn!</p></section></div>",
        });
        abouts.Add(new About()
        {
            Id = Guid.NewGuid(),
            Title = "Giới thiệu",
            Content = "<p><span contenteditable=\"false\" draggable=\"true\" class=\"fr-video fr-deletable fr-fvc fr-draggable fr-dvb\"><iframe width=\"640\" height=\"360\" src=\"https://www.youtube.com/embed/e1ZSLVTZ47M?&wmode=opaque&rel=0\" frameborder=\"0\" allowfullscreen=\"\" class=\"fr-draggable\"><span class=\"fr-mk\" style=\"display: none;\">&nbsp;</span><span class=\"fr-mk\" style=\"display: none;\">&nbsp;</span></iframe>&nbsp;</span></p><div class=\"website-intro\"><h1 style=\"text-align: center; color: #ff5733;\">Ch&agrave;o mừng đến với <strong>VHD</strong></h1><p style=\"text-align: justify; font-size: 18px; line-height: 1.6;\"><strong>[T&ecirc;n Trang Web]</strong> l&agrave; nền tảng đặt v&eacute; xem phim trực tuyến h&agrave;ng đầu, gi&uacute;p bạn dễ d&agrave;ng kh&aacute;m ph&aacute; những bộ phim bom tấn, chọn chỗ ngồi y&ecirc;u th&iacute;ch, v&agrave; tận hưởng trải nghiệm xem phim ho&agrave;n hảo c&ugrave;ng gia đ&igrave;nh, bạn b&egrave;.</p><h2 style=\"color: #2a9d8f;\">T&iacute;nh năng nổi bật:</h2><ul style=\"font-size: 18px; line-height: 1.8;\"><li><strong>Đa dạng rạp chiếu:</strong> Li&ecirc;n kết với c&aacute;c rạp lớn tr&ecirc;n to&agrave;n quốc, cập nhật lịch chiếu nhanh ch&oacute;ng.</li><li><strong>Chọn ghế linh hoạt:</strong> Giao diện trực quan, dễ d&agrave;ng t&igrave;m chỗ ngồi l&yacute; tưởng.</li><li><strong>Ưu đ&atilde;i hấp dẫn:</strong> Cập nhật voucher, khuyến m&atilde;i độc quyền d&agrave;nh ri&ecirc;ng cho th&agrave;nh vi&ecirc;n.</li></ul><h2 style=\"color: #e76f51;\">Tại sao chọn ch&uacute;ng t&ocirc;i?</h2><p style=\"text-align: justify; font-size: 18px; line-height: 1.6;\">Với hệ thống bảo mật ti&ecirc;n tiến, giao diện th&acirc;n thiện v&agrave; dịch vụ kh&aacute;ch h&agrave;ng tận t&acirc;m, <strong>VHD</strong> lu&ocirc;n đặt trải nghiệm của bạn l&ecirc;n h&agrave;ng đầu.</p></div>",
        }); abouts.Add(new About()
        {
            Id = Guid.NewGuid(),
            Title = "Liên hệ",
            Content = "<div class=\"container my-5\"><h2 class=\"text-center mb-4\">Li&ecirc;n Hệ Với Ch&uacute;ng T&ocirc;i</h2><!-- Thông tin liên hệ --><section class=\"mb-5\"><h4 class=\"bg-white text-black\">Th&ocirc;ng tin li&ecirc;n hệ</h4><p>Để biết th&ecirc;m th&ocirc;ng tin hoặc hỗ trợ, bạn c&oacute; thể li&ecirc;n hệ với ch&uacute;ng t&ocirc;i qua c&aacute;c k&ecirc;nh dưới đ&acirc;y:</p><ul class=\"list-unstyled\"><li><strong>Địa chỉ:</strong> 123 Đường ABC, Quận 1, TP. Hồ Ch&iacute; Minh</li><li><strong>Điện thoại:</strong> <a href=\"tel:+84123456789\">(+84) 123 456 789</a></li><li><strong>Email:</strong> <a href=\"mailto:contact@tencongty.com\">contact@VHDMedia.com</a></li></ul></section></div>",
        }); abouts.Add(new About()
        {
            Id = Guid.NewGuid(),
            Title = "F.A.Q",
            Content = "<div class=\"container my-5\"><h2 class=\"text-center mb-4\">C&acirc;u Hỏi Thường Gặp (FAQ)</h2><div class=\"accordion\" id=\"faqAccordion\"><!-- Câu hỏi 1 --><div class=\"accordion-item\"><h2 class=\"accordion-header\" id=\"headingOne\"><button class=\"accordion-button collapsed\" type=\"button\" data-bs-toggle=\"collapse\" data-bs-target=\"#collapseOne\" aria-expanded=\"false\">&nbsp;1. L&agrave;m thế n&agrave;o để đặt v&eacute; xem phim tr&ecirc;n website?&nbsp;</button></h2><div id=\"collapseOne\" class=\"accordion-collapse collapse\" data-bs-parent=\"#faqAccordion\"><div class=\"accordion-body\">Bạn chỉ cần chọn phim, chọn lịch chiếu v&agrave; số lượng v&eacute;. Sau đ&oacute;, bạn điền th&ocirc;ng tin thanh to&aacute;n v&agrave; ho&agrave;n tất qu&aacute; tr&igrave;nh mua v&eacute;.</div></div></div><!-- Câu hỏi 2 --><div class=\"accordion-item\"><h2 class=\"accordion-header\" id=\"headingTwo\"><button class=\"accordion-button collapsed\" type=\"button\" data-bs-toggle=\"collapse\" data-bs-target=\"#collapseTwo\" aria-expanded=\"false\">&nbsp;2. L&agrave;m thế n&agrave;o để t&ocirc;i nhận v&eacute; đ&atilde; mua?&nbsp;</button></h2><div id=\"collapseTwo\" class=\"accordion-collapse collapse\" data-bs-parent=\"#faqAccordion\"><div class=\"accordion-body\">V&eacute; sẽ được gửi đến email của bạn dưới dạng m&atilde; QR hoặc bạn c&oacute; thể nhận v&eacute; trực tiếp tại quầy v&eacute; của rạp.</div></div></div><!-- Câu hỏi 3 --><div class=\"accordion-item\"><h2 class=\"accordion-header\" id=\"headingThree\"><button class=\"accordion-button collapsed\" type=\"button\" data-bs-toggle=\"collapse\" data-bs-target=\"#collapseThree\" aria-expanded=\"false\">&nbsp;3. T&ocirc;i c&oacute; thể hủy v&eacute; sau khi đ&atilde; mua kh&ocirc;ng?&nbsp;</button></h2><div id=\"collapseThree\" class=\"accordion-collapse collapse\" data-bs-parent=\"#faqAccordion\"><div class=\"accordion-body\">Ch&uacute;ng t&ocirc;i kh&ocirc;ng hỗ trợ hủy v&eacute; sau khi thanh to&aacute;n. Tuy nhi&ecirc;n, bạn c&oacute; thể đổi v&eacute; nếu c&oacute; l&yacute; do ch&iacute;nh đ&aacute;ng v&agrave; trong thời gian cho ph&eacute;p.</div></div></div><!-- Câu hỏi 4 --><div class=\"accordion-item\"><h2 class=\"accordion-header\" id=\"headingFour\"><button class=\"accordion-button collapsed\" type=\"button\" data-bs-toggle=\"collapse\" data-bs-target=\"#collapseFour\" aria-expanded=\"false\">&nbsp;4. T&ocirc;i c&oacute; thể thanh to&aacute;n bằng h&igrave;nh thức n&agrave;o?&nbsp;</button></h2><div id=\"collapseFour\" class=\"accordion-collapse collapse\" data-bs-parent=\"#faqAccordion\"><div class=\"accordion-body\">Ch&uacute;ng t&ocirc;i hỗ trợ nhiều phương thức thanh to&aacute;n, bao gồm thẻ t&iacute;n dụng, thẻ ghi nợ, v&iacute; điện tử v&agrave; chuyển khoản ng&acirc;n h&agrave;ng.</div></div></div><!-- Câu hỏi 5 --><div class=\"accordion-item\"><h2 class=\"accordion-header\" id=\"headingFive\"><button class=\"accordion-button collapsed\" type=\"button\" data-bs-toggle=\"collapse\" data-bs-target=\"#collapseFive\" aria-expanded=\"false\">&nbsp;5. T&ocirc;i c&oacute; thể thay đổi th&ocirc;ng tin v&eacute; đ&atilde; đặt kh&ocirc;ng?&nbsp;</button></h2><div id=\"collapseFive\" class=\"accordion-collapse collapse\" data-bs-parent=\"#faqAccordion\"><div class=\"accordion-body\">Bạn kh&ocirc;ng thể thay đổi th&ocirc;ng tin v&eacute; sau khi đ&atilde; x&aacute;c nhận v&agrave; thanh to&aacute;n. Tuy nhi&ecirc;n, nếu c&oacute; sự cố, vui l&ograve;ng li&ecirc;n hệ với bộ phận hỗ trợ kh&aacute;ch h&agrave;ng.</div></div></div></div></div><!-- Bootstrap JS, Popper.js và jQuery -->",
        }); abouts.Add(new About()
        {
            Id = Guid.NewGuid(),
            Title = "Hoạt động xã hội",
            Content = "<div class=\"container my-5\"><h2 class=\"text-center mb-4\">Hoạt Động X&atilde; Hội</h2><!-- Hoạt động 1 --><div class=\"mb-4\"><h4 class=\"bg-white text-black\">Chương Tr&igrave;nh Tặng Qu&agrave; Cho Trẻ Em</h4><p>Ch&uacute;ng t&ocirc;i tổ chức chương tr&igrave;nh tặng qu&agrave; cho c&aacute;c em nhỏ c&oacute; ho&agrave;n cảnh kh&oacute; khăn v&agrave;o dịp Trung Thu mỗi năm.</p></div><!-- Hoạt động 2 --><div class=\"mb-4\"><h4 class=\"bg-white text-black\">Ng&agrave;y Hội Cộng Đồng</h4><p>Ng&agrave;y hội cộng đồng nhằm hỗ trợ người cao tuổi với c&aacute;c hoạt động như tư vấn sức khỏe v&agrave; giao lưu văn h&oacute;a.</p></div><!-- Hoạt động 3 --><div class=\"mb-4\"><h4 class=\"bg-white text-black\">Hoạt Động Thu Gom R&aacute;c</h4><p>Hoạt động thu gom r&aacute;c thải cộng đồng để bảo vệ m&ocirc;i trường, thu h&uacute;t sự tham gia của t&igrave;nh nguyện vi&ecirc;n v&agrave; cộng đồng địa phương.</p></div><!-- Tham gia tình nguyện --><div class=\"text-center mt-4\"><a href=\"https://www.steamforvietnam.org/\" class=\"btn btn-success\">Đăng k&yacute; tham gia</a></div></div>",
        }); abouts.Add(new About()
        {
            Id = Guid.NewGuid(),
            Title = "Điều khoản sử dụng",
            Content = "<div class=\"container my-5\"><h2 class=\"text-center mb-4\">Điều Khoản Sử Dụng</h2><section><h4 class=\"bg-white text-black\">1. Giới Thiệu</h4><p>Ch&agrave;o mừng bạn đến với website của ch&uacute;ng t&ocirc;i. Bằng c&aacute;ch truy cập v&agrave; sử dụng dịch vụ của ch&uacute;ng t&ocirc;i, bạn đồng &yacute; với c&aacute;c điều khoản sử dụng dưới đ&acirc;y.</p></section><section><h4 class=\"bg-white text-black\">2. Quyền Sử Dụng Dịch Vụ</h4><p>Người d&ugrave;ng c&oacute; quyền sử dụng dịch vụ của ch&uacute;ng t&ocirc;i cho c&aacute;c mục đ&iacute;ch hợp ph&aacute;p. Việc sử dụng dịch vụ tr&aacute;i ph&eacute;p sẽ dẫn đến việc bị kh&oacute;a t&agrave;i khoản hoặc bị xử l&yacute; theo ph&aacute;p luật.</p></section><section><h4 class=\"bg-white text-black\">3. Tr&aacute;ch Nhiệm Của Người D&ugrave;ng</h4><p>Người d&ugrave;ng chịu tr&aacute;ch nhiệm bảo mật th&ocirc;ng tin t&agrave;i khoản của m&igrave;nh v&agrave; đảm bảo rằng c&aacute;c th&ocirc;ng tin cung cấp cho website l&agrave; ch&iacute;nh x&aacute;c v&agrave; đầy đủ.</p></section><section><h4 class=\"bg-white text-black\">4. Quyền Sở Hữu Nội Dung</h4><p>Tất cả nội dung tr&ecirc;n website (bao gồm nhưng kh&ocirc;ng giới hạn ở văn bản, h&igrave;nh ảnh, logo) thuộc quyền sở hữu của ch&uacute;ng t&ocirc;i v&agrave; kh&ocirc;ng được sao ch&eacute;p hoặc sử dụng m&agrave; kh&ocirc;ng c&oacute; sự cho ph&eacute;p.</p></section><section><h4 class=\"bg-white text-black\">5. Bảo Mật Th&ocirc;ng Tin</h4><p>Ch&uacute;ng t&ocirc;i cam kết bảo vệ th&ocirc;ng tin c&aacute; nh&acirc;n của người d&ugrave;ng v&agrave; sẽ kh&ocirc;ng tiết lộ th&ocirc;ng tin n&agrave;y cho b&ecirc;n thứ ba m&agrave; kh&ocirc;ng c&oacute; sự đồng &yacute; của bạn, trừ khi c&oacute; y&ecirc;u cầu ph&aacute;p l&yacute;.</p></section><section><h4 class=\"bg-white text-black\">6. Điều Khoản Thay Đổi</h4><p>Ch&uacute;ng t&ocirc;i c&oacute; quyền thay đổi c&aacute;c điều khoản sử dụng n&agrave;y v&agrave;o bất kỳ l&uacute;c n&agrave;o m&agrave; kh&ocirc;ng cần th&ocirc;ng b&aacute;o trước. Mọi thay đổi sẽ c&oacute; hiệu lực ngay khi được c&ocirc;ng bố tr&ecirc;n website.</p></section></div>",
        }); abouts.Add(new About()
        {
            Id = Guid.NewGuid(),
            Title = "Liên hệ quảng cáo",
            Content = "<div class=\"container my-5\"><h2 class=\"text-center mb-4\">Li&ecirc;n Hệ Quảng C&aacute;o</h2><!-- Giới thiệu --><section class=\"mb-5\"><h4 class=\"text-center bg-white text-black mb-3\">H&atilde;y li&ecirc;n hệ với ch&uacute;ng t&ocirc;i để đặt quảng c&aacute;o</h4><p class=\"text-center\">Nếu bạn muốn quảng b&aacute; sản phẩm hoặc dịch vụ của m&igrave;nh th&ocirc;ng qua c&aacute;c k&ecirc;nh quảng c&aacute;o của ch&uacute;ng t&ocirc;i, vui l&ograve;ng điền th&ocirc;ng tin v&agrave;o mẫu dưới đ&acirc;y hoặc li&ecirc;n hệ trực tiếp qua email hoặc điện thoại.</p></section><!-- Thông tin liên hệ --><section class=\"mb-5\"><h5>Th&ocirc;ng tin li&ecirc;n hệ</h5><ul class=\"list-unstyled\"><li><strong>Địa chỉ:</strong> 123 Đường ABC, Quận 1, TP. Hồ Ch&iacute; Minh</li><li><strong>Điện thoại:</strong> <a href=\"tel:+84123456789\">(+84) 123 456 789</a></li><li><strong>Email:</strong> <a href=\"mailto:ads@tencongty.com\">ads@tencongty.com</a></li></ul></section></div>",
        }); abouts.Add(new About()
        {
            Id = Guid.NewGuid(),
            Title = "Điều khoản bảo mật",
            Content = "<div class=\"container my-5\"><h2 class=\"text-center mb-4\">Điều Khoản Bảo Mật</h2><section><h4 class=\"bg-white text-black\">1. Giới Thiệu</h4><p>Ch&uacute;ng t&ocirc;i cam kết bảo vệ quyền ri&ecirc;ng tư v&agrave; th&ocirc;ng tin c&aacute; nh&acirc;n của bạn. Điều khoản bảo mật n&agrave;y m&ocirc; tả c&aacute;ch ch&uacute;ng t&ocirc;i thu thập, sử dụng v&agrave; bảo vệ th&ocirc;ng tin khi bạn sử dụng dịch vụ của ch&uacute;ng t&ocirc;i.</p></section><section><h4 class=\"bg-white text-black\">2. Th&ocirc;ng Tin Ch&uacute;ng T&ocirc;i Thu Thập</h4><p>Ch&uacute;ng t&ocirc;i c&oacute; thể thu thập c&aacute;c th&ocirc;ng tin c&aacute; nh&acirc;n bao gồm nhưng kh&ocirc;ng giới hạn ở:</p><ul><li>Họ t&ecirc;n, email, số điện thoại, địa chỉ</li><li>Th&ocirc;ng tin thanh to&aacute;n (nếu c&oacute;)</li><li>Th&ocirc;ng tin thiết bị v&agrave; hoạt động tr&ecirc;n website</li></ul></section><section><h4 class=\"bg-white text-black\">3. C&aacute;ch Ch&uacute;ng T&ocirc;i Sử Dụng Th&ocirc;ng Tin</h4><p>Th&ocirc;ng tin c&aacute; nh&acirc;n của bạn được sử dụng cho c&aacute;c mục đ&iacute;ch sau:</p><ul><li>Quản l&yacute; t&agrave;i khoản người d&ugrave;ng v&agrave; cung cấp dịch vụ</li><li>Li&ecirc;n hệ với bạn về c&aacute;c dịch vụ hoặc th&ocirc;ng tin khuyến m&atilde;i</li><li>Cải thiện chất lượng dịch vụ v&agrave; trải nghiệm người d&ugrave;ng</li><li>Đảm bảo t&iacute;nh bảo mật v&agrave; ngăn chặn gian lận</li></ul></section><section><h4 class=\"bg-white text-black\">4. Chia Sẻ Th&ocirc;ng Tin</h4><p>Ch&uacute;ng t&ocirc;i cam kết kh&ocirc;ng b&aacute;n hoặc chia sẻ th&ocirc;ng tin c&aacute; nh&acirc;n của bạn với b&ecirc;n thứ ba m&agrave; kh&ocirc;ng c&oacute; sự đồng &yacute; của bạn, trừ khi c&oacute; y&ecirc;u cầu ph&aacute;p l&yacute; hoặc trong c&aacute;c trường hợp đặc biệt như:</p><ul><li>Chia sẻ với c&aacute;c đối t&aacute;c dịch vụ để cung cấp dịch vụ cho bạn (v&iacute; dụ: dịch vụ thanh to&aacute;n, hỗ trợ kh&aacute;ch h&agrave;ng)</li><li>Tu&acirc;n thủ y&ecirc;u cầu ph&aacute;p l&yacute;, bảo vệ quyền lợi v&agrave; t&agrave;i sản của c&ocirc;ng ty</li></ul></section><section><h4 class=\"bg-white text-black\">5. Bảo Mật Th&ocirc;ng Tin</h4><p>Ch&uacute;ng t&ocirc;i sử dụng c&aacute;c biện ph&aacute;p bảo mật hợp l&yacute; để bảo vệ th&ocirc;ng tin c&aacute; nh&acirc;n của bạn khỏi việc truy cập tr&aacute;i ph&eacute;p, thay đổi hoặc tiết lộ th&ocirc;ng tin. Tuy nhi&ecirc;n, kh&ocirc;ng c&oacute; phương thức truyền tải qua internet hoặc phương thức lưu trữ điện tử n&agrave;o l&agrave; ho&agrave;n to&agrave;n an to&agrave;n.</p></section><section><h4 class=\"bg-white text-black\">6. Quyền Của Người D&ugrave;ng</h4><p>Bạn c&oacute; quyền y&ecirc;u cầu ch&uacute;ng t&ocirc;i:</p><ul><li>Truy cập v&agrave; sửa chữa th&ocirc;ng tin c&aacute; nh&acirc;n m&agrave; ch&uacute;ng t&ocirc;i lưu trữ</li><li>X&oacute;a th&ocirc;ng tin c&aacute; nh&acirc;n trong một số trường hợp theo luật định</li><li>Y&ecirc;u cầu kh&ocirc;ng nhận th&ocirc;ng tin khuyến m&atilde;i từ ch&uacute;ng t&ocirc;i</li></ul></section><section><h4 class=\"bg-white text-black\">7. Thay Đổi Điều Khoản Bảo Mật</h4><p>Ch&uacute;ng t&ocirc;i c&oacute; quyền thay đổi Điều Khoản Bảo Mật n&agrave;y bất kỳ l&uacute;c n&agrave;o. Mọi thay đổi sẽ c&oacute; hiệu lực ngay khi được c&ocirc;ng bố tr&ecirc;n website.</p></section><section class=\"text-center mt-4\"><p class=\"text-muted\">Ng&agrave;y cập nhật: Th&aacute;ng 11, 2024</p></section></div>",
        }); abouts.Add(new About()
        {
            Id = Guid.NewGuid(),
            Title = "Hướng dẫn đặt vé online",
            Content = "<div class=\"container my-5\"><h2 class=\"text-center mb-4\">Hướng Dẫn Đặt V&eacute; Online</h2><!-- Giới thiệu --><section class=\"mb-5\"><h4 class=\"text-center bg-white text-black mb-3\">Ch&agrave;o mừng bạn đến với hệ thống đặt v&eacute; online của ch&uacute;ng t&ocirc;i!</h4><p class=\"text-center\">Để đặt v&eacute;, h&atilde;y l&agrave;m theo c&aacute;c bước hướng dẫn dưới đ&acirc;y. Ch&uacute;ng t&ocirc;i cung cấp dịch vụ đặt v&eacute; nhanh ch&oacute;ng v&agrave; dễ d&agrave;ng, gi&uacute;p bạn c&oacute; những trải nghiệm tuyệt vời.</p></section><!-- Các bước hướng dẫn --><section><h4 class=\"bg-white text-black\">1. Chọn Sự Kiện hoặc Phim</h4><p>Đầu ti&ecirc;n, h&atilde;y chọn sự kiện hoặc bộ phim m&agrave; bạn muốn tham gia. Bạn c&oacute; thể t&igrave;m kiếm theo thể loại, thời gian chiếu, hoặc địa điểm.</p><h4 class=\"bg-white text-black\">2. Chọn Ng&agrave;y v&agrave; Giờ</h4><p>Sau khi chọn sự kiện hoặc phim, h&atilde;y chọn ng&agrave;y v&agrave; giờ m&agrave; bạn muốn tham gia. Hệ thống sẽ hiển thị c&aacute;c khung giờ c&ograve;n v&eacute; cho bạn lựa chọn.</p><h4 class=\"bg-white text-black\">3. Chọn Loại V&eacute;</h4><p>Tiếp theo, bạn sẽ chọn loại v&eacute; bạn muốn mua. Bạn c&oacute; thể chọn v&eacute; thường, v&eacute; VIP, hoặc v&eacute; d&agrave;nh cho nh&oacute;m.</p><h4 class=\"bg-white text-black\">4. Điền Th&ocirc;ng Tin C&aacute; Nh&acirc;n</h4><p>Điền đầy đủ th&ocirc;ng tin c&aacute; nh&acirc;n như họ t&ecirc;n, email, v&agrave; số điện thoại để ch&uacute;ng t&ocirc;i c&oacute; thể li&ecirc;n hệ với bạn khi cần thiết.</p><h4 class=\"bg-white text-black\">5. Thanh To&aacute;n</h4><p>Chọn phương thức thanh to&aacute;n (v&iacute; dụ: thẻ t&iacute;n dụng, chuyển khoản ng&acirc;n h&agrave;ng, v&iacute; điện tử, v.v.) v&agrave; ho&agrave;n tất giao dịch.</p><h4 class=\"bg-white text-black\">6. X&aacute;c Nhận Đặt V&eacute;</h4><p>Sau khi thanh to&aacute;n th&agrave;nh c&ocirc;ng, bạn sẽ nhận được email x&aacute;c nhận v&agrave; v&eacute; điện tử qua email hoặc qua ứng dụng của ch&uacute;ng t&ocirc;i.</p></section><!-- Liên hệ hỗ trợ --><section class=\"mt-5 text-center\"><h5 class=\"bg-white text-black\">Li&ecirc;n Hệ Hỗ Trợ</h5><p>Nếu bạn gặp bất kỳ vấn đề n&agrave;o trong qu&aacute; tr&igrave;nh đặt v&eacute;, đừng ngần ngại li&ecirc;n hệ với đội ngũ hỗ trợ của ch&uacute;ng t&ocirc;i.</p><p>Email hỗ trợ: <a href=\"mailto:support@tencongty.com\">support@tencongty.com</a></p><p>Số điện thoại: <a href=\"tel:+84123456789\">(+84) 123 456 789</a></p></section></div>",
        });

        #endregion About

        modelBuilder.Entity<About>().HasData(abouts);
    }
}