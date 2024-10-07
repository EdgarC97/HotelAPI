using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelAPI.Models
{
    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        [StringLength(10)]
        public string RoomNumber { get; set; }
        
        [Required]
        public int RoomTypeId { get; set; }
        
        [ForeignKey("RoomTypeId")]
        public virtual RoomType RoomType { get; set; }
        
        [Required]
        [Range(0, double.MaxValue)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal PricePerNight { get; set; }
        
        public bool Availability { get; set; }
        
        [Range(1, int.MaxValue)]
        public int MaxOccupancyPersons { get; set; }
        
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}