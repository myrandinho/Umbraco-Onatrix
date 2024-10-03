using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Umbraco_Onatrix.Migrations
{
    /// <inheritdoc />
    public partial class AddingGetHelpentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "ContactForms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "ContactForms");
        }
    }
}
