using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieTicket.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class hi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: true),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Banners",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CinemaCenters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CinemaCenters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CinemaTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CinemaTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Combos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Combos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnglishName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Trailer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gerne = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Director = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cast = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScreenTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TranslationTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReleaseYear = table.Column<int>(type: "int", nullable: true),
                    RunningTime = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    Nation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Poster = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Promotions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScreeningDays",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Day = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScreeningDays", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScreenTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScreenTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SeatTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TranslationTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TranslationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vouchers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vouchers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConfirmedEmails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ConfirmCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsConfirmed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfirmedEmails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConfirmedEmails_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Memberships",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Point = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memberships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Memberships_Accounts_Id",
                        column: x => x.Id,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cinemas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CinemaTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CinemaCenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Column = table.Column<int>(type: "int", nullable: true),
                    Row = table.Column<int>(type: "int", nullable: true),
                    MaxSeatCapacity = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cinemas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cinemas_CinemaCenters_CinemaCenterId",
                        column: x => x.CinemaCenterId,
                        principalTable: "CinemaCenters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cinemas_CinemaTypes_CinemaTypeId",
                        column: x => x.CinemaTypeId,
                        principalTable: "CinemaTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FilmId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedules_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PromotionDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PromotionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromotionDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PromotionDetails_Promotions_PromotionId",
                        column: x => x.PromotionId,
                        principalTable: "Promotions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FilmScreenTypes",
                columns: table => new
                {
                    FilmId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ScreenTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmScreenTypes", x => new { x.ScreenTypeId, x.FilmId });
                    table.ForeignKey(
                        name: "FK_FilmScreenTypes_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmScreenTypes_ScreenTypes_ScreenTypeId",
                        column: x => x.ScreenTypeId,
                        principalTable: "ScreenTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketPrices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SeatTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ScreenTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ScreeningDayId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CinemaTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketPrices_CinemaTypes_CinemaTypeId",
                        column: x => x.CinemaTypeId,
                        principalTable: "CinemaTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TicketPrices_ScreenTypes_ScreenTypeId",
                        column: x => x.ScreenTypeId,
                        principalTable: "ScreenTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TicketPrices_ScreeningDays_ScreeningDayId",
                        column: x => x.ScreeningDayId,
                        principalTable: "ScreeningDays",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TicketPrices_SeatTypes_SeatTypeId",
                        column: x => x.SeatTypeId,
                        principalTable: "SeatTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FilmTranslationTypes",
                columns: table => new
                {
                    FilmId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TranslationTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmTranslationTypes", x => new { x.TranslationTypeId, x.FilmId });
                    table.ForeignKey(
                        name: "FK_FilmTranslationTypes_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmTranslationTypes_TranslationTypes_TranslationTypeId",
                        column: x => x.TranslationTypeId,
                        principalTable: "TranslationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VoucherDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VoucherId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoucherDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VoucherDetails_Vouchers_VoucherId",
                        column: x => x.VoucherId,
                        principalTable: "Vouchers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MembershipId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    VoucherId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TotalMoney = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "date", nullable: false),
                    BarCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    ActivationStatus = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bills_Memberships_MembershipId",
                        column: x => x.MembershipId,
                        principalTable: "Memberships",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bills_Vouchers_VoucherId",
                        column: x => x.VoucherId,
                        principalTable: "Vouchers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SeatTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CinemaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seats_Cinemas_CinemaId",
                        column: x => x.CinemaId,
                        principalTable: "Cinemas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Seats_SeatTypes_SeatTypeId",
                        column: x => x.SeatTypeId,
                        principalTable: "SeatTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ShowTimes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FilmId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CinemaCenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CinemaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ScreenTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TranslationTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ShowtimeDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Desciption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShowTimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShowTimes_CinemaCenters_CinemaCenterId",
                        column: x => x.CinemaCenterId,
                        principalTable: "CinemaCenters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ShowTimes_Cinemas_CinemaId",
                        column: x => x.CinemaId,
                        principalTable: "Cinemas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ShowTimes_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ShowTimes_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ShowTimes_ScreenTypes_ScreenTypeId",
                        column: x => x.ScreenTypeId,
                        principalTable: "ScreenTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ShowTimes_TranslationTypes_TranslationTypeId",
                        column: x => x.TranslationTypeId,
                        principalTable: "TranslationTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BillCombos",
                columns: table => new
                {
                    BillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComboId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillCombos", x => new { x.ComboId, x.BillId });
                    table.ForeignKey(
                        name: "FK_BillCombos_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BillCombos_Combos_ComboId",
                        column: x => x.ComboId,
                        principalTable: "Combos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BillSeats",
                columns: table => new
                {
                    SeatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillSeats", x => new { x.SeatId, x.BillId });
                    table.ForeignKey(
                        name: "FK_BillSeats_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BillSeats_Seats_SeatId",
                        column: x => x.SeatId,
                        principalTable: "Seats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BillId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ShowTimeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CinemaCenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SeatId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TicketPriceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Qrcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tickets_CinemaCenters_CinemaCenterId",
                        column: x => x.CinemaCenterId,
                        principalTable: "CinemaCenters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tickets_Seats_SeatId",
                        column: x => x.SeatId,
                        principalTable: "Seats",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tickets_ShowTimes_ShowTimeId",
                        column: x => x.ShowTimeId,
                        principalTable: "ShowTimes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tickets_TicketPrices_TicketPriceId",
                        column: x => x.TicketPriceId,
                        principalTable: "TicketPrices",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Avatar", "CreateDate", "Email", "Name", "Password", "Phone", "Role", "Status", "Username" },
                values: new object[,]
                {
                    { new Guid("0501f29c-2f1e-406c-a2ad-1c653b217346"), "avatar14.png", new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "user14@example.com", "User 14", "Nbb9cBgoI2KknXYhJgRsOg==", "123-456-78914", 2, 1, "user14" },
                    { new Guid("0e12e8dd-1223-4599-9841-5168f93f1f08"), "avatar23.png", new DateTime(2023, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "user23@example.com", "User 23", "JM3wDHJHLSLI6Wdnnfs2dQ==", "123-456-78923", 2, 1, "user23" },
                    { new Guid("0e1c2940-342c-4db3-bd26-f6746ee5d108"), "avatar20.png", new DateTime(2023, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "user20@example.com", "User 20", "J20oEfuyjDdy085hSNPLIw==", "123-456-78920", 2, 1, "user20" },
                    { new Guid("109fba4e-3eb1-4fa2-aeab-27ee8d71a4b1"), "avatar13.png", new DateTime(2023, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "user13@example.com", "User 13", "hjKFGDVLaz8y7jip9ebjyg==", "123-456-78913", 2, 1, "user13" },
                    { new Guid("25bb0474-a55b-46c5-a2d9-50b5d20f286b"), "avatar2.png", new DateTime(2023, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "user2@example.com", "User 2", "gPFa6fSRCX/O3JCnJjTBBg==", "123-456-7892", 2, 1, "user2" },
                    { new Guid("30537e29-c05c-46cc-bc0b-2f7f4d2116e8"), "avatar17.png", new DateTime(2023, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "user17@example.com", "User 17", "bnivYPkMUcJNzvYQyXZIvw==", "123-456-78917", 2, 1, "user17" },
                    { new Guid("3573ff87-4f2d-4e88-9df6-de71d55cb2c9"), "avatar9.png", new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "user9@example.com", "User 9", "XLl70iIryQx+lE/y5900Uw==", "123-456-7899", 2, 1, "user9" },
                    { new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), "avatar2.png", new DateTime(2023, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "azusachan309@gmail.com", "ClientTest", "LK25tQh1RqkKbrq4C2l6fw==", "000-000-000", 2, 1, "Client" },
                    { new Guid("400437ce-55a3-4349-9b69-2f44c79ec377"), "avatar30.png", new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "user30@example.com", "User 30", "ZIc8EakA57j1Q7JTsakLKA==", "123-456-78930", 2, 1, "user30" },
                    { new Guid("47d92172-3ade-48c9-8e47-f56efc92b861"), "avatar10.png", new DateTime(2023, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "user10@example.com", "User 10", "AD+DKAMne24G+bFvnB3umA==", "123-456-78910", 2, 1, "user10" },
                    { new Guid("4ec13d6a-ee72-45f7-b2c0-037be4fec14b"), "avatar5.png", new DateTime(2023, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "user5@example.com", "User 5", "LtgxZLXxd71ac78V6rYtcg==", "123-456-7895", 2, 1, "user5" },
                    { new Guid("513de07b-5258-40d0-a2d9-302293ebde6d"), "avatar26.png", new DateTime(2023, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "user26@example.com", "User 26", "JTjto+r7kPyCkZGQtsDBOA==", "123-456-78926", 2, 1, "user26" },
                    { new Guid("598589dc-ba50-4f76-b58e-24b38bba6bee"), "avatar4.png", new DateTime(2023, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "user4@example.com", "User 4", "AYCB0pkX1QvnELN5s4E7/w==", "123-456-7894", 2, 1, "user4" },
                    { new Guid("5c607db7-430f-41bc-a33f-3ca944c9a7ea"), "avatar22.png", new DateTime(2023, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "user22@example.com", "User 22", "yuwYTyVSnjUQg9d58Fr6eg==", "123-456-78922", 2, 1, "user22" },
                    { new Guid("75745a41-db7a-484e-87e3-c4b9c5a0759a"), "avatar15.png", new DateTime(2023, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "user15@example.com", "User 15", "AtoLhqKWoDhm5ytm7x3CFg==", "123-456-78915", 2, 1, "user15" },
                    { new Guid("7fe1d789-f42d-462a-a722-e022587f5d4d"), "avatar21.png", new DateTime(2023, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "user21@example.com", "User 21", "uqWAcnIuI+ey7XOiRgb8IA==", "123-456-78921", 2, 1, "user21" },
                    { new Guid("8360035b-4347-4849-bbfd-6c540cd63545"), "avatar16.png", new DateTime(2023, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "user16@example.com", "User 16", "1+4JJ+OIs+XRXx0vTPNGQA==", "123-456-78916", 2, 1, "user16" },
                    { new Guid("865ca3fe-9c60-41bf-8613-11790fd58784"), "avatar12.png", new DateTime(2023, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "user12@example.com", "User 12", "q/b7mh1nE1JeI7y/w6yvIQ==", "123-456-78912", 2, 1, "user12" },
                    { new Guid("8869f6f1-a78d-45b8-8711-f2fd016ea2a8"), "avatar29.png", new DateTime(2023, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "user29@example.com", "User 29", "ETdpo/KPinCotdzGNmsAPA==", "123-456-78929", 2, 1, "user29" },
                    { new Guid("8fa5e20e-a661-4d26-89e7-1b52b5e1ec04"), "avatar7.png", new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "user7@example.com", "User 7", "h8t5vD5p1U3C4AEASeaErg==", "123-456-7897", 2, 1, "user7" },
                    { new Guid("9aaa8e13-6c3b-4773-a460-7ce20b29b0e6"), "avatar24.png", new DateTime(2023, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "user24@example.com", "User 24", "wUy5uoNVQITmQW5R4nnOMA==", "123-456-78924", 2, 1, "user24" },
                    { new Guid("a1e0f8fd-561d-46a3-b925-a251cb48bf8e"), "avatar25.png", new DateTime(2023, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "user25@example.com", "User 25", "o+65kwYOgM/H5YtlR5eBGQ==", "123-456-78925", 2, 1, "user25" },
                    { new Guid("c06e8376-a9ac-451a-a43b-a68fcae15f80"), "avatar19.png", new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "user19@example.com", "User 19", "+BFH+L+RScNaLm45T9M5Tw==", "123-456-78919", 2, 1, "user19" },
                    { new Guid("c4c1d6d9-d5e4-49a6-9222-6ae64461de2f"), "avatar18.png", new DateTime(2023, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "user18@example.com", "User 18", "zp6jPz/JRrDgXS7tmjREDQ==", "123-456-78918", 2, 1, "user18" },
                    { new Guid("ca073c10-fd63-4f7f-a310-cdaa54d0fd35"), "avatar3.png", new DateTime(2023, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "user3@example.com", "User 3", "XZG20Zjr0RmKJ42oxCGZqQ==", "123-456-7893", 2, 1, "user3" },
                    { new Guid("cfb37859-b663-496a-83ea-e0f154c4fa60"), "avatar11.png", new DateTime(2023, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "user11@example.com", "User 11", "+1XAkm3H0MciMPlnUyv6ww==", "123-456-78911", 2, 1, "user11" },
                    { new Guid("d3f26ab7-7220-4a23-a396-1800efdcd041"), "avatar28.png", new DateTime(2023, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "user28@example.com", "User 28", "R/9+ITDUv36NqhUmUxCu5w==", "123-456-78928", 2, 1, "user28" },
                    { new Guid("d595bae7-7a79-48f3-90c8-00d949ce7c06"), "avatar27.png", new DateTime(2023, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "user27@example.com", "User 27", "lePABwdtIg5MqkBgyFdL9Q==", "123-456-78927", 2, 1, "user27" },
                    { new Guid("db406145-5cd3-4481-921a-c024ee789f7a"), "avatar6.png", new DateTime(2023, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "user6@example.com", "User 6", "ns3cIzMXn9uRJUqXbdf1sw==", "123-456-7896", 2, 1, "user6" },
                    { new Guid("dd414950-2a34-484f-a25a-070de883f701"), "avatar1.png", new DateTime(2023, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "user1@example.com", "User 1", "ei00xFxTj/yW/ErUUw1JvA==", "123-456-7891", 2, 1, "user1" },
                    { new Guid("e785d229-d42c-4582-8e09-f5ebaa9a1556"), "avatar8.png", new DateTime(2023, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "user8@example.com", "User 8", "QoNqXwm6ndtmwV7AptAudw==", "123-456-7898", 2, 1, "user8" },
                    { new Guid("fd36705c-0610-4c30-9cfb-e5827b3f3d78"), "avatar1.png", new DateTime(2023, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "azusachan307@gmail.com", "AdminTest", "LK25tQh1RqkKbrq4C2l6fw==", "000-000-000", 1, 1, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "CinemaCenters",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[,]
                {
                    { new Guid("0eedc93b-b2a9-4c09-9ba6-34f4532af50c"), "Address 13", "Cinema Center 13" },
                    { new Guid("195d310d-8236-41a2-8cf2-1092c96f6e3b"), "Address 15", "Cinema Center 15" },
                    { new Guid("2134060d-6ad6-42bc-b406-d1e381371abe"), "Address 17", "Cinema Center 17" },
                    { new Guid("244ffcea-6b2b-4025-a043-eee24f165a05"), "Address 20", "Cinema Center 20" },
                    { new Guid("26ef9fd2-5b34-4bd1-b91a-f6cbf23b50c3"), "Address 10", "Cinema Center 10" },
                    { new Guid("34607b9c-adfd-46ea-80e2-d6688e710f74"), "Address 1", "Cinema Center 1" },
                    { new Guid("5eba8de2-4492-44ac-8a4b-80e5c10ad326"), "Address 4", "Cinema Center 4" },
                    { new Guid("65215a44-8f91-4e7a-aea2-46afb1dc083a"), "Address 22", "Cinema Center 22" },
                    { new Guid("72e94f44-6348-428a-89c7-7808e0aca9ab"), "Address 19", "Cinema Center 19" },
                    { new Guid("774bb7be-c62c-4a07-b962-5032015c0411"), "Address 11", "Cinema Center 11" },
                    { new Guid("78680907-7923-4966-b950-9c2494bb47bb"), "Address 3", "Cinema Center 3" },
                    { new Guid("8269c479-9bd9-4fd8-b0c4-f573a8631af4"), "Address 14", "Cinema Center 14" },
                    { new Guid("855605f0-f1bf-4791-b36d-37e10dd8c523"), "Address 30", "Cinema Center 30" },
                    { new Guid("8bda5cc0-4f7f-4242-b23e-415fe3e3498f"), "Address 27", "Cinema Center 27" },
                    { new Guid("8e393bed-2b22-4b17-872b-da53b8ff75ad"), "Address 5", "Cinema Center 5" },
                    { new Guid("96bb5b79-1a11-4ef6-b6cf-2fc72ab74461"), "Address 9", "Cinema Center 9" },
                    { new Guid("986557b4-114c-4668-bd0e-02b416e99954"), "Address 21", "Cinema Center 21" },
                    { new Guid("9993c899-8956-4441-ae4a-fe06c32c6e02"), "Address 28", "Cinema Center 28" },
                    { new Guid("a11ba9fe-9ebc-44fa-8db0-3cd0d10270c6"), "Address 12", "Cinema Center 12" },
                    { new Guid("a80c70d7-65e3-4d74-a743-73c766c8e8ae"), "Address 6", "Cinema Center 6" },
                    { new Guid("a8817eda-abab-4bff-a3a5-82a1460ae416"), "Address 18", "Cinema Center 18" },
                    { new Guid("ae97ec2f-870c-4940-8679-65b362488677"), "Address 25", "Cinema Center 25" },
                    { new Guid("b37ce504-e51d-4259-a0aa-a8d0584c9530"), "Address 23", "Cinema Center 23" },
                    { new Guid("b6a9896f-c9c6-4e97-a793-e18cfb55e1f7"), "Address 26", "Cinema Center 26" },
                    { new Guid("e12faaf4-8a95-42a1-bd92-8d50beada41c"), "Address 2", "Cinema Center 2" },
                    { new Guid("e163e949-7e92-4d1f-a602-341faf1f3d7f"), "Address 7", "Cinema Center 7" },
                    { new Guid("e58ec98d-2eba-40a6-a7c9-ac4228c635f1"), "Address 29", "Cinema Center 29" },
                    { new Guid("e6d3f6dd-929b-497c-bd54-454d317dea41"), "Address 24", "Cinema Center 24" },
                    { new Guid("ee8b9b21-fe0e-4add-816a-52b1a822b6ac"), "Address 8", "Cinema Center 8" },
                    { new Guid("f4c196de-ad5a-424c-94b6-80a4097afec1"), "Address 16", "Cinema Center 16" }
                });

            migrationBuilder.InsertData(
                table: "CinemaTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("03846649-c852-443c-9f5c-f935343318d5"), "Premium Class" },
                    { new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), "2D" },
                    { new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), "Gold Class" }
                });

            migrationBuilder.InsertData(
                table: "Combos",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("04384de5-233e-4fc9-a3f5-cb320e465f55"), "Combo 26", 60000m },
                    { new Guid("0f741091-18be-4f5d-a271-d2d7b771a642"), "Combo 11", 10000m },
                    { new Guid("36e6a46a-d014-4fd6-8b21-d9cd4d1c646c"), "Combo 10", 0m },
                    { new Guid("3839e50d-4872-4b0d-8134-adbb233d1181"), "Combo 13", 30000m },
                    { new Guid("3c4aec6c-f45e-4a05-b357-f56d82708d90"), "Combo 29", 90000m },
                    { new Guid("43d1a8bc-7eaf-418f-a750-3832c184ebe8"), "Combo 27", 70000m },
                    { new Guid("46d38ae4-c6a5-423d-96c4-c4eea56194ac"), "Combo 21", 10000m },
                    { new Guid("53282f34-dbe1-4df2-9ed5-6f7d485a6cff"), "Combo 22", 20000m },
                    { new Guid("5d736597-1e04-4af4-841d-8be14bb947fa"), "Combo 19", 90000m },
                    { new Guid("66a05a13-fbdd-4947-8519-ce54e8f692db"), "Combo 8", 80000m },
                    { new Guid("6d9ed912-eb20-4ec1-9c62-79921192881f"), "Combo 2", 20000m },
                    { new Guid("75b01116-13e2-4dc9-9acf-fd478f9acf62"), "Combo 9", 90000m },
                    { new Guid("84d7e09f-6b5b-4f35-b109-434756033a6c"), "Combo 23", 30000m },
                    { new Guid("8b68b58e-c257-4f32-9962-c0e99e13f31b"), "Combo 15", 50000m },
                    { new Guid("94029caa-ea3c-42a2-b431-db77dcf72398"), "Combo 16", 60000m },
                    { new Guid("9d76674e-88b9-451b-84af-23c81a3bbd1a"), "Combo 5", 50000m },
                    { new Guid("9f8a7372-7432-49b7-b4f6-db93971db271"), "Combo 6", 60000m },
                    { new Guid("a93853b9-3a82-4078-9496-cb67745c95e9"), "Combo 14", 40000m },
                    { new Guid("ac2fd984-f00e-4286-a068-e2b87cd88167"), "Combo 18", 80000m },
                    { new Guid("b1eea8c2-303b-4425-a3b0-ba964b52ed84"), "Combo 28", 80000m },
                    { new Guid("b365f3f3-3c44-41bb-8b4a-d118771b7fd8"), "Combo 17", 70000m },
                    { new Guid("baf7b75d-4828-4134-bbfc-7696156eba10"), "Combo 7", 70000m },
                    { new Guid("bbbb9a46-f14d-41af-bb2d-7a9e49e77f3d"), "Combo 4", 40000m },
                    { new Guid("bd182a47-a15f-460e-b9fc-644d86123c40"), "Combo 24", 40000m },
                    { new Guid("c3c0d041-cbe9-48bd-806f-8b9b5074c273"), "Combo 3", 30000m },
                    { new Guid("c69abb85-98e6-4c94-8999-9413db23adac"), "Combo 20", 0m },
                    { new Guid("cd77f79a-74cb-4cbb-a6ca-746c32ac73e3"), "Combo 1", 10000m },
                    { new Guid("cef31171-ed36-4e09-869b-57a621c1f146"), "Combo 12", 20000m },
                    { new Guid("df537010-99ef-46bf-89b0-9849cca8d711"), "Combo 25", 50000m },
                    { new Guid("ec9ee5a9-1925-424b-b924-8f3a006d0158"), "Combo 30", 0m }
                });

            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "Id", "Cast", "CreatDate", "Description", "Director", "EnglishName", "Gerne", "Language", "Name", "Nation", "Poster", "Rating", "ReleaseYear", "RunningTime", "ScreenTypeId", "StartDate", "Status", "Trailer", "TranslationTypeId" },
                values: new object[,]
                {
                    { new Guid("19b092c9-91df-4cea-92c0-d54e76f92572"), "Actor 7, Actress 7", new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 7.", "Director 7", "Film 7 (English)", "Comedy", "Japanese", "Film 7", "Japan", "film_fake.jpg", 3, 2023, 67, new Guid("ece5862c-a5da-4444-ad34-813eb134d093"), new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer7.mp4", new Guid("6c31377d-261f-4a87-8620-61bb8030cdd8") },
                    { new Guid("1bac7698-bc3e-4e0c-b052-d5a6f87a0c05"), "Actor 5, Actress 5", new DateTime(2023, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 5.", "Director 5", "Film 5 (English)", "Comedy", "Japanese", "Film 5", "Japan", "film_fake.jpg", 1, 2023, 65, new Guid("8f31c439-5372-4641-9516-d5ee08f2db08"), new DateTime(2023, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer5.mp4", new Guid("5ad30636-a2db-442f-9fe5-6719f2ea50fe") },
                    { new Guid("2435bfc4-79ee-4ec6-ae6f-439ff5044428"), "Actor 27, Actress 27", new DateTime(2023, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 27.", "Director 27", "Film 27 (English)", "Comedy", "Japanese", "Film 27", "Japan", "film_fake.jpg", 3, 2023, 87, new Guid("e610fd1b-2742-4b57-9902-e2c99fde0863"), new DateTime(2023, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer27.mp4", new Guid("5e735696-57b4-4d47-8883-ad92836d1051") },
                    { new Guid("329c8514-2ddb-4554-998d-3bef7068423e"), "Actor 4, Actress 4", new DateTime(2023, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 4.", "Director 4", "Film 4 (English)", "Action", "English", "Film 4", "USA", "film_fake.jpg", 5, 2023, 64, new Guid("83522ed2-8661-4e7c-86cb-ff82b4cddb5a"), new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer4.mp4", new Guid("27f025f7-0785-4b17-af3f-7cc7b03ab2f4") },
                    { new Guid("39831169-ef3a-42fd-b391-272857bab717"), "Actor 11, Actress 11", new DateTime(2023, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 11.", "Director 11", "Film 11 (English)", "Comedy", "Japanese", "Film 11", "Japan", "film_fake.jpg", 2, 2023, 71, new Guid("c61f017f-4df1-4968-9c3b-43f99cbbb218"), new DateTime(2023, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer11.mp4", new Guid("1c8115d9-3b3f-4b18-895f-c50823fb3a60") },
                    { new Guid("39d30d8b-9d1c-4028-bf26-22f152c4370f"), "Actor 8, Actress 8", new DateTime(2023, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 8.", "Director 8", "Film 8 (English)", "Action", "English", "Film 8", "USA", "film_fake.jpg", 4, 2023, 68, new Guid("da47e008-02cb-4071-a94e-32340beaeed6"), new DateTime(2023, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer8.mp4", new Guid("cd56dc3a-e8f4-4e5e-a84f-733fb8738311") },
                    { new Guid("453228a9-8ee3-4739-b69d-336ce46a181a"), "Actor 24, Actress 24", new DateTime(2023, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 24.", "Director 24", "Film 24 (English)", "Action", "English", "Film 24", "USA", "film_fake.jpg", 5, 2023, 84, new Guid("64aa1e1e-66d0-4cdd-82d7-ddac997380fe"), new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer24.mp4", new Guid("933d3424-436a-400b-ba7c-1052a8201a77") },
                    { new Guid("47b88ede-70f2-4074-856a-dcea6a9f4ec7"), "Actor 25, Actress 25", new DateTime(2023, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 25.", "Director 25", "Film 25 (English)", "Comedy", "Japanese", "Film 25", "Japan", "film_fake.jpg", 1, 2023, 85, new Guid("db4c0893-400c-4e45-a696-02d6baeace1f"), new DateTime(2023, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer25.mp4", new Guid("bd05bdeb-8397-4687-8d9b-5541262c33b4") },
                    { new Guid("4af96ed7-3784-4f4f-9c4a-070363f90f5f"), "Actor 15, Actress 15", new DateTime(2023, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 15.", "Director 15", "Film 15 (English)", "Comedy", "Japanese", "Film 15", "Japan", "film_fake.jpg", 1, 2023, 75, new Guid("a8c8f3ad-622b-4a2c-ad1c-66ee2279c97e"), new DateTime(2023, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer15.mp4", new Guid("f1744c09-60f5-46ca-866f-da4edd8bf00f") },
                    { new Guid("58d617d6-4605-41eb-983a-7f8b08902762"), "Actor 2, Actress 2", new DateTime(2023, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 2.", "Director 2", "Film 2 (English)", "Action", "English", "Film 2", "USA", "film_fake.jpg", 3, 2023, 62, new Guid("96259071-b4e6-4605-ac00-14f4993b0038"), new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer2.mp4", new Guid("03f14455-84fb-48f7-bd28-2d0391a84f9e") },
                    { new Guid("5c86d655-14be-47b4-ba05-020167df03b8"), "Actor 28, Actress 28", new DateTime(2023, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 28.", "Director 28", "Film 28 (English)", "Action", "English", "Film 28", "USA", "film_fake.jpg", 4, 2023, 88, new Guid("f19a5850-34bc-4bd4-b2a8-8e1491ca4f80"), new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer28.mp4", new Guid("6f8325f5-9387-4179-999a-695a0750664d") },
                    { new Guid("604c7c77-37de-4a1c-bb8c-67313cb82b3c"), "Actor 12, Actress 12", new DateTime(2023, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 12.", "Director 12", "Film 12 (English)", "Action", "English", "Film 12", "USA", "film_fake.jpg", 3, 2023, 72, new Guid("ba376416-a98b-4fa8-b2f9-cf2d25449413"), new DateTime(2023, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer12.mp4", new Guid("152d9e8b-01b9-43c2-b854-f3207d5ea81f") },
                    { new Guid("72bd7490-85de-4192-b486-586b189277db"), "Actor 18, Actress 18", new DateTime(2023, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 18.", "Director 18", "Film 18 (English)", "Action", "English", "Film 18", "USA", "film_fake.jpg", 4, 2023, 78, new Guid("9b7fe4c3-d52e-4263-8852-3c965d5263cf"), new DateTime(2023, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer18.mp4", new Guid("41fcef0c-85b8-4324-8a85-af44ff874311") },
                    { new Guid("7ab3a193-9841-4afd-9975-21f495a4b7c2"), "Actor 14, Actress 14", new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 14.", "Director 14", "Film 14 (English)", "Action", "English", "Film 14", "USA", "film_fake.jpg", 5, 2023, 74, new Guid("250d44cd-5ca7-406a-b92e-139d5d62df08"), new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer14.mp4", new Guid("94e07f4c-098e-4af2-b0f0-b33d76765250") },
                    { new Guid("7e0b812e-435d-4f68-b589-cde23aa4e249"), "Actor 9, Actress 9", new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 9.", "Director 9", "Film 9 (English)", "Comedy", "Japanese", "Film 9", "Japan", "film_fake.jpg", 5, 2023, 69, new Guid("e6e4a8b4-69fd-4411-a06b-ad74e7f498c4"), new DateTime(2023, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer9.mp4", new Guid("b790edd5-6842-4f62-bb8b-4d8abe18e615") },
                    { new Guid("80688243-3577-4281-9550-c0f55295c0ac"), "Actor 10, Actress 10", new DateTime(2023, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 10.", "Director 10", "Film 10 (English)", "Action", "English", "Film 10", "USA", "film_fake.jpg", 1, 2023, 70, new Guid("159f78e9-ee5f-460f-9418-a4bc8e0efc0d"), new DateTime(2023, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer10.mp4", new Guid("5ca517f5-790d-4c49-b68b-0ec29b35d664") },
                    { new Guid("a0f2822b-f398-4cb9-9941-5562fb355874"), "Actor 22, Actress 22", new DateTime(2023, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 22.", "Director 22", "Film 22 (English)", "Action", "English", "Film 22", "USA", "film_fake.jpg", 3, 2023, 82, new Guid("2be3c1e4-a427-409c-a815-d3affa1ece5e"), new DateTime(2023, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer22.mp4", new Guid("a88e1058-b505-493b-85e9-bc5af0f5a5ad") },
                    { new Guid("a44c3cdb-9840-4e5e-b972-7f31b10b23fe"), "Actor 26, Actress 26", new DateTime(2023, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 26.", "Director 26", "Film 26 (English)", "Action", "English", "Film 26", "USA", "film_fake.jpg", 2, 2023, 86, new Guid("6a0a86e4-2e84-41f4-a25a-3b6417d556e2"), new DateTime(2023, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer26.mp4", new Guid("8a69f465-e3ca-47b6-92ba-b5ff05051169") },
                    { new Guid("b6d6f92f-2048-4279-8cf1-a749f4684404"), "Actor 3, Actress 3", new DateTime(2023, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 3.", "Director 3", "Film 3 (English)", "Comedy", "Japanese", "Film 3", "Japan", "film_fake.jpg", 4, 2023, 63, new Guid("05410a3f-65a0-4e47-b654-f33fa7f044aa"), new DateTime(2023, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer3.mp4", new Guid("8e1bb721-fb4c-440f-9ae7-66257f58319d") },
                    { new Guid("c144ac5a-15bc-4394-8871-80c5d3944f85"), "Actor 19, Actress 19", new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 19.", "Director 19", "Film 19 (English)", "Comedy", "Japanese", "Film 19", "Japan", "film_fake.jpg", 5, 2023, 79, new Guid("2382b781-a779-4a9c-b558-9c3c794b5f33"), new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer19.mp4", new Guid("ee0e9d9b-9795-48b9-b812-db2a8ce55165") },
                    { new Guid("c48ae736-d6bd-436b-baa9-b318ee7cb246"), "Actor 30, Actress 30", new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 30.", "Director 30", "Film 30 (English)", "Action", "English", "Film 30", "USA", "film_fake.jpg", 1, 2023, 90, new Guid("aa3659f7-66be-42ee-9957-056bc0fd5531"), new DateTime(2023, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer30.mp4", new Guid("5f0258dc-2e5f-411c-92d9-32ea1ce79367") },
                    { new Guid("c89867e6-e84b-4630-9739-87f643b7bc83"), "Actor 17, Actress 17", new DateTime(2023, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 17.", "Director 17", "Film 17 (English)", "Comedy", "Japanese", "Film 17", "Japan", "film_fake.jpg", 3, 2023, 77, new Guid("69754509-3d42-49c8-8663-81520f182ca0"), new DateTime(2023, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer17.mp4", new Guid("4fbea739-76e5-411c-a0ca-10b252a39c29") },
                    { new Guid("d0a3a0f1-660f-46c0-8d40-317c3a1ef86f"), "Actor 29, Actress 29", new DateTime(2023, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 29.", "Director 29", "Film 29 (English)", "Comedy", "Japanese", "Film 29", "Japan", "film_fake.jpg", 5, 2023, 89, new Guid("2c4187d2-ed73-4928-9236-1612d4aa492b"), new DateTime(2023, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer29.mp4", new Guid("5ff4e4c8-3176-48d4-bdde-67408501e183") },
                    { new Guid("d6790789-26e6-47f0-bf21-409eb084037c"), "Actor 16, Actress 16", new DateTime(2023, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 16.", "Director 16", "Film 16 (English)", "Action", "English", "Film 16", "USA", "film_fake.jpg", 2, 2023, 76, new Guid("1f519b83-b5cb-4adb-8bc1-c2f812aa92bc"), new DateTime(2023, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer16.mp4", new Guid("3db9cf3c-63ba-43d0-a425-1cfba6cd4466") },
                    { new Guid("d7b64f5e-f2d6-43c5-9949-d5ec83b7af0d"), "Actor 1, Actress 1", new DateTime(2023, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 1.", "Director 1", "Film 1 (English)", "Comedy", "Japanese", "Film 1", "Japan", "film_fake.jpg", 2, 2023, 61, new Guid("9b829ca1-9090-4e6f-b163-89e99b733a56"), new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer1.mp4", new Guid("dfd3af60-be25-4f9f-9034-fba084a848a0") },
                    { new Guid("e621fade-b458-48b9-a9c9-24e39464c48d"), "Actor 23, Actress 23", new DateTime(2023, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 23.", "Director 23", "Film 23 (English)", "Comedy", "Japanese", "Film 23", "Japan", "film_fake.jpg", 4, 2023, 83, new Guid("1f143a35-8cb6-4aae-8e60-1db4d7d525b2"), new DateTime(2023, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer23.mp4", new Guid("ecafa3bf-6e31-4f2f-9bca-89e8f1a245f2") },
                    { new Guid("f10220ed-1241-41bf-826e-ba2f99519c50"), "Actor 13, Actress 13", new DateTime(2023, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 13.", "Director 13", "Film 13 (English)", "Comedy", "Japanese", "Film 13", "Japan", "film_fake.jpg", 4, 2023, 73, new Guid("827f6b0c-48b4-4cdb-9172-8710c9fdbd03"), new DateTime(2023, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer13.mp4", new Guid("3d077bf2-a137-4eef-b53a-0a9cc105b40e") },
                    { new Guid("f9e358a5-63a9-4264-af67-5c9c9a05e719"), "Actor 6, Actress 6", new DateTime(2023, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 6.", "Director 6", "Film 6 (English)", "Action", "English", "Film 6", "USA", "film_fake.jpg", 2, 2023, 66, new Guid("87e006f3-159d-4eea-a3b1-c23a4577e903"), new DateTime(2023, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer6.mp4", new Guid("8ca92f18-fd52-45de-8fa1-4b50ab940d7e") },
                    { new Guid("ff0a25f5-2719-45af-ad6f-e2adf5b65b5f"), "Actor 21, Actress 21", new DateTime(2023, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 21.", "Director 21", "Film 21 (English)", "Comedy", "Japanese", "Film 21", "Japan", "film_fake.jpg", 2, 2023, 81, new Guid("755d8694-7ee3-4546-a68c-7d5103079b86"), new DateTime(2023, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer21.mp4", new Guid("4ce0094c-e896-4fd1-9299-4467f6e948f3") },
                    { new Guid("fff70a8c-d5db-4191-b5c4-7d259aaad696"), "Actor 20, Actress 20", new DateTime(2023, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 20.", "Director 20", "Film 20 (English)", "Action", "English", "Film 20", "USA", "film_fake.jpg", 1, 2023, 80, new Guid("51b73f50-45ed-45d0-9ab8-51925e08ed9a"), new DateTime(2023, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer20.mp4", new Guid("ee12a2fe-9a10-4c78-8b9b-db9fa1344b46") }
                });

            migrationBuilder.InsertData(
                table: "Promotions",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("0b40c89c-895b-4de5-a822-855567708f1b"), "Title 6" },
                    { new Guid("12c8e148-0f5a-483b-ba57-c4a0b8c19753"), "Title 11" },
                    { new Guid("19690a81-292e-477a-be82-bda714911b0e"), "Title 28" },
                    { new Guid("2d254f11-8c30-46f3-9cd7-2fb6e0d6a1b0"), "Title 13" },
                    { new Guid("44b2fb7e-b630-4821-a2a0-e344f7491e8e"), "Title 24" },
                    { new Guid("4640ebf3-b363-4928-a46d-5a3048368af3"), "Title 17" },
                    { new Guid("49c886ca-7397-482f-97ef-02becb5e629a"), "Title 5" },
                    { new Guid("57c0ba57-ef8e-4536-8ca9-767373780ac3"), "Title 19" },
                    { new Guid("5c2242f3-2dcf-44fc-a408-62e98a3eb989"), "Title 9" },
                    { new Guid("641e23d2-1c32-4bd4-9b3a-1704045aa8d1"), "Title 30" },
                    { new Guid("6a16ffb2-3b37-45b4-9074-5ed1739b42a1"), "Title 15" },
                    { new Guid("70b920fb-3075-4000-ac60-136153aa8d11"), "Title 16" },
                    { new Guid("7d497a5d-00ae-41a1-ab36-43df8499fd4a"), "Title 27" },
                    { new Guid("7f90a472-deda-4084-a8c3-bb770c5b9a6b"), "Title 26" },
                    { new Guid("85f07551-40f0-4a9c-b575-ce96fafbb8a2"), "Title 20" },
                    { new Guid("86d5d854-87fb-442a-9062-aa5978663aad"), "Title 21" },
                    { new Guid("94dd3916-2556-42cb-b147-e9efd01d34d8"), "Title 2" },
                    { new Guid("998b7704-daa0-475f-bc6b-083434396828"), "Title 22" },
                    { new Guid("a6c87c50-f44c-4a92-8503-c0c7192d2c50"), "Title 25" },
                    { new Guid("b738c16f-89ab-4ceb-acbd-571131b465e1"), "Title 29" },
                    { new Guid("b76c66f2-3b37-47fc-af44-464f580915c9"), "Title 14" },
                    { new Guid("b8349e79-9b22-4147-a4a2-4bb9804c4e82"), "Title 18" },
                    { new Guid("ba385f90-bf88-4801-bffb-c7d7d08fd0ed"), "Title 12" },
                    { new Guid("bdf3bd6c-affc-4104-8a08-ea477b48965b"), "Title 8" },
                    { new Guid("bed4b5c2-0adc-4087-916c-683ef86b0b5c"), "Title 23" },
                    { new Guid("c9cdb7bb-4c44-4e2b-bc9a-29ff442356e7"), "Title 10" },
                    { new Guid("d13971e7-d88f-40d1-a5ff-ab9e8b630888"), "Title 7" },
                    { new Guid("d833567a-cc66-4fb0-8575-23b17ac2dd25"), "Title 3" },
                    { new Guid("f199bcfa-533e-4c85-b54d-9492207ab134"), "Title 1" },
                    { new Guid("f6707da4-b906-43ca-bf32-5c0875e58961"), "Title 4" }
                });

            migrationBuilder.InsertData(
                table: "ScreenTypes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), "2D" },
                    { new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), "3D" },
                    { new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), "IMAX" }
                });

            migrationBuilder.InsertData(
                table: "ScreeningDays",
                columns: new[] { "Id", "Day" },
                values: new object[,]
                {
                    { new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), "T2-T6" },
                    { new Guid("d51bee9b-54c3-4a3c-a06a-7c3940852f57"), "T2-CN" },
                    { new Guid("e4f8f494-4e25-4966-806a-7b8843d79b6b"), "T7-CN" }
                });

            migrationBuilder.InsertData(
                table: "SeatTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("428edc6b-0862-4623-b038-ac505fd554bc"), "Couple" },
                    { new Guid("d997b27a-ddb7-4ad1-a1cd-c2bd00c50cb9"), "VIP" },
                    { new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), "Normal" }
                });

            migrationBuilder.InsertData(
                table: "TranslationTypes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30"), "Phụ đề" },
                    { new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf"), "Phụ đề và Lồng tiếng" }
                });

            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "Id", "CinemaCenterId", "CinemaTypeId", "Column", "Description", "MaxSeatCapacity", "Name", "Row" },
                values: new object[,]
                {
                    { new Guid("00ed026a-d4f0-4b56-95d4-9db923d7223b"), new Guid("e6d3f6dd-929b-497c-bd54-454d317dea41"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 10, "Description for Cinema 24", 100, "Cinema 24", 10 },
                    { new Guid("0a783862-3298-4dce-a1f3-caff5d7a0f1f"), new Guid("96bb5b79-1a11-4ef6-b6cf-2fc72ab74461"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 10, "Description for Cinema 9", 100, "Cinema 9", 10 },
                    { new Guid("0e46cbaf-c555-4066-a8c9-e209694ab5fb"), new Guid("986557b4-114c-4668-bd0e-02b416e99954"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 10, "Description for Cinema 21", 100, "Cinema 21", 10 },
                    { new Guid("0ec16764-f7c5-4a4f-ba58-e06ca36f663f"), new Guid("855605f0-f1bf-4791-b36d-37e10dd8c523"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 10, "Description for Cinema 30", 100, "Cinema 30", 10 },
                    { new Guid("11796c6d-6a2f-4740-9d40-3fd1fde1390a"), new Guid("2134060d-6ad6-42bc-b406-d1e381371abe"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 10, "Description for Cinema 17", 100, "Cinema 17", 10 },
                    { new Guid("21133506-7eef-4a5b-8532-fc0266330180"), new Guid("8269c479-9bd9-4fd8-b0c4-f573a8631af4"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 10, "Description for Cinema 14", 100, "Cinema 14", 10 },
                    { new Guid("2650b463-4c73-46d2-a601-528c837ff24e"), new Guid("0eedc93b-b2a9-4c09-9ba6-34f4532af50c"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 10, "Description for Cinema 13", 100, "Cinema 13", 10 },
                    { new Guid("33bf015f-b3a0-409b-8695-a0095867d0f6"), new Guid("a80c70d7-65e3-4d74-a743-73c766c8e8ae"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 10, "Description for Cinema 6", 100, "Cinema 6", 10 },
                    { new Guid("345ead0f-cd0f-4a65-a2ba-88bf4b5bf413"), new Guid("e58ec98d-2eba-40a6-a7c9-ac4228c635f1"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 10, "Description for Cinema 29", 100, "Cinema 29", 10 },
                    { new Guid("34f74fda-a941-43ed-8a14-bd16685aeafb"), new Guid("a11ba9fe-9ebc-44fa-8db0-3cd0d10270c6"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 10, "Description for Cinema 12", 100, "Cinema 12", 10 },
                    { new Guid("49cbdff1-0eaf-4f3e-939c-58da6cb64209"), new Guid("195d310d-8236-41a2-8cf2-1092c96f6e3b"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 10, "Description for Cinema 15", 100, "Cinema 15", 10 },
                    { new Guid("49ddf0e3-97a8-4989-a519-1376e7d0c5a1"), new Guid("e12faaf4-8a95-42a1-bd92-8d50beada41c"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 10, "Description for Cinema 2", 100, "Cinema 2", 10 },
                    { new Guid("4dd44dc3-d454-4ffd-b95a-f11057dc1cd6"), new Guid("f4c196de-ad5a-424c-94b6-80a4097afec1"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 10, "Description for Cinema 16", 100, "Cinema 16", 10 },
                    { new Guid("6858c450-98ef-4e03-97e7-d7ca3b3d8ce9"), new Guid("8bda5cc0-4f7f-4242-b23e-415fe3e3498f"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 10, "Description for Cinema 27", 100, "Cinema 27", 10 },
                    { new Guid("7276cfb2-159c-4d6f-ad32-0c47af1118ce"), new Guid("5eba8de2-4492-44ac-8a4b-80e5c10ad326"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 10, "Description for Cinema 4", 100, "Cinema 4", 10 },
                    { new Guid("7c1cf3f1-7fa8-4e0a-8118-656750f2d10f"), new Guid("a8817eda-abab-4bff-a3a5-82a1460ae416"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 10, "Description for Cinema 18", 100, "Cinema 18", 10 },
                    { new Guid("81706ee3-c0b3-4116-9e1d-812f6f8f5463"), new Guid("ee8b9b21-fe0e-4add-816a-52b1a822b6ac"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 10, "Description for Cinema 8", 100, "Cinema 8", 10 },
                    { new Guid("88aa20e0-08d9-43c4-bc34-af6c4c7a2a58"), new Guid("244ffcea-6b2b-4025-a043-eee24f165a05"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 10, "Description for Cinema 20", 100, "Cinema 20", 10 },
                    { new Guid("a51c195c-3446-453d-8870-24e921d3f360"), new Guid("65215a44-8f91-4e7a-aea2-46afb1dc083a"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 10, "Description for Cinema 22", 100, "Cinema 22", 10 },
                    { new Guid("b7af75e8-8aae-493a-b2ca-b61c290bc736"), new Guid("b6a9896f-c9c6-4e97-a793-e18cfb55e1f7"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 10, "Description for Cinema 26", 100, "Cinema 26", 10 },
                    { new Guid("bc0f96c2-283b-476b-b59e-9ae20b6f3ad0"), new Guid("b37ce504-e51d-4259-a0aa-a8d0584c9530"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 10, "Description for Cinema 23", 100, "Cinema 23", 10 },
                    { new Guid("bcb24e36-fc89-4f3c-9ae1-4784bee73016"), new Guid("ae97ec2f-870c-4940-8679-65b362488677"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 10, "Description for Cinema 25", 100, "Cinema 25", 10 },
                    { new Guid("bf34348b-0f36-4474-be13-08b6d78f9dca"), new Guid("9993c899-8956-4441-ae4a-fe06c32c6e02"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 10, "Description for Cinema 28", 100, "Cinema 28", 10 },
                    { new Guid("ca8f85a4-ccc6-40d0-b4ee-5d3720eba50e"), new Guid("78680907-7923-4966-b950-9c2494bb47bb"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 10, "Description for Cinema 3", 100, "Cinema 3", 10 },
                    { new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), new Guid("34607b9c-adfd-46ea-80e2-d6688e710f74"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 10, "Description for Cinema 1", 100, "Cinema 1", 10 },
                    { new Guid("dea4f05c-d8bf-43d3-8bae-784cb7aeade3"), new Guid("72e94f44-6348-428a-89c7-7808e0aca9ab"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 10, "Description for Cinema 19", 100, "Cinema 19", 10 },
                    { new Guid("e0a4782a-c594-42a5-a4c4-47f0aee15d40"), new Guid("8e393bed-2b22-4b17-872b-da53b8ff75ad"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 10, "Description for Cinema 5", 100, "Cinema 5", 10 },
                    { new Guid("e81ff048-14f3-4188-a377-efffd431c9ae"), new Guid("e163e949-7e92-4d1f-a602-341faf1f3d7f"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 10, "Description for Cinema 7", 100, "Cinema 7", 10 },
                    { new Guid("ee4a39ac-e048-4fc0-aaa7-75122c9aa7d7"), new Guid("26ef9fd2-5b34-4bd1-b91a-f6cbf23b50c3"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 10, "Description for Cinema 10", 100, "Cinema 10", 10 },
                    { new Guid("f8fe6028-1fc9-42e0-b58d-575e7550e307"), new Guid("774bb7be-c62c-4a07-b962-5032015c0411"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 10, "Description for Cinema 11", 100, "Cinema 11", 10 }
                });

            migrationBuilder.InsertData(
                table: "Memberships",
                columns: new[] { "Id", "Point", "Status" },
                values: new object[] { new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 0, 1 });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "Id", "EndDate", "FilmId", "StartDate", "Status", "Type" },
                values: new object[,]
                {
                    { new Guid("007fbba7-4dac-4cbb-9295-d6101a57629c"), new DateTime(2023, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a0f2822b-f398-4cb9-9941-5562fb355874"), new DateTime(2023, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { new Guid("01236102-00aa-41c4-8a2d-d6a091156fc0"), new DateTime(2023, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fff70a8c-d5db-4191-b5c4-7d259aaad696"), new DateTime(2023, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { new Guid("0780cd4c-aac7-45de-8917-a07f8c34de2c"), new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f9e358a5-63a9-4264-af67-5c9c9a05e719"), new DateTime(2023, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { new Guid("0ccd0fdc-b377-442c-8f35-5fc03384455b"), new DateTime(2023, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("19b092c9-91df-4cea-92c0-d54e76f92572"), new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { new Guid("193553e5-09d1-4992-b115-07d29ffd90a1"), new DateTime(2023, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a44c3cdb-9840-4e5e-b972-7f31b10b23fe"), new DateTime(2023, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { new Guid("1c59b2dc-825b-4a45-8b9e-e4de1e42ea80"), new DateTime(2023, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c144ac5a-15bc-4394-8871-80c5d3944f85"), new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { new Guid("205a4149-ddb2-44ea-9f9e-11f438fa7b66"), new DateTime(2023, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6790789-26e6-47f0-bf21-409eb084037c"), new DateTime(2023, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { new Guid("252fcb3b-69ab-4bb7-9b24-073efa7e23e9"), new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f10220ed-1241-41bf-826e-ba2f99519c50"), new DateTime(2023, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { new Guid("29b69d23-3bf6-44b3-9cb8-b73b87b5a1ec"), new DateTime(2023, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b6d6f92f-2048-4279-8cf1-a749f4684404"), new DateTime(2023, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { new Guid("33424ab3-28c4-4162-a78f-2546e9abf104"), new DateTime(2023, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("47b88ede-70f2-4074-856a-dcea6a9f4ec7"), new DateTime(2023, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { new Guid("46c4eca9-d7bc-4220-ba85-e892112e59b6"), new DateTime(2023, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("39831169-ef3a-42fd-b391-272857bab717"), new DateTime(2023, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { new Guid("47eb620e-a472-4dbd-a450-6784ee503ecd"), new DateTime(2023, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5c86d655-14be-47b4-ba05-020167df03b8"), new DateTime(2023, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { new Guid("4a2a1d48-9cd4-4cc7-b5d3-8dbde5075180"), new DateTime(2023, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("1bac7698-bc3e-4e0c-b052-d5a6f87a0c05"), new DateTime(2023, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { new Guid("62f2a7d7-87d8-4287-bedb-244245ffa0f7"), new DateTime(2023, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7ab3a193-9841-4afd-9975-21f495a4b7c2"), new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { new Guid("635cae6e-99c5-4a71-94ec-15542120554b"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c48ae736-d6bd-436b-baa9-b318ee7cb246"), new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { new Guid("6f54c038-dcad-408d-9c55-75afd7fa282d"), new DateTime(2023, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c89867e6-e84b-4630-9739-87f643b7bc83"), new DateTime(2023, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { new Guid("7263497e-9b79-4bc8-bcce-4e5da6fb7eeb"), new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("39d30d8b-9d1c-4028-bf26-22f152c4370f"), new DateTime(2023, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { new Guid("7b80eac5-4ba9-46a1-8361-00e5f77fc802"), new DateTime(2023, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("329c8514-2ddb-4554-998d-3bef7068423e"), new DateTime(2023, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { new Guid("8357aa0b-48fd-4343-b5b6-8d5ff4a9366d"), new DateTime(2023, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4af96ed7-3784-4f4f-9c4a-070363f90f5f"), new DateTime(2023, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { new Guid("84a4624e-73a4-425c-a066-d1f556aa35f6"), new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("72bd7490-85de-4192-b486-586b189277db"), new DateTime(2023, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { new Guid("9608c831-64cd-489e-b90e-bd10baf3aa2e"), new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d0a3a0f1-660f-46c0-8d40-317c3a1ef86f"), new DateTime(2023, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { new Guid("995ce7c9-b08e-48bf-8c16-5f84e489e5a4"), new DateTime(2023, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("80688243-3577-4281-9550-c0f55295c0ac"), new DateTime(2023, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { new Guid("9f38c585-b966-4743-92a6-2dc8a9600f95"), new DateTime(2023, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ff0a25f5-2719-45af-ad6f-e2adf5b65b5f"), new DateTime(2023, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { new Guid("af659ca2-9629-46d8-9965-712fa7d71010"), new DateTime(2023, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7e0b812e-435d-4f68-b589-cde23aa4e249"), new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { new Guid("b1585ce9-6c05-4395-b67d-0100395cff73"), new DateTime(2023, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d7b64f5e-f2d6-43c5-9949-d5ec83b7af0d"), new DateTime(2023, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { new Guid("d2ba36bc-2173-4ef2-9e24-f2a6ad6535c5"), new DateTime(2023, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("604c7c77-37de-4a1c-bb8c-67313cb82b3c"), new DateTime(2023, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { new Guid("d7b5edd3-955f-4b7b-967e-777c106edd44"), new DateTime(2023, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e621fade-b458-48b9-a9c9-24e39464c48d"), new DateTime(2023, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { new Guid("d992c3e8-e1fe-40ac-a4ab-feba8f2cfc11"), new DateTime(2023, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("58d617d6-4605-41eb-983a-7f8b08902762"), new DateTime(2023, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { new Guid("df299f22-0329-4f4e-a600-73c49f6ee754"), new DateTime(2023, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("453228a9-8ee3-4739-b69d-336ce46a181a"), new DateTime(2023, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { new Guid("ed0d8b67-0a35-43c9-a46f-60366012cab0"), new DateTime(2023, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2435bfc4-79ee-4ec6-ae6f-439ff5044428"), new DateTime(2023, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "TicketPrices",
                columns: new[] { "Id", "CinemaTypeId", "Price", "ScreenTypeId", "ScreeningDayId", "SeatTypeId", "Status" },
                values: new object[,]
                {
                    { new Guid("08dcb3f9-cf30-472d-ab13-32b2eb569bbd"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 30000m, new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("428edc6b-0862-4623-b038-ac505fd554bc"), 1 },
                    { new Guid("0b2a89a2-186b-4391-84fb-d2393ec18bae"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 50000m, new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new Guid("e4f8f494-4e25-4966-806a-7b8843d79b6b"), new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("0edc63e8-0eab-46ba-b594-ed3e622f9ee0"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 80000m, new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new Guid("e4f8f494-4e25-4966-806a-7b8843d79b6b"), new Guid("428edc6b-0862-4623-b038-ac505fd554bc"), 1 },
                    { new Guid("1c614111-0f85-49d7-8e4d-daeedca63c44"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 10000m, new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new Guid("e4f8f494-4e25-4966-806a-7b8843d79b6b"), new Guid("428edc6b-0862-4623-b038-ac505fd554bc"), 1 },
                    { new Guid("1caec22f-f602-4bd1-bdf9-5b6c8c707bd6"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 80000m, new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new Guid("e4f8f494-4e25-4966-806a-7b8843d79b6b"), new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("30069041-cf67-487c-bfbb-33839fb35cb7"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 60000m, new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("428edc6b-0862-4623-b038-ac505fd554bc"), 1 },
                    { new Guid("4e3a4325-0c36-4c91-a5ac-f81ef0010bd9"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 40000m, new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("d997b27a-ddb7-4ad1-a1cd-c2bd00c50cb9"), 1 },
                    { new Guid("58b4504a-d07c-4d5e-9e43-373f1c9818de"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 50000m, new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new Guid("d51bee9b-54c3-4a3c-a06a-7c3940852f57"), new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("5a1081aa-2601-41ac-b2d7-8e5e3614ae46"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 80000m, new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("428edc6b-0862-4623-b038-ac505fd554bc"), 1 },
                    { new Guid("5ac8296d-9d98-4648-ad9a-b197fe757588"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 30000m, new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("d997b27a-ddb7-4ad1-a1cd-c2bd00c50cb9"), 1 },
                    { new Guid("5f8dff09-1ce5-4a87-92bf-b8a23c0d92eb"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 10000m, new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("71ab05c7-af12-4645-9650-1a198f4276d6"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 40000m, new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new Guid("d51bee9b-54c3-4a3c-a06a-7c3940852f57"), new Guid("d997b27a-ddb7-4ad1-a1cd-c2bd00c50cb9"), 1 },
                    { new Guid("751ed19d-ab70-4baf-83ef-814ad7bafe98"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 0m, new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new Guid("d51bee9b-54c3-4a3c-a06a-7c3940852f57"), new Guid("d997b27a-ddb7-4ad1-a1cd-c2bd00c50cb9"), 1 },
                    { new Guid("7813a5f6-81f7-461a-bbe5-df84cef329a7"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 20000m, new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new Guid("d51bee9b-54c3-4a3c-a06a-7c3940852f57"), new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("85921e23-5721-4610-8c46-04b3df9c2184"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 70000m, new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new Guid("e4f8f494-4e25-4966-806a-7b8843d79b6b"), new Guid("d997b27a-ddb7-4ad1-a1cd-c2bd00c50cb9"), 1 },
                    { new Guid("9b7515d8-777c-4c46-b149-e864d19c2c9a"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 90000m, new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new Guid("e4f8f494-4e25-4966-806a-7b8843d79b6b"), new Guid("428edc6b-0862-4623-b038-ac505fd554bc"), 1 },
                    { new Guid("9f1b477f-1a9b-439d-8d47-30d0182729d7"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 40000m, new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new Guid("d51bee9b-54c3-4a3c-a06a-7c3940852f57"), new Guid("428edc6b-0862-4623-b038-ac505fd554bc"), 1 },
                    { new Guid("a71612bc-c7d5-4f9c-9583-cf1305ac26ba"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 20000m, new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new Guid("d51bee9b-54c3-4a3c-a06a-7c3940852f57"), new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("ba02125a-5420-4e6b-a88b-3d2963e0c555"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 60000m, new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new Guid("d51bee9b-54c3-4a3c-a06a-7c3940852f57"), new Guid("428edc6b-0862-4623-b038-ac505fd554bc"), 1 },
                    { new Guid("c74a85d7-84b6-4096-9d61-f3eac166adfe"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 0m, new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("d997b27a-ddb7-4ad1-a1cd-c2bd00c50cb9"), 1 },
                    { new Guid("d12d3ae8-a061-4f43-9256-0fb616131973"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 60000m, new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new Guid("d51bee9b-54c3-4a3c-a06a-7c3940852f57"), new Guid("428edc6b-0862-4623-b038-ac505fd554bc"), 1 },
                    { new Guid("d1507f4c-417c-4615-9dab-bd2f28660cc4"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 30000m, new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new Guid("e4f8f494-4e25-4966-806a-7b8843d79b6b"), new Guid("428edc6b-0862-4623-b038-ac505fd554bc"), 1 },
                    { new Guid("d28e72b7-8fe9-4732-ba43-e40f267e3f8b"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 70000m, new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new Guid("d51bee9b-54c3-4a3c-a06a-7c3940852f57"), new Guid("428edc6b-0862-4623-b038-ac505fd554bc"), 1 },
                    { new Guid("d8bd8bd6-52e7-41be-9476-96bb490fa65c"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 20000m, new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("428edc6b-0862-4623-b038-ac505fd554bc"), 1 },
                    { new Guid("d9830a51-c4a8-4f08-8b4e-8af089b0e58c"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 0m, new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("e144a691-3d6a-4607-8944-3b94c7b21e1f"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 90000m, new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("428edc6b-0862-4623-b038-ac505fd554bc"), 1 },
                    { new Guid("e53c42be-afc3-49fe-9a00-792afcd03d4e"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 90000m, new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new Guid("e4f8f494-4e25-4966-806a-7b8843d79b6b"), new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("e61f296d-442e-4e5f-ab4b-a9b467b070c2"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 10000m, new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new Guid("e4f8f494-4e25-4966-806a-7b8843d79b6b"), new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("e9d851cd-9b32-4b2b-84b3-12cbcd1f80ee"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 50000m, new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("428edc6b-0862-4623-b038-ac505fd554bc"), 1 },
                    { new Guid("fea1a559-7e0d-4483-b996-0dfaa179d1e3"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 70000m, new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new Guid("d51bee9b-54c3-4a3c-a06a-7c3940852f57"), new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 }
                });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "Id", "ActivationStatus", "BarCode", "CreateTime", "MembershipId", "Status", "TotalMoney", "VoucherId" },
                values: new object[,]
                {
                    { new Guid("08fe7553-3742-495a-a9ab-439c492bd04e"), true, "barcode1.jpg", new DateTime(2024, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 10000m, null },
                    { new Guid("0cac3169-9cc9-4f34-98fb-ed9dc6deba0c"), true, "barcode22.jpg", new DateTime(2024, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 20000m, null },
                    { new Guid("16494580-36ae-4e88-9856-5cde6dfd9acf"), true, "barcode29.jpg", new DateTime(2024, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 90000m, null },
                    { new Guid("176e363d-1567-450b-8420-3ab44c53f27a"), true, "barcode7.jpg", new DateTime(2024, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 70000m, null },
                    { new Guid("212bc07a-d805-440c-9717-2f1e1020fc92"), true, "barcode14.jpg", new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 40000m, null },
                    { new Guid("384fbbf2-26c2-4752-8542-0a9fa68d48e1"), true, "barcode3.jpg", new DateTime(2024, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 30000m, null },
                    { new Guid("3d144ab3-384d-4273-9081-7a053b4001aa"), true, "barcode19.jpg", new DateTime(2024, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 90000m, null },
                    { new Guid("400fbc87-4b42-4d83-8d44-635b4da23cac"), true, "barcode20.jpg", new DateTime(2024, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 0m, null },
                    { new Guid("4df1da33-4569-457f-bd37-f9df4809e12b"), true, "barcode12.jpg", new DateTime(2024, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 20000m, null },
                    { new Guid("5b13aeda-0e57-4f88-9830-fa75d8dee144"), true, "barcode26.jpg", new DateTime(2024, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 60000m, null },
                    { new Guid("67d6d47c-d4ae-477f-b801-04e73a7fe53b"), true, "barcode10.jpg", new DateTime(2024, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 0m, null },
                    { new Guid("6a8d56e6-94ce-4f12-9722-9b82a17228f0"), true, "barcode9.jpg", new DateTime(2024, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 90000m, null },
                    { new Guid("75ec3bdb-d382-4b40-a1ed-1a046a92c8f2"), true, "barcode16.jpg", new DateTime(2024, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 60000m, null },
                    { new Guid("78088d71-b3af-402c-95a6-92243189e69d"), true, "barcode11.jpg", new DateTime(2024, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 10000m, null },
                    { new Guid("84069f21-455a-4baf-9eff-159454500436"), true, "barcode17.jpg", new DateTime(2024, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 70000m, null },
                    { new Guid("997826c2-3adc-47ea-9839-219e955fe461"), true, "barcode21.jpg", new DateTime(2024, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 10000m, null },
                    { new Guid("9b2f3bb4-9be9-4a0a-aa57-f7cf6ccbb1fa"), true, "barcode15.jpg", new DateTime(2024, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 50000m, null },
                    { new Guid("9b32b3b6-d128-42be-b67b-c39aa9237012"), true, "barcode30.jpg", new DateTime(2024, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 0m, null },
                    { new Guid("aa609b27-d614-465a-8fe3-0abc9aea6253"), true, "barcode6.jpg", new DateTime(2024, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 60000m, null },
                    { new Guid("af135110-2a5a-432f-9bc9-4dfe19bbc3df"), true, "barcode28.jpg", new DateTime(2024, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 80000m, null },
                    { new Guid("bb7f79f8-abbe-4e6e-a197-793daf127506"), true, "barcode2.jpg", new DateTime(2024, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 20000m, null },
                    { new Guid("c9bcb6d2-c37f-4dc3-a487-9b2f57e17c12"), true, "barcode23.jpg", new DateTime(2024, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 30000m, null },
                    { new Guid("cab547d1-bd0d-458d-9a34-c52e43ccb424"), true, "barcode18.jpg", new DateTime(2024, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 80000m, null },
                    { new Guid("dc4b0965-1048-4c48-beac-b4814cfc8bef"), true, "barcode13.jpg", new DateTime(2024, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 30000m, null },
                    { new Guid("ed49eb90-c66c-4ef2-ba6b-318b16a9c3f3"), true, "barcode4.jpg", new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 40000m, null },
                    { new Guid("f5a6985c-5607-46e6-8918-22abd0c7b05c"), true, "barcode5.jpg", new DateTime(2024, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 50000m, null },
                    { new Guid("f9402347-4fa0-4ca1-8553-fc6bc0a08c30"), true, "barcode24.jpg", new DateTime(2024, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 40000m, null },
                    { new Guid("fc40291a-c164-4e23-9d72-f330676a383c"), true, "barcode25.jpg", new DateTime(2024, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 50000m, null },
                    { new Guid("fccd1383-373e-4839-be51-68a60abba242"), true, "barcode8.jpg", new DateTime(2024, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 80000m, null },
                    { new Guid("fe6cfcc6-d410-4277-b234-6fd72e17f882"), true, "barcode27.jpg", new DateTime(2024, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 70000m, null }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CinemaId", "Position", "SeatTypeId", "Status" },
                values: new object[,]
                {
                    { new Guid("004bd15d-bb99-4721-a325-6457bb467524"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "G3", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("02a37959-5497-4bcf-af68-4b628bb6ab71"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "A7", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("050351b7-5a32-4817-8b05-719ecf21ac47"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "F6", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("07685872-13ce-4a77-8e8b-6db85337c8f8"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "H1", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("08610e4c-0fdd-4336-9798-575a631a5408"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "C9", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("0ae6942b-22fc-4a07-a9b1-dc339eee80b9"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "C1", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("0afed214-5f19-486e-b5a0-175e99d9cef9"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "D9", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("0c9aa588-4340-4eee-ba68-31bb67534502"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "F5", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("0cdecabe-631f-4090-9915-71ad3ebb45cb"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "J6", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("0d4c5e05-f2bf-4d29-83dc-eb49e4fed174"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "H7", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("0f09366a-7fd9-490b-8c77-183a03c9e6bf"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "A5", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("117625e5-fd45-4b5c-8713-c72e6e589e27"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "B10", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("15c49bab-3850-41cb-83ce-aa27a3aea67f"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "B7", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("18584798-c6ff-4bce-a3fc-f1a83e1a59e1"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "D7", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("1afda0fd-4c5b-4a8e-90fc-ce3d283b8826"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "C10", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("1d86f3c6-1577-4f8b-8dec-74ade2591994"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "A2", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("1fa8c461-4e1f-43ae-9730-7dc3d87a46f3"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "H9", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("290a762d-c6fb-41dc-b649-2ff8d181d303"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "D5", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("2a76114d-91a9-4c29-9a00-b216d4399f29"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "G5", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("32572bf1-bf63-4c58-ad1d-fd07e099d205"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "E3", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("35aad7d7-4f03-4441-a60b-250f944a0297"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "J2", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("376542f1-b326-4fc8-bcd4-3668c58c58e1"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "C7", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("376c4c8e-e0ee-494f-9732-7be307b4d07d"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "H3", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("3d8706d0-e943-4ac3-aacb-ceda86240007"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "F9", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("3fac1341-c15e-430e-8242-183df3732b2a"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "H6", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("4273ed04-b99f-49f6-bf2f-5fe9569501bd"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "A10", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("42857e46-6b82-44ac-92d3-cae7ec652aa8"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "B3", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("4641cbe4-e036-40f1-9c54-5b988b915b2a"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "G8", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("49cdc679-fc82-4f85-af83-f6f2a41ab580"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "E5", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("4a7bc398-7f8e-4ebf-876c-282605b3979a"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "E7", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("4c686e34-5209-4bd2-a968-822d3fbd1512"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "E2", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("4df214a0-00f6-49e6-85e1-e000aa2e6f85"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "D2", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("4e8211a7-963b-415b-9599-23902935cf0c"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "C8", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("4f573ba3-cdbb-4bbf-ab5b-80455894feea"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "D3", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("524ef4dd-badb-430e-96a6-06059fa6eeef"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "I1", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("5463601d-466a-49cd-98eb-9e44eab0aa9e"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "A3", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("557763bb-ea83-4a54-a1ca-3d2997704e27"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "E9", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("5ce59c4b-5e21-4ac5-b94c-55ef2ac83199"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "I9", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("5eb4bd4a-0a17-472a-88b3-a8b40651f360"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "A8", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("600da20f-1d6f-4243-8673-0180e0924858"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "G2", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("63bf0147-cbab-4716-8c10-157c52794084"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "E1", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("63c7166a-6e4c-4eaf-bfa7-0e0a59e2badd"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "F1", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("65cf57cb-93aa-416d-84c1-6bb5b6d79548"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "B9", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("7262a600-ae24-4098-8dbc-409111e20018"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "I8", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("7708fd27-f9a4-44af-a8b3-6fa1ca46bc0e"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "B2", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("8070306d-bc60-43f9-aade-17f13d9c461a"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "C6", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("82b97aae-f13d-4979-9175-f2448b1dc9b7"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "H4", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("87e425e0-01b0-4c19-8ee0-4d3a838978f1"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "A1", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("8b9d727c-6bd6-456e-b9ab-0858aa274ee1"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "C2", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("8bf3c57a-48ad-4af4-8fe7-176199a30f5c"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "E8", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("8c7774aa-a8b6-49a5-ad39-9d0ffb1bdc16"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "G1", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("8c9373f4-c358-439c-9ede-e5202f5b9aa4"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "D1", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("8ff004fb-2304-4c33-a3fe-34c9f758c301"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "D10", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("901a582e-5802-461e-9065-874dca2176ca"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "F2", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("904c501a-7272-4dcc-87bf-9b13cad0b953"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "B4", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("90baf860-63ed-40fa-bb3b-7542cee80882"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "G7", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("91655daf-0781-436d-8f9d-a986008e6262"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "F7", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("91e5e264-d009-497f-bb31-29d50499e265"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "D6", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("91fa0f43-572e-432c-98a1-6bda1352e6a4"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "H5", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("93308472-1e2a-4c6c-869c-63b4bff31d11"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "J9", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("9405051a-9edb-4800-8670-2eb61aad5871"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "D8", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("94cd2039-010b-4456-b757-7c582709b137"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "B1", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("96343396-1514-4f15-b626-53bd8ba68c66"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "J3", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("998beae0-c11e-43a2-aff0-5025ab881ac4"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "I2", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("9b9371b1-c304-4a1e-ba46-9ce674d45f3c"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "H8", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("9c8d5b58-7892-4bf7-bdcd-81009572cca9"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "I3", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("9d2ed994-d06b-4c64-a844-d4968c4a59d4"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "G6", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("9f6674d5-7014-4584-afbe-39bb93768e1e"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "H10", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("9fc15181-2665-42da-b552-706c6e9dc488"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "A6", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("a16ea38f-2481-4091-a3db-2386853b39e2"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "B8", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("a2e99d81-efe7-4ee9-81d1-95e84636a5b8"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "E6", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("a4794e5c-05be-4fdd-9332-0ee38977647b"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "I4", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("a9fdabe0-ec96-44f2-8e5d-3e87b6b8ab79"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "I10", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("aa9ec930-96c1-4644-b39f-d260d0c9b57a"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "A4", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("ad28ae8e-09b1-4670-aba5-d047a9ba0aef"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "E4", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("b00af439-d298-4c54-9ef9-51493410fed1"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "J8", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("b076915b-0616-454f-9616-c7f6cecfdc55"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "F10", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("b0b08db6-a10c-4cfc-ba7b-70cc8bcbd452"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "A9", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("b648c697-9cd4-45dd-9a5b-8cfe78a3bb02"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "E10", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("bc43024f-55a4-4461-bd92-5e6588464584"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "J4", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("c35f8683-a303-4360-9869-cdc15c8517b1"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "G9", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("c6027f91-2d8b-4dba-b215-5eaa69daa58b"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "J1", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("c80ace43-7f85-4ff4-a357-ff99ca61a279"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "J5", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("cd910bdf-9f32-4df2-a9bf-1ac86079af3a"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "G10", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("cdfae431-3afb-4afe-9bdf-80d7c55a95ed"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "J7", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("cec9ade7-b6e5-4480-8892-603fcbadc89f"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "I7", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("ced6ff42-d320-4f7e-85b0-1b4e13e6215d"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "J10", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("d0eb8f4a-9212-45ac-9191-bbdd00d0197d"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "F8", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("d1149fa5-5eb4-409c-8cf9-1c3d77f575cc"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "H2", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("d6cd8513-be53-46c1-a33d-9b7d245e8e16"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "B6", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("d7160e9d-3217-45e1-8994-ba6d16190e67"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "B5", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("d98982b4-5b0e-4ec5-9acd-51980f7dd1bd"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "F4", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("e1ae8d1f-0e34-47bf-bf56-5d75a5a0769c"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "C4", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("e7ab4bae-07bd-4a6f-89a4-5c80c363f42f"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "G4", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("e7b0bfe8-1de3-4e84-a34c-8d9c2d2c7a70"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "D4", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("e927dc29-d05e-498c-b86c-1278b9017612"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "C3", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("f0290172-85fa-4fa9-96c4-e788376ec67e"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "I5", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("f3de2c91-e702-4052-a23b-b82363043d75"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "C5", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("f6ff1e35-8fd9-422c-800d-f09baf0f221e"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "I6", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("f8caa92a-3856-4028-beee-cc8593fca6ca"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "F3", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 }
                });

            migrationBuilder.InsertData(
                table: "ShowTimes",
                columns: new[] { "Id", "CinemaCenterId", "CinemaId", "Desciption", "EndTime", "FilmId", "ScheduleId", "ScreenTypeId", "ShowtimeDate", "StartTime", "Status", "TranslationTypeId" },
                values: new object[,]
                {
                    { new Guid("06031aca-d7a0-45ee-87ca-e8d9b83eecbb"), new Guid("8bda5cc0-4f7f-4242-b23e-415fe3e3498f"), new Guid("6858c450-98ef-4e03-97e7-d7ca3b3d8ce9"), "Description for ShowTime 27", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2435bfc4-79ee-4ec6-ae6f-439ff5044428"), new Guid("ed0d8b67-0a35-43c9-a46f-60366012cab0"), new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), null, new DateTime(2024, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("1db895e8-bfb0-446a-8bd5-2506cbca010a"), new Guid("26ef9fd2-5b34-4bd1-b91a-f6cbf23b50c3"), new Guid("ee4a39ac-e048-4fc0-aaa7-75122c9aa7d7"), "Description for ShowTime 10", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("80688243-3577-4281-9550-c0f55295c0ac"), new Guid("995ce7c9-b08e-48bf-8c16-5f84e489e5a4"), new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), null, new DateTime(2024, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("247d20c5-7d5c-4f9a-b38b-064f5e2f32de"), new Guid("774bb7be-c62c-4a07-b962-5032015c0411"), new Guid("f8fe6028-1fc9-42e0-b58d-575e7550e307"), "Description for ShowTime 11", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("39831169-ef3a-42fd-b391-272857bab717"), new Guid("46c4eca9-d7bc-4220-ba85-e892112e59b6"), new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), null, new DateTime(2024, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("26f1585d-6a65-474b-9729-af0fd27c07a1"), new Guid("8e393bed-2b22-4b17-872b-da53b8ff75ad"), new Guid("e0a4782a-c594-42a5-a4c4-47f0aee15d40"), "Description for ShowTime 5", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("1bac7698-bc3e-4e0c-b052-d5a6f87a0c05"), new Guid("4a2a1d48-9cd4-4cc7-b5d3-8dbde5075180"), new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), null, new DateTime(2024, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("2dd71a0d-28d2-4b10-a693-2455d155c7e0"), new Guid("96bb5b79-1a11-4ef6-b6cf-2fc72ab74461"), new Guid("0a783862-3298-4dce-a1f3-caff5d7a0f1f"), "Description for ShowTime 9", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7e0b812e-435d-4f68-b589-cde23aa4e249"), new Guid("af659ca2-9629-46d8-9965-712fa7d71010"), new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), null, new DateTime(2024, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("2f783da7-f7ab-4e1c-b6e5-24465e53058b"), new Guid("8269c479-9bd9-4fd8-b0c4-f573a8631af4"), new Guid("21133506-7eef-4a5b-8532-fc0266330180"), "Description for ShowTime 14", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7ab3a193-9841-4afd-9975-21f495a4b7c2"), new Guid("62f2a7d7-87d8-4287-bedb-244245ffa0f7"), new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), null, new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("42c503d5-9b2e-4d2a-8a5a-20b07b9a7c2d"), new Guid("e6d3f6dd-929b-497c-bd54-454d317dea41"), new Guid("00ed026a-d4f0-4b56-95d4-9db923d7223b"), "Description for ShowTime 24", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("453228a9-8ee3-4739-b69d-336ce46a181a"), new Guid("df299f22-0329-4f4e-a600-73c49f6ee754"), new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), null, new DateTime(2024, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("45455ac8-ec3c-4d6e-ac27-9df78739e842"), new Guid("ae97ec2f-870c-4940-8679-65b362488677"), new Guid("bcb24e36-fc89-4f3c-9ae1-4784bee73016"), "Description for ShowTime 25", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("47b88ede-70f2-4074-856a-dcea6a9f4ec7"), new Guid("33424ab3-28c4-4162-a78f-2546e9abf104"), new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), null, new DateTime(2024, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("4c4b547b-0ae9-4602-be3e-facebd4649ec"), new Guid("78680907-7923-4966-b950-9c2494bb47bb"), new Guid("ca8f85a4-ccc6-40d0-b4ee-5d3720eba50e"), "Description for ShowTime 3", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b6d6f92f-2048-4279-8cf1-a749f4684404"), new Guid("29b69d23-3bf6-44b3-9cb8-b73b87b5a1ec"), new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), null, new DateTime(2024, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("6252a9d2-09bf-4a83-be2c-468af5236dba"), new Guid("195d310d-8236-41a2-8cf2-1092c96f6e3b"), new Guid("49cbdff1-0eaf-4f3e-939c-58da6cb64209"), "Description for ShowTime 15", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4af96ed7-3784-4f4f-9c4a-070363f90f5f"), new Guid("8357aa0b-48fd-4343-b5b6-8d5ff4a9366d"), new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), null, new DateTime(2024, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("6a3e34db-29ce-4848-9e30-e15caeff469e"), new Guid("986557b4-114c-4668-bd0e-02b416e99954"), new Guid("0e46cbaf-c555-4066-a8c9-e209694ab5fb"), "Description for ShowTime 21", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ff0a25f5-2719-45af-ad6f-e2adf5b65b5f"), new Guid("9f38c585-b966-4743-92a6-2dc8a9600f95"), new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), null, new DateTime(2024, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("7a3182b5-aaac-4116-93dd-2ab859d3efbf"), new Guid("5eba8de2-4492-44ac-8a4b-80e5c10ad326"), new Guid("7276cfb2-159c-4d6f-ad32-0c47af1118ce"), "Description for ShowTime 4", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("329c8514-2ddb-4554-998d-3bef7068423e"), new Guid("7b80eac5-4ba9-46a1-8361-00e5f77fc802"), new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), null, new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("89ac21af-d3fa-4946-bb39-5f132b8e3c51"), new Guid("0eedc93b-b2a9-4c09-9ba6-34f4532af50c"), new Guid("2650b463-4c73-46d2-a601-528c837ff24e"), "Description for ShowTime 13", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f10220ed-1241-41bf-826e-ba2f99519c50"), new Guid("252fcb3b-69ab-4bb7-9b24-073efa7e23e9"), new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), null, new DateTime(2024, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("8bb90529-64d5-4460-a309-6c767c792b31"), new Guid("9993c899-8956-4441-ae4a-fe06c32c6e02"), new Guid("bf34348b-0f36-4474-be13-08b6d78f9dca"), "Description for ShowTime 28", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5c86d655-14be-47b4-ba05-020167df03b8"), new Guid("47eb620e-a472-4dbd-a450-6784ee503ecd"), new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), null, new DateTime(2024, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("92180f99-928e-421b-83cf-8c936bc09ce9"), new Guid("65215a44-8f91-4e7a-aea2-46afb1dc083a"), new Guid("a51c195c-3446-453d-8870-24e921d3f360"), "Description for ShowTime 22", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a0f2822b-f398-4cb9-9941-5562fb355874"), new Guid("007fbba7-4dac-4cbb-9295-d6101a57629c"), new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), null, new DateTime(2024, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("94500556-c4dc-47b6-9e9d-2da205e84f5c"), new Guid("855605f0-f1bf-4791-b36d-37e10dd8c523"), new Guid("0ec16764-f7c5-4a4f-ba58-e06ca36f663f"), "Description for ShowTime 30", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c48ae736-d6bd-436b-baa9-b318ee7cb246"), new Guid("635cae6e-99c5-4a71-94ec-15542120554b"), new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), null, new DateTime(2024, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("9d60f0ed-850b-42d8-bcde-ae6bd47c54b7"), new Guid("a11ba9fe-9ebc-44fa-8db0-3cd0d10270c6"), new Guid("34f74fda-a941-43ed-8a14-bd16685aeafb"), "Description for ShowTime 12", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("604c7c77-37de-4a1c-bb8c-67313cb82b3c"), new Guid("d2ba36bc-2173-4ef2-9e24-f2a6ad6535c5"), new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), null, new DateTime(2024, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("9e29b11a-658b-441e-be53-0432c01c3d78"), new Guid("34607b9c-adfd-46ea-80e2-d6688e710f74"), new Guid("d7fc3872-14e3-4e9f-9ff0-93e803c0c7cb"), "Description for ShowTime 1", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d7b64f5e-f2d6-43c5-9949-d5ec83b7af0d"), new Guid("b1585ce9-6c05-4395-b67d-0100395cff73"), new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), null, new DateTime(2024, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("ac0b4987-a2d5-4585-8707-ff26ac07730f"), new Guid("ee8b9b21-fe0e-4add-816a-52b1a822b6ac"), new Guid("81706ee3-c0b3-4116-9e1d-812f6f8f5463"), "Description for ShowTime 8", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("39d30d8b-9d1c-4028-bf26-22f152c4370f"), new Guid("7263497e-9b79-4bc8-bcce-4e5da6fb7eeb"), new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), null, new DateTime(2024, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("c0bc35e5-4013-4bb2-a45d-7d1a73655228"), new Guid("e12faaf4-8a95-42a1-bd92-8d50beada41c"), new Guid("49ddf0e3-97a8-4989-a519-1376e7d0c5a1"), "Description for ShowTime 2", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("58d617d6-4605-41eb-983a-7f8b08902762"), new Guid("d992c3e8-e1fe-40ac-a4ab-feba8f2cfc11"), new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), null, new DateTime(2024, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("c9262864-fc02-41db-9213-07ad1ae27ce7"), new Guid("e58ec98d-2eba-40a6-a7c9-ac4228c635f1"), new Guid("345ead0f-cd0f-4a65-a2ba-88bf4b5bf413"), "Description for ShowTime 29", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d0a3a0f1-660f-46c0-8d40-317c3a1ef86f"), new Guid("9608c831-64cd-489e-b90e-bd10baf3aa2e"), new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), null, new DateTime(2024, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("d28543ff-c560-4c2d-bf98-49436f329412"), new Guid("e163e949-7e92-4d1f-a602-341faf1f3d7f"), new Guid("e81ff048-14f3-4188-a377-efffd431c9ae"), "Description for ShowTime 7", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("19b092c9-91df-4cea-92c0-d54e76f92572"), new Guid("0ccd0fdc-b377-442c-8f35-5fc03384455b"), new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), null, new DateTime(2024, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("d2ba8b0d-bea0-4a76-8b6d-9945566d57d8"), new Guid("a8817eda-abab-4bff-a3a5-82a1460ae416"), new Guid("7c1cf3f1-7fa8-4e0a-8118-656750f2d10f"), "Description for ShowTime 18", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("72bd7490-85de-4192-b486-586b189277db"), new Guid("84a4624e-73a4-425c-a066-d1f556aa35f6"), new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), null, new DateTime(2024, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("da810290-aacd-43ad-af23-14a1e71efbdc"), new Guid("b6a9896f-c9c6-4e97-a793-e18cfb55e1f7"), new Guid("b7af75e8-8aae-493a-b2ca-b61c290bc736"), "Description for ShowTime 26", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a44c3cdb-9840-4e5e-b972-7f31b10b23fe"), new Guid("193553e5-09d1-4992-b115-07d29ffd90a1"), new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), null, new DateTime(2024, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("e14d7649-fb92-46b3-9c72-fcd2f84195e8"), new Guid("2134060d-6ad6-42bc-b406-d1e381371abe"), new Guid("11796c6d-6a2f-4740-9d40-3fd1fde1390a"), "Description for ShowTime 17", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c89867e6-e84b-4630-9739-87f643b7bc83"), new Guid("6f54c038-dcad-408d-9c55-75afd7fa282d"), new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), null, new DateTime(2024, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("e1ef143d-956e-4872-bb04-01f12fba6efb"), new Guid("72e94f44-6348-428a-89c7-7808e0aca9ab"), new Guid("dea4f05c-d8bf-43d3-8bae-784cb7aeade3"), "Description for ShowTime 19", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c144ac5a-15bc-4394-8871-80c5d3944f85"), new Guid("1c59b2dc-825b-4a45-8b9e-e4de1e42ea80"), new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), null, new DateTime(2024, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("eb0cacb2-f65c-4ada-bd03-4ad1e065e19f"), new Guid("244ffcea-6b2b-4025-a043-eee24f165a05"), new Guid("88aa20e0-08d9-43c4-bc34-af6c4c7a2a58"), "Description for ShowTime 20", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fff70a8c-d5db-4191-b5c4-7d259aaad696"), new Guid("01236102-00aa-41c4-8a2d-d6a091156fc0"), new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), null, new DateTime(2024, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("fb5cc57e-f80a-43a3-9fa3-bf1df268f899"), new Guid("a80c70d7-65e3-4d74-a743-73c766c8e8ae"), new Guid("33bf015f-b3a0-409b-8695-a0095867d0f6"), "Description for ShowTime 6", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f9e358a5-63a9-4264-af67-5c9c9a05e719"), new Guid("0780cd4c-aac7-45de-8917-a07f8c34de2c"), new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), null, new DateTime(2024, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("fd2a0acd-ef4e-4c96-8ee2-116cfb4b20c8"), new Guid("f4c196de-ad5a-424c-94b6-80a4097afec1"), new Guid("4dd44dc3-d454-4ffd-b95a-f11057dc1cd6"), "Description for ShowTime 16", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6790789-26e6-47f0-bf21-409eb084037c"), new Guid("205a4149-ddb2-44ea-9f9e-11f438fa7b66"), new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), null, new DateTime(2024, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("fd9a2b6a-9ce3-477f-b180-1d344c416c21"), new Guid("b37ce504-e51d-4259-a0aa-a8d0584c9530"), new Guid("bc0f96c2-283b-476b-b59e-9ae20b6f3ad0"), "Description for ShowTime 23", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e621fade-b458-48b9-a9c9-24e39464c48d"), new Guid("d7b5edd3-955f-4b7b-967e-777c106edd44"), new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), null, new DateTime(2024, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "BillId", "CinemaCenterId", "Description", "Qrcode", "SeatId", "ShowTimeId", "Status", "TicketPriceId" },
                values: new object[,]
                {
                    { new Guid("03f7155d-21bf-45fc-88e2-e57801ecf79f"), new Guid("ed49eb90-c66c-4ef2-ba6b-318b16a9c3f3"), new Guid("f4c196de-ad5a-424c-94b6-80a4097afec1"), "Description for Ticket 4", "qrcode4.jpg", new Guid("ad28ae8e-09b1-4670-aba5-d047a9ba0aef"), new Guid("7a3182b5-aaac-4116-93dd-2ab859d3efbf"), 2, new Guid("9f1b477f-1a9b-439d-8d47-30d0182729d7") },
                    { new Guid("1c0de6b4-b7e4-4436-9f59-0cc76e12017c"), new Guid("9b2f3bb4-9be9-4a0a-aa57-f7cf6ccbb1fa"), new Guid("ae97ec2f-870c-4940-8679-65b362488677"), "Description for Ticket 15", "qrcode15.jpg", new Guid("4e8211a7-963b-415b-9599-23902935cf0c"), new Guid("6252a9d2-09bf-4a83-be2c-468af5236dba"), 2, new Guid("e9d851cd-9b32-4b2b-84b3-12cbcd1f80ee") },
                    { new Guid("1ded8a1e-c52c-4802-adf8-732a5fd34efc"), new Guid("75ec3bdb-d382-4b40-a1ed-1a046a92c8f2"), new Guid("195d310d-8236-41a2-8cf2-1092c96f6e3b"), "Description for Ticket 16", "qrcode16.jpg", new Guid("8bf3c57a-48ad-4af4-8fe7-176199a30f5c"), new Guid("fd2a0acd-ef4e-4c96-8ee2-116cfb4b20c8"), 2, new Guid("30069041-cf67-487c-bfbb-33839fb35cb7") },
                    { new Guid("28142831-162f-4f0e-9229-5119d3817d96"), new Guid("fccd1383-373e-4839-be51-68a60abba242"), new Guid("195d310d-8236-41a2-8cf2-1092c96f6e3b"), "Description for Ticket 8", "qrcode8.jpg", new Guid("8b9d727c-6bd6-456e-b9ab-0858aa274ee1"), new Guid("ac0b4987-a2d5-4585-8707-ff26ac07730f"), 2, new Guid("5a1081aa-2601-41ac-b2d7-8e5e3614ae46") },
                    { new Guid("2ada0f9b-5990-412b-b59e-b0382439a83a"), new Guid("fe6cfcc6-d410-4277-b234-6fd72e17f882"), new Guid("195d310d-8236-41a2-8cf2-1092c96f6e3b"), "Description for Ticket 27", "qrcode27.jpg", new Guid("f6ff1e35-8fd9-422c-800d-f09baf0f221e"), new Guid("06031aca-d7a0-45ee-87ca-e8d9b83eecbb"), 2, new Guid("fea1a559-7e0d-4483-b996-0dfaa179d1e3") },
                    { new Guid("48a8ae22-f3e1-4e4d-9b87-40ae17ee57a2"), new Guid("4df1da33-4569-457f-bd37-f9df4809e12b"), new Guid("8269c479-9bd9-4fd8-b0c4-f573a8631af4"), "Description for Ticket 12", "qrcode12.jpg", new Guid("d0eb8f4a-9212-45ac-9191-bbdd00d0197d"), new Guid("9d60f0ed-850b-42d8-bcde-ae6bd47c54b7"), 2, new Guid("d8bd8bd6-52e7-41be-9476-96bb490fa65c") },
                    { new Guid("53c6333b-0012-4354-9ed4-aad9f7d95122"), new Guid("384fbbf2-26c2-4752-8542-0a9fa68d48e1"), new Guid("b6a9896f-c9c6-4e97-a793-e18cfb55e1f7"), "Description for Ticket 3", "qrcode3.jpg", new Guid("32572bf1-bf63-4c58-ad1d-fd07e099d205"), new Guid("4c4b547b-0ae9-4602-be3e-facebd4649ec"), 2, new Guid("d1507f4c-417c-4615-9dab-bd2f28660cc4") },
                    { new Guid("5539088c-b5eb-4c5d-9615-2f76ca58dded"), new Guid("0cac3169-9cc9-4f34-98fb-ed9dc6deba0c"), new Guid("34607b9c-adfd-46ea-80e2-d6688e710f74"), "Description for Ticket 22", "qrcode22.jpg", new Guid("91fa0f43-572e-432c-98a1-6bda1352e6a4"), new Guid("92180f99-928e-421b-83cf-8c936bc09ce9"), 2, new Guid("7813a5f6-81f7-461a-bbe5-df84cef329a7") },
                    { new Guid("55d52dbf-adc3-4c7c-9747-bcefb04a1466"), new Guid("5b13aeda-0e57-4f88-9830-fa75d8dee144"), new Guid("a80c70d7-65e3-4d74-a743-73c766c8e8ae"), "Description for Ticket 26", "qrcode26.jpg", new Guid("904c501a-7272-4dcc-87bf-9b13cad0b953"), new Guid("da810290-aacd-43ad-af23-14a1e71efbdc"), 2, new Guid("ba02125a-5420-4e6b-a88b-3d2963e0c555") },
                    { new Guid("576f09e4-6d77-488c-ba7e-594baa26e4b9"), new Guid("9b32b3b6-d128-42be-b67b-c39aa9237012"), new Guid("a8817eda-abab-4bff-a3a5-82a1460ae416"), "Description for Ticket 30", "qrcode30.jpg", new Guid("290a762d-c6fb-41dc-b649-2ff8d181d303"), new Guid("94500556-c4dc-47b6-9e9d-2da205e84f5c"), 2, new Guid("d9830a51-c4a8-4f08-8b4e-8af089b0e58c") },
                    { new Guid("592b007b-0fe7-42ce-9362-b2bf05d01bff"), new Guid("f9402347-4fa0-4ca1-8553-fc6bc0a08c30"), new Guid("b6a9896f-c9c6-4e97-a793-e18cfb55e1f7"), "Description for Ticket 24", "qrcode24.jpg", new Guid("9b9371b1-c304-4a1e-ba46-9ce674d45f3c"), new Guid("42c503d5-9b2e-4d2a-8a5a-20b07b9a7c2d"), 2, new Guid("4e3a4325-0c36-4c91-a5ac-f81ef0010bd9") },
                    { new Guid("60606083-a7d6-409a-ae85-36420247e392"), new Guid("16494580-36ae-4e88-9856-5cde6dfd9acf"), new Guid("e58ec98d-2eba-40a6-a7c9-ac4228c635f1"), "Description for Ticket 29", "qrcode29.jpg", new Guid("f6ff1e35-8fd9-422c-800d-f09baf0f221e"), new Guid("c9262864-fc02-41db-9213-07ad1ae27ce7"), 2, new Guid("e144a691-3d6a-4607-8944-3b94c7b21e1f") },
                    { new Guid("606b1bf1-750d-4055-ba34-16e31d967e35"), new Guid("212bc07a-d805-440c-9717-2f1e1020fc92"), new Guid("a11ba9fe-9ebc-44fa-8db0-3cd0d10270c6"), "Description for Ticket 14", "qrcode14.jpg", new Guid("0d4c5e05-f2bf-4d29-83dc-eb49e4fed174"), new Guid("2f783da7-f7ab-4e1c-b6e5-24465e53058b"), 2, new Guid("71ab05c7-af12-4645-9650-1a198f4276d6") },
                    { new Guid("64c3e6a1-f7d6-4f07-8b07-39a3a05cb6a4"), new Guid("08fe7553-3742-495a-a9ab-439c492bd04e"), new Guid("ee8b9b21-fe0e-4add-816a-52b1a822b6ac"), "Description for Ticket 1", "qrcode1.jpg", new Guid("998beae0-c11e-43a2-aff0-5025ab881ac4"), new Guid("9e29b11a-658b-441e-be53-0432c01c3d78"), 2, new Guid("5f8dff09-1ce5-4a87-92bf-b8a23c0d92eb") },
                    { new Guid("72d26f5c-8ae8-44fc-a191-c60f283669e7"), new Guid("78088d71-b3af-402c-95a6-92243189e69d"), new Guid("855605f0-f1bf-4791-b36d-37e10dd8c523"), "Description for Ticket 11", "qrcode11.jpg", new Guid("d0eb8f4a-9212-45ac-9191-bbdd00d0197d"), new Guid("247d20c5-7d5c-4f9a-b38b-064f5e2f32de"), 2, new Guid("1c614111-0f85-49d7-8e4d-daeedca63c44") },
                    { new Guid("8cd5d9e3-dfbd-4f7e-b109-329a3bf0bb87"), new Guid("dc4b0965-1048-4c48-beac-b4814cfc8bef"), new Guid("a80c70d7-65e3-4d74-a743-73c766c8e8ae"), "Description for Ticket 13", "qrcode13.jpg", new Guid("9f6674d5-7014-4584-afbe-39bb93768e1e"), new Guid("89ac21af-d3fa-4946-bb39-5f132b8e3c51"), 2, new Guid("08dcb3f9-cf30-472d-ab13-32b2eb569bbd") },
                    { new Guid("8d74f56a-af75-47f8-9f95-8e8d3a12e7be"), new Guid("cab547d1-bd0d-458d-9a34-c52e43ccb424"), new Guid("986557b4-114c-4668-bd0e-02b416e99954"), "Description for Ticket 18", "qrcode18.jpg", new Guid("4273ed04-b99f-49f6-bf2f-5fe9569501bd"), new Guid("d2ba8b0d-bea0-4a76-8b6d-9945566d57d8"), 2, new Guid("0edc63e8-0eab-46ba-b594-ed3e622f9ee0") },
                    { new Guid("967194e4-e430-4f07-a3a0-0ad4b0550d21"), new Guid("bb7f79f8-abbe-4e6e-a197-793daf127506"), new Guid("34607b9c-adfd-46ea-80e2-d6688e710f74"), "Description for Ticket 2", "qrcode2.jpg", new Guid("f8caa92a-3856-4028-beee-cc8593fca6ca"), new Guid("c0bc35e5-4013-4bb2-a45d-7d1a73655228"), 2, new Guid("a71612bc-c7d5-4f9c-9583-cf1305ac26ba") },
                    { new Guid("a337965d-48d4-4937-800b-1d601d6167c3"), new Guid("3d144ab3-384d-4273-9081-7a053b4001aa"), new Guid("34607b9c-adfd-46ea-80e2-d6688e710f74"), "Description for Ticket 19", "qrcode19.jpg", new Guid("9c8d5b58-7892-4bf7-bdcd-81009572cca9"), new Guid("e1ef143d-956e-4872-bb04-01f12fba6efb"), 2, new Guid("9b7515d8-777c-4c46-b149-e864d19c2c9a") },
                    { new Guid("a8009669-aff3-47e5-8dab-8079d39158bf"), new Guid("84069f21-455a-4baf-9eff-159454500436"), new Guid("774bb7be-c62c-4a07-b962-5032015c0411"), "Description for Ticket 17", "qrcode17.jpg", new Guid("91655daf-0781-436d-8f9d-a986008e6262"), new Guid("e14d7649-fb92-46b3-9c72-fcd2f84195e8"), 2, new Guid("85921e23-5721-4610-8c46-04b3df9c2184") },
                    { new Guid("b0cabb70-5526-40a4-8b58-f154a4f38422"), new Guid("af135110-2a5a-432f-9bc9-4dfe19bbc3df"), new Guid("244ffcea-6b2b-4025-a043-eee24f165a05"), "Description for Ticket 28", "qrcode28.jpg", new Guid("0afed214-5f19-486e-b5a0-175e99d9cef9"), new Guid("8bb90529-64d5-4460-a309-6c767c792b31"), 2, new Guid("1caec22f-f602-4bd1-bdf9-5b6c8c707bd6") },
                    { new Guid("c9be38ee-f946-4b8f-8643-72dbaa057aaa"), new Guid("176e363d-1567-450b-8420-3ab44c53f27a"), new Guid("b37ce504-e51d-4259-a0aa-a8d0584c9530"), "Description for Ticket 7", "qrcode7.jpg", new Guid("004bd15d-bb99-4721-a325-6457bb467524"), new Guid("d28543ff-c560-4c2d-bf98-49436f329412"), 2, new Guid("d28e72b7-8fe9-4732-ba43-e40f267e3f8b") },
                    { new Guid("cdf4863c-d854-4d6d-a758-76d30815786d"), new Guid("fc40291a-c164-4e23-9d72-f330676a383c"), new Guid("195d310d-8236-41a2-8cf2-1092c96f6e3b"), "Description for Ticket 25", "qrcode25.jpg", new Guid("9d2ed994-d06b-4c64-a844-d4968c4a59d4"), new Guid("45455ac8-ec3c-4d6e-ac27-9df78739e842"), 2, new Guid("0b2a89a2-186b-4391-84fb-d2393ec18bae") },
                    { new Guid("d237b9e2-09dd-4fbe-86a3-384d8fc2bec9"), new Guid("6a8d56e6-94ce-4f12-9722-9b82a17228f0"), new Guid("e12faaf4-8a95-42a1-bd92-8d50beada41c"), "Description for Ticket 9", "qrcode9.jpg", new Guid("cec9ade7-b6e5-4480-8892-603fcbadc89f"), new Guid("2dd71a0d-28d2-4b10-a693-2455d155c7e0"), 2, new Guid("e53c42be-afc3-49fe-9a00-792afcd03d4e") },
                    { new Guid("d9beb6c7-ed6f-48c0-bd1f-9ec2b4fa3179"), new Guid("f5a6985c-5607-46e6-8918-22abd0c7b05c"), new Guid("26ef9fd2-5b34-4bd1-b91a-f6cbf23b50c3"), "Description for Ticket 5", "qrcode5.jpg", new Guid("8ff004fb-2304-4c33-a3fe-34c9f758c301"), new Guid("26f1585d-6a65-474b-9729-af0fd27c07a1"), 2, new Guid("58b4504a-d07c-4d5e-9e43-373f1c9818de") },
                    { new Guid("e228323c-fb99-4540-8588-a3d7499cab00"), new Guid("aa609b27-d614-465a-8fe3-0abc9aea6253"), new Guid("0eedc93b-b2a9-4c09-9ba6-34f4532af50c"), "Description for Ticket 6", "qrcode6.jpg", new Guid("63bf0147-cbab-4716-8c10-157c52794084"), new Guid("fb5cc57e-f80a-43a3-9fa3-bf1df268f899"), 2, new Guid("d12d3ae8-a061-4f43-9256-0fb616131973") },
                    { new Guid("ed750d9f-8890-4f51-920b-2cd6fcb77456"), new Guid("400fbc87-4b42-4d83-8d44-635b4da23cac"), new Guid("a8817eda-abab-4bff-a3a5-82a1460ae416"), "Description for Ticket 20", "qrcode20.jpg", new Guid("290a762d-c6fb-41dc-b649-2ff8d181d303"), new Guid("eb0cacb2-f65c-4ada-bd03-4ad1e065e19f"), 2, new Guid("c74a85d7-84b6-4096-9d61-f3eac166adfe") },
                    { new Guid("edc01176-876e-41ab-8eee-2d8fd24a894e"), new Guid("67d6d47c-d4ae-477f-b801-04e73a7fe53b"), new Guid("e58ec98d-2eba-40a6-a7c9-ac4228c635f1"), "Description for Ticket 10", "qrcode10.jpg", new Guid("a2e99d81-efe7-4ee9-81d1-95e84636a5b8"), new Guid("1db895e8-bfb0-446a-8bd5-2506cbca010a"), 2, new Guid("751ed19d-ab70-4baf-83ef-814ad7bafe98") },
                    { new Guid("ef618db8-1438-4b07-adb3-966046f575a7"), new Guid("997826c2-3adc-47ea-9839-219e955fe461"), new Guid("e6d3f6dd-929b-497c-bd54-454d317dea41"), "Description for Ticket 21", "qrcode21.jpg", new Guid("8070306d-bc60-43f9-aade-17f13d9c461a"), new Guid("6a3e34db-29ce-4848-9e30-e15caeff469e"), 2, new Guid("e61f296d-442e-4e5f-ab4b-a9b467b070c2") },
                    { new Guid("fb23cdcf-e6e9-4393-87f8-5b222432c33b"), new Guid("c9bcb6d2-c37f-4dc3-a487-9b2f57e17c12"), new Guid("ee8b9b21-fe0e-4add-816a-52b1a822b6ac"), "Description for Ticket 23", "qrcode23.jpg", new Guid("600da20f-1d6f-4243-8673-0180e0924858"), new Guid("fd9a2b6a-9ce3-477f-b180-1d344c416c21"), 2, new Guid("5ac8296d-9d98-4648-ad9a-b197fe757588") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BillCombos_BillId",
                table: "BillCombos",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_MembershipId",
                table: "Bills",
                column: "MembershipId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_VoucherId",
                table: "Bills",
                column: "VoucherId");

            migrationBuilder.CreateIndex(
                name: "IX_BillSeats_BillId",
                table: "BillSeats",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_Cinemas_CinemaCenterId",
                table: "Cinemas",
                column: "CinemaCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Cinemas_CinemaTypeId",
                table: "Cinemas",
                column: "CinemaTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfirmedEmails_AccountId",
                table: "ConfirmedEmails",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmScreenTypes_FilmId",
                table: "FilmScreenTypes",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmTranslationTypes_FilmId",
                table: "FilmTranslationTypes",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_PromotionDetails_PromotionId",
                table: "PromotionDetails",
                column: "PromotionId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_AccountId",
                table: "RefreshTokens",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_FilmId",
                table: "Schedules",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_CinemaId",
                table: "Seats",
                column: "CinemaId");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_SeatTypeId",
                table: "Seats",
                column: "SeatTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ShowTimes_CinemaCenterId",
                table: "ShowTimes",
                column: "CinemaCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_ShowTimes_CinemaId",
                table: "ShowTimes",
                column: "CinemaId");

            migrationBuilder.CreateIndex(
                name: "IX_ShowTimes_FilmId",
                table: "ShowTimes",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_ShowTimes_ScheduleId",
                table: "ShowTimes",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_ShowTimes_ScreenTypeId",
                table: "ShowTimes",
                column: "ScreenTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ShowTimes_TranslationTypeId",
                table: "ShowTimes",
                column: "TranslationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketPrices_CinemaTypeId",
                table: "TicketPrices",
                column: "CinemaTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketPrices_ScreeningDayId",
                table: "TicketPrices",
                column: "ScreeningDayId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketPrices_ScreenTypeId",
                table: "TicketPrices",
                column: "ScreenTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketPrices_SeatTypeId",
                table: "TicketPrices",
                column: "SeatTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_BillId",
                table: "Tickets",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_CinemaCenterId",
                table: "Tickets",
                column: "CinemaCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_SeatId",
                table: "Tickets",
                column: "SeatId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ShowTimeId",
                table: "Tickets",
                column: "ShowTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TicketPriceId",
                table: "Tickets",
                column: "TicketPriceId",
                unique: true,
                filter: "[TicketPriceId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_VoucherDetails_VoucherId",
                table: "VoucherDetails",
                column: "VoucherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Banners");

            migrationBuilder.DropTable(
                name: "BillCombos");

            migrationBuilder.DropTable(
                name: "BillSeats");

            migrationBuilder.DropTable(
                name: "ConfirmedEmails");

            migrationBuilder.DropTable(
                name: "FilmScreenTypes");

            migrationBuilder.DropTable(
                name: "FilmTranslationTypes");

            migrationBuilder.DropTable(
                name: "PromotionDetails");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "VoucherDetails");

            migrationBuilder.DropTable(
                name: "Combos");

            migrationBuilder.DropTable(
                name: "Promotions");

            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "ShowTimes");

            migrationBuilder.DropTable(
                name: "TicketPrices");

            migrationBuilder.DropTable(
                name: "Memberships");

            migrationBuilder.DropTable(
                name: "Vouchers");

            migrationBuilder.DropTable(
                name: "Cinemas");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "TranslationTypes");

            migrationBuilder.DropTable(
                name: "ScreenTypes");

            migrationBuilder.DropTable(
                name: "ScreeningDays");

            migrationBuilder.DropTable(
                name: "SeatTypes");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "CinemaCenters");

            migrationBuilder.DropTable(
                name: "CinemaTypes");

            migrationBuilder.DropTable(
                name: "Films");
        }
    }
}