using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Seeders
{
    public class RoomSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            for (int floor = 1; floor <= 5; floor++)
            {
                for (int roomOnFloor = 1; roomOnFloor <= 10; roomOnFloor++)
                {
                    bool isAvailable = (floor + roomOnFloor) % 2 == 0; 

                    modelBuilder.Entity<Room>().HasData(
                        new Room
                        {
                            Id = (floor - 1) * 10 + roomOnFloor,
                            RoomNumber = $"{floor * 100 + roomOnFloor}", 
                            RoomTypeId = roomOnFloor <= 4 ? roomOnFloor : 1,
                            PricePerNight = roomOnFloor switch
                            {
                                1 => 50m,
                                2 => 80m,
                                3 => 150m,
                                4 => 200m,
                                _ => 50m
                            },
                            Availability = isAvailable,
                            MaxOccupancyPersons = roomOnFloor switch
                            {
                                1 => 1,
                                2 => 2,
                                3 => 2,
                                4 => 4,
                                _ => 1
                            }
                        }
                    );
                }
            }
        }
    }
}
