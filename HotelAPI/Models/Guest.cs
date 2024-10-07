using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelAPI.Models
{
    public class Guest
    {
        // Unique identifier for the guest, auto-generated by the database
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // First name of the guest, required and limited to 255 characters
        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }

        // Last name of the guest, required and limited to 255 characters
        [Required]
        [StringLength(255)]
        public string LastName { get; set; }

        // Email address of the guest, required, validated for email format, and limited to 255 characters
        [Required]
        [EmailAddress]
        [StringLength(255)]
        public string Email { get; set; }

        // Identification number of the guest, required and limited to 20 characters
        [Required]
        [StringLength(20)]
        public string IdentificationNumber { get; set; }

        // Phone number of the guest, optional but validated for phone format, and limited to 20 characters
        [Phone]
        [StringLength(20)]
        public string PhoneNumber { get; set; }

        // Birthdate of the guest, required field
        [Required]
        public DateTime Birthdate { get; set; }

        // Navigation property for related bookings, allows access to all bookings made by this guest
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
