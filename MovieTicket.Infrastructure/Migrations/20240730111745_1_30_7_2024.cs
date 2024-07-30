using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieTicket.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _1_30_7_2024 : Migration
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
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
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
                    Status = table.Column<int>(type: "int", nullable: true)
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
                columns: new[] { "Id", "Address", "Avatar", "CreateDate", "Email", "Name", "Password", "Phone", "Role", "Status", "Username" },
                values: new object[,]
                {
                    { new Guid("086d1144-6aae-4f8b-8af4-a1db2dfab24a"), "Address 26", "avatar26.png", new DateTime(2023, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "user26@example.com", "User 26", "JTjto+r7kPyCkZGQtsDBOA==", "123-456-78926", 2, 1, "user26" },
                    { new Guid("2989044b-c24d-44b1-9afa-99f8a618c118"), "Address 19", "avatar19.png", new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "user19@example.com", "User 19", "+BFH+L+RScNaLm45T9M5Tw==", "123-456-78919", 2, 1, "user19" },
                    { new Guid("2bc59d0e-eef3-441c-b80c-ca5c20f011f8"), "Address 20", "avatar20.png", new DateTime(2023, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "user20@example.com", "User 20", "J20oEfuyjDdy085hSNPLIw==", "123-456-78920", 2, 1, "user20" },
                    { new Guid("3eb5cfe0-d237-428b-a777-7598b3c04921"), "Address 21", "avatar21.png", new DateTime(2023, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "user21@example.com", "User 21", "uqWAcnIuI+ey7XOiRgb8IA==", "123-456-78921", 2, 1, "user21" },
                    { new Guid("445a3c30-acce-43d4-b4a2-f57e2b434752"), "Address 13", "avatar13.png", new DateTime(2023, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "user13@example.com", "User 13", "hjKFGDVLaz8y7jip9ebjyg==", "123-456-78913", 2, 1, "user13" },
                    { new Guid("528e579c-467d-4cf6-a4ce-a38dae3c0deb"), "Address 10", "avatar10.png", new DateTime(2023, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "user10@example.com", "User 10", "AD+DKAMne24G+bFvnB3umA==", "123-456-78910", 2, 1, "user10" },
                    { new Guid("54e4ad27-f12e-48ae-80da-3d9b6819be49"), "Address 8", "avatar8.png", new DateTime(2023, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "user8@example.com", "User 8", "QoNqXwm6ndtmwV7AptAudw==", "123-456-7898", 2, 1, "user8" },
                    { new Guid("5a65326d-a6b4-435d-8c4e-8b43bf2ac303"), "Address 7", "avatar7.png", new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "user7@example.com", "User 7", "h8t5vD5p1U3C4AEASeaErg==", "123-456-7897", 2, 1, "user7" },
                    { new Guid("68320b10-4e00-48c6-96e6-91dc3255f2f8"), "Address 25", "avatar25.png", new DateTime(2023, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "user25@example.com", "User 25", "o+65kwYOgM/H5YtlR5eBGQ==", "123-456-78925", 2, 1, "user25" },
                    { new Guid("6f5877bf-0c74-461b-8a53-a2083dff1d55"), "Address 3", "avatar3.png", new DateTime(2023, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "user3@example.com", "User 3", "XZG20Zjr0RmKJ42oxCGZqQ==", "123-456-7893", 2, 1, "user3" },
                    { new Guid("7da04598-4be2-43a5-85aa-0867ac5b2844"), "Address 22", "avatar22.png", new DateTime(2023, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "user22@example.com", "User 22", "yuwYTyVSnjUQg9d58Fr6eg==", "123-456-78922", 2, 1, "user22" },
                    { new Guid("9702905e-701f-473e-9101-44799bdd421a"), "Address 2", "avatar2.png", new DateTime(2023, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "user2@example.com", "User 2", "gPFa6fSRCX/O3JCnJjTBBg==", "123-456-7892", 2, 1, "user2" },
                    { new Guid("9961dd02-d4fd-45ca-bc95-007c42e3b9de"), "Address 29", "avatar29.png", new DateTime(2023, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "user29@example.com", "User 29", "ETdpo/KPinCotdzGNmsAPA==", "123-456-78929", 2, 1, "user29" },
                    { new Guid("9c392463-9fe7-4d0c-8f9e-91a1fca52cd1"), "Address 12", "avatar12.png", new DateTime(2023, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "user12@example.com", "User 12", "q/b7mh1nE1JeI7y/w6yvIQ==", "123-456-78912", 2, 1, "user12" },
                    { new Guid("9d78fad1-c094-41b7-b3ab-a31c40c1aa44"), "Address 1", "avatar1.png", new DateTime(2023, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "user1@example.com", "User 1", "ei00xFxTj/yW/ErUUw1JvA==", "123-456-7891", 2, 1, "user1" },
                    { new Guid("9d87fec5-997e-4fdb-a5b1-c11c0093a64b"), "Address 16", "avatar16.png", new DateTime(2023, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "user16@example.com", "User 16", "1+4JJ+OIs+XRXx0vTPNGQA==", "123-456-78916", 2, 1, "user16" },
                    { new Guid("a055cfde-492d-4c92-a272-a4e1f073f012"), "Address 18", "avatar18.png", new DateTime(2023, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "user18@example.com", "User 18", "zp6jPz/JRrDgXS7tmjREDQ==", "123-456-78918", 2, 1, "user18" },
                    { new Guid("ac950546-e91c-49c2-a661-4e92d4bd62ad"), "Address 9", "avatar9.png", new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "user9@example.com", "User 9", "XLl70iIryQx+lE/y5900Uw==", "123-456-7899", 2, 1, "user9" },
                    { new Guid("ae769e74-0ea6-4569-a0db-4ec896d6b820"), "Address 27", "avatar27.png", new DateTime(2023, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "user27@example.com", "User 27", "lePABwdtIg5MqkBgyFdL9Q==", "123-456-78927", 2, 1, "user27" },
                    { new Guid("ce2d4bf4-bf17-4d76-9a82-d38e4e657b64"), "Address 28", "avatar28.png", new DateTime(2023, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "user28@example.com", "User 28", "R/9+ITDUv36NqhUmUxCu5w==", "123-456-78928", 2, 1, "user28" },
                    { new Guid("d495a615-e241-44a7-993a-4d75b7569231"), "Address 23", "avatar23.png", new DateTime(2023, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "user23@example.com", "User 23", "JM3wDHJHLSLI6Wdnnfs2dQ==", "123-456-78923", 2, 1, "user23" },
                    { new Guid("d5cecb4d-a722-4211-9719-0d7db664d5c3"), "Address 6", "avatar6.png", new DateTime(2023, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "user6@example.com", "User 6", "ns3cIzMXn9uRJUqXbdf1sw==", "123-456-7896", 2, 1, "user6" },
                    { new Guid("e28cd878-fa52-4a12-9d77-97001d5b921a"), "Address 24", "avatar24.png", new DateTime(2023, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "user24@example.com", "User 24", "wUy5uoNVQITmQW5R4nnOMA==", "123-456-78924", 2, 1, "user24" },
                    { new Guid("e695e2a6-b7f9-4ce4-9aab-ccb5f933db4b"), "Address 5", "avatar5.png", new DateTime(2023, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "user5@example.com", "User 5", "LtgxZLXxd71ac78V6rYtcg==", "123-456-7895", 2, 1, "user5" },
                    { new Guid("f13e19b5-600d-4370-b4bd-1b25ebafa636"), "Address 15", "avatar15.png", new DateTime(2023, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "user15@example.com", "User 15", "AtoLhqKWoDhm5ytm7x3CFg==", "123-456-78915", 2, 1, "user15" },
                    { new Guid("f2c99bec-3c06-415b-8178-4eec730b04a1"), "Address 17", "avatar17.png", new DateTime(2023, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "user17@example.com", "User 17", "bnivYPkMUcJNzvYQyXZIvw==", "123-456-78917", 2, 1, "user17" },
                    { new Guid("f75f10db-069f-4793-ae8e-7f7dcd6034ff"), "Address 30", "avatar30.png", new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "user30@example.com", "User 30", "ZIc8EakA57j1Q7JTsakLKA==", "123-456-78930", 2, 1, "user30" },
                    { new Guid("f96cc423-d955-4689-a4b3-39009427f42d"), "Address 14", "avatar14.png", new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "user14@example.com", "User 14", "Nbb9cBgoI2KknXYhJgRsOg==", "123-456-78914", 2, 1, "user14" },
                    { new Guid("fb4a371f-285b-430f-85ef-8b8e9d059f4e"), "Address 11", "avatar11.png", new DateTime(2023, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "user11@example.com", "User 11", "+1XAkm3H0MciMPlnUyv6ww==", "123-456-78911", 2, 1, "user11" },
                    { new Guid("fd36705c-0610-4c30-9cfb-e5827b3f3d78"), "Address 1", "avatar1.png", new DateTime(2023, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "azusachan307@gmail.com", "ClientTest", "LK25tQh1RqkKbrq4C2l6fw==", "000-000-000", 1, 1, "Admin" },
                    { new Guid("fdb9cb95-79a6-4908-ae46-ce458dfaf588"), "Address 4", "avatar4.png", new DateTime(2023, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "user4@example.com", "User 4", "AYCB0pkX1QvnELN5s4E7/w==", "123-456-7894", 2, 1, "user4" }
                });

            migrationBuilder.InsertData(
                table: "CinemaCenters",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[,]
                {
                    { new Guid("031e14cd-ba88-4af1-a911-197f04c83908"), "Address 28", "Cinema Center 28" },
                    { new Guid("033bc8ea-ecd1-4228-924c-8a1ab2db5152"), "Address 17", "Cinema Center 17" },
                    { new Guid("0b8f5633-d0e2-4499-b551-9877f619a34d"), "Address 29", "Cinema Center 29" },
                    { new Guid("0ea50e02-780b-4d03-8c24-0fe73eb04fc1"), "Address 19", "Cinema Center 19" },
                    { new Guid("10d2c437-24df-4ea6-afb6-0c6c8d75ac38"), "Address 24", "Cinema Center 24" },
                    { new Guid("2419ad49-fd6b-4075-b3ea-b74622e43ff4"), "Address 1", "Cinema Center 1" },
                    { new Guid("2691ccfc-c6a8-4aeb-b58d-e784e21376fd"), "Address 26", "Cinema Center 26" },
                    { new Guid("351bd9dc-56ec-45cc-9fd9-ed66bb5669d7"), "Address 13", "Cinema Center 13" },
                    { new Guid("3ad664fd-d4b6-4be7-b76f-3d056a6e72c3"), "Address 10", "Cinema Center 10" },
                    { new Guid("3ccfaaeb-b64b-447c-a070-2435bfb032bf"), "Address 14", "Cinema Center 14" },
                    { new Guid("3f687c7f-3056-43ad-81b8-9df263071620"), "Address 15", "Cinema Center 15" },
                    { new Guid("41084370-747f-4892-85ec-48213e7b31f9"), "Address 4", "Cinema Center 4" },
                    { new Guid("4911bf0f-692d-4b00-b70e-f410eeeed20d"), "Address 11", "Cinema Center 11" },
                    { new Guid("55230399-fd61-4eff-8b70-94b9867eb2ea"), "Address 20", "Cinema Center 20" },
                    { new Guid("5e414938-ebf1-4110-ac41-57be47c747cb"), "Address 8", "Cinema Center 8" },
                    { new Guid("6bc14a03-cbfe-472e-9ecd-48c439079f50"), "Address 21", "Cinema Center 21" },
                    { new Guid("6e8e1014-5a4d-44de-ad77-e1146224aaa2"), "Address 16", "Cinema Center 16" },
                    { new Guid("744e3ea3-2ecc-435d-98dd-e6c2e8332e06"), "Address 7", "Cinema Center 7" },
                    { new Guid("792a11f5-bd83-4447-adc4-868a40011fec"), "Address 18", "Cinema Center 18" },
                    { new Guid("851f14ed-5504-44d9-ae98-c3a7501b150f"), "Address 30", "Cinema Center 30" },
                    { new Guid("8b263f7d-ea0d-45c5-a6ab-e6594cd94aff"), "Address 3", "Cinema Center 3" },
                    { new Guid("8b4d2397-f2cb-4246-92bd-e2e95d1ff96d"), "Address 27", "Cinema Center 27" },
                    { new Guid("92c21fc2-180d-4428-999a-83bb9c14ebd9"), "Address 23", "Cinema Center 23" },
                    { new Guid("94585632-1463-43a7-a8c2-edc1ab79d7d0"), "Address 12", "Cinema Center 12" },
                    { new Guid("955b84ca-e715-42c7-aca3-d46bfaaf56e3"), "Address 5", "Cinema Center 5" },
                    { new Guid("a03bdbb8-7aef-4c4e-a558-a3bb073dbe59"), "Address 22", "Cinema Center 22" },
                    { new Guid("a696e1ad-34d9-411c-b528-1155c1776317"), "Address 6", "Cinema Center 6" },
                    { new Guid("bef78559-c350-44f2-99ec-0ddad93b869e"), "Address 2", "Cinema Center 2" },
                    { new Guid("dfec35ca-6302-420d-8b76-638a9b56e86c"), "Address 9", "Cinema Center 9" },
                    { new Guid("fa6f8882-d69f-4d07-94da-4cc64ae1a0d3"), "Address 25", "Cinema Center 25" }
                });

            migrationBuilder.InsertData(
                table: "CinemaTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0019d8b5-908e-44b8-ba01-07e4cd35082a"), "Cinema Type 18" },
                    { new Guid("0c781eda-cb1d-45dc-9910-6607a03de405"), "Cinema Type 20" },
                    { new Guid("2224b2ba-d65b-4b4b-abde-8953b1d7f34d"), "Cinema Type 1" },
                    { new Guid("23976381-4a61-4a6b-accf-353df11b6d27"), "Cinema Type 11" },
                    { new Guid("252569d2-b5bc-409b-853f-23b5314a7b8c"), "Cinema Type 27" },
                    { new Guid("252a8daa-11d3-4ac1-86d9-c685e95fc33f"), "Cinema Type 26" },
                    { new Guid("2603c379-de76-4852-a047-add28cf3a584"), "Cinema Type 17" },
                    { new Guid("300cd87a-6141-4693-be40-1352d6fba1f2"), "Cinema Type 30" },
                    { new Guid("332f1772-aaca-46ce-b359-99e4d923d138"), "Cinema Type 21" },
                    { new Guid("406184c7-192c-467b-b7f9-c4f8cad50f99"), "Cinema Type 13" },
                    { new Guid("490faa03-e5ce-4b1a-a277-40b8012b40b7"), "Cinema Type 22" },
                    { new Guid("4d1896ae-ee24-4c57-ba80-7f99de05d821"), "Cinema Type 29" },
                    { new Guid("652081ee-7542-4081-86c1-7aecce811b06"), "Cinema Type 10" },
                    { new Guid("74e0dd8f-cfae-48f6-9ed8-7b5704820e68"), "Cinema Type 12" },
                    { new Guid("752b2476-6489-4035-9927-c1b48cd7f382"), "Cinema Type 6" },
                    { new Guid("7646980c-971d-46da-bea8-bd69c28a92bc"), "Cinema Type 15" },
                    { new Guid("7fc0f4d4-5ca3-4a01-9d07-bcb6842ce65b"), "Cinema Type 2" },
                    { new Guid("82796f1b-7060-4032-86f9-0adeb825d60a"), "Cinema Type 8" },
                    { new Guid("908bfaf2-089c-4400-8ca7-8a86b914962b"), "Cinema Type 16" },
                    { new Guid("9b4bc9a7-c406-4855-aa28-07a367379668"), "Cinema Type 14" },
                    { new Guid("9df338fb-cc7b-466e-9594-6f3cb921fe54"), "Cinema Type 5" },
                    { new Guid("a2d67f10-ec17-4139-9865-93a5fa22f421"), "Cinema Type 19" },
                    { new Guid("b013e2da-9e8d-4575-bccf-eb04c5547747"), "Cinema Type 28" },
                    { new Guid("c3890756-2f82-4903-a47a-8ef2c015d4d1"), "Cinema Type 3" },
                    { new Guid("c800d3a5-2181-4a09-8961-d8a9e1b9974b"), "Cinema Type 25" },
                    { new Guid("d014793d-8f24-484d-a193-b5da97c5f3cd"), "Cinema Type 9" },
                    { new Guid("dd660f2f-6810-443b-9ad5-af33c33bf7c8"), "Cinema Type 4" },
                    { new Guid("ea92ae18-2991-46d7-b71d-72d7d87cdb7b"), "Cinema Type 23" },
                    { new Guid("fdb936b1-2723-44c3-ae1e-c33522688b62"), "Cinema Type 7" },
                    { new Guid("ff6e42c7-4359-437b-a31e-3bb77b4aa956"), "Cinema Type 24" }
                });

            migrationBuilder.InsertData(
                table: "Combos",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("0ba777be-c29d-4180-bfba-224636bd786d"), "Combo 7", 70000m },
                    { new Guid("23004581-8eb5-44f8-961e-c5c61d3bf4d8"), "Combo 26", 60000m },
                    { new Guid("230b26ba-4373-41b7-bf86-83c8c710046d"), "Combo 17", 70000m },
                    { new Guid("23118961-b847-4289-b766-4c4bdbb29106"), "Combo 14", 40000m },
                    { new Guid("28fd79ed-c603-4562-9552-43b7eb3d98bd"), "Combo 1", 10000m },
                    { new Guid("2dd513b6-e7e3-4f2a-8f78-ee75cd5dea71"), "Combo 21", 10000m },
                    { new Guid("31ecf945-1f6e-41c7-a53b-0c4922b5d921"), "Combo 23", 30000m },
                    { new Guid("36b39b78-7ea8-4688-b785-d38328021a3f"), "Combo 29", 90000m },
                    { new Guid("3897a470-2635-455e-a5cc-82a57c151b37"), "Combo 20", 0m },
                    { new Guid("3ef09ab2-c037-4361-891c-fe6dd4c942cc"), "Combo 15", 50000m },
                    { new Guid("46fb499c-1c23-4f25-9596-80b08119c26c"), "Combo 10", 0m },
                    { new Guid("56ab0d62-bd6e-41eb-89d7-ed49bba5dafe"), "Combo 12", 20000m },
                    { new Guid("595ddcea-98e6-4046-9b11-cf4458f73169"), "Combo 24", 40000m },
                    { new Guid("612444e3-f5a5-4ed4-ad99-c369b22c33fa"), "Combo 5", 50000m },
                    { new Guid("6182e922-ec3d-4bba-8f26-5cf4606c4445"), "Combo 4", 40000m },
                    { new Guid("6279bdbc-d1cb-4848-bb52-07e2e874ca56"), "Combo 8", 80000m },
                    { new Guid("6508a5f5-2ae1-4940-8460-e6a331a3f0af"), "Combo 16", 60000m },
                    { new Guid("6a4fd850-3bed-41a3-b970-6d8305d3e407"), "Combo 27", 70000m },
                    { new Guid("70bdd498-b0cd-4601-a5bb-aaa19e00c8a4"), "Combo 3", 30000m },
                    { new Guid("70d6dc22-e30b-44c3-aaad-f5c9ba1d4ecf"), "Combo 9", 90000m },
                    { new Guid("806c353b-1b39-43dd-bbeb-757ede2ddb04"), "Combo 28", 80000m },
                    { new Guid("8c7b1dac-419d-4c7a-8906-006569a26780"), "Combo 2", 20000m },
                    { new Guid("a81c23fa-a0c3-40a3-b0b4-c158b09e5bba"), "Combo 30", 0m },
                    { new Guid("a93d4f44-ae92-4032-ae24-a79a388a88db"), "Combo 22", 20000m },
                    { new Guid("ad0adb5e-88da-4d60-8202-daeb6825e9fd"), "Combo 25", 50000m },
                    { new Guid("ad995979-5ba1-47d9-b4ab-355ae1ff05e9"), "Combo 19", 90000m },
                    { new Guid("be83164d-f099-48f7-a35f-398c13afee32"), "Combo 6", 60000m },
                    { new Guid("d6b08393-e6d7-4af0-96d3-76607075f767"), "Combo 18", 80000m },
                    { new Guid("dc531532-8594-4bf7-9947-08b33f5a26f3"), "Combo 11", 10000m },
                    { new Guid("e214ca00-8b24-4fad-a970-7fdfcc24c7b9"), "Combo 13", 30000m }
                });

            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "Id", "Cast", "CreatDate", "Description", "Director", "EnglishName", "Gerne", "Language", "Name", "Nation", "Poster", "Rating", "ReleaseYear", "RunningTime", "ScreenTypeId", "StartDate", "Status", "Trailer", "TranslationTypeId" },
                values: new object[,]
                {
                    { new Guid("0621be75-9a55-408b-b557-d572c2970bba"), "Actor 13, Actress 13", new DateTime(2023, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 13.", "Director 13", "Film 13 (English)", "Comedy", "Japanese", "Film 13", "Japan", "https://example.com/poster13.jpg", 4, 2023, 73, new Guid("503e7ecb-a1e3-4a66-b7b9-7dbd3917abb0"), new DateTime(2023, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer13.mp4", new Guid("312fcbbf-20e2-43cf-8dc4-ccbd7717ed9d") },
                    { new Guid("1552181f-cf10-4bd2-9651-e302a7be7d05"), "Actor 26, Actress 26", new DateTime(2023, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 26.", "Director 26", "Film 26 (English)", "Action", "English", "Film 26", "USA", "https://example.com/poster26.jpg", 2, 2023, 86, new Guid("d0e89a87-46fd-4dd5-ad82-279cfbb82e7a"), new DateTime(2023, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer26.mp4", new Guid("5886a7c6-4c1f-4ff1-8de2-ed1673e207c3") },
                    { new Guid("19c1df6a-1e9b-445d-a75e-11e86523bf53"), "Actor 15, Actress 15", new DateTime(2023, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 15.", "Director 15", "Film 15 (English)", "Comedy", "Japanese", "Film 15", "Japan", "https://example.com/poster15.jpg", 1, 2023, 75, new Guid("1215c6db-bf66-4fa8-833d-e846cc98856a"), new DateTime(2023, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer15.mp4", new Guid("56274806-9a0c-45cc-8fab-ddc19999dc51") },
                    { new Guid("23319d86-dc02-4953-b9ac-146b56efefae"), "Actor 10, Actress 10", new DateTime(2023, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 10.", "Director 10", "Film 10 (English)", "Action", "English", "Film 10", "USA", "https://example.com/poster10.jpg", 1, 2023, 70, new Guid("295e3b18-0f9b-4055-9dad-8e4877a02807"), new DateTime(2023, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer10.mp4", new Guid("4dc8af92-ca21-4e7b-bc4e-f7485956191c") },
                    { new Guid("248dcf89-6549-498f-8112-13d941d76327"), "Actor 22, Actress 22", new DateTime(2023, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 22.", "Director 22", "Film 22 (English)", "Action", "English", "Film 22", "USA", "https://example.com/poster22.jpg", 3, 2023, 82, new Guid("e60c5a16-0fb1-46ff-9239-8f567ba10641"), new DateTime(2023, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer22.mp4", new Guid("e6c73f86-522f-4fd7-8356-f6310bbab63a") },
                    { new Guid("2c9bf702-60eb-42cd-933c-e57e0ec62a37"), "Actor 14, Actress 14", new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 14.", "Director 14", "Film 14 (English)", "Action", "English", "Film 14", "USA", "https://example.com/poster14.jpg", 5, 2023, 74, new Guid("5625da9e-7905-4a2b-b770-f925eb986869"), new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer14.mp4", new Guid("be3c37ea-9c03-408a-a644-d2e89b5321f9") },
                    { new Guid("352dfd7b-652a-43ea-951d-b0638d672b52"), "Actor 28, Actress 28", new DateTime(2023, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 28.", "Director 28", "Film 28 (English)", "Action", "English", "Film 28", "USA", "https://example.com/poster28.jpg", 4, 2023, 88, new Guid("ed58a1e1-dfc5-4ac7-9583-d0e06924c2ef"), new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer28.mp4", new Guid("ab9aaefe-c7e9-4b0f-811e-a3a61af34e2d") },
                    { new Guid("38a4781a-d684-4c8e-a797-fdd31d89f25a"), "Actor 21, Actress 21", new DateTime(2023, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 21.", "Director 21", "Film 21 (English)", "Comedy", "Japanese", "Film 21", "Japan", "https://example.com/poster21.jpg", 2, 2023, 81, new Guid("503351ba-ba56-455c-a92f-5179ead1cc79"), new DateTime(2023, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer21.mp4", new Guid("55afbe86-d7d4-43cc-ae7d-d0c1815ca53e") },
                    { new Guid("45ff146a-2eb9-4f53-bf4c-82f0123e2f9f"), "Actor 30, Actress 30", new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 30.", "Director 30", "Film 30 (English)", "Action", "English", "Film 30", "USA", "https://example.com/poster30.jpg", 1, 2023, 90, new Guid("b3424fa5-a705-4ddd-be05-605e9af397b0"), new DateTime(2023, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer30.mp4", new Guid("bc298efa-6520-4172-b4c1-6e0e05e78231") },
                    { new Guid("4f24eba2-3477-44ef-9cd1-5471dfedb741"), "Actor 18, Actress 18", new DateTime(2023, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 18.", "Director 18", "Film 18 (English)", "Action", "English", "Film 18", "USA", "https://example.com/poster18.jpg", 4, 2023, 78, new Guid("0c83987b-91aa-46f7-8ea0-79e13fe57cc9"), new DateTime(2023, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer18.mp4", new Guid("5af1a1b7-764b-4841-b597-a76e7e71589d") },
                    { new Guid("50ab85ab-f254-4a4a-82cd-f756fc4a5b55"), "Actor 29, Actress 29", new DateTime(2023, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 29.", "Director 29", "Film 29 (English)", "Comedy", "Japanese", "Film 29", "Japan", "https://example.com/poster29.jpg", 5, 2023, 89, new Guid("4a999bca-86df-42d9-8f2b-8f475a3ce2db"), new DateTime(2023, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer29.mp4", new Guid("b377a331-0902-4de3-8867-ec71531154f2") },
                    { new Guid("53e9e0a5-073c-4b2b-af5e-8671185d5524"), "Actor 5, Actress 5", new DateTime(2023, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 5.", "Director 5", "Film 5 (English)", "Comedy", "Japanese", "Film 5", "Japan", "https://example.com/poster5.jpg", 1, 2023, 65, new Guid("74a086ae-80ed-4e0a-90d4-2f1f06afa775"), new DateTime(2023, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer5.mp4", new Guid("05b41030-b302-4bf5-81e6-e3c230f2796f") },
                    { new Guid("554fdcfb-d4d7-4750-9420-0bdd47eb8977"), "Actor 20, Actress 20", new DateTime(2023, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 20.", "Director 20", "Film 20 (English)", "Action", "English", "Film 20", "USA", "https://example.com/poster20.jpg", 1, 2023, 80, new Guid("c648a22d-e8ae-4cb5-a5f8-c98a7c98a067"), new DateTime(2023, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer20.mp4", new Guid("26dc27dd-a4a1-4c0c-8958-3d6c364762e5") },
                    { new Guid("5ac19004-763a-491e-8e6a-361f01b80d9d"), "Actor 7, Actress 7", new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 7.", "Director 7", "Film 7 (English)", "Comedy", "Japanese", "Film 7", "Japan", "https://example.com/poster7.jpg", 3, 2023, 67, new Guid("83f347a8-207f-4024-999e-b3df098c5781"), new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer7.mp4", new Guid("223c5361-386d-44f3-a886-0bcd32c9e7a1") },
                    { new Guid("60d2149a-b98f-4290-ab6d-6c0a4891c8f1"), "Actor 4, Actress 4", new DateTime(2023, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 4.", "Director 4", "Film 4 (English)", "Action", "English", "Film 4", "USA", "https://example.com/poster4.jpg", 5, 2023, 64, new Guid("9d3543c5-b5f1-4ea0-905a-c0c1002fe31e"), new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer4.mp4", new Guid("667dfeac-f7ec-4179-96b5-e058bcb8e41c") },
                    { new Guid("64b33695-be4a-4947-9482-1bb6935e6520"), "Actor 9, Actress 9", new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 9.", "Director 9", "Film 9 (English)", "Comedy", "Japanese", "Film 9", "Japan", "https://example.com/poster9.jpg", 5, 2023, 69, new Guid("651ffee5-83f2-4be2-afc6-944b467a6d4f"), new DateTime(2023, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer9.mp4", new Guid("276898f7-9bcf-44b4-9eb2-c6a10e79ba20") },
                    { new Guid("75c36596-2fd1-4960-b84f-6e922b76f664"), "Actor 27, Actress 27", new DateTime(2023, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 27.", "Director 27", "Film 27 (English)", "Comedy", "Japanese", "Film 27", "Japan", "https://example.com/poster27.jpg", 3, 2023, 87, new Guid("9689b13d-b0b3-47bc-80e9-9b430841a06c"), new DateTime(2023, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer27.mp4", new Guid("04ad0c91-e45c-4427-a87e-ff1439e3d4be") },
                    { new Guid("81c1c583-5fad-4d1a-b3df-a17c5aef3f9c"), "Actor 25, Actress 25", new DateTime(2023, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 25.", "Director 25", "Film 25 (English)", "Comedy", "Japanese", "Film 25", "Japan", "https://example.com/poster25.jpg", 1, 2023, 85, new Guid("a9af56d8-fd0d-48bf-94b5-b2e5b16e6006"), new DateTime(2023, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer25.mp4", new Guid("d0c716e1-0382-40f0-aa36-78b017d239dc") },
                    { new Guid("85bf38b2-b1b0-45fb-8093-f85709baed95"), "Actor 12, Actress 12", new DateTime(2023, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 12.", "Director 12", "Film 12 (English)", "Action", "English", "Film 12", "USA", "https://example.com/poster12.jpg", 3, 2023, 72, new Guid("70de918e-c474-49d9-8dae-963969e9c1e7"), new DateTime(2023, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer12.mp4", new Guid("8bd87147-580c-475f-a7c1-e85ca0842d33") },
                    { new Guid("8734584d-6ddc-44cc-bfc2-01903acb120a"), "Actor 2, Actress 2", new DateTime(2023, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 2.", "Director 2", "Film 2 (English)", "Action", "English", "Film 2", "USA", "https://example.com/poster2.jpg", 3, 2023, 62, new Guid("10ad464f-9c17-4a90-8615-9a15fcef6ad0"), new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer2.mp4", new Guid("8c739296-1579-4e67-b9e6-6464f5523161") },
                    { new Guid("9c439cae-6d21-4ff7-bbc7-2f5b25791bbb"), "Actor 11, Actress 11", new DateTime(2023, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 11.", "Director 11", "Film 11 (English)", "Comedy", "Japanese", "Film 11", "Japan", "https://example.com/poster11.jpg", 2, 2023, 71, new Guid("5dbf1e93-2e94-4cdd-8a88-f45a8e38f35d"), new DateTime(2023, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer11.mp4", new Guid("dcd82b9a-a407-4ed8-98e3-651395e0c74f") },
                    { new Guid("a4c83bb2-6d87-4ff4-9b5a-98a109fad462"), "Actor 3, Actress 3", new DateTime(2023, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 3.", "Director 3", "Film 3 (English)", "Comedy", "Japanese", "Film 3", "Japan", "https://example.com/poster3.jpg", 4, 2023, 63, new Guid("8d7b8711-c132-41d9-845a-27ff41f38b52"), new DateTime(2023, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer3.mp4", new Guid("b1efeec4-5c4b-430c-87ef-6b708495f2f5") },
                    { new Guid("af735e22-19e7-4ddc-8eac-e439a147b269"), "Actor 1, Actress 1", new DateTime(2023, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 1.", "Director 1", "Film 1 (English)", "Comedy", "Japanese", "Film 1", "Japan", "https://example.com/poster1.jpg", 2, 2023, 61, new Guid("013cb2f5-9a9f-450e-a932-9b792e0bc406"), new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer1.mp4", new Guid("5664a966-be18-464e-9bec-517af64f2d2e") },
                    { new Guid("ba51dd8c-02ad-4aab-a9af-732284a3eef9"), "Actor 6, Actress 6", new DateTime(2023, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 6.", "Director 6", "Film 6 (English)", "Action", "English", "Film 6", "USA", "https://example.com/poster6.jpg", 2, 2023, 66, new Guid("db256339-0767-4531-83d0-9103054dd4a0"), new DateTime(2023, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer6.mp4", new Guid("ceb61f3d-592f-40c8-b107-3d0ee76e9124") },
                    { new Guid("ce6ca0be-55d6-409c-869d-92babd311ce7"), "Actor 19, Actress 19", new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 19.", "Director 19", "Film 19 (English)", "Comedy", "Japanese", "Film 19", "Japan", "https://example.com/poster19.jpg", 5, 2023, 79, new Guid("73cc0468-7240-4ba3-89cb-10088ede0e1d"), new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer19.mp4", new Guid("652b771b-53bb-4684-a2ff-e9c1f21d077a") },
                    { new Guid("d16eaa3b-26f6-4298-8beb-697ef8a71922"), "Actor 23, Actress 23", new DateTime(2023, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 23.", "Director 23", "Film 23 (English)", "Comedy", "Japanese", "Film 23", "Japan", "https://example.com/poster23.jpg", 4, 2023, 83, new Guid("3c5f6b11-af02-4673-9ab5-3d8e4f8a5ea7"), new DateTime(2023, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer23.mp4", new Guid("20d60e68-a3e5-4d9f-bbe8-dd247d7dee82") },
                    { new Guid("e110fb2e-a1eb-4a0d-acf4-588be809210e"), "Actor 16, Actress 16", new DateTime(2023, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 16.", "Director 16", "Film 16 (English)", "Action", "English", "Film 16", "USA", "https://example.com/poster16.jpg", 2, 2023, 76, new Guid("c8fb5521-3a64-42d6-a166-601e1198b880"), new DateTime(2023, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer16.mp4", new Guid("498a98ee-b196-4d75-8b80-d5a80d716916") },
                    { new Guid("ed915f75-aa99-4203-bad7-64156301d91a"), "Actor 8, Actress 8", new DateTime(2023, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 8.", "Director 8", "Film 8 (English)", "Action", "English", "Film 8", "USA", "https://example.com/poster8.jpg", 4, 2023, 68, new Guid("0b31bfa9-252d-485c-8007-3405162915f7"), new DateTime(2023, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer8.mp4", new Guid("833af414-30c3-4016-9736-649943bba4ae") },
                    { new Guid("fec48eb6-a8bb-4482-a212-b08c834ee013"), "Actor 24, Actress 24", new DateTime(2023, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 24.", "Director 24", "Film 24 (English)", "Action", "English", "Film 24", "USA", "https://example.com/poster24.jpg", 5, 2023, 84, new Guid("58c172ba-243d-41e1-b190-4494a5e2fc82"), new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer24.mp4", new Guid("f951f136-40db-4ea5-bf60-2e4c58640196") },
                    { new Guid("ff22ccf8-b58d-44f5-9936-8436158119eb"), "Actor 17, Actress 17", new DateTime(2023, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 17.", "Director 17", "Film 17 (English)", "Comedy", "Japanese", "Film 17", "Japan", "https://example.com/poster17.jpg", 3, 2023, 77, new Guid("2b73067b-d11a-4261-8ab3-6ab43c1236c9"), new DateTime(2023, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer17.mp4", new Guid("44f8c085-e23f-4656-b27a-43121cb4aa75") }
                });

            migrationBuilder.InsertData(
                table: "Promotions",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("0b831287-9bef-4495-a95a-0e889869f053"), "Title 16" },
                    { new Guid("1897f888-f68c-411a-bcfd-657bdae0a941"), "Title 27" },
                    { new Guid("1cac1a57-d6c7-4b7b-8b70-c817f0d6f4d5"), "Title 3" },
                    { new Guid("1dab5b45-79a7-40ed-be03-2b2d9417efdf"), "Title 17" },
                    { new Guid("1e874bed-48da-491c-84d5-6ab0501805d3"), "Title 18" },
                    { new Guid("232f213f-21c0-490e-b1bb-c230fa31a4e1"), "Title 28" },
                    { new Guid("254e0e8e-66e3-461f-a826-7c1e04d5aace"), "Title 6" },
                    { new Guid("275fafed-c544-4ba8-adfe-f86998ccda20"), "Title 22" },
                    { new Guid("2efe5881-bf11-40f5-a54e-f0fd442adc33"), "Title 12" },
                    { new Guid("3c96c6a0-e9e1-4848-936d-1f5f727ebcbe"), "Title 13" },
                    { new Guid("3cb6f74d-1e66-4e19-b4a4-bdd505c06e00"), "Title 5" },
                    { new Guid("526ae2fa-cd5a-4b86-ba30-49f8dea7dda9"), "Title 8" },
                    { new Guid("559ae18f-eff2-42e8-988c-5d1e2f44db13"), "Title 30" },
                    { new Guid("56be7bc1-827b-4647-a483-5c8a614e8646"), "Title 24" },
                    { new Guid("5d1e41ea-ee00-43ac-813b-e7465376cfee"), "Title 21" },
                    { new Guid("69af2b41-8cee-4578-8b89-217a10bf5cbe"), "Title 20" },
                    { new Guid("6c9dbf85-46e3-40cc-a2c5-4f64017a35ab"), "Title 10" },
                    { new Guid("7b38b8b7-dcaf-4456-938f-7a1895b8cff8"), "Title 11" },
                    { new Guid("83445a1c-78f8-45db-b7e7-b1502bae2e3d"), "Title 23" },
                    { new Guid("86991826-2ae0-43a2-8b91-a926c408fd65"), "Title 26" },
                    { new Guid("9c6e2a6f-a4d7-40c8-bf64-faf3667b347f"), "Title 19" },
                    { new Guid("a03233b1-f5f6-4c18-a89e-db28df756739"), "Title 29" },
                    { new Guid("b39efc48-e0a0-49f2-9c51-3bc082be2293"), "Title 15" },
                    { new Guid("da757f2d-ffe8-47ec-8b50-deb0be526dd3"), "Title 14" },
                    { new Guid("dc31b086-71d5-4fb9-bed9-deab3885b73e"), "Title 7" },
                    { new Guid("e41c25d8-b4a3-4a6b-923d-061e26671f3c"), "Title 4" },
                    { new Guid("e8ab170e-ecb7-4998-b874-5019215bcffa"), "Title 1" },
                    { new Guid("e8b9be3a-8b27-479e-af16-50a6b1d7fb70"), "Title 2" },
                    { new Guid("fc74be91-6389-40e1-bce3-d5886bca25b0"), "Title 25" },
                    { new Guid("fe6b388d-d7d4-42b1-9b8c-4dab6be37768"), "Title 9" }
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
                table: "Memberships",
                columns: new[] { "Id", "Point", "Status" },
                values: new object[] { new Guid("fd36705c-0610-4c30-9cfb-e5827b3f3d78"), 0, 1 });

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
                column: "CinemaTypeId",
                unique: true,
                filter: "[CinemaTypeId] IS NOT NULL");

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
                column: "ScreenTypeId",
                unique: true,
                filter: "[ScreenTypeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ShowTimes_TranslationTypeId",
                table: "ShowTimes",
                column: "TranslationTypeId",
                unique: true,
                filter: "[TranslationTypeId] IS NOT NULL");

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
