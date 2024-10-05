using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieTicket.Infrastructure.Migrations.MovieTicketReadWriteDb
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
                    { new Guid("1181c91b-1232-45de-ab04-455487c5b53f"), "avatar21.png", new DateTime(2023, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "user21@example.com", "User 21", "uqWAcnIuI+ey7XOiRgb8IA==", "123-456-78921", 2, 1, "user21" },
                    { new Guid("13beddf5-4fce-4275-89a6-63fc38a209c0"), "avatar30.png", new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "user30@example.com", "User 30", "ZIc8EakA57j1Q7JTsakLKA==", "123-456-78930", 2, 1, "user30" },
                    { new Guid("198affa9-700f-44e7-ad36-a8297d6a1a8d"), "avatar5.png", new DateTime(2023, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "user5@example.com", "User 5", "LtgxZLXxd71ac78V6rYtcg==", "123-456-7895", 2, 1, "user5" },
                    { new Guid("1b847c0c-617b-49fb-9a67-5641bf9df6bb"), "avatar26.png", new DateTime(2023, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "user26@example.com", "User 26", "JTjto+r7kPyCkZGQtsDBOA==", "123-456-78926", 2, 1, "user26" },
                    { new Guid("1f0b8e9b-bf5a-4a61-ba42-e8a53d7313e0"), "avatar29.png", new DateTime(2023, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "user29@example.com", "User 29", "ETdpo/KPinCotdzGNmsAPA==", "123-456-78929", 2, 1, "user29" },
                    { new Guid("2cdb5f7c-df46-4a3b-95af-86648600fe4d"), "avatar16.png", new DateTime(2023, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "user16@example.com", "User 16", "1+4JJ+OIs+XRXx0vTPNGQA==", "123-456-78916", 2, 1, "user16" },
                    { new Guid("3491c4fc-b94a-45be-8042-7689b3ca86dd"), "avatar7.png", new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "user7@example.com", "User 7", "h8t5vD5p1U3C4AEASeaErg==", "123-456-7897", 2, 1, "user7" },
                    { new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), "avatar2.png", new DateTime(2023, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "azusachan309@gmail.com", "ClientTest", "LK25tQh1RqkKbrq4C2l6fw==", "000-000-000", 2, 1, "Client" },
                    { new Guid("38182ab7-7807-4c2c-bfb7-0b2b43c92c8f"), "avatar23.png", new DateTime(2023, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "user23@example.com", "User 23", "JM3wDHJHLSLI6Wdnnfs2dQ==", "123-456-78923", 2, 1, "user23" },
                    { new Guid("3b2a890d-2f93-4859-a4e4-e6c7da8f8b7f"), "avatar24.png", new DateTime(2023, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "user24@example.com", "User 24", "wUy5uoNVQITmQW5R4nnOMA==", "123-456-78924", 2, 1, "user24" },
                    { new Guid("443df1a4-0110-4c3e-a350-d0785782847e"), "avatar3.png", new DateTime(2023, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "user3@example.com", "User 3", "XZG20Zjr0RmKJ42oxCGZqQ==", "123-456-7893", 2, 1, "user3" },
                    { new Guid("625c3dec-d580-4831-96bc-c7ee7bb16832"), "avatar28.png", new DateTime(2023, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "user28@example.com", "User 28", "R/9+ITDUv36NqhUmUxCu5w==", "123-456-78928", 2, 1, "user28" },
                    { new Guid("69efc8d9-5def-4698-8869-bfb77af5df25"), "avatar12.png", new DateTime(2023, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "user12@example.com", "User 12", "q/b7mh1nE1JeI7y/w6yvIQ==", "123-456-78912", 2, 1, "user12" },
                    { new Guid("6e5c5705-384a-4511-8e4f-dcbda20f2140"), "avatar19.png", new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "user19@example.com", "User 19", "+BFH+L+RScNaLm45T9M5Tw==", "123-456-78919", 2, 1, "user19" },
                    { new Guid("764e8ad3-131d-461f-a2ae-7a570337b647"), "avatar2.png", new DateTime(2023, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "user2@example.com", "User 2", "gPFa6fSRCX/O3JCnJjTBBg==", "123-456-7892", 2, 1, "user2" },
                    { new Guid("84c8d688-4b12-44a2-b244-18e36bfde139"), "avatar22.png", new DateTime(2023, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "user22@example.com", "User 22", "yuwYTyVSnjUQg9d58Fr6eg==", "123-456-78922", 2, 1, "user22" },
                    { new Guid("86c23ef2-7604-4fa2-bfbc-a91fbcd120cc"), "avatar14.png", new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "user14@example.com", "User 14", "Nbb9cBgoI2KknXYhJgRsOg==", "123-456-78914", 2, 1, "user14" },
                    { new Guid("8783e052-eaa9-4215-9115-8efabe3dd8b3"), "avatar6.png", new DateTime(2023, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "user6@example.com", "User 6", "ns3cIzMXn9uRJUqXbdf1sw==", "123-456-7896", 2, 1, "user6" },
                    { new Guid("9f714aa4-07fa-4bcc-9cd0-4df8332da230"), "avatar4.png", new DateTime(2023, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "user4@example.com", "User 4", "AYCB0pkX1QvnELN5s4E7/w==", "123-456-7894", 2, 1, "user4" },
                    { new Guid("b0cfe23c-c85d-4755-816f-84f04e460d6f"), "avatar27.png", new DateTime(2023, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "user27@example.com", "User 27", "lePABwdtIg5MqkBgyFdL9Q==", "123-456-78927", 2, 1, "user27" },
                    { new Guid("b501e07d-b7d0-463e-b0e9-a351da4b4af0"), "avatar20.png", new DateTime(2023, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "user20@example.com", "User 20", "J20oEfuyjDdy085hSNPLIw==", "123-456-78920", 2, 1, "user20" },
                    { new Guid("c07874e9-f296-4f6f-bb5f-acd3b334ebae"), "avatar8.png", new DateTime(2023, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "user8@example.com", "User 8", "QoNqXwm6ndtmwV7AptAudw==", "123-456-7898", 2, 1, "user8" },
                    { new Guid("c75e0b4e-e264-47fe-b9b7-a0780ab5a92b"), "avatar9.png", new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "user9@example.com", "User 9", "XLl70iIryQx+lE/y5900Uw==", "123-456-7899", 2, 1, "user9" },
                    { new Guid("ddb9baa0-5bcb-47f9-af78-c5df34863b7a"), "avatar11.png", new DateTime(2023, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "user11@example.com", "User 11", "+1XAkm3H0MciMPlnUyv6ww==", "123-456-78911", 2, 1, "user11" },
                    { new Guid("dff3bd32-4956-4e09-b0b6-97ae3424f896"), "avatar17.png", new DateTime(2023, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "user17@example.com", "User 17", "bnivYPkMUcJNzvYQyXZIvw==", "123-456-78917", 2, 1, "user17" },
                    { new Guid("e8faf264-ba55-4df8-88ef-0bd8c61003f8"), "avatar13.png", new DateTime(2023, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "user13@example.com", "User 13", "hjKFGDVLaz8y7jip9ebjyg==", "123-456-78913", 2, 1, "user13" },
                    { new Guid("e93e7f12-57a5-40bd-b03f-b092f037260f"), "avatar10.png", new DateTime(2023, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "user10@example.com", "User 10", "AD+DKAMne24G+bFvnB3umA==", "123-456-78910", 2, 1, "user10" },
                    { new Guid("ef4b4f1e-334d-4538-9070-2e28369856d9"), "avatar1.png", new DateTime(2023, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "user1@example.com", "User 1", "ei00xFxTj/yW/ErUUw1JvA==", "123-456-7891", 2, 1, "user1" },
                    { new Guid("efaba4df-b7b5-4cbd-8fec-64d41dcba16e"), "avatar18.png", new DateTime(2023, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "user18@example.com", "User 18", "zp6jPz/JRrDgXS7tmjREDQ==", "123-456-78918", 2, 1, "user18" },
                    { new Guid("faa55da3-8261-45c2-9167-4f151471df95"), "avatar25.png", new DateTime(2023, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "user25@example.com", "User 25", "o+65kwYOgM/H5YtlR5eBGQ==", "123-456-78925", 2, 1, "user25" },
                    { new Guid("fd36705c-0610-4c30-9cfb-e5827b3f3d78"), "avatar1.png", new DateTime(2023, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "azusachan307@gmail.com", "AdminTest", "LK25tQh1RqkKbrq4C2l6fw==", "000-000-000", 1, 1, "Admin" },
                    { new Guid("fdcb4ec3-cde9-48f1-bb2d-e091c5299185"), "avatar15.png", new DateTime(2023, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "user15@example.com", "User 15", "AtoLhqKWoDhm5ytm7x3CFg==", "123-456-78915", 2, 1, "user15" }
                });

            migrationBuilder.InsertData(
                table: "CinemaCenters",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[,]
                {
                    { new Guid("0740e6ae-a711-41c2-8515-1e743d7b4682"), "Address 14", "Cinema Center 14" },
                    { new Guid("2f2b8c56-c334-4dc8-b125-5c8fc81aa75a"), "Address 16", "Cinema Center 16" },
                    { new Guid("3378ec63-e87d-4d8c-8739-ccd64ff4a053"), "Address 8", "Cinema Center 8" },
                    { new Guid("374ccabe-cae4-4389-ac12-a1b327c912ff"), "Address 20", "Cinema Center 20" },
                    { new Guid("562703b6-f408-4340-9651-780c11395069"), "Address 23", "Cinema Center 23" },
                    { new Guid("6062cd97-0dbf-42a4-88cc-4e870ad66f2b"), "Address 4", "Cinema Center 4" },
                    { new Guid("713d97e0-456c-4e33-ab26-203625e4ebf7"), "Address 1", "Cinema Center 1" },
                    { new Guid("72ce0538-77cb-4738-86a4-db5f74a79f2e"), "Address 27", "Cinema Center 27" },
                    { new Guid("75ae46ab-bb42-48a0-ac95-ac5b7f72289e"), "Address 17", "Cinema Center 17" },
                    { new Guid("78b6c6b0-212e-4582-9c31-68d15056d3ec"), "Address 9", "Cinema Center 9" },
                    { new Guid("799559d7-7c44-43b6-80ba-6d5bcc012934"), "Address 10", "Cinema Center 10" },
                    { new Guid("7b6669ba-5dc7-46b5-8731-93bdf681f358"), "Address 22", "Cinema Center 22" },
                    { new Guid("82bfb838-8074-4d43-97e3-af625430b1e5"), "Address 7", "Cinema Center 7" },
                    { new Guid("8fe002c4-d845-4ee0-8d55-29212c6618ef"), "Address 25", "Cinema Center 25" },
                    { new Guid("94a99957-ebfa-46b3-af5f-877e6116b5df"), "Address 28", "Cinema Center 28" },
                    { new Guid("9586d3ff-46f6-4058-9bdc-cba2f987d645"), "Address 29", "Cinema Center 29" },
                    { new Guid("9915451c-1ab7-447e-8427-fa87158c3911"), "Address 24", "Cinema Center 24" },
                    { new Guid("a231f257-80fa-45b4-bdbd-178ca5c4cbb9"), "Address 21", "Cinema Center 21" },
                    { new Guid("a7fe53d1-c4e3-4d98-a6ad-bad2cd2c90fd"), "Address 3", "Cinema Center 3" },
                    { new Guid("aba76668-45cf-4a71-8c04-d03a22604d8d"), "Address 2", "Cinema Center 2" },
                    { new Guid("ae2be624-42ba-4371-ae06-f36766b74a1a"), "Address 13", "Cinema Center 13" },
                    { new Guid("b2408ebd-0143-4fe9-9197-0306a750e952"), "Address 18", "Cinema Center 18" },
                    { new Guid("b33761ea-2f8f-46ae-8a72-923adb87001f"), "Address 26", "Cinema Center 26" },
                    { new Guid("c389e092-7635-49b9-80ed-2e966606e152"), "Address 6", "Cinema Center 6" },
                    { new Guid("c70f5021-d95c-4168-b488-90cad88042ce"), "Address 5", "Cinema Center 5" },
                    { new Guid("d0566c92-c9d5-45c8-9d3b-a632f7c5e874"), "Address 30", "Cinema Center 30" },
                    { new Guid("d0718ece-1e1c-41fe-8e2d-fe043626f3b6"), "Address 19", "Cinema Center 19" },
                    { new Guid("d67c6d99-0ff9-4426-90f7-aad61ad3f313"), "Address 12", "Cinema Center 12" },
                    { new Guid("dbdf57c7-b24f-492a-8547-a7a1b6c059a7"), "Address 15", "Cinema Center 15" },
                    { new Guid("f727c7c2-313f-40e6-9cba-bc33a0a4896d"), "Address 11", "Cinema Center 11" }
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
                    { new Guid("0a5e059e-3f6e-4960-bb18-b5eb49f34dd7"), "Combo 25", 50000m },
                    { new Guid("0b948319-5f77-439e-ae6c-cea50a122a17"), "Combo 18", 80000m },
                    { new Guid("12fed860-0940-40c6-afe0-49717f9fa027"), "Combo 23", 30000m },
                    { new Guid("1a3d6868-b3ac-4c52-8ef0-45de0ea05893"), "Combo 20", 0m },
                    { new Guid("1faeff73-88ef-4b83-932f-54e528c16332"), "Combo 15", 50000m },
                    { new Guid("2c6981ca-c46b-463b-b59f-9cc2a665731a"), "Combo 1", 10000m },
                    { new Guid("2e4caadc-cc9d-4c1c-8d8c-42ef7b42ded3"), "Combo 29", 90000m },
                    { new Guid("325c02c3-25c2-41b8-a80b-ff83fc25f630"), "Combo 7", 70000m },
                    { new Guid("4ac882d2-168d-43d3-8283-1746278172e3"), "Combo 8", 80000m },
                    { new Guid("4b5e2b04-398b-4617-9a58-55569f82be5a"), "Combo 24", 40000m },
                    { new Guid("58c1e54f-eb5d-41cd-8853-32b17a93dd8e"), "Combo 10", 0m },
                    { new Guid("64b55597-7e87-4c7c-9dee-28a68cae0c42"), "Combo 30", 0m },
                    { new Guid("73bf0989-d589-410d-8f41-d0215b550eb4"), "Combo 9", 90000m },
                    { new Guid("75044332-37b9-4200-806e-4fe0131f52a3"), "Combo 11", 10000m },
                    { new Guid("7a95e2f8-35d2-4c1a-95b2-f5c294b46d00"), "Combo 13", 30000m },
                    { new Guid("7da7fdaa-669e-4136-b195-cf5124634ce0"), "Combo 19", 90000m },
                    { new Guid("8cef5b4e-ec02-4f07-a7ec-0e146523f0c3"), "Combo 17", 70000m },
                    { new Guid("9338d499-c412-4644-b669-0c2686e0122b"), "Combo 16", 60000m },
                    { new Guid("9fc9a923-61fa-422b-971b-9261e2aff2d4"), "Combo 22", 20000m },
                    { new Guid("b61c9ab8-e51d-49f2-a499-f40a01e3997b"), "Combo 28", 80000m },
                    { new Guid("b764b804-0e28-49e5-84f2-64824c4f1c33"), "Combo 2", 20000m },
                    { new Guid("b8684907-a50b-4b87-a3cf-1d23b754d057"), "Combo 6", 60000m },
                    { new Guid("bd53492c-ec1b-42b0-a095-433ffc8c98b8"), "Combo 12", 20000m },
                    { new Guid("c372c08c-9b39-4ba2-a7d1-167eaaa68396"), "Combo 26", 60000m },
                    { new Guid("c38f791a-6d87-4b71-8f47-276c0df6a41a"), "Combo 3", 30000m },
                    { new Guid("c9113f9c-6e9c-4f90-befb-d1f16ab50889"), "Combo 14", 40000m },
                    { new Guid("cdc48a92-3fcf-433d-a7fc-58840a29f879"), "Combo 27", 70000m },
                    { new Guid("d2ead2c2-704b-41b3-a335-b6895a7682aa"), "Combo 21", 10000m },
                    { new Guid("f7cd643f-0a76-4788-afe4-dfa2b2778b03"), "Combo 5", 50000m },
                    { new Guid("ff47e751-7347-4a64-bf46-288500ce8d53"), "Combo 4", 40000m }
                });

            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "Id", "Cast", "CreatDate", "Description", "Director", "EnglishName", "Gerne", "Language", "Name", "Nation", "Poster", "Rating", "ReleaseYear", "RunningTime", "ScreenTypeId", "StartDate", "Status", "Trailer", "TranslationTypeId" },
                values: new object[,]
                {
                    { new Guid("073e9f64-7da6-41f9-81bc-734e1b063143"), "Actor 6, Actress 6", new DateTime(2023, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 6.", "Director 6", "Film 6 (English)", "Action", "English", "Film 6", "USA", "film_fake.jpg", 2, 2023, 66, new Guid("24a5e083-becb-4f78-824c-a881c0e146cd"), new DateTime(2023, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer6.mp4", new Guid("67c16729-c2ee-41ab-9238-fc35178597b3") },
                    { new Guid("18fea777-3726-4a22-890a-f7e6aeb52d45"), "Actor 19, Actress 19", new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 19.", "Director 19", "Film 19 (English)", "Comedy", "Japanese", "Film 19", "Japan", "film_fake.jpg", 5, 2023, 79, new Guid("06db104f-aade-471f-ad66-d7604edc97c2"), new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer19.mp4", new Guid("a1815b66-3484-46fc-952f-1fc15c3cf807") },
                    { new Guid("22b245ce-e209-4039-8779-d5742f05a8af"), "Actor 26, Actress 26", new DateTime(2023, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 26.", "Director 26", "Film 26 (English)", "Action", "English", "Film 26", "USA", "film_fake.jpg", 2, 2023, 86, new Guid("47287e10-fb35-4934-947c-738e027559cd"), new DateTime(2023, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer26.mp4", new Guid("a8295ed1-91d6-4f5d-aaf9-23b169013e95") },
                    { new Guid("24b33fd3-c227-48d4-8304-b01f9e977e0b"), "Actor 4, Actress 4", new DateTime(2023, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 4.", "Director 4", "Film 4 (English)", "Action", "English", "Film 4", "USA", "film_fake.jpg", 5, 2023, 64, new Guid("fdca0f20-376e-43fb-92dc-208eded31b6f"), new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer4.mp4", new Guid("4c152535-2870-46f7-bec8-b84c8c1b7e4d") },
                    { new Guid("2b269958-33b6-4b80-966a-9bff4f77aaff"), "Actor 28, Actress 28", new DateTime(2023, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 28.", "Director 28", "Film 28 (English)", "Action", "English", "Film 28", "USA", "film_fake.jpg", 4, 2023, 88, new Guid("a8997304-017d-41a7-955c-6a97eeac70b6"), new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer28.mp4", new Guid("6e27ed47-ece8-4fa4-b0ca-6078d381c026") },
                    { new Guid("2e433041-aca1-438d-b491-ab19f072ae56"), "Actor 10, Actress 10", new DateTime(2023, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 10.", "Director 10", "Film 10 (English)", "Action", "English", "Film 10", "USA", "film_fake.jpg", 1, 2023, 70, new Guid("2b1a29ac-f311-4449-b389-7f57e6624bdc"), new DateTime(2023, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer10.mp4", new Guid("1d9f3747-963f-47e9-ae50-edea69dd6826") },
                    { new Guid("34728e79-06aa-4979-9a73-18878eae0856"), "Actor 12, Actress 12", new DateTime(2023, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 12.", "Director 12", "Film 12 (English)", "Action", "English", "Film 12", "USA", "film_fake.jpg", 3, 2023, 72, new Guid("516c6f71-0a4e-4654-9733-867aa07d79a0"), new DateTime(2023, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer12.mp4", new Guid("7dd6a27b-08c5-473d-9985-c5e290b4c9c2") },
                    { new Guid("39847e7b-a7f9-473c-8e69-359451cdad2e"), "Actor 1, Actress 1", new DateTime(2023, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 1.", "Director 1", "Film 1 (English)", "Comedy", "Japanese", "Film 1", "Japan", "film_fake.jpg", 2, 2023, 61, new Guid("2daa5da4-4568-4067-bd0d-815ba5f39f2d"), new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer1.mp4", new Guid("80f0b303-07bc-4843-b4d0-5be3cc22c9b7") },
                    { new Guid("3b28a9f2-7d94-467d-9caa-a755ff685ee8"), "Actor 25, Actress 25", new DateTime(2023, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 25.", "Director 25", "Film 25 (English)", "Comedy", "Japanese", "Film 25", "Japan", "film_fake.jpg", 1, 2023, 85, new Guid("5add65ad-f465-4ab4-a935-3543d8ca0b86"), new DateTime(2023, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer25.mp4", new Guid("f9170efd-4889-4801-8c08-11e9b5bbea50") },
                    { new Guid("3c1bac2e-6287-44c8-9c5c-22bfb0f76a57"), "Actor 7, Actress 7", new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 7.", "Director 7", "Film 7 (English)", "Comedy", "Japanese", "Film 7", "Japan", "film_fake.jpg", 3, 2023, 67, new Guid("9ad4a057-270f-42be-b1fb-9c2b89fc0871"), new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer7.mp4", new Guid("2f8bc44c-1418-4b32-b84c-88a75afa376c") },
                    { new Guid("433fa649-d62d-499a-94e3-63454e4d2170"), "Actor 3, Actress 3", new DateTime(2023, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 3.", "Director 3", "Film 3 (English)", "Comedy", "Japanese", "Film 3", "Japan", "film_fake.jpg", 4, 2023, 63, new Guid("f9b83fbc-3c8e-4900-bfa1-e19027c78432"), new DateTime(2023, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer3.mp4", new Guid("b3a0580b-6c29-4f10-b39b-86e7ba87fc18") },
                    { new Guid("5168145c-4cbb-4a8d-bdea-3639e2f0b6df"), "Actor 14, Actress 14", new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 14.", "Director 14", "Film 14 (English)", "Action", "English", "Film 14", "USA", "film_fake.jpg", 5, 2023, 74, new Guid("15c899e9-7e38-4888-af8f-6bc4ab12abf2"), new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer14.mp4", new Guid("cb48410a-7d95-4fd0-88a1-738ab03fbd32") },
                    { new Guid("5d9910f7-57dd-49fa-983c-0d655e08744a"), "Actor 24, Actress 24", new DateTime(2023, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 24.", "Director 24", "Film 24 (English)", "Action", "English", "Film 24", "USA", "film_fake.jpg", 5, 2023, 84, new Guid("9a287a86-63c1-4c2a-81f9-0a238ad938b1"), new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer24.mp4", new Guid("aa807fe8-a7fb-4644-9a9e-4811b3c29bc9") },
                    { new Guid("649aeb7d-632c-4f53-97e2-0c7f827fe5d5"), "Actor 16, Actress 16", new DateTime(2023, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 16.", "Director 16", "Film 16 (English)", "Action", "English", "Film 16", "USA", "film_fake.jpg", 2, 2023, 76, new Guid("46fe4942-80dc-4985-b0fa-e44806d3d978"), new DateTime(2023, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer16.mp4", new Guid("308eee2f-a35c-4cc0-a042-e2ccee5af2ee") },
                    { new Guid("6e3fd909-246d-47be-a2b9-c3169ea18d60"), "Actor 18, Actress 18", new DateTime(2023, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 18.", "Director 18", "Film 18 (English)", "Action", "English", "Film 18", "USA", "film_fake.jpg", 4, 2023, 78, new Guid("8081f230-5a36-4cd8-89c2-6f4e51910161"), new DateTime(2023, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer18.mp4", new Guid("e8ad11fe-38b6-4302-b6b1-7763d2aabb0a") },
                    { new Guid("7247b4ae-8e10-4012-81fb-0146ef3a1adf"), "Actor 5, Actress 5", new DateTime(2023, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 5.", "Director 5", "Film 5 (English)", "Comedy", "Japanese", "Film 5", "Japan", "film_fake.jpg", 1, 2023, 65, new Guid("c3d2d8c2-d697-4ce4-98c1-35b2f64f78a0"), new DateTime(2023, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer5.mp4", new Guid("6f7a486a-9dc9-4115-8464-fa6f66263113") },
                    { new Guid("7822c70d-8e8c-4b36-b4b8-065eb2d82a3e"), "Actor 22, Actress 22", new DateTime(2023, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 22.", "Director 22", "Film 22 (English)", "Action", "English", "Film 22", "USA", "film_fake.jpg", 3, 2023, 82, new Guid("59ed6f91-84f2-4264-a7ea-215d87fbb48b"), new DateTime(2023, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer22.mp4", new Guid("a6c89aa7-5226-4804-97f7-a95ad972a4dc") },
                    { new Guid("8cf13b57-c89b-4aa1-93e5-6fbc6e725c98"), "Actor 11, Actress 11", new DateTime(2023, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 11.", "Director 11", "Film 11 (English)", "Comedy", "Japanese", "Film 11", "Japan", "film_fake.jpg", 2, 2023, 71, new Guid("120dab7b-a20b-4753-bedf-6c719f97555f"), new DateTime(2023, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer11.mp4", new Guid("f2e6ab2f-2073-4307-9103-558433c50374") },
                    { new Guid("8efe2a39-72a1-4e76-951f-06dba87f7256"), "Actor 20, Actress 20", new DateTime(2023, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 20.", "Director 20", "Film 20 (English)", "Action", "English", "Film 20", "USA", "film_fake.jpg", 1, 2023, 80, new Guid("3d85248f-5628-49fc-bd62-f208338d731b"), new DateTime(2023, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer20.mp4", new Guid("4879de4d-cffe-442b-bef3-66c0d2a21978") },
                    { new Guid("96a1c7af-2a5f-41a2-a4cc-f91dbca8daac"), "Actor 15, Actress 15", new DateTime(2023, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 15.", "Director 15", "Film 15 (English)", "Comedy", "Japanese", "Film 15", "Japan", "film_fake.jpg", 1, 2023, 75, new Guid("b49f06df-4e1f-46fd-b9d5-57a1777729d8"), new DateTime(2023, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer15.mp4", new Guid("dce45936-cfea-4e01-8dad-1ad991c3ee17") },
                    { new Guid("9810291e-4391-40ee-bc0d-f4cf84318fb5"), "Actor 2, Actress 2", new DateTime(2023, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 2.", "Director 2", "Film 2 (English)", "Action", "English", "Film 2", "USA", "film_fake.jpg", 3, 2023, 62, new Guid("fec36de5-86c3-440e-86e4-c809690be6be"), new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer2.mp4", new Guid("afc1534f-6421-4913-bebf-29b5b3294bee") },
                    { new Guid("9bceb03a-a2f2-40b0-bc55-bfb55e4e8690"), "Actor 23, Actress 23", new DateTime(2023, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 23.", "Director 23", "Film 23 (English)", "Comedy", "Japanese", "Film 23", "Japan", "film_fake.jpg", 4, 2023, 83, new Guid("afc124e4-1815-4859-9ed9-6c96059a7d0b"), new DateTime(2023, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer23.mp4", new Guid("0dbf5d95-d9e1-4793-b0fa-73435ab7a1dd") },
                    { new Guid("ae216a68-1c4d-4d4f-806d-854935e1c5a0"), "Actor 13, Actress 13", new DateTime(2023, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 13.", "Director 13", "Film 13 (English)", "Comedy", "Japanese", "Film 13", "Japan", "film_fake.jpg", 4, 2023, 73, new Guid("d5690ec4-eba5-4c29-a8dd-f35650b9f3cb"), new DateTime(2023, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer13.mp4", new Guid("8114bd2a-1613-453e-ac1b-47c82c8405c7") },
                    { new Guid("b7fd5c99-8da1-4086-8af7-8dc2eab178a4"), "Actor 9, Actress 9", new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 9.", "Director 9", "Film 9 (English)", "Comedy", "Japanese", "Film 9", "Japan", "film_fake.jpg", 5, 2023, 69, new Guid("7370be17-6e7d-471a-8cce-ef0b4a8553be"), new DateTime(2023, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer9.mp4", new Guid("f8741c5d-f9a7-4979-b5bf-f8e45c9b0953") },
                    { new Guid("b9e71344-3a19-49b2-80f2-4b6869616657"), "Actor 30, Actress 30", new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 30.", "Director 30", "Film 30 (English)", "Action", "English", "Film 30", "USA", "film_fake.jpg", 1, 2023, 90, new Guid("0b6b0444-802e-4db1-80b1-29169a7f5e81"), new DateTime(2023, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer30.mp4", new Guid("41403a14-8b97-4d62-a5ef-dca1fcb29192") },
                    { new Guid("bfbacdf7-1e08-4627-9dea-1211792009e6"), "Actor 27, Actress 27", new DateTime(2023, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 27.", "Director 27", "Film 27 (English)", "Comedy", "Japanese", "Film 27", "Japan", "film_fake.jpg", 3, 2023, 87, new Guid("caa9381a-56a2-4677-ac25-30f909c8de71"), new DateTime(2023, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer27.mp4", new Guid("5789641b-98d3-4de8-bcba-79f9cffde35f") },
                    { new Guid("c352e249-845a-4a65-92dc-096718447df8"), "Actor 8, Actress 8", new DateTime(2023, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 8.", "Director 8", "Film 8 (English)", "Action", "English", "Film 8", "USA", "film_fake.jpg", 4, 2023, 68, new Guid("347b8784-c355-44da-8f5d-12bb77e7cd73"), new DateTime(2023, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer8.mp4", new Guid("40a6d98a-daa1-4d28-bf6a-ed142f06a336") },
                    { new Guid("c5d31102-c217-4989-99d0-2e7da5a26e12"), "Actor 29, Actress 29", new DateTime(2023, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 29.", "Director 29", "Film 29 (English)", "Comedy", "Japanese", "Film 29", "Japan", "film_fake.jpg", 5, 2023, 89, new Guid("044ba5ed-e5dd-4ade-bd54-9cb519e8dcf4"), new DateTime(2023, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer29.mp4", new Guid("b953ad0c-ab5c-442d-9c4d-04d09cc957bb") },
                    { new Guid("e59fc7dd-f635-4109-b090-1d4150483b95"), "Actor 17, Actress 17", new DateTime(2023, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 17.", "Director 17", "Film 17 (English)", "Comedy", "Japanese", "Film 17", "Japan", "film_fake.jpg", 3, 2023, 77, new Guid("75aa1ea1-87ee-4129-aeb1-6f9a0ea2a949"), new DateTime(2023, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer17.mp4", new Guid("2538bb34-f89d-498e-9836-dde6218a4674") },
                    { new Guid("faabedb7-6f8f-47ac-bdff-6a9f1ecb6d53"), "Actor 21, Actress 21", new DateTime(2023, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 21.", "Director 21", "Film 21 (English)", "Comedy", "Japanese", "Film 21", "Japan", "film_fake.jpg", 2, 2023, 81, new Guid("c952a2f4-ea7e-4bf3-ab3e-1d24b95011e9"), new DateTime(2023, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer21.mp4", new Guid("4a4e9495-90a8-446b-88bd-c7ed574f0ee2") }
                });

            migrationBuilder.InsertData(
                table: "Promotions",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("0705c484-1554-4e7e-9f23-4f5029195d65"), "Title 6" },
                    { new Guid("126e1105-7622-414d-bf88-770c72fb03b2"), "Title 25" },
                    { new Guid("13f24496-987d-4676-8a62-f63003250fa6"), "Title 9" },
                    { new Guid("17f86fcf-3a5a-407c-b25c-59da31d165b0"), "Title 10" },
                    { new Guid("192a7aed-c170-46e3-8a0f-5b7676bc1359"), "Title 29" },
                    { new Guid("20339814-8e18-4c79-adb5-bc15729c4420"), "Title 11" },
                    { new Guid("2431c0dd-c0fe-4ee7-8dd4-db976227f2fd"), "Title 1" },
                    { new Guid("2c876ebc-56cb-42a9-aa7f-7d03d34d4878"), "Title 18" },
                    { new Guid("2dd9d284-3066-4da2-b643-b96780747f4f"), "Title 3" },
                    { new Guid("42458d9b-17b8-4084-9ad6-cbd01c7205ad"), "Title 7" },
                    { new Guid("43663dd0-c21f-405d-9d6f-1321aa0349f7"), "Title 19" },
                    { new Guid("553f18b5-fbc0-4e3c-953b-87fe8c27ab25"), "Title 5" },
                    { new Guid("6824c3eb-8185-4618-a2de-9f78f8b8657a"), "Title 23" },
                    { new Guid("6f59fae1-b72b-4446-a2bf-5d911128b1cb"), "Title 20" },
                    { new Guid("7ad3f9e1-6e43-45a7-95af-4dfadeae05fd"), "Title 16" },
                    { new Guid("80b2f269-55f8-462b-bc86-a0d5088fc14b"), "Title 2" },
                    { new Guid("85c45197-4afe-4580-9b6d-389ef1f15cf5"), "Title 24" },
                    { new Guid("86b0f84b-ea31-4960-8a55-42366f64fe3c"), "Title 22" },
                    { new Guid("86bd1bf8-e0dc-4060-95ee-9426e41b7023"), "Title 8" },
                    { new Guid("abd25612-2420-4d29-913a-3a52a2a82ec6"), "Title 28" },
                    { new Guid("aeb508d4-5446-436e-a576-1371d8d3efcf"), "Title 27" },
                    { new Guid("b7fad5d6-5653-447b-80fa-b19a9a5aa0d2"), "Title 13" },
                    { new Guid("b9a673e8-4675-48c0-b5fa-f60c1ef3b952"), "Title 12" },
                    { new Guid("dbb2a4ea-64de-474f-aa6e-e1a5b7369e78"), "Title 17" },
                    { new Guid("dc801d3e-6f0c-4714-81ac-93f058356126"), "Title 30" },
                    { new Guid("dde5bbd9-9290-4140-a1ed-b3e8dfc124f0"), "Title 26" },
                    { new Guid("e640aac9-ae41-437e-8d52-c56c426b0b61"), "Title 4" },
                    { new Guid("eaca3f7a-84db-43cd-869e-c8e3cce89847"), "Title 15" },
                    { new Guid("f1f79992-e1f2-4fbc-9aa0-845054022916"), "Title 21" },
                    { new Guid("ff6ed476-a56f-478f-a556-51ed9aea8302"), "Title 14" }
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
                    { new Guid("06306ba2-b3e8-44cd-8786-c08a2e2d5ada"), new Guid("d0718ece-1e1c-41fe-8e2d-fe043626f3b6"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 10, "Description for Cinema 19", 100, "Cinema 19", 10 },
                    { new Guid("11806a9b-27a7-41eb-a6bb-4fd80352d1ec"), new Guid("d0566c92-c9d5-45c8-9d3b-a632f7c5e874"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 10, "Description for Cinema 30", 100, "Cinema 30", 10 },
                    { new Guid("1fca244b-748e-4aa7-b3fa-44cceff604c8"), new Guid("9915451c-1ab7-447e-8427-fa87158c3911"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 10, "Description for Cinema 24", 100, "Cinema 24", 10 },
                    { new Guid("27622177-ed08-44fa-afe8-9c46e89ee6e8"), new Guid("75ae46ab-bb42-48a0-ac95-ac5b7f72289e"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 10, "Description for Cinema 17", 100, "Cinema 17", 10 },
                    { new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), new Guid("713d97e0-456c-4e33-ab26-203625e4ebf7"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 10, "Description for Cinema 1", 100, "Cinema 1", 10 },
                    { new Guid("3ffd7564-bd1b-46d0-99db-230e1ddb6ce1"), new Guid("a7fe53d1-c4e3-4d98-a6ad-bad2cd2c90fd"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 10, "Description for Cinema 3", 100, "Cinema 3", 10 },
                    { new Guid("505eeda1-bff3-4b04-9b6d-6de7f69b6cfd"), new Guid("9586d3ff-46f6-4058-9bdc-cba2f987d645"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 10, "Description for Cinema 29", 100, "Cinema 29", 10 },
                    { new Guid("556e25f2-7ea6-49a7-8417-0bf1a5c8e349"), new Guid("ae2be624-42ba-4371-ae06-f36766b74a1a"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 10, "Description for Cinema 13", 100, "Cinema 13", 10 },
                    { new Guid("60214384-01a7-49d5-b610-4c81b1e25afe"), new Guid("2f2b8c56-c334-4dc8-b125-5c8fc81aa75a"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 10, "Description for Cinema 16", 100, "Cinema 16", 10 },
                    { new Guid("6889322a-df97-4349-be4f-5fdfc59d028d"), new Guid("b2408ebd-0143-4fe9-9197-0306a750e952"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 10, "Description for Cinema 18", 100, "Cinema 18", 10 },
                    { new Guid("6a8ff52a-86d3-4435-b8d6-cbf625d77be8"), new Guid("8fe002c4-d845-4ee0-8d55-29212c6618ef"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 10, "Description for Cinema 25", 100, "Cinema 25", 10 },
                    { new Guid("7619a7e4-1dd0-4946-83f7-499c4e004220"), new Guid("d67c6d99-0ff9-4426-90f7-aad61ad3f313"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 10, "Description for Cinema 12", 100, "Cinema 12", 10 },
                    { new Guid("7f147b06-d13d-47eb-99e5-0751c89ccd8c"), new Guid("72ce0538-77cb-4738-86a4-db5f74a79f2e"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 10, "Description for Cinema 27", 100, "Cinema 27", 10 },
                    { new Guid("7f50f725-3177-43cc-bdc9-f4a0d50723d0"), new Guid("aba76668-45cf-4a71-8c04-d03a22604d8d"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 10, "Description for Cinema 2", 100, "Cinema 2", 10 },
                    { new Guid("84f5062b-579b-49cf-b903-0bd00472f6d2"), new Guid("562703b6-f408-4340-9651-780c11395069"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 10, "Description for Cinema 23", 100, "Cinema 23", 10 },
                    { new Guid("964014ed-a801-4559-a365-c84a8904b58e"), new Guid("82bfb838-8074-4d43-97e3-af625430b1e5"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 10, "Description for Cinema 7", 100, "Cinema 7", 10 },
                    { new Guid("9a98571b-3977-4dba-8b4b-50794946f2e2"), new Guid("dbdf57c7-b24f-492a-8547-a7a1b6c059a7"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 10, "Description for Cinema 15", 100, "Cinema 15", 10 },
                    { new Guid("9bc3fe53-5e19-4447-b6f6-49b3d3aa6b99"), new Guid("c389e092-7635-49b9-80ed-2e966606e152"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 10, "Description for Cinema 6", 100, "Cinema 6", 10 },
                    { new Guid("9df8dd15-0024-4015-b768-55e6fe2cf376"), new Guid("94a99957-ebfa-46b3-af5f-877e6116b5df"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 10, "Description for Cinema 28", 100, "Cinema 28", 10 },
                    { new Guid("aa78626e-a41e-47ef-b31e-8f0ae92aea3b"), new Guid("a231f257-80fa-45b4-bdbd-178ca5c4cbb9"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 10, "Description for Cinema 21", 100, "Cinema 21", 10 },
                    { new Guid("b3d39eda-1560-428f-8225-7e587936960c"), new Guid("799559d7-7c44-43b6-80ba-6d5bcc012934"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 10, "Description for Cinema 10", 100, "Cinema 10", 10 },
                    { new Guid("c4641c03-beb1-4bc2-baa0-ed7bb4f175be"), new Guid("b33761ea-2f8f-46ae-8a72-923adb87001f"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 10, "Description for Cinema 26", 100, "Cinema 26", 10 },
                    { new Guid("cb354c2c-76bc-4ee6-8f3d-0d58fab80933"), new Guid("f727c7c2-313f-40e6-9cba-bc33a0a4896d"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 10, "Description for Cinema 11", 100, "Cinema 11", 10 },
                    { new Guid("dff19976-0960-4544-9f23-fa6e468cb5c9"), new Guid("c70f5021-d95c-4168-b488-90cad88042ce"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 10, "Description for Cinema 5", 100, "Cinema 5", 10 },
                    { new Guid("e3e244ab-8e8e-4341-81e1-3e2eafef99fe"), new Guid("3378ec63-e87d-4d8c-8739-ccd64ff4a053"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 10, "Description for Cinema 8", 100, "Cinema 8", 10 },
                    { new Guid("e62d783e-6ddb-4c0e-94df-776f0e76f236"), new Guid("374ccabe-cae4-4389-ac12-a1b327c912ff"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 10, "Description for Cinema 20", 100, "Cinema 20", 10 },
                    { new Guid("eb152661-bf42-4655-a699-6aa9f89fb12a"), new Guid("6062cd97-0dbf-42a4-88cc-4e870ad66f2b"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 10, "Description for Cinema 4", 100, "Cinema 4", 10 },
                    { new Guid("f1b523f0-4663-4a4c-8cf6-5b2087a4797c"), new Guid("7b6669ba-5dc7-46b5-8731-93bdf681f358"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 10, "Description for Cinema 22", 100, "Cinema 22", 10 },
                    { new Guid("f4a7ad7b-ada8-42d6-93f9-b334d8bec1ab"), new Guid("0740e6ae-a711-41c2-8515-1e743d7b4682"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 10, "Description for Cinema 14", 100, "Cinema 14", 10 },
                    { new Guid("f8053902-8714-4ec0-bd6a-ffc268ee6186"), new Guid("78b6c6b0-212e-4582-9c31-68d15056d3ec"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 10, "Description for Cinema 9", 100, "Cinema 9", 10 }
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
                    { new Guid("05c1d5c6-b2f8-472e-91f5-51686fdad516"), new DateTime(2023, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("39847e7b-a7f9-473c-8e69-359451cdad2e"), new DateTime(2023, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { new Guid("0e368e86-563c-405f-bb6c-d6e67244f020"), new DateTime(2023, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("faabedb7-6f8f-47ac-bdff-6a9f1ecb6d53"), new DateTime(2023, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { new Guid("12b01a89-6f50-4876-bf67-26a12ef8eaa7"), new DateTime(2023, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("24b33fd3-c227-48d4-8304-b01f9e977e0b"), new DateTime(2023, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { new Guid("287ff4af-d81c-4a0c-a4dc-5255b3170c8f"), new DateTime(2023, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("649aeb7d-632c-4f53-97e2-0c7f827fe5d5"), new DateTime(2023, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { new Guid("2c21db2f-7c44-4df2-afbe-0249a95b6f4a"), new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("073e9f64-7da6-41f9-81bc-734e1b063143"), new DateTime(2023, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { new Guid("3733e798-001d-42e3-9789-192b59fd0040"), new DateTime(2023, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22b245ce-e209-4039-8779-d5742f05a8af"), new DateTime(2023, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { new Guid("3ca8bfd1-bb30-4b81-a325-0fb10b9cb2ff"), new DateTime(2023, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("9810291e-4391-40ee-bc0d-f4cf84318fb5"), new DateTime(2023, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { new Guid("5ed1b273-a900-4b84-9c13-f8e5bd27dc09"), new DateTime(2023, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7822c70d-8e8c-4b36-b4b8-065eb2d82a3e"), new DateTime(2023, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { new Guid("60646501-70f7-4660-b86c-3d828ccb9024"), new DateTime(2023, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("433fa649-d62d-499a-94e3-63454e4d2170"), new DateTime(2023, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { new Guid("64ada421-c00e-47c2-8d08-0b2f4c817943"), new DateTime(2023, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("34728e79-06aa-4979-9a73-18878eae0856"), new DateTime(2023, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { new Guid("64b2cb82-6104-4da1-8e93-397026a2a3ea"), new DateTime(2023, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7247b4ae-8e10-4012-81fb-0146ef3a1adf"), new DateTime(2023, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { new Guid("65cd7fbf-c739-41d9-92dd-caa0eb96121b"), new DateTime(2023, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bfbacdf7-1e08-4627-9dea-1211792009e6"), new DateTime(2023, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { new Guid("6f95b332-b766-4b99-ab72-cdd8a7fd62b9"), new DateTime(2023, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5168145c-4cbb-4a8d-bdea-3639e2f0b6df"), new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { new Guid("7533e0e5-05f4-4716-bc65-c0ded11f250a"), new DateTime(2023, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("9bceb03a-a2f2-40b0-bc55-bfb55e4e8690"), new DateTime(2023, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { new Guid("7c67fdaa-deda-4edd-9517-1f6a2beaf70f"), new DateTime(2023, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b7fd5c99-8da1-4086-8af7-8dc2eab178a4"), new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { new Guid("7d36102b-75a6-470e-961b-e1729d4a8be4"), new DateTime(2023, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3b28a9f2-7d94-467d-9caa-a755ff685ee8"), new DateTime(2023, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { new Guid("7e085d92-f989-4790-99b6-7ee060e6634d"), new DateTime(2023, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3c1bac2e-6287-44c8-9c5c-22bfb0f76a57"), new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { new Guid("7e4be017-32de-4763-9884-1cfed585cf83"), new DateTime(2023, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8efe2a39-72a1-4e76-951f-06dba87f7256"), new DateTime(2023, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { new Guid("84ad461c-2008-4b9d-a2db-ca1f0ccf93b1"), new DateTime(2023, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("96a1c7af-2a5f-41a2-a4cc-f91dbca8daac"), new DateTime(2023, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { new Guid("8840b38f-32dd-4a1e-b7fb-87001ec975c7"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b9e71344-3a19-49b2-80f2-4b6869616657"), new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { new Guid("975d0a83-23c6-4fd7-bd4a-3d0a95206265"), new DateTime(2023, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5d9910f7-57dd-49fa-983c-0d655e08744a"), new DateTime(2023, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { new Guid("9e82bddd-d0ca-4db6-91f4-6d0bfe91e97e"), new DateTime(2023, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2e433041-aca1-438d-b491-ab19f072ae56"), new DateTime(2023, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { new Guid("a4e4fa80-13c2-4b42-83ad-02b3a6a4a2b7"), new DateTime(2023, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("18fea777-3726-4a22-890a-f7e6aeb52d45"), new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { new Guid("a84527da-d1c2-4e05-9bd5-b697c574bf17"), new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c352e249-845a-4a65-92dc-096718447df8"), new DateTime(2023, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { new Guid("a8742ac1-c874-4371-8983-74a4edf130be"), new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c5d31102-c217-4989-99d0-2e7da5a26e12"), new DateTime(2023, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { new Guid("c2ca9e97-feaa-4b63-badd-728d32150e56"), new DateTime(2023, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8cf13b57-c89b-4aa1-93e5-6fbc6e725c98"), new DateTime(2023, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { new Guid("d922274a-225a-4c0e-90eb-0da2fbd325db"), new DateTime(2023, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e59fc7dd-f635-4109-b090-1d4150483b95"), new DateTime(2023, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { new Guid("dfe29b40-18fc-43bd-abb3-3742ea774fb7"), new DateTime(2023, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2b269958-33b6-4b80-966a-9bff4f77aaff"), new DateTime(2023, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { new Guid("e84b16d0-4d63-44dd-9586-563e2406eba9"), new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ae216a68-1c4d-4d4f-806d-854935e1c5a0"), new DateTime(2023, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { new Guid("efffc858-a502-4c10-a860-9b9bac3f3cb5"), new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6e3fd909-246d-47be-a2b9-c3169ea18d60"), new DateTime(2023, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "TicketPrices",
                columns: new[] { "Id", "CinemaTypeId", "Price", "ScreenTypeId", "ScreeningDayId", "SeatTypeId", "Status" },
                values: new object[,]
                {
                    { new Guid("06961681-885c-47db-be43-112d0b3983e8"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 10000m, new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new Guid("d51bee9b-54c3-4a3c-a06a-7c3940852f57"), new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("06ac71cd-896a-4192-9db4-66e55f1fbe8d"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 70000m, new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new Guid("d51bee9b-54c3-4a3c-a06a-7c3940852f57"), new Guid("428edc6b-0862-4623-b038-ac505fd554bc"), 1 },
                    { new Guid("0bf0f98c-d4bc-4a7a-8ae0-4ffacf1e23e6"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 20000m, new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new Guid("d51bee9b-54c3-4a3c-a06a-7c3940852f57"), new Guid("428edc6b-0862-4623-b038-ac505fd554bc"), 1 },
                    { new Guid("1354e144-bfb2-4b12-af25-90566c661b12"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 90000m, new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new Guid("d51bee9b-54c3-4a3c-a06a-7c3940852f57"), new Guid("d997b27a-ddb7-4ad1-a1cd-c2bd00c50cb9"), 1 },
                    { new Guid("160a58fe-f031-4cc2-8451-4ba2670f7cb7"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 30000m, new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new Guid("e4f8f494-4e25-4966-806a-7b8843d79b6b"), new Guid("428edc6b-0862-4623-b038-ac505fd554bc"), 1 },
                    { new Guid("20590e39-e764-4415-a3c6-e73064d46534"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 90000m, new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new Guid("e4f8f494-4e25-4966-806a-7b8843d79b6b"), new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("22fa0b0d-cbb3-4b7b-a7d5-f5202e6f7232"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 80000m, new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new Guid("e4f8f494-4e25-4966-806a-7b8843d79b6b"), new Guid("d997b27a-ddb7-4ad1-a1cd-c2bd00c50cb9"), 1 },
                    { new Guid("270de1b0-875f-4165-9117-ac96cd338203"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 50000m, new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new Guid("e4f8f494-4e25-4966-806a-7b8843d79b6b"), new Guid("428edc6b-0862-4623-b038-ac505fd554bc"), 1 },
                    { new Guid("3d422297-2da2-428e-b319-118f16346053"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 10000m, new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new Guid("e4f8f494-4e25-4966-806a-7b8843d79b6b"), new Guid("d997b27a-ddb7-4ad1-a1cd-c2bd00c50cb9"), 1 },
                    { new Guid("3e149012-b7e3-4aa8-8986-13838abcc261"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 20000m, new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new Guid("d51bee9b-54c3-4a3c-a06a-7c3940852f57"), new Guid("d997b27a-ddb7-4ad1-a1cd-c2bd00c50cb9"), 1 },
                    { new Guid("44cae637-055d-471f-82c8-1fe76ce101dc"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 30000m, new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("d997b27a-ddb7-4ad1-a1cd-c2bd00c50cb9"), 1 },
                    { new Guid("4ef17c71-1c8f-4f0a-bfc3-b958509a4cb9"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 70000m, new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("428edc6b-0862-4623-b038-ac505fd554bc"), 1 },
                    { new Guid("5a1c296c-8e64-4611-8546-f8e23f2bfc17"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 80000m, new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new Guid("d51bee9b-54c3-4a3c-a06a-7c3940852f57"), new Guid("428edc6b-0862-4623-b038-ac505fd554bc"), 1 },
                    { new Guid("5d743fea-8d86-4643-8a0d-41e160395209"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 0m, new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("5ea1b6f4-c92f-4623-aa80-3cbcb3988f21"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 10000m, new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new Guid("e4f8f494-4e25-4966-806a-7b8843d79b6b"), new Guid("428edc6b-0862-4623-b038-ac505fd554bc"), 1 },
                    { new Guid("6790f820-0590-4a56-9f90-3a00817b40d3"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 60000m, new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new Guid("d51bee9b-54c3-4a3c-a06a-7c3940852f57"), new Guid("d997b27a-ddb7-4ad1-a1cd-c2bd00c50cb9"), 1 },
                    { new Guid("68a06d8c-e036-4da0-a0f1-f632a83efc29"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 40000m, new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new Guid("e4f8f494-4e25-4966-806a-7b8843d79b6b"), new Guid("428edc6b-0862-4623-b038-ac505fd554bc"), 1 },
                    { new Guid("8157faf8-200b-4a1a-b577-cb86fed23d45"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 20000m, new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new Guid("d51bee9b-54c3-4a3c-a06a-7c3940852f57"), new Guid("428edc6b-0862-4623-b038-ac505fd554bc"), 1 },
                    { new Guid("82287faa-ce55-446f-a627-3863b1fff25e"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 80000m, new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new Guid("e4f8f494-4e25-4966-806a-7b8843d79b6b"), new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("99d795a8-4384-4878-99c3-5905e9c6e3fa"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 70000m, new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("d997b27a-ddb7-4ad1-a1cd-c2bd00c50cb9"), 1 },
                    { new Guid("9afb6602-af1a-4c3c-a2da-e0280a434e01"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 50000m, new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new Guid("d51bee9b-54c3-4a3c-a06a-7c3940852f57"), new Guid("428edc6b-0862-4623-b038-ac505fd554bc"), 1 },
                    { new Guid("aaa23ed1-31f1-422b-b3bc-d8fef32570ed"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 50000m, new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("d997b27a-ddb7-4ad1-a1cd-c2bd00c50cb9"), 1 },
                    { new Guid("ad8f8f1d-31d8-4582-a6d4-03384fb7d46a"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 0m, new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("428edc6b-0862-4623-b038-ac505fd554bc"), 1 },
                    { new Guid("bf8162e1-75da-4a1b-898f-3f9e040c6e92"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 60000m, new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("d997b27a-ddb7-4ad1-a1cd-c2bd00c50cb9"), 1 },
                    { new Guid("d72ddcb1-ebef-4b89-94e1-4ce38375a736"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 90000m, new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("d78984fc-e255-4a63-b3c4-b5cfdf1df002"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 30000m, new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new Guid("d51bee9b-54c3-4a3c-a06a-7c3940852f57"), new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("e594668d-a0b7-4cf0-a9ab-5c1ca087696d"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 40000m, new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("e633214f-0eff-485f-9d6f-8c7119d563af"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 0m, new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new Guid("d51bee9b-54c3-4a3c-a06a-7c3940852f57"), new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("e815b5ab-d548-4a15-a314-62f74a0b13bf"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 40000m, new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new Guid("d51bee9b-54c3-4a3c-a06a-7c3940852f57"), new Guid("428edc6b-0862-4623-b038-ac505fd554bc"), 1 },
                    { new Guid("f1400175-bef3-41fb-af49-9f3c10d40522"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 60000m, new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new Guid("d51bee9b-54c3-4a3c-a06a-7c3940852f57"), new Guid("428edc6b-0862-4623-b038-ac505fd554bc"), 1 }
                });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "Id", "ActivationStatus", "BarCode", "CreateTime", "MembershipId", "Status", "TotalMoney", "VoucherId" },
                values: new object[,]
                {
                    { new Guid("0aded26a-67c9-4649-b785-078f972e4c02"), true, "barcode4.jpg", new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 40000m, null },
                    { new Guid("0f43f5cd-b359-4b8e-8b2f-82808b60efef"), true, "barcode12.jpg", new DateTime(2024, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 20000m, null },
                    { new Guid("10aa65e8-69ac-4c4f-a24c-e6ee3776c06f"), true, "barcode13.jpg", new DateTime(2024, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 30000m, null },
                    { new Guid("2206d17f-b71c-4bba-86c7-112b8f8216fb"), true, "barcode19.jpg", new DateTime(2024, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 90000m, null },
                    { new Guid("288433f0-cf58-4dcd-a682-e8afa7b307ef"), true, "barcode25.jpg", new DateTime(2024, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 50000m, null },
                    { new Guid("441f10e6-c4c0-45f3-8d37-7df17559fe54"), true, "barcode1.jpg", new DateTime(2024, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 10000m, null },
                    { new Guid("44fd8c5d-7ec3-413f-a66b-8a7edc0f042f"), true, "barcode20.jpg", new DateTime(2024, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 0m, null },
                    { new Guid("50e640dd-814d-4d54-b56c-ed221f2793c0"), true, "barcode17.jpg", new DateTime(2024, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 70000m, null },
                    { new Guid("67b209b3-9c5c-4d96-96ab-b764c6962c10"), true, "barcode10.jpg", new DateTime(2024, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 0m, null },
                    { new Guid("6f5052b0-ce1f-46fe-ba06-af930da1e24e"), true, "barcode18.jpg", new DateTime(2024, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 80000m, null },
                    { new Guid("72477574-e7b6-499e-b67f-ac6d59f394b7"), true, "barcode23.jpg", new DateTime(2024, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 30000m, null },
                    { new Guid("7401c5f1-bbf5-436c-a2f3-0ea0dd66664c"), true, "barcode27.jpg", new DateTime(2024, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 70000m, null },
                    { new Guid("7affd4b3-b810-4a25-a17b-83da6df6106e"), true, "barcode2.jpg", new DateTime(2024, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 20000m, null },
                    { new Guid("88ac530e-249d-4cef-b7a3-2b3753ef3bc0"), true, "barcode21.jpg", new DateTime(2024, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 10000m, null },
                    { new Guid("92e9faba-6f4f-4ee0-ab2f-f29b996d82a5"), true, "barcode16.jpg", new DateTime(2024, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 60000m, null },
                    { new Guid("95181f5b-30e8-491b-8872-847a598c90af"), true, "barcode7.jpg", new DateTime(2024, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 70000m, null },
                    { new Guid("9a70b4af-8263-41c4-84d8-931eb85b8db1"), true, "barcode26.jpg", new DateTime(2024, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 60000m, null },
                    { new Guid("a7b791b7-084f-4305-8015-a5350204abf6"), true, "barcode5.jpg", new DateTime(2024, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 50000m, null },
                    { new Guid("b2e1f581-0d47-4d1e-8b75-8a505731c66a"), true, "barcode6.jpg", new DateTime(2024, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 60000m, null },
                    { new Guid("b49d57cb-0eeb-4f33-a2d3-ad69a04f2efe"), true, "barcode11.jpg", new DateTime(2024, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 10000m, null },
                    { new Guid("bdaf1fc7-a71d-416d-a960-e39c46aceef0"), true, "barcode8.jpg", new DateTime(2024, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 80000m, null },
                    { new Guid("be5f0dc7-7f5d-495f-b9d4-b8c9148bd956"), true, "barcode29.jpg", new DateTime(2024, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 90000m, null },
                    { new Guid("c802ec6b-e6c4-4aeb-b8ea-06af953d643d"), true, "barcode9.jpg", new DateTime(2024, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 90000m, null },
                    { new Guid("ca5f8cef-4a02-4891-9d00-f1cd29927794"), true, "barcode30.jpg", new DateTime(2024, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 0m, null },
                    { new Guid("cba5ee8a-ca9b-4b0a-b0d3-84042d358718"), true, "barcode28.jpg", new DateTime(2024, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 80000m, null },
                    { new Guid("d04ef227-7f23-4f62-8dbd-0c57702885d0"), true, "barcode15.jpg", new DateTime(2024, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 50000m, null },
                    { new Guid("d512da42-ede6-4fc7-b895-b41359193abc"), true, "barcode14.jpg", new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 40000m, null },
                    { new Guid("e84940fa-f17c-4ddd-99de-b54b213164fc"), true, "barcode24.jpg", new DateTime(2024, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 40000m, null },
                    { new Guid("f04e9bd6-c140-4c88-9139-706540b45aa2"), true, "barcode3.jpg", new DateTime(2024, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 30000m, null },
                    { new Guid("f904aa25-4dde-4405-9b7e-23659edd24f9"), true, "barcode22.jpg", new DateTime(2024, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 20000m, null }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CinemaId", "Position", "SeatTypeId", "Status" },
                values: new object[,]
                {
                    { new Guid("00960b0d-7a9b-4f81-a67d-450e0501aa2d"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "C8", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("0a6dfd9f-3249-460a-bd41-04d0cd814096"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "J7", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("0c49a16b-354a-49e7-a2a7-7318123cc7e5"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "H2", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("0d1a6b0a-0c14-4a29-980a-768566dc91e4"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "I5", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("182891cc-a820-4726-b1c7-f40c5f7685d6"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "B7", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("1c9bb125-84bf-47fd-868e-3d96e4962ea8"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "J5", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("1ce6289a-36c1-445c-a525-0a427af467a7"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "G5", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("1ed83ab4-6cef-4e14-ba51-0631fdc442f2"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "A4", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("23ebf585-f61d-4667-9c38-2fa2bfaa2a29"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "E7", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("247379e2-2a09-440e-82dc-97a79f628395"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "F10", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("24bbccd1-6e85-4545-aef8-e1a33dc3938d"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "D6", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("24f82de2-4120-421f-8842-0858aef40d8d"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "G7", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("267b970e-136a-492f-8f50-3140fe2bf910"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "E10", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("26c45339-7e67-4bbb-b590-1f49e8648fa5"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "F8", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("29b439b9-67e3-4ded-802f-3f312bccdd24"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "C7", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("2c40f3c0-2266-4814-a072-da98b5472478"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "C9", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("2f6deb4f-721c-4fba-be88-d2b5eb3b0f1c"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "C1", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("30f879eb-ae94-4566-971e-1afd1433c1ee"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "G6", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("359af857-b1ff-43f9-8325-cc39fd976ca2"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "F5", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("35ec0745-6549-4857-b10f-f56febbc104d"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "J10", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("36c790a9-7356-41b3-8b3f-1b6cedc6617a"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "D5", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("3860702a-3b9f-4d6e-bc4d-d5ddc06df198"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "C3", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("43ef6f69-9974-43d3-81b0-1fdf0054eba5"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "G4", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("4524fc8d-24ad-4072-8c77-7b08656c18b8"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "G1", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("4b9835d5-e2ee-4953-b283-1184ac9190d6"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "J6", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("4c6713df-2054-4816-8e0f-993466b12bde"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "C6", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("4ea8a774-1040-4c9c-b4df-75b64ce29f0b"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "D9", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("4f1479b4-867a-4be7-8c4a-86e691ad1922"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "G2", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("513efb4d-4881-4dc0-84b7-5a72d53e6703"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "H9", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("519a0f35-6de2-410e-aa82-2bff8cc296a8"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "E5", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("5308ef3e-04be-477b-8477-84816693ce4b"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "H6", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("5364783c-54ef-4774-982d-5515b62a208e"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "H3", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("53b3f557-cb04-4f04-add8-f97e9119abd8"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "H8", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("554664af-2ae8-4c77-b548-5761abe21bc6"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "D4", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("55fa66d6-e42d-420d-8dcd-d93d50c66eb4"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "B6", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("56e32851-d499-4fc1-8dcd-369785d885c9"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "B10", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("607b055f-333c-45ca-a69b-3dc1e74c8be5"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "G3", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("651f1fa8-219b-4185-b3ea-9813d0c7ddc6"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "I4", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("671ac562-a168-40bc-bc1d-8bd22808b5f0"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "I10", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("6c3a4790-0592-432e-8b23-68a60397424c"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "D1", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("6d1d65ff-1b12-45cd-9853-eec68ea6f2b1"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "F7", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("72a0cdba-bf12-466f-8312-152f846498b7"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "F6", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("753df890-6abc-4a55-aff6-88625c3a3941"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "B2", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("75e3fe57-ca1c-48e1-967a-712f5b14e6b7"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "H7", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("78396102-2065-4dd4-b7ef-4d69d0cab383"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "G8", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("7b872d28-9c14-4171-a3a3-d6c44ddffa8b"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "D2", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("7c4a74eb-03e2-4de4-99ab-0d82a21a6288"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "B9", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("7e050289-0a53-4b07-a251-734e5d4d60b2"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "A5", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("7eb72444-b56e-4f5c-9c12-ef100a2b832a"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "J4", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("7eed12f7-6021-4d87-b04c-92bc32ede9c3"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "B3", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("7f30e8cd-0fc7-48d3-997d-02e0b9e01ccb"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "J2", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("815117fc-1f04-4ad8-aa29-2396a06ff80e"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "F1", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("838240da-814a-49bd-bf6a-a3cd9c355d11"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "E2", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("858a3622-38b6-4e39-b09d-f10c69993bd2"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "B4", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("85ac3bce-fbba-49c7-aa5b-6788075518b3"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "C10", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("8ac624a0-d444-41a6-8dad-154dccf6fec6"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "I1", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("8d4ef64e-d5d5-4dd1-83fb-70c2c54b075f"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "F3", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("8f95ac38-a542-44e8-99df-26525be330ee"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "H4", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("96d9872f-f232-4fa1-bdb9-d2c79c6ab9c2"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "I8", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("97ee447c-3205-4872-bcd0-98f1835365e2"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "D8", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("9a710295-2970-4b66-9d9c-25ea9d6996d8"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "I3", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("a4b6323a-4ee9-4a70-b631-a02ee1dcbf8a"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "I2", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("a64c4419-5d16-484c-b9bf-24ed93da66d4"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "J1", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("ad4ea3fd-53d4-4fd5-a2cc-e92e8b3b2e44"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "B1", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("aeb53e9b-d36d-43dc-b248-29bc3c5379d4"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "E4", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("b0734d92-59f4-4412-9af3-6706972e818b"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "J3", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("b336a149-e836-43e1-b276-f427e7f5770e"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "A2", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("b567b7b0-090d-4cb5-8643-e47dcad96802"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "I9", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("b57be3d7-78f9-4d13-9200-bc3379c359b1"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "H5", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("b79f2d04-40a5-4145-b504-9c229a6976f0"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "H10", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("b94c0e78-2944-4b5a-89fd-dbf1d2b0eec6"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "C2", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("b9f0a759-5847-4059-b2e4-24f5f54dab07"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "J9", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("bbaa4ff8-7e1b-422e-a944-ce871e7439f8"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "J8", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("bc0ee673-a170-4d6f-bc49-eefcd2defad3"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "F9", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("bd9df3cf-6916-41c0-aaff-12c828c1fc8d"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "D3", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("c285b7a7-74e9-4d08-b1dc-0be1e2bb49d7"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "G10", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("c77a969e-cd1c-400c-8424-f22f4ec67d3d"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "A3", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("cb4ba9bc-49ce-4233-b917-f2d96bcbe31e"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "B8", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("ccf4fda7-3bfd-460e-b9ff-20158ce58aac"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "F4", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("d6f61926-8aa5-4368-996a-c7b3b96e3b20"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "E8", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("db463e87-41b3-4e52-ba40-b9c0f6d8a8ac"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "H1", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("dda21245-827d-43e8-8ebf-de2b23948bc9"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "E9", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("ddaa068f-9a5b-4593-9a92-7e07c0b08d70"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "I6", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("ddccd6b9-fa83-45c8-8868-9dbf83b5344c"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "C4", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("dfa59234-5205-4f75-92d4-946eb311487b"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "A1", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("e022d212-01d9-4733-bac6-84f0439073fa"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "C5", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("e1385b90-d5da-4ec6-a863-5287fafd9a48"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "A6", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("e42e188b-1cb5-487b-9f6c-3b8832bdf836"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "D10", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("e451daed-1c48-4432-8f9d-bed48e67ed0c"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "E3", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("e671f629-4344-4d85-88a5-bb77268f9934"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "G9", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("e93d4c33-8c0d-4875-ad31-3f949549c368"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "I7", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("ecee704d-c9c6-4302-a300-d17f6f2e3232"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "A9", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("f24eee2a-f32b-4fa1-a2c7-1244ab35f6e2"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "B5", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("f29b6d13-7839-49a1-9873-8a50a98347c0"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "E6", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("f5dc5168-b035-46b7-a37f-f20fae5ab6ac"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "A10", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("f6eaad67-3dd7-43e8-81df-01992d12e6bb"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "E1", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("f7f02748-d8c1-4ed3-a192-2c8e893b6056"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "A7", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("f8cefc53-a6ee-4b5b-9d4c-0537754a83ad"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "D7", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("f9e4e19a-f3c1-44e9-91d3-69a8203c9d3f"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "F2", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("fa6898f3-5106-4c87-acd9-dfd2d0e44433"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "A8", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 }
                });

            migrationBuilder.InsertData(
                table: "ShowTimes",
                columns: new[] { "Id", "CinemaCenterId", "CinemaId", "Desciption", "EndTime", "FilmId", "ScheduleId", "ScreenTypeId", "ShowtimeDate", "StartTime", "Status", "TranslationTypeId" },
                values: new object[,]
                {
                    { new Guid("08f33d16-eaa1-4d40-978e-f576802b95be"), new Guid("f727c7c2-313f-40e6-9cba-bc33a0a4896d"), new Guid("cb354c2c-76bc-4ee6-8f3d-0d58fab80933"), "Description for ShowTime 11", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8cf13b57-c89b-4aa1-93e5-6fbc6e725c98"), new Guid("c2ca9e97-feaa-4b63-badd-728d32150e56"), new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), null, new DateTime(2024, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("1c517b36-a9ef-42e1-97a9-24d10ed9aa02"), new Guid("c70f5021-d95c-4168-b488-90cad88042ce"), new Guid("dff19976-0960-4544-9f23-fa6e468cb5c9"), "Description for ShowTime 5", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7247b4ae-8e10-4012-81fb-0146ef3a1adf"), new Guid("64b2cb82-6104-4da1-8e93-397026a2a3ea"), new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), null, new DateTime(2024, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("24ccc3ec-dee9-4d8b-9897-3cc2e297aa83"), new Guid("82bfb838-8074-4d43-97e3-af625430b1e5"), new Guid("964014ed-a801-4559-a365-c84a8904b58e"), "Description for ShowTime 7", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3c1bac2e-6287-44c8-9c5c-22bfb0f76a57"), new Guid("7e085d92-f989-4790-99b6-7ee060e6634d"), new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), null, new DateTime(2024, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("253db7d1-dc76-403f-8444-69dd44a47411"), new Guid("b33761ea-2f8f-46ae-8a72-923adb87001f"), new Guid("c4641c03-beb1-4bc2-baa0-ed7bb4f175be"), "Description for ShowTime 26", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22b245ce-e209-4039-8779-d5742f05a8af"), new Guid("3733e798-001d-42e3-9789-192b59fd0040"), new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), null, new DateTime(2024, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("2ef00b5c-27e0-4f9f-a147-82ed6f81ed33"), new Guid("75ae46ab-bb42-48a0-ac95-ac5b7f72289e"), new Guid("27622177-ed08-44fa-afe8-9c46e89ee6e8"), "Description for ShowTime 17", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e59fc7dd-f635-4109-b090-1d4150483b95"), new Guid("d922274a-225a-4c0e-90eb-0da2fbd325db"), new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), null, new DateTime(2024, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("3eccb423-3138-43b9-b105-9b783dc11f29"), new Guid("799559d7-7c44-43b6-80ba-6d5bcc012934"), new Guid("b3d39eda-1560-428f-8225-7e587936960c"), "Description for ShowTime 10", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2e433041-aca1-438d-b491-ab19f072ae56"), new Guid("9e82bddd-d0ca-4db6-91f4-6d0bfe91e97e"), new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), null, new DateTime(2024, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("48d89161-fbdd-44ee-928a-1522f6a6448e"), new Guid("c389e092-7635-49b9-80ed-2e966606e152"), new Guid("9bc3fe53-5e19-4447-b6f6-49b3d3aa6b99"), "Description for ShowTime 6", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("073e9f64-7da6-41f9-81bc-734e1b063143"), new Guid("2c21db2f-7c44-4df2-afbe-0249a95b6f4a"), new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), null, new DateTime(2024, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("4d6237fb-d91b-4c16-a092-7c6acab509aa"), new Guid("72ce0538-77cb-4738-86a4-db5f74a79f2e"), new Guid("7f147b06-d13d-47eb-99e5-0751c89ccd8c"), "Description for ShowTime 27", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bfbacdf7-1e08-4627-9dea-1211792009e6"), new Guid("65cd7fbf-c739-41d9-92dd-caa0eb96121b"), new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), null, new DateTime(2024, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("4e87d62e-ebab-4491-940f-7ae5222c9297"), new Guid("94a99957-ebfa-46b3-af5f-877e6116b5df"), new Guid("9df8dd15-0024-4015-b768-55e6fe2cf376"), "Description for ShowTime 28", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2b269958-33b6-4b80-966a-9bff4f77aaff"), new Guid("dfe29b40-18fc-43bd-abb3-3742ea774fb7"), new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), null, new DateTime(2024, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("53a59e2e-7a8e-4e58-adeb-f7bb376fa6b8"), new Guid("aba76668-45cf-4a71-8c04-d03a22604d8d"), new Guid("7f50f725-3177-43cc-bdc9-f4a0d50723d0"), "Description for ShowTime 2", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("9810291e-4391-40ee-bc0d-f4cf84318fb5"), new Guid("3ca8bfd1-bb30-4b81-a325-0fb10b9cb2ff"), new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), null, new DateTime(2024, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("5730a49d-78fa-4c58-87f8-6b54e0891b93"), new Guid("ae2be624-42ba-4371-ae06-f36766b74a1a"), new Guid("556e25f2-7ea6-49a7-8417-0bf1a5c8e349"), "Description for ShowTime 13", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ae216a68-1c4d-4d4f-806d-854935e1c5a0"), new Guid("e84b16d0-4d63-44dd-9586-563e2406eba9"), new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), null, new DateTime(2024, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("5a095403-85bb-4434-b92e-9554dcece8a3"), new Guid("9586d3ff-46f6-4058-9bdc-cba2f987d645"), new Guid("505eeda1-bff3-4b04-9b6d-6de7f69b6cfd"), "Description for ShowTime 29", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c5d31102-c217-4989-99d0-2e7da5a26e12"), new Guid("a8742ac1-c874-4371-8983-74a4edf130be"), new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), null, new DateTime(2024, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("5dc83cb9-a4eb-4724-83bd-b844acddca7a"), new Guid("d0718ece-1e1c-41fe-8e2d-fe043626f3b6"), new Guid("06306ba2-b3e8-44cd-8786-c08a2e2d5ada"), "Description for ShowTime 19", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("18fea777-3726-4a22-890a-f7e6aeb52d45"), new Guid("a4e4fa80-13c2-4b42-83ad-02b3a6a4a2b7"), new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), null, new DateTime(2024, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("6c557a0e-acf5-4721-81ef-ca8a1677a441"), new Guid("0740e6ae-a711-41c2-8515-1e743d7b4682"), new Guid("f4a7ad7b-ada8-42d6-93f9-b334d8bec1ab"), "Description for ShowTime 14", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5168145c-4cbb-4a8d-bdea-3639e2f0b6df"), new Guid("6f95b332-b766-4b99-ab72-cdd8a7fd62b9"), new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), null, new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("77e3d6fb-149a-43b8-b9f5-c70efc0d8300"), new Guid("2f2b8c56-c334-4dc8-b125-5c8fc81aa75a"), new Guid("60214384-01a7-49d5-b610-4c81b1e25afe"), "Description for ShowTime 16", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("649aeb7d-632c-4f53-97e2-0c7f827fe5d5"), new Guid("287ff4af-d81c-4a0c-a4dc-5255b3170c8f"), new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), null, new DateTime(2024, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("7cf53c63-d4bf-4fbe-83a5-c2e8bd19df50"), new Guid("562703b6-f408-4340-9651-780c11395069"), new Guid("84f5062b-579b-49cf-b903-0bd00472f6d2"), "Description for ShowTime 23", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("9bceb03a-a2f2-40b0-bc55-bfb55e4e8690"), new Guid("7533e0e5-05f4-4716-bc65-c0ded11f250a"), new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), null, new DateTime(2024, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("84ebf4ae-7f1c-437f-92b2-7ad0d8e9b6c4"), new Guid("d67c6d99-0ff9-4426-90f7-aad61ad3f313"), new Guid("7619a7e4-1dd0-4946-83f7-499c4e004220"), "Description for ShowTime 12", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("34728e79-06aa-4979-9a73-18878eae0856"), new Guid("64ada421-c00e-47c2-8d08-0b2f4c817943"), new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), null, new DateTime(2024, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("97f97b0f-80f2-4adc-8919-5d1fac696b28"), new Guid("b2408ebd-0143-4fe9-9197-0306a750e952"), new Guid("6889322a-df97-4349-be4f-5fdfc59d028d"), "Description for ShowTime 18", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6e3fd909-246d-47be-a2b9-c3169ea18d60"), new Guid("efffc858-a502-4c10-a860-9b9bac3f3cb5"), new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), null, new DateTime(2024, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("98da30f1-679e-48b8-9e75-c014bda349d0"), new Guid("7b6669ba-5dc7-46b5-8731-93bdf681f358"), new Guid("f1b523f0-4663-4a4c-8cf6-5b2087a4797c"), "Description for ShowTime 22", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7822c70d-8e8c-4b36-b4b8-065eb2d82a3e"), new Guid("5ed1b273-a900-4b84-9c13-f8e5bd27dc09"), new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), null, new DateTime(2024, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("a5357a5e-6444-4fc9-a16f-55bfb756bd39"), new Guid("d0566c92-c9d5-45c8-9d3b-a632f7c5e874"), new Guid("11806a9b-27a7-41eb-a6bb-4fd80352d1ec"), "Description for ShowTime 30", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b9e71344-3a19-49b2-80f2-4b6869616657"), new Guid("8840b38f-32dd-4a1e-b7fb-87001ec975c7"), new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), null, new DateTime(2024, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("a5c7a2cb-1f83-4a73-83fe-71fd277f0011"), new Guid("8fe002c4-d845-4ee0-8d55-29212c6618ef"), new Guid("6a8ff52a-86d3-4435-b8d6-cbf625d77be8"), "Description for ShowTime 25", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3b28a9f2-7d94-467d-9caa-a755ff685ee8"), new Guid("7d36102b-75a6-470e-961b-e1729d4a8be4"), new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), null, new DateTime(2024, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("b2ee4164-d637-44bd-a35c-343923ce5bc9"), new Guid("a7fe53d1-c4e3-4d98-a6ad-bad2cd2c90fd"), new Guid("3ffd7564-bd1b-46d0-99db-230e1ddb6ce1"), "Description for ShowTime 3", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("433fa649-d62d-499a-94e3-63454e4d2170"), new Guid("60646501-70f7-4660-b86c-3d828ccb9024"), new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), null, new DateTime(2024, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("b5e0ee80-e358-4988-81a8-eb1a066bf144"), new Guid("713d97e0-456c-4e33-ab26-203625e4ebf7"), new Guid("2fc11052-f5e5-42ca-9248-7f42c2d2a5a6"), "Description for ShowTime 1", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("39847e7b-a7f9-473c-8e69-359451cdad2e"), new Guid("05c1d5c6-b2f8-472e-91f5-51686fdad516"), new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), null, new DateTime(2024, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("be26b807-c076-47e8-ae6a-7f4065e46dc9"), new Guid("78b6c6b0-212e-4582-9c31-68d15056d3ec"), new Guid("f8053902-8714-4ec0-bd6a-ffc268ee6186"), "Description for ShowTime 9", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b7fd5c99-8da1-4086-8af7-8dc2eab178a4"), new Guid("7c67fdaa-deda-4edd-9517-1f6a2beaf70f"), new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), null, new DateTime(2024, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("ded26285-734f-4e10-95ae-3191f793c5a3"), new Guid("a231f257-80fa-45b4-bdbd-178ca5c4cbb9"), new Guid("aa78626e-a41e-47ef-b31e-8f0ae92aea3b"), "Description for ShowTime 21", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("faabedb7-6f8f-47ac-bdff-6a9f1ecb6d53"), new Guid("0e368e86-563c-405f-bb6c-d6e67244f020"), new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), null, new DateTime(2024, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("e4d2bfb1-5499-4a3d-9ed1-10d4484abf8f"), new Guid("6062cd97-0dbf-42a4-88cc-4e870ad66f2b"), new Guid("eb152661-bf42-4655-a699-6aa9f89fb12a"), "Description for ShowTime 4", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("24b33fd3-c227-48d4-8304-b01f9e977e0b"), new Guid("12b01a89-6f50-4876-bf67-26a12ef8eaa7"), new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), null, new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("e4e78cc9-398a-4ee3-b57a-d51525bddb84"), new Guid("dbdf57c7-b24f-492a-8547-a7a1b6c059a7"), new Guid("9a98571b-3977-4dba-8b4b-50794946f2e2"), "Description for ShowTime 15", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("96a1c7af-2a5f-41a2-a4cc-f91dbca8daac"), new Guid("84ad461c-2008-4b9d-a2db-ca1f0ccf93b1"), new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), null, new DateTime(2024, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("f00a7d80-38d2-4587-94ef-00ece17e1017"), new Guid("3378ec63-e87d-4d8c-8739-ccd64ff4a053"), new Guid("e3e244ab-8e8e-4341-81e1-3e2eafef99fe"), "Description for ShowTime 8", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c352e249-845a-4a65-92dc-096718447df8"), new Guid("a84527da-d1c2-4e05-9bd5-b697c574bf17"), new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), null, new DateTime(2024, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("f6d74142-8c20-464a-8502-657c4cc75942"), new Guid("9915451c-1ab7-447e-8427-fa87158c3911"), new Guid("1fca244b-748e-4aa7-b3fa-44cceff604c8"), "Description for ShowTime 24", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5d9910f7-57dd-49fa-983c-0d655e08744a"), new Guid("975d0a83-23c6-4fd7-bd4a-3d0a95206265"), new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), null, new DateTime(2024, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("fd54b3b0-e4e5-4d2f-af2b-6f87a7dc047f"), new Guid("374ccabe-cae4-4389-ac12-a1b327c912ff"), new Guid("e62d783e-6ddb-4c0e-94df-776f0e76f236"), "Description for ShowTime 20", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8efe2a39-72a1-4e76-951f-06dba87f7256"), new Guid("7e4be017-32de-4763-9884-1cfed585cf83"), new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), null, new DateTime(2024, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "BillId", "CinemaCenterId", "Description", "Qrcode", "SeatId", "ShowTimeId", "Status", "TicketPriceId" },
                values: new object[,]
                {
                    { new Guid("096f6e53-35c9-4019-a5a9-b11bda0a03d1"), new Guid("b49d57cb-0eeb-4f33-a2d3-ad69a04f2efe"), new Guid("c389e092-7635-49b9-80ed-2e966606e152"), "Description for Ticket 11", "qrcode11.jpg", new Guid("f24eee2a-f32b-4fa1-a2c7-1244ab35f6e2"), new Guid("08f33d16-eaa1-4d40-978e-f576802b95be"), 2, new Guid("3d422297-2da2-428e-b319-118f16346053") },
                    { new Guid("141b8357-a136-4527-8fa1-4c40692d7c68"), new Guid("b2e1f581-0d47-4d1e-8b75-8a505731c66a"), new Guid("3378ec63-e87d-4d8c-8739-ccd64ff4a053"), "Description for Ticket 6", "qrcode6.jpg", new Guid("8f95ac38-a542-44e8-99df-26525be330ee"), new Guid("48d89161-fbdd-44ee-928a-1522f6a6448e"), 2, new Guid("6790f820-0590-4a56-9f90-3a00817b40d3") },
                    { new Guid("16d802d9-da66-4763-aba4-09eb88f49695"), new Guid("95181f5b-30e8-491b-8872-847a598c90af"), new Guid("8fe002c4-d845-4ee0-8d55-29212c6618ef"), "Description for Ticket 7", "qrcode7.jpg", new Guid("8f95ac38-a542-44e8-99df-26525be330ee"), new Guid("24ccc3ec-dee9-4d8b-9897-3cc2e297aa83"), 2, new Guid("4ef17c71-1c8f-4f0a-bfc3-b958509a4cb9") },
                    { new Guid("1d6bf618-3c3f-4bbd-a958-11b48a9c59d7"), new Guid("c802ec6b-e6c4-4aeb-b8ea-06af953d643d"), new Guid("2f2b8c56-c334-4dc8-b125-5c8fc81aa75a"), "Description for Ticket 9", "qrcode9.jpg", new Guid("e451daed-1c48-4432-8f9d-bed48e67ed0c"), new Guid("be26b807-c076-47e8-ae6a-7f4065e46dc9"), 2, new Guid("d72ddcb1-ebef-4b89-94e1-4ce38375a736") },
                    { new Guid("1f0a72dd-f373-4bed-b379-e711950ec0e8"), new Guid("92e9faba-6f4f-4ee0-ab2f-f29b996d82a5"), new Guid("dbdf57c7-b24f-492a-8547-a7a1b6c059a7"), "Description for Ticket 16", "qrcode16.jpg", new Guid("75e3fe57-ca1c-48e1-967a-712f5b14e6b7"), new Guid("77e3d6fb-149a-43b8-b9f5-c70efc0d8300"), 2, new Guid("bf8162e1-75da-4a1b-898f-3f9e040c6e92") },
                    { new Guid("22021199-1ec2-4285-997c-47b69522778c"), new Guid("7401c5f1-bbf5-436c-a2f3-0ea0dd66664c"), new Guid("78b6c6b0-212e-4582-9c31-68d15056d3ec"), "Description for Ticket 27", "qrcode27.jpg", new Guid("55fa66d6-e42d-420d-8dcd-d93d50c66eb4"), new Guid("4d6237fb-d91b-4c16-a092-7c6acab509aa"), 2, new Guid("06ac71cd-896a-4192-9db4-66e55f1fbe8d") },
                    { new Guid("48762dbb-6e08-4d8e-bf39-b16e3b971085"), new Guid("f904aa25-4dde-4405-9b7e-23659edd24f9"), new Guid("6062cd97-0dbf-42a4-88cc-4e870ad66f2b"), "Description for Ticket 22", "qrcode22.jpg", new Guid("e42e188b-1cb5-487b-9f6c-3b8832bdf836"), new Guid("98da30f1-679e-48b8-9e75-c014bda349d0"), 2, new Guid("8157faf8-200b-4a1a-b577-cb86fed23d45") },
                    { new Guid("503fe570-8c43-4937-a197-dfd334e9dca9"), new Guid("67b209b3-9c5c-4d96-96ab-b764c6962c10"), new Guid("b2408ebd-0143-4fe9-9197-0306a750e952"), "Description for Ticket 10", "qrcode10.jpg", new Guid("7eb72444-b56e-4f5c-9c12-ef100a2b832a"), new Guid("3eccb423-3138-43b9-b105-9b783dc11f29"), 2, new Guid("ad8f8f1d-31d8-4582-a6d4-03384fb7d46a") },
                    { new Guid("5294a1f5-0ca6-4624-af99-398d16304a42"), new Guid("50e640dd-814d-4d54-b56c-ed221f2793c0"), new Guid("82bfb838-8074-4d43-97e3-af625430b1e5"), "Description for Ticket 17", "qrcode17.jpg", new Guid("182891cc-a820-4726-b1c7-f40c5f7685d6"), new Guid("2ef00b5c-27e0-4f9f-a147-82ed6f81ed33"), 2, new Guid("99d795a8-4384-4878-99c3-5905e9c6e3fa") },
                    { new Guid("645bb7ec-3f55-4f7b-8b49-d012f9d1edc1"), new Guid("6f5052b0-ce1f-46fe-ba06-af930da1e24e"), new Guid("f727c7c2-313f-40e6-9cba-bc33a0a4896d"), "Description for Ticket 18", "qrcode18.jpg", new Guid("267b970e-136a-492f-8f50-3140fe2bf910"), new Guid("97f97b0f-80f2-4adc-8919-5d1fac696b28"), 2, new Guid("5a1c296c-8e64-4611-8546-f8e23f2bfc17") },
                    { new Guid("647f7d69-ac1f-4ed4-b216-c1601aceb837"), new Guid("288433f0-cf58-4dcd-a682-e8afa7b307ef"), new Guid("72ce0538-77cb-4738-86a4-db5f74a79f2e"), "Description for Ticket 25", "qrcode25.jpg", new Guid("b336a149-e836-43e1-b276-f427e7f5770e"), new Guid("a5c7a2cb-1f83-4a73-83fe-71fd277f0011"), 2, new Guid("9afb6602-af1a-4c3c-a2da-e0280a434e01") },
                    { new Guid("6485a2e9-22b0-4c3f-aa71-65afb5da9e2d"), new Guid("9a70b4af-8263-41c4-84d8-931eb85b8db1"), new Guid("82bfb838-8074-4d43-97e3-af625430b1e5"), "Description for Ticket 26", "qrcode26.jpg", new Guid("b0734d92-59f4-4412-9af3-6706972e818b"), new Guid("253db7d1-dc76-403f-8444-69dd44a47411"), 2, new Guid("f1400175-bef3-41fb-af49-9f3c10d40522") },
                    { new Guid("688b8181-2cc1-40f8-a267-08ea771aea4e"), new Guid("0aded26a-67c9-4649-b785-078f972e4c02"), new Guid("7b6669ba-5dc7-46b5-8731-93bdf681f358"), "Description for Ticket 4", "qrcode4.jpg", new Guid("6d1d65ff-1b12-45cd-9853-eec68ea6f2b1"), new Guid("e4d2bfb1-5499-4a3d-9ed1-10d4484abf8f"), 2, new Guid("e815b5ab-d548-4a15-a314-62f74a0b13bf") },
                    { new Guid("6d0d0260-dd7b-4092-9588-7c4ab4e499fc"), new Guid("f04e9bd6-c140-4c88-9139-706540b45aa2"), new Guid("0740e6ae-a711-41c2-8515-1e743d7b4682"), "Description for Ticket 3", "qrcode3.jpg", new Guid("7eed12f7-6021-4d87-b04c-92bc32ede9c3"), new Guid("b2ee4164-d637-44bd-a35c-343923ce5bc9"), 2, new Guid("44cae637-055d-471f-82c8-1fe76ce101dc") },
                    { new Guid("6ea262cb-ee3c-42e4-bcba-f99a288d8b27"), new Guid("be5f0dc7-7f5d-495f-b9d4-b8c9148bd956"), new Guid("72ce0538-77cb-4738-86a4-db5f74a79f2e"), "Description for Ticket 29", "qrcode29.jpg", new Guid("aeb53e9b-d36d-43dc-b248-29bc3c5379d4"), new Guid("5a095403-85bb-4434-b92e-9554dcece8a3"), 2, new Guid("20590e39-e764-4415-a3c6-e73064d46534") },
                    { new Guid("73eed363-26c7-4b11-9011-35727e903df9"), new Guid("7affd4b3-b810-4a25-a17b-83da6df6106e"), new Guid("a231f257-80fa-45b4-bdbd-178ca5c4cbb9"), "Description for Ticket 2", "qrcode2.jpg", new Guid("f24eee2a-f32b-4fa1-a2c7-1244ab35f6e2"), new Guid("53a59e2e-7a8e-4e58-adeb-f7bb376fa6b8"), 2, new Guid("3e149012-b7e3-4aa8-8986-13838abcc261") },
                    { new Guid("8861e9ed-2e15-43fa-b96e-28cc90effc87"), new Guid("d512da42-ede6-4fc7-b895-b41359193abc"), new Guid("b33761ea-2f8f-46ae-8a72-923adb87001f"), "Description for Ticket 14", "qrcode14.jpg", new Guid("0d1a6b0a-0c14-4a29-980a-768566dc91e4"), new Guid("6c557a0e-acf5-4721-81ef-ca8a1677a441"), 2, new Guid("68a06d8c-e036-4da0-a0f1-f632a83efc29") },
                    { new Guid("8938c659-72be-4237-8242-79ba004f63e3"), new Guid("88ac530e-249d-4cef-b7a3-2b3753ef3bc0"), new Guid("8fe002c4-d845-4ee0-8d55-29212c6618ef"), "Description for Ticket 21", "qrcode21.jpg", new Guid("dfa59234-5205-4f75-92d4-946eb311487b"), new Guid("ded26285-734f-4e10-95ae-3191f793c5a3"), 2, new Guid("5ea1b6f4-c92f-4623-aa80-3cbcb3988f21") },
                    { new Guid("966a5c8e-dac0-4c89-bb7e-800a447678f7"), new Guid("10aa65e8-69ac-4c4f-a24c-e6ee3776c06f"), new Guid("82bfb838-8074-4d43-97e3-af625430b1e5"), "Description for Ticket 13", "qrcode13.jpg", new Guid("e451daed-1c48-4432-8f9d-bed48e67ed0c"), new Guid("5730a49d-78fa-4c58-87f8-6b54e0891b93"), 2, new Guid("160a58fe-f031-4cc2-8451-4ba2670f7cb7") },
                    { new Guid("9af18f3f-ec21-46aa-98c1-b477b32a49fc"), new Guid("2206d17f-b71c-4bba-86c7-112b8f8216fb"), new Guid("82bfb838-8074-4d43-97e3-af625430b1e5"), "Description for Ticket 19", "qrcode19.jpg", new Guid("815117fc-1f04-4ad8-aa29-2396a06ff80e"), new Guid("5dc83cb9-a4eb-4724-83bd-b844acddca7a"), 2, new Guid("1354e144-bfb2-4b12-af25-90566c661b12") },
                    { new Guid("9f14970a-46d2-49c6-94d4-ab94b8becb67"), new Guid("e84940fa-f17c-4ddd-99de-b54b213164fc"), new Guid("7b6669ba-5dc7-46b5-8731-93bdf681f358"), "Description for Ticket 24", "qrcode24.jpg", new Guid("513efb4d-4881-4dc0-84b7-5a72d53e6703"), new Guid("f6d74142-8c20-464a-8502-657c4cc75942"), 2, new Guid("e594668d-a0b7-4cf0-a9ab-5c1ca087696d") },
                    { new Guid("c1eb8e65-1f99-4a26-89b2-02ff69df066d"), new Guid("d04ef227-7f23-4f62-8dbd-0c57702885d0"), new Guid("7b6669ba-5dc7-46b5-8731-93bdf681f358"), "Description for Ticket 15", "qrcode15.jpg", new Guid("24bbccd1-6e85-4545-aef8-e1a33dc3938d"), new Guid("e4e78cc9-398a-4ee3-b57a-d51525bddb84"), 2, new Guid("aaa23ed1-31f1-422b-b3bc-d8fef32570ed") },
                    { new Guid("c379446e-baba-4d07-b836-c2ea7f4e484e"), new Guid("44fd8c5d-7ec3-413f-a66b-8a7edc0f042f"), new Guid("562703b6-f408-4340-9651-780c11395069"), "Description for Ticket 20", "qrcode20.jpg", new Guid("fa6898f3-5106-4c87-acd9-dfd2d0e44433"), new Guid("fd54b3b0-e4e5-4d2f-af2b-6f87a7dc047f"), 2, new Guid("e633214f-0eff-485f-9d6f-8c7119d563af") },
                    { new Guid("c74ea7eb-418a-400e-88c5-aaac6e7ad677"), new Guid("0f43f5cd-b359-4b8e-8b2f-82808b60efef"), new Guid("6062cd97-0dbf-42a4-88cc-4e870ad66f2b"), "Description for Ticket 12", "qrcode12.jpg", new Guid("b9f0a759-5847-4059-b2e4-24f5f54dab07"), new Guid("84ebf4ae-7f1c-437f-92b2-7ad0d8e9b6c4"), 2, new Guid("0bf0f98c-d4bc-4a7a-8ae0-4ffacf1e23e6") },
                    { new Guid("d58f98f4-3230-4e0b-8e06-c3ecbc9d9adb"), new Guid("cba5ee8a-ca9b-4b0a-b0d3-84042d358718"), new Guid("d0566c92-c9d5-45c8-9d3b-a632f7c5e874"), "Description for Ticket 28", "qrcode28.jpg", new Guid("26c45339-7e67-4bbb-b590-1f49e8648fa5"), new Guid("4e87d62e-ebab-4491-940f-7ae5222c9297"), 2, new Guid("22fa0b0d-cbb3-4b7b-a7d5-f5202e6f7232") },
                    { new Guid("d7da457b-d655-4008-9df9-af5085a30261"), new Guid("72477574-e7b6-499e-b67f-ac6d59f394b7"), new Guid("562703b6-f408-4340-9651-780c11395069"), "Description for Ticket 23", "qrcode23.jpg", new Guid("ecee704d-c9c6-4302-a300-d17f6f2e3232"), new Guid("7cf53c63-d4bf-4fbe-83a5-c2e8bd19df50"), 2, new Guid("d78984fc-e255-4a63-b3c4-b5cfdf1df002") },
                    { new Guid("e57ce556-928f-4fa9-a6ab-8abd7b4cbb2e"), new Guid("bdaf1fc7-a71d-416d-a960-e39c46aceef0"), new Guid("3378ec63-e87d-4d8c-8739-ccd64ff4a053"), "Description for Ticket 8", "qrcode8.jpg", new Guid("75e3fe57-ca1c-48e1-967a-712f5b14e6b7"), new Guid("f00a7d80-38d2-4587-94ef-00ece17e1017"), 2, new Guid("82287faa-ce55-446f-a627-3863b1fff25e") },
                    { new Guid("ebdaa1c5-e0f7-40da-92b6-3b17409ca10f"), new Guid("a7b791b7-084f-4305-8015-a5350204abf6"), new Guid("b33761ea-2f8f-46ae-8a72-923adb87001f"), "Description for Ticket 5", "qrcode5.jpg", new Guid("4c6713df-2054-4816-8e0f-993466b12bde"), new Guid("1c517b36-a9ef-42e1-97a9-24d10ed9aa02"), 2, new Guid("270de1b0-875f-4165-9117-ac96cd338203") },
                    { new Guid("f085b1a4-5418-4d48-8cb3-2ac7e186f612"), new Guid("441f10e6-c4c0-45f3-8d37-7df17559fe54"), new Guid("8fe002c4-d845-4ee0-8d55-29212c6618ef"), "Description for Ticket 1", "qrcode1.jpg", new Guid("554664af-2ae8-4c77-b548-5761abe21bc6"), new Guid("b5e0ee80-e358-4988-81a8-eb1a066bf144"), 2, new Guid("06961681-885c-47db-be43-112d0b3983e8") },
                    { new Guid("f399ccf0-0ab2-4776-b96f-22f887195635"), new Guid("ca5f8cef-4a02-4891-9d00-f1cd29927794"), new Guid("a231f257-80fa-45b4-bdbd-178ca5c4cbb9"), "Description for Ticket 30", "qrcode30.jpg", new Guid("a64c4419-5d16-484c-b9bf-24ed93da66d4"), new Guid("a5357a5e-6444-4fc9-a16f-55bfb756bd39"), 2, new Guid("5d743fea-8d86-4643-8a0d-41e160395209") }
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
