using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeoPharma.Migrations
{
    /// <inheritdoc />
    public partial class RenamingEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address_ZipCode",
                table: "Pharmacy",
                newName: "ZipCode");

            migrationBuilder.RenameColumn(
                name: "Address_YoutubeUrl",
                table: "Pharmacy",
                newName: "YoutubeUrl");

            migrationBuilder.RenameColumn(
                name: "Address_XUrl",
                table: "Pharmacy",
                newName: "XUrl");

            migrationBuilder.RenameColumn(
                name: "Address_WebSiteUrl",
                table: "Pharmacy",
                newName: "WebSiteUrl");

            migrationBuilder.RenameColumn(
                name: "Address_Street",
                table: "Pharmacy",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "Address_PhoneNumber2",
                table: "Pharmacy",
                newName: "PhoneNumber2");

            migrationBuilder.RenameColumn(
                name: "Address_PhoneNumber1",
                table: "Pharmacy",
                newName: "PhoneNumber1");

            migrationBuilder.RenameColumn(
                name: "Address_Longitude",
                table: "Pharmacy",
                newName: "Longitude");

            migrationBuilder.RenameColumn(
                name: "Address_Localisation",
                table: "Pharmacy",
                newName: "Localisation");

            migrationBuilder.RenameColumn(
                name: "Address_LinkedInUrl",
                table: "Pharmacy",
                newName: "LinkedInUrl");

            migrationBuilder.RenameColumn(
                name: "Address_Latitude",
                table: "Pharmacy",
                newName: "Latitude");

            migrationBuilder.RenameColumn(
                name: "Address_InstagramUrl",
                table: "Pharmacy",
                newName: "InstagramUrl");

            migrationBuilder.RenameColumn(
                name: "Address_FacebookUrl",
                table: "Pharmacy",
                newName: "FacebookUrl");

            migrationBuilder.RenameColumn(
                name: "Address_Email",
                table: "Pharmacy",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "Address_District",
                table: "Pharmacy",
                newName: "District");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ZipCode",
                table: "Pharmacy",
                newName: "Address_ZipCode");

            migrationBuilder.RenameColumn(
                name: "YoutubeUrl",
                table: "Pharmacy",
                newName: "Address_YoutubeUrl");

            migrationBuilder.RenameColumn(
                name: "XUrl",
                table: "Pharmacy",
                newName: "Address_XUrl");

            migrationBuilder.RenameColumn(
                name: "WebSiteUrl",
                table: "Pharmacy",
                newName: "Address_WebSiteUrl");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "Pharmacy",
                newName: "Address_Street");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber2",
                table: "Pharmacy",
                newName: "Address_PhoneNumber2");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber1",
                table: "Pharmacy",
                newName: "Address_PhoneNumber1");

            migrationBuilder.RenameColumn(
                name: "Longitude",
                table: "Pharmacy",
                newName: "Address_Longitude");

            migrationBuilder.RenameColumn(
                name: "Localisation",
                table: "Pharmacy",
                newName: "Address_Localisation");

            migrationBuilder.RenameColumn(
                name: "LinkedInUrl",
                table: "Pharmacy",
                newName: "Address_LinkedInUrl");

            migrationBuilder.RenameColumn(
                name: "Latitude",
                table: "Pharmacy",
                newName: "Address_Latitude");

            migrationBuilder.RenameColumn(
                name: "InstagramUrl",
                table: "Pharmacy",
                newName: "Address_InstagramUrl");

            migrationBuilder.RenameColumn(
                name: "FacebookUrl",
                table: "Pharmacy",
                newName: "Address_FacebookUrl");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Pharmacy",
                newName: "Address_Email");

            migrationBuilder.RenameColumn(
                name: "District",
                table: "Pharmacy",
                newName: "Address_District");
        }
    }
}
