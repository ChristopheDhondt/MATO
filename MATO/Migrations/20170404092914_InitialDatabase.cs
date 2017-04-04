using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MATO.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    PostBox = table.Column<string>(nullable: true),
                    PostCode = table.Column<string>(nullable: true),
                    PostNumber = table.Column<string>(nullable: true),
                    Street = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Federations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    OfficialAdressId = table.Column<int>(nullable: true),
                    PostalAdressId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Federations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Federations_Address_OfficialAdressId",
                        column: x => x.OfficialAdressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Federations_Address_PostalAdressId",
                        column: x => x.PostalAdressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmailAdress = table.Column<string>(nullable: true),
                    Firstname = table.Column<string>(nullable: true),
                    LastConnection = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true),
                    OfficialAdressId = table.Column<int>(nullable: true),
                    PostalAdressId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_Address_OfficialAdressId",
                        column: x => x.OfficialAdressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Persons_Address_PostalAdressId",
                        column: x => x.PostalAdressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Clubs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FederationId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    OfficialAdressId = table.Column<int>(nullable: true),
                    PostalAdressId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clubs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clubs_Federations_FederationId",
                        column: x => x.FederationId,
                        principalTable: "Federations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clubs_Address_OfficialAdressId",
                        column: x => x.OfficialAdressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clubs_Address_PostalAdressId",
                        column: x => x.PostalAdressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClubId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.id);
                    table.ForeignKey(
                        name: "FK_Teams_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClubMember",
                columns: table => new
                {
                    ClubId = table.Column<int>(nullable: false),
                    MemberId = table.Column<int>(nullable: false),
                    Teamid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClubMember", x => new { x.ClubId, x.MemberId });
                    table.ForeignKey(
                        name: "FK_ClubMember_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClubMember_Persons_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClubMember_Teams_Teamid",
                        column: x => x.Teamid,
                        principalTable: "Teams",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeamCoach",
                columns: table => new
                {
                    TeamId = table.Column<int>(nullable: false),
                    CoachId = table.Column<int>(nullable: false),
                    CoachClubId = table.Column<int>(nullable: true),
                    CoachMemberId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamCoach", x => new { x.TeamId, x.CoachId });
                    table.ForeignKey(
                        name: "FK_TeamCoach_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamCoach_ClubMember_CoachClubId_CoachMemberId",
                        columns: x => new { x.CoachClubId, x.CoachMemberId },
                        principalTable: "ClubMember",
                        principalColumns: new[] { "ClubId", "MemberId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeamMember",
                columns: table => new
                {
                    TeamId = table.Column<int>(nullable: false),
                    MemberId = table.Column<int>(nullable: false),
                    MemberClubId = table.Column<int>(nullable: true),
                    MemberId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMember", x => new { x.TeamId, x.MemberId });
                    table.ForeignKey(
                        name: "FK_TeamMember_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamMember_ClubMember_MemberClubId_MemberId1",
                        columns: x => new { x.MemberClubId, x.MemberId1 },
                        principalTable: "ClubMember",
                        principalColumns: new[] { "ClubId", "MemberId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clubs_FederationId",
                table: "Clubs",
                column: "FederationId");

            migrationBuilder.CreateIndex(
                name: "IX_Clubs_OfficialAdressId",
                table: "Clubs",
                column: "OfficialAdressId");

            migrationBuilder.CreateIndex(
                name: "IX_Clubs_PostalAdressId",
                table: "Clubs",
                column: "PostalAdressId");

            migrationBuilder.CreateIndex(
                name: "IX_ClubMember_MemberId",
                table: "ClubMember",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_ClubMember_Teamid",
                table: "ClubMember",
                column: "Teamid");

            migrationBuilder.CreateIndex(
                name: "IX_Federations_OfficialAdressId",
                table: "Federations",
                column: "OfficialAdressId");

            migrationBuilder.CreateIndex(
                name: "IX_Federations_PostalAdressId",
                table: "Federations",
                column: "PostalAdressId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_OfficialAdressId",
                table: "Persons",
                column: "OfficialAdressId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_PostalAdressId",
                table: "Persons",
                column: "PostalAdressId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_ClubId",
                table: "Teams",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamCoach_CoachClubId_CoachMemberId",
                table: "TeamCoach",
                columns: new[] { "CoachClubId", "CoachMemberId" });

            migrationBuilder.CreateIndex(
                name: "IX_TeamMember_MemberClubId_MemberId1",
                table: "TeamMember",
                columns: new[] { "MemberClubId", "MemberId1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeamCoach");

            migrationBuilder.DropTable(
                name: "TeamMember");

            migrationBuilder.DropTable(
                name: "ClubMember");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Clubs");

            migrationBuilder.DropTable(
                name: "Federations");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
