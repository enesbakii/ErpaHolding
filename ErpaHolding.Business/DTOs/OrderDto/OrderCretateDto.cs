using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpaHolding.Business.DTOs.OrderDto
{
    public class OrderCretateDto
    {
        public Guid UserId { get; set; }
        public decimal OrderTotal { get; set; }
        public DateTime OrderDate { get; set; }

        public int CartTotalItems { get; set; }

        public bool OrderStatus { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
