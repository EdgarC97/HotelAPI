using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsAPI.DTOS
{
    public class CreateOrderProductDTO
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}