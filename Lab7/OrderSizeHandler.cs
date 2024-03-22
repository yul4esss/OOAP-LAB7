using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    class OrderSizeHandler : OrderHandler
    {
        public override bool HandleOrder(Order order)
        {
            // Holding order by order size
            if (order.OrderSize > 0)
            {
                Console.WriteLine("Order handled by OrderSizeHandler");
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
