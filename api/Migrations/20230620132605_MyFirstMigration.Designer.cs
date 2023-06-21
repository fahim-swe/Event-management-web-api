﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using repository.StoreContext;

#nullable disable

namespace api.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230620132605_MyFirstMigration")]
    partial class MyFirstMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("model.Entities.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("DetailsInfo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("VattingLastTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("model.Entities.EventLocation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("LocationId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("EventId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id", "LocationId", "EventId");

                    b.HasIndex("EventId");

                    b.HasIndex("LocationId");

                    b.ToTable("EventLocation");
                });

            modelBuilder.Entity("model.Entities.EventParticipant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("EventId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ParticipantId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id", "EventId", "ParticipantId");

                    b.HasIndex("EventId");

                    b.HasIndex("ParticipantId");

                    b.HasIndex("UserId");

                    b.ToTable("EventParticipant");
                });

            modelBuilder.Entity("model.Entities.EventPreferenceTime", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("EventId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("PreferenceTimeId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("PreferenceDateTimeId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id", "EventId", "PreferenceTimeId");

                    b.HasIndex("EventId");

                    b.HasIndex("PreferenceDateTimeId");

                    b.ToTable("EventPreferenceTimes");
                });

            modelBuilder.Entity("model.Entities.Location", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("model.Entities.Participant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("ParticipantId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ParticipantInfoId")
                        .HasColumnType("char(36)");

                    b.Property<int>("ParticipantType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParticipantInfoId");

                    b.ToTable("Participants");
                });

            modelBuilder.Entity("model.Entities.PreferenceDateTime", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<TimeOnly>("Time")
                        .HasColumnType("time(6)");

                    b.HasKey("Id");

                    b.ToTable("DateTimes");
                });

            modelBuilder.Entity("model.Entities.SocialMedia", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("EventId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("SocialMedia");
                });

            modelBuilder.Entity("model.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("longblob");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("longblob");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("model.Entities.EventLocation", b =>
                {
                    b.HasOne("model.Entities.Event", "Event")
                        .WithMany("EventLocations")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("model.Entities.Location", "location")
                        .WithMany("EventLocations")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("location");
                });

            modelBuilder.Entity("model.Entities.EventParticipant", b =>
                {
                    b.HasOne("model.Entities.Event", "Event")
                        .WithMany("EventParticipants")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("model.Entities.Participant", "Participant")
                        .WithMany("EventParticipants")
                        .HasForeignKey("ParticipantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("model.Entities.User", null)
                        .WithMany("EventParticipants")
                        .HasForeignKey("UserId");

                    b.Navigation("Event");

                    b.Navigation("Participant");
                });

            modelBuilder.Entity("model.Entities.EventPreferenceTime", b =>
                {
                    b.HasOne("model.Entities.Event", "Event")
                        .WithMany("EventPreferenceTimes")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("model.Entities.PreferenceDateTime", "PreferenceDateTime")
                        .WithMany("EventPreferenceTimes")
                        .HasForeignKey("PreferenceDateTimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("PreferenceDateTime");
                });

            modelBuilder.Entity("model.Entities.Participant", b =>
                {
                    b.HasOne("model.Entities.User", "ParticipantInfo")
                        .WithMany()
                        .HasForeignKey("ParticipantInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParticipantInfo");
                });

            modelBuilder.Entity("model.Entities.SocialMedia", b =>
                {
                    b.HasOne("model.Entities.Event", "Event")
                        .WithMany("EventSocialMediaLinks")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");
                });

            modelBuilder.Entity("model.Entities.Event", b =>
                {
                    b.Navigation("EventLocations");

                    b.Navigation("EventParticipants");

                    b.Navigation("EventPreferenceTimes");

                    b.Navigation("EventSocialMediaLinks");
                });

            modelBuilder.Entity("model.Entities.Location", b =>
                {
                    b.Navigation("EventLocations");
                });

            modelBuilder.Entity("model.Entities.Participant", b =>
                {
                    b.Navigation("EventParticipants");
                });

            modelBuilder.Entity("model.Entities.PreferenceDateTime", b =>
                {
                    b.Navigation("EventPreferenceTimes");
                });

            modelBuilder.Entity("model.Entities.User", b =>
                {
                    b.Navigation("EventParticipants");
                });
#pragma warning restore 612, 618
        }
    }
}
