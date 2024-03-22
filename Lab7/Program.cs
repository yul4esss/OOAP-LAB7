namespace Lab7
{
    internal class Program
    {
        static List<Order> orders = new List<Order>();

        static void Main(string[] args)
        {
            // Creating the order and handling info using chain of responsibility
            OrderHandler customerNameHandler = new CustomerNameHandler();
            OrderHandler orderSizeHandler = new OrderSizeHandler();
            OrderHandler shippingFormHandler = new ShippingFormHandler();
            OrderHandler shippingAdressHandler = new ShippingAdressHandler();

            customerNameHandler.SetNextHandler(orderSizeHandler);
            orderSizeHandler.SetNextHandler(shippingFormHandler);
            shippingFormHandler.SetNextHandler(shippingAdressHandler);

            // Entering order through the consol
            Order order = new Order();
            Console.WriteLine("Enter customer name:");
            order.CustomerName = Console.ReadLine();
            Console.WriteLine("Enter order size:");
            order.OrderSize = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter shipping method:");
            order.ShippingForm = Console.ReadLine();
            Console.WriteLine("Enter destination:");
            order.ShippingAddress = Console.ReadLine();

            orders.Add(order);

            Console.WriteLine("Order placed successfully.");

            // Checking if order exist in "database"
            Console.WriteLine("Do you want to check the status of your order? (Y/N)");
            string checkStatus = Console.ReadLine();

            if (checkStatus.ToUpper() == "Y")
            {
                Console.WriteLine("Enter the order details to check its status:");
                Console.WriteLine("Enter customer name:");
                string checkCustomerName = Console.ReadLine();
                Console.WriteLine("Enter order size:");
                int checkOrderSize = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter shipping method:");
                string checkShippingMethod = Console.ReadLine();
                Console.WriteLine("Enter destination:");
                string checkDestination = Console.ReadLine();

                Order checkOrder = new Order
                {
                    CustomerName = checkCustomerName,
                    OrderSize = checkOrderSize,
                    ShippingForm = checkShippingMethod,
                    ShippingAddress = checkDestination
                };

                bool isOrderFound = false;
                foreach (Order o in orders)
                {
                    if (o.CustomerName == checkOrder.CustomerName &&
                        o.OrderSize == checkOrder.OrderSize &&
                        o.ShippingForm == checkOrder.ShippingForm &&
                        o.ShippingAddress == checkOrder.ShippingAddress)
                    {
                        isOrderFound = true;
                        bool orderHandled = customerNameHandler.HandleOrder(checkOrder);

                        if (orderHandled)
                        {
                            Console.WriteLine("Order processed successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Failed to process order.");
                        }

                        break;
                    }
                }

                if (!isOrderFound)
                {
                    Console.WriteLine("Order not found.");
                }
            }

            Console.ReadLine();
        }
    }
}
