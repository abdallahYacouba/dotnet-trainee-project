using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeoPharma.Migrations
{
    /// <inheritdoc />
    public partial class InitialTestForAddressType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Municipality",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipality", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pharmacy",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    RCCM = table.Column<string>(type: "TEXT", nullable: true),
                    Nif = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Address_PhoneNumber1 = table.Column<string>(type: "TEXT", nullable: true),
                    Address_PhoneNumber2 = table.Column<string>(type: "TEXT", nullable: true),
                    Address_Email = table.Column<string>(type: "TEXT", nullable: true),
                    Address_Latitude = table.Column<double>(type: "REAL", nullable: true),
                    Address_Longitude = table.Column<double>(type: "REAL", nullable: true),
                    Address_Localisation = table.Column<string>(type: "TEXT", nullable: true),
                    Address_District = table.Column<string>(type: "TEXT", nullable: true),
                    Address_Street = table.Column<string>(type: "TEXT", nullable: true),
                    Address_WebSiteUrl = table.Column<string>(type: "TEXT", nullable: true),
                    Address_YoutubeUrl = table.Column<string>(type: "TEXT", nullable: true),
                    Address_XUrl = table.Column<string>(type: "TEXT", nullable: true),
                    Address_FacebookUrl = table.Column<string>(type: "TEXT", nullable: true),
                    Address_LinkedInUrl = table.Column<string>(type: "TEXT", nullable: true),
                    Address_InstagramUrl = table.Column<string>(type: "TEXT", nullable: true),
                    Address_ZipCode = table.Column<string>(type: "TEXT", nullable: true),
                    DoctorId = table.Column<Guid>(type: "TEXT", nullable: true),
                    RegionId = table.Column<Guid>(type: "TEXT", nullable: true),
                    MunicipalityId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pharmacy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pharmacy_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pharmacy_Municipality_MunicipalityId",
                        column: x => x.MunicipalityId,
                        principalTable: "Municipality",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pharmacy_Region_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Region",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pharmacy_DoctorId",
                table: "Pharmacy",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Pharmacy_MunicipalityId",
                table: "Pharmacy",
                column: "MunicipalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Pharmacy_RegionId",
                table: "Pharmacy",
                column: "RegionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pharmacy");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "Municipality");

            migrationBuilder.DropTable(
                name: "Region");
        }
    }
}
