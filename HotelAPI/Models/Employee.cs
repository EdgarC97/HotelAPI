using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelAPI.Models
{
    public class Employee
    {
        // Unique identifier for the employee, auto-generated by the database
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // First name of the employee, required and limited to 50 characters
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        // Last name of the employee, required and limited to 50 characters
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        // Email address of the employee, required, validated for email format, and limited to 255 characters
        [Required]
        [EmailAddress]
        [StringLength(255)]
        public string Email { get; set; }

        // Identification number of the employee, required and limited to 20 characters
        [Required]
        [StringLength(20)]
        public string IdentificationNumber { get; set; }

        // Password for the employee account, required and limited to 255 characters
        [Required]
        [StringLength(255)]
        public string Password { get; set; }

        // Navigation property for related bookings, allows access to all bookings managed by this employee
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
