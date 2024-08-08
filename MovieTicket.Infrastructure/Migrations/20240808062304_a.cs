using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieTicket.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class a : Migration
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
                    { new Guid("0362356d-126d-4dc6-8543-1a6eba65b1c8"), "Address 7", "avatar7.png", new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "user7@example.com", "User 7", "h8t5vD5p1U3C4AEASeaErg==", "123-456-7897", 2, 1, "user7" },
                    { new Guid("079a86b0-db6c-4a3b-b259-81c25e8b9c02"), "Address 9", "avatar9.png", new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "user9@example.com", "User 9", "XLl70iIryQx+lE/y5900Uw==", "123-456-7899", 2, 1, "user9" },
                    { new Guid("09323f99-fc29-4614-a4cf-7baa2b206c9d"), "Address 20", "avatar20.png", new DateTime(2023, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "user20@example.com", "User 20", "J20oEfuyjDdy085hSNPLIw==", "123-456-78920", 2, 1, "user20" },
                    { new Guid("182d493f-feee-41f9-81f9-4d4577f563e3"), "Address 16", "avatar16.png", new DateTime(2023, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "user16@example.com", "User 16", "1+4JJ+OIs+XRXx0vTPNGQA==", "123-456-78916", 2, 1, "user16" },
                    { new Guid("235c04f9-e8b5-4d07-926c-745234ab832a"), "Address 5", "avatar5.png", new DateTime(2023, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "user5@example.com", "User 5", "LtgxZLXxd71ac78V6rYtcg==", "123-456-7895", 2, 1, "user5" },
                    { new Guid("2c0abe6c-8415-4a5b-b5c8-e2ef0044c1d5"), "Address 25", "avatar25.png", new DateTime(2023, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "user25@example.com", "User 25", "o+65kwYOgM/H5YtlR5eBGQ==", "123-456-78925", 2, 1, "user25" },
                    { new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), "Address 2", "avatar2.png", new DateTime(2023, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "azusachan309@gmail.com", "ClientTest", "LK25tQh1RqkKbrq4C2l6fw==", "000-000-000", 2, 1, "Client" },
                    { new Guid("3be56c1b-97fd-4255-bd73-d3293e58f316"), "Address 21", "avatar21.png", new DateTime(2023, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "user21@example.com", "User 21", "uqWAcnIuI+ey7XOiRgb8IA==", "123-456-78921", 2, 1, "user21" },
                    { new Guid("3d10413b-6dc8-4dd2-9731-330719676170"), "Address 18", "avatar18.png", new DateTime(2023, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "user18@example.com", "User 18", "zp6jPz/JRrDgXS7tmjREDQ==", "123-456-78918", 2, 1, "user18" },
                    { new Guid("3dbc7693-260c-4464-85fd-68028ef02180"), "Address 22", "avatar22.png", new DateTime(2023, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "user22@example.com", "User 22", "yuwYTyVSnjUQg9d58Fr6eg==", "123-456-78922", 2, 1, "user22" },
                    { new Guid("3e417d7c-814d-418c-93c5-fe77633dbd63"), "Address 14", "avatar14.png", new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "user14@example.com", "User 14", "Nbb9cBgoI2KknXYhJgRsOg==", "123-456-78914", 2, 1, "user14" },
                    { new Guid("4198635c-23ac-4b96-9dd2-701f16a938e4"), "Address 26", "avatar26.png", new DateTime(2023, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "user26@example.com", "User 26", "JTjto+r7kPyCkZGQtsDBOA==", "123-456-78926", 2, 1, "user26" },
                    { new Guid("463504d7-0935-4dee-a15b-9536a2d33e31"), "Address 28", "avatar28.png", new DateTime(2023, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "user28@example.com", "User 28", "R/9+ITDUv36NqhUmUxCu5w==", "123-456-78928", 2, 1, "user28" },
                    { new Guid("4636e0a1-868b-4201-a107-ef4dea94a2bf"), "Address 24", "avatar24.png", new DateTime(2023, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "user24@example.com", "User 24", "wUy5uoNVQITmQW5R4nnOMA==", "123-456-78924", 2, 1, "user24" },
                    { new Guid("4e2cb0c5-6f14-432d-bde3-8d4606faf160"), "Address 11", "avatar11.png", new DateTime(2023, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "user11@example.com", "User 11", "+1XAkm3H0MciMPlnUyv6ww==", "123-456-78911", 2, 1, "user11" },
                    { new Guid("4e98eea3-4090-4e96-bf4d-0b930c7f1a2a"), "Address 27", "avatar27.png", new DateTime(2023, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "user27@example.com", "User 27", "lePABwdtIg5MqkBgyFdL9Q==", "123-456-78927", 2, 1, "user27" },
                    { new Guid("585bd47d-8235-4a4e-ae63-6b7a1f7b0801"), "Address 30", "avatar30.png", new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "user30@example.com", "User 30", "ZIc8EakA57j1Q7JTsakLKA==", "123-456-78930", 2, 1, "user30" },
                    { new Guid("5bdb9f98-508c-4a2a-8d22-64b63eb5cb2d"), "Address 10", "avatar10.png", new DateTime(2023, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "user10@example.com", "User 10", "AD+DKAMne24G+bFvnB3umA==", "123-456-78910", 2, 1, "user10" },
                    { new Guid("642f5656-af6c-4a73-8024-fa7c22d614f3"), "Address 13", "avatar13.png", new DateTime(2023, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "user13@example.com", "User 13", "hjKFGDVLaz8y7jip9ebjyg==", "123-456-78913", 2, 1, "user13" },
                    { new Guid("7687f1bb-87ca-402e-a536-a3ce12db8ec1"), "Address 3", "avatar3.png", new DateTime(2023, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "user3@example.com", "User 3", "XZG20Zjr0RmKJ42oxCGZqQ==", "123-456-7893", 2, 1, "user3" },
                    { new Guid("854b1c19-ea67-4e1a-b6f2-752ef80119d0"), "Address 6", "avatar6.png", new DateTime(2023, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "user6@example.com", "User 6", "ns3cIzMXn9uRJUqXbdf1sw==", "123-456-7896", 2, 1, "user6" },
                    { new Guid("8c914f26-9a6b-48ca-ab72-61a6a3f623f9"), "Address 4", "avatar4.png", new DateTime(2023, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "user4@example.com", "User 4", "AYCB0pkX1QvnELN5s4E7/w==", "123-456-7894", 2, 1, "user4" },
                    { new Guid("8ee22965-d2d3-4886-9a8c-ad5ddbe336d3"), "Address 12", "avatar12.png", new DateTime(2023, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "user12@example.com", "User 12", "q/b7mh1nE1JeI7y/w6yvIQ==", "123-456-78912", 2, 1, "user12" },
                    { new Guid("9e20183f-07d0-482d-a1fd-c54caf8c06f0"), "Address 2", "avatar2.png", new DateTime(2023, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "user2@example.com", "User 2", "gPFa6fSRCX/O3JCnJjTBBg==", "123-456-7892", 2, 1, "user2" },
                    { new Guid("9fa77117-9961-41da-bdc3-6470b76f4b97"), "Address 15", "avatar15.png", new DateTime(2023, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "user15@example.com", "User 15", "AtoLhqKWoDhm5ytm7x3CFg==", "123-456-78915", 2, 1, "user15" },
                    { new Guid("aba5e6d5-1257-4eeb-bbe6-6c03ad589a72"), "Address 17", "avatar17.png", new DateTime(2023, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "user17@example.com", "User 17", "bnivYPkMUcJNzvYQyXZIvw==", "123-456-78917", 2, 1, "user17" },
                    { new Guid("af0eb7b6-cb5c-4c96-886c-ced162a70026"), "Address 8", "avatar8.png", new DateTime(2023, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "user8@example.com", "User 8", "QoNqXwm6ndtmwV7AptAudw==", "123-456-7898", 2, 1, "user8" },
                    { new Guid("bc58c1ed-85a2-4103-859e-c95884a070d1"), "Address 19", "avatar19.png", new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "user19@example.com", "User 19", "+BFH+L+RScNaLm45T9M5Tw==", "123-456-78919", 2, 1, "user19" },
                    { new Guid("d3f5a596-200f-4421-9467-a6de69876047"), "Address 23", "avatar23.png", new DateTime(2023, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "user23@example.com", "User 23", "JM3wDHJHLSLI6Wdnnfs2dQ==", "123-456-78923", 2, 1, "user23" },
                    { new Guid("e82f2960-62c2-4f36-922f-5fd9af8d5f67"), "Address 1", "avatar1.png", new DateTime(2023, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "user1@example.com", "User 1", "ei00xFxTj/yW/ErUUw1JvA==", "123-456-7891", 2, 1, "user1" },
                    { new Guid("fd36705c-0610-4c30-9cfb-e5827b3f3d78"), "Address 1", "avatar1.png", new DateTime(2023, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "azusachan307@gmail.com", "AdminTest", "LK25tQh1RqkKbrq4C2l6fw==", "000-000-000", 1, 1, "Admin" },
                    { new Guid("fe4d251f-7632-4b7d-97a3-3e31c5138d82"), "Address 29", "avatar29.png", new DateTime(2023, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "user29@example.com", "User 29", "ETdpo/KPinCotdzGNmsAPA==", "123-456-78929", 2, 1, "user29" }
                });

            migrationBuilder.InsertData(
                table: "CinemaCenters",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[,]
                {
                    { new Guid("03b862fe-b58c-45e6-a6f0-db2132316720"), "Address 19", "Cinema Center 19" },
                    { new Guid("0920589e-8404-4570-8111-b66d85c9f0cc"), "Address 7", "Cinema Center 7" },
                    { new Guid("213ed74b-499a-47e7-b684-77c109cd751c"), "Address 6", "Cinema Center 6" },
                    { new Guid("2409d876-0c18-4d9b-9bd8-ceb6a1b73e40"), "Address 26", "Cinema Center 26" },
                    { new Guid("2cf4902c-1ac0-49e6-9db2-a6bd1107ca69"), "Address 2", "Cinema Center 2" },
                    { new Guid("2d4f8157-b352-4f54-b04a-2784011c090d"), "Address 29", "Cinema Center 29" },
                    { new Guid("302b31a4-601f-4ea0-a358-a326f9257d8c"), "Address 13", "Cinema Center 13" },
                    { new Guid("47cdf744-cc51-424d-a998-ae61053c95fc"), "Address 21", "Cinema Center 21" },
                    { new Guid("4a49a3bb-2457-4248-89ef-e091a33d4c1f"), "Address 30", "Cinema Center 30" },
                    { new Guid("519072f0-b8d7-4b8f-a16f-0ae7b1271e1d"), "Address 20", "Cinema Center 20" },
                    { new Guid("5968f5c9-0032-4f01-9b33-d37a21dfb6db"), "Address 15", "Cinema Center 15" },
                    { new Guid("62e68a04-1132-4880-878e-1facb4deea97"), "Address 8", "Cinema Center 8" },
                    { new Guid("639ce77d-b096-4453-bfa8-1c0fa2dcc23c"), "Address 14", "Cinema Center 14" },
                    { new Guid("67ce8ad3-516b-4ff6-9a6a-552d72dffe92"), "Address 3", "Cinema Center 3" },
                    { new Guid("766e5f3b-a530-4bd5-92d9-a3ee084a6504"), "Address 23", "Cinema Center 23" },
                    { new Guid("79095388-508b-4549-9c7d-475ce44798d5"), "Address 4", "Cinema Center 4" },
                    { new Guid("9560a4d9-8ed4-4f69-910f-f264ef58255c"), "Address 1", "Cinema Center 1" },
                    { new Guid("96ea85d5-6f20-411c-b106-3ee1d0ad72dd"), "Address 17", "Cinema Center 17" },
                    { new Guid("99a15a39-0e86-4931-ba52-45acba38ba25"), "Address 11", "Cinema Center 11" },
                    { new Guid("9d02e80f-085e-43a7-8afa-00239a1245e7"), "Address 27", "Cinema Center 27" },
                    { new Guid("a5f5459f-3061-4d77-9a43-8eb4017f0a6e"), "Address 22", "Cinema Center 22" },
                    { new Guid("aa349729-6fe5-4e3e-9b98-6088bafeef20"), "Address 28", "Cinema Center 28" },
                    { new Guid("b78159bf-ffb8-4d12-b6cf-944340349352"), "Address 10", "Cinema Center 10" },
                    { new Guid("b95d44e7-863f-4af5-bcaf-27ebe149d609"), "Address 24", "Cinema Center 24" },
                    { new Guid("c05d2b45-12fd-449d-9518-31f561a9cee9"), "Address 9", "Cinema Center 9" },
                    { new Guid("d1a648f7-7978-4ca0-9064-a7effad47f10"), "Address 16", "Cinema Center 16" },
                    { new Guid("d84496f3-aa10-44ee-9cd6-6f17a967fec3"), "Address 25", "Cinema Center 25" },
                    { new Guid("e5e935c0-59ff-4ac0-b32e-99ab5fe33064"), "Address 18", "Cinema Center 18" },
                    { new Guid("fd2c4ee6-d781-4b6f-9f9e-6c301d4dd791"), "Address 12", "Cinema Center 12" },
                    { new Guid("fd987245-4f2a-40b5-b5b7-e9d3ed3b29c2"), "Address 5", "Cinema Center 5" }
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
                    { new Guid("007262cf-0c2d-4b81-a453-f1870565d970"), "Combo 19", 90000m },
                    { new Guid("041248ea-6133-4367-a5c9-14e924f79357"), "Combo 30", 0m },
                    { new Guid("126f59ba-701f-422a-91fc-3cbdc869789e"), "Combo 3", 30000m },
                    { new Guid("12fca348-b0d8-4878-a6a8-31fac544dde8"), "Combo 4", 40000m },
                    { new Guid("42cafd9a-ae61-4d57-834e-ae55b86d420b"), "Combo 11", 10000m },
                    { new Guid("4891efc1-92c8-4e2e-8b0a-44b1e7df3601"), "Combo 12", 20000m },
                    { new Guid("5d3bcf93-0222-4089-ae68-9cf15f581cd3"), "Combo 25", 50000m },
                    { new Guid("629e6864-1844-47ff-8050-cefc5f64e223"), "Combo 29", 90000m },
                    { new Guid("62e9f690-f9cc-4797-895e-320dfbd7b613"), "Combo 7", 70000m },
                    { new Guid("6373eabe-8b4e-4019-9872-e08cb3fca106"), "Combo 15", 50000m },
                    { new Guid("73f9571c-3eae-49fd-99ae-84d9945604e7"), "Combo 20", 0m },
                    { new Guid("76478ed7-0fb7-4dec-a3a4-73a99242a8a3"), "Combo 18", 80000m },
                    { new Guid("858377c5-64d3-4f7f-bef0-2eab1586cddf"), "Combo 22", 20000m },
                    { new Guid("8fdfa7bf-1351-47ab-af55-ba0f124202d3"), "Combo 14", 40000m },
                    { new Guid("99165327-c8f7-4748-a53b-56f3135112ea"), "Combo 13", 30000m },
                    { new Guid("9ba4732d-6d6b-46eb-817b-55bce1a63b4e"), "Combo 10", 0m },
                    { new Guid("a5c79557-e67e-400f-af4a-6ed96e1a4a52"), "Combo 2", 20000m },
                    { new Guid("ac809d1c-ee30-4c5c-a3b1-ec5f6616b44b"), "Combo 23", 30000m },
                    { new Guid("add578ca-b985-4a00-a335-1c5a6ac9c699"), "Combo 8", 80000m },
                    { new Guid("c18acb07-663a-45d3-b76e-6259a11c9c0b"), "Combo 16", 60000m },
                    { new Guid("c505ff0b-705c-4d28-a422-42ab90b14674"), "Combo 5", 50000m },
                    { new Guid("c6590d56-66d0-476b-a92b-cceedb213777"), "Combo 9", 90000m },
                    { new Guid("ca2de4eb-ca69-4a97-9382-9d42e0187def"), "Combo 21", 10000m },
                    { new Guid("cb6fd551-1e25-4938-9442-31031b0ca2b5"), "Combo 6", 60000m },
                    { new Guid("d118427f-a2ab-4487-b4ca-9db046a752d8"), "Combo 24", 40000m },
                    { new Guid("d4ad2c79-4562-4591-bd51-24d8bf005660"), "Combo 26", 60000m },
                    { new Guid("e8ecb2da-5f19-469b-80d3-59ec647b56bf"), "Combo 1", 10000m },
                    { new Guid("f981b7e1-6798-4626-a2af-fe82deb6d8e7"), "Combo 28", 80000m },
                    { new Guid("fb31d532-c434-47fd-81cf-50cc750bbae4"), "Combo 17", 70000m },
                    { new Guid("fc9f4a57-8c28-4714-9465-36bf53eca3f8"), "Combo 27", 70000m }
                });

            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "Id", "Cast", "CreatDate", "Description", "Director", "EnglishName", "Gerne", "Language", "Name", "Nation", "Poster", "Rating", "ReleaseYear", "RunningTime", "ScreenTypeId", "StartDate", "Status", "Trailer", "TranslationTypeId" },
                values: new object[,]
                {
                    { new Guid("0dbc75c0-e6a9-4cb5-b5a5-07a51609525f"), "Actor 22, Actress 22", new DateTime(2023, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 22.", "Director 22", "Film 22 (English)", "Action", "English", "Film 22", "USA", "https://example.com/poster22.jpg", 3, 2023, 82, new Guid("4181ad66-30c9-441f-8c06-401742dea16c"), new DateTime(2023, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer22.mp4", new Guid("8e844c4f-e410-4042-b83e-99bfcfb7b26a") },
                    { new Guid("19faa4b8-6687-4f1a-b17a-a2667650a166"), "Actor 21, Actress 21", new DateTime(2023, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 21.", "Director 21", "Film 21 (English)", "Comedy", "Japanese", "Film 21", "Japan", "https://example.com/poster21.jpg", 2, 2023, 81, new Guid("1855dc5c-b9d9-4bf9-aa65-7912243645db"), new DateTime(2023, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer21.mp4", new Guid("b939bda8-10a2-48c8-af80-714b6618934a") },
                    { new Guid("1b4095a8-d53e-40f7-9ccb-435cb19a5300"), "Actor 12, Actress 12", new DateTime(2023, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 12.", "Director 12", "Film 12 (English)", "Action", "English", "Film 12", "USA", "https://example.com/poster12.jpg", 3, 2023, 72, new Guid("0ea6ecc5-9508-4b1d-a036-ae949b306578"), new DateTime(2023, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer12.mp4", new Guid("13eebdb3-3ebb-4b66-abcc-06fc6e9d2cef") },
                    { new Guid("1bdf8e26-5d47-4398-a911-feb85d9350a5"), "Actor 29, Actress 29", new DateTime(2023, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 29.", "Director 29", "Film 29 (English)", "Comedy", "Japanese", "Film 29", "Japan", "https://example.com/poster29.jpg", 5, 2023, 89, new Guid("9b4c5912-00ed-40d3-9ade-3d038902f67b"), new DateTime(2023, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer29.mp4", new Guid("6ef16c08-873e-439d-a5f7-7d628467a886") },
                    { new Guid("1d26d0bc-28d2-4670-87ae-069d7c485c77"), "Actor 15, Actress 15", new DateTime(2023, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 15.", "Director 15", "Film 15 (English)", "Comedy", "Japanese", "Film 15", "Japan", "https://example.com/poster15.jpg", 1, 2023, 75, new Guid("ed701212-92a7-425b-974a-e559c4c9ce35"), new DateTime(2023, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer15.mp4", new Guid("a114500e-06dd-4c10-9886-fa1dcb51f4f2") },
                    { new Guid("219a7453-924e-4c1b-9ac4-b687954122fb"), "Actor 4, Actress 4", new DateTime(2023, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 4.", "Director 4", "Film 4 (English)", "Action", "English", "Film 4", "USA", "https://example.com/poster4.jpg", 5, 2023, 64, new Guid("23d91af5-b58c-49e8-b5d4-c8d69453b8ed"), new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer4.mp4", new Guid("22b14515-d91b-441d-907d-e7b2c65e1b34") },
                    { new Guid("21c9e756-ee2b-4448-aec3-1c6ad704e3b2"), "Actor 16, Actress 16", new DateTime(2023, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 16.", "Director 16", "Film 16 (English)", "Action", "English", "Film 16", "USA", "https://example.com/poster16.jpg", 2, 2023, 76, new Guid("c72a53ff-36c2-4df0-bd11-759e22658fd0"), new DateTime(2023, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer16.mp4", new Guid("f767e945-4b88-4efe-986b-7335617a4263") },
                    { new Guid("26fd53f7-5e35-4d06-ac4f-ad11554ddb39"), "Actor 18, Actress 18", new DateTime(2023, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 18.", "Director 18", "Film 18 (English)", "Action", "English", "Film 18", "USA", "https://example.com/poster18.jpg", 4, 2023, 78, new Guid("21846027-a10a-4e16-89fd-225d887e0555"), new DateTime(2023, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer18.mp4", new Guid("6fc366f2-1f36-4d02-90f2-317697ab7b97") },
                    { new Guid("2a1846c1-845a-47ef-9d6a-16c0b6526b8c"), "Actor 5, Actress 5", new DateTime(2023, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 5.", "Director 5", "Film 5 (English)", "Comedy", "Japanese", "Film 5", "Japan", "https://example.com/poster5.jpg", 1, 2023, 65, new Guid("7efb51df-d291-4043-9868-25c00f0e04d7"), new DateTime(2023, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer5.mp4", new Guid("e9baec4f-9105-474e-af68-0c6db2d3bd3e") },
                    { new Guid("336534a4-84fd-41b5-abf2-65297ecac38e"), "Actor 11, Actress 11", new DateTime(2023, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 11.", "Director 11", "Film 11 (English)", "Comedy", "Japanese", "Film 11", "Japan", "https://example.com/poster11.jpg", 2, 2023, 71, new Guid("8c86f040-2a85-4d49-8c89-8a8788cc2d20"), new DateTime(2023, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer11.mp4", new Guid("d41d3cb6-8f93-45b1-8019-a8a8fe54c036") },
                    { new Guid("39d2cdfb-a3af-46d9-8a2b-604addd5eed7"), "Actor 28, Actress 28", new DateTime(2023, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 28.", "Director 28", "Film 28 (English)", "Action", "English", "Film 28", "USA", "https://example.com/poster28.jpg", 4, 2023, 88, new Guid("8059c55c-2455-44ff-9b3d-4186bd02f1f8"), new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer28.mp4", new Guid("c2756346-674b-4d26-abd2-913cd755b9f6") },
                    { new Guid("3e21fe17-e072-43fd-9a1c-66d4447641ae"), "Actor 13, Actress 13", new DateTime(2023, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 13.", "Director 13", "Film 13 (English)", "Comedy", "Japanese", "Film 13", "Japan", "https://example.com/poster13.jpg", 4, 2023, 73, new Guid("f5fb2199-4b3f-4b72-b781-fc8837fa53b1"), new DateTime(2023, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer13.mp4", new Guid("62e092e4-0adb-44f7-a9db-02e10d365e36") },
                    { new Guid("4d982c4f-1c29-44ce-a456-87a848be4969"), "Actor 6, Actress 6", new DateTime(2023, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 6.", "Director 6", "Film 6 (English)", "Action", "English", "Film 6", "USA", "https://example.com/poster6.jpg", 2, 2023, 66, new Guid("97ba1d1a-0792-4099-919c-2e4fa80caa7c"), new DateTime(2023, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer6.mp4", new Guid("621c7e4b-a030-4af1-a654-d2f3daa12d6d") },
                    { new Guid("4da74f06-5124-4b66-8116-8c8d82c65633"), "Actor 25, Actress 25", new DateTime(2023, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 25.", "Director 25", "Film 25 (English)", "Comedy", "Japanese", "Film 25", "Japan", "https://example.com/poster25.jpg", 1, 2023, 85, new Guid("35990214-5247-4021-8418-0522296e18a3"), new DateTime(2023, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer25.mp4", new Guid("8f11265d-8027-451e-8ab3-ff1cc145359b") },
                    { new Guid("55ee464f-bb63-4185-af52-d61f23d1d874"), "Actor 24, Actress 24", new DateTime(2023, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 24.", "Director 24", "Film 24 (English)", "Action", "English", "Film 24", "USA", "https://example.com/poster24.jpg", 5, 2023, 84, new Guid("73ee37ac-bf4b-40e1-a11d-a786514e6599"), new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer24.mp4", new Guid("18c61697-b1bb-46ab-a805-498db86261c2") },
                    { new Guid("6ac3752a-5d9f-4446-a105-1c04358c708a"), "Actor 14, Actress 14", new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 14.", "Director 14", "Film 14 (English)", "Action", "English", "Film 14", "USA", "https://example.com/poster14.jpg", 5, 2023, 74, new Guid("3554bae0-9b04-4e31-b44b-83aa624f80f6"), new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer14.mp4", new Guid("baea4f35-e9f4-42ae-a210-9761c68f6299") },
                    { new Guid("6c3ddbf7-7b29-4c0f-bb09-0727edd17ac1"), "Actor 19, Actress 19", new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 19.", "Director 19", "Film 19 (English)", "Comedy", "Japanese", "Film 19", "Japan", "https://example.com/poster19.jpg", 5, 2023, 79, new Guid("13ee8709-cb1e-498b-8678-7805ef79c80e"), new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer19.mp4", new Guid("7a5344eb-812d-4a64-b5f8-e7fd0cf8d2c9") },
                    { new Guid("7806ffb9-951a-4c67-b009-b3d186585d2c"), "Actor 3, Actress 3", new DateTime(2023, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 3.", "Director 3", "Film 3 (English)", "Comedy", "Japanese", "Film 3", "Japan", "https://example.com/poster3.jpg", 4, 2023, 63, new Guid("74becaa4-e725-401e-a313-38e37abe36e9"), new DateTime(2023, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer3.mp4", new Guid("3ff9d27a-2276-46d1-aca1-365dbdb06a9d") },
                    { new Guid("83eb765e-6517-4fee-831a-c7c9bcdd1209"), "Actor 7, Actress 7", new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 7.", "Director 7", "Film 7 (English)", "Comedy", "Japanese", "Film 7", "Japan", "https://example.com/poster7.jpg", 3, 2023, 67, new Guid("b53d6699-fc58-44d9-8cea-2947dcaf6bed"), new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer7.mp4", new Guid("db24cd8e-cab0-4e80-9381-5213a398269a") },
                    { new Guid("92ba852b-49f4-4169-b66f-05e72b0a5a97"), "Actor 9, Actress 9", new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 9.", "Director 9", "Film 9 (English)", "Comedy", "Japanese", "Film 9", "Japan", "https://example.com/poster9.jpg", 5, 2023, 69, new Guid("4682dca0-85d4-437f-89ed-8d0f22debd77"), new DateTime(2023, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer9.mp4", new Guid("9e87cfb2-40cf-4baa-a65d-177aeaab0590") },
                    { new Guid("a54b8f90-480a-43c4-8442-0cc2a8bf5a78"), "Actor 30, Actress 30", new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 30.", "Director 30", "Film 30 (English)", "Action", "English", "Film 30", "USA", "https://example.com/poster30.jpg", 1, 2023, 90, new Guid("2956a70d-db0c-40f0-84cf-2eb5f04f94e4"), new DateTime(2023, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer30.mp4", new Guid("69e96a5a-8673-4841-9153-3ae7fb0282b8") },
                    { new Guid("a6c30e12-e067-47eb-ae82-f6c3c810805f"), "Actor 23, Actress 23", new DateTime(2023, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 23.", "Director 23", "Film 23 (English)", "Comedy", "Japanese", "Film 23", "Japan", "https://example.com/poster23.jpg", 4, 2023, 83, new Guid("de4da006-11b7-4d72-ba45-4b2adcb961b7"), new DateTime(2023, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer23.mp4", new Guid("868b8a42-726f-467f-ad7e-2a5bb3311b35") },
                    { new Guid("c1cc2e3a-efda-4e20-95c4-da59a207ef20"), "Actor 27, Actress 27", new DateTime(2023, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 27.", "Director 27", "Film 27 (English)", "Comedy", "Japanese", "Film 27", "Japan", "https://example.com/poster27.jpg", 3, 2023, 87, new Guid("fefd2635-a4f8-4646-8446-1c6fede9438f"), new DateTime(2023, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer27.mp4", new Guid("280be84f-de17-412d-ad4a-5ac2fd608e7a") },
                    { new Guid("cd1632dd-2e30-4bf0-baff-83d9e3878230"), "Actor 10, Actress 10", new DateTime(2023, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 10.", "Director 10", "Film 10 (English)", "Action", "English", "Film 10", "USA", "https://example.com/poster10.jpg", 1, 2023, 70, new Guid("23b251ec-af5f-4564-9408-636747446e58"), new DateTime(2023, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer10.mp4", new Guid("31ece98d-1a8c-4f06-84f3-e59ad69fa417") },
                    { new Guid("cec4303c-1023-4911-aacd-4484f35b2880"), "Actor 20, Actress 20", new DateTime(2023, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 20.", "Director 20", "Film 20 (English)", "Action", "English", "Film 20", "USA", "https://example.com/poster20.jpg", 1, 2023, 80, new Guid("6f9a835d-5062-406d-a249-6524ffbf65af"), new DateTime(2023, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer20.mp4", new Guid("8b88355c-b0c7-4c31-bc89-a1d53aae4d70") },
                    { new Guid("d7420837-12b2-4246-80ef-de72c9212ad3"), "Actor 8, Actress 8", new DateTime(2023, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 8.", "Director 8", "Film 8 (English)", "Action", "English", "Film 8", "USA", "https://example.com/poster8.jpg", 4, 2023, 68, new Guid("c51af678-a754-42ca-a20a-a4edeb4353af"), new DateTime(2023, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer8.mp4", new Guid("0e20b629-ebce-4aae-8c25-a898cc6b00b2") },
                    { new Guid("e34a42b9-0c14-4353-a53d-6574d2c6d984"), "Actor 2, Actress 2", new DateTime(2023, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 2.", "Director 2", "Film 2 (English)", "Action", "English", "Film 2", "USA", "https://example.com/poster2.jpg", 3, 2023, 62, new Guid("b41b13a0-3fe8-4de8-82a6-a1691cdc207a"), new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer2.mp4", new Guid("1ac9c90e-071f-4137-8cb3-186518174d9a") },
                    { new Guid("ef269f1b-a14d-48ee-b250-99e0660b9921"), "Actor 26, Actress 26", new DateTime(2023, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 26.", "Director 26", "Film 26 (English)", "Action", "English", "Film 26", "USA", "https://example.com/poster26.jpg", 2, 2023, 86, new Guid("11046729-55ab-47ed-bedf-c7e21e249580"), new DateTime(2023, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer26.mp4", new Guid("ada30532-c4f0-448d-8a10-43f4f976a6a2") },
                    { new Guid("f500f281-afd5-4a3a-94ad-0632b88f700c"), "Actor 1, Actress 1", new DateTime(2023, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 1.", "Director 1", "Film 1 (English)", "Comedy", "Japanese", "Film 1", "Japan", "https://example.com/poster1.jpg", 2, 2023, 61, new Guid("b0ee5c30-044e-40e7-bc2c-ef53e23f4de4"), new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer1.mp4", new Guid("cd453a4a-6f11-4e4b-8812-c2209f375ef3") },
                    { new Guid("fbcf1f42-4a8d-43e9-96e2-805b0728c57b"), "Actor 17, Actress 17", new DateTime(2023, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 17.", "Director 17", "Film 17 (English)", "Comedy", "Japanese", "Film 17", "Japan", "https://example.com/poster17.jpg", 3, 2023, 77, new Guid("d6173300-746a-474b-b75f-24a6b96fc1dd"), new DateTime(2023, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer17.mp4", new Guid("14582543-d8aa-4adf-a726-a0f7cabdc24b") }
                });

            migrationBuilder.InsertData(
                table: "Promotions",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("04a7e053-7332-4481-a955-d7e370841ff3"), "Title 18" },
                    { new Guid("0dbede29-aa13-477b-b587-188040ec6df7"), "Title 8" },
                    { new Guid("29ee21c3-16fd-4dc9-96a5-6db18e10e3ce"), "Title 11" },
                    { new Guid("37e0e072-cf6a-4627-a0be-3c3c8e9238ab"), "Title 9" },
                    { new Guid("41662c88-dd81-49a6-a9b5-6ae639158b6d"), "Title 3" },
                    { new Guid("4554b60b-175f-440e-89e2-31fc5aa7a94c"), "Title 22" },
                    { new Guid("5499f036-2a4b-42af-80fa-d40d7a38f91a"), "Title 13" },
                    { new Guid("564f6061-499a-424e-8e35-25b45f8f6cdc"), "Title 16" },
                    { new Guid("57411195-4421-41c6-999a-53bf999b7b8f"), "Title 15" },
                    { new Guid("57f0afee-ec1b-4428-9605-a44dd1629174"), "Title 27" },
                    { new Guid("6079d1e1-9a86-444a-b978-f8dd27867552"), "Title 21" },
                    { new Guid("647bb1f3-12f3-433d-a841-fddd193fde4f"), "Title 10" },
                    { new Guid("67bd1a2f-764e-4d99-a55b-4ce466f59996"), "Title 23" },
                    { new Guid("686982db-dac2-44b1-842c-18403b291727"), "Title 17" },
                    { new Guid("68bb214c-c6f6-4f45-af77-f41502171424"), "Title 25" },
                    { new Guid("840faddf-7b78-4c8e-bc16-a8f9c030b98a"), "Title 2" },
                    { new Guid("ab127ad5-ae57-46d1-8f87-ac64610575dc"), "Title 7" },
                    { new Guid("ae0ce080-a933-47e2-88a3-44e44e58e8ca"), "Title 6" },
                    { new Guid("bd6b22af-ae46-4327-b869-e0ef0f17c335"), "Title 24" },
                    { new Guid("c6ce7187-3d77-4135-900f-0a3c2c18c91c"), "Title 14" },
                    { new Guid("c77f2981-dc17-4991-a9da-12b664052dc7"), "Title 5" },
                    { new Guid("c9bf9989-a240-443f-8dda-e580f5a9a8d1"), "Title 20" },
                    { new Guid("cfc1c69d-67cd-4e22-bd0a-88e6af5acea3"), "Title 1" },
                    { new Guid("d3ec5168-83b7-4e7d-9b12-96a8224aeb2a"), "Title 12" },
                    { new Guid("e663c2bd-5865-4894-9e2d-4fe512d221ca"), "Title 30" },
                    { new Guid("eaaf2bbc-4398-43bd-a92d-7d2bd5857a78"), "Title 4" },
                    { new Guid("ec546e29-af9c-44dc-be66-15e29b2085ed"), "Title 26" },
                    { new Guid("f55f7618-7e96-48e5-95cc-451b7a04ca18"), "Title 29" },
                    { new Guid("f69015aa-b733-48c8-8c04-8b813054e18e"), "Title 28" },
                    { new Guid("f87bf8f0-83be-4560-ba5d-f10ef91e06a8"), "Title 19" }
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
                    { new Guid("04134e8c-46b2-4bf3-bbfa-007f9a22e0a0"), new Guid("62e68a04-1132-4880-878e-1facb4deea97"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 10, "Description for Cinema 20", 100, "Cinema 20", 10 },
                    { new Guid("15ab9581-a950-4c59-bd4c-b8fa923d66ab"), new Guid("62e68a04-1132-4880-878e-1facb4deea97"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 10, "Description for Cinema 18", 100, "Cinema 18", 10 },
                    { new Guid("15e17613-86cc-4510-bea3-927e7fe28fdc"), new Guid("c05d2b45-12fd-449d-9518-31f561a9cee9"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 10, "Description for Cinema 5", 100, "Cinema 5", 10 },
                    { new Guid("165d9abc-a3cb-4634-a187-c09736a692ec"), new Guid("99a15a39-0e86-4931-ba52-45acba38ba25"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 10, "Description for Cinema 21", 100, "Cinema 21", 10 },
                    { new Guid("26b5381f-717d-4511-aac8-572f4166e13f"), new Guid("47cdf744-cc51-424d-a998-ae61053c95fc"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 10, "Description for Cinema 13", 100, "Cinema 13", 10 },
                    { new Guid("3a870612-5942-422f-9267-14f3396ad171"), new Guid("c05d2b45-12fd-449d-9518-31f561a9cee9"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 10, "Description for Cinema 16", 100, "Cinema 16", 10 },
                    { new Guid("537ff2ab-8b65-448a-ae56-803c11f914ee"), new Guid("c05d2b45-12fd-449d-9518-31f561a9cee9"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 10, "Description for Cinema 22", 100, "Cinema 22", 10 },
                    { new Guid("5930a52f-8a8d-4d44-9df7-6301070bdf0e"), new Guid("fd2c4ee6-d781-4b6f-9f9e-6c301d4dd791"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 10, "Description for Cinema 6", 100, "Cinema 6", 10 },
                    { new Guid("59a96e00-e92e-4cf6-af41-9cd367482bcc"), new Guid("d84496f3-aa10-44ee-9cd6-6f17a967fec3"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 10, "Description for Cinema 11", 100, "Cinema 11", 10 },
                    { new Guid("5acd6609-d37e-4730-b5c4-fcbd705c93e2"), new Guid("5968f5c9-0032-4f01-9b33-d37a21dfb6db"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 10, "Description for Cinema 15", 100, "Cinema 15", 10 },
                    { new Guid("62e9ecf2-c195-4d1f-8ab7-bcd691bface6"), new Guid("aa349729-6fe5-4e3e-9b98-6088bafeef20"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 10, "Description for Cinema 25", 100, "Cinema 25", 10 },
                    { new Guid("659345e6-ab9b-4b1c-b69f-01ebd8f767c7"), new Guid("67ce8ad3-516b-4ff6-9a6a-552d72dffe92"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 10, "Description for Cinema 19", 100, "Cinema 19", 10 },
                    { new Guid("70c4fdc5-6759-4ef8-89fa-62b904d85d45"), new Guid("2409d876-0c18-4d9b-9bd8-ceb6a1b73e40"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 10, "Description for Cinema 7", 100, "Cinema 7", 10 },
                    { new Guid("78cbfac1-fb48-41d0-9919-46f119079c21"), new Guid("fd2c4ee6-d781-4b6f-9f9e-6c301d4dd791"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 10, "Description for Cinema 14", 100, "Cinema 14", 10 },
                    { new Guid("795971d7-4379-470a-a270-2772be5493ca"), new Guid("9d02e80f-085e-43a7-8afa-00239a1245e7"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 10, "Description for Cinema 3", 100, "Cinema 3", 10 },
                    { new Guid("879e5acf-9ad5-4c5e-a832-a0e168824ba6"), new Guid("766e5f3b-a530-4bd5-92d9-a3ee084a6504"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 10, "Description for Cinema 17", 100, "Cinema 17", 10 },
                    { new Guid("9e377f2c-a9ac-411d-82cb-7fe084e7daff"), new Guid("9560a4d9-8ed4-4f69-910f-f264ef58255c"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 10, "Description for Cinema 27", 100, "Cinema 27", 10 },
                    { new Guid("b3750ec2-01a2-4060-abd2-4cf07159f378"), new Guid("766e5f3b-a530-4bd5-92d9-a3ee084a6504"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 10, "Description for Cinema 29", 100, "Cinema 29", 10 },
                    { new Guid("b4ea933c-cfaf-43b4-b813-c81433b8a73f"), new Guid("766e5f3b-a530-4bd5-92d9-a3ee084a6504"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 10, "Description for Cinema 4", 100, "Cinema 4", 10 },
                    { new Guid("be9c1b85-0bc1-4125-bb7c-aab82154ec32"), new Guid("213ed74b-499a-47e7-b684-77c109cd751c"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 10, "Description for Cinema 24", 100, "Cinema 24", 10 },
                    { new Guid("c7cc70e3-08d2-4291-bf52-35de60f98a16"), new Guid("519072f0-b8d7-4b8f-a16f-0ae7b1271e1d"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 10, "Description for Cinema 9", 100, "Cinema 9", 10 },
                    { new Guid("cc515d78-b58f-4356-95c0-de59791e7167"), new Guid("fd987245-4f2a-40b5-b5b7-e9d3ed3b29c2"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 10, "Description for Cinema 28", 100, "Cinema 28", 10 },
                    { new Guid("d4a52464-d55a-404c-9fe1-0b536cf8ea87"), new Guid("b78159bf-ffb8-4d12-b6cf-944340349352"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 10, "Description for Cinema 23", 100, "Cinema 23", 10 },
                    { new Guid("d52dd338-62af-4237-b589-558ae0026f62"), new Guid("9d02e80f-085e-43a7-8afa-00239a1245e7"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 10, "Description for Cinema 26", 100, "Cinema 26", 10 },
                    { new Guid("d7bcad7d-bb1a-4bbe-9be6-f7796976a2b5"), new Guid("a5f5459f-3061-4d77-9a43-8eb4017f0a6e"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 10, "Description for Cinema 2", 100, "Cinema 2", 10 },
                    { new Guid("d92fac80-24b8-4dd7-afbe-6421faaf85d7"), new Guid("47cdf744-cc51-424d-a998-ae61053c95fc"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 10, "Description for Cinema 1", 100, "Cinema 1", 10 },
                    { new Guid("d9fe7bf1-0b6a-44b8-9ce6-888218fa62e8"), new Guid("0920589e-8404-4570-8111-b66d85c9f0cc"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 10, "Description for Cinema 10", 100, "Cinema 10", 10 },
                    { new Guid("ea6b4f45-7a57-453d-800b-0ab61319bcc7"), new Guid("fd2c4ee6-d781-4b6f-9f9e-6c301d4dd791"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 10, "Description for Cinema 8", 100, "Cinema 8", 10 },
                    { new Guid("f073cdef-65a5-4f6a-a090-352873274de5"), new Guid("5968f5c9-0032-4f01-9b33-d37a21dfb6db"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 10, "Description for Cinema 30", 100, "Cinema 30", 10 },
                    { new Guid("f707baba-5ecb-4580-956b-c1b577d73eea"), new Guid("79095388-508b-4549-9c7d-475ce44798d5"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 10, "Description for Cinema 12", 100, "Cinema 12", 10 }
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
                    { new Guid("03c089b3-7b6f-4af8-a26d-f37949ab8afc"), new DateTime(2023, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("cd1632dd-2e30-4bf0-baff-83d9e3878230"), new DateTime(2023, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { new Guid("10912ccb-e19d-484c-89fa-bb0afd1c8100"), new DateTime(2023, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("92ba852b-49f4-4169-b66f-05e72b0a5a97"), new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0 },
                    { new Guid("175088f8-0b5b-4c40-beea-eaf0a8c1d7b6"), new DateTime(2023, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f500f281-afd5-4a3a-94ad-0632b88f700c"), new DateTime(2023, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { new Guid("1e788a52-b071-4fa1-926c-a91932a60bb5"), new DateTime(2023, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("1d26d0bc-28d2-4670-87ae-069d7c485c77"), new DateTime(2023, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0 },
                    { new Guid("202753d7-463b-44e3-b71c-6c9fd8515bf2"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a54b8f90-480a-43c4-8442-0cc2a8bf5a78"), new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { new Guid("28573f7f-1fbc-4f4a-b8cc-4caaf1699af8"), new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d7420837-12b2-4246-80ef-de72c9212ad3"), new DateTime(2023, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { new Guid("290991c8-885b-457c-99e8-5da3c553469f"), new DateTime(2023, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("21c9e756-ee2b-4448-aec3-1c6ad704e3b2"), new DateTime(2023, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { new Guid("3be2ee27-7b72-42c7-81fa-479221841d64"), new DateTime(2023, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("19faa4b8-6687-4f1a-b17a-a2667650a166"), new DateTime(2023, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { new Guid("3ee725ed-80f8-4968-bc23-d494a8cf4220"), new DateTime(2023, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ef269f1b-a14d-48ee-b250-99e0660b9921"), new DateTime(2023, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0 },
                    { new Guid("5b54f089-9b7e-4054-9f01-0874ba5d9ddd"), new DateTime(2023, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("1b4095a8-d53e-40f7-9ccb-435cb19a5300"), new DateTime(2023, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0 },
                    { new Guid("5e831c18-6546-4f4f-b250-19979b81b256"), new DateTime(2023, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c1cc2e3a-efda-4e20-95c4-da59a207ef20"), new DateTime(2023, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { new Guid("614f677a-071d-495b-98c1-0240d5a36166"), new DateTime(2023, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7806ffb9-951a-4c67-b009-b3d186585d2c"), new DateTime(2023, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { new Guid("7078a0c5-c514-4385-9678-eaa9ab7a1e9f"), new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4d982c4f-1c29-44ce-a456-87a848be4969"), new DateTime(2023, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0 },
                    { new Guid("7b5f4426-9cfb-4d29-8ba8-70e98d6c0750"), new DateTime(2023, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("219a7453-924e-4c1b-9ac4-b687954122fb"), new DateTime(2023, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { new Guid("8952d1be-8ced-4464-a6fa-48597145c8d9"), new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e21fe17-e072-43fd-9a1c-66d4447641ae"), new DateTime(2023, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { new Guid("898d9018-68b6-468f-aca4-130c7116879d"), new DateTime(2023, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6ac3752a-5d9f-4446-a105-1c04358c708a"), new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0 },
                    { new Guid("9b4cf951-7342-4957-ad35-8f038e48e109"), new DateTime(2023, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6c3ddbf7-7b29-4c0f-bb09-0727edd17ac1"), new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { new Guid("9f215eaf-0c86-493e-9255-a8563be87df5"), new DateTime(2023, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e34a42b9-0c14-4353-a53d-6574d2c6d984"), new DateTime(2023, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { new Guid("9f46a4d9-b2c7-4e12-a898-92e7fb2e9312"), new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("26fd53f7-5e35-4d06-ac4f-ad11554ddb39"), new DateTime(2023, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0 },
                    { new Guid("aa8542bc-da91-4be5-89ea-6e198c84fbd4"), new DateTime(2023, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("336534a4-84fd-41b5-abf2-65297ecac38e"), new DateTime(2023, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { new Guid("b2763688-a25a-46f2-9129-3bbb77fea02d"), new DateTime(2023, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4da74f06-5124-4b66-8116-8c8d82c65633"), new DateTime(2023, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { new Guid("bec3db35-3467-4a07-b70f-39edd6a7c3d7"), new DateTime(2023, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a6c30e12-e067-47eb-ae82-f6c3c810805f"), new DateTime(2023, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { new Guid("c2e29a65-dea5-4c6a-a02a-4025be86fe35"), new DateTime(2023, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("83eb765e-6517-4fee-831a-c7c9bcdd1209"), new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0 },
                    { new Guid("d5dfcb97-ea32-4f49-a6a9-af8c3cd88c0d"), new DateTime(2023, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("55ee464f-bb63-4185-af52-d61f23d1d874"), new DateTime(2023, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { new Guid("dc299bc0-107c-4bc9-9cf1-6d2cf51a7b81"), new DateTime(2023, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2a1846c1-845a-47ef-9d6a-16c0b6526b8c"), new DateTime(2023, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { new Guid("e3fce93b-ab0c-4b26-82ab-3470f74f16ea"), new DateTime(2023, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("cec4303c-1023-4911-aacd-4484f35b2880"), new DateTime(2023, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { new Guid("eabef9b4-68a9-4ffa-8991-a55849aee76f"), new DateTime(2023, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fbcf1f42-4a8d-43e9-96e2-805b0728c57b"), new DateTime(2023, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0 },
                    { new Guid("ecf8bd49-d532-47cc-a4c5-2129db156155"), new DateTime(2023, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("39d2cdfb-a3af-46d9-8a2b-604addd5eed7"), new DateTime(2023, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { new Guid("ef0e1659-f80a-4842-9f79-16321f804a4a"), new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("1bdf8e26-5d47-4398-a911-feb85d9350a5"), new DateTime(2023, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { new Guid("f0a77191-92bc-4249-b92a-13a6535c4398"), new DateTime(2023, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0dbc75c0-e6a9-4cb5-b5a5-07a51609525f"), new DateTime(2023, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0 }
                });

            migrationBuilder.InsertData(
                table: "TicketPrices",
                columns: new[] { "Id", "CinemaTypeId", "Price", "ScreenTypeId", "ScreeningDayId", "SeatTypeId", "Status" },
                values: new object[,]
                {
                    { new Guid("0166cc15-553a-4b30-9db5-910f6cabc06f"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 50000m, new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 0 },
                    { new Guid("14fd6681-3436-41f3-aa02-53610f993288"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 30000m, new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new Guid("e4f8f494-4e25-4966-806a-7b8843d79b6b"), new Guid("428edc6b-0862-4623-b038-ac505fd554bc"), 0 },
                    { new Guid("1b9bd352-b261-49db-a135-061651c5e570"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 80000m, new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new Guid("e4f8f494-4e25-4966-806a-7b8843d79b6b"), new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 0 },
                    { new Guid("1ca94ca7-e991-46fe-a0d7-2eb69718181b"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 80000m, new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("d997b27a-ddb7-4ad1-a1cd-c2bd00c50cb9"), 0 },
                    { new Guid("22d6c4f7-1ee4-473f-b89e-7079cca4b29f"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 30000m, new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new Guid("e4f8f494-4e25-4966-806a-7b8843d79b6b"), new Guid("428edc6b-0862-4623-b038-ac505fd554bc"), 0 },
                    { new Guid("24ada8b8-c8b7-4b29-b934-bd5994c989f7"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 40000m, new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("428edc6b-0862-4623-b038-ac505fd554bc"), 0 },
                    { new Guid("27d9ea31-64f0-4dce-9edc-02d02a4423a0"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 90000m, new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new Guid("d51bee9b-54c3-4a3c-a06a-7c3940852f57"), new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 0 },
                    { new Guid("2dc35731-4e5e-4355-a394-ae14a6fef8de"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 70000m, new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 0 },
                    { new Guid("2fc01c25-f5c8-4f5c-84f9-366b56259060"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 20000m, new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new Guid("e4f8f494-4e25-4966-806a-7b8843d79b6b"), new Guid("428edc6b-0862-4623-b038-ac505fd554bc"), 0 },
                    { new Guid("50ffea86-33a7-4196-9a73-b1fbdd201732"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 10000m, new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new Guid("e4f8f494-4e25-4966-806a-7b8843d79b6b"), new Guid("428edc6b-0862-4623-b038-ac505fd554bc"), 0 },
                    { new Guid("56fa4815-3a91-4f1f-ba7f-2f3f6c69cd1c"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 70000m, new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("d997b27a-ddb7-4ad1-a1cd-c2bd00c50cb9"), 0 },
                    { new Guid("5819e604-52e7-415d-8ea6-726e4aa6966c"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 20000m, new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new Guid("e4f8f494-4e25-4966-806a-7b8843d79b6b"), new Guid("428edc6b-0862-4623-b038-ac505fd554bc"), 0 },
                    { new Guid("7562cbd1-8efe-4e4b-a218-3f85df1b3a3e"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 60000m, new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new Guid("e4f8f494-4e25-4966-806a-7b8843d79b6b"), new Guid("428edc6b-0862-4623-b038-ac505fd554bc"), 0 },
                    { new Guid("80426196-1a34-4805-9b44-69796214e6df"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 0m, new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new Guid("e4f8f494-4e25-4966-806a-7b8843d79b6b"), new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 0 },
                    { new Guid("889e3fb1-17cd-4054-8386-0335a5f4713a"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 90000m, new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new Guid("e4f8f494-4e25-4966-806a-7b8843d79b6b"), new Guid("d997b27a-ddb7-4ad1-a1cd-c2bd00c50cb9"), 0 },
                    { new Guid("8b90223a-ae53-4926-b679-61c52797bf01"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 10000m, new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("d997b27a-ddb7-4ad1-a1cd-c2bd00c50cb9"), 0 },
                    { new Guid("8ce0b561-5468-4af5-88f2-f77651539dcc"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 80000m, new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("d997b27a-ddb7-4ad1-a1cd-c2bd00c50cb9"), 0 },
                    { new Guid("8ed12bcc-98ad-40fc-8459-0e76ee7551fc"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 20000m, new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("d997b27a-ddb7-4ad1-a1cd-c2bd00c50cb9"), 0 },
                    { new Guid("a4751648-e71e-4dc2-ae49-9151fcbffd44"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 50000m, new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new Guid("e4f8f494-4e25-4966-806a-7b8843d79b6b"), new Guid("428edc6b-0862-4623-b038-ac505fd554bc"), 0 },
                    { new Guid("a87bda7a-cc6f-4d09-a83e-a747ce3d5e6d"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 90000m, new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 0 },
                    { new Guid("ac4f41e0-c4e2-4e2a-a0a9-4934601ac7bb"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 60000m, new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("428edc6b-0862-4623-b038-ac505fd554bc"), 0 },
                    { new Guid("ac8cf4ca-7842-42fe-aa32-5d34b42f14c1"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 60000m, new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new Guid("d51bee9b-54c3-4a3c-a06a-7c3940852f57"), new Guid("428edc6b-0862-4623-b038-ac505fd554bc"), 0 },
                    { new Guid("b6f7cbf4-8071-4a20-9fcf-e3090c0b863b"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 40000m, new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("d997b27a-ddb7-4ad1-a1cd-c2bd00c50cb9"), 0 },
                    { new Guid("bdb0129a-879c-41fd-a61a-204a1eb45f90"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 0m, new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("d997b27a-ddb7-4ad1-a1cd-c2bd00c50cb9"), 0 },
                    { new Guid("d4d6e7b6-9d43-49e4-bf60-3177ba997242"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 40000m, new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new Guid("e4f8f494-4e25-4966-806a-7b8843d79b6b"), new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 0 },
                    { new Guid("df129c84-9419-4878-aa87-8290ba6cc158"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 0m, new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 0 },
                    { new Guid("df9144db-8539-43fe-919f-1147fa121bf4"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 70000m, new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new Guid("d51bee9b-54c3-4a3c-a06a-7c3940852f57"), new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 0 },
                    { new Guid("f692453c-f40b-4ec8-9ba0-03c2b42afb8b"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 10000m, new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new Guid("d51bee9b-54c3-4a3c-a06a-7c3940852f57"), new Guid("d997b27a-ddb7-4ad1-a1cd-c2bd00c50cb9"), 0 },
                    { new Guid("f712c1b2-a8af-481a-8c14-4de892f14632"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 30000m, new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new Guid("e4f8f494-4e25-4966-806a-7b8843d79b6b"), new Guid("d997b27a-ddb7-4ad1-a1cd-c2bd00c50cb9"), 0 },
                    { new Guid("fea23cad-e864-488d-aefc-e43a9f62ac87"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 50000m, new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 0 }
                });

            migrationBuilder.InsertData(
                table: "ShowTimes",
                columns: new[] { "Id", "CinemaCenterId", "CinemaId", "Desciption", "EndTime", "FilmId", "ScheduleId", "ScreenTypeId", "StartTime", "Status", "TranslationTypeId" },
                values: new object[,]
                {
                    { new Guid("049b288d-d4c5-4ff1-8a4c-d9767d528965"), new Guid("639ce77d-b096-4453-bfa8-1c0fa2dcc23c"), new Guid("c7cc70e3-08d2-4291-bf52-35de60f98a16"), "Description for ShowTime 23", new DateTime(2023, 8, 24, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a6c30e12-e067-47eb-ae82-f6c3c810805f"), new Guid("bec3db35-3467-4a07-b70f-39edd6a7c3d7"), new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new DateTime(2023, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("05bed03b-f33f-4f57-8316-5400b3b1bdf4"), new Guid("213ed74b-499a-47e7-b684-77c109cd751c"), new Guid("795971d7-4379-470a-a270-2772be5493ca"), "Description for ShowTime 10", new DateTime(2023, 8, 11, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("cd1632dd-2e30-4bf0-baff-83d9e3878230"), new Guid("03c089b3-7b6f-4af8-a26d-f37949ab8afc"), new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new DateTime(2023, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("06f16384-ad1a-4269-b7d9-7642ac889f33"), new Guid("302b31a4-601f-4ea0-a358-a326f9257d8c"), new Guid("b3750ec2-01a2-4060-abd2-4cf07159f378"), "Description for ShowTime 14", new DateTime(2023, 8, 15, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6ac3752a-5d9f-4446-a105-1c04358c708a"), new Guid("898d9018-68b6-468f-aca4-130c7116879d"), new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("086a807f-9efd-4a90-adc0-be7cf62d94b9"), new Guid("519072f0-b8d7-4b8f-a16f-0ae7b1271e1d"), new Guid("b3750ec2-01a2-4060-abd2-4cf07159f378"), "Description for ShowTime 15", new DateTime(2023, 8, 16, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("1d26d0bc-28d2-4670-87ae-069d7c485c77"), new Guid("1e788a52-b071-4fa1-926c-a91932a60bb5"), new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new DateTime(2023, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("1952a7c5-72d0-4ebf-af97-e99093178e13"), new Guid("2409d876-0c18-4d9b-9bd8-ceb6a1b73e40"), new Guid("26b5381f-717d-4511-aac8-572f4166e13f"), "Description for ShowTime 17", new DateTime(2023, 8, 18, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fbcf1f42-4a8d-43e9-96e2-805b0728c57b"), new Guid("eabef9b4-68a9-4ffa-8991-a55849aee76f"), new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new DateTime(2023, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("1ca187e3-02b8-4f21-b686-035d26de4bfd"), new Guid("0920589e-8404-4570-8111-b66d85c9f0cc"), new Guid("165d9abc-a3cb-4634-a187-c09736a692ec"), "Description for ShowTime 26", new DateTime(2023, 8, 27, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ef269f1b-a14d-48ee-b250-99e0660b9921"), new Guid("3ee725ed-80f8-4968-bc23-d494a8cf4220"), new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new DateTime(2023, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("296538cd-3282-4879-bbb7-a4c8f1b9ad82"), new Guid("2d4f8157-b352-4f54-b04a-2784011c090d"), new Guid("879e5acf-9ad5-4c5e-a832-a0e168824ba6"), "Description for ShowTime 3", new DateTime(2023, 8, 4, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7806ffb9-951a-4c67-b009-b3d186585d2c"), new Guid("614f677a-071d-495b-98c1-0240d5a36166"), new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new DateTime(2023, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("320bd0b7-b17a-4eef-abea-d72ec376c8df"), new Guid("a5f5459f-3061-4d77-9a43-8eb4017f0a6e"), new Guid("04134e8c-46b2-4bf3-bbfa-007f9a22e0a0"), "Description for ShowTime 5", new DateTime(2023, 8, 6, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2a1846c1-845a-47ef-9d6a-16c0b6526b8c"), new Guid("dc299bc0-107c-4bc9-9cf1-6d2cf51a7b81"), new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new DateTime(2023, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("388ba81b-052c-4094-9799-8de572347b1f"), new Guid("5968f5c9-0032-4f01-9b33-d37a21dfb6db"), new Guid("d92fac80-24b8-4dd7-afbe-6421faaf85d7"), "Description for ShowTime 2", new DateTime(2023, 8, 3, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e34a42b9-0c14-4353-a53d-6574d2c6d984"), new Guid("9f215eaf-0c86-493e-9255-a8563be87df5"), new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new DateTime(2023, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("3b63fa5f-daa5-40fe-b159-ed36ada9c974"), new Guid("2d4f8157-b352-4f54-b04a-2784011c090d"), new Guid("d92fac80-24b8-4dd7-afbe-6421faaf85d7"), "Description for ShowTime 7", new DateTime(2023, 8, 8, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("83eb765e-6517-4fee-831a-c7c9bcdd1209"), new Guid("c2e29a65-dea5-4c6a-a02a-4025be86fe35"), new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("45b6c490-9b32-41b7-8d5b-dce5c43c1781"), new Guid("9560a4d9-8ed4-4f69-910f-f264ef58255c"), new Guid("f073cdef-65a5-4f6a-a090-352873274de5"), "Description for ShowTime 27", new DateTime(2023, 8, 28, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c1cc2e3a-efda-4e20-95c4-da59a207ef20"), new Guid("5e831c18-6546-4f4f-b250-19979b81b256"), new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new DateTime(2023, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("5406b919-22fa-454a-848e-dfd41b6f82f3"), new Guid("9d02e80f-085e-43a7-8afa-00239a1245e7"), new Guid("d9fe7bf1-0b6a-44b8-9ce6-888218fa62e8"), "Description for ShowTime 20", new DateTime(2023, 8, 21, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("cec4303c-1023-4911-aacd-4484f35b2880"), new Guid("e3fce93b-ab0c-4b26-82ab-3470f74f16ea"), new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new DateTime(2023, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("59e7b67a-d7a6-43b5-b9ea-7060f96fce4b"), new Guid("e5e935c0-59ff-4ac0-b32e-99ab5fe33064"), new Guid("ea6b4f45-7a57-453d-800b-0ab61319bcc7"), "Description for ShowTime 6", new DateTime(2023, 8, 7, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4d982c4f-1c29-44ce-a456-87a848be4969"), new Guid("7078a0c5-c514-4385-9678-eaa9ab7a1e9f"), new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new DateTime(2023, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("5d843c42-44b9-40b5-ba9f-8304c95a9b9c"), new Guid("99a15a39-0e86-4931-ba52-45acba38ba25"), new Guid("70c4fdc5-6759-4ef8-89fa-62b904d85d45"), "Description for ShowTime 12", new DateTime(2023, 8, 13, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("1b4095a8-d53e-40f7-9ccb-435cb19a5300"), new Guid("5b54f089-9b7e-4054-9f01-0874ba5d9ddd"), new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new DateTime(2023, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("61b30b3b-779a-4e37-a8b3-834c7cacdf47"), new Guid("2d4f8157-b352-4f54-b04a-2784011c090d"), new Guid("795971d7-4379-470a-a270-2772be5493ca"), "Description for ShowTime 4", new DateTime(2023, 8, 5, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("219a7453-924e-4c1b-9ac4-b687954122fb"), new Guid("7b5f4426-9cfb-4d29-8ba8-70e98d6c0750"), new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new DateTime(2023, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("62939f73-e069-4e90-a84e-779811ce3a6c"), new Guid("fd987245-4f2a-40b5-b5b7-e9d3ed3b29c2"), new Guid("b4ea933c-cfaf-43b4-b813-c81433b8a73f"), "Description for ShowTime 18", new DateTime(2023, 8, 19, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("26fd53f7-5e35-4d06-ac4f-ad11554ddb39"), new Guid("9f46a4d9-b2c7-4e12-a898-92e7fb2e9312"), new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new DateTime(2023, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("6eb70110-7dbf-4324-8bc0-480e058aef20"), new Guid("b78159bf-ffb8-4d12-b6cf-944340349352"), new Guid("62e9ecf2-c195-4d1f-8ab7-bcd691bface6"), "Description for ShowTime 13", new DateTime(2023, 8, 14, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e21fe17-e072-43fd-9a1c-66d4447641ae"), new Guid("8952d1be-8ced-4464-a6fa-48597145c8d9"), new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new DateTime(2023, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("91e7fb95-edc8-4a97-9713-a780cdd332b7"), new Guid("e5e935c0-59ff-4ac0-b32e-99ab5fe33064"), new Guid("3a870612-5942-422f-9267-14f3396ad171"), "Description for ShowTime 16", new DateTime(2023, 8, 17, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("21c9e756-ee2b-4448-aec3-1c6ad704e3b2"), new Guid("290991c8-885b-457c-99e8-5da3c553469f"), new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new DateTime(2023, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("96777a4b-04ce-45ad-87d6-89e8fef5e4ed"), new Guid("c05d2b45-12fd-449d-9518-31f561a9cee9"), new Guid("b4ea933c-cfaf-43b4-b813-c81433b8a73f"), "Description for ShowTime 21", new DateTime(2023, 8, 22, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("19faa4b8-6687-4f1a-b17a-a2667650a166"), new Guid("3be2ee27-7b72-42c7-81fa-479221841d64"), new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new DateTime(2023, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("9a9f4b52-f0fc-47b4-9c6d-6cb01606cb78"), new Guid("fd2c4ee6-d781-4b6f-9f9e-6c301d4dd791"), new Guid("795971d7-4379-470a-a270-2772be5493ca"), "Description for ShowTime 8", new DateTime(2023, 8, 9, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d7420837-12b2-4246-80ef-de72c9212ad3"), new Guid("28573f7f-1fbc-4f4a-b8cc-4caaf1699af8"), new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new DateTime(2023, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("bd36b3ee-5dba-48df-9ea7-c99a0b4e4f7d"), new Guid("96ea85d5-6f20-411c-b106-3ee1d0ad72dd"), new Guid("f073cdef-65a5-4f6a-a090-352873274de5"), "Description for ShowTime 22", new DateTime(2023, 8, 23, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0dbc75c0-e6a9-4cb5-b5a5-07a51609525f"), new Guid("f0a77191-92bc-4249-b92a-13a6535c4398"), new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new DateTime(2023, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("ca0f2e68-6234-4301-a388-930905002886"), new Guid("d84496f3-aa10-44ee-9cd6-6f17a967fec3"), new Guid("d92fac80-24b8-4dd7-afbe-6421faaf85d7"), "Description for ShowTime 30", new DateTime(2023, 8, 31, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a54b8f90-480a-43c4-8442-0cc2a8bf5a78"), new Guid("202753d7-463b-44e3-b71c-6c9fd8515bf2"), new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("d14652b1-32a6-457b-acbb-76046cc19d31"), new Guid("fd987245-4f2a-40b5-b5b7-e9d3ed3b29c2"), new Guid("d7bcad7d-bb1a-4bbe-9be6-f7796976a2b5"), "Description for ShowTime 1", new DateTime(2023, 8, 2, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f500f281-afd5-4a3a-94ad-0632b88f700c"), new Guid("175088f8-0b5b-4c40-beea-eaf0a8c1d7b6"), new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new DateTime(2023, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("dbff069c-b50f-425a-a234-a5d280747769"), new Guid("a5f5459f-3061-4d77-9a43-8eb4017f0a6e"), new Guid("537ff2ab-8b65-448a-ae56-803c11f914ee"), "Description for ShowTime 11", new DateTime(2023, 8, 12, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("336534a4-84fd-41b5-abf2-65297ecac38e"), new Guid("aa8542bc-da91-4be5-89ea-6e198c84fbd4"), new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new DateTime(2023, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("e0087a9a-8f40-4e47-a120-dec3f4920614"), new Guid("d1a648f7-7978-4ca0-9064-a7effad47f10"), new Guid("70c4fdc5-6759-4ef8-89fa-62b904d85d45"), "Description for ShowTime 29", new DateTime(2023, 8, 30, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("1bdf8e26-5d47-4398-a911-feb85d9350a5"), new Guid("ef0e1659-f80a-4842-9f79-16321f804a4a"), new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new DateTime(2023, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("e09be888-5d38-4673-a857-5388c2fdfb79"), new Guid("96ea85d5-6f20-411c-b106-3ee1d0ad72dd"), new Guid("62e9ecf2-c195-4d1f-8ab7-bcd691bface6"), "Description for ShowTime 19", new DateTime(2023, 8, 20, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6c3ddbf7-7b29-4c0f-bb09-0727edd17ac1"), new Guid("9b4cf951-7342-4957-ad35-8f038e48e109"), new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("e8942e4b-f7ef-4be1-8493-1519ce24347f"), new Guid("d1a648f7-7978-4ca0-9064-a7effad47f10"), new Guid("795971d7-4379-470a-a270-2772be5493ca"), "Description for ShowTime 24", new DateTime(2023, 8, 25, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("55ee464f-bb63-4185-af52-d61f23d1d874"), new Guid("d5dfcb97-ea32-4f49-a6a9-af8c3cd88c0d"), new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new DateTime(2023, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("ed0518ac-4145-491b-bfd3-750437045703"), new Guid("639ce77d-b096-4453-bfa8-1c0fa2dcc23c"), new Guid("165d9abc-a3cb-4634-a187-c09736a692ec"), "Description for ShowTime 9", new DateTime(2023, 8, 10, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("92ba852b-49f4-4169-b66f-05e72b0a5a97"), new Guid("10912ccb-e19d-484c-89fa-bb0afd1c8100"), new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("eda106e1-f927-4645-8b41-2afbc147995e"), new Guid("4a49a3bb-2457-4248-89ef-e091a33d4c1f"), new Guid("70c4fdc5-6759-4ef8-89fa-62b904d85d45"), "Description for ShowTime 28", new DateTime(2023, 8, 29, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("39d2cdfb-a3af-46d9-8a2b-604addd5eed7"), new Guid("ecf8bd49-d532-47cc-a4c5-2129db156155"), new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new DateTime(2023, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("ee21d8ed-b06f-4d6f-8bd2-1d257a48be2c"), new Guid("d1a648f7-7978-4ca0-9064-a7effad47f10"), new Guid("5930a52f-8a8d-4d44-9df7-6301070bdf0e"), "Description for ShowTime 25", new DateTime(2023, 8, 26, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4da74f06-5124-4b66-8116-8c8d82c65633"), new Guid("b2763688-a25a-46f2-9129-3bbb77fea02d"), new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new DateTime(2023, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") }
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
