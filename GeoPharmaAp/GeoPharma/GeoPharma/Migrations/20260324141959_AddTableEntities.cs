using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeoPharma.Migrations
{
    /// <inheritdoc />
    public partial class AddTableEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pharmacy_Doctor_DoctorId",
                table: "Pharmacy");

            migrationBuilder.DropForeignKey(
                name: "FK_Pharmacy_Municipality_MunicipalityId",
                table: "Pharmacy");

            migrationBuilder.DropForeignKey(
                name: "FK_Pharmacy_Region_RegionId",
                table: "Pharmacy");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Region",
                table: "Region");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pharmacy",
                table: "Pharmacy");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Municipality",
                table: "Municipality");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Doctor",
                table: "Doctor");

            migrationBuilder.RenameTable(
                name: "Region",
                newName: "Regions");

            migrationBuilder.RenameTable(
                name: "Pharmacy",
                newName: "Pharmacies");

            migrationBuilder.RenameTable(
                name: "Municipality",
                newName: "Municipalities");

            migrationBuilder.RenameTable(
                name: "Doctor",
                newName: "Doctors");

            migrationBuilder.RenameIndex(
                name: "IX_Pharmacy_RegionId",
                table: "Pharmacies",
                newName: "IX_Pharmacies_RegionId");

            migrationBuilder.RenameIndex(
                name: "IX_Pharmacy_MunicipalityId",
                table: "Pharmacies",
                newName: "IX_Pharmacies_MunicipalityId");

            migrationBuilder.RenameIndex(
                name: "IX_Pharmacy_DoctorId",
                table: "Pharmacies",
                newName: "IX_Pharmacies_DoctorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Regions",
                table: "Regions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pharmacies",
                table: "Pharmacies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Municipalities",
                table: "Municipalities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Doctors",
                table: "Doctors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pharmacies_Doctors_DoctorId",
                table: "Pharmacies",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pharmacies_Municipalities_MunicipalityId",
                table: "Pharmacies",
                column: "MunicipalityId",
                principalTable: "Municipalities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pharmacies_Regions_RegionId",
                table: "Pharmacies",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pharmacies_Doctors_DoctorId",
                table: "Pharmacies");

            migrationBuilder.DropForeignKey(
                name: "FK_Pharmacies_Municipalities_MunicipalityId",
                table: "Pharmacies");

            migrationBuilder.DropForeignKey(
                name: "FK_Pharmacies_Regions_RegionId",
                table: "Pharmacies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Regions",
                table: "Regions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pharmacies",
                table: "Pharmacies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Municipalities",
                table: "Municipalities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Doctors",
                table: "Doctors");

            migrationBuilder.RenameTable(
                name: "Regions",
                newName: "Region");

            migrationBuilder.RenameTable(
                name: "Pharmacies",
                newName: "Pharmacy");

            migrationBuilder.RenameTable(
                name: "Municipalities",
                newName: "Municipality");

            migrationBuilder.RenameTable(
                name: "Doctors",
                newName: "Doctor");

            migrationBuilder.RenameIndex(
                name: "IX_Pharmacies_RegionId",
                table: "Pharmacy",
                newName: "IX_Pharmacy_RegionId");

            migrationBuilder.RenameIndex(
                name: "IX_Pharmacies_MunicipalityId",
                table: "Pharmacy",
                newName: "IX_Pharmacy_MunicipalityId");

            migrationBuilder.RenameIndex(
                name: "IX_Pharmacies_DoctorId",
                table: "Pharmacy",
                newName: "IX_Pharmacy_DoctorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Region",
                table: "Region",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pharmacy",
                table: "Pharmacy",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Municipality",
                table: "Municipality",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Doctor",
                table: "Doctor",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pharmacy_Doctor_DoctorId",
                table: "Pharmacy",
                column: "DoctorId",
                principalTable: "Doctor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pharmacy_Municipality_MunicipalityId",
                table: "Pharmacy",
                column: "MunicipalityId",
                principalTable: "Municipality",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pharmacy_Region_RegionId",
                table: "Pharmacy",
                column: "RegionId",
                principalTable: "Region",
                principalColumn: "Id");
        }
    }
}
