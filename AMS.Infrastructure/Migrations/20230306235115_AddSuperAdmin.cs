using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSuperAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUserTokens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "AspNetUserTokens",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "AspNetUserTokens",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AspNetUserTokens",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("ad2267ef-5579-4cd0-8eb5-7635d57e4e1d"), "c879cea6-7715-4630-9091-98bca275c94e", "Admin", "ADMIN" },
                    { new Guid("ef1551c0-439d-4557-91b3-68362533b294"), "ef1551c0-439d-4557-91b3-68362533b294", "Super Admin", "SUPER ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DeviceSerialNumber", "Email", "EmailConfirmed", "FullName", "IDNumber", "IsActive", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("0485f3ff-ddd1-4535-96ca-58dad6369c98"), 0, "2e2da04a-792b-4b63-ab95-d3307f8cbdad", "00001111", "khatap1@hotmail.com", true, "Khatab Mohamed", "2537045755", true, false, null, "khatap1@hotmail.com", "Administrator", "AQAAAAIAAYagAAAAEHAXHwYHdJZoVVPsui/peBipdT+EVGi486AfKki82ByOtMRn4DaswaPlJQab9WrKlw==", null, false, "", false, "khatap1@hotmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("ef1551c0-439d-4557-91b3-68362533b294"), new Guid("0485f3ff-ddd1-4535-96ca-58dad6369c98") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ad2267ef-5579-4cd0-8eb5-7635d57e4e1d"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("ef1551c0-439d-4557-91b3-68362533b294"), new Guid("0485f3ff-ddd1-4535-96ca-58dad6369c98") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ef1551c0-439d-4557-91b3-68362533b294"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0485f3ff-ddd1-4535-96ca-58dad6369c98"));

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUserTokens");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "AspNetUserTokens");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "AspNetUserTokens");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AspNetUserTokens");
        }
    }
}
