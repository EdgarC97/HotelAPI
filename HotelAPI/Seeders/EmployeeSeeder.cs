using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Seeders
{
    public class EmployeeSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, FirstName = "Luis", LastName = "Fernández", Email = "luis.fernandez@example.com", IdentificationNumber = "EMP123456", Password = "hashed_password_1" },
                new Employee { Id = 2, FirstName = "Clara", LastName = "Torres", Email = "clara.torres@example.com", IdentificationNumber = "EMP234567", Password = "hashed_password_2" },
                new Employee { Id = 3, FirstName = "Javier", LastName = "Ramírez", Email = "javier.ramirez@example.com", IdentificationNumber = "EMP345678", Password = "hashed_password_3" },
                new Employee { Id = 4, FirstName = "Elena", LastName = "Sánchez", Email = "elena.sanchez@example.com", IdentificationNumber = "EMP456789", Password = "hashed_password_4" }
            );
        }
    }
}