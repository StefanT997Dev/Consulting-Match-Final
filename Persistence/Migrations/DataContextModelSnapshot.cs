﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Persistence;

namespace Persistence.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("AppUserRole", b =>
                {
                    b.Property<string>("RolesId")
                        .HasColumnType("text");

                    b.Property<string>("UsersId")
                        .HasColumnType("text");

                    b.HasKey("RolesId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("AppUserRole");
                });

            modelBuilder.Entity("Domain.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("Bio")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("DisplayName")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("PhotoId")
                        .HasColumnType("text");

                    b.Property<string>("ProfilePicture")
                        .HasColumnType("text");

                    b.Property<string>("SalesVideo")
                        .HasColumnType("text");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.HasIndex("PhotoId");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Domain.AppUserCategory", b =>
                {
                    b.Property<string>("AppUserId")
                        .HasColumnType("text");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.HasKey("AppUserId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("AppUserCategories");
                });

            modelBuilder.Entity("Domain.AppUserLevel", b =>
                {
                    b.Property<string>("AppUserId")
                        .HasColumnType("text");

                    b.Property<Guid>("LevelId")
                        .HasColumnType("uuid");

                    b.Property<int>("NumberOfCredits")
                        .HasColumnType("integer");

                    b.HasKey("AppUserId", "LevelId");

                    b.HasIndex("LevelId");

                    b.ToTable("AppUserLevel");
                });

            modelBuilder.Entity("Domain.AppUserSkill", b =>
                {
                    b.Property<string>("MentorId")
                        .HasColumnType("text");

                    b.Property<Guid>("SkillId")
                        .HasColumnType("uuid");

                    b.HasKey("MentorId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("AppUserSkills");
                });

            modelBuilder.Entity("Domain.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Domain.CategorySkill", b =>
                {
                    b.Property<Guid>("SkillId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.HasKey("SkillId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("CategorySkills");
                });

            modelBuilder.Entity("Domain.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("AuthorId")
                        .HasColumnType("text");

                    b.Property<string>("Body")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("PostId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("PostId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Domain.Level", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<int>("CreditsNeeded")
                        .HasColumnType("integer");

                    b.Property<string>("LevelName")
                        .HasColumnType("text");

                    b.Property<int>("LevelNumber")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Level");
                });

            modelBuilder.Entity("Domain.MentorJobApplication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<byte[]>("CV")
                        .HasColumnType("bytea");

                    b.Property<string>("Category")
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<byte[]>("MotivationalLetter")
                        .HasColumnType("bytea");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("JobApplications");
                });

            modelBuilder.Entity("Domain.Message", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<string>("MentorId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("MentorId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Domain.Photo", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<bool>("IsMain")
                        .HasColumnType("boolean");

                    b.Property<string>("Url")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("Domain.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("MentorId")
                        .HasColumnType("text");

                    b.Property<int>("NumberOfCredits")
                        .HasColumnType("integer");

                    b.Property<string>("Picture")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<string>("Video")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("MentorId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Domain.Review", b =>
                {
                    b.Property<string>("MentorId")
                        .HasColumnType("text");

                    b.Property<string>("ClientId")
                        .HasColumnType("text");

                    b.Property<string>("Comment")
                        .HasColumnType("text");

                    b.Property<int>("StarRating")
                        .HasColumnType("integer");

                    b.HasKey("MentorId", "ClientId");

                    b.HasIndex("ClientId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Domain.Skill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("Domain.UserFollowing", b =>
                {
                    b.Property<string>("ObserverId")
                        .HasColumnType("text");

                    b.Property<string>("TargetId")
                        .HasColumnType("text");

                    b.HasKey("ObserverId", "TargetId");

                    b.HasIndex("TargetId");

                    b.ToTable("UserFollowings");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityRole");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Domain.Role", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityRole");

                    b.HasDiscriminator().HasValue("Role");
                });

            modelBuilder.Entity("AppUserRole", b =>
                {
                    b.HasOne("Domain.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.AppUser", b =>
                {
                    b.HasOne("Domain.Photo", "Photo")
                        .WithMany()
                        .HasForeignKey("PhotoId");

                    b.Navigation("Photo");
                });

            modelBuilder.Entity("Domain.AppUserCategory", b =>
                {
                    b.HasOne("Domain.AppUser", "AppUser")
                        .WithMany("Categories")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Category", "Category")
                        .WithMany("Mentors")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Domain.AppUserLevel", b =>
                {
                    b.HasOne("Domain.AppUser", "AppUser")
                        .WithMany("Levels")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Level", "Level")
                        .WithMany("Mentors")
                        .HasForeignKey("LevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("Level");
                });

            modelBuilder.Entity("Domain.AppUserSkill", b =>
                {
                    b.HasOne("Domain.AppUser", "Mentor")
                        .WithMany("Skills")
                        .HasForeignKey("MentorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Skill", "Skill")
                        .WithMany("Mentors")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mentor");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("Domain.CategorySkill", b =>
                {
                    b.HasOne("Domain.Category", "Category")
                        .WithMany("Skills")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Skill", "Skill")
                        .WithMany("Categories")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("Domain.Comment", b =>
                {
                    b.HasOne("Domain.AppUser", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId");

                    b.HasOne("Domain.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Author");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("Domain.Level", b =>
                {
                    b.HasOne("Domain.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Domain.Message", b =>
                {
                    b.HasOne("Domain.AppUser", "Mentor")
                        .WithMany()
                        .HasForeignKey("MentorId");

                    b.Navigation("Mentor");
                });

            modelBuilder.Entity("Domain.Post", b =>
                {
                    b.HasOne("Domain.AppUser", "Mentor")
                        .WithMany()
                        .HasForeignKey("MentorId");

                    b.Navigation("Mentor");
                });

            modelBuilder.Entity("Domain.Review", b =>
                {
                    b.HasOne("Domain.AppUser", "Client")
                        .WithMany("MentorReviews")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.AppUser", "Mentor")
                        .WithMany("ClientReviews")
                        .HasForeignKey("MentorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Mentor");
                });

            modelBuilder.Entity("Domain.UserFollowing", b =>
                {
                    b.HasOne("Domain.AppUser", "Observer")
                        .WithMany("Followings")
                        .HasForeignKey("ObserverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.AppUser", "Target")
                        .WithMany("Followers")
                        .HasForeignKey("TargetId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Observer");

                    b.Navigation("Target");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Domain.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Domain.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Domain.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.AppUser", b =>
                {
                    b.Navigation("Categories");

                    b.Navigation("ClientReviews");

                    b.Navigation("Followers");

                    b.Navigation("Followings");

                    b.Navigation("Levels");

                    b.Navigation("MentorReviews");

                    b.Navigation("Skills");
                });

            modelBuilder.Entity("Domain.Category", b =>
                {
                    b.Navigation("Mentors");

                    b.Navigation("Skills");
                });

            modelBuilder.Entity("Domain.Level", b =>
                {
                    b.Navigation("Mentors");
                });

            modelBuilder.Entity("Domain.Post", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("Domain.Skill", b =>
                {
                    b.Navigation("Categories");

                    b.Navigation("Mentors");
                });
#pragma warning restore 612, 618
        }
    }
}
