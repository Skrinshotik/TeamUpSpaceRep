using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamUpSpace.Migrations.IdentityDb
{
    /// <inheritdoc />
    public partial class init34554 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ProjectModel_ProjectId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ProjectModel_ProjectId",
                table: "AspNetUsers",
                column: "ProjectId",
                principalTable: "ProjectModel",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ProjectModel_ProjectId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ProjectModel_ProjectId",
                table: "AspNetUsers",
                column: "ProjectId",
                principalTable: "ProjectModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
