using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsAPI.DTOS
{
    public class UpdateOrderDTO
    {
        public DateTime OrderDate { get; set; }
        [Required]
        [StringLength(100)]
        public string CustomerName { get; set; }

        [Required]
        [StringLength(500)]
        public string CustomerAddress { get; set; }

        [Required]
        [StringLength(50)]
        public string CustomerContact { get; set; }

        public List<OrderProductDTO> OrderProducts { get; set; }
    }
}