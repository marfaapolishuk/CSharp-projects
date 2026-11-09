namespace Module1
{
    internal class DeliveryService
    {
        private List<Transport> transports = new List<Transport>();

        private List<Order> orders = new List<Order>();

        private List<Delivery> activeDeliveries = new List<Delivery>();

        private List<Delivery> deliveryHistory = new List<Delivery>();

        public void AddTransport(Transport transport)
        {
            if (transport == null)
            {
                Console.WriteLine("Помилка: транспорт не може бути порожнім.");
                return;
            }

            if (transports.Exists(t => t.ID == transport.ID))
            {
                Console.WriteLine("Транспорт з таким ID вже існує.");
                return;
            }

            transports.Add(transport);
        }

        public void AddOrder(Order order)
        {
            if (order == null)
            {
                Console.WriteLine("Помилка: замовлення не може бути порожнім.");
                return;
            }

            if (orders.Exists(o => o.ID == order.ID))
            {
                Console.WriteLine("Замовлення з таким ID вже існує.");
                return;
            }

            orders.Add(order);
        }

        private Order FindOrderById(int id)
        {
            return orders.Find(order => order.ID == id);
        }

        private Transport FindTransportById(int id)
        {
            return transports.Find(transport => transport.ID == id);
        }

        private string GetTransportName(Transport transport)
        {
            if (transport is Bike)
            {
                return "Велосипед";
            }

            if (transport is Car)
            {
                return "Автомобіль";
            }

            if (transport is Truck)
            {
                return "Вантажівка";
            }

            return "Транспорт";
        }

        public void ShowTransportCosts(int orderId)
        {
            Order order = FindOrderById(orderId);

            if (order == null)
            {
                Console.WriteLine("Помилка: замовлення не знайдено.");
                return;
            }

            Console.WriteLine($"\n--- Вартість доставки замовлення №{orderId} ---");

            bool found = false;

            foreach (Transport transport in transports)
            {
                if (transport.CanTake(order))
                {
                    string status;

                    if (transport.IsBusy)
                    {
                        status = "Зайнятий";
                    }
                    else
                    {
                        status = "Вільний";
                    }

                    double cost = transport.CalculateCost(order);

                    Console.WriteLine($"{GetTransportName(transport)} (ID: {transport.ID}) — {cost:F2} грн. Статус: {status}");

                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("Немає транспорту, який може виконати це замовлення.");
            }
        }

        public void AssignOrder(int orderId, int transportId)
        {
            Order order = FindOrderById(orderId);

            if (order == null)
            {
                Console.WriteLine("Помилка: замовлення не знайдено.");
                return;
            }

            Transport transport = FindTransportById(transportId);

            if (transport == null)
            {
                Console.WriteLine("Помилка: транспорт не знайдено.");
                return;
            }

            bool orderAlreadyAssigned = activeDeliveries.Exists(d => d.Order.ID == orderId) || deliveryHistory.Exists(d => d.Order.ID == orderId);

            if (orderAlreadyAssigned)
            {
                Console.WriteLine("Це замовлення вже призначене або доставлене.");

                return;
            }

            if (!transport.CanTake(order))
            {
                Console.WriteLine($"\nЗамовлення №{order.ID} не підходить для {GetTransportName(transport)}.");

                Console.WriteLine($"Характеристики замовлення: {order}");

                if (order.Weight > transport.MaxWeight)
                {
                    Console.WriteLine($"Причина: вага замовлення ({order.Weight} кг) перевищує ліміт транспорту ({transport.MaxWeight} кг).");
                }

                if (transport is Bike && order.Distance > 10)
                {
                    Console.WriteLine($"Причина: відстань доставки ({order.Distance} км) перевищує ліміт велосипеда (10 км).");
                }
                return;
            }

            if (transport.IsBusy)
            {
                Console.WriteLine($"Помилка: {GetTransportName(transport)} вже зайнятий.");
                return;
            }

            Delivery delivery = new Delivery(order, transport);

            activeDeliveries.Add(delivery);

            transport.MarkAsBusy();

            Console.WriteLine($"Замовлення №{order.ID} призначено на {GetTransportName(transport)}. Вартість доставки: {delivery.Cost:F2} грн.");
        }

        public void DeliverOrder(int orderId, IPaymentMethod payment)
        {
            Delivery delivery = activeDeliveries.Find(d => d.Order.ID == orderId);

            if (delivery == null)
            {
                Console.WriteLine("Помилка: активну доставку цього замовлення не знайдено.");
                return;
            }

            if (payment == null)
            {
                Console.WriteLine("Помилка: спосіб оплати не вказаний.");
                return;
            }

            bool success = delivery.Complete(payment);

            if (!success)
            {
                Console.WriteLine("Не вдалося завершити оплату.");
                return;
            }

            delivery.Transport.MarkAsAvailable();

            activeDeliveries.Remove(delivery);
            deliveryHistory.Add(delivery);

            Console.WriteLine($"Замовлення №{orderId} успішно доставлено. {GetTransportName(delivery.Transport)} звільнено.");
        }

        public void ShowActiveOrders()
        {
            Console.WriteLine("\nАктивні замовлення");

            if (activeDeliveries.Count == 0)
            {
                Console.WriteLine("Немає активних замовлень.");
                return;
            }

            foreach (Delivery delivery in activeDeliveries)
            {
                Console.WriteLine(delivery);
            }
        }

        public void ShowDeliveryHistory()
        {
            Console.WriteLine("\n--- Історія доставок ---");

            if (deliveryHistory.Count == 0)
            {
                Console.WriteLine("Історія доставок порожня.");
                return;
            }

            foreach (Delivery delivery in deliveryHistory)
            {
                Console.WriteLine(delivery);
            }
        }
    }
}
