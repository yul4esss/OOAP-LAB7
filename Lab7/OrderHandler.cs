using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    abstract class OrderHandler
    {
        protected OrderHandler NextHandler;

        public void SetNextHandler(OrderHandler handler)
        {
            NextHandler = handler;
        }

        public abstract bool HandleOrder(Order order);
    }
}
