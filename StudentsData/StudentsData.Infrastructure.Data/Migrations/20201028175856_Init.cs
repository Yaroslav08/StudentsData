using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentsData.Infrastructure.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    DateStartEdu = table.Column<DateTime>(nullable: false),
                    DateEndEdu = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Fullname = table.Column<string>(maxLength: 50, nullable: false),
                    Username = table.Column<string>(maxLength: 25, nullable: true),
                    Login = table.Column<string>(maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(maxLength: 1000, nullable: false),
                    IsConfirm = table.Column<bool>(nullable: false),
                    DateConfirm = table.Column<DateTime>(nullable: true),
                    TokenConfirm = table.Column<string>(nullable: false),
                    Avatar = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Firstname = table.Column<string>(maxLength: 25, nullable: false),
                    Middlename = table.Column<string>(maxLength: 25, nullable: false),
                    Lastname = table.Column<string>(maxLength: 25, nullable: false),
                    Photo = table.Column<string>(maxLength: 250, nullable: true),
                    Address = table.Column<string>(maxLength: 150, nullable: false),
                    MobilePhone = table.Column<string>(maxLength: 100, nullable: false),
                    EmailAddress = table.Column<string>(maxLength: 100, nullable: false),
                    Passport = table.Column<string>(maxLength: 250, nullable: true),
                    GroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Groups_Name",
                table: "Groups",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Students_GroupId",
                table: "Students",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_Firstname_Middlename_Lastname_Photo_GroupId_Passport_Address",
                table: "Students",
                columns: new[] { "Firstname", "Middlename", "Lastname", "Photo", "GroupId", "Passport", "Address" });

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_Username_Login_TokenConfirm",
                table: "Teachers",
                columns: new[] { "Username", "Login", "TokenConfirm" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Groups");
        }
    }
}
