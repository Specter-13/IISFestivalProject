using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FestivalProject.DAL.Migrations
{
    public partial class AddMoreData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "Capacity", "City", "Country", "Description", "EndTime", "Genre", "LogoUri", "Name", "Price", "StartTime", "Street" },
                values: new object[] { new Guid("30d09c0f-f6aa-442c-9d87-2869faf175f4"), 10000, "Trenčin", "Slovakia", "The best festivals in Slovakia!", new DateTime(2020, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "https://dl-media.viber.com/5/share/2/long/vibes/icon/image/0x0/105c/2c48f0221e7b0b58487a6483ba8c19e8a0a4f4d27a7e0291932b5dc92c41105c.jpg", "Pohoda", 70m, new DateTime(2020, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Letisko" });

            migrationBuilder.InsertData(
                table: "FestivalInterprets",
                columns: new[] { "InterpretId", "FestivalId" },
                values: new object[] { new Guid("0c41b222-d06b-4021-9668-a4f845bbe57b"), new Guid("30d09c0f-f6aa-442c-9d87-2869faf175f4") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FestivalInterprets",
                keyColumns: new[] { "InterpretId", "FestivalId" },
                keyValues: new object[] { new Guid("0c41b222-d06b-4021-9668-a4f845bbe57b"), new Guid("30d09c0f-f6aa-442c-9d87-2869faf175f4") });

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("30d09c0f-f6aa-442c-9d87-2869faf175f4"));
        }
    }
}
