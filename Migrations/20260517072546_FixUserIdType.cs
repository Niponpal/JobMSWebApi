using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobMSWebApi.Migrations
{
    /// <inheritdoc />
    public partial class FixUserIdType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_AspNetUsers_UserId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_UserId",
                table: "Jobs");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "UserId1",
                table: "Jobs",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "26d4e157-e8f6-408c-9dd6-6964b046cbb1", new DateTime(2026, 5, 17, 13, 25, 46, 265, DateTimeKind.Local).AddTicks(3022), "AQAAAAIAAYagAAAAEFAIfr3hfz6f1eamAKDTTPVU/+esquJVB3yQ+wksrODdE8oEYRTFoMI0JWAUJYgxAA==", "518f1970-54da-43fb-92af-cf91e4d91412" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2af4c774-8e3d-4b5b-9d40-8f7f07ffecf4", new DateTime(2026, 5, 17, 13, 25, 46, 316, DateTimeKind.Local).AddTicks(689), "AQAAAAIAAYagAAAAEGMFd46yirOtod8yWNB9bCs2KenXIu0bS6F5pbT0UQOYqKlmfRDPa/LzmyP7rhHI0g==", "c83c8638-1000-4c31-890e-ce8e2f0a7aa9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "05021642-a48f-42bc-adc1-9217562a0f78", new DateTime(2026, 5, 17, 13, 25, 46, 363, DateTimeKind.Local).AddTicks(8488), "AQAAAAIAAYagAAAAELY1ymQxDE08qbiGNETZF6mkUK7jbhpOhAXoFr8PWNuYtjxvs/GYg45sGnQuB3bKnA==", "77d90a63-e122-4f11-b4ef-a4ef09c8f286" });

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_UserId1",
                table: "Jobs",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_AspNetUsers_UserId1",
                table: "Jobs",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_AspNetUsers_UserId1",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_UserId1",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Jobs");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "Jobs",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "81bcdb2d-9b03-4301-a303-05acc88ed973", new DateTime(2026, 5, 17, 13, 0, 15, 926, DateTimeKind.Local).AddTicks(660), "AQAAAAIAAYagAAAAELkOqA7U+GzkxRrRJS1JfWzUVzTtCxSDDBVPJh3ppzv0qazh6Fd+ZmIguueOtPmCPA==", "128486a0-dbc6-4722-a3d2-0c2a0cfd1316" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1c7659a3-9780-4170-b858-6990ef44201a", new DateTime(2026, 5, 17, 13, 0, 15, 976, DateTimeKind.Local).AddTicks(4421), "AQAAAAIAAYagAAAAENvVwHU2npLScRmL4RWviObqAru7Cj2xbIm7XRisvS1mk1BhdPQAFuwt3PBIZhBWBg==", "a5af73f8-1d7f-44b0-9115-4f77c636a3f4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "15f15aa7-d70c-4692-b212-a34eb2ceb5f5", new DateTime(2026, 5, 17, 13, 0, 16, 23, DateTimeKind.Local).AddTicks(5766), "AQAAAAIAAYagAAAAEIgsJrdPBgayb8+JuALzyZAQtM97SqwOMPwTxqYYPmv3BaTG7L+PsaDC5nF6JXk6hQ==", "3093b48e-b2fc-4ade-b457-5b9709c6a1ed" });

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_UserId",
                table: "Jobs",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_AspNetUsers_UserId",
                table: "Jobs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
