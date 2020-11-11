using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FestivalProject.DAL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Festivals",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Genre = table.Column<int>(nullable: false),
                    Country = table.Column<string>(nullable: true),
                    LogoUri = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Capacity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Festivals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Interprets",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    LogoUri = table.Column<string>(nullable: true),
                    Rating = table.Column<float>(nullable: false),
                    Genre = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interprets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stages",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Capacity = table.Column<int>(nullable: false),
                    FestivalId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stages_Festivals_FestivalId",
                        column: x => x.FestivalId,
                        principalTable: "Festivals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FestivalInterprets",
                columns: table => new
                {
                    FestivalId = table.Column<Guid>(nullable: false),
                    InterpretId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FestivalInterprets", x => new { x.InterpretId, x.FestivalId });
                    table.ForeignKey(
                        name: "FK_FestivalInterprets_Festivals_FestivalId",
                        column: x => x.FestivalId,
                        principalTable: "Festivals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FestivalInterprets_Interprets_InterpretId",
                        column: x => x.InterpretId,
                        principalTable: "Interprets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    InterpretId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Members_Interprets_InterpretId",
                        column: x => x.InterpretId,
                        principalTable: "Interprets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Role = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    Psc = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    LoginId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Logins_LoginId",
                        column: x => x.LoginId,
                        principalTable: "Logins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StageInterprets",
                columns: table => new
                {
                    InterpretId = table.Column<Guid>(nullable: false),
                    StageId = table.Column<Guid>(nullable: false),
                    ConcertLength = table.Column<TimeSpan>(nullable: false),
                    ConcertStart = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StageInterprets", x => new { x.InterpretId, x.StageId });
                    table.ForeignKey(
                        name: "FK_StageInterprets_Interprets_InterpretId",
                        column: x => x.InterpretId,
                        principalTable: "Interprets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StageInterprets_Stages_StageId",
                        column: x => x.StageId,
                        principalTable: "Stages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    State = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Tickets = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(nullable: true),
                    FestivalId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Festivals_FestivalId",
                        column: x => x.FestivalId,
                        principalTable: "Festivals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "Capacity", "City", "Country", "Description", "EndTime", "Genre", "LogoUri", "Name", "Price", "StartTime", "Street" },
                values: new object[] { new Guid("46abef51-c53f-4cc5-a270-a2756ef1455e"), 1500, "Piestany", "Slovakia", "One of the best festivals in Slovakia!", new DateTime(2020, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "https://www.gregi.net/wp-content/uploads/2018/07/logo-1.jpg", "Grape", 55m, new DateTime(2020, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Letiskova 123" });

            migrationBuilder.InsertData(
                table: "Interprets",
                columns: new[] { "Id", "Description", "Genre", "LogoUri", "Name", "Rating" },
                values: new object[,]
                {
                    { new Guid("0c41b222-d06b-4021-9668-a4f845bbe57b"), "One of the most talented slovak singer.", 0, "https://www.adamdurica.com/wp-content/uploads/2019/04/album_adam_durica_mandolina-400x400.jpg", "Adam Durica", 8.7f },
                    { new Guid("c993e8d3-719b-43d7-908b-e26dc6f4ace0"), "Without word one of the best metal groups.", 2, "https://www.adamdurica.com/wp-content/uploads/2019/04/album_adam_durica_mandolina-400x400.jpg", "Metallica", 9.7f }
                });

            migrationBuilder.InsertData(
                table: "Logins",
                columns: new[] { "Id", "Password", "UserId", "Username" },
                values: new object[,]
                {
                    { new Guid("a2347ca2-4a12-46f6-9013-3596b07c63ed"), "123", new Guid("1ae18ad6-9809-4b19-be41-94aa4ff622f8"), "admin" },
                    { new Guid("f7e5a131-c097-47fc-8900-65c51819ecee"), "12345", new Guid("e3681bb8-1e7f-4e4f-8abe-58dbd211d6d1"), "trdielko" }
                });

            migrationBuilder.InsertData(
                table: "FestivalInterprets",
                columns: new[] { "InterpretId", "FestivalId" },
                values: new object[,]
                {
                    { new Guid("0c41b222-d06b-4021-9668-a4f845bbe57b"), new Guid("46abef51-c53f-4cc5-a270-a2756ef1455e") },
                    { new Guid("c993e8d3-719b-43d7-908b-e26dc6f4ace0"), new Guid("46abef51-c53f-4cc5-a270-a2756ef1455e") }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "InterpretId", "Name", "Surname" },
                values: new object[,]
                {
                    { new Guid("d01d66d9-ac9d-4419-81b3-bc8ae2dfae96"), new Guid("0c41b222-d06b-4021-9668-a4f845bbe57b"), "Janko", "Mrkvicka" },
                    { new Guid("af1e3d1f-fbd7-4d2f-a7f1-f7cda8e3547f"), new Guid("0c41b222-d06b-4021-9668-a4f845bbe57b"), "Misko", "Maly" }
                });

            migrationBuilder.InsertData(
                table: "Stages",
                columns: new[] { "Id", "Capacity", "FestivalId", "Name" },
                values: new object[,]
                {
                    { new Guid("cb22c323-729d-49e6-834a-644d47d3dc4c"), 600, new Guid("46abef51-c53f-4cc5-a270-a2756ef1455e"), "Main Stage" },
                    { new Guid("4afd5bb9-6c95-411b-becf-daffb873a7a4"), 200, new Guid("46abef51-c53f-4cc5-a270-a2756ef1455e"), "Low Stage" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "City", "Country", "Email", "LoginId", "Name", "Psc", "Role", "Street", "Surname" },
                values: new object[,]
                {
                    { new Guid("1ae18ad6-9809-4b19-be41-94aa4ff622f8"), null, "Slovakia", "xspavo00@vutrb.cz", new Guid("a2347ca2-4a12-46f6-9013-3596b07c63ed"), "David", null, 0, null, "Spavor" },
                    { new Guid("e3681bb8-1e7f-4e4f-8abe-58dbd211d6d1"), "Bratislava", "Slovakia", "trdielko@hotmail.sk", new Guid("f7e5a131-c097-47fc-8900-65c51819ecee"), "Barbora", "03855", 3, "Vajnorska", "Bakosova" }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "Description", "FestivalId", "Name", "Price", "State", "Tickets", "UserId" },
                values: new object[] { new Guid("8edf6ecd-8d1d-4fbf-92c1-9640e4bc21d9"), "rezervacia sa vybavuje", new Guid("46abef51-c53f-4cc5-a270-a2756ef1455e"), "Grape rezervacia (mozno bude lepsie nejake cislo rezervacie)", 55m, 0, 1, new Guid("e3681bb8-1e7f-4e4f-8abe-58dbd211d6d1") });

            migrationBuilder.InsertData(
                table: "StageInterprets",
                columns: new[] { "InterpretId", "StageId", "ConcertLength", "ConcertStart" },
                values: new object[] { new Guid("c993e8d3-719b-43d7-908b-e26dc6f4ace0"), new Guid("cb22c323-729d-49e6-834a-644d47d3dc4c"), new TimeSpan(0, 3, 30, 0, 0), new DateTime(2020, 7, 26, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "StageInterprets",
                columns: new[] { "InterpretId", "StageId", "ConcertLength", "ConcertStart" },
                values: new object[] { new Guid("0c41b222-d06b-4021-9668-a4f845bbe57b"), new Guid("cb22c323-729d-49e6-834a-644d47d3dc4c"), new TimeSpan(0, 2, 30, 0, 0), new DateTime(2020, 7, 25, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_FestivalInterprets_FestivalId",
                table: "FestivalInterprets",
                column: "FestivalId");

            migrationBuilder.CreateIndex(
                name: "IX_Logins_Username",
                table: "Logins",
                column: "Username",
                unique: true,
                filter: "[Username] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Members_InterpretId",
                table: "Members",
                column: "InterpretId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_FestivalId",
                table: "Reservations",
                column: "FestivalId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserId",
                table: "Reservations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StageInterprets_StageId",
                table: "StageInterprets",
                column: "StageId");

            migrationBuilder.CreateIndex(
                name: "IX_Stages_FestivalId",
                table: "Stages",
                column: "FestivalId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_LoginId",
                table: "Users",
                column: "LoginId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FestivalInterprets");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "StageInterprets");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Interprets");

            migrationBuilder.DropTable(
                name: "Stages");

            migrationBuilder.DropTable(
                name: "Logins");

            migrationBuilder.DropTable(
                name: "Festivals");
        }
    }
}
