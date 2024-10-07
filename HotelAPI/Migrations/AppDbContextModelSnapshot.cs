﻿// <auto-generated />
using System;
using HotelAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HotelAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("HotelAPI.Models.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("GuestId")
                        .HasColumnType("int");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("TotalCost")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("GuestId");

                    b.HasIndex("RoomId");

                    b.ToTable("Bookings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EmployeeId = 1,
                            EndDate = new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GuestId = 1,
                            RoomId = 1,
                            StartDate = new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TotalCost = 200m
                        },
                        new
                        {
                            Id = 2,
                            EmployeeId = 1,
                            EndDate = new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GuestId = 2,
                            RoomId = 2,
                            StartDate = new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TotalCost = 560m
                        },
                        new
                        {
                            Id = 3,
                            EmployeeId = 2,
                            EndDate = new DateTime(2024, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GuestId = 3,
                            RoomId = 3,
                            StartDate = new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TotalCost = 300m
                        },
                        new
                        {
                            Id = 4,
                            EmployeeId = 2,
                            EndDate = new DateTime(2024, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GuestId = 4,
                            RoomId = 4,
                            StartDate = new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TotalCost = 800m
                        });
                });

            modelBuilder.Entity("HotelAPI.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("IdentificationNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "luis.fernandez@example.com",
                            FirstName = "Luis",
                            IdentificationNumber = "EMP123456",
                            LastName = "Fernández",
                            Password = "hashed_password_1"
                        },
                        new
                        {
                            Id = 2,
                            Email = "clara.torres@example.com",
                            FirstName = "Clara",
                            IdentificationNumber = "EMP234567",
                            LastName = "Torres",
                            Password = "hashed_password_2"
                        },
                        new
                        {
                            Id = 3,
                            Email = "javier.ramirez@example.com",
                            FirstName = "Javier",
                            IdentificationNumber = "EMP345678",
                            LastName = "Ramírez",
                            Password = "hashed_password_3"
                        },
                        new
                        {
                            Id = 4,
                            Email = "elena.sanchez@example.com",
                            FirstName = "Elena",
                            IdentificationNumber = "EMP456789",
                            LastName = "Sánchez",
                            Password = "hashed_password_4"
                        });
                });

            modelBuilder.Entity("HotelAPI.Models.Guest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("IdentificationNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Guests");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Birthdate = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "juan.perez@example.com",
                            FirstName = "Juan",
                            IdentificationNumber = "ID123456",
                            LastName = "Pérez",
                            PhoneNumber = "3007448596"
                        },
                        new
                        {
                            Id = 2,
                            Birthdate = new DateTime(1985, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "maria.lopez@example.com",
                            FirstName = "María",
                            IdentificationNumber = "ID234567",
                            LastName = "López",
                            PhoneNumber = "3017448596"
                        },
                        new
                        {
                            Id = 3,
                            Birthdate = new DateTime(1992, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "carlos.garcia@example.com",
                            FirstName = "Carlos",
                            IdentificationNumber = "ID345678",
                            LastName = "García",
                            PhoneNumber = "3027448596"
                        },
                        new
                        {
                            Id = 4,
                            Birthdate = new DateTime(1988, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "ana.martinez@example.com",
                            FirstName = "Ana",
                            IdentificationNumber = "ID456789",
                            LastName = "Martínez",
                            PhoneNumber = "3037448596"
                        });
                });

            modelBuilder.Entity("HotelAPI.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Availability")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("MaxOccupancyPersons")
                        .HasColumnType("int");

                    b.Property<decimal>("PricePerNight")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("RoomNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<int>("RoomTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoomTypeId");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Availability = true,
                            MaxOccupancyPersons = 1,
                            PricePerNight = 50m,
                            RoomNumber = "101",
                            RoomTypeId = 1
                        },
                        new
                        {
                            Id = 2,
                            Availability = false,
                            MaxOccupancyPersons = 2,
                            PricePerNight = 80m,
                            RoomNumber = "102",
                            RoomTypeId = 2
                        },
                        new
                        {
                            Id = 3,
                            Availability = true,
                            MaxOccupancyPersons = 2,
                            PricePerNight = 150m,
                            RoomNumber = "103",
                            RoomTypeId = 3
                        },
                        new
                        {
                            Id = 4,
                            Availability = false,
                            MaxOccupancyPersons = 4,
                            PricePerNight = 200m,
                            RoomNumber = "104",
                            RoomTypeId = 4
                        },
                        new
                        {
                            Id = 5,
                            Availability = true,
                            MaxOccupancyPersons = 1,
                            PricePerNight = 50m,
                            RoomNumber = "105",
                            RoomTypeId = 1
                        },
                        new
                        {
                            Id = 6,
                            Availability = false,
                            MaxOccupancyPersons = 1,
                            PricePerNight = 50m,
                            RoomNumber = "106",
                            RoomTypeId = 1
                        },
                        new
                        {
                            Id = 7,
                            Availability = true,
                            MaxOccupancyPersons = 1,
                            PricePerNight = 50m,
                            RoomNumber = "107",
                            RoomTypeId = 1
                        },
                        new
                        {
                            Id = 8,
                            Availability = false,
                            MaxOccupancyPersons = 1,
                            PricePerNight = 50m,
                            RoomNumber = "108",
                            RoomTypeId = 1
                        },
                        new
                        {
                            Id = 9,
                            Availability = true,
                            MaxOccupancyPersons = 1,
                            PricePerNight = 50m,
                            RoomNumber = "109",
                            RoomTypeId = 1
                        },
                        new
                        {
                            Id = 10,
                            Availability = false,
                            MaxOccupancyPersons = 1,
                            PricePerNight = 50m,
                            RoomNumber = "110",
                            RoomTypeId = 1
                        },
                        new
                        {
                            Id = 11,
                            Availability = false,
                            MaxOccupancyPersons = 1,
                            PricePerNight = 50m,
                            RoomNumber = "201",
                            RoomTypeId = 1
                        },
                        new
                        {
                            Id = 12,
                            Availability = true,
                            MaxOccupancyPersons = 2,
                            PricePerNight = 80m,
                            RoomNumber = "202",
                            RoomTypeId = 2
                        },
                        new
                        {
                            Id = 13,
                            Availability = false,
                            MaxOccupancyPersons = 2,
                            PricePerNight = 150m,
                            RoomNumber = "203",
                            RoomTypeId = 3
                        },
                        new
                        {
                            Id = 14,
                            Availability = true,
                            MaxOccupancyPersons = 4,
                            PricePerNight = 200m,
                            RoomNumber = "204",
                            RoomTypeId = 4
                        },
                        new
                        {
                            Id = 15,
                            Availability = false,
                            MaxOccupancyPersons = 1,
                            PricePerNight = 50m,
                            RoomNumber = "205",
                            RoomTypeId = 1
                        },
                        new
                        {
                            Id = 16,
                            Availability = true,
                            MaxOccupancyPersons = 1,
                            PricePerNight = 50m,
                            RoomNumber = "206",
                            RoomTypeId = 1
                        },
                        new
                        {
                            Id = 17,
                            Availability = false,
                            MaxOccupancyPersons = 1,
                            PricePerNight = 50m,
                            RoomNumber = "207",
                            RoomTypeId = 1
                        },
                        new
                        {
                            Id = 18,
                            Availability = true,
                            MaxOccupancyPersons = 1,
                            PricePerNight = 50m,
                            RoomNumber = "208",
                            RoomTypeId = 1
                        },
                        new
                        {
                            Id = 19,
                            Availability = false,
                            MaxOccupancyPersons = 1,
                            PricePerNight = 50m,
                            RoomNumber = "209",
                            RoomTypeId = 1
                        },
                        new
                        {
                            Id = 20,
                            Availability = true,
                            MaxOccupancyPersons = 1,
                            PricePerNight = 50m,
                            RoomNumber = "210",
                            RoomTypeId = 1
                        },
                        new
                        {
                            Id = 21,
                            Availability = true,
                            MaxOccupancyPersons = 1,
                            PricePerNight = 50m,
                            RoomNumber = "301",
                            RoomTypeId = 1
                        },
                        new
                        {
                            Id = 22,
                            Availability = false,
                            MaxOccupancyPersons = 2,
                            PricePerNight = 80m,
                            RoomNumber = "302",
                            RoomTypeId = 2
                        },
                        new
                        {
                            Id = 23,
                            Availability = true,
                            MaxOccupancyPersons = 2,
                            PricePerNight = 150m,
                            RoomNumber = "303",
                            RoomTypeId = 3
                        },
                        new
                        {
                            Id = 24,
                            Availability = false,
                            MaxOccupancyPersons = 4,
                            PricePerNight = 200m,
                            RoomNumber = "304",
                            RoomTypeId = 4
                        },
                        new
                        {
                            Id = 25,
                            Availability = true,
                            MaxOccupancyPersons = 1,
                            PricePerNight = 50m,
                            RoomNumber = "305",
                            RoomTypeId = 1
                        },
                        new
                        {
                            Id = 26,
                            Availability = false,
                            MaxOccupancyPersons = 1,
                            PricePerNight = 50m,
                            RoomNumber = "306",
                            RoomTypeId = 1
                        },
                        new
                        {
                            Id = 27,
                            Availability = true,
                            MaxOccupancyPersons = 1,
                            PricePerNight = 50m,
                            RoomNumber = "307",
                            RoomTypeId = 1
                        },
                        new
                        {
                            Id = 28,
                            Availability = false,
                            MaxOccupancyPersons = 1,
                            PricePerNight = 50m,
                            RoomNumber = "308",
                            RoomTypeId = 1
                        },
                        new
                        {
                            Id = 29,
                            Availability = true,
                            MaxOccupancyPersons = 1,
                            PricePerNight = 50m,
                            RoomNumber = "309",
                            RoomTypeId = 1
                        },
                        new
                        {
                            Id = 30,
                            Availability = false,
                            MaxOccupancyPersons = 1,
                            PricePerNight = 50m,
                            RoomNumber = "310",
                            RoomTypeId = 1
                        },
                        new
                        {
                            Id = 31,
                            Availability = false,
                            MaxOccupancyPersons = 1,
                            PricePerNight = 50m,
                            RoomNumber = "401",
                            RoomTypeId = 1
                        },
                        new
                        {
                            Id = 32,
                            Availability = true,
                            MaxOccupancyPersons = 2,
                            PricePerNight = 80m,
                            RoomNumber = "402",
                            RoomTypeId = 2
                        },
                        new
                        {
                            Id = 33,
                            Availability = false,
                            MaxOccupancyPersons = 2,
                            PricePerNight = 150m,
                            RoomNumber = "403",
                            RoomTypeId = 3
                        },
                        new
                        {
                            Id = 34,
                            Availability = true,
                            MaxOccupancyPersons = 4,
                            PricePerNight = 200m,
                            RoomNumber = "404",
                            RoomTypeId = 4
                        },
                        new
                        {
                            Id = 35,
                            Availability = false,
                            MaxOccupancyPersons = 1,
                            PricePerNight = 50m,
                            RoomNumber = "405",
                            RoomTypeId = 1
                        },
                        new
                        {
                            Id = 36,
                            Availability = true,
                            MaxOccupancyPersons = 1,
                            PricePerNight = 50m,
                            RoomNumber = "406",
                            RoomTypeId = 1
                        },
                        new
                        {
                            Id = 37,
                            Availability = false,
                            MaxOccupancyPersons = 1,
                            PricePerNight = 50m,
                            RoomNumber = "407",
                            RoomTypeId = 1
                        },
                        new
                        {
                            Id = 38,
                            Availability = true,
                            MaxOccupancyPersons = 1,
                            PricePerNight = 50m,
                            RoomNumber = "408",
                            RoomTypeId = 1
                        },
                        new
                        {
                            Id = 39,
                            Availability = false,
                            MaxOccupancyPersons = 1,
                            PricePerNight = 50m,
                            RoomNumber = "409",
                            RoomTypeId = 1
                        },
                        new
                        {
                            Id = 40,
                            Availability = true,
                            MaxOccupancyPersons = 1,
                            PricePerNight = 50m,
                            RoomNumber = "410",
                            RoomTypeId = 1
                        },
                        new
                        {
                            Id = 41,
                            Availability = true,
                            MaxOccupancyPersons = 1,
                            PricePerNight = 50m,
                            RoomNumber = "501",
                            RoomTypeId = 1
                        },
                        new
                        {
                            Id = 42,
                            Availability = false,
                            MaxOccupancyPersons = 2,
                            PricePerNight = 80m,
                            RoomNumber = "502",
                            RoomTypeId = 2
                        },
                        new
                        {
                            Id = 43,
                            Availability = true,
                            MaxOccupancyPersons = 2,
                            PricePerNight = 150m,
                            RoomNumber = "503",
                            RoomTypeId = 3
                        },
                        new
                        {
                            Id = 44,
                            Availability = false,
                            MaxOccupancyPersons = 4,
                            PricePerNight = 200m,
                            RoomNumber = "504",
                            RoomTypeId = 4
                        },
                        new
                        {
                            Id = 45,
                            Availability = true,
                            MaxOccupancyPersons = 1,
                            PricePerNight = 50m,
                            RoomNumber = "505",
                            RoomTypeId = 1
                        },
                        new
                        {
                            Id = 46,
                            Availability = false,
                            MaxOccupancyPersons = 1,
                            PricePerNight = 50m,
                            RoomNumber = "506",
                            RoomTypeId = 1
                        },
                        new
                        {
                            Id = 47,
                            Availability = true,
                            MaxOccupancyPersons = 1,
                            PricePerNight = 50m,
                            RoomNumber = "507",
                            RoomTypeId = 1
                        },
                        new
                        {
                            Id = 48,
                            Availability = false,
                            MaxOccupancyPersons = 1,
                            PricePerNight = 50m,
                            RoomNumber = "508",
                            RoomTypeId = 1
                        },
                        new
                        {
                            Id = 49,
                            Availability = true,
                            MaxOccupancyPersons = 1,
                            PricePerNight = 50m,
                            RoomNumber = "509",
                            RoomTypeId = 1
                        },
                        new
                        {
                            Id = 50,
                            Availability = false,
                            MaxOccupancyPersons = 1,
                            PricePerNight = 50m,
                            RoomNumber = "510",
                            RoomTypeId = 1
                        });
                });

            modelBuilder.Entity("HotelAPI.Models.RoomType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("RoomTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Una acogedora habitación básica con una cama individual, ideal para viajeros solos.",
                            Name = "Habitación Simple"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Ofrece flexibilidad con dos camas individuales o una cama doble, perfecta para parejas o amigos.",
                            Name = "Habitación Doble"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Espaciosa y lujosa, con una cama king size y una sala de estar separada, ideal para quienes buscan confort y exclusividad.",
                            Name = "Suite"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Diseñada para familias, con espacio adicional y varias camas para una estancia cómoda.",
                            Name = "Habitación Familiar"
                        });
                });

            modelBuilder.Entity("HotelAPI.Models.Booking", b =>
                {
                    b.HasOne("HotelAPI.Models.Employee", "Employee")
                        .WithMany("Bookings")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelAPI.Models.Guest", "Guest")
                        .WithMany("Bookings")
                        .HasForeignKey("GuestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelAPI.Models.Room", "Room")
                        .WithMany("Bookings")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Guest");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("HotelAPI.Models.Room", b =>
                {
                    b.HasOne("HotelAPI.Models.RoomType", "RoomType")
                        .WithMany("Rooms")
                        .HasForeignKey("RoomTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RoomType");
                });

            modelBuilder.Entity("HotelAPI.Models.Employee", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("HotelAPI.Models.Guest", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("HotelAPI.Models.Room", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("HotelAPI.Models.RoomType", b =>
                {
                    b.Navigation("Rooms");
                });
#pragma warning restore 612, 618
        }
    }
}
