using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    class CustomerNameHandler : OrderHandler
    {
        public override bool HandleOrder(Order order)
        {
            // Holding order by customer name
            if (!string.IsNullOrEmpty(order.CustomerName))
            {
                Console.WriteLine("Order handled by CustomerNameHandler");
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
