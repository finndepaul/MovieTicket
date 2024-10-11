using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieTicket.Infrastructure.Migrations.MovieTicketReadOnlyDb
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
                    { new Guid("0f43a4fa-3fbf-4e75-8cda-f8275c6e8a21"), "avatar15.png", new DateTime(2023, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "user15@example.com", "User 15", "AtoLhqKWoDhm5ytm7x3CFg==", "123-456-78915", 2, 1, "user15" },
                    { new Guid("18eb30ed-5bb6-43f7-a89c-be928c6a2403"), "avatar18.png", new DateTime(2023, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "user18@example.com", "User 18", "zp6jPz/JRrDgXS7tmjREDQ==", "123-456-78918", 2, 1, "user18" },
                    { new Guid("1958964d-9447-4968-bd2b-75dc08e06667"), "avatar7.png", new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "user7@example.com", "User 7", "h8t5vD5p1U3C4AEASeaErg==", "123-456-7897", 2, 1, "user7" },
                    { new Guid("1bbcf9f7-7e52-4b0c-874f-2ac53e78eed2"), "avatar20.png", new DateTime(2023, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "user20@example.com", "User 20", "J20oEfuyjDdy085hSNPLIw==", "123-456-78920", 2, 1, "user20" },
                    { new Guid("257e2056-6367-48cc-9599-3c73b769e241"), "avatar17.png", new DateTime(2023, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "user17@example.com", "User 17", "bnivYPkMUcJNzvYQyXZIvw==", "123-456-78917", 2, 1, "user17" },
                    { new Guid("2b730f7b-f16a-447c-9d1f-be776c9ed466"), "avatar22.png", new DateTime(2023, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "user22@example.com", "User 22", "yuwYTyVSnjUQg9d58Fr6eg==", "123-456-78922", 2, 1, "user22" },
                    { new Guid("31bb8204-4a9d-4d88-bfb3-0a85c2d9c046"), "avatar6.png", new DateTime(2023, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "user6@example.com", "User 6", "ns3cIzMXn9uRJUqXbdf1sw==", "123-456-7896", 2, 1, "user6" },
                    { new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), "avatar2.png", new DateTime(2023, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "azusachan309@gmail.com", "ClientTest", "LK25tQh1RqkKbrq4C2l6fw==", "000-000-000", 2, 1, "Client" },
                    { new Guid("36b31db5-6f9c-416c-a418-19a4ecaa06a3"), "avatar23.png", new DateTime(2023, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "user23@example.com", "User 23", "JM3wDHJHLSLI6Wdnnfs2dQ==", "123-456-78923", 2, 1, "user23" },
                    { new Guid("3b551ccd-825f-4066-99e6-1d0c1bea42b0"), "avatar5.png", new DateTime(2023, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "user5@example.com", "User 5", "LtgxZLXxd71ac78V6rYtcg==", "123-456-7895", 2, 1, "user5" },
                    { new Guid("437c4804-4961-49bf-bb47-13566db28062"), "avatar16.png", new DateTime(2023, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "user16@example.com", "User 16", "1+4JJ+OIs+XRXx0vTPNGQA==", "123-456-78916", 2, 1, "user16" },
                    { new Guid("4402a38e-d4c3-4a9b-8aec-96f8531129b9"), "avatar4.png", new DateTime(2023, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "user4@example.com", "User 4", "AYCB0pkX1QvnELN5s4E7/w==", "123-456-7894", 2, 1, "user4" },
                    { new Guid("5113da54-ffba-4d14-921f-b1600df52fb0"), "avatar8.png", new DateTime(2023, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "user8@example.com", "User 8", "QoNqXwm6ndtmwV7AptAudw==", "123-456-7898", 2, 1, "user8" },
                    { new Guid("577e8348-48b7-4d88-8323-594633c813b8"), "avatar13.png", new DateTime(2023, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "user13@example.com", "User 13", "hjKFGDVLaz8y7jip9ebjyg==", "123-456-78913", 2, 1, "user13" },
                    { new Guid("61904d7a-dcea-45b7-aa25-c23bb13b1ae7"), "avatar21.png", new DateTime(2023, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "user21@example.com", "User 21", "uqWAcnIuI+ey7XOiRgb8IA==", "123-456-78921", 2, 1, "user21" },
                    { new Guid("68753652-97a3-4f0d-8774-7e84c9a12f97"), "avatar12.png", new DateTime(2023, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "user12@example.com", "User 12", "q/b7mh1nE1JeI7y/w6yvIQ==", "123-456-78912", 2, 1, "user12" },
                    { new Guid("7e90a8b3-69c3-43ef-a493-031a17c415d9"), "avatar19.png", new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "user19@example.com", "User 19", "+BFH+L+RScNaLm45T9M5Tw==", "123-456-78919", 2, 1, "user19" },
                    { new Guid("8c588821-39c6-45d2-986e-938b678f39da"), "avatar11.png", new DateTime(2023, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "user11@example.com", "User 11", "+1XAkm3H0MciMPlnUyv6ww==", "123-456-78911", 2, 1, "user11" },
                    { new Guid("9429b0fb-4cc4-4ced-8f2a-6674be07ee7b"), "avatar14.png", new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "user14@example.com", "User 14", "Nbb9cBgoI2KknXYhJgRsOg==", "123-456-78914", 2, 1, "user14" },
                    { new Guid("9b5e8195-7c28-4df2-8598-822fc7a4972b"), "avatar25.png", new DateTime(2023, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "user25@example.com", "User 25", "o+65kwYOgM/H5YtlR5eBGQ==", "123-456-78925", 2, 1, "user25" },
                    { new Guid("a191351a-bdcc-4477-83e0-837015a1dee1"), "avatar29.png", new DateTime(2023, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "user29@example.com", "User 29", "ETdpo/KPinCotdzGNmsAPA==", "123-456-78929", 2, 1, "user29" },
                    { new Guid("b779275f-bd00-4f72-954e-1dbd3afcede8"), "avatar26.png", new DateTime(2023, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "user26@example.com", "User 26", "JTjto+r7kPyCkZGQtsDBOA==", "123-456-78926", 2, 1, "user26" },
                    { new Guid("ba22f94a-cf30-42b7-9c03-92ade34249bf"), "avatar2.png", new DateTime(2023, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "user2@example.com", "User 2", "gPFa6fSRCX/O3JCnJjTBBg==", "123-456-7892", 2, 1, "user2" },
                    { new Guid("d2ce2cdc-0885-4f63-ba0c-51c562dbe29f"), "avatar30.png", new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "user30@example.com", "User 30", "ZIc8EakA57j1Q7JTsakLKA==", "123-456-78930", 2, 1, "user30" },
                    { new Guid("d8052168-11e9-4d4f-beac-79e9aea8f2ec"), "avatar3.png", new DateTime(2023, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "user3@example.com", "User 3", "XZG20Zjr0RmKJ42oxCGZqQ==", "123-456-7893", 2, 1, "user3" },
                    { new Guid("de50f2f6-7649-46f1-aeba-ffe9db10426a"), "avatar28.png", new DateTime(2023, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "user28@example.com", "User 28", "R/9+ITDUv36NqhUmUxCu5w==", "123-456-78928", 2, 1, "user28" },
                    { new Guid("e6f21a23-54f1-4b22-9aba-fd8194b154f5"), "avatar24.png", new DateTime(2023, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "user24@example.com", "User 24", "wUy5uoNVQITmQW5R4nnOMA==", "123-456-78924", 2, 1, "user24" },
                    { new Guid("ebd74089-08ae-4f50-978c-f5ee3ef60ae5"), "avatar10.png", new DateTime(2023, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "user10@example.com", "User 10", "AD+DKAMne24G+bFvnB3umA==", "123-456-78910", 2, 1, "user10" },
                    { new Guid("ee946212-8379-430f-88d0-7877562c823e"), "avatar1.png", new DateTime(2023, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "user1@example.com", "User 1", "ei00xFxTj/yW/ErUUw1JvA==", "123-456-7891", 2, 1, "user1" },
                    { new Guid("f43d3c0d-a57f-413c-b14e-0e215e2328be"), "avatar9.png", new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "user9@example.com", "User 9", "XLl70iIryQx+lE/y5900Uw==", "123-456-7899", 2, 1, "user9" },
                    { new Guid("f8f8b6c7-9747-4a1c-84bf-da8bfe5b60d5"), "avatar27.png", new DateTime(2023, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "user27@example.com", "User 27", "lePABwdtIg5MqkBgyFdL9Q==", "123-456-78927", 2, 1, "user27" },
                    { new Guid("fd36705c-0610-4c30-9cfb-e5827b3f3d78"), "avatar1.png", new DateTime(2023, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "azusachan307@gmail.com", "AdminTest", "LK25tQh1RqkKbrq4C2l6fw==", "000-000-000", 1, 1, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "CinemaCenters",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[,]
                {
                    { new Guid("031ef9a3-a02b-4155-a078-6b6c9357cf01"), "Address 27", "Cinema Center 27" },
                    { new Guid("07c4e772-9a7e-42ef-a22b-c927a2047bef"), "Address 20", "Cinema Center 20" },
                    { new Guid("20e8572e-4045-4e9b-9c48-7478711ca9f7"), "Address 4", "Cinema Center 4" },
                    { new Guid("21a1015e-4ed4-4af4-a489-3334db1186e3"), "Address 12", "Cinema Center 12" },
                    { new Guid("2381bdda-4ab3-45a7-949e-b54e586ae48a"), "Address 16", "Cinema Center 16" },
                    { new Guid("2ea3d492-fc6a-48ba-8cd9-1e8cdfb46271"), "Address 25", "Cinema Center 25" },
                    { new Guid("33a99230-5120-416a-bc01-4401741de767"), "Address 21", "Cinema Center 21" },
                    { new Guid("46454bd7-6a5e-42f1-9215-141c0a11654b"), "Address 1", "Cinema Center 1" },
                    { new Guid("58bb7811-9f5a-40da-8ebc-efc59bb8df53"), "Address 13", "Cinema Center 13" },
                    { new Guid("5d24b6c2-5446-4278-8c31-72622c871dc7"), "Address 28", "Cinema Center 28" },
                    { new Guid("5e3439b9-2091-4132-aeda-99de360b7b41"), "Address 18", "Cinema Center 18" },
                    { new Guid("68b399b1-56bb-46ee-965f-f012f9b17684"), "Address 8", "Cinema Center 8" },
                    { new Guid("6fdce11f-d0fa-49ef-add6-094a237372cc"), "Address 23", "Cinema Center 23" },
                    { new Guid("6ff3b1aa-b3c1-4505-92fe-72c0b2c9ad06"), "Address 24", "Cinema Center 24" },
                    { new Guid("81b214a6-3a4a-475f-8089-8300df19099c"), "Address 5", "Cinema Center 5" },
                    { new Guid("84351fd7-5487-41fa-908c-ffebb5689ddc"), "Address 6", "Cinema Center 6" },
                    { new Guid("aa474f56-51e1-4e0f-850c-d64827e56536"), "Address 9", "Cinema Center 9" },
                    { new Guid("ac86d266-dff7-44a9-8952-70a938fc25ae"), "Address 15", "Cinema Center 15" },
                    { new Guid("af0aec34-6223-4ec7-88ef-df079059dc9d"), "Address 10", "Cinema Center 10" },
                    { new Guid("b3b351e0-8a87-405d-a12c-6d79b25810b5"), "Address 3", "Cinema Center 3" },
                    { new Guid("d12589ad-358c-4c48-bf4c-5d9d72571130"), "Address 29", "Cinema Center 29" },
                    { new Guid("d54ca520-9c70-40a4-8b88-9c87d8a5558f"), "Address 2", "Cinema Center 2" },
                    { new Guid("da1424b4-704c-48cb-8d9e-1ed264778966"), "Address 30", "Cinema Center 30" },
                    { new Guid("e304a215-e308-4b14-a489-8146ecde8dbd"), "Address 26", "Cinema Center 26" },
                    { new Guid("efce1372-4a4b-4292-8cdb-bf28deb0f808"), "Address 11", "Cinema Center 11" },
                    { new Guid("f085f15a-6aa2-4ea7-9bf2-6b271d3c36e0"), "Address 22", "Cinema Center 22" },
                    { new Guid("f150574e-e730-4b4b-8dc4-8ea023ff26d6"), "Address 14", "Cinema Center 14" },
                    { new Guid("f292361d-e382-44ce-9c79-63970daae8eb"), "Address 7", "Cinema Center 7" },
                    { new Guid("fc8c2a48-8009-478d-bd89-ea5f997b5edc"), "Address 17", "Cinema Center 17" },
                    { new Guid("ff8f338a-58b5-4fad-aea9-39423f9f264d"), "Address 19", "Cinema Center 19" }
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
                    { new Guid("0380913b-8dd3-43b4-8c70-c8ff7b1e2f9a"), "Combo 12", 20000m },
                    { new Guid("06a44a8c-cd98-4bfb-b20a-bbbcc49bcc67"), "Combo 15", 50000m },
                    { new Guid("06c9365a-3303-4b58-8fdb-9a9c290fe785"), "Combo 18", 80000m },
                    { new Guid("06d06e95-0417-4e17-a772-2450ac1994cc"), "Combo 19", 90000m },
                    { new Guid("1b4a0c9b-1e83-49c8-8786-61aabae23d77"), "Combo 2", 20000m },
                    { new Guid("2346842c-ba37-4457-8307-c7062a1e061e"), "Combo 29", 90000m },
                    { new Guid("2a388554-018b-4dbd-aae3-a1b1057ce239"), "Combo 11", 10000m },
                    { new Guid("2ad77aa9-2858-407c-9b7b-74a3899ee70e"), "Combo 16", 60000m },
                    { new Guid("3523c58f-22a0-441b-b3d2-b0d7aea58f2f"), "Combo 1", 10000m },
                    { new Guid("470fb25e-bb3f-4514-abb6-da78667cc2ca"), "Combo 13", 30000m },
                    { new Guid("496fdd5a-47d4-441f-aca1-5e753fbf0681"), "Combo 23", 30000m },
                    { new Guid("4ac2f943-8f55-4d9e-8311-71ca10902c40"), "Combo 4", 40000m },
                    { new Guid("6fb4476f-8e39-4499-b541-a656df58104f"), "Combo 9", 90000m },
                    { new Guid("72a464dc-49c2-4f7d-ac37-db2a48823900"), "Combo 17", 70000m },
                    { new Guid("806ff35e-c6a6-49ba-ad72-c1e7446cc845"), "Combo 3", 30000m },
                    { new Guid("84f35da8-deeb-4ecf-88ab-d656c6bcab5f"), "Combo 10", 0m },
                    { new Guid("8bea79e3-f2eb-4166-9716-6a6e95b65d9d"), "Combo 24", 40000m },
                    { new Guid("9c6001b0-d366-4442-adc9-41ced54490c1"), "Combo 8", 80000m },
                    { new Guid("9d0c854e-0f0d-44d2-ba16-8444b842aff4"), "Combo 7", 70000m },
                    { new Guid("a782b955-3b15-455c-bd3e-67cfd35f9059"), "Combo 21", 10000m },
                    { new Guid("abbbfec8-0d56-4ecb-ba52-fd30f783c7d2"), "Combo 5", 50000m },
                    { new Guid("acb0a090-2696-4f2e-863b-90db40a481fe"), "Combo 27", 70000m },
                    { new Guid("be163bf7-392e-4204-b96b-891a175a8169"), "Combo 14", 40000m },
                    { new Guid("c223f2b1-2ab5-49af-8c14-c365d54cf3f9"), "Combo 6", 60000m },
                    { new Guid("d6cf71f2-5c65-40e4-9df4-0ff2ba8fd6ff"), "Combo 28", 80000m },
                    { new Guid("d813835d-cc8a-45fa-9bfe-6832f3e3bcf3"), "Combo 30", 0m },
                    { new Guid("e126c0c6-3903-4f40-8dc9-b7100964b1be"), "Combo 22", 20000m },
                    { new Guid("ecd857a8-fdf2-45a0-b1b6-5b4a5c0df26a"), "Combo 20", 0m },
                    { new Guid("ed9c0e20-8fde-4979-aa4c-893f84fe76b2"), "Combo 26", 60000m },
                    { new Guid("fb5080b7-c738-47ee-8dcb-4e6b7ea70db8"), "Combo 25", 50000m }
                });

            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "Id", "Cast", "CreatDate", "Description", "Director", "EnglishName", "Gerne", "Language", "Name", "Nation", "Poster", "Rating", "ReleaseYear", "RunningTime", "ScreenTypeId", "StartDate", "Status", "Trailer", "TranslationTypeId" },
                values: new object[,]
                {
                    { new Guid("0406a43f-29f7-47b9-b8a8-940769c914a4"), "Actor 8, Actress 8", new DateTime(2023, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 8.", "Director 8", "Film 8 (English)", "Action", "English", "Film 8", "USA", "film_fake.jpg", 4, 2023, 68, new Guid("ecf93d04-a062-4048-8bfe-541e3eb3deec"), new DateTime(2023, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer8.mp4", new Guid("91943c82-c06f-4b01-9bf3-80df9a32004f") },
                    { new Guid("06cb5e0b-b38d-4faa-8308-fd95f3d72c4b"), "Actor 5, Actress 5", new DateTime(2023, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 5.", "Director 5", "Film 5 (English)", "Comedy", "Japanese", "Film 5", "Japan", "film_fake.jpg", 1, 2023, 65, new Guid("fd0d242e-14fd-4a63-92ef-fa84b6f23720"), new DateTime(2023, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer5.mp4", new Guid("b6fea136-8f78-43b5-98a0-efb0fa2802a9") },
                    { new Guid("10fd66b7-9c7f-4642-addc-8fb94282f2be"), "Actor 6, Actress 6", new DateTime(2023, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 6.", "Director 6", "Film 6 (English)", "Action", "English", "Film 6", "USA", "film_fake.jpg", 2, 2023, 66, new Guid("b74924ae-b307-42ec-90a7-23f20e4cd582"), new DateTime(2023, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer6.mp4", new Guid("5b349dfa-53e1-4be9-909a-4c786c154f4e") },
                    { new Guid("18084a35-739e-4433-a607-63e2da9a547f"), "Actor 25, Actress 25", new DateTime(2023, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 25.", "Director 25", "Film 25 (English)", "Comedy", "Japanese", "Film 25", "Japan", "film_fake.jpg", 1, 2023, 85, new Guid("341d28ea-7433-4668-adcd-27debc6d6f58"), new DateTime(2023, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer25.mp4", new Guid("c7a88694-1ef1-4ecf-b34e-8f52aabb003c") },
                    { new Guid("1f835672-6eae-4107-aac0-7358094a1d49"), "Actor 19, Actress 19", new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 19.", "Director 19", "Film 19 (English)", "Comedy", "Japanese", "Film 19", "Japan", "film_fake.jpg", 5, 2023, 79, new Guid("e94d26c2-9195-4005-aa6f-6bf83afa3dd4"), new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer19.mp4", new Guid("987a2db5-6a4c-4164-b611-b59a456368bc") },
                    { new Guid("24b83f6a-0643-4774-8417-5c15839ba9e8"), "Actor 21, Actress 21", new DateTime(2023, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 21.", "Director 21", "Film 21 (English)", "Comedy", "Japanese", "Film 21", "Japan", "film_fake.jpg", 2, 2023, 81, new Guid("f2dc871b-9adf-41b4-94e8-96356e0394c8"), new DateTime(2023, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer21.mp4", new Guid("e8c81702-bbc7-4303-8e0c-aaeacf01b847") },
                    { new Guid("2b05b649-a5f5-4e13-9015-b84836a88805"), "Actor 28, Actress 28", new DateTime(2023, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 28.", "Director 28", "Film 28 (English)", "Action", "English", "Film 28", "USA", "film_fake.jpg", 4, 2023, 88, new Guid("9c67cd76-8390-48f6-ac63-a4c655899796"), new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer28.mp4", new Guid("2154d3c8-0db1-4db9-b476-7877b75b320f") },
                    { new Guid("2c9d3e45-76e6-4ed8-a3c2-02b054c3173a"), "Actor 20, Actress 20", new DateTime(2023, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 20.", "Director 20", "Film 20 (English)", "Action", "English", "Film 20", "USA", "film_fake.jpg", 1, 2023, 80, new Guid("a2631297-8d82-4cf1-9066-85967d09873e"), new DateTime(2023, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer20.mp4", new Guid("5be349a3-5a92-4d5b-a8b7-937048fc30fc") },
                    { new Guid("3e88711f-ad16-4bdf-b476-bf8cdd791012"), "Actor 2, Actress 2", new DateTime(2023, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 2.", "Director 2", "Film 2 (English)", "Action", "English", "Film 2", "USA", "film_fake.jpg", 3, 2023, 62, new Guid("dff29918-6e4b-42c8-aca8-bcf168cfb46e"), new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer2.mp4", new Guid("452213f2-ac1e-45c6-9f4c-bbd84015c865") },
                    { new Guid("3ff63242-1758-467a-9d65-5561812a46fe"), "Actor 27, Actress 27", new DateTime(2023, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 27.", "Director 27", "Film 27 (English)", "Comedy", "Japanese", "Film 27", "Japan", "film_fake.jpg", 3, 2023, 87, new Guid("b5f1a276-7915-46a8-b16c-e7583a5837d6"), new DateTime(2023, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer27.mp4", new Guid("fb84332e-9b17-4bbc-931c-698e315d03b0") },
                    { new Guid("4b27a070-162c-4a44-9897-1785247031c4"), "Actor 23, Actress 23", new DateTime(2023, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 23.", "Director 23", "Film 23 (English)", "Comedy", "Japanese", "Film 23", "Japan", "film_fake.jpg", 4, 2023, 83, new Guid("dcc396a9-3659-49f9-b4a5-0bbb5ce3cfc9"), new DateTime(2023, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer23.mp4", new Guid("f22b4d7f-3278-40ce-8391-54f5c9d948b8") },
                    { new Guid("4ffa15f4-caeb-4c8a-9ad3-af3b61f34968"), "Actor 3, Actress 3", new DateTime(2023, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 3.", "Director 3", "Film 3 (English)", "Comedy", "Japanese", "Film 3", "Japan", "film_fake.jpg", 4, 2023, 63, new Guid("33a88223-80af-467d-a98b-7486c97aaca9"), new DateTime(2023, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer3.mp4", new Guid("f555b494-2f22-4347-822b-3d2b78c15491") },
                    { new Guid("58184807-19e7-42d1-a849-3e7bd1dbb3ed"), "Actor 24, Actress 24", new DateTime(2023, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 24.", "Director 24", "Film 24 (English)", "Action", "English", "Film 24", "USA", "film_fake.jpg", 5, 2023, 84, new Guid("2bfb87b4-aaed-46bf-8698-3e58994d4ef1"), new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer24.mp4", new Guid("234c90d7-288f-4fc3-a0b7-931f72d52cf9") },
                    { new Guid("5cc78365-f76c-4a70-a42d-410d20c9517e"), "Actor 30, Actress 30", new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 30.", "Director 30", "Film 30 (English)", "Action", "English", "Film 30", "USA", "film_fake.jpg", 1, 2023, 90, new Guid("48da0f25-5e2b-474f-9368-c89ef582ef9a"), new DateTime(2023, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer30.mp4", new Guid("e982baa5-8d4f-46e0-8683-69548b6f3530") },
                    { new Guid("635a12ab-d8de-4070-9c72-0d941fa2b254"), "Actor 16, Actress 16", new DateTime(2023, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 16.", "Director 16", "Film 16 (English)", "Action", "English", "Film 16", "USA", "film_fake.jpg", 2, 2023, 76, new Guid("92af9306-3455-482b-ad98-68c75a9bffb0"), new DateTime(2023, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer16.mp4", new Guid("b6c5477c-3445-4986-864b-4ed948fa43ec") },
                    { new Guid("7029112f-6421-45de-8443-0ba9f61162ad"), "Actor 10, Actress 10", new DateTime(2023, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 10.", "Director 10", "Film 10 (English)", "Action", "English", "Film 10", "USA", "film_fake.jpg", 1, 2023, 70, new Guid("d9706a1e-4547-4358-a2e2-d077ee27c22e"), new DateTime(2023, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer10.mp4", new Guid("27cfb235-1719-46a1-bc3d-922bb3c45484") },
                    { new Guid("70ae0a17-99f3-41dd-a509-0eee0f902f4d"), "Actor 11, Actress 11", new DateTime(2023, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 11.", "Director 11", "Film 11 (English)", "Comedy", "Japanese", "Film 11", "Japan", "film_fake.jpg", 2, 2023, 71, new Guid("af762c29-7b33-428a-ba0f-ba774eccbec7"), new DateTime(2023, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer11.mp4", new Guid("265f995a-7822-4fe7-bdfd-b12d0c4f5122") },
                    { new Guid("715a1729-4f02-4bbd-968d-50d7dd60a34a"), "Actor 14, Actress 14", new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 14.", "Director 14", "Film 14 (English)", "Action", "English", "Film 14", "USA", "film_fake.jpg", 5, 2023, 74, new Guid("197a0c6a-e87a-4d0a-865a-cd2b97d144c4"), new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer14.mp4", new Guid("4eb405c6-068b-4b4d-8f73-25e5fa0b708d") },
                    { new Guid("7560a439-9367-4c21-b74b-b83361bcd79d"), "Actor 18, Actress 18", new DateTime(2023, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 18.", "Director 18", "Film 18 (English)", "Action", "English", "Film 18", "USA", "film_fake.jpg", 4, 2023, 78, new Guid("eef10e4d-d4b8-4ae8-b742-374e152709a6"), new DateTime(2023, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer18.mp4", new Guid("6e3ca7fb-f5d9-4e26-a2c7-3fa8809fcffa") },
                    { new Guid("99426faf-3b24-44fd-8f18-f2a906f067db"), "Actor 15, Actress 15", new DateTime(2023, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 15.", "Director 15", "Film 15 (English)", "Comedy", "Japanese", "Film 15", "Japan", "film_fake.jpg", 1, 2023, 75, new Guid("95b9cb80-aea7-43f7-b4e6-af84202d900b"), new DateTime(2023, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer15.mp4", new Guid("ec31fac9-ddd8-4ddb-bce5-03d191da9db7") },
                    { new Guid("aebeecda-4b25-4dd4-8a3f-97ef9632e7b2"), "Actor 12, Actress 12", new DateTime(2023, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 12.", "Director 12", "Film 12 (English)", "Action", "English", "Film 12", "USA", "film_fake.jpg", 3, 2023, 72, new Guid("8bf5cf72-f49d-4967-92cd-7ce5760649f7"), new DateTime(2023, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer12.mp4", new Guid("75cdbe64-c1be-4194-844c-a60e459c2ea0") },
                    { new Guid("cc1b079c-e341-464c-a631-7023727476cc"), "Actor 22, Actress 22", new DateTime(2023, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 22.", "Director 22", "Film 22 (English)", "Action", "English", "Film 22", "USA", "film_fake.jpg", 3, 2023, 82, new Guid("957dc7d4-ab07-4e96-9b9b-80da6e52045c"), new DateTime(2023, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer22.mp4", new Guid("81794814-c6c6-430d-9d6c-e83ffac0b745") },
                    { new Guid("d4f21ac7-7ec3-4363-a162-308797be55ec"), "Actor 13, Actress 13", new DateTime(2023, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 13.", "Director 13", "Film 13 (English)", "Comedy", "Japanese", "Film 13", "Japan", "film_fake.jpg", 4, 2023, 73, new Guid("484c9c26-64df-4079-80e2-811b30a30ce5"), new DateTime(2023, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer13.mp4", new Guid("05e713c3-5bc2-4114-9a7b-d1888f933395") },
                    { new Guid("e03ad928-22d1-405b-bad0-ed388b99eb72"), "Actor 9, Actress 9", new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 9.", "Director 9", "Film 9 (English)", "Comedy", "Japanese", "Film 9", "Japan", "film_fake.jpg", 5, 2023, 69, new Guid("9a86eee8-cc8f-4138-8ebf-44ea754b8e79"), new DateTime(2023, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer9.mp4", new Guid("203d84e2-8699-47f2-8c9b-dea4167e8be2") },
                    { new Guid("e0e1fc50-7ff9-4334-80c6-94afbd0bd4c8"), "Actor 4, Actress 4", new DateTime(2023, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 4.", "Director 4", "Film 4 (English)", "Action", "English", "Film 4", "USA", "film_fake.jpg", 5, 2023, 64, new Guid("fc19f429-eeb5-4e0f-84c3-f699a1cb4554"), new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer4.mp4", new Guid("bbd94cb0-5699-43eb-aa62-6fd6d2a29dbc") },
                    { new Guid("e275734b-3205-4f25-bfad-e59a74155799"), "Actor 1, Actress 1", new DateTime(2023, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 1.", "Director 1", "Film 1 (English)", "Comedy", "Japanese", "Film 1", "Japan", "film_fake.jpg", 2, 2023, 61, new Guid("ea16e599-997b-47f5-b5e2-149d70c03751"), new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer1.mp4", new Guid("12987801-1308-4282-aade-fbe1af49c0dc") },
                    { new Guid("e28077f1-f18d-49af-b2ec-6898f4f5cfab"), "Actor 26, Actress 26", new DateTime(2023, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 26.", "Director 26", "Film 26 (English)", "Action", "English", "Film 26", "USA", "film_fake.jpg", 2, 2023, 86, new Guid("9ce7470c-d2ab-458c-bf67-57c4b6b4c4d1"), new DateTime(2023, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer26.mp4", new Guid("b7b6e341-4b9f-4dd9-8ea1-b7e2195aa6cd") },
                    { new Guid("e7f701b9-a37a-483a-a630-8714d4941d1e"), "Actor 29, Actress 29", new DateTime(2023, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 29.", "Director 29", "Film 29 (English)", "Comedy", "Japanese", "Film 29", "Japan", "film_fake.jpg", 5, 2023, 89, new Guid("08a72297-1bae-490b-b6c7-7f259510b1f3"), new DateTime(2023, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer29.mp4", new Guid("37ddd7c9-f160-4c1d-8008-16c1f6b940fc") },
                    { new Guid("e899b936-08c5-44e6-915d-bf982858dd84"), "Actor 17, Actress 17", new DateTime(2023, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 17.", "Director 17", "Film 17 (English)", "Comedy", "Japanese", "Film 17", "Japan", "film_fake.jpg", 3, 2023, 77, new Guid("d5a14212-e8e3-450d-a961-f768647a3081"), new DateTime(2023, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer17.mp4", new Guid("ce5f8469-a58c-4d2b-ba9c-7ab3a95f1eca") },
                    { new Guid("f78386e9-43d2-4d34-ba23-ef420746a1db"), "Actor 7, Actress 7", new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for Film 7.", "Director 7", "Film 7 (English)", "Comedy", "Japanese", "Film 7", "Japan", "film_fake.jpg", 3, 2023, 67, new Guid("3746f13a-116c-4d05-bb51-d207b7b873fa"), new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://example.com/trailer7.mp4", new Guid("cedbadb0-251d-4f47-9182-492c6339346c") }
                });

            migrationBuilder.InsertData(
                table: "Promotions",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("037d5fc2-f721-4ada-b9e2-d0af85569bcb"), "Title 4" },
                    { new Guid("0eda49d5-4570-44e0-b8e5-30327659df76"), "Title 24" },
                    { new Guid("19d348c8-6116-4b48-a341-3c3e02379d57"), "Title 25" },
                    { new Guid("267b16eb-6418-4789-8c32-2c84ca7fc174"), "Title 28" },
                    { new Guid("2ba82b43-804a-4743-92ad-8d2e3eeb9228"), "Title 6" },
                    { new Guid("45421425-adb2-4ae4-ba93-c55047d102f8"), "Title 23" },
                    { new Guid("4f671bfb-c7a3-4f29-b7fe-12ba080067cb"), "Title 2" },
                    { new Guid("55934c66-f591-4c27-b11e-fb4676b5b59e"), "Title 15" },
                    { new Guid("5797f179-5ece-4361-ae15-21c52df98c9b"), "Title 30" },
                    { new Guid("5bdeb79a-93d4-4677-bea1-1da6a9f8311e"), "Title 7" },
                    { new Guid("5e0e95bc-b5e5-4f77-86c1-0016e240dea7"), "Title 9" },
                    { new Guid("600d9f16-2c44-468a-a7c3-fd6835d8c15d"), "Title 29" },
                    { new Guid("71b1b2f7-9b69-4353-8512-04c64253b1fd"), "Title 8" },
                    { new Guid("7adcb970-de84-456f-afdb-c26b739989a5"), "Title 16" },
                    { new Guid("7b97feec-eb9b-4bc2-9cae-781873d843a3"), "Title 20" },
                    { new Guid("807667fe-bd16-4d67-8bd0-1cd280cb071c"), "Title 18" },
                    { new Guid("82a4b39d-55b2-4636-84f3-aa7b75e051de"), "Title 14" },
                    { new Guid("83c820f9-4479-448e-9a6d-1be048ebeb5d"), "Title 26" },
                    { new Guid("843149ba-37ae-4178-ad18-a427b70e156c"), "Title 5" },
                    { new Guid("89c52c1d-b403-49bc-877c-1bb1e8915937"), "Title 21" },
                    { new Guid("8a60d43f-48d9-4973-90ee-336f5aa15301"), "Title 22" },
                    { new Guid("a1505831-dcc5-4305-b5fd-03b22b5ebfdd"), "Title 27" },
                    { new Guid("adfcfef5-45c3-4915-9207-96f26ed3004b"), "Title 19" },
                    { new Guid("b297f640-3008-4daf-8c28-8d92fe8bc3ac"), "Title 11" },
                    { new Guid("b8767294-230c-4653-a934-ae96442c660a"), "Title 10" },
                    { new Guid("c0470636-052c-4516-975e-b402df714571"), "Title 13" },
                    { new Guid("c31312f6-61f5-4cad-9938-73efad1832cc"), "Title 3" },
                    { new Guid("ccc08ed5-c54b-4c8e-8432-b149e797a5a6"), "Title 1" },
                    { new Guid("d45646cf-804a-4dc7-beca-19f531c2607c"), "Title 12" },
                    { new Guid("d90f06a7-08e2-4030-9d21-7b24b25a0d7d"), "Title 17" }
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
                    { new Guid("0322e843-d775-4192-bf65-7265d1d99e37"), new Guid("e304a215-e308-4b14-a489-8146ecde8dbd"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 10, "Description for Cinema 26", 100, "Cinema 26", 10 },
                    { new Guid("1395a43b-dda6-4c0c-80e9-67c58f72acfa"), new Guid("58bb7811-9f5a-40da-8ebc-efc59bb8df53"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 10, "Description for Cinema 13", 100, "Cinema 13", 10 },
                    { new Guid("16197418-f61e-471c-8730-02ed9f116d8e"), new Guid("af0aec34-6223-4ec7-88ef-df079059dc9d"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 10, "Description for Cinema 10", 100, "Cinema 10", 10 },
                    { new Guid("2070eb43-99de-4601-9e66-767a6bcf636c"), new Guid("b3b351e0-8a87-405d-a12c-6d79b25810b5"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 10, "Description for Cinema 3", 100, "Cinema 3", 10 },
                    { new Guid("3ecc1c7b-7f1b-4465-8b22-0cc336795231"), new Guid("5e3439b9-2091-4132-aeda-99de360b7b41"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 10, "Description for Cinema 18", 100, "Cinema 18", 10 },
                    { new Guid("41208f1e-84e4-470c-9bab-4484bce2e1fb"), new Guid("d54ca520-9c70-40a4-8b88-9c87d8a5558f"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 10, "Description for Cinema 2", 100, "Cinema 2", 10 },
                    { new Guid("41c41f65-f9bb-4976-a110-292a3cef72c8"), new Guid("2381bdda-4ab3-45a7-949e-b54e586ae48a"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 10, "Description for Cinema 16", 100, "Cinema 16", 10 },
                    { new Guid("46667323-a6ba-4e39-b117-52d2377b6ec5"), new Guid("2ea3d492-fc6a-48ba-8cd9-1e8cdfb46271"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 10, "Description for Cinema 25", 100, "Cinema 25", 10 },
                    { new Guid("4b86245d-a01d-4eaf-b552-0f345580cbbb"), new Guid("f292361d-e382-44ce-9c79-63970daae8eb"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 10, "Description for Cinema 7", 100, "Cinema 7", 10 },
                    { new Guid("4b90406b-b203-40e9-ae93-c36344072697"), new Guid("81b214a6-3a4a-475f-8089-8300df19099c"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 10, "Description for Cinema 5", 100, "Cinema 5", 10 },
                    { new Guid("6aea3387-a9b2-4bd1-828f-ed56b361d5e5"), new Guid("efce1372-4a4b-4292-8cdb-bf28deb0f808"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 10, "Description for Cinema 11", 100, "Cinema 11", 10 },
                    { new Guid("6ba8b0fd-9cad-4667-8be9-d69503c79f1d"), new Guid("031ef9a3-a02b-4155-a078-6b6c9357cf01"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 10, "Description for Cinema 27", 100, "Cinema 27", 10 },
                    { new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), new Guid("46454bd7-6a5e-42f1-9215-141c0a11654b"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 10, "Description for Cinema 1", 100, "Cinema 1", 10 },
                    { new Guid("76c3943a-ba0f-4cad-bd8c-f4d65c6fa831"), new Guid("21a1015e-4ed4-4af4-a489-3334db1186e3"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 10, "Description for Cinema 12", 100, "Cinema 12", 10 },
                    { new Guid("8a15de72-34c5-4c10-bb55-ffea277b3f52"), new Guid("6fdce11f-d0fa-49ef-add6-094a237372cc"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 10, "Description for Cinema 23", 100, "Cinema 23", 10 },
                    { new Guid("98a494cb-93e3-48df-9306-2117a699e750"), new Guid("07c4e772-9a7e-42ef-a22b-c927a2047bef"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 10, "Description for Cinema 20", 100, "Cinema 20", 10 },
                    { new Guid("a16a0117-e6dc-4e6e-adf6-c7c62a6363bc"), new Guid("5d24b6c2-5446-4278-8c31-72622c871dc7"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 10, "Description for Cinema 28", 100, "Cinema 28", 10 },
                    { new Guid("ad5ed4d0-77ca-4f76-8a89-582533e6aba6"), new Guid("fc8c2a48-8009-478d-bd89-ea5f997b5edc"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 10, "Description for Cinema 17", 100, "Cinema 17", 10 },
                    { new Guid("ae0305f2-01c1-44e2-a0ba-160ba7fc9d01"), new Guid("84351fd7-5487-41fa-908c-ffebb5689ddc"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 10, "Description for Cinema 6", 100, "Cinema 6", 10 },
                    { new Guid("ae7a6d1b-301f-426a-bd8e-f63ff98f78b6"), new Guid("da1424b4-704c-48cb-8d9e-1ed264778966"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 10, "Description for Cinema 30", 100, "Cinema 30", 10 },
                    { new Guid("aede5615-0530-45c1-a60b-5896ec6da0b8"), new Guid("ff8f338a-58b5-4fad-aea9-39423f9f264d"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 10, "Description for Cinema 19", 100, "Cinema 19", 10 },
                    { new Guid("b56a0639-71b4-4352-98b1-fd8570e53ebd"), new Guid("f150574e-e730-4b4b-8dc4-8ea023ff26d6"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 10, "Description for Cinema 14", 100, "Cinema 14", 10 },
                    { new Guid("bd7a075c-216b-4505-855f-d49cc3d6ee2f"), new Guid("6ff3b1aa-b3c1-4505-92fe-72c0b2c9ad06"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 10, "Description for Cinema 24", 100, "Cinema 24", 10 },
                    { new Guid("ca2a3430-9d0f-4af6-8684-2d721b747515"), new Guid("ac86d266-dff7-44a9-8952-70a938fc25ae"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 10, "Description for Cinema 15", 100, "Cinema 15", 10 },
                    { new Guid("ccf01534-6d68-450b-91b1-14ef8d9c4b15"), new Guid("20e8572e-4045-4e9b-9c48-7478711ca9f7"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 10, "Description for Cinema 4", 100, "Cinema 4", 10 },
                    { new Guid("dd16d30b-8ae3-4ac0-bdaa-b02c320dd238"), new Guid("f085f15a-6aa2-4ea7-9bf2-6b271d3c36e0"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 10, "Description for Cinema 22", 100, "Cinema 22", 10 },
                    { new Guid("df0edc1d-d26b-46b9-ad7d-03a2a4a39890"), new Guid("68b399b1-56bb-46ee-965f-f012f9b17684"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 10, "Description for Cinema 8", 100, "Cinema 8", 10 },
                    { new Guid("f1ec4e5b-6072-4e9d-9c48-ef93419736da"), new Guid("d12589ad-358c-4c48-bf4c-5d9d72571130"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 10, "Description for Cinema 29", 100, "Cinema 29", 10 },
                    { new Guid("f4727936-dc2f-45f4-8b1b-557b445638d7"), new Guid("33a99230-5120-416a-bc01-4401741de767"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 10, "Description for Cinema 21", 100, "Cinema 21", 10 },
                    { new Guid("fdc23e86-a00b-4084-87ea-7c9afb4ec170"), new Guid("aa474f56-51e1-4e0f-850c-d64827e56536"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 10, "Description for Cinema 9", 100, "Cinema 9", 10 }
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
                    { new Guid("12ee505b-b640-4798-a3e3-240141f1b119"), new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0406a43f-29f7-47b9-b8a8-940769c914a4"), new DateTime(2023, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { new Guid("14291a65-5bac-42c5-b7f7-95126b580cf9"), new DateTime(2023, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("635a12ab-d8de-4070-9c72-0d941fa2b254"), new DateTime(2023, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { new Guid("21e88854-167d-4a59-b0c7-779420b40349"), new DateTime(2023, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e28077f1-f18d-49af-b2ec-6898f4f5cfab"), new DateTime(2023, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { new Guid("26b4666c-3c7a-4a68-94cd-eb5f5646d719"), new DateTime(2023, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e0e1fc50-7ff9-4334-80c6-94afbd0bd4c8"), new DateTime(2023, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { new Guid("331e1597-ccfc-4aeb-b40f-0bdcdde387a5"), new DateTime(2023, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("1f835672-6eae-4107-aac0-7358094a1d49"), new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { new Guid("37012426-4d90-4e9d-bdb6-dcbd47f31745"), new DateTime(2023, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("715a1729-4f02-4bbd-968d-50d7dd60a34a"), new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { new Guid("3e14846e-c52a-41c0-825b-3f18c4b01a37"), new DateTime(2023, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e899b936-08c5-44e6-915d-bf982858dd84"), new DateTime(2023, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { new Guid("44a49862-2563-4e16-add4-193a6972d0c7"), new DateTime(2023, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2b05b649-a5f5-4e13-9015-b84836a88805"), new DateTime(2023, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { new Guid("459cd0ed-c8b5-42ff-bbb5-1d762b72688b"), new DateTime(2023, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("06cb5e0b-b38d-4faa-8308-fd95f3d72c4b"), new DateTime(2023, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { new Guid("61833f4f-a817-4395-8245-e7f5e4d2aacd"), new DateTime(2023, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("58184807-19e7-42d1-a849-3e7bd1dbb3ed"), new DateTime(2023, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { new Guid("6e926898-353d-4591-962c-c7fc788cdf6c"), new DateTime(2023, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("70ae0a17-99f3-41dd-a509-0eee0f902f4d"), new DateTime(2023, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { new Guid("736a84c8-651e-4e47-8379-8246a0bca4d9"), new DateTime(2023, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e275734b-3205-4f25-bfad-e59a74155799"), new DateTime(2023, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { new Guid("73cccbf0-5cf3-4b94-9f26-9abf85fabb34"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5cc78365-f76c-4a70-a42d-410d20c9517e"), new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { new Guid("77b77b7f-142e-431e-acdb-a7752931b525"), new DateTime(2023, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4ffa15f4-caeb-4c8a-9ad3-af3b61f34968"), new DateTime(2023, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { new Guid("7cf9cb82-90d2-4b64-877d-8e0fa2b1df8a"), new DateTime(2023, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2c9d3e45-76e6-4ed8-a3c2-02b054c3173a"), new DateTime(2023, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { new Guid("7d63a82f-8374-4f67-b726-11f945653431"), new DateTime(2023, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e03ad928-22d1-405b-bad0-ed388b99eb72"), new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { new Guid("a94cf825-3cea-4187-9266-2db32a0bf417"), new DateTime(2023, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("24b83f6a-0643-4774-8417-5c15839ba9e8"), new DateTime(2023, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { new Guid("afa8bad5-939d-4583-880e-e206563959bd"), new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d4f21ac7-7ec3-4363-a162-308797be55ec"), new DateTime(2023, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { new Guid("bae22ba8-8452-4275-b8b3-67bc9740d559"), new DateTime(2023, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3ff63242-1758-467a-9d65-5561812a46fe"), new DateTime(2023, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { new Guid("be707d99-4a42-4217-adeb-d0b7c0615286"), new DateTime(2023, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7029112f-6421-45de-8443-0ba9f61162ad"), new DateTime(2023, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { new Guid("c57e17a4-1692-45a9-9219-f56eb05d275e"), new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7560a439-9367-4c21-b74b-b83361bcd79d"), new DateTime(2023, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { new Guid("c95d4676-0025-4201-b905-b9ce6f30c53f"), new DateTime(2023, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("18084a35-739e-4433-a607-63e2da9a547f"), new DateTime(2023, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { new Guid("c9ac632e-a699-4907-a6fd-e32cccbfe957"), new DateTime(2023, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4b27a070-162c-4a44-9897-1785247031c4"), new DateTime(2023, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { new Guid("db2feb1c-65f5-42ef-b5a6-eebf4aa0349c"), new DateTime(2023, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e88711f-ad16-4bdf-b476-bf8cdd791012"), new DateTime(2023, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { new Guid("e36cad6f-9226-44ac-9015-178b0c1fad3b"), new DateTime(2023, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("99426faf-3b24-44fd-8f18-f2a906f067db"), new DateTime(2023, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { new Guid("e793723a-d50a-49ab-8539-ce704702506a"), new DateTime(2023, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("cc1b079c-e341-464c-a631-7023727476cc"), new DateTime(2023, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { new Guid("ebe87901-6b7b-42e3-ab93-455802928d43"), new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("10fd66b7-9c7f-4642-addc-8fb94282f2be"), new DateTime(2023, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { new Guid("ec7bdee1-45e7-4662-9514-2f4b3d37f036"), new DateTime(2023, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("aebeecda-4b25-4dd4-8a3f-97ef9632e7b2"), new DateTime(2023, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { new Guid("f1ceb272-5632-492c-aa2f-a752dc4ed30b"), new DateTime(2023, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f78386e9-43d2-4d34-ba23-ef420746a1db"), new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { new Guid("fa86c932-4d2b-40d2-8168-c9da827905ba"), new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e7f701b9-a37a-483a-a630-8714d4941d1e"), new DateTime(2023, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "TicketPrices",
                columns: new[] { "Id", "CinemaTypeId", "Price", "ScreenTypeId", "ScreeningDayId", "SeatTypeId", "Status" },
                values: new object[,]
                {
                    { new Guid("06dde27e-4c53-4576-8049-2d4cda77ca14"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 0m, new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new Guid("e4f8f494-4e25-4966-806a-7b8843d79b6b"), new Guid("d997b27a-ddb7-4ad1-a1cd-c2bd00c50cb9"), 1 },
                    { new Guid("0812e290-f087-4229-88de-6f66ad7d2821"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 60000m, new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new Guid("e4f8f494-4e25-4966-806a-7b8843d79b6b"), new Guid("d997b27a-ddb7-4ad1-a1cd-c2bd00c50cb9"), 1 },
                    { new Guid("10db47fb-a1e2-41ec-9ac3-e2191c432084"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 70000m, new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new Guid("e4f8f494-4e25-4966-806a-7b8843d79b6b"), new Guid("428edc6b-0862-4623-b038-ac505fd554bc"), 1 },
                    { new Guid("14af9293-cd58-4c91-bd5f-3b2d0feb9771"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 50000m, new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new Guid("e4f8f494-4e25-4966-806a-7b8843d79b6b"), new Guid("d997b27a-ddb7-4ad1-a1cd-c2bd00c50cb9"), 1 },
                    { new Guid("1d3826ee-113b-413f-b887-115138ac3e23"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 30000m, new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("d997b27a-ddb7-4ad1-a1cd-c2bd00c50cb9"), 1 },
                    { new Guid("1d897c6d-d50b-470c-9e93-4925b33d80ba"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 40000m, new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("20b7e1d0-fe6d-4d15-8121-1c53ebd087fd"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 60000m, new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new Guid("e4f8f494-4e25-4966-806a-7b8843d79b6b"), new Guid("428edc6b-0862-4623-b038-ac505fd554bc"), 1 },
                    { new Guid("2850a2e1-3b8c-4d51-a505-9a72ef304109"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 20000m, new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("428edc6b-0862-4623-b038-ac505fd554bc"), 1 },
                    { new Guid("2fd89eab-e2fa-4683-b4af-9b416037c925"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 50000m, new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("31608c71-0a25-4e49-8774-eb6b2df5302c"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 20000m, new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new Guid("d51bee9b-54c3-4a3c-a06a-7c3940852f57"), new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("3585a9ba-e4f6-4779-90e1-f55101f22e76"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 10000m, new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("428edc6b-0862-4623-b038-ac505fd554bc"), 1 },
                    { new Guid("5933772a-41de-4a06-92a3-a9edd33c04d4"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 30000m, new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new Guid("d51bee9b-54c3-4a3c-a06a-7c3940852f57"), new Guid("d997b27a-ddb7-4ad1-a1cd-c2bd00c50cb9"), 1 },
                    { new Guid("6fe0c2c8-fb01-4502-b049-4cbca1ae7018"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 50000m, new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("d997b27a-ddb7-4ad1-a1cd-c2bd00c50cb9"), 1 },
                    { new Guid("711a624b-8e54-4fac-bf17-17a6e84f9710"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 40000m, new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("85ad9e2e-f04a-4bf1-b5c9-b88e92d37c76"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 0m, new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new Guid("d51bee9b-54c3-4a3c-a06a-7c3940852f57"), new Guid("d997b27a-ddb7-4ad1-a1cd-c2bd00c50cb9"), 1 },
                    { new Guid("8a50a132-0fef-410e-800f-529553fd3840"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 40000m, new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("428edc6b-0862-4623-b038-ac505fd554bc"), 1 },
                    { new Guid("8e961cc5-e760-46b4-8cd8-1ee2ab1db2cc"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 60000m, new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("428edc6b-0862-4623-b038-ac505fd554bc"), 1 },
                    { new Guid("9063c706-a57a-4635-a610-64601a0014f0"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 80000m, new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("428edc6b-0862-4623-b038-ac505fd554bc"), 1 },
                    { new Guid("9102dda5-c7f2-407a-aa3c-9dea1e4e7939"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 90000m, new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new Guid("e4f8f494-4e25-4966-806a-7b8843d79b6b"), new Guid("428edc6b-0862-4623-b038-ac505fd554bc"), 1 },
                    { new Guid("9c449a73-638c-4889-ba2e-3a2a7b947aec"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 80000m, new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("428edc6b-0862-4623-b038-ac505fd554bc"), 1 },
                    { new Guid("a718b6d6-1d1b-4bdb-8fe9-35258499d080"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 30000m, new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new Guid("e4f8f494-4e25-4966-806a-7b8843d79b6b"), new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("ac61be35-55c6-400b-a83b-fa1726eb4163"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 90000m, new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("c138961d-4fe3-4a99-b1f7-96683dbda815"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 90000m, new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new Guid("e4f8f494-4e25-4966-806a-7b8843d79b6b"), new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("c798a69d-39af-4cec-94a5-ce88177c6e5e"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 70000m, new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new Guid("e4f8f494-4e25-4966-806a-7b8843d79b6b"), new Guid("d997b27a-ddb7-4ad1-a1cd-c2bd00c50cb9"), 1 },
                    { new Guid("c80d7766-3575-4c60-ae0b-81dd880b8c4f"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 80000m, new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new Guid("d51bee9b-54c3-4a3c-a06a-7c3940852f57"), new Guid("428edc6b-0862-4623-b038-ac505fd554bc"), 1 },
                    { new Guid("c958a3e9-6933-4e25-9689-42ee08db9b6a"), new Guid("e85df49a-e99d-4727-917f-28ca67bf33ec"), 70000m, new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), new Guid("d51bee9b-54c3-4a3c-a06a-7c3940852f57"), new Guid("428edc6b-0862-4623-b038-ac505fd554bc"), 1 },
                    { new Guid("ca683ef4-74b4-466e-9743-ede4b5cdd04f"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 10000m, new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new Guid("e4f8f494-4e25-4966-806a-7b8843d79b6b"), new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("e101b9ea-7d7f-417d-b1e4-fb6e665df30a"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 10000m, new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new Guid("7136ed84-69f4-46dc-a784-857bb2c91c42"), new Guid("d997b27a-ddb7-4ad1-a1cd-c2bd00c50cb9"), 1 },
                    { new Guid("f7df388e-9fb5-45ac-89de-bf98ed7b99ba"), new Guid("03846649-c852-443c-9f5c-f935343318d5"), 20000m, new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), new Guid("d51bee9b-54c3-4a3c-a06a-7c3940852f57"), new Guid("428edc6b-0862-4623-b038-ac505fd554bc"), 1 },
                    { new Guid("f9c1c649-4e02-402a-8690-e90adc04a6df"), new Guid("fbe455d5-c40e-432e-9b28-edac59f7e481"), 0m, new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), new Guid("e4f8f494-4e25-4966-806a-7b8843d79b6b"), new Guid("d997b27a-ddb7-4ad1-a1cd-c2bd00c50cb9"), 1 }
                });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "Id", "ActivationStatus", "BarCode", "CreateTime", "MembershipId", "Status", "TotalMoney", "VoucherId" },
                values: new object[,]
                {
                    { new Guid("0e5fc47a-825f-4f4a-ab26-58015a312ee6"), true, "barcode4.jpg", new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 40000m, null },
                    { new Guid("0f9774b5-1ab8-4a16-8dc7-d6bdeed36981"), true, "barcode9.jpg", new DateTime(2024, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 90000m, null },
                    { new Guid("1c914ec9-94e6-49ba-b485-cd7ba608dc5f"), true, "barcode24.jpg", new DateTime(2024, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 40000m, null },
                    { new Guid("298df334-6234-4226-a4f1-5c69ab01e09d"), true, "barcode23.jpg", new DateTime(2024, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 30000m, null },
                    { new Guid("2c3d0b61-a5c0-4e43-b7a2-a1a797582f1c"), true, "barcode15.jpg", new DateTime(2024, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 50000m, null },
                    { new Guid("344c3158-13dc-4199-9291-50fccd8c7d11"), true, "barcode5.jpg", new DateTime(2024, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 50000m, null },
                    { new Guid("3c71499a-4c1b-43f1-bf93-287df90065cb"), true, "barcode16.jpg", new DateTime(2024, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 60000m, null },
                    { new Guid("4394a155-fc7d-40f5-8ee4-4ee8b4f1073c"), true, "barcode22.jpg", new DateTime(2024, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 20000m, null },
                    { new Guid("54232ea1-606d-49c2-a98d-f805ead8e9c3"), true, "barcode27.jpg", new DateTime(2024, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 70000m, null },
                    { new Guid("5bc19ef4-5617-4285-9457-0a744f1eb39f"), true, "barcode10.jpg", new DateTime(2024, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 0m, null },
                    { new Guid("5d9ba538-60f0-47d9-8199-7d4859b6a740"), true, "barcode29.jpg", new DateTime(2024, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 90000m, null },
                    { new Guid("5da5f624-37d6-47a6-8741-f67387d3343f"), true, "barcode13.jpg", new DateTime(2024, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 30000m, null },
                    { new Guid("68cc8a04-f972-4064-9ea3-c002580b75ea"), true, "barcode19.jpg", new DateTime(2024, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 90000m, null },
                    { new Guid("69cdfd3e-26f1-4e30-bc1c-8a400e71e252"), true, "barcode30.jpg", new DateTime(2024, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 0m, null },
                    { new Guid("71d1d8cc-73bd-47a1-baa0-cda4315024fc"), true, "barcode7.jpg", new DateTime(2024, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 70000m, null },
                    { new Guid("78a126b5-2187-4d4e-ae50-0bef3cc5ca92"), true, "barcode8.jpg", new DateTime(2024, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 80000m, null },
                    { new Guid("7cf85394-aa19-4508-9284-fb3d51ea7545"), true, "barcode14.jpg", new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 40000m, null },
                    { new Guid("97693a5a-c23d-4a01-ab4a-ba2e216bd567"), true, "barcode6.jpg", new DateTime(2024, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 60000m, null },
                    { new Guid("9797be41-9187-4a16-9a1a-0227a43e3fb3"), true, "barcode3.jpg", new DateTime(2024, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 30000m, null },
                    { new Guid("99f75dec-8ff0-40ac-83ad-47ce8e2be553"), true, "barcode26.jpg", new DateTime(2024, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 60000m, null },
                    { new Guid("a9297f04-cae4-47ef-92c0-e2748a91918e"), true, "barcode20.jpg", new DateTime(2024, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 0m, null },
                    { new Guid("aa58b0cb-6308-4f9f-b792-fc375fe3d5d8"), true, "barcode18.jpg", new DateTime(2024, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 80000m, null },
                    { new Guid("b07327ec-6611-4f70-ba5f-641c785a4325"), true, "barcode11.jpg", new DateTime(2024, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 10000m, null },
                    { new Guid("b43511f8-c064-4abf-8925-c4657c70ee52"), true, "barcode17.jpg", new DateTime(2024, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 70000m, null },
                    { new Guid("c9c4185f-df7d-4acb-aced-c17e4d0061ed"), true, "barcode21.jpg", new DateTime(2024, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 10000m, null },
                    { new Guid("cb0c8661-77cd-4153-895a-5700ec32699b"), true, "barcode1.jpg", new DateTime(2024, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 10000m, null },
                    { new Guid("d088636b-2c9f-493f-b636-8642e8c24328"), true, "barcode25.jpg", new DateTime(2024, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 50000m, null },
                    { new Guid("d285dc95-1b21-488c-a01c-1511f6a23a56"), true, "barcode12.jpg", new DateTime(2024, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 20000m, null },
                    { new Guid("eac5000e-e006-46b9-aa74-ef46ac921d42"), true, "barcode28.jpg", new DateTime(2024, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 80000m, null },
                    { new Guid("fc93ef81-d97e-4192-96b9-a906b8785689"), true, "barcode2.jpg", new DateTime(2024, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35ff4cc4-7823-4ffb-95e4-c2e73dace190"), 2, 20000m, null }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CinemaId", "Position", "SeatTypeId", "Status" },
                values: new object[,]
                {
                    { new Guid("009be231-199d-4eb0-b480-2acabc821e65"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "A6", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("04d34c6b-9c1a-42ab-be34-aacaac2a941d"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "J5", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("052cc8f5-360b-4baa-a4d7-3b04de38345b"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "J7", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("066c7dde-1bab-4ee0-9dde-42bc1b75fa3b"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "H4", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("0728d74b-603d-4b20-b4b0-307714650290"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "J3", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("0963d89f-ea3c-4220-9a30-9cd1964d3a30"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "F4", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("0aeec050-655b-4c77-8777-ba1e4d4ed733"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "A4", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("0e9e128e-ef6d-41c4-8d5b-9c19beee6d4c"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "A2", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("0ee863b4-7bdb-4306-a930-ea4827bc014b"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "I10", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("137c81c4-bd77-41f5-96c2-d61f780848d0"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "I8", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("14fe1bf8-a323-4529-87f0-6dd87950b2e7"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "H7", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("1b4eb831-7c56-4df6-a324-37ed1d17d3cc"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "C9", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("1f1f071e-7519-4ca3-bda8-1cda40418669"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "J4", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("2347e910-c52c-4dbe-bf77-18af778b59f3"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "H3", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("25f67c2f-03fb-4ef2-8fd2-3c2ac68a37bc"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "J8", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("264d06af-3334-4a5d-8c6f-c348423035a4"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "G5", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("2c8bc93c-664e-46a9-8eb4-171b07851cdc"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "H1", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("2cbfb9cd-fea2-4620-9852-eddc53a605ef"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "H5", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("308b7469-1369-4f79-a84d-9d41bbb68d99"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "G9", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("323705f9-714b-4443-9b18-faf58f9a0de3"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "E9", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("325dc393-d8e7-469c-93b3-5bd848a4e4e7"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "B8", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("33cf1ab3-58e6-43f9-8e46-9a7f85b40985"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "A1", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("348cde9e-d294-4dab-b2a9-12551ca934db"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "F5", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("361743ac-74c5-4439-9d56-59bdb5c90424"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "I5", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("37d063ea-1803-4ef9-b06e-f481cb1d4059"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "B3", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("37d1e738-c72b-460d-87ee-a4e4c612ebe5"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "B7", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("384d3065-4105-4f8a-929e-df842e9ed9a1"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "G8", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("39852863-87da-4f6f-bfa1-4c2a721e8865"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "E7", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("3cb51c0f-228a-4659-908e-3a171becfc8c"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "B6", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("3e0f9d7d-f96e-437d-a4d0-a9bad5e8d2bd"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "C8", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("3e564900-7626-4197-a871-57587ca684a2"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "F8", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("3e75bf2b-6926-4fb3-9506-9a8574d1ad5e"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "E2", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("4174010e-1970-4450-be1a-b32c9e3ae6af"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "J6", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("44b9e9f0-3ee9-4a5f-b2cd-0c05e6890653"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "F1", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("4509ee21-89da-4855-b174-91fa22c66bde"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "J2", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("49b8ccc5-ff53-4b4a-a430-a15230ac9c3c"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "J1", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("4a5c8f41-c3c2-4ae7-b905-0692f3033537"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "G3", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("50eeb3f6-bc3d-4fcd-9557-8a62deb2f554"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "E5", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("523e9917-eb2b-466a-b037-500c71923bbc"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "H8", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("546cf67c-87de-47b8-a1b6-2eddf342d348"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "B5", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("5a095646-e838-4d66-a436-40f83b051272"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "C1", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("6371cd38-4755-4148-b174-d2fa0767404b"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "D1", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("694ec5c7-822b-443a-8e7f-7fa99b7c9179"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "I2", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("6c4912a7-7a58-4462-a9fd-8debaa26d0e4"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "E8", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("6db30645-7dbf-4b92-8814-b021bbd12785"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "I1", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("6fdd49c5-187c-407b-b9cb-1b99455e320e"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "D4", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("70be096b-e03b-4f08-953c-679e804162ae"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "I6", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("7148dee1-87b7-42de-870b-6dcf3cb03bc2"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "J9", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("73571667-1159-4ba3-8394-b2680d0629e9"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "C10", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("7529d907-b38b-44d1-bb29-260284bbc8f5"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "F7", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("76f98168-57ea-41ac-8ca3-437c66e7e65e"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "A9", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("7cf102aa-bb96-489b-80e1-c84694cb78da"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "G6", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("7cfdd533-132e-4537-a360-91202d6c341f"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "G7", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("7e07fe21-89ee-4c3c-9462-d058f0472923"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "H9", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("812350e0-2fb5-42da-80d1-5ff01cbab690"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "B10", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("85068365-a9fc-4dec-be5e-e31a53bbb1cc"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "G2", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("886010b0-deff-42c8-bd3a-c49e97eada9c"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "D9", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("8c5c4ef0-2b88-424b-8e54-030030ce81f1"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "D10", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("8c90ee3c-0e69-455d-a787-72e67f43e63c"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "I4", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("8d15e5d6-15ca-42af-8cee-34b94819e762"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "H6", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("98faf34e-c781-41c7-b483-d97de8994d71"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "E4", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("9a795db9-6dca-43df-b21b-34070939daa4"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "D3", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("9c863bed-271c-4a1d-b58a-cd64f69364e6"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "D6", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("9f5a938a-d386-4bfd-968b-69da01c2d1a9"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "A8", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("a11066f1-2f33-4782-afc2-87429b3fdb5b"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "B1", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("a31b278a-e9fe-45e3-a059-8afec7b688e3"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "A10", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("a84e56ef-6340-4347-8d18-c915217b7944"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "A7", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("b46804b4-c709-4468-9855-38e9dd8c27bf"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "D8", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("b46bcfaf-fc5f-4038-be80-cdccd23e8488"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "D2", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("b66f3165-c1c2-42c4-b444-60ada065037f"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "E1", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("b799ac9d-b007-442f-93bb-1d48886c1658"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "F6", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("b894c38d-b78d-4267-836b-3d4618ad0f49"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "C6", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("bb100207-22b2-451b-bf47-fc068838fb6c"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "C3", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("bd57bc64-7302-41de-a5ca-e3567ff63407"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "F9", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("befb19b1-4397-4bbd-882f-0bcdba6a4b3f"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "D5", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("c3851346-9d08-407c-94f3-726cac807955"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "B9", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("c7c886f8-5573-4f81-8970-a84171f9d739"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "C5", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("cc21c7ce-0119-4cb6-8c02-55477564d063"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "G1", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("cefa2887-8857-4bad-a2e5-f95ede09c502"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "H2", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("d08ad5f7-2fcf-4f52-ad89-8db8b23f49c3"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "F10", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("d0c26d35-cf0b-4001-a95a-ad843da3d1dc"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "B2", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("d24d63e3-124c-40ea-81ed-853ffe6d8f47"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "E10", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("d40f9592-ad76-4119-b5e2-9b0c3e0ef03e"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "E3", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("d8f2a81a-2756-4f5a-8763-65090bdc198c"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "A3", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("de1b9ea1-5aa9-4cc0-8eee-bb81b7fd5917"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "F2", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("de3165d4-7ed5-4ba1-8e3a-618316d8e0a9"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "I3", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("df1e1850-4406-46d5-91ea-8e6722cacbe5"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "C4", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("e103a628-01fc-4ab7-89c9-b320bb5445ff"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "F3", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("e4bf9c3e-0937-427f-9801-b01db9a77ef4"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "G10", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("e53d8268-c7a2-4e19-ae69-ec1ab536b9d9"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "I7", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("e53d8ab6-4ae8-4073-917f-eaff439b7247"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "E6", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("e6823b1a-e935-4dae-a851-0fa4443e519f"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "I9", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("e68f86b5-96dd-49a8-a228-ee122f00455f"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "D7", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("e9593a61-edbe-4c24-aef3-7ea70c8f4df5"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "H10", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("ea53b026-906b-4f34-8aef-3e12ee17fb03"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "J10", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("ec149e22-663c-4cd3-9c04-7fad46e49635"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "G4", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("f140b309-fc02-4041-b5e9-cb45ec067f01"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "B4", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("f7210bb6-7e60-49aa-9c71-803d05499432"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "C2", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("fd23ffa9-032d-4e0c-ba39-0d4d443425a4"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "C7", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 },
                    { new Guid("fde31a4a-40df-446c-bb48-cefdf16fe51e"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "A5", new Guid("e548fd61-3d84-4104-b15e-f13d5d7d53ed"), 1 }
                });

            migrationBuilder.InsertData(
                table: "ShowTimes",
                columns: new[] { "Id", "CinemaCenterId", "CinemaId", "Desciption", "EndTime", "FilmId", "ScheduleId", "ScreenTypeId", "ShowtimeDate", "StartTime", "Status", "TranslationTypeId" },
                values: new object[,]
                {
                    { new Guid("00b5ca25-021d-4c12-a17a-78e99f4010e2"), new Guid("fc8c2a48-8009-478d-bd89-ea5f997b5edc"), new Guid("ad5ed4d0-77ca-4f76-8a89-582533e6aba6"), "Description for ShowTime 17", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e899b936-08c5-44e6-915d-bf982858dd84"), new Guid("3e14846e-c52a-41c0-825b-3f18c4b01a37"), new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), null, new DateTime(2024, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("0747cd62-d825-487f-a4b0-2f5ef1a4ae37"), new Guid("da1424b4-704c-48cb-8d9e-1ed264778966"), new Guid("ae7a6d1b-301f-426a-bd8e-f63ff98f78b6"), "Description for ShowTime 30", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5cc78365-f76c-4a70-a42d-410d20c9517e"), new Guid("73cccbf0-5cf3-4b94-9f26-9abf85fabb34"), new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), null, new DateTime(2024, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("09fc9746-f6f5-4cad-b865-04d4b5da1486"), new Guid("aa474f56-51e1-4e0f-850c-d64827e56536"), new Guid("fdc23e86-a00b-4084-87ea-7c9afb4ec170"), "Description for ShowTime 9", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e03ad928-22d1-405b-bad0-ed388b99eb72"), new Guid("7d63a82f-8374-4f67-b726-11f945653431"), new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), null, new DateTime(2024, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("134878ff-9ce9-4848-9be3-91f9907bfdbf"), new Guid("68b399b1-56bb-46ee-965f-f012f9b17684"), new Guid("df0edc1d-d26b-46b9-ad7d-03a2a4a39890"), "Description for ShowTime 8", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0406a43f-29f7-47b9-b8a8-940769c914a4"), new Guid("12ee505b-b640-4798-a3e3-240141f1b119"), new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), null, new DateTime(2024, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("1962a347-e5d9-411e-a71a-c24fca86923d"), new Guid("efce1372-4a4b-4292-8cdb-bf28deb0f808"), new Guid("6aea3387-a9b2-4bd1-828f-ed56b361d5e5"), "Description for ShowTime 11", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("70ae0a17-99f3-41dd-a509-0eee0f902f4d"), new Guid("6e926898-353d-4591-962c-c7fc788cdf6c"), new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), null, new DateTime(2024, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("304187cd-4c89-4f5c-b199-f5d69a853e98"), new Guid("58bb7811-9f5a-40da-8ebc-efc59bb8df53"), new Guid("1395a43b-dda6-4c0c-80e9-67c58f72acfa"), "Description for ShowTime 13", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d4f21ac7-7ec3-4363-a162-308797be55ec"), new Guid("afa8bad5-939d-4583-880e-e206563959bd"), new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), null, new DateTime(2024, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("4183c428-1409-44f2-b8da-2c5f6f9c84bf"), new Guid("031ef9a3-a02b-4155-a078-6b6c9357cf01"), new Guid("6ba8b0fd-9cad-4667-8be9-d69503c79f1d"), "Description for ShowTime 27", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3ff63242-1758-467a-9d65-5561812a46fe"), new Guid("bae22ba8-8452-4275-b8b3-67bc9740d559"), new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), null, new DateTime(2024, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("4709ecc5-e8bc-418e-8f75-be1d0602d388"), new Guid("84351fd7-5487-41fa-908c-ffebb5689ddc"), new Guid("ae0305f2-01c1-44e2-a0ba-160ba7fc9d01"), "Description for ShowTime 6", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("10fd66b7-9c7f-4642-addc-8fb94282f2be"), new Guid("ebe87901-6b7b-42e3-ab93-455802928d43"), new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), null, new DateTime(2024, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("481a19eb-f2f7-4232-aa27-eed5e839bfe5"), new Guid("f150574e-e730-4b4b-8dc4-8ea023ff26d6"), new Guid("b56a0639-71b4-4352-98b1-fd8570e53ebd"), "Description for ShowTime 14", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("715a1729-4f02-4bbd-968d-50d7dd60a34a"), new Guid("37012426-4d90-4e9d-bdb6-dcbd47f31745"), new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), null, new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("51d87136-c1d7-4eda-996c-dec0d7432faf"), new Guid("6ff3b1aa-b3c1-4505-92fe-72c0b2c9ad06"), new Guid("bd7a075c-216b-4505-855f-d49cc3d6ee2f"), "Description for ShowTime 24", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("58184807-19e7-42d1-a849-3e7bd1dbb3ed"), new Guid("61833f4f-a817-4395-8245-e7f5e4d2aacd"), new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), null, new DateTime(2024, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("5abc8626-9144-47a0-9a5c-d4be30d1d586"), new Guid("5e3439b9-2091-4132-aeda-99de360b7b41"), new Guid("3ecc1c7b-7f1b-4465-8b22-0cc336795231"), "Description for ShowTime 18", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7560a439-9367-4c21-b74b-b83361bcd79d"), new Guid("c57e17a4-1692-45a9-9219-f56eb05d275e"), new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), null, new DateTime(2024, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("5e76d4c7-5845-4fff-9192-906456621e4e"), new Guid("2ea3d492-fc6a-48ba-8cd9-1e8cdfb46271"), new Guid("46667323-a6ba-4e39-b117-52d2377b6ec5"), "Description for ShowTime 25", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("18084a35-739e-4433-a607-63e2da9a547f"), new Guid("c95d4676-0025-4201-b905-b9ce6f30c53f"), new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), null, new DateTime(2024, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("641e13a2-2892-4efe-ab7b-e65c2e54a5bf"), new Guid("f292361d-e382-44ce-9c79-63970daae8eb"), new Guid("4b86245d-a01d-4eaf-b552-0f345580cbbb"), "Description for ShowTime 7", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f78386e9-43d2-4d34-ba23-ef420746a1db"), new Guid("f1ceb272-5632-492c-aa2f-a752dc4ed30b"), new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), null, new DateTime(2024, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("64c009b1-8376-421c-bef4-8b667f19e2b6"), new Guid("2381bdda-4ab3-45a7-949e-b54e586ae48a"), new Guid("41c41f65-f9bb-4976-a110-292a3cef72c8"), "Description for ShowTime 16", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("635a12ab-d8de-4070-9c72-0d941fa2b254"), new Guid("14291a65-5bac-42c5-b7f7-95126b580cf9"), new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), null, new DateTime(2024, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("658c59ae-45bc-499e-86aa-527cf24cd03f"), new Guid("d54ca520-9c70-40a4-8b88-9c87d8a5558f"), new Guid("41208f1e-84e4-470c-9bab-4484bce2e1fb"), "Description for ShowTime 2", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e88711f-ad16-4bdf-b476-bf8cdd791012"), new Guid("db2feb1c-65f5-42ef-b5a6-eebf4aa0349c"), new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), null, new DateTime(2024, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("67952dd0-b0a8-4928-a700-5e505562c5eb"), new Guid("ff8f338a-58b5-4fad-aea9-39423f9f264d"), new Guid("aede5615-0530-45c1-a60b-5896ec6da0b8"), "Description for ShowTime 19", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("1f835672-6eae-4107-aac0-7358094a1d49"), new Guid("331e1597-ccfc-4aeb-b40f-0bdcdde387a5"), new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), null, new DateTime(2024, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("705a67e7-4d4d-49f2-b3b5-0bac22925131"), new Guid("b3b351e0-8a87-405d-a12c-6d79b25810b5"), new Guid("2070eb43-99de-4601-9e66-767a6bcf636c"), "Description for ShowTime 3", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4ffa15f4-caeb-4c8a-9ad3-af3b61f34968"), new Guid("77b77b7f-142e-431e-acdb-a7752931b525"), new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), null, new DateTime(2024, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("8df0a390-a993-4cc7-8219-ab2b84eef1dc"), new Guid("33a99230-5120-416a-bc01-4401741de767"), new Guid("f4727936-dc2f-45f4-8b1b-557b445638d7"), "Description for ShowTime 21", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("24b83f6a-0643-4774-8417-5c15839ba9e8"), new Guid("a94cf825-3cea-4187-9266-2db32a0bf417"), new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), null, new DateTime(2024, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("8ed9d7c9-d2ca-4650-93d9-713a33a6d2da"), new Guid("81b214a6-3a4a-475f-8089-8300df19099c"), new Guid("4b90406b-b203-40e9-ae93-c36344072697"), "Description for ShowTime 5", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("06cb5e0b-b38d-4faa-8308-fd95f3d72c4b"), new Guid("459cd0ed-c8b5-42ff-bbb5-1d762b72688b"), new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), null, new DateTime(2024, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("92edca84-508f-421c-a713-e71d3352fe60"), new Guid("5d24b6c2-5446-4278-8c31-72622c871dc7"), new Guid("a16a0117-e6dc-4e6e-adf6-c7c62a6363bc"), "Description for ShowTime 28", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2b05b649-a5f5-4e13-9015-b84836a88805"), new Guid("44a49862-2563-4e16-add4-193a6972d0c7"), new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), null, new DateTime(2024, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("97203bc1-1c2f-47e0-8408-1479fcb6045e"), new Guid("6fdce11f-d0fa-49ef-add6-094a237372cc"), new Guid("8a15de72-34c5-4c10-bb55-ffea277b3f52"), "Description for ShowTime 23", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4b27a070-162c-4a44-9897-1785247031c4"), new Guid("c9ac632e-a699-4907-a6fd-e32cccbfe957"), new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), null, new DateTime(2024, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("a69f2e82-d968-456e-a79e-31fadae09c0e"), new Guid("e304a215-e308-4b14-a489-8146ecde8dbd"), new Guid("0322e843-d775-4192-bf65-7265d1d99e37"), "Description for ShowTime 26", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e28077f1-f18d-49af-b2ec-6898f4f5cfab"), new Guid("21e88854-167d-4a59-b0c7-779420b40349"), new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), null, new DateTime(2024, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("cc1d533c-37da-4f48-86c9-db6b55baba3f"), new Guid("46454bd7-6a5e-42f1-9215-141c0a11654b"), new Guid("6e4ec94a-bc1b-4eeb-a70c-018ac74120dd"), "Description for ShowTime 1", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e275734b-3205-4f25-bfad-e59a74155799"), new Guid("736a84c8-651e-4e47-8379-8246a0bca4d9"), new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), null, new DateTime(2024, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("df4e6f49-2074-48c9-a9a5-9e23c59cc014"), new Guid("07c4e772-9a7e-42ef-a22b-c927a2047bef"), new Guid("98a494cb-93e3-48df-9306-2117a699e750"), "Description for ShowTime 20", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2c9d3e45-76e6-4ed8-a3c2-02b054c3173a"), new Guid("7cf9cb82-90d2-4b64-877d-8e0fa2b1df8a"), new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), null, new DateTime(2024, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("e1edf59f-73ba-473e-b2ca-57c6452b4dc6"), new Guid("f085f15a-6aa2-4ea7-9bf2-6b271d3c36e0"), new Guid("dd16d30b-8ae3-4ac0-bdaa-b02c320dd238"), "Description for ShowTime 22", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("cc1b079c-e341-464c-a631-7023727476cc"), new Guid("e793723a-d50a-49ab-8539-ce704702506a"), new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), null, new DateTime(2024, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("e5db60e4-39c6-46d2-be42-42e43584de94"), new Guid("ac86d266-dff7-44a9-8952-70a938fc25ae"), new Guid("ca2a3430-9d0f-4af6-8684-2d721b747515"), "Description for ShowTime 15", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("99426faf-3b24-44fd-8f18-f2a906f067db"), new Guid("e36cad6f-9226-44ac-9015-178b0c1fad3b"), new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), null, new DateTime(2024, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("e6653dd3-dd15-4703-ab4d-bc41195dc41b"), new Guid("af0aec34-6223-4ec7-88ef-df079059dc9d"), new Guid("16197418-f61e-471c-8730-02ed9f116d8e"), "Description for ShowTime 10", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7029112f-6421-45de-8443-0ba9f61162ad"), new Guid("be707d99-4a42-4217-adeb-d0b7c0615286"), new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), null, new DateTime(2024, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("ee318d99-cfc2-4cfb-84b2-cb1817637cfc"), new Guid("21a1015e-4ed4-4af4-a489-3334db1186e3"), new Guid("76c3943a-ba0f-4cad-bd8c-f4d65c6fa831"), "Description for ShowTime 12", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("aebeecda-4b25-4dd4-8a3f-97ef9632e7b2"), new Guid("ec7bdee1-45e7-4662-9514-2f4b3d37f036"), new Guid("8c0c4fe0-5d38-4760-93f6-ebd5fcd0e17c"), null, new DateTime(2024, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c4bba8c8-0cc7-4d31-a82d-efa9c1d7bb30") },
                    { new Guid("f7c6421a-be92-4cdb-b867-c5399293f240"), new Guid("d12589ad-358c-4c48-bf4c-5d9d72571130"), new Guid("f1ec4e5b-6072-4e9d-9c48-ef93419736da"), "Description for ShowTime 29", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e7f701b9-a37a-483a-a630-8714d4941d1e"), new Guid("fa86c932-4d2b-40d2-8168-c9da827905ba"), new Guid("36bbb6d8-eda5-4353-9f9c-765e24ff0122"), null, new DateTime(2024, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") },
                    { new Guid("f80e9f76-105e-452c-b795-f53adc88c57a"), new Guid("20e8572e-4045-4e9b-9c48-7478711ca9f7"), new Guid("ccf01534-6d68-450b-91b1-14ef8d9c4b15"), "Description for ShowTime 4", new DateTime(2024, 10, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e0e1fc50-7ff9-4334-80c6-94afbd0bd4c8"), new Guid("26b4666c-3c7a-4a68-94cd-eb5f5646d719"), new Guid("2b18932d-3074-4ba9-9d4b-97b09feac482"), null, new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("e7e15c47-4d2d-4f6b-9b93-6b233e0115bf") }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "BillId", "CinemaCenterId", "Description", "Qrcode", "SeatId", "ShowTimeId", "Status", "TicketPriceId" },
                values: new object[,]
                {
                    { new Guid("0115625e-4344-4939-bc33-faf91a94f061"), new Guid("5bc19ef4-5617-4285-9457-0a744f1eb39f"), new Guid("07c4e772-9a7e-42ef-a22b-c927a2047bef"), "Description for Ticket 10", "qrcode10.jpg", new Guid("8c5c4ef0-2b88-424b-8e54-030030ce81f1"), new Guid("e6653dd3-dd15-4703-ab4d-bc41195dc41b"), 2, new Guid("f9c1c649-4e02-402a-8690-e90adc04a6df") },
                    { new Guid("07467ba0-7f68-4fbb-8856-85ee3d49f80c"), new Guid("b43511f8-c064-4abf-8925-c4657c70ee52"), new Guid("fc8c2a48-8009-478d-bd89-ea5f997b5edc"), "Description for Ticket 17", "qrcode17.jpg", new Guid("37d1e738-c72b-460d-87ee-a4e4c612ebe5"), new Guid("00b5ca25-021d-4c12-a17a-78e99f4010e2"), 2, new Guid("c958a3e9-6933-4e25-9689-42ee08db9b6a") },
                    { new Guid("1873d308-58b3-45f7-9d74-4f40ef28a8f0"), new Guid("cb0c8661-77cd-4153-895a-5700ec32699b"), new Guid("6fdce11f-d0fa-49ef-add6-094a237372cc"), "Description for Ticket 1", "qrcode1.jpg", new Guid("ea53b026-906b-4f34-8aef-3e12ee17fb03"), new Guid("cc1d533c-37da-4f48-86c9-db6b55baba3f"), 2, new Guid("3585a9ba-e4f6-4779-90e1-f55101f22e76") },
                    { new Guid("1c8c66c1-0645-42b9-8d40-8536bcbda550"), new Guid("2c3d0b61-a5c0-4e43-b7a2-a1a797582f1c"), new Guid("b3b351e0-8a87-405d-a12c-6d79b25810b5"), "Description for Ticket 15", "qrcode15.jpg", new Guid("3e0f9d7d-f96e-437d-a4d0-a9bad5e8d2bd"), new Guid("e5db60e4-39c6-46d2-be42-42e43584de94"), 2, new Guid("2fd89eab-e2fa-4683-b4af-9b416037c925") },
                    { new Guid("2324c3e0-2f7c-44f0-9520-28c5cba4a0e1"), new Guid("5da5f624-37d6-47a6-8741-f67387d3343f"), new Guid("5d24b6c2-5446-4278-8c31-72622c871dc7"), "Description for Ticket 13", "qrcode13.jpg", new Guid("361743ac-74c5-4439-9d56-59bdb5c90424"), new Guid("304187cd-4c89-4f5c-b199-f5d69a853e98"), 2, new Guid("a718b6d6-1d1b-4bdb-8fe9-35258499d080") },
                    { new Guid("245db162-5c63-40e7-9fbe-feaf19ef4ef2"), new Guid("d088636b-2c9f-493f-b636-8642e8c24328"), new Guid("d12589ad-358c-4c48-bf4c-5d9d72571130"), "Description for Ticket 25", "qrcode25.jpg", new Guid("546cf67c-87de-47b8-a1b6-2eddf342d348"), new Guid("5e76d4c7-5845-4fff-9192-906456621e4e"), 2, new Guid("14af9293-cd58-4c91-bd5f-3b2d0feb9771") },
                    { new Guid("24d72140-2f35-4396-88f1-50bf225438a3"), new Guid("0e5fc47a-825f-4f4a-ab26-58015a312ee6"), new Guid("b3b351e0-8a87-405d-a12c-6d79b25810b5"), "Description for Ticket 4", "qrcode4.jpg", new Guid("d24d63e3-124c-40ea-81ed-853ffe6d8f47"), new Guid("f80e9f76-105e-452c-b795-f53adc88c57a"), 2, new Guid("1d897c6d-d50b-470c-9e93-4925b33d80ba") },
                    { new Guid("320c031d-c5a0-4373-9dd1-df06604d790a"), new Guid("aa58b0cb-6308-4f9f-b792-fc375fe3d5d8"), new Guid("2ea3d492-fc6a-48ba-8cd9-1e8cdfb46271"), "Description for Ticket 18", "qrcode18.jpg", new Guid("df1e1850-4406-46d5-91ea-8e6722cacbe5"), new Guid("5abc8626-9144-47a0-9a5c-d4be30d1d586"), 2, new Guid("9c449a73-638c-4889-ba2e-3a2a7b947aec") },
                    { new Guid("44840a8d-d2f7-4386-bf41-e23e34d9db38"), new Guid("eac5000e-e006-46b9-aa74-ef46ac921d42"), new Guid("031ef9a3-a02b-4155-a078-6b6c9357cf01"), "Description for Ticket 28", "qrcode28.jpg", new Guid("308b7469-1369-4f79-a84d-9d41bbb68d99"), new Guid("92edca84-508f-421c-a713-e71d3352fe60"), 2, new Guid("c80d7766-3575-4c60-ae0b-81dd880b8c4f") },
                    { new Guid("46589715-19f3-4349-a3fb-142d20bdf762"), new Guid("9797be41-9187-4a16-9a1a-0227a43e3fb3"), new Guid("d12589ad-358c-4c48-bf4c-5d9d72571130"), "Description for Ticket 3", "qrcode3.jpg", new Guid("cc21c7ce-0119-4cb6-8c02-55477564d063"), new Guid("705a67e7-4d4d-49f2-b3b5-0bac22925131"), 2, new Guid("5933772a-41de-4a06-92a3-a9edd33c04d4") },
                    { new Guid("58f3598f-d56f-4e08-871e-f31f9e1de145"), new Guid("c9c4185f-df7d-4acb-aced-c17e4d0061ed"), new Guid("af0aec34-6223-4ec7-88ef-df079059dc9d"), "Description for Ticket 21", "qrcode21.jpg", new Guid("2cbfb9cd-fea2-4620-9852-eddc53a605ef"), new Guid("8df0a390-a993-4cc7-8219-ab2b84eef1dc"), 2, new Guid("ca683ef4-74b4-466e-9743-ede4b5cdd04f") },
                    { new Guid("6446aab1-af3b-4450-8a00-842d15ed8b18"), new Guid("a9297f04-cae4-47ef-92c0-e2748a91918e"), new Guid("5e3439b9-2091-4132-aeda-99de360b7b41"), "Description for Ticket 20", "qrcode20.jpg", new Guid("886010b0-deff-42c8-bd3a-c49e97eada9c"), new Guid("df4e6f49-2074-48c9-a9a5-9e23c59cc014"), 2, new Guid("85ad9e2e-f04a-4bf1-b5c9-b88e92d37c76") },
                    { new Guid("6fc8837e-e308-42a8-950a-c5c2b9d166a9"), new Guid("68cc8a04-f972-4064-9ea3-c002580b75ea"), new Guid("6ff3b1aa-b3c1-4505-92fe-72c0b2c9ad06"), "Description for Ticket 19", "qrcode19.jpg", new Guid("f7210bb6-7e60-49aa-9c71-803d05499432"), new Guid("67952dd0-b0a8-4928-a700-5e505562c5eb"), 2, new Guid("9102dda5-c7f2-407a-aa3c-9dea1e4e7939") },
                    { new Guid("706df488-e05a-4919-9d42-196a5166cb0e"), new Guid("5d9ba538-60f0-47d9-8199-7d4859b6a740"), new Guid("81b214a6-3a4a-475f-8089-8300df19099c"), "Description for Ticket 29", "qrcode29.jpg", new Guid("7e07fe21-89ee-4c3c-9462-d058f0472923"), new Guid("f7c6421a-be92-4cdb-b867-c5399293f240"), 2, new Guid("c138961d-4fe3-4a99-b1f7-96683dbda815") },
                    { new Guid("71d24f1b-2bde-4c56-bd20-1ef8c7ae3e74"), new Guid("1c914ec9-94e6-49ba-b485-cd7ba608dc5f"), new Guid("ac86d266-dff7-44a9-8952-70a938fc25ae"), "Description for Ticket 24", "qrcode24.jpg", new Guid("0728d74b-603d-4b20-b4b0-307714650290"), new Guid("51d87136-c1d7-4eda-996c-dec0d7432faf"), 2, new Guid("711a624b-8e54-4fac-bf17-17a6e84f9710") },
                    { new Guid("7b86f95a-eaa4-4c6f-a0fb-d51c551a8403"), new Guid("344c3158-13dc-4199-9291-50fccd8c7d11"), new Guid("2381bdda-4ab3-45a7-949e-b54e586ae48a"), "Description for Ticket 5", "qrcode5.jpg", new Guid("009be231-199d-4eb0-b480-2acabc821e65"), new Guid("8ed9d7c9-d2ca-4650-93d9-713a33a6d2da"), 2, new Guid("6fe0c2c8-fb01-4502-b049-4cbca1ae7018") },
                    { new Guid("8bbaecab-a8c9-4970-90ff-7a987116b635"), new Guid("0f9774b5-1ab8-4a16-8dc7-d6bdeed36981"), new Guid("46454bd7-6a5e-42f1-9215-141c0a11654b"), "Description for Ticket 9", "qrcode9.jpg", new Guid("6c4912a7-7a58-4462-a9fd-8debaa26d0e4"), new Guid("09fc9746-f6f5-4cad-b865-04d4b5da1486"), 2, new Guid("ac61be35-55c6-400b-a83b-fa1726eb4163") },
                    { new Guid("94210918-aebe-46e2-9a09-284947b9c870"), new Guid("b07327ec-6611-4f70-ba5f-641c785a4325"), new Guid("e304a215-e308-4b14-a489-8146ecde8dbd"), "Description for Ticket 11", "qrcode11.jpg", new Guid("137c81c4-bd77-41f5-96c2-d61f780848d0"), new Guid("1962a347-e5d9-411e-a71a-c24fca86923d"), 2, new Guid("e101b9ea-7d7f-417d-b1e4-fb6e665df30a") },
                    { new Guid("952fb32f-7257-45a1-8656-016b06be6bfb"), new Guid("69cdfd3e-26f1-4e30-bc1c-8a400e71e252"), new Guid("07c4e772-9a7e-42ef-a22b-c927a2047bef"), "Description for Ticket 30", "qrcode30.jpg", new Guid("2c8bc93c-664e-46a9-8eb4-171b07851cdc"), new Guid("0747cd62-d825-487f-a4b0-2f5ef1a4ae37"), 2, new Guid("06dde27e-4c53-4576-8049-2d4cda77ca14") },
                    { new Guid("96ab954e-5476-45fa-ab79-fd5f1121e234"), new Guid("4394a155-fc7d-40f5-8ee4-4ee8b4f1073c"), new Guid("20e8572e-4045-4e9b-9c48-7478711ca9f7"), "Description for Ticket 22", "qrcode22.jpg", new Guid("7cf102aa-bb96-489b-80e1-c84694cb78da"), new Guid("e1edf59f-73ba-473e-b2ca-57c6452b4dc6"), 2, new Guid("31608c71-0a25-4e49-8774-eb6b2df5302c") },
                    { new Guid("9b1c2205-e8af-4ddd-a85e-ec19d5ff4f93"), new Guid("71d1d8cc-73bd-47a1-baa0-cda4315024fc"), new Guid("d54ca520-9c70-40a4-8b88-9c87d8a5558f"), "Description for Ticket 7", "qrcode7.jpg", new Guid("8c5c4ef0-2b88-424b-8e54-030030ce81f1"), new Guid("641e13a2-2892-4efe-ab7b-e65c2e54a5bf"), 2, new Guid("10db47fb-a1e2-41ec-9ac3-e2191c432084") },
                    { new Guid("9cb66133-1c79-4bd8-adca-3849ce7d4dd3"), new Guid("298df334-6234-4226-a4f1-5c69ab01e09d"), new Guid("6fdce11f-d0fa-49ef-add6-094a237372cc"), "Description for Ticket 23", "qrcode23.jpg", new Guid("361743ac-74c5-4439-9d56-59bdb5c90424"), new Guid("97203bc1-1c2f-47e0-8408-1479fcb6045e"), 2, new Guid("1d3826ee-113b-413f-b887-115138ac3e23") },
                    { new Guid("a60e19ab-ffa2-4c69-bc1c-4432a878148b"), new Guid("99f75dec-8ff0-40ac-83ad-47ce8e2be553"), new Guid("33a99230-5120-416a-bc01-4401741de767"), "Description for Ticket 26", "qrcode26.jpg", new Guid("0963d89f-ea3c-4220-9a30-9cd1964d3a30"), new Guid("a69f2e82-d968-456e-a79e-31fadae09c0e"), 2, new Guid("0812e290-f087-4229-88de-6f66ad7d2821") },
                    { new Guid("ae0575d8-42cf-4e90-9635-e9088d968fdb"), new Guid("54232ea1-606d-49c2-a98d-f805ead8e9c3"), new Guid("031ef9a3-a02b-4155-a078-6b6c9357cf01"), "Description for Ticket 27", "qrcode27.jpg", new Guid("e68f86b5-96dd-49a8-a228-ee122f00455f"), new Guid("4183c428-1409-44f2-b8da-2c5f6f9c84bf"), 2, new Guid("c798a69d-39af-4cec-94a5-ce88177c6e5e") },
                    { new Guid("c4c7021b-a64e-438d-8a57-f52d51d6bf8c"), new Guid("fc93ef81-d97e-4192-96b9-a906b8785689"), new Guid("84351fd7-5487-41fa-908c-ffebb5689ddc"), "Description for Ticket 2", "qrcode2.jpg", new Guid("de1b9ea1-5aa9-4cc0-8eee-bb81b7fd5917"), new Guid("658c59ae-45bc-499e-86aa-527cf24cd03f"), 2, new Guid("f7df388e-9fb5-45ac-89de-bf98ed7b99ba") },
                    { new Guid("c7083a89-cb9e-440d-83c5-0216cdfcaaac"), new Guid("7cf85394-aa19-4508-9284-fb3d51ea7545"), new Guid("6fdce11f-d0fa-49ef-add6-094a237372cc"), "Description for Ticket 14", "qrcode14.jpg", new Guid("2c8bc93c-664e-46a9-8eb4-171b07851cdc"), new Guid("481a19eb-f2f7-4232-aa27-eed5e839bfe5"), 2, new Guid("8a50a132-0fef-410e-800f-529553fd3840") },
                    { new Guid("cbb5cc22-1475-43cc-af32-e2a9dabe28f0"), new Guid("d285dc95-1b21-488c-a01c-1511f6a23a56"), new Guid("07c4e772-9a7e-42ef-a22b-c927a2047bef"), "Description for Ticket 12", "qrcode12.jpg", new Guid("bd57bc64-7302-41de-a5ca-e3567ff63407"), new Guid("ee318d99-cfc2-4cfb-84b2-cb1817637cfc"), 2, new Guid("2850a2e1-3b8c-4d51-a505-9a72ef304109") },
                    { new Guid("d9666fcc-a15a-404a-a063-5d94d0207ca4"), new Guid("3c71499a-4c1b-43f1-bf93-287df90065cb"), new Guid("84351fd7-5487-41fa-908c-ffebb5689ddc"), "Description for Ticket 16", "qrcode16.jpg", new Guid("04d34c6b-9c1a-42ab-be34-aacaac2a941d"), new Guid("64c009b1-8376-421c-bef4-8b667f19e2b6"), 2, new Guid("8e961cc5-e760-46b4-8cd8-1ee2ab1db2cc") },
                    { new Guid("f7ee81cf-ddbb-4494-98fe-76d9461756d5"), new Guid("78a126b5-2187-4d4e-ae50-0bef3cc5ca92"), new Guid("58bb7811-9f5a-40da-8ebc-efc59bb8df53"), "Description for Ticket 8", "qrcode8.jpg", new Guid("5a095646-e838-4d66-a436-40f83b051272"), new Guid("134878ff-9ce9-4848-9be3-91f9907bfdbf"), 2, new Guid("9063c706-a57a-4635-a610-64601a0014f0") },
                    { new Guid("f81dce71-1b23-4a8a-a121-e6b466227eb7"), new Guid("97693a5a-c23d-4a01-ab4a-ba2e216bd567"), new Guid("58bb7811-9f5a-40da-8ebc-efc59bb8df53"), "Description for Ticket 6", "qrcode6.jpg", new Guid("a11066f1-2f33-4782-afc2-87429b3fdb5b"), new Guid("4709ecc5-e8bc-418e-8f75-be1d0602d388"), 2, new Guid("20b7e1d0-fe6d-4d15-8121-1c53ebd087fd") }
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