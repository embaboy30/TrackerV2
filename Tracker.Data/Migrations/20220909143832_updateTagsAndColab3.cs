using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tracker.Data.Migrations
{
    public partial class updateTagsAndColab3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todo_Tag_TagId",
                table: "Todo");

            migrationBuilder.AlterColumn<int>(
                name: "TagId",
                table: "Todo",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Todo_Tag_TagId",
                table: "Todo",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todo_Tag_TagId",
                table: "Todo");

            migrationBuilder.AlterColumn<int>(
                name: "TagId",
                table: "Todo",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Todo_Tag_TagId",
                table: "Todo",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
