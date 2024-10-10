using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsAPI.DTOS
{
    public class CreateOrderDTO
    {
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerContact { get; set; }
        public List<CreateOrderProductDTO> OrderProducts { get; set; }
    }
}