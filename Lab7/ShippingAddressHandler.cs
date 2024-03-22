using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    class ShippingAdressHandler : OrderHandler
    {
        public override bool HandleOrder(Order order)
        {
            // Holding order by shipping adress
            if (!string.IsNullOrEmpty(order.ShippingAddress))
            {
                Console.WriteLine("Order handled by DestinationHandler");
                return true;
            }
            else if (NextHandler != null)
            {
                return NextHandler.HandleOrder(order);
            }
            else
            {
                Console.WriteLine("Order cannot be handled");
                return false;
            }
        }
    }
}
