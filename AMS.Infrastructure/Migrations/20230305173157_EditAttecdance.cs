using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EditAttecdance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AttendanceType",
                table: "Attendances",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AttendanceType",
                table: "Attendances");
        }
    }
}
