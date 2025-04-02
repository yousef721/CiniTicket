using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CineTicket.Data.Migrations
{
    /// <inheritdoc />
    public partial class EditDurationInSchduleCinema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_ScheduleCinema_Duration",
                table: "ScheduleCinemas");

            migrationBuilder.AlterColumn<int>(
                name: "Duration",
                table: "ScheduleCinemas",
                type: "int",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AddCheckConstraint(
                name: "CK_ScheduleCinema_Duration",
                table: "ScheduleCinemas",
                sql: "[Duration] > 0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_ScheduleCinema_Duration",
                table: "ScheduleCinemas");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Duration",
                table: "ScheduleCinemas",
                type: "time",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddCheckConstraint(
                name: "CK_ScheduleCinema_Duration",
                table: "ScheduleCinemas",
                sql: "DATEDIFF(SECOND, '00:00:00', [Duration]) > 0");
        }
    }
}
