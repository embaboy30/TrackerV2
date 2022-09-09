using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Tracker.Data.Migrations
{
    public partial class addedTagsAndColab : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tag",
                table: "Todo");

            migrationBuilder.AddColumn<int>(
                name: "TagId",
                table: "Todo",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Colaborator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    TodoId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaborator", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Colaborator_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Colaborator_Todo_TodoId",
                        column: x => x.TodoId,
                        principalTable: "Todo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Color = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Todo_TagId",
                table: "Todo",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Colaborator_TodoId",
                table: "Colaborator",
                column: "TodoId");

            migrationBuilder.CreateIndex(
                name: "IX_Colaborator_UserId",
                table: "Colaborator",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Todo_Tag_TagId",
                table: "Todo",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todo_Tag_TagId",
                table: "Todo");

            migrationBuilder.DropTable(
                name: "Colaborator");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropIndex(
                name: "IX_Todo_TagId",
                table: "Todo");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "Todo");

            migrationBuilder.AddColumn<string>(
                name: "Tag",
                table: "Todo",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
