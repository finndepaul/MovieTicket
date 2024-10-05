using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieTicket.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
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
                    CreateTime = table.Column<DateTime>(type: "date", nullable: true),
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
                    Position = table.Column<int>(type: "int", nullable: true),
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
                    { new Guid("0517a962-acb8-4a62-99d0-a7a89e64fcb5"), "avatar6.png", new DateTime(2023, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "user6@example.com", "User 6", "ns3cIzMXn9uRJUqXbdf1sw==", "123-456-7896", 2, 1, "user6" },
                    { new Guid("05cf4767-5d0b-46af-af2a-27d9d800a04a"), "avatar30.png", new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "user30@example.com", "User 30", "ZIc8EakA57j1Q7JTsakLKA==", "123-456-78930", 2, 1, "user30" },
                    { new Guid("07a4f8c8-e14f-468e-bcc6-c33dfe624ac3"), "avatar21.png", new DateTime(2023, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "user21@example.com", "User 21", "uqWAcnIuI+ey7XOiRgb8IA==", "123-456-78921", 2, 1, "user21" },
                    { new Guid("19c662c4-12a4-48a9-bfd6-ec08b6f3b397"), "avatar1.png", new DateTime(2023, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "user1@example.com", "User 1", "ei00xFxTj/yW/ErUUw1JvA==", "123-456-7891", 2, 1, "user1" },
                    { new Guid("2a6d87ab-365b-4f75-916b-64f5802dc25f"), "avatar27.png", new DateTime(2023, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "user27@example.com", "User 27", "lePABwdtIg5MqkBgyFdL9Q==", "123-456-78927", 2, 1, "user27" },
                    { new Guid("2d40473d-a034-4ddd-851a-95885a8a4cc6"), "avatar20.png", new DateTime(2023, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "user20@example.com", "User 20", "J20oEfuyjDdy085hSNPLIw==", "123-456-78920", 2, 1, "user20" },
                    { new Guid("31c2348c-05f4-4a03-a0e7-eea362d5e7c0"), "avatar15.png", new DateTime(2023, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "user15@example.com", "User 15", "AtoLhqKWoDhm5ytm7x3CFg==", "123-456-78915", 2, 1, "user15" },
                    { new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), "avatar2.png", new DateTime(2023, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "azusachan309@gmail.com", "ClientTest", "LK25tQh1RqkKbrq4C2l6fw==", "000-000-000", 2, 1, "Client" },
                    { new Guid("3af2d3c2-6a8b-46a7-a89e-5c573960528c"), "avatar19.png", new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "user19@example.com", "User 19", "+BFH+L+RScNaLm45T9M5Tw==", "123-456-78919", 2, 1, "user19" },
                    { new Guid("47d9e9fa-3192-4356-a90b-9cf2f9a3c50c"), "avatar14.png", new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "user14@example.com", "User 14", "Nbb9cBgoI2KknXYhJgRsOg==", "123-456-78914", 2, 1, "user14" },
                    { new Guid("4b1f8531-719b-40e7-94b5-8b7496803931"), "avatar8.png", new DateTime(2023, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "user8@example.com", "User 8", "QoNqXwm6ndtmwV7AptAudw==", "123-456-7898", 2, 1, "user8" },
                    { new Guid("5312c43d-e07b-4ea5-916b-e652308cb336"), "avatar23.png", new DateTime(2023, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "user23@example.com", "User 23", "JM3wDHJHLSLI6Wdnnfs2dQ==", "123-456-78923", 2, 1, "user23" },
                    { new Guid("5c38bfa2-e25e-4d8b-b010-20ff2b93e312"), "avatar18.png", new DateTime(2023, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "user18@example.com", "User 18", "zp6jPz/JRrDgXS7tmjREDQ==", "123-456-78918", 2, 1, "user18" },
                    { new Guid("6151bba7-2698-4033-91ba-e14d8a6ff850"), "avatar17.png", new DateTime(2023, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "user17@example.com", "User 17", "bnivYPkMUcJNzvYQyXZIvw==", "123-456-78917", 2, 1, "user17" },
                    { new Guid("61522be3-2cb2-4a27-aaba-d2c82555c71b"), "avatar4.png", new DateTime(2023, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "user4@example.com", "User 4", "AYCB0pkX1QvnELN5s4E7/w==", "123-456-7894", 2, 1, "user4" },
                    { new Guid("6450612c-3035-40c6-af7b-03a7cbc7fba9"), "avatar2.png", new DateTime(2023, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "user2@example.com", "User 2", "gPFa6fSRCX/O3JCnJjTBBg==", "123-456-7892", 2, 1, "user2" },
                    { new Guid("686784af-0aba-4393-b332-4928b2b68c4d"), "avatar28.png", new DateTime(2023, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "user28@example.com", "User 28", "R/9+ITDUv36NqhUmUxCu5w==", "123-456-78928", 2, 1, "user28" },
                    { new Guid("6e3165d0-9800-4974-85b8-17844e422150"), "avatar10.png", new DateTime(2023, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "user10@example.com", "User 10", "AD+DKAMne24G+bFvnB3umA==", "123-456-78910", 2, 1, "user10" },
                    { new Guid("71c601db-113d-441d-a183-b21bbae0b068"), "avatar7.png", new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "user7@example.com", "User 7", "h8t5vD5p1U3C4AEASeaErg==", "123-456-7897", 2, 1, "user7" },
                    { new Guid("74103c81-a5b0-45f4-963f-25a71ec84f28"), "avatar24.png", new DateTime(2023, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "user24@example.com", "User 24", "wUy5uoNVQITmQW5R4nnOMA==", "123-456-78924", 2, 1, "user24" },
                    { new Guid("7a9d5900-b6d4-43eb-85de-15c4b1288d0a"), "avatar9.png", new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "user9@example.com", "User 9", "XLl70iIryQx+lE/y5900Uw==", "123-456-7899", 2, 1, "user9" },
                    { new Guid("7bc7845d-695d-494d-9b3f-152a8b982b45"), "avatar29.png", new DateTime(2023, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "user29@example.com", "User 29", "ETdpo/KPinCotdzGNmsAPA==", "123-456-78929", 2, 1, "user29" },
                    { new Guid("87ce9a38-550b-4ea8-a7b0-6b98c004512b"), "avatar13.png", new DateTime(2023, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "user13@example.com", "User 13", "hjKFGDVLaz8y7jip9ebjyg==", "123-456-78913", 2, 1, "user13" },
                    { new Guid("94c34542-f2ca-46e6-a88a-296934000500"), "avatar5.png", new DateTime(2023, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "user5@example.com", "User 5", "LtgxZLXxd71ac78V6rYtcg==", "123-456-7895", 2, 1, "user5" },
                    { new Guid("9bb59daa-ddfd-43d0-a50c-407575e293b0"), "avatar11.png", new DateTime(2023, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "user11@example.com", "User 11", "+1XAkm3H0MciMPlnUyv6ww==", "123-456-78911", 2, 1, "user11" },
                    { new Guid("aa2c4d22-49e0-4981-a650-d8b82b529e0e"), "avatar16.png", new DateTime(2023, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "user16@example.com", "User 16", "1+4JJ+OIs+XRXx0vTPNGQA==", "123-456-78916", 2, 1, "user16" },
                    { new Guid("aaa9df08-b318-4790-b6a3-b512400359a1"), "avatar26.png", new DateTime(2023, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "user26@example.com", "User 26", "JTjto+r7kPyCkZGQtsDBOA==", "123-456-78926", 2, 1, "user26" },
                    { new Guid("ac23e9f7-5d82-431c-a3e0-8274492874fc"), "avatar22.png", new DateTime(2023, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "user22@example.com", "User 22", "yuwYTyVSnjUQg9d58Fr6eg==", "123-456-78922", 2, 1, "user22" },
                    { new Guid("ade584a2-6e1d-42ba-a1a9-9d0d585ea2ef"), "avatar3.png", new DateTime(2023, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "user3@example.com", "User 3", "XZG20Zjr0RmKJ42oxCGZqQ==", "123-456-7893", 2, 1, "user3" },
                    { new Guid("bc67c711-5d8a-4c9e-b415-e488bd7789a9"), "avatar25.png", new DateTime(2023, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "user25@example.com", "User 25", "o+65kwYOgM/H5YtlR5eBGQ==", "123-456-78925", 2, 1, "user25" },
                    { new Guid("c32411c1-18e9-499e-b9d1-16943c2844e9"), "avatar12.png", new DateTime(2023, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "user12@example.com", "User 12", "q/b7mh1nE1JeI7y/w6yvIQ==", "123-456-78912", 2, 1, "user12" },
                    { new Guid("fd36705c-0610-4c30-9cfb-e5827b3f3d78"), "avatar1.png", new DateTime(2023, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "azusachan307@gmail.com", "AdminTest", "LK25tQh1RqkKbrq4C2l6fw==", "000-000-000", 1, 1, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "CinemaCenters",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[,]
                {
                    { new Guid("0104bfac-0f55-43a4-9e6e-942d7b09712b"), "Address 17", "Cinema Center 17" },
                    { new Guid("026cd9fb-e1c5-44d8-8eb1-dc828982a849"), "Address 7", "Cinema Center 7" },
                    { new Guid("0e75aa19-af1e-493f-9b63-838542826cd7"), "Address 2", "Cinema Center 2" },
                    { new Guid("40ce4cd7-abb3-4f6c-a583-b351806cfa5f"), "Address 3", "Cinema Center 3" },
                    { new Guid("4937f1fa-79c3-4f76-bb58-fc37fe6c2df3"), "Address 4", "Cinema Center 4" },
                    { new Guid("506611d2-8578-4d50-aaaf-4ef78c64b42b"), "Address 27", "Cinema Center 27" },
                    { new Guid("5297311c-444b-44a1-8d5d-a479c698a486"), "Address 11", "Cinema Center 11" },
                    { new Guid("5702e262-c3a1-490d-a1bf-5a2b90fa8213"), "Address 1", "Cinema Center 1" },
                    { new Guid("5e0934d8-e2c9-4e7a-912a-40d526ebc4e1"), "Address 10", "Cinema Center 10" },
                    { new Guid("64037f78-6880-496e-b377-ec75207cfaf0"), "Address 6", "Cinema Center 6" },
                    { new Guid("6c2ce430-9318-4718-9397-8271f2ef235f"), "Address 25", "Cinema Center 25" },
                    { new Guid("70fe1c28-e815-4132-84cc-78aeca3a32e8"), "Address 28", "Cinema Center 28" },
                    { new Guid("778f70d8-2cdb-4233-8b06-e7080c32f7fe"), "Address 19", "Cinema Center 19" },
                    { new Guid("7ceab03c-ab44-4852-864d-248b84829da2"), "Address 21", "Cinema Center 21" },
                    { new Guid("7f3b8ea5-b7be-4bb1-a724-26052329c451"), "Address 22", "Cinema Center 22" },
                    { new Guid("80106303-1458-4f27-a35d-c1f72ea3db1e"), "Address 16", "Cinema Center 16" },
                    { new Guid("837929a9-2991-4382-aac2-3341f37296c2"), "Address 13", "Cinema Center 13" },
                    { new Guid("8c215391-f10e-400d-951b-47fe6a44c8d7"), "Address 29", "Cinema Center 29" },
                    { new Guid("a101a88c-ef71-4889-ba05-724e6d6a0231"), "Address 24", "Cinema Center 24" },
                    { new Guid("a36b428c-de76-4ebd-87c3-587f0b41e870"), "Address 12", "Cinema Center 12" },
                    { new Guid("a79736bd-5167-4d63-bc8d-95ead276d6a9"), "Address 14", "Cinema Center 14" },
                    { new Guid("b4a73848-0660-4a06-8670-5fcfa52e7f3e"), "Address 18", "Cinema Center 18" },
                    { new Guid("b7d43885-549f-4701-9cb3-cc37532e17f1"), "Address 15", "Cinema Center 15" },
                    { new Guid("b95a8bc6-4f33-4e7a-9a43-de3a05a25636"), "Address 30", "Cinema Center 30" },
                    { new Guid("c4ec6444-c437-4b38-ae3b-4371469c11be"), "Address 23", "Cinema Center 23" },
                    { new Guid("c9c8d3d6-45ad-4fc5-bdc0-67ba3a9ccbc5"), "Address 9", "Cinema Center 9" },
                    { new Guid("d8c4fa8f-07bc-4be7-a77d-a91bd7350775"), "Address 8", "Cinema Center 8" },
                    { new Guid("e168f30c-a391-4949-9523-fee2408db37b"), "Address 26", "Cinema Center 26" },
                    { new Guid("ec762dfc-63e6-4af6-8bc9-9c9cf4f70019"), "Address 5", "Cinema Center 5" },
                    { new Guid("f04d9768-c223-4a95-89f8-4e145e454e17"), "Address 20", "Cinema Center 20" }
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
                    { new Guid("04e9fc01-30c1-4cb8-9390-3d9c795278e9"), "Combo 10", 0m },
                    { new Guid("0cd8d202-5078-4aa0-8b64-9f5ea6a42325"), "Combo 23", 30000m },
                    { new Guid("191322dc-bc05-4d22-b897-a19443e7f2e8"), "Combo 26", 60000m },
                    { new Guid("29a3aac5-d193-4932-ae33-d5ee5f003b0f"), "Combo 24", 40000m },
                    { new Guid("4c57a305-824d-4029-bb6f-acd2020c0a1f"), "Combo 19", 90000m },
                    { new Guid("52a71c83-c474-4afe-a269-f285aa1938d9"), "Combo 28", 80000m },
                    { new Guid("614ef4e6-f1e1-4090-8a82-4bafdbccb107"), "Combo 14", 40000m },
                    { new Guid("6ce91185-740d-4616-bf4a-61f72c5c6e98"), "Combo 13", 30000m },
                    { new Guid("6d063051-69a3-4207-be11-db1730303af6"), "Combo 12", 20000m },
                    { new Guid("726dd655-ad43-4774-b660-9fe3dc1e53ff"), "Combo 3", 30000m },
                    { new Guid("76b709a6-f807-41df-a107-9b2a17fd1ea9"), "Combo 20", 0m },
                    { new Guid("7fc95605-71da-479e-b6f0-c553a4a73732"), "Combo 15", 50000m },
                    { new Guid("8de94009-f293-4e9d-8052-d062a5177a93"), "Combo 22", 20000m },
                    { new Guid("8e4c6fe3-5a69-489c-a09d-169635c80707"), "Combo 25", 50000m },
                    { new Guid("8e6b4de3-6ad7-457c-927a-aa39d4aeb5d1"), "Combo 7", 70000m },
                    { new Guid("8ef8a557-5059-4442-9e69-002086fa9fcd"), "Combo 18", 80000m },
                    { new Guid("8fd97926-aa60-428a-9863-a3a16aa6af3c"), "Combo 9", 90000m },
                    { new Guid("96a3efa1-7d3e-46e0-9a7c-49e763eb032c"), "Combo 4", 40000m },
                    { new Guid("97888d30-22e2-4e0a-b87a-9b7de981a601"), "Combo 6", 60000m },
                    { new Guid("9a82e4ce-3fcf-4164-969d-aa9ec711fc19"), "Combo 27", 70000m },
                    { new Guid("9d0f55a6-87d8-4771-a347-2acd462330a0"), "Combo 5", 50000m },
                    { new Guid("a334a760-b6d5-418b-a6ae-cb8446d5a857"), "Combo 30", 0m },
                    { new Guid("a5908a64-4b88-40b9-81ac-e6148d92dc63"), "Combo 11", 10000m },
                    { new Guid("ab3b34fd-4810-46b4-beba-d9e3c67c24d9"), "Combo 21", 10000m },
                    { new Guid("b3576ae4-0525-4166-84c4-c967114f3827"), "Combo 16", 60000m },
                    { new Guid("b9925da4-25a2-4c8d-adeb-f4fe74d5da6e"), "Combo 17", 70000m },
                    { new Guid("bebb351c-ae84-469c-a69c-91fe1ecdc09d"), "Combo 1", 10000m },
                    { new Guid("d6a47170-2837-4764-bbe0-4bd66079afa1"), "Combo 29", 90000m },
                    { new Guid("dfba0a82-1956-4e71-9bde-2d410ed56ccc"), "Combo 8", 80000m },
                    { new Guid("f7a8c6ec-cf21-4b2a-9fce-bf578062154a"), "Combo 2", 20000m }
                });

            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "Id", "Cast", "CreatDate", "Description", "Director", "EnglishName", "Gerne", "Language", "Name", "Nation", "Poster", "Rating", "ReleaseYear", "RunningTime", "ScreenTypeId", "StartDate", "Status", "Trailer", "TranslationTypeId" },
                values: new object[,]
                {
                    { new Guid("012a9cea-1709-41c2-9319-fbd51c859529"), "Actor 25, Actress 25", new DateTime(2023, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 25.", "Director 25", "Film 25 (English)", "Comedy", "Japanese", "Film 25", "Japan", "https://example.com/poster25.jpg", 1, 2023, 85, new Guid("3d5740bd-0e42-44bf-8eb4-a62db308227d"), new DateTime(2023, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer25.mp4", new Guid("a38013df-f76c-404f-b389-aa43836e9b72") },
                    { new Guid("2728118a-0bb7-40e4-955b-d143717160a3"), "Actor 10, Actress 10", new DateTime(2023, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 10.", "Director 10", "Film 10 (English)", "Action", "English", "Film 10", "USA", "https://example.com/poster10.jpg", 1, 2023, 70, new Guid("06dda287-f016-4bff-a3fb-e655da960058"), new DateTime(2023, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer10.mp4", new Guid("6f3dd40b-f073-407c-b44a-8e7cb3af090f") },
                    { new Guid("2e44b946-809f-48ab-8535-966bfa2c9e2b"), "Actor 11, Actress 11", new DateTime(2023, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 11.", "Director 11", "Film 11 (English)", "Comedy", "Japanese", "Film 11", "Japan", "https://example.com/poster11.jpg", 2, 2023, 71, new Guid("05466674-9c2f-44b3-b224-927dd5167124"), new DateTime(2023, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer11.mp4", new Guid("c1a19e45-e904-4922-bf22-6899d1d218ac") },
                    { new Guid("30909bea-5840-4df7-94b8-8b9096ffc78b"), "Actor 24, Actress 24", new DateTime(2023, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 24.", "Director 24", "Film 24 (English)", "Action", "English", "Film 24", "USA", "https://example.com/poster24.jpg", 5, 2023, 84, new Guid("699390fe-3f65-4e77-a9a7-0029087b8b3d"), new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer24.mp4", new Guid("dfccb355-5069-46a9-9a5c-568bc2f59068") },
                    { new Guid("30cdff19-6aca-4209-a058-22c55945efb1"), "Actor 8, Actress 8", new DateTime(2023, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 8.", "Director 8", "Film 8 (English)", "Action", "English", "Film 8", "USA", "https://example.com/poster8.jpg", 4, 2023, 68, new Guid("79016e62-6138-4793-87a0-151d6bc977d2"), new DateTime(2023, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer8.mp4", new Guid("dd4d50f6-459d-45a5-b651-9c3ea1d98c1a") },
                    { new Guid("36c4a063-b471-4e10-bb88-3958cea4cb01"), "Actor 28, Actress 28", new DateTime(2023, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 28.", "Director 28", "Film 28 (English)", "Action", "English", "Film 28", "USA", "https://example.com/poster28.jpg", 4, 2023, 88, new Guid("7042460b-94fb-465f-a850-18e034ea89d5"), new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer28.mp4", new Guid("dd67ec4c-0e80-4e17-9b3d-f1b1db0ff885") },
                    { new Guid("38a3facd-a8cc-419c-9378-eec39a9148b5"), "Actor 7, Actress 7", new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 7.", "Director 7", "Film 7 (English)", "Comedy", "Japanese", "Film 7", "Japan", "https://example.com/poster7.jpg", 3, 2023, 67, new Guid("e75850d9-8409-4e06-9186-0f085ea1c9e9"), new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer7.mp4", new Guid("c609c0ce-03d7-4a8c-b09a-0e8db0b674b0") },
                    { new Guid("3da7c6ce-aae1-478c-b4ec-ae603199f46c"), "Actor 30, Actress 30", new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 30.", "Director 30", "Film 30 (English)", "Action", "English", "Film 30", "USA", "https://example.com/poster30.jpg", 1, 2023, 90, new Guid("5a211bcc-e15a-42fe-805b-f701e814de75"), new DateTime(2023, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer30.mp4", new Guid("6c12c1f9-a680-467c-ae36-ad10fb77fbc0") },
                    { new Guid("460e8859-52f6-4321-b21a-e89a6ab9e9aa"), "Actor 29, Actress 29", new DateTime(2023, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 29.", "Director 29", "Film 29 (English)", "Comedy", "Japanese", "Film 29", "Japan", "https://example.com/poster29.jpg", 5, 2023, 89, new Guid("ea560472-c7ec-452b-91ff-ab5d719f0377"), new DateTime(2023, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer29.mp4", new Guid("2d18ec28-89af-4983-9d18-78497a7af841") },
                    { new Guid("4d2272b4-d10b-4f71-92f2-eda815343e40"), "Actor 20, Actress 20", new DateTime(2023, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 20.", "Director 20", "Film 20 (English)", "Action", "English", "Film 20", "USA", "https://example.com/poster20.jpg", 1, 2023, 80, new Guid("f1129432-dc84-4d7d-bebe-f9848d65c4b1"), new DateTime(2023, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer20.mp4", new Guid("ca6e8b54-8bf9-40cb-a692-3fa03d269553") },
                    { new Guid("60bd8a24-719d-4fa5-97d2-d4718d511025"), "Actor 21, Actress 21", new DateTime(2023, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 21.", "Director 21", "Film 21 (English)", "Comedy", "Japanese", "Film 21", "Japan", "https://example.com/poster21.jpg", 2, 2023, 81, new Guid("cf9e6729-6bdc-472a-b694-4d48aea69307"), new DateTime(2023, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer21.mp4", new Guid("23717ec5-2a2a-49f8-9a36-56e8ee3c531d") },
                    { new Guid("664538e2-3d0e-4398-9168-4d3ba307e6bb"), "Actor 14, Actress 14", new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 14.", "Director 14", "Film 14 (English)", "Action", "English", "Film 14", "USA", "https://example.com/poster14.jpg", 5, 2023, 74, new Guid("e2f48ada-425a-4f43-af59-e9124f122871"), new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer14.mp4", new Guid("c0976758-a1f5-4f2d-bf9c-27c17e80ae4c") },
                    { new Guid("80223920-e5d8-4727-95db-292cd71076a4"), "Actor 4, Actress 4", new DateTime(2023, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 4.", "Director 4", "Film 4 (English)", "Action", "English", "Film 4", "USA", "https://example.com/poster4.jpg", 5, 2023, 64, new Guid("f83301c4-19d3-482c-989b-8bf43e568b52"), new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer4.mp4", new Guid("b482364d-c98a-4a99-aa07-98f8fc069410") },
                    { new Guid("8298ce4c-c9c7-4812-ac9b-f0e91967ec04"), "Actor 6, Actress 6", new DateTime(2023, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 6.", "Director 6", "Film 6 (English)", "Action", "English", "Film 6", "USA", "https://example.com/poster6.jpg", 2, 2023, 66, new Guid("9d81b562-e988-48f5-850d-f1477cf09795"), new DateTime(2023, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer6.mp4", new Guid("f286546a-ae5f-4a03-add6-13dbdf905b15") },
                    { new Guid("88ccdbbf-84e2-494a-800c-f6f52c735416"), "Actor 3, Actress 3", new DateTime(2023, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 3.", "Director 3", "Film 3 (English)", "Comedy", "Japanese", "Film 3", "Japan", "https://example.com/poster3.jpg", 4, 2023, 63, new Guid("a1dc9769-507c-415f-b8be-8c0c52b5013a"), new DateTime(2023, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer3.mp4", new Guid("54155d0e-937b-45bf-a590-5850bb48712f") },
                    { new Guid("93377cfa-5b29-4843-ab2f-925af57365f5"), "Actor 16, Actress 16", new DateTime(2023, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 16.", "Director 16", "Film 16 (English)", "Action", "English", "Film 16", "USA", "https://example.com/poster16.jpg", 2, 2023, 76, new Guid("a7d2347d-a732-4381-ae2e-b47b8f5366e5"), new DateTime(2023, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer16.mp4", new Guid("820fa484-90f1-4eb9-ad68-70b1c28b4e9c") },
                    { new Guid("9b78a90e-a4d0-48b1-b83a-96b989a5310e"), "Actor 23, Actress 23", new DateTime(2023, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 23.", "Director 23", "Film 23 (English)", "Comedy", "Japanese", "Film 23", "Japan", "https://example.com/poster23.jpg", 4, 2023, 83, new Guid("44de24cd-3ce2-4aa4-abd0-22fd9be99391"), new DateTime(2023, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer23.mp4", new Guid("f603b82d-04cc-4087-bc67-50fd6a4bee6b") },
                    { new Guid("a1fa75b6-60cb-40bc-a635-0d219d4f7955"), "Actor 2, Actress 2", new DateTime(2023, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 2.", "Director 2", "Film 2 (English)", "Action", "English", "Film 2", "USA", "https://example.com/poster2.jpg", 3, 2023, 62, new Guid("be9a0a2b-caa1-4f0d-853f-d78a9ebe82c8"), new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer2.mp4", new Guid("1ebe7221-2a3b-4134-8f8f-46a0c2533cfc") },
                    { new Guid("a6e5ff4a-db3c-44d7-9dfd-236ff1ead092"), "Actor 1, Actress 1", new DateTime(2023, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 1.", "Director 1", "Film 1 (English)", "Comedy", "Japanese", "Film 1", "Japan", "https://example.com/poster1.jpg", 2, 2023, 61, new Guid("a770169b-5ebb-4a84-9ca1-b1e7b6fd514f"), new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer1.mp4", new Guid("a1808886-516c-47e3-a1e1-74a8b43c5ff8") },
                    { new Guid("b1fb585f-4b7e-49d3-b8e7-f3b8d0dd577b"), "Actor 22, Actress 22", new DateTime(2023, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 22.", "Director 22", "Film 22 (English)", "Action", "English", "Film 22", "USA", "https://example.com/poster22.jpg", 3, 2023, 82, new Guid("2028c08a-deb7-43ab-b691-7d27f4fdba47"), new DateTime(2023, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer22.mp4", new Guid("a8d4c706-b0d6-4e9d-b671-388ad6cfbfe9") },
                    { new Guid("b8850abb-2138-4c9d-949b-08538873d2fb"), "Actor 5, Actress 5", new DateTime(2023, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 5.", "Director 5", "Film 5 (English)", "Comedy", "Japanese", "Film 5", "Japan", "https://example.com/poster5.jpg", 1, 2023, 65, new Guid("1f4cc4c2-4edd-4d75-b93f-82b6927d34a8"), new DateTime(2023, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer5.mp4", new Guid("14a56f66-7468-4418-a8fe-ea417dc28b52") },
                    { new Guid("bfe0afe3-9623-43ce-8242-10b8d64c73df"), "Actor 27, Actress 27", new DateTime(2023, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 27.", "Director 27", "Film 27 (English)", "Comedy", "Japanese", "Film 27", "Japan", "https://example.com/poster27.jpg", 3, 2023, 87, new Guid("3843c6b5-43b6-451f-82c4-1ebe8988ad54"), new DateTime(2023, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer27.mp4", new Guid("d411ba2a-c176-46f7-8c07-123019968b57") },
                    { new Guid("cb181e00-06d8-4643-9f83-b01faedf4df8"), "Actor 12, Actress 12", new DateTime(2023, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 12.", "Director 12", "Film 12 (English)", "Action", "English", "Film 12", "USA", "https://example.com/poster12.jpg", 3, 2023, 72, new Guid("f8d05ec5-b59d-4405-90a0-d7995c2a55c9"), new DateTime(2023, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer12.mp4", new Guid("68e6e657-582f-4334-9913-6cafd4f3fd79") },
                    { new Guid("daa83ab8-8524-4f48-a08a-5c6e53a0d486"), "Actor 9, Actress 9", new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 9.", "Director 9", "Film 9 (English)", "Comedy", "Japanese", "Film 9", "Japan", "https://example.com/poster9.jpg", 5, 2023, 69, new Guid("d14bc4bc-1449-4bf2-a456-74715587eb5b"), new DateTime(2023, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer9.mp4", new Guid("a25b6b17-bea9-4d16-beff-aac401f50c32") },
                    { new Guid("dfa93714-e79b-4aec-9a25-5b2374c839dd"), "Actor 19, Actress 19", new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 19.", "Director 19", "Film 19 (English)", "Comedy", "Japanese", "Film 19", "Japan", "https://example.com/poster19.jpg", 5, 2023, 79, new Guid("275089c0-43f1-430a-ab5e-c51d47be8454"), new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer19.mp4", new Guid("426484ec-7665-47ae-9386-826c2b00802b") },
                    { new Guid("e8942801-ff6f-4a87-8ad2-904d5a5bb3f3"), "Actor 15, Actress 15", new DateTime(2023, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 15.", "Director 15", "Film 15 (English)", "Comedy", "Japanese", "Film 15", "Japan", "https://example.com/poster15.jpg", 1, 2023, 75, new Guid("1f85abcd-019f-43b7-81a0-395594336a36"), new DateTime(2023, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer15.mp4", new Guid("5deec792-f43b-4082-aa8e-eb5e4874cd94") },
                    { new Guid("ec6aafa6-3fbc-4d8d-852f-efafff0f7f80"), "Actor 17, Actress 17", new DateTime(2023, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 17.", "Director 17", "Film 17 (English)", "Comedy", "Japanese", "Film 17", "Japan", "https://example.com/poster17.jpg", 3, 2023, 77, new Guid("9d4f47aa-0819-42c3-a995-43e470c6e509"), new DateTime(2023, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer17.mp4", new Guid("918ae79b-10c9-4f07-960b-9f1030473418") },
                    { new Guid("ed70a5c0-72f2-43f6-87ab-28f11a8df453"), "Actor 26, Actress 26", new DateTime(2023, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 26.", "Director 26", "Film 26 (English)", "Action", "English", "Film 26", "USA", "https://example.com/poster26.jpg", 2, 2023, 86, new Guid("63bd5dda-d03b-45ba-aa33-28c1dbcee04c"), new DateTime(2023, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer26.mp4", new Guid("b776faf5-3962-4c15-964a-8f0d1827b573") },
                    { new Guid("f014141e-22d0-4c3b-8192-27fdfc4f37d6"), "Actor 13, Actress 13", new DateTime(2023, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 13.", "Director 13", "Film 13 (English)", "Comedy", "Japanese", "Film 13", "Japan", "https://example.com/poster13.jpg", 4, 2023, 73, new Guid("b5421d41-9951-48ff-8946-2b33bf5f506c"), new DateTime(2023, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer13.mp4", new Guid("72482c79-098c-4696-9b81-5d9e422c4f38") },
                    { new Guid("fc0b5348-e58a-49b1-bece-1d838af8cdca"), "Actor 18, Actress 18", new DateTime(2023, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 18.", "Director 18", "Film 18 (English)", "Action", "English", "Film 18", "USA", "https://example.com/poster18.jpg", 4, 2023, 78, new Guid("b2223bf7-c6ea-4806-91e4-08f09be5575e"), new DateTime(2023, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer18.mp4", new Guid("e7865e5f-e9de-480c-b0cf-bdb4d6a724fd") }
                });

            migrationBuilder.InsertData(
                table: "Promotions",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("0dfd7d85-8446-49aa-bb5c-011859858b73"), "Title 7" },
                    { new Guid("1889994a-d271-488a-816f-b95a37bd97f3"), "Title 5" },
                    { new Guid("1977337d-6568-437c-890e-461e6ced5653"), "Title 8" },
                    { new Guid("19f6cc17-6627-4ff6-9639-d9234f0cd254"), "Title 16" },
                    { new Guid("21e13aa9-b74a-4dcb-9b03-3271ff143e73"), "Title 9" },
                    { new Guid("28b7f061-1436-4dfb-839f-f331fd74469d"), "Title 27" },
                    { new Guid("3b98b136-0fc7-41ed-92b4-9d1bbf31b8ec"), "Title 25" },
                    { new Guid("43e71d72-4c16-487b-b902-def791328f1f"), "Title 6" },
                    { new Guid("43ea535c-d359-4d32-958a-1dc37f5f9ab3"), "Title 18" },
                    { new Guid("536f6a22-2dd0-4a5d-a611-ff1f62ca9c0d"), "Title 28" },
                    { new Guid("5382031d-7e4c-4dc1-87cc-f5f15d52831d"), "Title 11" },
                    { new Guid("542bf937-5f74-452e-908b-268ea6b17526"), "Title 1" },
                    { new Guid("572f2f3f-25dd-4464-aac7-58b3fe63eb1b"), "Title 13" },
                    { new Guid("5d000c42-3e32-4549-ba37-b4448b05eaf4"), "Title 20" },
                    { new Guid("75f7707d-76f0-417a-948d-2a359efba11d"), "Title 3" },
                    { new Guid("9098c2fc-aa14-478a-b63e-e4d5a3febafc"), "Title 19" },
                    { new Guid("b441bf56-4476-4330-8ab6-adb4eeca1116"), "Title 12" },
                    { new Guid("b477b5ca-afe2-4593-a7cf-b05a5befb892"), "Title 30" },
                    { new Guid("b7f60b6e-3037-471b-b016-45f591cbaecb"), "Title 15" },
                    { new Guid("bbd4682f-7fe6-4872-aebb-b46dcafec32f"), "Title 26" },
                    { new Guid("be654df6-e3e9-4771-b3b2-d55170da8ddf"), "Title 14" },
                    { new Guid("c08e7861-4f1e-48f8-90a2-d646e387cfd1"), "Title 17" },
                    { new Guid("d44d5d6e-76df-4556-9fda-d32494cf943e"), "Title 4" },
                    { new Guid("d635dd5a-ec53-4ef0-ae48-c5b59cae4f90"), "Title 2" },
                    { new Guid("de6a492a-3f7f-46df-8d52-481f2fca4096"), "Title 22" },
                    { new Guid("e05e774a-6d5d-4781-868c-0a72fb4fc6b8"), "Title 24" },
                    { new Guid("e80d0b6b-8cc0-49cb-a58e-58b69c5e200f"), "Title 23" },
                    { new Guid("e8aece0a-a05a-4f2e-b7ec-7c3a8c1c6db6"), "Title 21" },
                    { new Guid("ef515c3f-cd52-4b4a-9a5a-a11c025e16a6"), "Title 10" },
                    { new Guid("ff10cca6-0092-48c9-8c8c-5e91b7765dad"), "Title 29" }
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
                    { new Guid("0282c3df-d072-46d6-99b2-f8a9ba2118d1"), new Guid("70fe1c28-e815-4132-84cc-78aeca3a32e8"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 10, "Description for Cinema 18", 100, "Cinema 18", 10 },
                    { new Guid("1cfdd267-3233-4544-8388-398b402c54f4"), new Guid("64037f78-6880-496e-b377-ec75207cfaf0"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 10, "Description for Cinema 15", 100, "Cinema 15", 10 },
                    { new Guid("20a962d1-2167-4409-9298-da06ef3e2f20"), new Guid("40ce4cd7-abb3-4f6c-a583-b351806cfa5f"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 10, "Description for Cinema 1", 100, "Cinema 1", 10 },
                    { new Guid("42deb021-d10d-4b4e-91eb-7ce6c667c756"), new Guid("6c2ce430-9318-4718-9397-8271f2ef235f"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 10, "Description for Cinema 4", 100, "Cinema 4", 10 },
                    { new Guid("46db8741-7dfc-4ed2-b6e6-b199387c9c44"), new Guid("5e0934d8-e2c9-4e7a-912a-40d526ebc4e1"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 10, "Description for Cinema 9", 100, "Cinema 9", 10 },
                    { new Guid("4755829f-a143-4cd7-9e41-0c1ecabad797"), new Guid("d8c4fa8f-07bc-4be7-a77d-a91bd7350775"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 10, "Description for Cinema 17", 100, "Cinema 17", 10 },
                    { new Guid("4c94a5a7-4bfb-4ef7-8126-57efacdfd734"), new Guid("7f3b8ea5-b7be-4bb1-a724-26052329c451"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 10, "Description for Cinema 12", 100, "Cinema 12", 10 },
                    { new Guid("4d7348e2-4bfc-4ba9-96cd-5b68d226fdd1"), new Guid("f04d9768-c223-4a95-89f8-4e145e454e17"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 10, "Description for Cinema 2", 100, "Cinema 2", 10 },
                    { new Guid("517ce199-9b75-47b8-ba68-3e53cc325ee0"), new Guid("8c215391-f10e-400d-951b-47fe6a44c8d7"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 10, "Description for Cinema 16", 100, "Cinema 16", 10 },
                    { new Guid("51bf752c-88a2-4dea-8f0b-17b7d24b9b6a"), new Guid("b95a8bc6-4f33-4e7a-9a43-de3a05a25636"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 10, "Description for Cinema 6", 100, "Cinema 6", 10 },
                    { new Guid("6b65c8da-aeb0-4484-81e8-7603434fbd27"), new Guid("f04d9768-c223-4a95-89f8-4e145e454e17"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 10, "Description for Cinema 21", 100, "Cinema 21", 10 },
                    { new Guid("6dc99a7d-1b33-4c84-996f-6da2d341f75d"), new Guid("b4a73848-0660-4a06-8670-5fcfa52e7f3e"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 10, "Description for Cinema 23", 100, "Cinema 23", 10 },
                    { new Guid("79955743-0125-4208-9246-e5504876fa66"), new Guid("a79736bd-5167-4d63-bc8d-95ead276d6a9"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 10, "Description for Cinema 27", 100, "Cinema 27", 10 },
                    { new Guid("7a3a5569-e31e-4724-af45-6f67e2685fba"), new Guid("5702e262-c3a1-490d-a1bf-5a2b90fa8213"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 10, "Description for Cinema 26", 100, "Cinema 26", 10 },
                    { new Guid("7bd2df98-d138-434e-bb41-9711cf431cf4"), new Guid("b4a73848-0660-4a06-8670-5fcfa52e7f3e"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 10, "Description for Cinema 7", 100, "Cinema 7", 10 },
                    { new Guid("89197cad-54c1-4dfe-9f92-d739ba8a8e85"), new Guid("b4a73848-0660-4a06-8670-5fcfa52e7f3e"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 10, "Description for Cinema 28", 100, "Cinema 28", 10 },
                    { new Guid("95b6e31b-d363-435c-87b1-e187251734e7"), new Guid("4937f1fa-79c3-4f76-bb58-fc37fe6c2df3"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 10, "Description for Cinema 22", 100, "Cinema 22", 10 },
                    { new Guid("98cff797-972a-457c-857f-c6e2dfe63310"), new Guid("506611d2-8578-4d50-aaaf-4ef78c64b42b"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 10, "Description for Cinema 24", 100, "Cinema 24", 10 },
                    { new Guid("9cdb44e7-11d7-4d5d-adf3-a9df5a939479"), new Guid("4937f1fa-79c3-4f76-bb58-fc37fe6c2df3"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 10, "Description for Cinema 13", 100, "Cinema 13", 10 },
                    { new Guid("9dddbc7c-6e1f-4180-9348-57cd3ec8b439"), new Guid("5e0934d8-e2c9-4e7a-912a-40d526ebc4e1"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 10, "Description for Cinema 3", 100, "Cinema 3", 10 },
                    { new Guid("a3a3a770-3227-4127-b95b-1ada6c661f18"), new Guid("a101a88c-ef71-4889-ba05-724e6d6a0231"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 10, "Description for Cinema 30", 100, "Cinema 30", 10 },
                    { new Guid("a6f59986-587f-4d8d-b09a-f96620ac33b3"), new Guid("778f70d8-2cdb-4233-8b06-e7080c32f7fe"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 10, "Description for Cinema 25", 100, "Cinema 25", 10 },
                    { new Guid("a91b257e-c9f4-4851-b5f4-781cc449ebf3"), new Guid("f04d9768-c223-4a95-89f8-4e145e454e17"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 10, "Description for Cinema 8", 100, "Cinema 8", 10 },
                    { new Guid("bb8bc45a-10cb-456f-a804-3d0487cb2391"), new Guid("70fe1c28-e815-4132-84cc-78aeca3a32e8"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 10, "Description for Cinema 11", 100, "Cinema 11", 10 },
                    { new Guid("bf3138ad-289f-4bc9-af62-bd5e552c5022"), new Guid("0e75aa19-af1e-493f-9b63-838542826cd7"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 10, "Description for Cinema 14", 100, "Cinema 14", 10 },
                    { new Guid("c3967686-8ace-4d95-a03a-ee93d967e48f"), new Guid("7ceab03c-ab44-4852-864d-248b84829da2"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 10, "Description for Cinema 5", 100, "Cinema 5", 10 },
                    { new Guid("d2070f08-2875-4fe8-8fdc-1c729708e9e3"), new Guid("a36b428c-de76-4ebd-87c3-587f0b41e870"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 10, "Description for Cinema 29", 100, "Cinema 29", 10 },
                    { new Guid("e1f8fb77-8ed1-4d0d-a940-b9fe65672d58"), new Guid("837929a9-2991-4382-aac2-3341f37296c2"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 10, "Description for Cinema 19", 100, "Cinema 19", 10 },
                    { new Guid("e7c37349-42d0-46d5-8bb9-89ee43696a26"), new Guid("7f3b8ea5-b7be-4bb1-a724-26052329c451"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 10, "Description for Cinema 20", 100, "Cinema 20", 10 },
                    { new Guid("ffc43d8b-5a8c-4d3f-abef-da62d16cd7fb"), new Guid("5297311c-444b-44a1-8d5d-a479c698a486"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 10, "Description for Cinema 10", 100, "Cinema 10", 10 }
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
                    { new Guid("016ac530-5795-4ab0-b221-5aee086ada35"), new DateTime(2023, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("60bd8a24-719d-4fa5-97d2-d4718d511025"), new DateTime(2023, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { new Guid("02c94b8a-f098-46f2-9d00-cd2ffa7565b5"), new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("460e8859-52f6-4321-b21a-e89a6ab9e9aa"), new DateTime(2023, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { new Guid("102f290c-c6b3-4956-a3c1-74f392a92446"), new DateTime(2023, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b8850abb-2138-4c9d-949b-08538873d2fb"), new DateTime(2023, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { new Guid("15e02943-e246-4f2c-a277-5c6b4aa3a9d2"), new DateTime(2023, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2e44b946-809f-48ab-8535-966bfa2c9e2b"), new DateTime(2023, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { new Guid("1673c9c9-edc6-49cd-8791-0b93fffe6f9d"), new DateTime(2023, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2728118a-0bb7-40e4-955b-d143717160a3"), new DateTime(2023, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { new Guid("1fa4b87f-6ae8-4687-b9c2-39dc923d2954"), new DateTime(2023, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("38a3facd-a8cc-419c-9378-eec39a9148b5"), new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { new Guid("22a77324-a06e-491f-987d-7256af424b30"), new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("30cdff19-6aca-4209-a058-22c55945efb1"), new DateTime(2023, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { new Guid("22a9d74f-f4cf-4224-8d7f-c11a68686a3f"), new DateTime(2023, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bfe0afe3-9623-43ce-8242-10b8d64c73df"), new DateTime(2023, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { new Guid("24042c2a-7033-4f3d-bb7d-0bd5782b6f15"), new DateTime(2023, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("daa83ab8-8524-4f48-a08a-5c6e53a0d486"), new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { new Guid("2531b914-ef3f-4c4d-bfc0-76a4bff87b49"), new DateTime(2023, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("9b78a90e-a4d0-48b1-b83a-96b989a5310e"), new DateTime(2023, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { new Guid("2596413b-dce8-456e-b474-a010e2d53c7a"), new DateTime(2023, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("93377cfa-5b29-4843-ab2f-925af57365f5"), new DateTime(2023, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { new Guid("2a9e34e5-dafa-4957-9cf7-4e755fc51c03"), new DateTime(2023, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a1fa75b6-60cb-40bc-a635-0d219d4f7955"), new DateTime(2023, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { new Guid("2e78e6e1-bdd3-4740-94c3-d3889b32985d"), new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc0b5348-e58a-49b1-bece-1d838af8cdca"), new DateTime(2023, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { new Guid("3d335299-1788-4eef-866c-63a96472ed61"), new DateTime(2023, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4d2272b4-d10b-4f71-92f2-eda815343e40"), new DateTime(2023, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { new Guid("656ad897-6252-44df-aa3a-2b04a786ac58"), new DateTime(2023, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a6e5ff4a-db3c-44d7-9dfd-236ff1ead092"), new DateTime(2023, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { new Guid("78df30c8-75c5-4c60-b23c-87def3c8998b"), new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f014141e-22d0-4c3b-8192-27fdfc4f37d6"), new DateTime(2023, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { new Guid("7b55f9bf-d7c5-4d1f-a66b-77e69f4707c2"), new DateTime(2023, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ed70a5c0-72f2-43f6-87ab-28f11a8df453"), new DateTime(2023, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { new Guid("7e52f7e5-d78d-4c89-a342-ad4e274b084f"), new DateTime(2023, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b1fb585f-4b7e-49d3-b8e7-f3b8d0dd577b"), new DateTime(2023, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { new Guid("865751a3-9274-41dd-91bb-829df6e79928"), new DateTime(2023, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("cb181e00-06d8-4643-9f83-b01faedf4df8"), new DateTime(2023, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { new Guid("89d428eb-8b72-4c3e-8f58-2bb4b267b75d"), new DateTime(2023, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("88ccdbbf-84e2-494a-800c-f6f52c735416"), new DateTime(2023, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { new Guid("8be94b0c-dd60-4abb-a509-339939d70241"), new DateTime(2023, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("664538e2-3d0e-4398-9168-4d3ba307e6bb"), new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { new Guid("929b5c1d-b1a9-4566-8801-8b2fa4ddba3d"), new DateTime(2023, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("30909bea-5840-4df7-94b8-8b9096ffc78b"), new DateTime(2023, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { new Guid("a2f0ec48-f0d8-4a30-9920-ef06eaa8cd2b"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3da7c6ce-aae1-478c-b4ec-ae603199f46c"), new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { new Guid("b5a1565a-44ac-4e68-bf2a-53081c7909f7"), new DateTime(2023, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ec6aafa6-3fbc-4d8d-852f-efafff0f7f80"), new DateTime(2023, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { new Guid("b67d278d-5b08-4e0b-b270-5f51e5f261c0"), new DateTime(2023, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("80223920-e5d8-4727-95db-292cd71076a4"), new DateTime(2023, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { new Guid("d2be5ea7-33a7-492d-9933-9e69e5973a10"), new DateTime(2023, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e8942801-ff6f-4a87-8ad2-904d5a5bb3f3"), new DateTime(2023, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { new Guid("e062ff27-5d68-41d4-925f-fd918823a1cf"), new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8298ce4c-c9c7-4812-ac9b-f0e91967ec04"), new DateTime(2023, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { new Guid("f56b13a9-f364-4683-a873-f9b147b226de"), new DateTime(2023, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("012a9cea-1709-41c2-9319-fbd51c859529"), new DateTime(2023, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { new Guid("f9383468-950d-40ab-b6bc-287a3408f94b"), new DateTime(2023, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("dfa93714-e79b-4aec-9a25-5b2374c839dd"), new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { new Guid("ff4f2466-34ed-4102-a713-08678f273adc"), new DateTime(2023, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("36c4a063-b471-4e10-bb88-3958cea4cb01"), new DateTime(2023, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "TicketPrices",
                columns: new[] { "Id", "CinemaTypeId", "Price", "ScreenTypeId", "ScreeningDayId", "SeatTypeId", "Status" },
                values: new object[,]
                {
                    { new Guid("05a391bb-277c-4e6f-9071-1cf04d3abf06"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 0m, new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new Guid("e4f8f494-4e25-4966-806a-7b8843d79b6b"), new Guid("428edc6b-0862-4623-b038-ac505fd554bc"), 1 },
                    { new Guid("0cd9dd1b-e407-4338-a512-9f7d137edd91"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 60000m, new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("d997b27a-ddb7-4ad1-a1cd-c2bd00c50cb9"), 1 },
                    { new Guid("248d3faa-51f2-4e9a-9f33-6ac566ce7671"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 30000m, new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("428edc6b-0862-4623-b038-ac505fd554bc"), 1 },
                    { new Guid("329df677-77a7-4b30-a738-2585bb2895c3"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 0m, new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("d997b27a-ddb7-4ad1-a1cd-c2bd00c50cb9"), 1 },
                    { new Guid("36b6ba5a-de7e-4fbf-bf7d-cbc136118f32"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 20000m, new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("d997b27a-ddb7-4ad1-a1cd-c2bd00c50cb9"), 1 },
                    { new Guid("36de71fd-7b2e-4bfe-ac72-895875bfb975"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 60000m, new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new Guid("d51bee9b-54c3-4a3c-a06a-7c3940852f57"), new Guid("428edc6b-0862-4623-b038-ac505fd554bc"), 1 },
                    { new Guid("4078ef32-5239-40b7-bb01-365efa88c4de"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 80000m, new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new Guid("d51bee9b-54c3-4a3c-a06a-7c3940852f57"), new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("432afe66-5c1f-4a04-8d14-597f4db6ddef"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 0m, new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new Guid("e4f8f494-4e25-4966-806a-7b8843d79b6b"), new Guid("d997b27a-ddb7-4ad1-a1cd-c2bd00c50cb9"), 1 },
                    { new Guid("5acaa1e2-7032-4e13-aca9-b3dc9e59b584"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 90000m, new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("5e685e0c-c471-4c71-8b0e-5cc0ff8c8637"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 20000m, new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new Guid("d51bee9b-54c3-4a3c-a06a-7c3940852f57"), new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("6113d34b-165b-46b2-b399-921774d9607e"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 70000m, new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new Guid("d51bee9b-54c3-4a3c-a06a-7c3940852f57"), new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("71809485-bf9c-461e-8686-c28c1984a9a6"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 50000m, new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new Guid("d51bee9b-54c3-4a3c-a06a-7c3940852f57"), new Guid("428edc6b-0862-4623-b038-ac505fd554bc"), 1 },
                    { new Guid("72f8ef0f-b8b3-46c0-a6a1-ab9fe40568b0"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 50000m, new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new Guid("e4f8f494-4e25-4966-806a-7b8843d79b6b"), new Guid("d997b27a-ddb7-4ad1-a1cd-c2bd00c50cb9"), 1 },
                    { new Guid("7af886ae-5663-419e-8c87-fd3276d30bc1"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 60000m, new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new Guid("e4f8f494-4e25-4966-806a-7b8843d79b6b"), new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("8abb072e-7ce0-4851-80d0-c65ccec37713"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 40000m, new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new Guid("e4f8f494-4e25-4966-806a-7b8843d79b6b"), new Guid("428edc6b-0862-4623-b038-ac505fd554bc"), 1 },
                    { new Guid("8c3897bd-bc78-4494-b3c5-8667f8074e6e"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 30000m, new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("428edc6b-0862-4623-b038-ac505fd554bc"), 1 },
                    { new Guid("a0f2f899-dd58-4539-bb13-9bc988f2b909"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 50000m, new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new Guid("e4f8f494-4e25-4966-806a-7b8843d79b6b"), new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("a707ea6c-b6bc-4620-8cf3-be7b1b4dc6b0"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 20000m, new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new Guid("e4f8f494-4e25-4966-806a-7b8843d79b6b"), new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("a712c75e-b80d-4fb3-8ae3-8d9d404b01d9"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 70000m, new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("428edc6b-0862-4623-b038-ac505fd554bc"), 1 },
                    { new Guid("a8a96d96-e730-4042-99c9-bac86fa20aa4"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 10000m, new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new Guid("e4f8f494-4e25-4966-806a-7b8843d79b6b"), new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("ac93d644-bf27-4969-89b8-22853ae8f74c"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 10000m, new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("d997b27a-ddb7-4ad1-a1cd-c2bd00c50cb9"), 1 },
                    { new Guid("bc6a4928-2503-42b1-88c2-0e0e8ac8f4ee"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 80000m, new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("ca10a443-d62a-4461-9994-9986dd29d895"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 90000m, new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("ca41a84e-4c18-4a27-be36-518d19b72035"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 30000m, new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new Guid("e4f8f494-4e25-4966-806a-7b8843d79b6b"), new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("cc087d0d-91b0-45b2-822b-73bf27209e38"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 40000m, new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new Guid("d51bee9b-54c3-4a3c-a06a-7c3940852f57"), new Guid("d997b27a-ddb7-4ad1-a1cd-c2bd00c50cb9"), 1 },
                    { new Guid("dc51cb82-4a43-4221-bd8f-5f1af7f1557c"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 40000m, new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new Guid("d51bee9b-54c3-4a3c-a06a-7c3940852f57"), new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("e1726bf5-2e19-483e-b818-cb5910da5651"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 90000m, new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new Guid("e4f8f494-4e25-4966-806a-7b8843d79b6b"), new Guid("d997b27a-ddb7-4ad1-a1cd-c2bd00c50cb9"), 1 },
                    { new Guid("e7b5d907-4692-4832-aa08-d77eae19c907"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 80000m, new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("e8d12ca2-6818-40ab-833d-48f568f83406"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 10000m, new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new Guid("e4f8f494-4e25-4966-806a-7b8843d79b6b"), new Guid("d997b27a-ddb7-4ad1-a1cd-c2bd00c50cb9"), 1 },
                    { new Guid("f96d45df-7cab-45cf-b851-0cda25fa877a"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 70000m, new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("428edc6b-0862-4623-b038-ac505fd554bc"), 1 }
                });

            migrationBuilder.InsertData(
                table: "ShowTimes",
                columns: new[] { "Id", "CinemaCenterId", "CinemaId", "Desciption", "EndTime", "FilmId", "ScheduleId", "ScreenTypeId", "ShowtimeDate", "StartTime", "Status", "TranslationTypeId" },
                values: new object[,]
                {
                    { new Guid("114b3f20-a1e2-46dc-b5ff-4601caef1ecb"), new Guid("64037f78-6880-496e-b377-ec75207cfaf0"), new Guid("20a962d1-2167-4409-9298-da06ef3e2f20"), "Description for ShowTime 15", new DateTime(2023, 8, 16, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e8942801-ff6f-4a87-8ad2-904d5a5bb3f3"), new Guid("d2be5ea7-33a7-492d-9933-9e69e5973a10"), new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), null, new DateTime(2023, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("11d8cfb5-1372-4e83-a1c7-7f29e43224d4"), new Guid("837929a9-2991-4382-aac2-3341f37296c2"), new Guid("51bf752c-88a2-4dea-8f0b-17b7d24b9b6a"), "Description for ShowTime 21", new DateTime(2023, 8, 22, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("60bd8a24-719d-4fa5-97d2-d4718d511025"), new Guid("016ac530-5795-4ab0-b221-5aee086ada35"), new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), null, new DateTime(2023, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("14108bc9-8dd9-48c4-97b5-13a0c0257f95"), new Guid("e168f30c-a391-4949-9523-fee2408db37b"), new Guid("d2070f08-2875-4fe8-8fdc-1c729708e9e3"), "Description for ShowTime 19", new DateTime(2023, 8, 20, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("dfa93714-e79b-4aec-9a25-5b2374c839dd"), new Guid("f9383468-950d-40ab-b6bc-287a3408f94b"), new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), null, new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("25d5bdcf-60c8-4c0f-8116-566e35c86ec9"), new Guid("5702e262-c3a1-490d-a1bf-5a2b90fa8213"), new Guid("9cdb44e7-11d7-4d5d-adf3-a9df5a939479"), "Description for ShowTime 4", new DateTime(2023, 8, 5, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("80223920-e5d8-4727-95db-292cd71076a4"), new Guid("b67d278d-5b08-4e0b-b270-5f51e5f261c0"), new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), null, new DateTime(2023, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("2701b377-ea27-45f5-852b-3d8ae92f3c00"), new Guid("778f70d8-2cdb-4233-8b06-e7080c32f7fe"), new Guid("c3967686-8ace-4d95-a03a-ee93d967e48f"), "Description for ShowTime 5", new DateTime(2023, 8, 6, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b8850abb-2138-4c9d-949b-08538873d2fb"), new Guid("102f290c-c6b3-4956-a3c1-74f392a92446"), new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), null, new DateTime(2023, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("2db07cdb-f3f7-4dc4-b599-165d6c9d60d8"), new Guid("80106303-1458-4f27-a35d-c1f72ea3db1e"), new Guid("7a3a5569-e31e-4724-af45-6f67e2685fba"), "Description for ShowTime 8", new DateTime(2023, 8, 9, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("30cdff19-6aca-4209-a058-22c55945efb1"), new Guid("22a77324-a06e-491f-987d-7256af424b30"), new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), null, new DateTime(2023, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("337cb366-be99-44d3-9cbd-12e5579eecd1"), new Guid("0104bfac-0f55-43a4-9e6e-942d7b09712b"), new Guid("ffc43d8b-5a8c-4d3f-abef-da62d16cd7fb"), "Description for ShowTime 16", new DateTime(2023, 8, 17, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("93377cfa-5b29-4843-ab2f-925af57365f5"), new Guid("2596413b-dce8-456e-b474-a010e2d53c7a"), new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), null, new DateTime(2023, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("3f1ebca5-7145-430f-bf4c-af395102a84d"), new Guid("b7d43885-549f-4701-9cb3-cc37532e17f1"), new Guid("517ce199-9b75-47b8-ba68-3e53cc325ee0"), "Description for ShowTime 17", new DateTime(2023, 8, 18, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ec6aafa6-3fbc-4d8d-852f-efafff0f7f80"), new Guid("b5a1565a-44ac-4e68-bf2a-53081c7909f7"), new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), null, new DateTime(2023, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("4bbdf82b-1943-4a6e-9931-8254c1f20d53"), new Guid("7ceab03c-ab44-4852-864d-248b84829da2"), new Guid("e1f8fb77-8ed1-4d0d-a940-b9fe65672d58"), "Description for ShowTime 2", new DateTime(2023, 8, 3, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a1fa75b6-60cb-40bc-a635-0d219d4f7955"), new Guid("2a9e34e5-dafa-4957-9cf7-4e755fc51c03"), new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), null, new DateTime(2023, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("54dc80e5-a640-4a52-b2f0-0ef76cb98a14"), new Guid("64037f78-6880-496e-b377-ec75207cfaf0"), new Guid("7a3a5569-e31e-4724-af45-6f67e2685fba"), "Description for ShowTime 10", new DateTime(2023, 8, 11, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2728118a-0bb7-40e4-955b-d143717160a3"), new Guid("1673c9c9-edc6-49cd-8791-0b93fffe6f9d"), new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), null, new DateTime(2023, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("5b6fe1b0-32d8-4c76-bf6e-aa168bf1c1fd"), new Guid("c4ec6444-c437-4b38-ae3b-4371469c11be"), new Guid("4d7348e2-4bfc-4ba9-96cd-5b68d226fdd1"), "Description for ShowTime 29", new DateTime(2023, 8, 30, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("460e8859-52f6-4321-b21a-e89a6ab9e9aa"), new Guid("02c94b8a-f098-46f2-9d00-cd2ffa7565b5"), new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), null, new DateTime(2023, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("5bb568f1-1028-4fb6-9257-15df7159f87f"), new Guid("6c2ce430-9318-4718-9397-8271f2ef235f"), new Guid("79955743-0125-4208-9246-e5504876fa66"), "Description for ShowTime 30", new DateTime(2023, 8, 31, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3da7c6ce-aae1-478c-b4ec-ae603199f46c"), new Guid("a2f0ec48-f0d8-4a30-9920-ef06eaa8cd2b"), new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), null, new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("63159cea-f1ff-40c6-ace1-09bbf4c2dd0d"), new Guid("b4a73848-0660-4a06-8670-5fcfa52e7f3e"), new Guid("42deb021-d10d-4b4e-91eb-7ce6c667c756"), "Description for ShowTime 12", new DateTime(2023, 8, 13, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("cb181e00-06d8-4643-9f83-b01faedf4df8"), new Guid("865751a3-9274-41dd-91bb-829df6e79928"), new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), null, new DateTime(2023, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("758c1fe0-23a9-4ca9-9b6c-a4fcf1d83ea9"), new Guid("5297311c-444b-44a1-8d5d-a479c698a486"), new Guid("7bd2df98-d138-434e-bb41-9711cf431cf4"), "Description for ShowTime 9", new DateTime(2023, 8, 10, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("daa83ab8-8524-4f48-a08a-5c6e53a0d486"), new Guid("24042c2a-7033-4f3d-bb7d-0bd5782b6f15"), new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), null, new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("7b239fee-20e2-4fbb-92b7-0e0859a3a18e"), new Guid("c4ec6444-c437-4b38-ae3b-4371469c11be"), new Guid("a3a3a770-3227-4127-b95b-1ada6c661f18"), "Description for ShowTime 13", new DateTime(2023, 8, 14, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f014141e-22d0-4c3b-8192-27fdfc4f37d6"), new Guid("78df30c8-75c5-4c60-b23c-87def3c8998b"), new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), null, new DateTime(2023, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("7b6c80de-afd9-489b-8a4e-da6ec5f3bbab"), new Guid("f04d9768-c223-4a95-89f8-4e145e454e17"), new Guid("98cff797-972a-457c-857f-c6e2dfe63310"), "Description for ShowTime 11", new DateTime(2023, 8, 12, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2e44b946-809f-48ab-8535-966bfa2c9e2b"), new Guid("15e02943-e246-4f2c-a277-5c6b4aa3a9d2"), new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), null, new DateTime(2023, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("9e3b25c6-fa75-472f-8bdd-550c848f318b"), new Guid("0e75aa19-af1e-493f-9b63-838542826cd7"), new Guid("42deb021-d10d-4b4e-91eb-7ce6c667c756"), "Description for ShowTime 6", new DateTime(2023, 8, 7, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8298ce4c-c9c7-4812-ac9b-f0e91967ec04"), new Guid("e062ff27-5d68-41d4-925f-fd918823a1cf"), new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), null, new DateTime(2023, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("9f0c51ec-ddf0-4fac-970e-e3393bbd87a3"), new Guid("a79736bd-5167-4d63-bc8d-95ead276d6a9"), new Guid("20a962d1-2167-4409-9298-da06ef3e2f20"), "Description for ShowTime 23", new DateTime(2023, 8, 24, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("9b78a90e-a4d0-48b1-b83a-96b989a5310e"), new Guid("2531b914-ef3f-4c4d-bfc0-76a4bff87b49"), new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), null, new DateTime(2023, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("9fe84772-86dd-4d46-918e-87fa201b9138"), new Guid("b95a8bc6-4f33-4e7a-9a43-de3a05a25636"), new Guid("4c94a5a7-4bfb-4ef7-8126-57efacdfd734"), "Description for ShowTime 26", new DateTime(2023, 8, 27, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ed70a5c0-72f2-43f6-87ab-28f11a8df453"), new Guid("7b55f9bf-d7c5-4d1f-a66b-77e69f4707c2"), new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), null, new DateTime(2023, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("ab1045eb-ce87-43ed-8244-989908847a6c"), new Guid("64037f78-6880-496e-b377-ec75207cfaf0"), new Guid("98cff797-972a-457c-857f-c6e2dfe63310"), "Description for ShowTime 22", new DateTime(2023, 8, 23, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b1fb585f-4b7e-49d3-b8e7-f3b8d0dd577b"), new Guid("7e52f7e5-d78d-4c89-a342-ad4e274b084f"), new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), null, new DateTime(2023, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("b0fe05f4-bafb-4b6b-bd07-2ebacf295bee"), new Guid("64037f78-6880-496e-b377-ec75207cfaf0"), new Guid("95b6e31b-d363-435c-87b1-e187251734e7"), "Description for ShowTime 7", new DateTime(2023, 8, 8, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("38a3facd-a8cc-419c-9378-eec39a9148b5"), new Guid("1fa4b87f-6ae8-4687-b9c2-39dc923d2954"), new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), null, new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("b25c4673-f917-47c2-9b41-c72e3adc3984"), new Guid("4937f1fa-79c3-4f76-bb58-fc37fe6c2df3"), new Guid("e1f8fb77-8ed1-4d0d-a940-b9fe65672d58"), "Description for ShowTime 20", new DateTime(2023, 8, 21, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4d2272b4-d10b-4f71-92f2-eda815343e40"), new Guid("3d335299-1788-4eef-866c-63a96472ed61"), new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), null, new DateTime(2023, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("b69e4c0c-9707-4ae6-9486-c3ebef0ae21a"), new Guid("a36b428c-de76-4ebd-87c3-587f0b41e870"), new Guid("7a3a5569-e31e-4724-af45-6f67e2685fba"), "Description for ShowTime 3", new DateTime(2023, 8, 4, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("88ccdbbf-84e2-494a-800c-f6f52c735416"), new Guid("89d428eb-8b72-4c3e-8f58-2bb4b267b75d"), new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), null, new DateTime(2023, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("ca051c9d-6a89-42ba-b7f2-64591c44e26c"), new Guid("a101a88c-ef71-4889-ba05-724e6d6a0231"), new Guid("a3a3a770-3227-4127-b95b-1ada6c661f18"), "Description for ShowTime 28", new DateTime(2023, 8, 29, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("36c4a063-b471-4e10-bb88-3958cea4cb01"), new Guid("ff4f2466-34ed-4102-a713-08678f273adc"), new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), null, new DateTime(2023, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("d207327c-adb4-48ad-b1af-c9135c69b3d3"), new Guid("a101a88c-ef71-4889-ba05-724e6d6a0231"), new Guid("4c94a5a7-4bfb-4ef7-8126-57efacdfd734"), "Description for ShowTime 14", new DateTime(2023, 8, 15, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("664538e2-3d0e-4398-9168-4d3ba307e6bb"), new Guid("8be94b0c-dd60-4abb-a509-339939d70241"), new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), null, new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("d231db6b-09bc-4c5d-a1db-338eb866329b"), new Guid("e168f30c-a391-4949-9523-fee2408db37b"), new Guid("a91b257e-c9f4-4851-b5f4-781cc449ebf3"), "Description for ShowTime 24", new DateTime(2023, 8, 25, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("30909bea-5840-4df7-94b8-8b9096ffc78b"), new Guid("929b5c1d-b1a9-4566-8801-8b2fa4ddba3d"), new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), null, new DateTime(2023, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("dc058a63-96f6-46aa-a183-e1996af1598d"), new Guid("0e75aa19-af1e-493f-9b63-838542826cd7"), new Guid("6b65c8da-aeb0-4484-81e8-7603434fbd27"), "Description for ShowTime 27", new DateTime(2023, 8, 28, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bfe0afe3-9623-43ce-8242-10b8d64c73df"), new Guid("22a9d74f-f4cf-4224-8d7f-c11a68686a3f"), new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), null, new DateTime(2023, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("e0266032-acd3-49fd-b804-cbda52645b0a"), new Guid("c9c8d3d6-45ad-4fc5-bdc0-67ba3a9ccbc5"), new Guid("e1f8fb77-8ed1-4d0d-a940-b9fe65672d58"), "Description for ShowTime 25", new DateTime(2023, 8, 26, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("012a9cea-1709-41c2-9319-fbd51c859529"), new Guid("f56b13a9-f364-4683-a873-f9b147b226de"), new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), null, new DateTime(2023, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("e0c413fd-2c82-47ed-925f-ea58a00180c5"), new Guid("c9c8d3d6-45ad-4fc5-bdc0-67ba3a9ccbc5"), new Guid("517ce199-9b75-47b8-ba68-3e53cc325ee0"), "Description for ShowTime 1", new DateTime(2023, 8, 2, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a6e5ff4a-db3c-44d7-9dfd-236ff1ead092"), new Guid("656ad897-6252-44df-aa3a-2b04a786ac58"), new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), null, new DateTime(2023, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("f51f1c0c-34bf-4024-99c2-6aabed727ff1"), new Guid("5e0934d8-e2c9-4e7a-912a-40d526ebc4e1"), new Guid("bf3138ad-289f-4bc9-af62-bd5e552c5022"), "Description for ShowTime 18", new DateTime(2023, 8, 19, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc0b5348-e58a-49b1-bece-1d838af8cdca"), new Guid("2e78e6e1-bdd3-4740-94c3-d3889b32985d"), new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), null, new DateTime(2023, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") }
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