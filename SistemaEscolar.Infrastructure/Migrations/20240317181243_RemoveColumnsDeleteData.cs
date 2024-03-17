using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaEscolar.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveColumnsDeleteData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuditDeleteDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AuditDeleteUser",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AuditDeleteDate",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AuditDeleteUser",
                table: "Users",
                type: "int",
                nullable: true);
        }
    }
}
