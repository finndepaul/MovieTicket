using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieTicket.Infrastructure.Migrations.MovieTicketReadOnlyDb
{
    /// <inheritdoc />
    public partial class b : Migration
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
                    { new Guid("067fbfdc-88e3-4c40-b617-5b6019030bb2"), "Address 1", "avatar1.png", new DateTime(2023, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "user1@example.com", "User 1", "ei00xFxTj/yW/ErUUw1JvA==", "123-456-7891", 2, 1, "user1" },
                    { new Guid("0d70fde9-4632-4f1e-bf79-120a0ab4c2e9"), "Address 19", "avatar19.png", new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "user19@example.com", "User 19", "+BFH+L+RScNaLm45T9M5Tw==", "123-456-78919", 2, 1, "user19" },
                    { new Guid("1358e5aa-6ce3-499e-ac0f-5fc597414524"), "Address 28", "avatar28.png", new DateTime(2023, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "user28@example.com", "User 28", "R/9+ITDUv36NqhUmUxCu5w==", "123-456-78928", 2, 1, "user28" },
                    { new Guid("24f8caf8-101d-4e92-a660-a81bff01ffb0"), "Address 24", "avatar24.png", new DateTime(2023, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "user24@example.com", "User 24", "wUy5uoNVQITmQW5R4nnOMA==", "123-456-78924", 2, 1, "user24" },
                    { new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), "Address 2", "avatar2.png", new DateTime(2023, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "azusachan309@gmail.com", "ClientTest", "LK25tQh1RqkKbrq4C2l6fw==", "000-000-000", 2, 1, "Client" },
                    { new Guid("3906172d-79e7-4f36-a4ea-22b7680028e8"), "Address 23", "avatar23.png", new DateTime(2023, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "user23@example.com", "User 23", "JM3wDHJHLSLI6Wdnnfs2dQ==", "123-456-78923", 2, 1, "user23" },
                    { new Guid("3aeb169a-526f-49dc-8ebc-3513770be48d"), "Address 2", "avatar2.png", new DateTime(2023, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "user2@example.com", "User 2", "gPFa6fSRCX/O3JCnJjTBBg==", "123-456-7892", 2, 1, "user2" },
                    { new Guid("46f4e421-a4d7-4b57-8252-3e888f66cac6"), "Address 15", "avatar15.png", new DateTime(2023, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "user15@example.com", "User 15", "AtoLhqKWoDhm5ytm7x3CFg==", "123-456-78915", 2, 1, "user15" },
                    { new Guid("4c5ad01c-c8ee-4c69-969e-80e3236ec7d2"), "Address 22", "avatar22.png", new DateTime(2023, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "user22@example.com", "User 22", "yuwYTyVSnjUQg9d58Fr6eg==", "123-456-78922", 2, 1, "user22" },
                    { new Guid("4fb04b8b-c986-4ea2-a39a-a8c116625d32"), "Address 26", "avatar26.png", new DateTime(2023, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "user26@example.com", "User 26", "JTjto+r7kPyCkZGQtsDBOA==", "123-456-78926", 2, 1, "user26" },
                    { new Guid("53d5a91d-e6c3-42f8-9549-1b03202d7b55"), "Address 30", "avatar30.png", new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "user30@example.com", "User 30", "ZIc8EakA57j1Q7JTsakLKA==", "123-456-78930", 2, 1, "user30" },
                    { new Guid("59219e4b-6fc2-4ab3-b5e5-10f9943880fb"), "Address 17", "avatar17.png", new DateTime(2023, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "user17@example.com", "User 17", "bnivYPkMUcJNzvYQyXZIvw==", "123-456-78917", 2, 1, "user17" },
                    { new Guid("6539e0d9-64ca-49a8-950a-a71bf6701b9b"), "Address 29", "avatar29.png", new DateTime(2023, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "user29@example.com", "User 29", "ETdpo/KPinCotdzGNmsAPA==", "123-456-78929", 2, 1, "user29" },
                    { new Guid("69d7635b-ece5-4f9d-822c-358b37670dc0"), "Address 16", "avatar16.png", new DateTime(2023, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "user16@example.com", "User 16", "1+4JJ+OIs+XRXx0vTPNGQA==", "123-456-78916", 2, 1, "user16" },
                    { new Guid("6b4389b4-c431-4f2d-8b4a-934106b74209"), "Address 9", "avatar9.png", new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "user9@example.com", "User 9", "XLl70iIryQx+lE/y5900Uw==", "123-456-7899", 2, 1, "user9" },
                    { new Guid("8149bad7-a9e8-4eda-a404-854483e65578"), "Address 20", "avatar20.png", new DateTime(2023, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "user20@example.com", "User 20", "J20oEfuyjDdy085hSNPLIw==", "123-456-78920", 2, 1, "user20" },
                    { new Guid("88242876-ce8b-4b2c-ab7d-c93dae20773f"), "Address 3", "avatar3.png", new DateTime(2023, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "user3@example.com", "User 3", "XZG20Zjr0RmKJ42oxCGZqQ==", "123-456-7893", 2, 1, "user3" },
                    { new Guid("8a3db164-ea70-4c4f-b40d-87fbcd395e75"), "Address 10", "avatar10.png", new DateTime(2023, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "user10@example.com", "User 10", "AD+DKAMne24G+bFvnB3umA==", "123-456-78910", 2, 1, "user10" },
                    { new Guid("8c282c00-e672-4fea-a93c-ffbe81b2adef"), "Address 12", "avatar12.png", new DateTime(2023, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "user12@example.com", "User 12", "q/b7mh1nE1JeI7y/w6yvIQ==", "123-456-78912", 2, 1, "user12" },
                    { new Guid("92998632-3cd9-4590-aeec-a4968eb155ed"), "Address 21", "avatar21.png", new DateTime(2023, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "user21@example.com", "User 21", "uqWAcnIuI+ey7XOiRgb8IA==", "123-456-78921", 2, 1, "user21" },
                    { new Guid("9473a24e-d140-41b7-ae97-0335c4ecc4b9"), "Address 18", "avatar18.png", new DateTime(2023, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "user18@example.com", "User 18", "zp6jPz/JRrDgXS7tmjREDQ==", "123-456-78918", 2, 1, "user18" },
                    { new Guid("96b7f8d6-541b-4acc-8349-17f03f46a5a1"), "Address 11", "avatar11.png", new DateTime(2023, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "user11@example.com", "User 11", "+1XAkm3H0MciMPlnUyv6ww==", "123-456-78911", 2, 1, "user11" },
                    { new Guid("98ba91c1-547a-4f9f-9732-2f66c1f4afe5"), "Address 8", "avatar8.png", new DateTime(2023, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "user8@example.com", "User 8", "QoNqXwm6ndtmwV7AptAudw==", "123-456-7898", 2, 1, "user8" },
                    { new Guid("a2805019-14eb-4224-8433-cf0d4a0f780b"), "Address 5", "avatar5.png", new DateTime(2023, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "user5@example.com", "User 5", "LtgxZLXxd71ac78V6rYtcg==", "123-456-7895", 2, 1, "user5" },
                    { new Guid("b7540eb8-ee8d-4cee-911e-72fa6e2f1feb"), "Address 25", "avatar25.png", new DateTime(2023, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "user25@example.com", "User 25", "o+65kwYOgM/H5YtlR5eBGQ==", "123-456-78925", 2, 1, "user25" },
                    { new Guid("ce5f210e-ffa7-4f6a-a150-6753e0a2c959"), "Address 27", "avatar27.png", new DateTime(2023, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "user27@example.com", "User 27", "lePABwdtIg5MqkBgyFdL9Q==", "123-456-78927", 2, 1, "user27" },
                    { new Guid("d5d5a1e1-0a5f-43b3-b315-6b29a4c0e0aa"), "Address 14", "avatar14.png", new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "user14@example.com", "User 14", "Nbb9cBgoI2KknXYhJgRsOg==", "123-456-78914", 2, 1, "user14" },
                    { new Guid("d61d856e-352f-47ab-9576-399b4c33a34c"), "Address 13", "avatar13.png", new DateTime(2023, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "user13@example.com", "User 13", "hjKFGDVLaz8y7jip9ebjyg==", "123-456-78913", 2, 1, "user13" },
                    { new Guid("df74f382-d685-46f3-be57-2152feaf9761"), "Address 7", "avatar7.png", new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "user7@example.com", "User 7", "h8t5vD5p1U3C4AEASeaErg==", "123-456-7897", 2, 1, "user7" },
                    { new Guid("e5a38697-a19c-48a8-8c11-b67d9f872f1d"), "Address 6", "avatar6.png", new DateTime(2023, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "user6@example.com", "User 6", "ns3cIzMXn9uRJUqXbdf1sw==", "123-456-7896", 2, 1, "user6" },
                    { new Guid("fbab72dc-8327-4d38-b81d-3d76b4d2a849"), "Address 4", "avatar4.png", new DateTime(2023, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "user4@example.com", "User 4", "AYCB0pkX1QvnELN5s4E7/w==", "123-456-7894", 2, 1, "user4" },
                    { new Guid("fd36705c-0610-4c30-9cfb-e5827b3f3d78"), "Address 1", "avatar1.png", new DateTime(2023, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "azusachan307@gmail.com", "AdminTest", "LK25tQh1RqkKbrq4C2l6fw==", "000-000-000", 1, 1, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "CinemaCenters",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[,]
                {
                    { new Guid("1149860d-7296-4eda-a172-30e2a1aec7bf"), "Address 10", "Cinema Center 10" },
                    { new Guid("142eed81-3a9e-4ee5-9b72-12eaf8d5a087"), "Address 20", "Cinema Center 20" },
                    { new Guid("23ebaf3c-5c97-4bd3-a539-c2555edebfa1"), "Address 19", "Cinema Center 19" },
                    { new Guid("2f1fa0d7-e22c-47af-b660-fa1d298a9495"), "Address 5", "Cinema Center 5" },
                    { new Guid("329708e0-8a62-4e35-8d51-b4e590fb9e99"), "Address 9", "Cinema Center 9" },
                    { new Guid("33126158-0ed1-4a83-9e57-4539e019d24f"), "Address 30", "Cinema Center 30" },
                    { new Guid("39aef27c-4151-4b11-aac5-b0574b20db21"), "Address 13", "Cinema Center 13" },
                    { new Guid("3ca4db01-7d97-4f00-be09-c859f3e9b53e"), "Address 21", "Cinema Center 21" },
                    { new Guid("50e2e2bf-5933-4c38-b81c-e31ab92b520a"), "Address 22", "Cinema Center 22" },
                    { new Guid("5bf7c3c2-ba29-4c64-a740-0abe0c9bfcf5"), "Address 14", "Cinema Center 14" },
                    { new Guid("5f836cb6-c3e4-4480-8ed9-4322f7fe29d3"), "Address 23", "Cinema Center 23" },
                    { new Guid("5fd0d523-198b-4b9a-9a2a-66f181d99284"), "Address 4", "Cinema Center 4" },
                    { new Guid("6191e4d9-4d55-4410-8428-3961edbe4185"), "Address 7", "Cinema Center 7" },
                    { new Guid("62a2e1fa-43c1-4ff5-b51c-656fef64a200"), "Address 12", "Cinema Center 12" },
                    { new Guid("63682607-5f68-4196-9068-22594670e0c8"), "Address 11", "Cinema Center 11" },
                    { new Guid("8655de78-b91e-40cf-9d24-5c5d0550549f"), "Address 1", "Cinema Center 1" },
                    { new Guid("8880ed6c-3729-433b-8ba7-a8135d1eda45"), "Address 2", "Cinema Center 2" },
                    { new Guid("8904c38e-b5ca-4559-a8e7-6f194771321a"), "Address 29", "Cinema Center 29" },
                    { new Guid("8dc51421-b949-4586-a74c-dc1da16ccfed"), "Address 27", "Cinema Center 27" },
                    { new Guid("9768466f-9de7-4bfa-ae8c-f2edc449e19d"), "Address 8", "Cinema Center 8" },
                    { new Guid("a076a4eb-8225-4347-b902-2a9669b1214b"), "Address 26", "Cinema Center 26" },
                    { new Guid("b13fb8b8-493a-4c40-ae97-16323ed316d0"), "Address 25", "Cinema Center 25" },
                    { new Guid("b14bfb5d-d94d-49f5-a6c3-86fb1ea81700"), "Address 6", "Cinema Center 6" },
                    { new Guid("ba120274-e815-436e-a1d7-76ee8eef9bfa"), "Address 3", "Cinema Center 3" },
                    { new Guid("ba8b2ce6-4982-4050-bf69-849c51f23e5d"), "Address 18", "Cinema Center 18" },
                    { new Guid("cb2ec087-4436-4ca0-97d2-fe03636cd27f"), "Address 17", "Cinema Center 17" },
                    { new Guid("ce56e2a8-1ff2-4da1-9bf6-628412a7c18b"), "Address 16", "Cinema Center 16" },
                    { new Guid("d4e3733f-6361-4eb7-96e2-2fab3c669c55"), "Address 28", "Cinema Center 28" },
                    { new Guid("dbb23550-82be-4c2a-b475-1f720cc335a7"), "Address 15", "Cinema Center 15" },
                    { new Guid("ecb19868-0342-47e6-aba9-b0f2b0b31d47"), "Address 24", "Cinema Center 24" }
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
                    { new Guid("08f7977c-5cbc-44fe-b6a3-4e6a81a76798"), "Combo 28", 80000m },
                    { new Guid("0ecc082f-34e9-4df3-a192-722765d9978f"), "Combo 4", 40000m },
                    { new Guid("1781fa86-b5cc-4e87-9b5c-0db6b4647d05"), "Combo 7", 70000m },
                    { new Guid("19e4c883-f31f-440b-9922-8192f0596587"), "Combo 27", 70000m },
                    { new Guid("1e93e1a5-9d4b-4601-a227-b3b77ebe119c"), "Combo 6", 60000m },
                    { new Guid("1efcbf56-a68e-44e1-abf1-af8b7f4b1d10"), "Combo 13", 30000m },
                    { new Guid("3861ea4f-d87f-484d-94ef-2cccb4b8ecf9"), "Combo 18", 80000m },
                    { new Guid("3f16beea-1950-48a1-82a7-c95c33d2b8d9"), "Combo 5", 50000m },
                    { new Guid("40a5337c-ce73-4b47-8cb7-a061d3f70125"), "Combo 17", 70000m },
                    { new Guid("41087295-a19f-4d28-8a1a-4de96d1d70a5"), "Combo 9", 90000m },
                    { new Guid("44b9a46d-06ff-45b6-a1a6-fce2f7361820"), "Combo 20", 0m },
                    { new Guid("44fc00aa-7130-4b05-bb12-7b3ced897cef"), "Combo 10", 0m },
                    { new Guid("4cf235ec-c410-44e6-a06c-a55787ee6bdb"), "Combo 25", 50000m },
                    { new Guid("4d2928cb-6654-42ae-8003-f2343e43c915"), "Combo 8", 80000m },
                    { new Guid("522dc73a-be6a-4f46-a1f1-b4832cb766b0"), "Combo 3", 30000m },
                    { new Guid("5c1b2601-4c47-4e24-ae34-131e61d7848f"), "Combo 29", 90000m },
                    { new Guid("5e3f757a-97ff-483d-b19a-cf19a0a888ea"), "Combo 30", 0m },
                    { new Guid("695f8cab-e858-4cbc-9a2f-016f96e06da2"), "Combo 19", 90000m },
                    { new Guid("74135726-baac-405a-bb60-0bf1a1bf8d31"), "Combo 22", 20000m },
                    { new Guid("795acb70-bbee-4c93-8753-bf83674d48de"), "Combo 11", 10000m },
                    { new Guid("798636e9-055b-4a19-b481-cef8fa663a89"), "Combo 26", 60000m },
                    { new Guid("82b5054f-39fa-4648-8b06-abac3197d5a6"), "Combo 21", 10000m },
                    { new Guid("8380315e-0fc7-4b4e-9fbb-8fdb36f6abc1"), "Combo 23", 30000m },
                    { new Guid("95ea243b-b7a6-4485-81d4-02f609085436"), "Combo 2", 20000m },
                    { new Guid("988db1a1-7d2e-446b-b153-dc2d6a76e2ad"), "Combo 15", 50000m },
                    { new Guid("a3649859-36f7-48ac-b40b-618921e0c506"), "Combo 16", 60000m },
                    { new Guid("b9684d6e-ad0a-4d2b-917d-f0381fa4bc15"), "Combo 24", 40000m },
                    { new Guid("cbe8fb78-964e-459a-89be-d4dd646b74cf"), "Combo 12", 20000m },
                    { new Guid("d1f0c4e1-1069-4677-9f15-b0d99133ead7"), "Combo 14", 40000m },
                    { new Guid("e08fb162-e3b5-48ef-afc6-a9cf6b61e762"), "Combo 1", 10000m }
                });

            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "Id", "Cast", "CreatDate", "Description", "Director", "EnglishName", "Gerne", "Language", "Name", "Nation", "Poster", "Rating", "ReleaseYear", "RunningTime", "ScreenTypeId", "StartDate", "Status", "Trailer", "TranslationTypeId" },
                values: new object[,]
                {
                    { new Guid("15ea680c-f25f-4783-b0c6-dac184a892fc"), "Actor 2, Actress 2", new DateTime(2023, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 2.", "Director 2", "Film 2 (English)", "Action", "English", "Film 2", "USA", "https://example.com/poster2.jpg", 3, 2023, 62, new Guid("76638c53-482b-4d65-a01f-1f0fa1922f0f"), new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer2.mp4", new Guid("bd2f2b0c-7ce8-4034-ab0c-4f95329f370d") },
                    { new Guid("18203774-8f6d-4b91-a453-8e3564a11516"), "Actor 24, Actress 24", new DateTime(2023, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 24.", "Director 24", "Film 24 (English)", "Action", "English", "Film 24", "USA", "https://example.com/poster24.jpg", 5, 2023, 84, new Guid("57a0ce50-c377-47c9-a3d9-46155204d57d"), new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer24.mp4", new Guid("d5f66519-d4d5-48a2-8253-f850a9445179") },
                    { new Guid("1b5802ad-34d6-4ae3-ace8-54910cad7e15"), "Actor 29, Actress 29", new DateTime(2023, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 29.", "Director 29", "Film 29 (English)", "Comedy", "Japanese", "Film 29", "Japan", "https://example.com/poster29.jpg", 5, 2023, 89, new Guid("10f8a514-5809-4104-b43b-d9ecc27bd6e4"), new DateTime(2023, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer29.mp4", new Guid("9665a31e-84ef-4b54-b181-2dedbd1334c1") },
                    { new Guid("1fb6d897-0e19-4a58-b94f-17f8e1bda52f"), "Actor 16, Actress 16", new DateTime(2023, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 16.", "Director 16", "Film 16 (English)", "Action", "English", "Film 16", "USA", "https://example.com/poster16.jpg", 2, 2023, 76, new Guid("4a4ff5f0-e4d4-4691-bbd3-613c3f11c94f"), new DateTime(2023, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer16.mp4", new Guid("d14a4109-da6c-4a11-a914-0b8a96e787b4") },
                    { new Guid("2622e587-aacc-4e0c-be05-aa7871bd925f"), "Actor 18, Actress 18", new DateTime(2023, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 18.", "Director 18", "Film 18 (English)", "Action", "English", "Film 18", "USA", "https://example.com/poster18.jpg", 4, 2023, 78, new Guid("e36ffa97-2c1d-4421-9888-77f172c4cbb5"), new DateTime(2023, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer18.mp4", new Guid("e0bda852-f764-485c-abb4-0ea7d6e69ab9") },
                    { new Guid("2d7946f4-d97b-4644-9a51-8e021449568d"), "Actor 1, Actress 1", new DateTime(2023, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 1.", "Director 1", "Film 1 (English)", "Comedy", "Japanese", "Film 1", "Japan", "https://example.com/poster1.jpg", 2, 2023, 61, new Guid("facfbfbb-740c-44ca-a39d-a6841035cd44"), new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer1.mp4", new Guid("f823ed01-85c9-41e5-81db-5b5c3a480de6") },
                    { new Guid("2e15de8e-0e6d-4eb9-9698-48e79b3fa7aa"), "Actor 10, Actress 10", new DateTime(2023, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 10.", "Director 10", "Film 10 (English)", "Action", "English", "Film 10", "USA", "https://example.com/poster10.jpg", 1, 2023, 70, new Guid("473294ff-de8a-4f54-bcaa-8bdc3773ac8a"), new DateTime(2023, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer10.mp4", new Guid("1ce10357-c5d2-4044-a965-4575b31b456a") },
                    { new Guid("33861c2c-20c4-4cca-affe-e38a43ea0949"), "Actor 30, Actress 30", new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 30.", "Director 30", "Film 30 (English)", "Action", "English", "Film 30", "USA", "https://example.com/poster30.jpg", 1, 2023, 90, new Guid("073163e1-2eff-46dd-ba7f-fc177f49b521"), new DateTime(2023, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer30.mp4", new Guid("81dc993d-7e68-4d40-953e-02e30cf7fcc9") },
                    { new Guid("387438f2-c3bb-459d-8562-faa9b8b1a9e3"), "Actor 11, Actress 11", new DateTime(2023, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 11.", "Director 11", "Film 11 (English)", "Comedy", "Japanese", "Film 11", "Japan", "https://example.com/poster11.jpg", 2, 2023, 71, new Guid("d4e8c34a-97d4-42f3-a343-97134f19821b"), new DateTime(2023, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer11.mp4", new Guid("489fc1f9-d8d2-4ec7-9300-13bd4cbf7f01") },
                    { new Guid("3cb9a15e-11a0-40a0-a299-6fbefc94d227"), "Actor 14, Actress 14", new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 14.", "Director 14", "Film 14 (English)", "Action", "English", "Film 14", "USA", "https://example.com/poster14.jpg", 5, 2023, 74, new Guid("0d47d447-2158-48d5-83ea-93e3d7c79f3c"), new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer14.mp4", new Guid("34a480e0-19d7-48d4-a8eb-5c8165956e13") },
                    { new Guid("477ad6c0-5e29-4d10-b89b-38a77fb7ece0"), "Actor 25, Actress 25", new DateTime(2023, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 25.", "Director 25", "Film 25 (English)", "Comedy", "Japanese", "Film 25", "Japan", "https://example.com/poster25.jpg", 1, 2023, 85, new Guid("70de4888-0d7b-46f2-b4b1-c50bba11d894"), new DateTime(2023, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer25.mp4", new Guid("24dec72c-958c-45e8-a12c-fd2d957cb95f") },
                    { new Guid("4b1207d1-4438-48a1-b15b-b58fbaa3ca59"), "Actor 20, Actress 20", new DateTime(2023, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 20.", "Director 20", "Film 20 (English)", "Action", "English", "Film 20", "USA", "https://example.com/poster20.jpg", 1, 2023, 80, new Guid("304bd6e1-8bdf-41e3-9501-13d454dac6d1"), new DateTime(2023, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer20.mp4", new Guid("b81e575d-d492-45a7-954f-ffeef8c3c469") },
                    { new Guid("5be62d8c-d94b-4aa3-b034-e74715858b7c"), "Actor 9, Actress 9", new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 9.", "Director 9", "Film 9 (English)", "Comedy", "Japanese", "Film 9", "Japan", "https://example.com/poster9.jpg", 5, 2023, 69, new Guid("222f58cb-c245-45cf-afa2-dfc4b166527c"), new DateTime(2023, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer9.mp4", new Guid("7dd88c46-54b1-417b-a954-3ddf1b9f6443") },
                    { new Guid("61e77182-312f-4d0d-b063-07bd94c0aa1f"), "Actor 6, Actress 6", new DateTime(2023, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 6.", "Director 6", "Film 6 (English)", "Action", "English", "Film 6", "USA", "https://example.com/poster6.jpg", 2, 2023, 66, new Guid("2235bdbe-599d-4d5e-bb48-176ff9149f59"), new DateTime(2023, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer6.mp4", new Guid("51e93c09-6fb7-4c0c-b179-3fef4453403b") },
                    { new Guid("670c2599-60f5-462e-8ffb-b42e0c2a57a8"), "Actor 21, Actress 21", new DateTime(2023, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 21.", "Director 21", "Film 21 (English)", "Comedy", "Japanese", "Film 21", "Japan", "https://example.com/poster21.jpg", 2, 2023, 81, new Guid("97c307b8-ec59-4bd9-b2b7-d04e0b878488"), new DateTime(2023, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer21.mp4", new Guid("24dcb2ac-ffd9-4de0-a17a-2b87546e123b") },
                    { new Guid("691c42e3-7115-4c60-9f96-d1e6c67bad20"), "Actor 28, Actress 28", new DateTime(2023, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 28.", "Director 28", "Film 28 (English)", "Action", "English", "Film 28", "USA", "https://example.com/poster28.jpg", 4, 2023, 88, new Guid("bb7cd4ce-5093-4b17-9e57-49763bc54582"), new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer28.mp4", new Guid("9c5257d0-4aee-431f-8747-b87080fb72c4") },
                    { new Guid("707942bc-5502-4275-85f9-38b8f43a9b93"), "Actor 5, Actress 5", new DateTime(2023, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 5.", "Director 5", "Film 5 (English)", "Comedy", "Japanese", "Film 5", "Japan", "https://example.com/poster5.jpg", 1, 2023, 65, new Guid("50f67e16-7e72-4212-bdb9-b356c448a7e5"), new DateTime(2023, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer5.mp4", new Guid("f7ab3e54-63de-47e7-985e-c616afeb6872") },
                    { new Guid("7dcd5c8a-603e-497b-b70e-1d7ddd70d2d9"), "Actor 23, Actress 23", new DateTime(2023, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 23.", "Director 23", "Film 23 (English)", "Comedy", "Japanese", "Film 23", "Japan", "https://example.com/poster23.jpg", 4, 2023, 83, new Guid("11c71429-773e-4414-bcdd-66b43087e430"), new DateTime(2023, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer23.mp4", new Guid("6ff34abd-b7ff-4080-a546-3d1619150c49") },
                    { new Guid("87242ad3-7da5-4e0a-b697-1afa008f5f7d"), "Actor 12, Actress 12", new DateTime(2023, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 12.", "Director 12", "Film 12 (English)", "Action", "English", "Film 12", "USA", "https://example.com/poster12.jpg", 3, 2023, 72, new Guid("8a51cdb8-c7c7-453e-a798-394e7157dbb5"), new DateTime(2023, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer12.mp4", new Guid("173e80df-bbfb-4d80-9b1d-8466bebccb21") },
                    { new Guid("8be9d148-5ee0-495d-98eb-27508df0e1b2"), "Actor 13, Actress 13", new DateTime(2023, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 13.", "Director 13", "Film 13 (English)", "Comedy", "Japanese", "Film 13", "Japan", "https://example.com/poster13.jpg", 4, 2023, 73, new Guid("5c0bfd09-c3c5-42a3-b874-8d17fd72ae3c"), new DateTime(2023, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer13.mp4", new Guid("1e698fb6-d520-48b3-a8ce-576cdc3531b2") },
                    { new Guid("8ed31605-81b0-48b4-a5d0-4de68ff66fc8"), "Actor 8, Actress 8", new DateTime(2023, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 8.", "Director 8", "Film 8 (English)", "Action", "English", "Film 8", "USA", "https://example.com/poster8.jpg", 4, 2023, 68, new Guid("7725d298-115e-456b-b2a2-f3b3204b3ef8"), new DateTime(2023, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer8.mp4", new Guid("6dc708a6-5a4e-4159-a38f-245f9219d68e") },
                    { new Guid("98483443-68c5-4865-9e45-cce31b831ee7"), "Actor 7, Actress 7", new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 7.", "Director 7", "Film 7 (English)", "Comedy", "Japanese", "Film 7", "Japan", "https://example.com/poster7.jpg", 3, 2023, 67, new Guid("ecff2241-f948-46f2-b014-8c691e3734ad"), new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer7.mp4", new Guid("5ff5353b-6435-459f-8b8c-577ea3b52043") },
                    { new Guid("9bb9c728-540c-4808-b348-d9f369431edf"), "Actor 17, Actress 17", new DateTime(2023, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 17.", "Director 17", "Film 17 (English)", "Comedy", "Japanese", "Film 17", "Japan", "https://example.com/poster17.jpg", 3, 2023, 77, new Guid("d55dc0da-13d6-465d-8ca6-ff5611a5d0d8"), new DateTime(2023, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer17.mp4", new Guid("bc942488-6a00-4350-b022-ab7e49bb8d8a") },
                    { new Guid("b62e5c5a-fd67-43a4-b3b3-f8fd3aaf1c80"), "Actor 27, Actress 27", new DateTime(2023, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 27.", "Director 27", "Film 27 (English)", "Comedy", "Japanese", "Film 27", "Japan", "https://example.com/poster27.jpg", 3, 2023, 87, new Guid("117f1474-1c75-4447-b1bd-083c40ff771d"), new DateTime(2023, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer27.mp4", new Guid("25e6b7be-d9d2-4f94-8db7-379cf904befa") },
                    { new Guid("c157dcbc-c29d-4152-9d56-10ba1a1c555e"), "Actor 26, Actress 26", new DateTime(2023, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 26.", "Director 26", "Film 26 (English)", "Action", "English", "Film 26", "USA", "https://example.com/poster26.jpg", 2, 2023, 86, new Guid("05681ff7-a75c-453a-9a02-f0f5949cc867"), new DateTime(2023, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer26.mp4", new Guid("23dbbd6a-a675-470a-bd7d-aec73fbbc7a4") },
                    { new Guid("d0ca15f9-5f06-4c64-b8f8-87c273a7f1df"), "Actor 22, Actress 22", new DateTime(2023, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 22.", "Director 22", "Film 22 (English)", "Action", "English", "Film 22", "USA", "https://example.com/poster22.jpg", 3, 2023, 82, new Guid("fbbe1049-3e65-4799-9562-3608eed7f98b"), new DateTime(2023, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer22.mp4", new Guid("89638a08-4392-432c-9e47-97b9021dd6b0") },
                    { new Guid("daa9b891-acd1-4476-a67d-8e2c8594dd70"), "Actor 3, Actress 3", new DateTime(2023, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 3.", "Director 3", "Film 3 (English)", "Comedy", "Japanese", "Film 3", "Japan", "https://example.com/poster3.jpg", 4, 2023, 63, new Guid("897e007e-28f5-4f9f-9ca1-5884fa744a0b"), new DateTime(2023, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer3.mp4", new Guid("514e170e-3fc3-4fb7-a70d-248ff622db67") },
                    { new Guid("eed60bb2-bde9-451d-b9d7-bc41e9cd0dff"), "Actor 4, Actress 4", new DateTime(2023, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 4.", "Director 4", "Film 4 (English)", "Action", "English", "Film 4", "USA", "https://example.com/poster4.jpg", 5, 2023, 64, new Guid("84a67d40-d9cb-494a-855d-d09a54edb67e"), new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer4.mp4", new Guid("a195498d-b891-4d1d-a588-82bb95a29932") },
                    { new Guid("f290ad85-33a1-49c1-945b-5f3285c8b85f"), "Actor 15, Actress 15", new DateTime(2023, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 15.", "Director 15", "Film 15 (English)", "Comedy", "Japanese", "Film 15", "Japan", "https://example.com/poster15.jpg", 1, 2023, 75, new Guid("d773023c-e10e-47b4-9464-16806f3c3b5c"), new DateTime(2023, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer15.mp4", new Guid("ca1161bf-54a0-4095-babb-7c0ecd1e858a") },
                    { new Guid("f30d6d40-318c-44ff-b8ee-ad5893d5848f"), "Actor 19, Actress 19", new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 19.", "Director 19", "Film 19 (English)", "Comedy", "Japanese", "Film 19", "Japan", "https://example.com/poster19.jpg", 5, 2023, 79, new Guid("7828968a-107e-4857-8468-72108f7bfe3e"), new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer19.mp4", new Guid("49847653-5713-4e3d-aa76-a22bffac5ec0") }
                });

            migrationBuilder.InsertData(
                table: "Promotions",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("00f52c30-dc61-421d-93ea-ef70da91f942"), "Title 4" },
                    { new Guid("032a70ab-52a4-4ad4-8d7e-5ef93e1fc13c"), "Title 1" },
                    { new Guid("184e7f39-c2e1-4b80-a38b-8842e1a4193e"), "Title 21" },
                    { new Guid("2f89ee12-1f9f-46a6-8a67-ca7c8cd994f0"), "Title 10" },
                    { new Guid("348b7a73-64b1-443d-9c5b-c4d6b9aeb73c"), "Title 27" },
                    { new Guid("3e56585b-054a-4ef1-b807-115ab56d55fa"), "Title 2" },
                    { new Guid("48a6bf94-bcc6-4cf9-984b-619d1fd48914"), "Title 8" },
                    { new Guid("51e4493f-dede-4523-aea6-7483d2acd859"), "Title 12" },
                    { new Guid("5314055d-5653-4f4b-90fc-3fe5f537b095"), "Title 25" },
                    { new Guid("5ba33777-9152-4826-9fc0-41dc1004034b"), "Title 30" },
                    { new Guid("618ed6ea-874e-4c73-afd0-b5024f351446"), "Title 29" },
                    { new Guid("660d36be-1ac7-4409-bc53-664915068e23"), "Title 22" },
                    { new Guid("66fd6049-7493-44c4-829a-ed4296e66d52"), "Title 3" },
                    { new Guid("6d1e3aeb-9d83-4661-a5d4-d32e462ea3fc"), "Title 18" },
                    { new Guid("780ce2ca-3317-41d0-b565-7e2230f1e0ce"), "Title 26" },
                    { new Guid("7b980b4d-9da8-4a04-9ce5-4fe1372b9b23"), "Title 15" },
                    { new Guid("83f2b5e7-6a05-4973-b6cd-f107b3fa7c36"), "Title 13" },
                    { new Guid("87e52ba5-98f9-4dcf-b810-2f302e6f0921"), "Title 11" },
                    { new Guid("921192ee-f55c-425d-8a90-1107fe4cfcb4"), "Title 28" },
                    { new Guid("a523616b-a765-4fbb-915d-09ee49dfc130"), "Title 19" },
                    { new Guid("b49739cd-24a6-4f9c-b21d-29758dd6df49"), "Title 14" },
                    { new Guid("c10556e6-930f-487b-b42f-eb726dc57e32"), "Title 6" },
                    { new Guid("cdba0e38-7d60-4667-a202-b7410dc518a3"), "Title 17" },
                    { new Guid("cf9f8a13-06f2-499b-bc5c-a7e9b87721a9"), "Title 20" },
                    { new Guid("d2beb918-6f38-4987-b470-7ec9835acacc"), "Title 23" },
                    { new Guid("e00e7640-ebd4-43f7-8a12-4bdd6acb3681"), "Title 16" },
                    { new Guid("e5b42561-7d94-444c-8122-ad162b1f1440"), "Title 24" },
                    { new Guid("e6c1bf6a-a33d-42eb-8574-cd881592832f"), "Title 7" },
                    { new Guid("eacec79a-d80f-409e-8ffe-bff57fc40133"), "Title 9" },
                    { new Guid("ef98ebbb-f432-4a98-ab4a-1ab3fd41e7c7"), "Title 5" }
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
                    { new Guid("03750602-5cca-4329-80bd-d0ed6a5a3a66"), new Guid("b13fb8b8-493a-4c40-ae97-16323ed316d0"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 10, "Description for Cinema 26", 100, "Cinema 26", 10 },
                    { new Guid("0cb413ee-e9e5-4cad-9bed-9d659490aad2"), new Guid("62a2e1fa-43c1-4ff5-b51c-656fef64a200"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 10, "Description for Cinema 17", 100, "Cinema 17", 10 },
                    { new Guid("12a4eaed-ce54-4328-bff0-e973696566f1"), new Guid("6191e4d9-4d55-4410-8428-3961edbe4185"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 10, "Description for Cinema 5", 100, "Cinema 5", 10 },
                    { new Guid("17f5a4fd-6ccb-4152-a0b6-95476c5ac957"), new Guid("dbb23550-82be-4c2a-b475-1f720cc335a7"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 10, "Description for Cinema 24", 100, "Cinema 24", 10 },
                    { new Guid("2bdfe7d4-83a6-4c6a-9620-82ec071e8774"), new Guid("dbb23550-82be-4c2a-b475-1f720cc335a7"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 10, "Description for Cinema 3", 100, "Cinema 3", 10 },
                    { new Guid("35d0d5f6-4a8d-47a0-8e04-3085abcc6947"), new Guid("9768466f-9de7-4bfa-ae8c-f2edc449e19d"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 10, "Description for Cinema 25", 100, "Cinema 25", 10 },
                    { new Guid("457339ab-13e3-4b7c-b335-269455a39b6c"), new Guid("8655de78-b91e-40cf-9d24-5c5d0550549f"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 10, "Description for Cinema 4", 100, "Cinema 4", 10 },
                    { new Guid("486a1ae1-d8d0-436a-9442-9b24b61aaea1"), new Guid("6191e4d9-4d55-4410-8428-3961edbe4185"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 10, "Description for Cinema 6", 100, "Cinema 6", 10 },
                    { new Guid("4a19bbae-49e2-4c60-b47f-8d3ab4daccf5"), new Guid("3ca4db01-7d97-4f00-be09-c859f3e9b53e"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 10, "Description for Cinema 23", 100, "Cinema 23", 10 },
                    { new Guid("5b6a9398-fc9a-48e0-9dc6-8b6033f3af87"), new Guid("ce56e2a8-1ff2-4da1-9bf6-628412a7c18b"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 10, "Description for Cinema 10", 100, "Cinema 10", 10 },
                    { new Guid("5e84b441-48c0-4a13-b4ce-995fecbee655"), new Guid("8880ed6c-3729-433b-8ba7-a8135d1eda45"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 10, "Description for Cinema 27", 100, "Cinema 27", 10 },
                    { new Guid("64459955-7c25-4605-a74e-0bca83b5e391"), new Guid("8655de78-b91e-40cf-9d24-5c5d0550549f"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 10, "Description for Cinema 12", 100, "Cinema 12", 10 },
                    { new Guid("66f8366e-4be4-4bd8-9794-e65996d57874"), new Guid("2f1fa0d7-e22c-47af-b660-fa1d298a9495"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 10, "Description for Cinema 11", 100, "Cinema 11", 10 },
                    { new Guid("704c027f-40b5-4830-a784-a8389cf386d4"), new Guid("cb2ec087-4436-4ca0-97d2-fe03636cd27f"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 10, "Description for Cinema 30", 100, "Cinema 30", 10 },
                    { new Guid("70c0784a-d769-4bcd-834e-b62c07234447"), new Guid("50e2e2bf-5933-4c38-b81c-e31ab92b520a"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 10, "Description for Cinema 18", 100, "Cinema 18", 10 },
                    { new Guid("71ab8f6c-2124-4441-ba9a-da3c54e60cba"), new Guid("a076a4eb-8225-4347-b902-2a9669b1214b"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 10, "Description for Cinema 2", 100, "Cinema 2", 10 },
                    { new Guid("721793ca-c0a4-4947-a64c-56d7b0d5e3d0"), new Guid("ecb19868-0342-47e6-aba9-b0f2b0b31d47"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 10, "Description for Cinema 16", 100, "Cinema 16", 10 },
                    { new Guid("9643efc8-df9b-468a-917e-f74cc16c1793"), new Guid("b14bfb5d-d94d-49f5-a6c3-86fb1ea81700"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 10, "Description for Cinema 9", 100, "Cinema 9", 10 },
                    { new Guid("99316a7f-85ea-4bd2-8ab5-dba4c168ae97"), new Guid("b13fb8b8-493a-4c40-ae97-16323ed316d0"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 10, "Description for Cinema 22", 100, "Cinema 22", 10 },
                    { new Guid("a742a1d7-1fa0-44d7-a8ed-a62e785b499b"), new Guid("d4e3733f-6361-4eb7-96e2-2fab3c669c55"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 10, "Description for Cinema 8", 100, "Cinema 8", 10 },
                    { new Guid("ae7cff41-4cdf-4155-a666-48feec699547"), new Guid("63682607-5f68-4196-9068-22594670e0c8"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 10, "Description for Cinema 20", 100, "Cinema 20", 10 },
                    { new Guid("aef5dc7e-f47f-4a1b-9042-2db8f7a2d2f9"), new Guid("1149860d-7296-4eda-a172-30e2a1aec7bf"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 10, "Description for Cinema 28", 100, "Cinema 28", 10 },
                    { new Guid("b08802bf-ff56-4fb7-9a1b-a62fafd8308f"), new Guid("6191e4d9-4d55-4410-8428-3961edbe4185"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 10, "Description for Cinema 21", 100, "Cinema 21", 10 },
                    { new Guid("b994b42e-6896-4572-8e31-78fbe1edde21"), new Guid("50e2e2bf-5933-4c38-b81c-e31ab92b520a"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 10, "Description for Cinema 7", 100, "Cinema 7", 10 },
                    { new Guid("c2423d03-1e05-4839-8beb-cca0711e1df8"), new Guid("3ca4db01-7d97-4f00-be09-c859f3e9b53e"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 10, "Description for Cinema 1", 100, "Cinema 1", 10 },
                    { new Guid("d42d5fde-50bd-4558-ba09-3013f24faccc"), new Guid("62a2e1fa-43c1-4ff5-b51c-656fef64a200"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 10, "Description for Cinema 29", 100, "Cinema 29", 10 },
                    { new Guid("d6d95904-716e-400c-a7eb-48108d088c35"), new Guid("5f836cb6-c3e4-4480-8ed9-4322f7fe29d3"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 10, "Description for Cinema 13", 100, "Cinema 13", 10 },
                    { new Guid("e4408554-3141-4e15-bb2b-c2fe6855617f"), new Guid("6191e4d9-4d55-4410-8428-3961edbe4185"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 10, "Description for Cinema 14", 100, "Cinema 14", 10 },
                    { new Guid("f0fdf3ce-c6ea-4778-a26a-7cbfff6b7027"), new Guid("b14bfb5d-d94d-49f5-a6c3-86fb1ea81700"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 10, "Description for Cinema 15", 100, "Cinema 15", 10 },
                    { new Guid("f35843d9-e482-44a8-8c84-102748bb7efa"), new Guid("63682607-5f68-4196-9068-22594670e0c8"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 10, "Description for Cinema 19", 100, "Cinema 19", 10 }
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
                    { new Guid("0f0c4d20-61e1-42db-bbb4-1a07534e643a"), new DateTime(2023, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("18203774-8f6d-4b91-a453-8e3564a11516"), new DateTime(2023, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { new Guid("0f26eda0-362d-4de3-9d39-666f41bd6442"), new DateTime(2023, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3cb9a15e-11a0-40a0-a299-6fbefc94d227"), new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { new Guid("1223ae4d-9847-4309-a012-6852dc75db71"), new DateTime(2023, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2e15de8e-0e6d-4eb9-9698-48e79b3fa7aa"), new DateTime(2023, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0 },
                    { new Guid("1bf04a1e-1879-4157-976f-cb649e33215a"), new DateTime(2023, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7dcd5c8a-603e-497b-b70e-1d7ddd70d2d9"), new DateTime(2023, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { new Guid("1d633646-3828-4f68-97b8-1f70657b5d93"), new DateTime(2023, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("15ea680c-f25f-4783-b0c6-dac184a892fc"), new DateTime(2023, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0 },
                    { new Guid("237f5ae7-85c1-4476-a0e2-ab91f6092134"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33861c2c-20c4-4cca-affe-e38a43ea0949"), new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { new Guid("275a48c5-9c29-4321-b606-bf1521554bed"), new DateTime(2023, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b62e5c5a-fd67-43a4-b3b3-f8fd3aaf1c80"), new DateTime(2023, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { new Guid("2a3fb7a4-78d9-4d1f-98a5-2bfb356bb752"), new DateTime(2023, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f30d6d40-318c-44ff-b8ee-ad5893d5848f"), new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { new Guid("3e3ae13e-686a-4341-9298-6ebe13265eea"), new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8ed31605-81b0-48b4-a5d0-4de68ff66fc8"), new DateTime(2023, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { new Guid("401b6ca5-eed1-4f6a-b499-291c5e70e5c3"), new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8be9d148-5ee0-495d-98eb-27508df0e1b2"), new DateTime(2023, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0 },
                    { new Guid("41765552-2a04-42c8-93f6-918c3310eecd"), new DateTime(2023, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("387438f2-c3bb-459d-8562-faa9b8b1a9e3"), new DateTime(2023, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0 },
                    { new Guid("4d0cd848-59fb-4cc1-b1bc-2515bd74c14a"), new DateTime(2023, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("1fb6d897-0e19-4a58-b94f-17f8e1bda52f"), new DateTime(2023, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0 },
                    { new Guid("4f3f144f-30e6-4085-8141-00b1e32a2ba6"), new DateTime(2023, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f290ad85-33a1-49c1-945b-5f3285c8b85f"), new DateTime(2023, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { new Guid("5146be02-ea42-4b62-968a-bbb9e7462986"), new DateTime(2023, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c157dcbc-c29d-4152-9d56-10ba1a1c555e"), new DateTime(2023, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0 },
                    { new Guid("581e38dd-e034-4b75-bdec-95c6472eb95c"), new DateTime(2023, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("707942bc-5502-4275-85f9-38b8f43a9b93"), new DateTime(2023, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { new Guid("645157a6-6d07-4f81-8972-27b4caa39ec2"), new DateTime(2023, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("477ad6c0-5e29-4d10-b89b-38a77fb7ece0"), new DateTime(2023, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { new Guid("67b60c90-ef1b-44fd-8f1a-4a8b915e5d4b"), new DateTime(2023, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d0ca15f9-5f06-4c64-b8f8-87c273a7f1df"), new DateTime(2023, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { new Guid("68e2199a-dcf3-44e3-9d9a-8350879c42a8"), new DateTime(2023, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("87242ad3-7da5-4e0a-b697-1afa008f5f7d"), new DateTime(2023, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0 },
                    { new Guid("6a29c2be-9c33-43ab-b0f9-92dd759f8e55"), new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("61e77182-312f-4d0d-b063-07bd94c0aa1f"), new DateTime(2023, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { new Guid("76f226b3-83d4-4099-88de-5212b4a7411e"), new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("1b5802ad-34d6-4ae3-ace8-54910cad7e15"), new DateTime(2023, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { new Guid("7b78679c-82a9-4878-9d4e-2f94bdee27e8"), new DateTime(2023, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("670c2599-60f5-462e-8ffb-b42e0c2a57a8"), new DateTime(2023, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { new Guid("7c7a360a-a590-4a29-9eaa-c03083afba16"), new DateTime(2023, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("98483443-68c5-4865-9e45-cce31b831ee7"), new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0 },
                    { new Guid("813bdd3f-c082-46e2-b527-321d1e5c5ce9"), new DateTime(2023, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("daa9b891-acd1-4476-a67d-8e2c8594dd70"), new DateTime(2023, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { new Guid("8f801f2d-ff82-4d73-aa41-1bd35f808a76"), new DateTime(2023, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("9bb9c728-540c-4808-b348-d9f369431edf"), new DateTime(2023, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { new Guid("8fa7ddae-f00d-4694-9d31-c141c8e044cd"), new DateTime(2023, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("691c42e3-7115-4c60-9f96-d1e6c67bad20"), new DateTime(2023, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { new Guid("90f03fa7-9afe-401c-ae8b-176398c1fa05"), new DateTime(2023, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4b1207d1-4438-48a1-b15b-b58fbaa3ca59"), new DateTime(2023, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { new Guid("96a8f600-f6e6-4bcd-86d4-ddf63c18b1b3"), new DateTime(2023, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2d7946f4-d97b-4644-9a51-8e021449568d"), new DateTime(2023, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { new Guid("9f91099f-06c1-4a13-b87a-8f83aee0f885"), new DateTime(2023, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("eed60bb2-bde9-451d-b9d7-bc41e9cd0dff"), new DateTime(2023, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { new Guid("d1c8b2f7-bfe4-4200-b126-1d79db71f33b"), new DateTime(2023, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5be62d8c-d94b-4aa3-b034-e74715858b7c"), new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { new Guid("e26ea3c7-ec61-428d-a968-636e706a751f"), new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2622e587-aacc-4e0c-be05-aa7871bd925f"), new DateTime(2023, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 }
                });

            migrationBuilder.InsertData(
                table: "TicketPrices",
                columns: new[] { "Id", "CinemaTypeId", "Price", "ScreenTypeId", "ScreeningDayId", "SeatTypeId", "Status" },
                values: new object[,]
                {
                    { new Guid("111577b4-6464-4ae7-8cbe-f0e310d2061c"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 40000m, new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("d997b27a-ddb7-4ad1-a1cd-c2bd00c50cb9"), 0 },
                    { new Guid("19596da7-e597-41af-9484-8653f7e834c1"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 30000m, new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new Guid("e4f8f494-4e25-4966-806a-7b8843d79b6b"), new Guid("d997b27a-ddb7-4ad1-a1cd-c2bd00c50cb9"), 0 },
                    { new Guid("1f05ede6-c584-4c92-b1e9-0f43a12c0527"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 60000m, new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new Guid("d51bee9b-54c3-4a3c-a06a-7c3940852f57"), new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 0 },
                    { new Guid("22698a56-2859-42a3-a9ac-23a9f0ca2f92"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 90000m, new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new Guid("e4f8f494-4e25-4966-806a-7b8843d79b6b"), new Guid("428edc6b-0862-4623-b038-ac505fd554bc"), 0 },
                    { new Guid("29860250-de36-457c-9ca8-f43582abf446"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 70000m, new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("d997b27a-ddb7-4ad1-a1cd-c2bd00c50cb9"), 0 },
                    { new Guid("2ffe15e8-9ab0-457f-a178-dd803349c80f"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 40000m, new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("d997b27a-ddb7-4ad1-a1cd-c2bd00c50cb9"), 0 },
                    { new Guid("3209a4c9-63f0-44b0-a020-1ce7e05ba175"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 50000m, new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("d997b27a-ddb7-4ad1-a1cd-c2bd00c50cb9"), 0 },
                    { new Guid("382982ca-6cc3-4750-96ca-8fb28cfed75d"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 40000m, new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new Guid("d51bee9b-54c3-4a3c-a06a-7c3940852f57"), new Guid("428edc6b-0862-4623-b038-ac505fd554bc"), 0 },
                    { new Guid("39dd55df-da26-403a-91da-ab76772c1f42"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 60000m, new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("428edc6b-0862-4623-b038-ac505fd554bc"), 0 },
                    { new Guid("3e8e89cf-d6e3-474f-b98d-1f61f5c133c6"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 50000m, new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 0 },
                    { new Guid("4168b29c-388f-4d1e-af46-1740520d4fa6"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 0m, new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 0 },
                    { new Guid("6a86fc3e-4fe8-4054-8177-9f241d8a3d07"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 50000m, new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new Guid("d51bee9b-54c3-4a3c-a06a-7c3940852f57"), new Guid("428edc6b-0862-4623-b038-ac505fd554bc"), 0 },
                    { new Guid("6aa09211-95ed-408f-803a-ee575f1d522a"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 90000m, new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("d997b27a-ddb7-4ad1-a1cd-c2bd00c50cb9"), 0 },
                    { new Guid("70f72910-3a89-439b-beff-00661e7d40e8"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 20000m, new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new Guid("e4f8f494-4e25-4966-806a-7b8843d79b6b"), new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 0 },
                    { new Guid("716d112e-53da-4cba-88c9-a830a1069cf1"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 0m, new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 0 },
                    { new Guid("8a43143e-c4a2-4df2-8b90-bfb2629f7ad1"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 90000m, new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("d997b27a-ddb7-4ad1-a1cd-c2bd00c50cb9"), 0 },
                    { new Guid("8b34b800-4e30-4d60-b6ab-ddb188d024a8"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 60000m, new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new Guid("d51bee9b-54c3-4a3c-a06a-7c3940852f57"), new Guid("428edc6b-0862-4623-b038-ac505fd554bc"), 0 },
                    { new Guid("8cdb5cff-8a4e-4e70-b8f4-211bbace8fe6"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 80000m, new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new Guid("e4f8f494-4e25-4966-806a-7b8843d79b6b"), new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 0 },
                    { new Guid("a0642981-6345-46a2-9e69-1a675c3806e6"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 10000m, new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new Guid("e4f8f494-4e25-4966-806a-7b8843d79b6b"), new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 0 },
                    { new Guid("aa1eaccd-f685-446c-ab8e-1f8f38414b1d"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 10000m, new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new Guid("e4f8f494-4e25-4966-806a-7b8843d79b6b"), new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 0 },
                    { new Guid("adb4b220-4f55-4228-bd03-c4f355e80691"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 70000m, new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new Guid("d51bee9b-54c3-4a3c-a06a-7c3940852f57"), new Guid("d997b27a-ddb7-4ad1-a1cd-c2bd00c50cb9"), 0 },
                    { new Guid("b38bb672-259c-439c-aa1b-bacc94485341"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 30000m, new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("d997b27a-ddb7-4ad1-a1cd-c2bd00c50cb9"), 0 },
                    { new Guid("b84371a5-90ba-4790-aeaa-bc764fbb95a1"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 70000m, new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new Guid("e4f8f494-4e25-4966-806a-7b8843d79b6b"), new Guid("428edc6b-0862-4623-b038-ac505fd554bc"), 0 },
                    { new Guid("c0f10563-c2d7-47df-bd06-5b0dc9837533"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 30000m, new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new Guid("e4f8f494-4e25-4966-806a-7b8843d79b6b"), new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 0 },
                    { new Guid("c26a6650-5343-45b1-8552-d68c28fd77c8"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 80000m, new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new Guid("e4f8f494-4e25-4966-806a-7b8843d79b6b"), new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 0 },
                    { new Guid("c2c93b45-2ce5-4518-aab3-7588423bca5b"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 20000m, new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new Guid("d51bee9b-54c3-4a3c-a06a-7c3940852f57"), new Guid("d997b27a-ddb7-4ad1-a1cd-c2bd00c50cb9"), 0 },
                    { new Guid("cb640451-6b8f-4438-bbcb-4a39d8bd7663"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 10000m, new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new Guid("d51bee9b-54c3-4a3c-a06a-7c3940852f57"), new Guid("428edc6b-0862-4623-b038-ac505fd554bc"), 0 },
                    { new Guid("cf606375-fe34-42d2-a802-bbebd3c5f29c"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 80000m, new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new Guid("d51bee9b-54c3-4a3c-a06a-7c3940852f57"), new Guid("d997b27a-ddb7-4ad1-a1cd-c2bd00c50cb9"), 0 },
                    { new Guid("e59f831c-6598-4944-982e-f0d9b8b96a03"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 0m, new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new Guid("d51bee9b-54c3-4a3c-a06a-7c3940852f57"), new Guid("428edc6b-0862-4623-b038-ac505fd554bc"), 0 },
                    { new Guid("fc67734a-73c3-4471-9a32-56d86a27f796"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 20000m, new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("428edc6b-0862-4623-b038-ac505fd554bc"), 0 }
                });

            migrationBuilder.InsertData(
                table: "ShowTimes",
                columns: new[] { "Id", "CinemaCenterId", "CinemaId", "Desciption", "EndTime", "FilmId", "ScheduleId", "ScreenTypeId", "StartTime", "Status", "TranslationTypeId" },
                values: new object[,]
                {
                    { new Guid("02effd43-ec4b-484f-8622-b56472c08e94"), new Guid("5f836cb6-c3e4-4480-8ed9-4322f7fe29d3"), new Guid("0cb413ee-e9e5-4cad-9bed-9d659490aad2"), "Description for ShowTime 5", new DateTime(2023, 8, 6, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("707942bc-5502-4275-85f9-38b8f43a9b93"), new Guid("581e38dd-e034-4b75-bdec-95c6472eb95c"), new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new DateTime(2023, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("03b00500-d8d0-42a1-ab98-b8b92e3e6f33"), new Guid("2f1fa0d7-e22c-47af-b660-fa1d298a9495"), new Guid("c2423d03-1e05-4839-8beb-cca0711e1df8"), "Description for ShowTime 14", new DateTime(2023, 8, 15, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3cb9a15e-11a0-40a0-a299-6fbefc94d227"), new Guid("0f26eda0-362d-4de3-9d39-666f41bd6442"), new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("081999dd-a087-454e-b3f0-0d503d76c012"), new Guid("3ca4db01-7d97-4f00-be09-c859f3e9b53e"), new Guid("71ab8f6c-2124-4441-ba9a-da3c54e60cba"), "Description for ShowTime 3", new DateTime(2023, 8, 4, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("daa9b891-acd1-4476-a67d-8e2c8594dd70"), new Guid("813bdd3f-c082-46e2-b527-321d1e5c5ce9"), new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new DateTime(2023, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("10362d7a-8b57-435f-a258-29ca61f7f6d0"), new Guid("62a2e1fa-43c1-4ff5-b51c-656fef64a200"), new Guid("9643efc8-df9b-468a-917e-f74cc16c1793"), "Description for ShowTime 12", new DateTime(2023, 8, 13, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("87242ad3-7da5-4e0a-b697-1afa008f5f7d"), new Guid("68e2199a-dcf3-44e3-9d9a-8350879c42a8"), new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new DateTime(2023, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("15852e3b-93cb-49b7-9d0c-91be5cdf4971"), new Guid("33126158-0ed1-4a83-9e57-4539e019d24f"), new Guid("b08802bf-ff56-4fb7-9a1b-a62fafd8308f"), "Description for ShowTime 17", new DateTime(2023, 8, 18, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("9bb9c728-540c-4808-b348-d9f369431edf"), new Guid("8f801f2d-ff82-4d73-aa41-1bd35f808a76"), new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new DateTime(2023, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("2fb0a25a-75b4-4923-91c0-c521e8baf773"), new Guid("329708e0-8a62-4e35-8d51-b4e590fb9e99"), new Guid("c2423d03-1e05-4839-8beb-cca0711e1df8"), "Description for ShowTime 30", new DateTime(2023, 8, 31, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33861c2c-20c4-4cca-affe-e38a43ea0949"), new Guid("237f5ae7-85c1-4476-a0e2-ab91f6092134"), new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("46137a3e-0c5d-4c01-bc64-41e2e3343d0c"), new Guid("8904c38e-b5ca-4559-a8e7-6f194771321a"), new Guid("f0fdf3ce-c6ea-4778-a26a-7cbfff6b7027"), "Description for ShowTime 24", new DateTime(2023, 8, 25, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("18203774-8f6d-4b91-a453-8e3564a11516"), new Guid("0f0c4d20-61e1-42db-bbb4-1a07534e643a"), new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new DateTime(2023, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("4e6bd271-9d08-4395-b01d-ec52b9f96cb0"), new Guid("6191e4d9-4d55-4410-8428-3961edbe4185"), new Guid("17f5a4fd-6ccb-4152-a0b6-95476c5ac957"), "Description for ShowTime 20", new DateTime(2023, 8, 21, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4b1207d1-4438-48a1-b15b-b58fbaa3ca59"), new Guid("90f03fa7-9afe-401c-ae8b-176398c1fa05"), new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new DateTime(2023, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("5491b366-b8e4-492f-ad35-60d97947ba9e"), new Guid("8880ed6c-3729-433b-8ba7-a8135d1eda45"), new Guid("4a19bbae-49e2-4c60-b47f-8d3ab4daccf5"), "Description for ShowTime 25", new DateTime(2023, 8, 26, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("477ad6c0-5e29-4d10-b89b-38a77fb7ece0"), new Guid("645157a6-6d07-4f81-8972-27b4caa39ec2"), new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new DateTime(2023, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("6455a013-5676-46e1-aa15-a38945adcd2c"), new Guid("329708e0-8a62-4e35-8d51-b4e590fb9e99"), new Guid("71ab8f6c-2124-4441-ba9a-da3c54e60cba"), "Description for ShowTime 19", new DateTime(2023, 8, 20, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f30d6d40-318c-44ff-b8ee-ad5893d5848f"), new Guid("2a3fb7a4-78d9-4d1f-98a5-2bfb356bb752"), new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("65e2aa07-3cc1-4b0e-abd0-5e419752f356"), new Guid("39aef27c-4151-4b11-aac5-b0574b20db21"), new Guid("03750602-5cca-4329-80bd-d0ed6a5a3a66"), "Description for ShowTime 4", new DateTime(2023, 8, 5, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("eed60bb2-bde9-451d-b9d7-bc41e9cd0dff"), new Guid("9f91099f-06c1-4a13-b87a-8f83aee0f885"), new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new DateTime(2023, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("6e8b710a-06ec-407b-a5da-3692bf322e2f"), new Guid("329708e0-8a62-4e35-8d51-b4e590fb9e99"), new Guid("5b6a9398-fc9a-48e0-9dc6-8b6033f3af87"), "Description for ShowTime 13", new DateTime(2023, 8, 14, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8be9d148-5ee0-495d-98eb-27508df0e1b2"), new Guid("401b6ca5-eed1-4f6a-b499-291c5e70e5c3"), new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new DateTime(2023, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("72c8e567-9af2-4134-bc95-b6a32d38f670"), new Guid("39aef27c-4151-4b11-aac5-b0574b20db21"), new Guid("2bdfe7d4-83a6-4c6a-9620-82ec071e8774"), "Description for ShowTime 1", new DateTime(2023, 8, 2, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2d7946f4-d97b-4644-9a51-8e021449568d"), new Guid("96a8f600-f6e6-4bcd-86d4-ddf63c18b1b3"), new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new DateTime(2023, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("75cc5e32-9c09-47cd-9001-99499ce11cec"), new Guid("8904c38e-b5ca-4559-a8e7-6f194771321a"), new Guid("721793ca-c0a4-4947-a64c-56d7b0d5e3d0"), "Description for ShowTime 6", new DateTime(2023, 8, 7, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("61e77182-312f-4d0d-b063-07bd94c0aa1f"), new Guid("6a29c2be-9c33-43ab-b0f9-92dd759f8e55"), new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new DateTime(2023, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("81f59725-e748-476c-9d1b-21468638704e"), new Guid("33126158-0ed1-4a83-9e57-4539e019d24f"), new Guid("e4408554-3141-4e15-bb2b-c2fe6855617f"), "Description for ShowTime 11", new DateTime(2023, 8, 12, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("387438f2-c3bb-459d-8562-faa9b8b1a9e3"), new Guid("41765552-2a04-42c8-93f6-918c3310eecd"), new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new DateTime(2023, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("85d55b28-1e34-4812-892d-4516f2d3436a"), new Guid("39aef27c-4151-4b11-aac5-b0574b20db21"), new Guid("03750602-5cca-4329-80bd-d0ed6a5a3a66"), "Description for ShowTime 15", new DateTime(2023, 8, 16, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f290ad85-33a1-49c1-945b-5f3285c8b85f"), new Guid("4f3f144f-30e6-4085-8141-00b1e32a2ba6"), new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new DateTime(2023, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("863c527d-c4be-4d44-a5c6-ea9a124e0508"), new Guid("62a2e1fa-43c1-4ff5-b51c-656fef64a200"), new Guid("0cb413ee-e9e5-4cad-9bed-9d659490aad2"), "Description for ShowTime 9", new DateTime(2023, 8, 10, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5be62d8c-d94b-4aa3-b034-e74715858b7c"), new Guid("d1c8b2f7-bfe4-4200-b126-1d79db71f33b"), new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("9383a6b0-7cde-4a2b-b170-885f119adb60"), new Guid("5f836cb6-c3e4-4480-8ed9-4322f7fe29d3"), new Guid("486a1ae1-d8d0-436a-9442-9b24b61aaea1"), "Description for ShowTime 16", new DateTime(2023, 8, 17, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("1fb6d897-0e19-4a58-b94f-17f8e1bda52f"), new Guid("4d0cd848-59fb-4cc1-b1bc-2515bd74c14a"), new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new DateTime(2023, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("9e6d77ae-cfc9-4b78-8d2d-39a9426c3427"), new Guid("1149860d-7296-4eda-a172-30e2a1aec7bf"), new Guid("d42d5fde-50bd-4558-ba09-3013f24faccc"), "Description for ShowTime 2", new DateTime(2023, 8, 3, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("15ea680c-f25f-4783-b0c6-dac184a892fc"), new Guid("1d633646-3828-4f68-97b8-1f70657b5d93"), new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new DateTime(2023, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("abae06b4-0ff4-4410-95be-5c5ef4ca3646"), new Guid("5fd0d523-198b-4b9a-9a2a-66f181d99284"), new Guid("704c027f-40b5-4830-a784-a8389cf386d4"), "Description for ShowTime 29", new DateTime(2023, 8, 30, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("1b5802ad-34d6-4ae3-ace8-54910cad7e15"), new Guid("76f226b3-83d4-4099-88de-5212b4a7411e"), new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new DateTime(2023, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("b4845a19-62e4-45d2-8eb0-35d940f94303"), new Guid("8dc51421-b949-4586-a74c-dc1da16ccfed"), new Guid("64459955-7c25-4605-a74e-0bca83b5e391"), "Description for ShowTime 27", new DateTime(2023, 8, 28, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b62e5c5a-fd67-43a4-b3b3-f8fd3aaf1c80"), new Guid("275a48c5-9c29-4321-b606-bf1521554bed"), new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new DateTime(2023, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("ba35328b-c776-4c7c-9b84-9fcc56f460c8"), new Guid("ce56e2a8-1ff2-4da1-9bf6-628412a7c18b"), new Guid("4a19bbae-49e2-4c60-b47f-8d3ab4daccf5"), "Description for ShowTime 22", new DateTime(2023, 8, 23, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d0ca15f9-5f06-4c64-b8f8-87c273a7f1df"), new Guid("67b60c90-ef1b-44fd-8f1a-4a8b915e5d4b"), new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new DateTime(2023, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("cf1a776a-a3fe-4442-a721-61ac8c74f90f"), new Guid("5bf7c3c2-ba29-4c64-a740-0abe0c9bfcf5"), new Guid("e4408554-3141-4e15-bb2b-c2fe6855617f"), "Description for ShowTime 26", new DateTime(2023, 8, 27, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c157dcbc-c29d-4152-9d56-10ba1a1c555e"), new Guid("5146be02-ea42-4b62-968a-bbb9e7462986"), new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new DateTime(2023, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("cf2a014c-737c-40d1-9693-e119fc7d4bbd"), new Guid("8655de78-b91e-40cf-9d24-5c5d0550549f"), new Guid("71ab8f6c-2124-4441-ba9a-da3c54e60cba"), "Description for ShowTime 28", new DateTime(2023, 8, 29, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("691c42e3-7115-4c60-9f96-d1e6c67bad20"), new Guid("8fa7ddae-f00d-4694-9d31-c141c8e044cd"), new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new DateTime(2023, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("d2809f30-778f-4320-a340-57f8e0cf7fd3"), new Guid("50e2e2bf-5933-4c38-b81c-e31ab92b520a"), new Guid("a742a1d7-1fa0-44d7-a8ed-a62e785b499b"), "Description for ShowTime 8", new DateTime(2023, 8, 9, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8ed31605-81b0-48b4-a5d0-4de68ff66fc8"), new Guid("3e3ae13e-686a-4341-9298-6ebe13265eea"), new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new DateTime(2023, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("d5de679e-b7a4-441c-b614-5268da6c08f5"), new Guid("dbb23550-82be-4c2a-b475-1f720cc335a7"), new Guid("03750602-5cca-4329-80bd-d0ed6a5a3a66"), "Description for ShowTime 21", new DateTime(2023, 8, 22, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("670c2599-60f5-462e-8ffb-b42e0c2a57a8"), new Guid("7b78679c-82a9-4878-9d4e-2f94bdee27e8"), new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new DateTime(2023, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("d9d40b2f-facd-4193-af19-8f5ad27663a9"), new Guid("8655de78-b91e-40cf-9d24-5c5d0550549f"), new Guid("99316a7f-85ea-4bd2-8ab5-dba4c168ae97"), "Description for ShowTime 18", new DateTime(2023, 8, 19, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2622e587-aacc-4e0c-be05-aa7871bd925f"), new Guid("e26ea3c7-ec61-428d-a968-636e706a751f"), new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new DateTime(2023, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("da27f674-c386-4fc4-b8a3-aee110e26334"), new Guid("329708e0-8a62-4e35-8d51-b4e590fb9e99"), new Guid("03750602-5cca-4329-80bd-d0ed6a5a3a66"), "Description for ShowTime 7", new DateTime(2023, 8, 8, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("98483443-68c5-4865-9e45-cce31b831ee7"), new Guid("7c7a360a-a590-4a29-9eaa-c03083afba16"), new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("dab87038-7c1a-4a5e-a209-81afbda74aa2"), new Guid("23ebaf3c-5c97-4bd3-a539-c2555edebfa1"), new Guid("f35843d9-e482-44a8-8c84-102748bb7efa"), "Description for ShowTime 23", new DateTime(2023, 8, 24, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7dcd5c8a-603e-497b-b70e-1d7ddd70d2d9"), new Guid("1bf04a1e-1879-4157-976f-cb649e33215a"), new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new DateTime(2023, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("fc9e1e2d-3705-40a9-898d-d16b1709b0c3"), new Guid("5f836cb6-c3e4-4480-8ed9-4322f7fe29d3"), new Guid("9643efc8-df9b-468a-917e-f74cc16c1793"), "Description for ShowTime 10", new DateTime(2023, 8, 11, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2e15de8e-0e6d-4eb9-9698-48e79b3fa7aa"), new Guid("1223ae4d-9847-4309-a012-6852dc75db71"), new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new DateTime(2023, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") }
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
