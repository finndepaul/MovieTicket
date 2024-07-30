using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieTicket.Infrastructure.Migrations.MovieTicketReadWriteDb
{
    /// <inheritdoc />
    public partial class _2_30_7_2024 : Migration
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
                    { new Guid("001ed156-53e7-4417-bad8-6034ae0a34ce"), "Address 27", "avatar27.png", new DateTime(2023, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "user27@example.com", "User 27", "lePABwdtIg5MqkBgyFdL9Q==", "123-456-78927", 2, 1, "user27" },
                    { new Guid("202bcdd6-65f6-4e20-b036-42d850f7d6c7"), "Address 9", "avatar9.png", new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "user9@example.com", "User 9", "XLl70iIryQx+lE/y5900Uw==", "123-456-7899", 2, 1, "user9" },
                    { new Guid("220d932f-b608-43b4-ad92-1b5848b74086"), "Address 1", "avatar1.png", new DateTime(2023, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "user1@example.com", "User 1", "ei00xFxTj/yW/ErUUw1JvA==", "123-456-7891", 2, 1, "user1" },
                    { new Guid("2cfae587-19f2-41fe-8eb7-231dac626adc"), "Address 21", "avatar21.png", new DateTime(2023, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "user21@example.com", "User 21", "uqWAcnIuI+ey7XOiRgb8IA==", "123-456-78921", 2, 1, "user21" },
                    { new Guid("358d9b68-2703-490d-874b-2f1cca196b36"), "Address 5", "avatar5.png", new DateTime(2023, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "user5@example.com", "User 5", "LtgxZLXxd71ac78V6rYtcg==", "123-456-7895", 2, 1, "user5" },
                    { new Guid("3740f350-fdd4-49d1-8f25-6f10e74a40c0"), "Address 30", "avatar30.png", new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "user30@example.com", "User 30", "ZIc8EakA57j1Q7JTsakLKA==", "123-456-78930", 2, 1, "user30" },
                    { new Guid("38922fa4-81fb-47b2-b49d-4e4883d50857"), "Address 22", "avatar22.png", new DateTime(2023, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "user22@example.com", "User 22", "yuwYTyVSnjUQg9d58Fr6eg==", "123-456-78922", 2, 1, "user22" },
                    { new Guid("3b9a5b74-8fa5-4d4e-bff7-a4c7972df188"), "Address 10", "avatar10.png", new DateTime(2023, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "user10@example.com", "User 10", "AD+DKAMne24G+bFvnB3umA==", "123-456-78910", 2, 1, "user10" },
                    { new Guid("457dad8c-5d63-4616-a2d3-aa5cc9cbbeec"), "Address 11", "avatar11.png", new DateTime(2023, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "user11@example.com", "User 11", "+1XAkm3H0MciMPlnUyv6ww==", "123-456-78911", 2, 1, "user11" },
                    { new Guid("5f0c0f1c-0471-4c62-b570-1fc6886ad5f9"), "Address 13", "avatar13.png", new DateTime(2023, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "user13@example.com", "User 13", "hjKFGDVLaz8y7jip9ebjyg==", "123-456-78913", 2, 1, "user13" },
                    { new Guid("6102932b-c823-4f6b-8df6-6f8d6427c6b1"), "Address 14", "avatar14.png", new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "user14@example.com", "User 14", "Nbb9cBgoI2KknXYhJgRsOg==", "123-456-78914", 2, 1, "user14" },
                    { new Guid("64f01481-288b-425b-bcf4-31ecd9657c50"), "Address 23", "avatar23.png", new DateTime(2023, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "user23@example.com", "User 23", "JM3wDHJHLSLI6Wdnnfs2dQ==", "123-456-78923", 2, 1, "user23" },
                    { new Guid("6cc811d6-c874-475f-8ec6-8373e87cd01d"), "Address 7", "avatar7.png", new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "user7@example.com", "User 7", "h8t5vD5p1U3C4AEASeaErg==", "123-456-7897", 2, 1, "user7" },
                    { new Guid("6ebe655c-06aa-46fd-b26d-89f929c57323"), "Address 29", "avatar29.png", new DateTime(2023, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "user29@example.com", "User 29", "ETdpo/KPinCotdzGNmsAPA==", "123-456-78929", 2, 1, "user29" },
                    { new Guid("7013b839-ed60-42cb-a519-663d2a93fef3"), "Address 28", "avatar28.png", new DateTime(2023, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "user28@example.com", "User 28", "R/9+ITDUv36NqhUmUxCu5w==", "123-456-78928", 2, 1, "user28" },
                    { new Guid("9f6507fe-1e62-424e-b684-1bc1cdbd0eb5"), "Address 12", "avatar12.png", new DateTime(2023, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "user12@example.com", "User 12", "q/b7mh1nE1JeI7y/w6yvIQ==", "123-456-78912", 2, 1, "user12" },
                    { new Guid("ac887d19-d7fb-4c8a-aa89-292157849f67"), "Address 26", "avatar26.png", new DateTime(2023, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "user26@example.com", "User 26", "JTjto+r7kPyCkZGQtsDBOA==", "123-456-78926", 2, 1, "user26" },
                    { new Guid("af2734af-1f06-46a4-a81c-a94483b44780"), "Address 8", "avatar8.png", new DateTime(2023, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "user8@example.com", "User 8", "QoNqXwm6ndtmwV7AptAudw==", "123-456-7898", 2, 1, "user8" },
                    { new Guid("b3ce248e-3215-42b1-b404-fe08ddd10403"), "Address 3", "avatar3.png", new DateTime(2023, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "user3@example.com", "User 3", "XZG20Zjr0RmKJ42oxCGZqQ==", "123-456-7893", 2, 1, "user3" },
                    { new Guid("c5e680f4-2c75-4662-a693-6841d73e1b3a"), "Address 15", "avatar15.png", new DateTime(2023, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "user15@example.com", "User 15", "AtoLhqKWoDhm5ytm7x3CFg==", "123-456-78915", 2, 1, "user15" },
                    { new Guid("cd52e7cd-778d-47ce-9692-a4b474629bab"), "Address 2", "avatar2.png", new DateTime(2023, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "user2@example.com", "User 2", "gPFa6fSRCX/O3JCnJjTBBg==", "123-456-7892", 2, 1, "user2" },
                    { new Guid("ce9ed277-ed43-47d2-9677-d5eecb716e34"), "Address 6", "avatar6.png", new DateTime(2023, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "user6@example.com", "User 6", "ns3cIzMXn9uRJUqXbdf1sw==", "123-456-7896", 2, 1, "user6" },
                    { new Guid("dac77e2b-9d75-4bb6-ba94-6ce1d1ab1343"), "Address 17", "avatar17.png", new DateTime(2023, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "user17@example.com", "User 17", "bnivYPkMUcJNzvYQyXZIvw==", "123-456-78917", 2, 1, "user17" },
                    { new Guid("dcdc02fa-e89d-45b5-8fad-6fd217755bce"), "Address 18", "avatar18.png", new DateTime(2023, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "user18@example.com", "User 18", "zp6jPz/JRrDgXS7tmjREDQ==", "123-456-78918", 2, 1, "user18" },
                    { new Guid("df6f9cfa-4b8b-4ccd-8bfb-3df29051cf3f"), "Address 20", "avatar20.png", new DateTime(2023, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "user20@example.com", "User 20", "J20oEfuyjDdy085hSNPLIw==", "123-456-78920", 2, 1, "user20" },
                    { new Guid("e0e90d2e-b034-4b3e-ab3d-a48c85fec57c"), "Address 16", "avatar16.png", new DateTime(2023, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "user16@example.com", "User 16", "1+4JJ+OIs+XRXx0vTPNGQA==", "123-456-78916", 2, 1, "user16" },
                    { new Guid("e76fbbf2-a8b7-48a7-8e9e-46e2ff740aeb"), "Address 4", "avatar4.png", new DateTime(2023, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "user4@example.com", "User 4", "AYCB0pkX1QvnELN5s4E7/w==", "123-456-7894", 2, 1, "user4" },
                    { new Guid("ed301741-a77e-4dac-8d4d-a34fc4c4b89a"), "Address 25", "avatar25.png", new DateTime(2023, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "user25@example.com", "User 25", "o+65kwYOgM/H5YtlR5eBGQ==", "123-456-78925", 2, 1, "user25" },
                    { new Guid("f00a8d13-644f-4161-a424-e4963c8743c4"), "Address 19", "avatar19.png", new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "user19@example.com", "User 19", "+BFH+L+RScNaLm45T9M5Tw==", "123-456-78919", 2, 1, "user19" },
                    { new Guid("fd36705c-0610-4c30-9cfb-e5827b3f3d78"), "Address 1", "avatar1.png", new DateTime(2023, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "azusachan307@gmail.com", "ClientTest", "LK25tQh1RqkKbrq4C2l6fw==", "000-000-000", 1, 1, "Admin" },
                    { new Guid("fdaa6e4b-7d75-41cc-aca7-96ce08038ec0"), "Address 24", "avatar24.png", new DateTime(2023, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "user24@example.com", "User 24", "wUy5uoNVQITmQW5R4nnOMA==", "123-456-78924", 2, 1, "user24" }
                });

            migrationBuilder.InsertData(
                table: "CinemaCenters",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[,]
                {
                    { new Guid("0339a68d-56e1-4c27-a490-cdbfac9d2d2c"), "Address 21", "Cinema Center 21" },
                    { new Guid("038c9d18-c0ca-40a7-8282-70370e03bd92"), "Address 17", "Cinema Center 17" },
                    { new Guid("07887e03-7e35-46d4-8aba-cbed671845c1"), "Address 16", "Cinema Center 16" },
                    { new Guid("0a632e18-f18f-46df-a3c1-aea25245b4ca"), "Address 2", "Cinema Center 2" },
                    { new Guid("0b73b4c4-0df0-44a3-a1a7-9fb2bbd00770"), "Address 22", "Cinema Center 22" },
                    { new Guid("14f42478-4dbb-44ca-8815-d7e8e146adf6"), "Address 27", "Cinema Center 27" },
                    { new Guid("1f692266-dcae-4014-a476-14bda60d1722"), "Address 3", "Cinema Center 3" },
                    { new Guid("20f4a402-d0cf-43bb-a331-0c052c5c8b18"), "Address 29", "Cinema Center 29" },
                    { new Guid("21dcdec3-e1da-4014-bebc-15461c8f8d51"), "Address 1", "Cinema Center 1" },
                    { new Guid("31247af7-5b63-4aaa-a8d7-999815716f2a"), "Address 26", "Cinema Center 26" },
                    { new Guid("325019f6-682e-4977-841e-398b22cbf180"), "Address 10", "Cinema Center 10" },
                    { new Guid("33160449-6e6c-4e87-8474-9fdc36fa0e2c"), "Address 24", "Cinema Center 24" },
                    { new Guid("3597db76-ab0f-4bd3-8ad2-b64273d3e9d5"), "Address 9", "Cinema Center 9" },
                    { new Guid("3fddf683-1b53-4c82-af0c-813af4936046"), "Address 8", "Cinema Center 8" },
                    { new Guid("4914e5d0-19f9-4c94-a883-e109ea34d811"), "Address 20", "Cinema Center 20" },
                    { new Guid("573c9c91-b026-475c-b89e-a9b2b4eafaf4"), "Address 14", "Cinema Center 14" },
                    { new Guid("68b4f416-98f1-42b6-8815-2f835ec1e7bb"), "Address 4", "Cinema Center 4" },
                    { new Guid("6af23e25-6655-4b90-b260-5538ec250f4c"), "Address 13", "Cinema Center 13" },
                    { new Guid("6e7bd87d-c75b-4266-ae5f-eccadeac0152"), "Address 5", "Cinema Center 5" },
                    { new Guid("7cae0174-5377-47e5-9a79-208ca34a6b32"), "Address 15", "Cinema Center 15" },
                    { new Guid("8592c367-e68d-4957-9d41-db242c98bd09"), "Address 18", "Cinema Center 18" },
                    { new Guid("8a9ed42f-124a-4cbd-b955-1592cf99c958"), "Address 12", "Cinema Center 12" },
                    { new Guid("9110eb87-f854-46c3-bcd1-7f4366f67cd4"), "Address 30", "Cinema Center 30" },
                    { new Guid("b5f30059-8aa6-47f8-b010-af1e921bf14e"), "Address 19", "Cinema Center 19" },
                    { new Guid("b8cd5389-57b8-485b-a490-62b685898dbc"), "Address 7", "Cinema Center 7" },
                    { new Guid("d1af1643-0c5b-4f86-aa23-938ac813228e"), "Address 6", "Cinema Center 6" },
                    { new Guid("e0dd3f66-e22b-4a3e-a32a-ce26695e2cb3"), "Address 25", "Cinema Center 25" },
                    { new Guid("e6feafa0-87a4-4e70-aec1-547e52764184"), "Address 11", "Cinema Center 11" },
                    { new Guid("f2c38fdc-d3b6-407e-891e-cccbfb00bf5b"), "Address 23", "Cinema Center 23" },
                    { new Guid("f65775c8-34a4-49f1-8356-e75176fb430a"), "Address 28", "Cinema Center 28" }
                });

            migrationBuilder.InsertData(
                table: "CinemaTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("058a6601-a244-4fc2-b35d-37da707d9ade"), "Cinema Type 6" },
                    { new Guid("0a393b2f-4955-468c-bc40-b36ff49d4aa5"), "Cinema Type 20" },
                    { new Guid("0d13732e-0f68-44ba-ae23-be10ce441b32"), "Cinema Type 30" },
                    { new Guid("0f120eaf-cd0f-49ab-85a8-96cd80c3dbeb"), "Cinema Type 18" },
                    { new Guid("103772c0-aef5-4225-83d0-9a4317c1f070"), "Cinema Type 22" },
                    { new Guid("3f17e206-c2e9-4adb-85e2-c172c44fe08c"), "Cinema Type 5" },
                    { new Guid("4951d9d6-d0d1-4e6b-b7b7-85e2aa062cdf"), "Cinema Type 2" },
                    { new Guid("4f548700-030c-4cda-b5b8-a44c323ff9bf"), "Cinema Type 24" },
                    { new Guid("57ab8a77-5fcb-4271-a069-e4a3675508bb"), "Cinema Type 11" },
                    { new Guid("58e7abfa-bd1f-45a2-a711-5101ac40234f"), "Cinema Type 26" },
                    { new Guid("596a4cae-c392-49d4-bcc3-b6e46a04e593"), "Cinema Type 8" },
                    { new Guid("5aa361b5-3d75-4e86-ae9a-992a3082d0f6"), "Cinema Type 29" },
                    { new Guid("71bb7cd1-a57f-4964-8933-264895387dfb"), "Cinema Type 27" },
                    { new Guid("71eadab4-07a0-4c63-85c7-a6b579adc182"), "Cinema Type 3" },
                    { new Guid("74e5ac49-029c-4eff-8577-33f8d5d8dccf"), "Cinema Type 23" },
                    { new Guid("76666e39-aedc-414e-af11-32bafbec0db4"), "Cinema Type 10" },
                    { new Guid("7a16c228-81ac-4a73-9e9f-dae7f9a2dc66"), "Cinema Type 7" },
                    { new Guid("7c68c3e5-e825-4b8f-9c8f-9cd3bd69ea4d"), "Cinema Type 15" },
                    { new Guid("8292a53c-1afb-42ef-9ea6-0a2801313c19"), "Cinema Type 28" },
                    { new Guid("862a96ac-19fb-4e9a-8e2a-97a1081d1952"), "Cinema Type 16" },
                    { new Guid("90405444-6c95-4860-a087-db6216de0d78"), "Cinema Type 12" },
                    { new Guid("9ff06176-2bb2-43f3-9127-de5d538ad2a0"), "Cinema Type 19" },
                    { new Guid("b0df037e-0433-45c0-b91f-c4fd8eb3c56b"), "Cinema Type 25" },
                    { new Guid("b2c4662e-b4ef-4e73-a832-07770bd2dac0"), "Cinema Type 4" },
                    { new Guid("c8adc5e1-7bfa-4752-8610-e1be7536e1db"), "Cinema Type 14" },
                    { new Guid("ddce1309-cfed-40cc-ae0f-cd253ee58946"), "Cinema Type 17" },
                    { new Guid("dfaad32b-e175-434b-bb83-c7318235bb4e"), "Cinema Type 9" },
                    { new Guid("eb31b45f-e3d0-49cf-aec6-68671166ada7"), "Cinema Type 13" },
                    { new Guid("f3aa3fa1-9f62-412a-9013-b37e13cbf0cd"), "Cinema Type 1" },
                    { new Guid("f6b2562a-a38a-4030-a796-305f9d1cceff"), "Cinema Type 21" }
                });

            migrationBuilder.InsertData(
                table: "Combos",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("03f2e0fd-928a-4d94-bdd4-b7efb4974b82"), "Combo 3", 30000m },
                    { new Guid("04798a19-6de2-4e51-bd21-c164e57d3c84"), "Combo 13", 30000m },
                    { new Guid("2ab0aab2-35f6-45dd-9738-262fab9491c3"), "Combo 6", 60000m },
                    { new Guid("2ced1f96-66e3-4c3d-8af4-3c7a2ec0c1d0"), "Combo 26", 60000m },
                    { new Guid("3263fa08-2ce9-4b3c-b83e-9f97e1058b5e"), "Combo 20", 0m },
                    { new Guid("3b7706b1-0a22-4702-ae46-9f2a3c605bf2"), "Combo 9", 90000m },
                    { new Guid("4e190e67-567d-4625-b0e5-bfd93bf2f0ee"), "Combo 24", 40000m },
                    { new Guid("4f436c3e-ec27-4cf4-b0ab-507441cc14bf"), "Combo 12", 20000m },
                    { new Guid("5bd75401-cccf-4546-ac45-c9833266f6e8"), "Combo 30", 0m },
                    { new Guid("5efdc397-4272-412f-a681-9fae3dd3ae1e"), "Combo 11", 10000m },
                    { new Guid("6390d61d-e9b2-4637-a9f2-4eefb2206cd3"), "Combo 23", 30000m },
                    { new Guid("76c9f49c-214f-4d0f-b1ab-175bcc53a540"), "Combo 4", 40000m },
                    { new Guid("7f7c505f-a47e-4d65-bca1-7f22d48b78d1"), "Combo 22", 20000m },
                    { new Guid("8ae0af0c-00d0-4350-9ec2-6223ce58300d"), "Combo 21", 10000m },
                    { new Guid("8e09fba9-58be-4084-a442-d4910d7f1e3c"), "Combo 5", 50000m },
                    { new Guid("954926ca-add4-47aa-8c71-87586936e19a"), "Combo 16", 60000m },
                    { new Guid("982cbdb8-2562-4168-9124-6bea5024d91d"), "Combo 10", 0m },
                    { new Guid("a9f46aef-ff56-4960-9215-220cd5787922"), "Combo 29", 90000m },
                    { new Guid("aeb8124c-4fc0-42b7-8aa7-a3f16931f58e"), "Combo 27", 70000m },
                    { new Guid("ba07a31c-fd8d-472e-a0cb-615c979a7445"), "Combo 1", 10000m },
                    { new Guid("c2864335-c2e1-49f1-843d-f9d21a2ee2b2"), "Combo 17", 70000m },
                    { new Guid("cdb4c4ed-4962-49f8-9bc8-423aaefe0943"), "Combo 25", 50000m },
                    { new Guid("d0985463-1ba4-426f-917f-6ce6ee4b912d"), "Combo 18", 80000m },
                    { new Guid("d532be87-5189-4a4f-abdb-0305ac34b853"), "Combo 7", 70000m },
                    { new Guid("d60259d0-3ef4-489b-a399-b5287661294b"), "Combo 14", 40000m },
                    { new Guid("d9523d49-32db-4f01-8fa9-d3857a033207"), "Combo 28", 80000m },
                    { new Guid("dba7d780-6c5a-4f12-b275-736dcea5c96f"), "Combo 2", 20000m },
                    { new Guid("de9887c6-5314-4623-a0f5-8566028e972e"), "Combo 8", 80000m },
                    { new Guid("f32476e5-73fa-4726-a4d0-9953d11fe38e"), "Combo 19", 90000m },
                    { new Guid("fa9f49bc-e203-4e09-beab-8d9a2c7ed47a"), "Combo 15", 50000m }
                });

            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "Id", "Cast", "CreatDate", "Description", "Director", "EnglishName", "Gerne", "Language", "Name", "Nation", "Poster", "Rating", "ReleaseYear", "RunningTime", "ScreenTypeId", "StartDate", "Status", "Trailer", "TranslationTypeId" },
                values: new object[,]
                {
                    { new Guid("00eaa5bb-5040-4e25-bce8-5162daa44b31"), "Actor 12, Actress 12", new DateTime(2023, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 12.", "Director 12", "Film 12 (English)", "Action", "English", "Film 12", "USA", "https://example.com/poster12.jpg", 3, 2023, 72, new Guid("e177d0be-31c1-4c09-a844-b1b87bf73d49"), new DateTime(2023, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer12.mp4", new Guid("97bc20b0-1191-4e57-9d8a-063c87cf772f") },
                    { new Guid("07402444-17e1-45cf-a548-55a3603c221f"), "Actor 28, Actress 28", new DateTime(2023, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 28.", "Director 28", "Film 28 (English)", "Action", "English", "Film 28", "USA", "https://example.com/poster28.jpg", 4, 2023, 88, new Guid("47913fee-fa43-44a1-be1e-350a8d412d66"), new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer28.mp4", new Guid("b7d6341e-5cf2-4b19-8db0-3dbb1700032f") },
                    { new Guid("124b4183-660d-4e6e-a548-18c9ed417ef1"), "Actor 15, Actress 15", new DateTime(2023, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 15.", "Director 15", "Film 15 (English)", "Comedy", "Japanese", "Film 15", "Japan", "https://example.com/poster15.jpg", 1, 2023, 75, new Guid("5bc91374-f55e-4fac-a9d0-53751a3df102"), new DateTime(2023, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer15.mp4", new Guid("2dde2d4b-2cd9-4d07-a596-5a16721b7df8") },
                    { new Guid("1a9704d4-c6f9-4c78-8f61-33f0032d144b"), "Actor 20, Actress 20", new DateTime(2023, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 20.", "Director 20", "Film 20 (English)", "Action", "English", "Film 20", "USA", "https://example.com/poster20.jpg", 1, 2023, 80, new Guid("58a2c0e8-2479-4e8f-819e-e0a170a62d16"), new DateTime(2023, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer20.mp4", new Guid("c4f6cc02-a079-4955-bcd0-f9c3619be1c6") },
                    { new Guid("2330f956-cd00-48ae-901d-f47d2314497a"), "Actor 11, Actress 11", new DateTime(2023, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 11.", "Director 11", "Film 11 (English)", "Comedy", "Japanese", "Film 11", "Japan", "https://example.com/poster11.jpg", 2, 2023, 71, new Guid("0ed37b54-ef75-43db-b05f-323166085b4d"), new DateTime(2023, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer11.mp4", new Guid("33460d30-d139-4faf-9bc3-cb9c08d9a818") },
                    { new Guid("2b3038a7-693e-4858-b46f-22c56cad6c6f"), "Actor 5, Actress 5", new DateTime(2023, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 5.", "Director 5", "Film 5 (English)", "Comedy", "Japanese", "Film 5", "Japan", "https://example.com/poster5.jpg", 1, 2023, 65, new Guid("3920c172-ed25-4725-8aa3-905269df89fa"), new DateTime(2023, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer5.mp4", new Guid("7738f32b-fa7e-48a6-8784-4815c0fdb223") },
                    { new Guid("2dbafe39-c627-49d8-afbb-5eab00597640"), "Actor 22, Actress 22", new DateTime(2023, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 22.", "Director 22", "Film 22 (English)", "Action", "English", "Film 22", "USA", "https://example.com/poster22.jpg", 3, 2023, 82, new Guid("433e016a-9602-4cf3-9832-8965f95149d2"), new DateTime(2023, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer22.mp4", new Guid("74943df5-dd08-496b-b0a2-5c3f7ebcc753") },
                    { new Guid("38ed18a4-415a-4697-afea-7a0e7ae65183"), "Actor 9, Actress 9", new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 9.", "Director 9", "Film 9 (English)", "Comedy", "Japanese", "Film 9", "Japan", "https://example.com/poster9.jpg", 5, 2023, 69, new Guid("14c479a7-a75d-4619-8d26-1d10a68340d6"), new DateTime(2023, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer9.mp4", new Guid("d59c1825-17de-49ff-a02a-6ae6196a1971") },
                    { new Guid("3ecc1e78-6fb7-4dcc-a47d-1157ad2df61d"), "Actor 16, Actress 16", new DateTime(2023, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 16.", "Director 16", "Film 16 (English)", "Action", "English", "Film 16", "USA", "https://example.com/poster16.jpg", 2, 2023, 76, new Guid("a8f7efab-9e0e-4862-abce-81caeb60fcb9"), new DateTime(2023, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer16.mp4", new Guid("ee950f4e-b52c-4c52-985b-28780f8501be") },
                    { new Guid("4564523d-91a4-4a46-bad3-38676e6d48c2"), "Actor 26, Actress 26", new DateTime(2023, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 26.", "Director 26", "Film 26 (English)", "Action", "English", "Film 26", "USA", "https://example.com/poster26.jpg", 2, 2023, 86, new Guid("19aefa12-03f5-4782-97fe-622385f24a21"), new DateTime(2023, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer26.mp4", new Guid("6ff51dd8-d2cb-4945-8b3d-5010ab13db75") },
                    { new Guid("4823862b-d60c-4f4e-a3dc-5d504869c197"), "Actor 19, Actress 19", new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 19.", "Director 19", "Film 19 (English)", "Comedy", "Japanese", "Film 19", "Japan", "https://example.com/poster19.jpg", 5, 2023, 79, new Guid("514adf83-7d7b-4474-a0be-bf84f3b58248"), new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer19.mp4", new Guid("5c57ef70-2fc0-4ceb-857e-119c8eee613f") },
                    { new Guid("4947fdea-45bc-4628-b337-3cd19eadf1e4"), "Actor 6, Actress 6", new DateTime(2023, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 6.", "Director 6", "Film 6 (English)", "Action", "English", "Film 6", "USA", "https://example.com/poster6.jpg", 2, 2023, 66, new Guid("7023edaf-f3e1-4f5f-a9e5-49e9e49a94cc"), new DateTime(2023, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer6.mp4", new Guid("be13c67f-c40a-42e3-b339-2883b55c4a25") },
                    { new Guid("5e01f41a-897a-40f9-bc1c-dd2c01de9419"), "Actor 18, Actress 18", new DateTime(2023, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 18.", "Director 18", "Film 18 (English)", "Action", "English", "Film 18", "USA", "https://example.com/poster18.jpg", 4, 2023, 78, new Guid("68463e83-cbce-4de8-a40e-bff8dd3ef1cb"), new DateTime(2023, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer18.mp4", new Guid("8b0be583-4708-4209-b950-619075bb160c") },
                    { new Guid("66fe2fba-30b1-4b4f-8ca1-5e3b29378297"), "Actor 30, Actress 30", new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 30.", "Director 30", "Film 30 (English)", "Action", "English", "Film 30", "USA", "https://example.com/poster30.jpg", 1, 2023, 90, new Guid("bdffda8f-3d97-4df0-90fc-e02261ecbb99"), new DateTime(2023, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer30.mp4", new Guid("e3a8d93e-6139-4d77-892b-3091bd849f5e") },
                    { new Guid("6d566a2f-5bb9-4cbc-9379-90883a768190"), "Actor 17, Actress 17", new DateTime(2023, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 17.", "Director 17", "Film 17 (English)", "Comedy", "Japanese", "Film 17", "Japan", "https://example.com/poster17.jpg", 3, 2023, 77, new Guid("206db19e-2571-4cc8-82ec-66fc99874fc4"), new DateTime(2023, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer17.mp4", new Guid("ca9c9900-6d53-414d-9e3c-62c68967debb") },
                    { new Guid("8076791b-a2d8-4b0a-87af-7c59505e7e00"), "Actor 21, Actress 21", new DateTime(2023, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 21.", "Director 21", "Film 21 (English)", "Comedy", "Japanese", "Film 21", "Japan", "https://example.com/poster21.jpg", 2, 2023, 81, new Guid("23d69278-bbc5-44bf-967e-64331bc56439"), new DateTime(2023, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer21.mp4", new Guid("bc2214e2-121c-48fc-afca-518de6da4849") },
                    { new Guid("812520d3-1f14-45af-a3db-a24b4d6a96e2"), "Actor 25, Actress 25", new DateTime(2023, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 25.", "Director 25", "Film 25 (English)", "Comedy", "Japanese", "Film 25", "Japan", "https://example.com/poster25.jpg", 1, 2023, 85, new Guid("e7aefb20-1fea-40ff-8a40-b46eee20c582"), new DateTime(2023, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer25.mp4", new Guid("be0cbb1a-77ac-4800-9249-2ed681e4e152") },
                    { new Guid("966f7fbe-a5b4-4c8b-94a9-1338ab6e92bd"), "Actor 14, Actress 14", new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 14.", "Director 14", "Film 14 (English)", "Action", "English", "Film 14", "USA", "https://example.com/poster14.jpg", 5, 2023, 74, new Guid("baa5657f-14c2-4ace-86bb-9c68969839c1"), new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer14.mp4", new Guid("85e62173-8e31-4306-9f59-e2f8597cdc1e") },
                    { new Guid("a2f73867-7acf-41b5-9130-3139c8e0d1ac"), "Actor 24, Actress 24", new DateTime(2023, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 24.", "Director 24", "Film 24 (English)", "Action", "English", "Film 24", "USA", "https://example.com/poster24.jpg", 5, 2023, 84, new Guid("3ca407f6-d21b-40a3-9f5c-9662915505b7"), new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer24.mp4", new Guid("452542fa-a85f-41ed-90f0-68e982231186") },
                    { new Guid("b39d16bc-6489-463e-9b11-f0cfe923532e"), "Actor 3, Actress 3", new DateTime(2023, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 3.", "Director 3", "Film 3 (English)", "Comedy", "Japanese", "Film 3", "Japan", "https://example.com/poster3.jpg", 4, 2023, 63, new Guid("6dd20c2f-1c95-472b-be66-241f674ce26f"), new DateTime(2023, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer3.mp4", new Guid("90dfe464-e83a-4edc-90ac-ab20b550f25d") },
                    { new Guid("bfb6e8a8-d4fa-4bb7-9ea6-c857fa837324"), "Actor 27, Actress 27", new DateTime(2023, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 27.", "Director 27", "Film 27 (English)", "Comedy", "Japanese", "Film 27", "Japan", "https://example.com/poster27.jpg", 3, 2023, 87, new Guid("be900791-9f9c-45da-9081-70adc00ce2e2"), new DateTime(2023, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer27.mp4", new Guid("e31eee13-4019-4874-8374-acf7562df0c8") },
                    { new Guid("c27159dc-b159-44ab-86b8-44635c82c95c"), "Actor 8, Actress 8", new DateTime(2023, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 8.", "Director 8", "Film 8 (English)", "Action", "English", "Film 8", "USA", "https://example.com/poster8.jpg", 4, 2023, 68, new Guid("6a4188d6-4e9c-4f95-afab-9c2e923a90ba"), new DateTime(2023, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer8.mp4", new Guid("63f3ce97-dd7a-478a-b563-800ac97912ba") },
                    { new Guid("c847384e-cf33-4a17-980e-f42c495cd5d3"), "Actor 1, Actress 1", new DateTime(2023, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 1.", "Director 1", "Film 1 (English)", "Comedy", "Japanese", "Film 1", "Japan", "https://example.com/poster1.jpg", 2, 2023, 61, new Guid("289a45af-4ebe-439a-a3ba-c7f3fe9d73f2"), new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer1.mp4", new Guid("d8b59dbe-0e2e-444d-8fbf-d43b747936da") },
                    { new Guid("d114c736-85af-4da3-8f5c-0b7740bf50c0"), "Actor 2, Actress 2", new DateTime(2023, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 2.", "Director 2", "Film 2 (English)", "Action", "English", "Film 2", "USA", "https://example.com/poster2.jpg", 3, 2023, 62, new Guid("21da5acc-4393-4bdd-a87b-51c273fa5f48"), new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer2.mp4", new Guid("a7571a64-609c-4092-80e2-d6aec020d81c") },
                    { new Guid("d38f5786-ab57-4ded-8218-11964078e035"), "Actor 13, Actress 13", new DateTime(2023, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 13.", "Director 13", "Film 13 (English)", "Comedy", "Japanese", "Film 13", "Japan", "https://example.com/poster13.jpg", 4, 2023, 73, new Guid("3f8f3739-0f1a-4f88-91ff-edd9b0010e27"), new DateTime(2023, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer13.mp4", new Guid("68866335-20a1-4071-a480-30b8cfbf24d9") },
                    { new Guid("d849987d-2ad9-4182-847c-9fa41a2cfeab"), "Actor 7, Actress 7", new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 7.", "Director 7", "Film 7 (English)", "Comedy", "Japanese", "Film 7", "Japan", "https://example.com/poster7.jpg", 3, 2023, 67, new Guid("e648cfd5-5028-4c41-933f-6c978aabd2aa"), new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer7.mp4", new Guid("c663c9f1-e3b7-40c3-9473-0591ac05b932") },
                    { new Guid("e74a085f-b78a-4333-8572-7f436b580ca4"), "Actor 23, Actress 23", new DateTime(2023, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 23.", "Director 23", "Film 23 (English)", "Comedy", "Japanese", "Film 23", "Japan", "https://example.com/poster23.jpg", 4, 2023, 83, new Guid("bcc1ca4f-0c22-4464-9929-960f1f15f867"), new DateTime(2023, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer23.mp4", new Guid("326e50cb-8d99-4c0a-9c22-f7907a23711e") },
                    { new Guid("e8bf9b4f-0f26-419a-aeb9-41da6a1260aa"), "Actor 29, Actress 29", new DateTime(2023, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 29.", "Director 29", "Film 29 (English)", "Comedy", "Japanese", "Film 29", "Japan", "https://example.com/poster29.jpg", 5, 2023, 89, new Guid("40fe0ef7-cf4d-48f5-821c-fd34673014c4"), new DateTime(2023, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer29.mp4", new Guid("253e6f64-c395-4614-a3e9-f6eeb828b92f") },
                    { new Guid("f4b9539b-c86d-4c43-a1ab-6d1722b496d5"), "Actor 10, Actress 10", new DateTime(2023, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 10.", "Director 10", "Film 10 (English)", "Action", "English", "Film 10", "USA", "https://example.com/poster10.jpg", 1, 2023, 70, new Guid("432b7161-97ac-4964-a1f1-b622e8a091ab"), new DateTime(2023, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer10.mp4", new Guid("3a362d36-230d-4995-ba2b-87b038f509ee") },
                    { new Guid("fb17d7c0-e7b9-4685-8b8f-ebb7f4d8014e"), "Actor 4, Actress 4", new DateTime(2023, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 4.", "Director 4", "Film 4 (English)", "Action", "English", "Film 4", "USA", "https://example.com/poster4.jpg", 5, 2023, 64, new Guid("b844a74e-a8ae-42b1-8961-53173bc0d60e"), new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer4.mp4", new Guid("8f25894c-c792-4a2d-8dca-d38e63723c0b") }
                });

            migrationBuilder.InsertData(
                table: "Promotions",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("0218a8bc-b9c1-4908-951f-b3fe540b90cb"), "Title 26" },
                    { new Guid("13c0b75e-c99d-42ad-bf9b-1cdbee89a4bb"), "Title 12" },
                    { new Guid("2e592e96-73c4-4653-8c7a-9d7f58a6dd5d"), "Title 17" },
                    { new Guid("30171c6f-2f55-48df-8cec-47ec42580aaa"), "Title 13" },
                    { new Guid("3160fdfe-6570-4ded-965e-12873200698a"), "Title 8" },
                    { new Guid("48b25a2d-fb91-4ec3-aad5-d9545c6fca41"), "Title 25" },
                    { new Guid("4cabd80a-16ef-4ef7-8699-0d44a2bcc811"), "Title 29" },
                    { new Guid("4d325c5a-b2fe-48d2-921d-1ce31e01b96a"), "Title 5" },
                    { new Guid("4d5d958c-f500-4a8c-bd0a-4c3cded923d4"), "Title 16" },
                    { new Guid("57702f37-27d6-429a-8f55-c5245ce14fd7"), "Title 15" },
                    { new Guid("5fdf43e4-f10f-49bf-a74e-b5bad61d26fd"), "Title 4" },
                    { new Guid("602b35e9-a722-4603-a193-08284d1e5b1b"), "Title 23" },
                    { new Guid("6074460c-3f3a-4a80-9187-17835a03d5ac"), "Title 3" },
                    { new Guid("69d4bb9c-4a4a-470f-a2ca-fc9922fe3718"), "Title 22" },
                    { new Guid("793f342e-1b17-4d86-96f0-390ab5139e55"), "Title 27" },
                    { new Guid("89b29e4e-f048-48d3-8928-44fb077f9937"), "Title 30" },
                    { new Guid("90917a1c-49a8-40d4-ac7e-3cc15776308e"), "Title 19" },
                    { new Guid("9846c314-a710-487b-8633-ea78f6afe352"), "Title 24" },
                    { new Guid("9d7c2214-2a62-4286-acf7-63876d12b938"), "Title 21" },
                    { new Guid("a3369eee-ef73-4c82-9520-2332a2fd6337"), "Title 9" },
                    { new Guid("aa4185cc-2c5b-4bd1-ac0b-46544b643080"), "Title 6" },
                    { new Guid("b61751e6-c448-4087-8d65-30f04854d4c1"), "Title 2" },
                    { new Guid("bf1b3864-dbc9-40c7-a5d6-98f210685f76"), "Title 1" },
                    { new Guid("c1fb5502-b58d-42be-b61f-3ac716038f63"), "Title 20" },
                    { new Guid("c740bd38-98fd-40c7-8a8a-20997d9f9d39"), "Title 10" },
                    { new Guid("ceb3ae09-1acc-417a-968f-f5967abfef9d"), "Title 28" },
                    { new Guid("db6a1412-cb8b-4d2d-bba6-252a4dd1f7f6"), "Title 7" },
                    { new Guid("e0d37800-5dfb-4246-973b-2e5889b5879f"), "Title 11" },
                    { new Guid("ef3312c4-0da8-4a53-86f5-3631340a2bac"), "Title 18" },
                    { new Guid("ffc2cebd-4dd9-4878-9d17-5ceb4db11381"), "Title 14" }
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
