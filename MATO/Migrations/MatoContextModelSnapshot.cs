using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MATO.Models;

namespace MATO.Migrations
{
    [DbContext(typeof(MatoContext))]
    partial class MatoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MATO.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<string>("PostBox");

                    b.Property<string>("PostCode");

                    b.Property<string>("PostNumber");

                    b.Property<string>("Street")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("MATO.Models.Club", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("FederationId");

                    b.Property<string>("Name");

                    b.Property<int?>("OfficialAdressId");

                    b.Property<int?>("PostalAdressId");

                    b.HasKey("Id");

                    b.HasIndex("FederationId");

                    b.HasIndex("OfficialAdressId");

                    b.HasIndex("PostalAdressId");

                    b.ToTable("Clubs");
                });

            modelBuilder.Entity("MATO.Models.ClubMember", b =>
                {
                    b.Property<int>("ClubId");

                    b.Property<int>("MemberId");

                    b.Property<int?>("Teamid");

                    b.HasKey("ClubId", "MemberId");

                    b.HasIndex("MemberId");

                    b.HasIndex("Teamid");

                    b.ToTable("ClubMember");
                });

            modelBuilder.Entity("MATO.Models.Federation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int?>("OfficialAdressId");

                    b.Property<int?>("PostalAdressId");

                    b.HasKey("Id");

                    b.HasIndex("OfficialAdressId");

                    b.HasIndex("PostalAdressId");

                    b.ToTable("Federations");
                });

            modelBuilder.Entity("MATO.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EmailAdress");

                    b.Property<string>("Firstname");

                    b.Property<string>("LastConnection");

                    b.Property<string>("Lastname");

                    b.Property<int?>("OfficialAdressId");

                    b.Property<int?>("PostalAdressId");

                    b.HasKey("Id");

                    b.HasIndex("OfficialAdressId");

                    b.HasIndex("PostalAdressId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("MATO.Models.Team", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ClubId");

                    b.Property<string>("Name");

                    b.HasKey("id");

                    b.HasIndex("ClubId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("MATO.Models.TeamCoach", b =>
                {
                    b.Property<int>("TeamId");

                    b.Property<int>("CoachId");

                    b.Property<int?>("CoachClubId");

                    b.Property<int?>("CoachMemberId");

                    b.HasKey("TeamId", "CoachId");

                    b.HasIndex("CoachClubId", "CoachMemberId");

                    b.ToTable("TeamCoach");
                });

            modelBuilder.Entity("MATO.Models.TeamMember", b =>
                {
                    b.Property<int>("TeamId");

                    b.Property<int>("MemberId");

                    b.Property<int?>("MemberClubId");

                    b.Property<int?>("MemberId1");

                    b.HasKey("TeamId", "MemberId");

                    b.HasIndex("MemberClubId", "MemberId1");

                    b.ToTable("TeamMember");
                });

            modelBuilder.Entity("MATO.Models.Club", b =>
                {
                    b.HasOne("MATO.Models.Federation", "Federation")
                        .WithMany("Clubs")
                        .HasForeignKey("FederationId");

                    b.HasOne("MATO.Models.Address", "OfficialAdress")
                        .WithMany()
                        .HasForeignKey("OfficialAdressId");

                    b.HasOne("MATO.Models.Address", "PostalAdress")
                        .WithMany()
                        .HasForeignKey("PostalAdressId");
                });

            modelBuilder.Entity("MATO.Models.ClubMember", b =>
                {
                    b.HasOne("MATO.Models.Club", "Club")
                        .WithMany("ClubMembers")
                        .HasForeignKey("ClubId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MATO.Models.Person", "Member")
                        .WithMany("ClubMembers")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MATO.Models.Team")
                        .WithMany("TeamMembers")
                        .HasForeignKey("Teamid");
                });

            modelBuilder.Entity("MATO.Models.Federation", b =>
                {
                    b.HasOne("MATO.Models.Address", "OfficialAdress")
                        .WithMany()
                        .HasForeignKey("OfficialAdressId");

                    b.HasOne("MATO.Models.Address", "PostalAdress")
                        .WithMany()
                        .HasForeignKey("PostalAdressId");
                });

            modelBuilder.Entity("MATO.Models.Person", b =>
                {
                    b.HasOne("MATO.Models.Address", "OfficialAdress")
                        .WithMany()
                        .HasForeignKey("OfficialAdressId");

                    b.HasOne("MATO.Models.Address", "PostalAdress")
                        .WithMany()
                        .HasForeignKey("PostalAdressId");
                });

            modelBuilder.Entity("MATO.Models.Team", b =>
                {
                    b.HasOne("MATO.Models.Club", "Club")
                        .WithMany("Teams")
                        .HasForeignKey("ClubId");
                });

            modelBuilder.Entity("MATO.Models.TeamCoach", b =>
                {
                    b.HasOne("MATO.Models.Team", "Team")
                        .WithMany("TeamCoachs")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MATO.Models.ClubMember", "Coach")
                        .WithMany()
                        .HasForeignKey("CoachClubId", "CoachMemberId");
                });

            modelBuilder.Entity("MATO.Models.TeamMember", b =>
                {
                    b.HasOne("MATO.Models.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MATO.Models.ClubMember", "Member")
                        .WithMany()
                        .HasForeignKey("MemberClubId", "MemberId1");
                });
        }
    }
}
