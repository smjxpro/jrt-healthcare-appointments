using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Healthcare.Appointments.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Added_Specialty_To_Doctors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Specialty",
                table: "AspNetUsers",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Specialty",
                table: "AspNetUsers");
        }
    }
}
