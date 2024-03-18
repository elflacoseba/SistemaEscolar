using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaEscolar.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNameTableInstitutionEducationalLevel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstitutionEducationalLevel_EducationalLevels",
                table: "InstitutionEducationalLevel");

            migrationBuilder.DropForeignKey(
                name: "FK_InstitutionEducationalLevel_Institutions",
                table: "InstitutionEducationalLevel");

            migrationBuilder.AddForeignKey(
                name: "FK_InstitutionEducationalLevel_EducationalLevels_EducationalLevelId",
                table: "InstitutionEducationalLevel",
                column: "EducationalLevelId",
                principalTable: "EducationalLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InstitutionEducationalLevel_Institutions_InstitutionId",
                table: "InstitutionEducationalLevel",
                column: "InstitutionId",
                principalTable: "Institutions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstitutionEducationalLevel_EducationalLevels_EducationalLevelId",
                table: "InstitutionEducationalLevel");

            migrationBuilder.DropForeignKey(
                name: "FK_InstitutionEducationalLevel_Institutions_InstitutionId",
                table: "InstitutionEducationalLevel");

            migrationBuilder.AddForeignKey(
                name: "FK_InstitutionEducationalLevel_EducationalLevels",
                table: "InstitutionEducationalLevel",
                column: "EducationalLevelId",
                principalTable: "EducationalLevels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InstitutionEducationalLevel_Institutions",
                table: "InstitutionEducationalLevel",
                column: "InstitutionId",
                principalTable: "Institutions",
                principalColumn: "Id");
        }
    }
}
