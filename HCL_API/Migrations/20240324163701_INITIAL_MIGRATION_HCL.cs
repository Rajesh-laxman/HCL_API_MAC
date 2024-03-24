using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HCL_API.Migrations
{
    /// <inheritdoc />
    public partial class INITIAL_MIGRATION_HCL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Emp_db_set",
                columns: table => new
                {
                    E_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    E_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    E_City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    E_Design = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emp_db_set", x => x.E_ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Emp_db_set");
        }
    }
}
