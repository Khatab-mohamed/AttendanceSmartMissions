using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class editUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLocations_AspNetUsers_UserId",
                table: "UserLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLocations_Locations_LocationId",
                table: "UserLocations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLocations",
                table: "UserLocations");

            migrationBuilder.DropIndex(
                name: "IX_UserLocations_LocationId",
                table: "UserLocations");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5af7a692-fb67-4ce2-b910-606bf592aa55"));

            migrationBuilder.RenameTable(
                name: "UserLocations",
                newName: "LocationUser");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LocationUser",
                table: "LocationUser",
                columns: new[] { "LocationId", "UserId" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("20d9a780-66df-4449-9981-b7467672f0da"), null, "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fac3c682-00a7-48c9-8713-828028efd932", "AQAAAAIAAYagAAAAEKYefBm38nr7o6trU3nAbty0ZIel1zAmLBS5l2BsCQGDgZg4I211TfPNGajisnpu7A==" });

            migrationBuilder.CreateIndex(
                name: "IX_LocationUser_UserId",
                table: "LocationUser",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_LocationUser_AspNetUsers_UserId",
                table: "LocationUser",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LocationUser_Locations_LocationId",
                table: "LocationUser",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocationUser_AspNetUsers_UserId",
                table: "LocationUser");

            migrationBuilder.DropForeignKey(
                name: "FK_LocationUser_Locations_LocationId",
                table: "LocationUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LocationUser",
                table: "LocationUser");

            migrationBuilder.DropIndex(
                name: "IX_LocationUser_UserId",
                table: "LocationUser");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("20d9a780-66df-4449-9981-b7467672f0da"));

            migrationBuilder.RenameTable(
                name: "LocationUser",
                newName: "UserLocations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLocations",
                table: "UserLocations",
                columns: new[] { "UserId", "LocationId" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("5af7a692-fb67-4ce2-b910-606bf592aa55"), null, "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e5acc18f-74cb-4c48-b258-96b045a85255", "AQAAAAIAAYagAAAAEIOUm3tAYhkCCcKAXC52RXaR8kWKu6NZ+TDKZgaqCMrsQHciof49at7LBuKdbnWzlg==" });

            migrationBuilder.CreateIndex(
                name: "IX_UserLocations_LocationId",
                table: "UserLocations",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLocations_AspNetUsers_UserId",
                table: "UserLocations",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLocations_Locations_LocationId",
                table: "UserLocations",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
