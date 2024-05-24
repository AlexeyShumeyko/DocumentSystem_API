using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DocumentSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class @ref : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Documents_PreviousTaskID",
                table: "Tasks");

            migrationBuilder.AlterColumn<string>(
                name: "PreviousTaskID",
                table: "Tasks",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Documents_PreviousTaskID",
                table: "Tasks",
                column: "PreviousTaskID",
                principalTable: "Documents",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Documents_PreviousTaskID",
                table: "Tasks");

            migrationBuilder.AlterColumn<string>(
                name: "PreviousTaskID",
                table: "Tasks",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Documents_PreviousTaskID",
                table: "Tasks",
                column: "PreviousTaskID",
                principalTable: "Documents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
