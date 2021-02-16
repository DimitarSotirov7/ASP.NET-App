﻿// <auto-generated />
using System;
using Application.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Application.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210203130605_InitalSetup")]
    partial class InitalSetup
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Application.Models.Films_Game.Film", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Films");
                });

            modelBuilder.Entity("Application.Models.Films_Game.FilmAnswer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Context")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("FilmAnswers");
                });

            modelBuilder.Entity("Application.Models.Films_Game.FilmQuestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Context")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("FilmQustions");
                });

            modelBuilder.Entity("Application.Models.Films_Game.UserFilmQuestion", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<bool>("AnswerIsCorrect")
                        .HasColumnType("bit");

                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "QuestionId");

                    b.HasIndex("FilmId");

                    b.HasIndex("QuestionId");

                    b.ToTable("UserFilmQuestions");
                });

            modelBuilder.Entity("Application.Models.Q_A_Game.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Application.Models.Q_A_Game.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Context")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("Application.Models.Q_A_Game.UserQuestion", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<bool>("Answer")
                        .HasColumnType("bit");

                    b.HasKey("UserId", "QuestionId");

                    b.HasIndex("QuestionId");

                    b.ToTable("UsersQuestions");
                });

            modelBuilder.Entity("Application.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("CoverImageId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Joined")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PasswordHint")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProfileImageId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CoverImageId");

                    b.HasIndex("Password")
                        .IsUnique();

                    b.HasIndex("ProfileImageId");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Application.Models.UserStuffs.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CommentedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Context")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("FromUserId")
                        .HasColumnType("int");

                    b.Property<int?>("ImageId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("PostId")
                        .HasColumnType("int");

                    b.Property<int>("ToUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FromUserId");

                    b.HasIndex("ImageId");

                    b.HasIndex("PostId");

                    b.HasIndex("ToUserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Application.Models.UserStuffs.Follow", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("FromUserId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("ToUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FromUserId");

                    b.HasIndex("ToUserId");

                    b.ToTable("Follows");
                });

            modelBuilder.Entity("Application.Models.UserStuffs.Friendship", b =>
                {
                    b.Property<int>("RequesterId")
                        .HasColumnType("int");

                    b.Property<int>("ResponderId")
                        .HasColumnType("int");

                    b.Property<int?>("BlockedById")
                        .HasColumnType("int");

                    b.Property<bool>("IsAccepted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsBlocked")
                        .HasColumnType("bit");

                    b.HasKey("RequesterId", "ResponderId");

                    b.HasIndex("BlockedById");

                    b.HasIndex("ResponderId");

                    b.ToTable("Friendships");
                });

            modelBuilder.Entity("Application.Models.UserStuffs.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<byte[]>("ImageFile")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("UploadedOn")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("Application.Models.UserStuffs.Like", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("FromUserId")
                        .HasColumnType("int");

                    b.Property<int?>("ImageId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("PostId")
                        .HasColumnType("int");

                    b.Property<int>("ToUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FromUserId");

                    b.HasIndex("ImageId");

                    b.HasIndex("PostId");

                    b.HasIndex("ToUserId");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("Application.Models.UserStuffs.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Context")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("FromUserId")
                        .HasColumnType("int");

                    b.Property<int?>("ImageId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("Seen")
                        .HasColumnType("bit");

                    b.Property<DateTime>("SentOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("ToUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FromUserId");

                    b.HasIndex("ImageId");

                    b.HasIndex("ToUserId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Application.Models.UserStuffs.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Context")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("FromUserId")
                        .HasColumnType("int");

                    b.Property<int?>("ImageId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("PostOn")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ToUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FromUserId");

                    b.HasIndex("ImageId");

                    b.HasIndex("ToUserId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Application.Models.Films_Game.FilmAnswer", b =>
                {
                    b.HasOne("Application.Models.Films_Game.FilmQuestion", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("Application.Models.Films_Game.UserFilmQuestion", b =>
                {
                    b.HasOne("Application.Models.Films_Game.Film", "Film")
                        .WithMany()
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Application.Models.Films_Game.FilmQuestion", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Application.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Film");

                    b.Navigation("Question");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Application.Models.Q_A_Game.Question", b =>
                {
                    b.HasOne("Application.Models.Q_A_Game.Category", "Category")
                        .WithMany("Questions")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Application.Models.Q_A_Game.UserQuestion", b =>
                {
                    b.HasOne("Application.Models.Q_A_Game.Question", "Question")
                        .WithMany("Users")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Application.Models.User", "User")
                        .WithMany("Questions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Application.Models.User", b =>
                {
                    b.HasOne("Application.Models.UserStuffs.Image", "CoverImage")
                        .WithMany()
                        .HasForeignKey("CoverImageId");

                    b.HasOne("Application.Models.UserStuffs.Image", "ProfileImage")
                        .WithMany()
                        .HasForeignKey("ProfileImageId");

                    b.Navigation("CoverImage");

                    b.Navigation("ProfileImage");
                });

            modelBuilder.Entity("Application.Models.UserStuffs.Comment", b =>
                {
                    b.HasOne("Application.Models.User", "FromUser")
                        .WithMany("OwnComments")
                        .HasForeignKey("FromUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Application.Models.UserStuffs.Image", "Image")
                        .WithMany("Comments")
                        .HasForeignKey("ImageId");

                    b.HasOne("Application.Models.UserStuffs.Post", null)
                        .WithMany("Comments")
                        .HasForeignKey("PostId");

                    b.HasOne("Application.Models.User", "ToUser")
                        .WithMany("CommentsReceived")
                        .HasForeignKey("ToUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("FromUser");

                    b.Navigation("Image");

                    b.Navigation("ToUser");
                });

            modelBuilder.Entity("Application.Models.UserStuffs.Follow", b =>
                {
                    b.HasOne("Application.Models.User", "FromUser")
                        .WithMany("Followings")
                        .HasForeignKey("FromUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Application.Models.User", "ToUser")
                        .WithMany("Followers")
                        .HasForeignKey("ToUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("FromUser");

                    b.Navigation("ToUser");
                });

            modelBuilder.Entity("Application.Models.UserStuffs.Friendship", b =>
                {
                    b.HasOne("Application.Models.User", "BlockedBy")
                        .WithMany()
                        .HasForeignKey("BlockedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Application.Models.User", "Requester")
                        .WithMany("FriendshipRequests")
                        .HasForeignKey("RequesterId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Application.Models.User", "Responder")
                        .WithMany("FriendshipResponses")
                        .HasForeignKey("ResponderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("BlockedBy");

                    b.Navigation("Requester");

                    b.Navigation("Responder");
                });

            modelBuilder.Entity("Application.Models.UserStuffs.Image", b =>
                {
                    b.HasOne("Application.Models.User", null)
                        .WithMany("OtherImages")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Application.Models.UserStuffs.Like", b =>
                {
                    b.HasOne("Application.Models.User", "FromUser")
                        .WithMany("OwnLikes")
                        .HasForeignKey("FromUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Application.Models.UserStuffs.Image", null)
                        .WithMany("Likes")
                        .HasForeignKey("ImageId");

                    b.HasOne("Application.Models.UserStuffs.Post", null)
                        .WithMany("Likes")
                        .HasForeignKey("PostId");

                    b.HasOne("Application.Models.User", "ToUser")
                        .WithMany("LikesReceived")
                        .HasForeignKey("ToUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("FromUser");

                    b.Navigation("ToUser");
                });

            modelBuilder.Entity("Application.Models.UserStuffs.Message", b =>
                {
                    b.HasOne("Application.Models.User", "FromUser")
                        .WithMany("OwnMessages")
                        .HasForeignKey("FromUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Application.Models.UserStuffs.Image", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId");

                    b.HasOne("Application.Models.User", "ToUser")
                        .WithMany("MessagesReceived")
                        .HasForeignKey("ToUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("FromUser");

                    b.Navigation("Image");

                    b.Navigation("ToUser");
                });

            modelBuilder.Entity("Application.Models.UserStuffs.Post", b =>
                {
                    b.HasOne("Application.Models.User", "FromUser")
                        .WithMany("OwnPosts")
                        .HasForeignKey("FromUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Application.Models.UserStuffs.Image", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId");

                    b.HasOne("Application.Models.User", "ToUser")
                        .WithMany("PostsReceived")
                        .HasForeignKey("ToUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("FromUser");

                    b.Navigation("Image");

                    b.Navigation("ToUser");
                });

            modelBuilder.Entity("Application.Models.Films_Game.FilmQuestion", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("Application.Models.Q_A_Game.Category", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("Application.Models.Q_A_Game.Question", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Application.Models.User", b =>
                {
                    b.Navigation("CommentsReceived");

                    b.Navigation("Followers");

                    b.Navigation("Followings");

                    b.Navigation("FriendshipRequests");

                    b.Navigation("FriendshipResponses");

                    b.Navigation("LikesReceived");

                    b.Navigation("MessagesReceived");

                    b.Navigation("OtherImages");

                    b.Navigation("OwnComments");

                    b.Navigation("OwnLikes");

                    b.Navigation("OwnMessages");

                    b.Navigation("OwnPosts");

                    b.Navigation("PostsReceived");

                    b.Navigation("Questions");
                });

            modelBuilder.Entity("Application.Models.UserStuffs.Image", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Likes");
                });

            modelBuilder.Entity("Application.Models.UserStuffs.Post", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Likes");
                });
#pragma warning restore 612, 618
        }
    }
}