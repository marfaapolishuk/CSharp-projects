namespace Module1
{
    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            DeliveryService deliveryService = new DeliveryService();

            Bike bike = new Bike(1);
            Car car = new Car(2);
            Truck truck = new Truck(3);

            deliveryService.AddTransport(bike);
            deliveryService.AddTransport(car);
            deliveryService.AddTransport(truck);

            Console.WriteLine("\n========== ПОВТОРНЕ ДОДАВАННЯ ТРАНСПОРТУ ==========");

            deliveryService.AddTransport(new Bike(1));

            Order order1 = new Order(1, "Книги", 3, 8);
            Order order2 = new Order(2, "Побутова техніка", 20, 25);
            Order order3 = new Order(3, "Меблі", 300, 50);
            Order order4 = new Order(4, "Документи", 1, 5);

            // Додаткові замовлення для перевірки обмежень
            Order order5 = new Order(5, "Будівельні матеріали", 1200, 50);
            Order order6 = new Order(6, "Конструктор LEGO", 2, 15);

            deliveryService.AddOrder(order1);
            deliveryService.AddOrder(order2);
            deliveryService.AddOrder(order3);
            deliveryService.AddOrder(order4);
            deliveryService.AddOrder(order5);
            deliveryService.AddOrder(order6);

            Console.WriteLine("\n========== ПОВТОРНЕ ДОДАВАННЯ ЗАМОВЛЕННЯ ==========");

            deliveryService.AddOrder(new Order(1, "Мультиварка", 2, 5));


            Console.WriteLine("\n========== ПОЧАТКОВИЙ СТАН СИСТЕМИ ==========");

            deliveryService.ShowActiveOrders();
            deliveryService.ShowDeliveryHistory();

            Console.WriteLine("\n========== ПЕРЕВІРКА ПОШУКУ ==========");

            deliveryService.ShowTransportCosts(99);
            deliveryService.AssignOrder(99, 1);
            deliveryService.AssignOrder(1, 99);


            Console.WriteLine("\n========== ВАРТІСТЬ ДОСТАВКИ ==========");

            deliveryService.ShowTransportCosts(1);
            deliveryService.ShowTransportCosts(2);
            deliveryService.ShowTransportCosts(3);
            deliveryService.ShowTransportCosts(4);
            deliveryService.ShowTransportCosts(5);
            deliveryService.ShowTransportCosts(6);


            Console.WriteLine("\n========== ПЕРЕВІРКА ОБМЕЖЕНЬ ==========");

            deliveryService.AssignOrder(2, 1);
            deliveryService.AssignOrder(3, 2);
            deliveryService.AssignOrder(5, 3);
            deliveryService.AssignOrder(6, 1);


            Console.WriteLine("\n========== ПРИЗНАЧЕННЯ ЗАМОВЛЕНЬ ==========");

            deliveryService.AssignOrder(1, 1);
            deliveryService.AssignOrder(2, 2);
            deliveryService.AssignOrder(3, 3);


            Console.WriteLine("\n========== ПОВТОРНЕ ПРИЗНАЧЕННЯ ЗАМОВЛЕННЯ ==========");

            deliveryService.AssignOrder(1, 2);


            Console.WriteLine("\n========== ПЕРЕВІРКА ЗАЙНЯТОСТІ ==========");

            deliveryService.AssignOrder(4, 1);


            Console.WriteLine("\n========== АКТИВНІ ЗАМОВЛЕННЯ ==========");

            deliveryService.ShowActiveOrders();


            Console.WriteLine("\n========== ПЕРЕВІРКА ЗАВЕРШЕННЯ ДОСТАВКИ ==========");

            deliveryService.DeliverOrder(99, new CardPayment());


            Console.WriteLine("\n========== ОПЛАТА КАРТКОЮ ==========");

            deliveryService.DeliverOrder(1, new CardPayment());


            Console.WriteLine("\n========== ПОВТОРНЕ ПРИЗНАЧЕННЯ ДОСТАВЛЕНОГО ЗАМОВЛЕННЯ ==========");

            deliveryService.AssignOrder(1, 2);


            Console.WriteLine("\n========== ПОВТОРНЕ ПРИЗНАЧЕННЯ ТРАНСПОРТУ ==========");

            deliveryService.AssignOrder(4, 1);


            Console.WriteLine("\n========== ОПЛАТА ГОТІВКОЮ ==========");

            deliveryService.DeliverOrder(4, new CashPayment());


            Console.WriteLine("\n========== ЗАВЕРШЕННЯ ІНШИХ ДОСТАВОК ==========");

            deliveryService.DeliverOrder(2, new CashPayment());
            deliveryService.DeliverOrder(3, new CardPayment());


            Console.WriteLine("\n========== ПОВТОРНЕ ЗАВЕРШЕННЯ ДОСТАВКИ ==========");

            deliveryService.DeliverOrder(1, new CashPayment());


            Console.WriteLine("\n========== ФІНАЛЬНІ АКТИВНІ ЗАМОВЛЕННЯ ==========");

            deliveryService.ShowActiveOrders();


            Console.WriteLine("\n========== ІСТОРІЯ ДОСТАВОК ==========");

            deliveryService.ShowDeliveryHistory();
        }
    }
}
