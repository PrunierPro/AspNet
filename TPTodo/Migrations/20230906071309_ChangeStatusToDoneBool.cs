using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TPTodo.Migrations
{
    /// <inheritdoc />
    public partial class ChangeStatusToDoneBool : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "tasks");

            migrationBuilder.AddColumn<bool>(
                name: "done",
                table: "tasks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "tasks",
                keyColumn: "id",
                keyValue: 1,
                column: "done",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "done",
                table: "tasks");

            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "tasks",
                keyColumn: "id",
                keyValue: 1,
                column: "status",
                value: 0);
        }
    }
}
