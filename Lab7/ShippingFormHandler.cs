using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    class ShippingFormHandler : OrderHandler
    {
        public override bool HandleOrder(Order order)
        {
            // Holding order by shipping form
            if (!string.IsNullOrEmpty(order.ShippingForm))
            {
                Console.WriteLine("Order handled by ShippingFormHandler");
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
