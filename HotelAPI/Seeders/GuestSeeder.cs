using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Seeders
{
    public class GuestSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Guest>().HasData(
                new Guest { Id = 1, FirstName = "Juan", LastName = "Pérez", Email = "juan.perez@example.com", IdentificationNumber = "ID123456", Birthdate = new DateTime(1990, 1, 1) },
                new Guest { Id = 2, FirstName = "María", LastName = "López", Email = "maria.lopez@example.com", IdentificationNumber = "ID234567", Birthdate = new DateTime(1985, 5, 15) },
                new Guest { Id = 3, FirstName = "Carlos", LastName = "García", Email = "carlos.garcia@example.com", IdentificationNumber = "ID345678", Birthdate = new DateTime(1992, 3, 10) },
                new Guest { Id = 4, FirstName = "Ana", LastName = "Martínez", Email = "ana.martinez@example.com", IdentificationNumber = "ID456789", Birthdate = new DateTime(1988, 7, 20) }
            );
        }
    }
}