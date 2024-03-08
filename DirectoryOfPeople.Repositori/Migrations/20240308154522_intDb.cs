using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DirectoryOfPeople.Repositori.Migrations
{
    /// <inheritdoc />
    public partial class intDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "GetDate()"),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "(0)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PersonalityConnections",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConnectionType = table.Column<string>(type: "nvarchar(35)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "GetDate()"),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "(0)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalityConnections", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(75)", nullable: false),
                    PersonalNumber = table.Column<string>(type: "nvarchar(11)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: false),
                    PictureAddres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "GetDate()"),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "(0)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.ID);
                    table.ForeignKey(
                        name: "FK_People_Cities_ID",
                        column: x => x.ID,
                        principalTable: "Cities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactInformation",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactNamber = table.Column<string>(type: "varchar(15)", nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    PersonID = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "GetDate()"),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "(0)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactInformation", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ContactInformation_People_PersonID",
                        column: x => x.PersonID,
                        principalTable: "People",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FromPeopelPersonalityConnection",
                columns: table => new
                {
                    FromPersonID = table.Column<int>(type: "int", nullable: false),
                    FromPersonalityConnectionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FromPeopelPersonalityConnection", x => new { x.FromPersonID, x.FromPersonalityConnectionID });
                    table.ForeignKey(
                        name: "FK_FromPeopelPersonalityConnection_People_FromPersonID",
                        column: x => x.FromPersonID,
                        principalTable: "People",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FromPeopelPersonalityConnection_PersonalityConnections_FromPersonalityConnectionID",
                        column: x => x.FromPersonalityConnectionID,
                        principalTable: "PersonalityConnections",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ToPersonalityConnectionPerson",
                columns: table => new
                {
                    ToPersonID = table.Column<int>(type: "int", nullable: false),
                    ToPersonalityConnectionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToPersonalityConnectionPerson", x => new { x.ToPersonID, x.ToPersonalityConnectionID });
                    table.ForeignKey(
                        name: "FK_ToPersonalityConnectionPerson_People_ToPersonID",
                        column: x => x.ToPersonID,
                        principalTable: "People",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ToPersonalityConnectionPerson_PersonalityConnections_ToPersonalityConnectionID",
                        column: x => x.ToPersonalityConnectionID,
                        principalTable: "PersonalityConnections",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_Name",
                table: "Cities",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContactInformation_PersonID",
                table: "ContactInformation",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_FromPeopelPersonalityConnection_FromPersonalityConnectionID",
                table: "FromPeopelPersonalityConnection",
                column: "FromPersonalityConnectionID");

            migrationBuilder.CreateIndex(
                name: "IX_ToPersonalityConnectionPerson_ToPersonalityConnectionID",
                table: "ToPersonalityConnectionPerson",
                column: "ToPersonalityConnectionID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactInformation");

            migrationBuilder.DropTable(
                name: "FromPeopelPersonalityConnection");

            migrationBuilder.DropTable(
                name: "ToPersonalityConnectionPerson");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "PersonalityConnections");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
