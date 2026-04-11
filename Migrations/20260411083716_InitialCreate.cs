using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobMSWebApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationId = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PresentSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ExpectionSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Degree = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    University = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CGPA = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CompletionYear = table.Column<int>(type: "int", nullable: true),
                    ResumePath = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applications");
        }
    }
}
