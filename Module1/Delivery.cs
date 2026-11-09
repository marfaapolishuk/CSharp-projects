namespace Module1
{
    internal class Delivery
    {
        public Order Order { get; }
        public Transport Transport { get; }
        public double Cost { get; }
        public bool IsCompleted { get; private set; }
        public string PaymentMethodName { get; private set; }

        public Delivery(Order order, Transport transport)
        {
            Order = order;
            Transport = transport;
            Cost = transport.CalculateCost(order);

            IsCompleted = false;
            PaymentMethodName = "Не оплачено";
        }

        public bool Complete(IPaymentMethod payment)
        {
            if (payment == null || IsCompleted)
            {
                return false;
            }

            bool success = payment.Pay(Cost);

            if (!success)
            {
                return false;
            }

            PaymentMethodName = payment.Name;
            IsCompleted = true;

            return true;
        }

        public override string ToString()
        {
            string status;

            if (IsCompleted)
            {
                status = $"Завершено, оплата: {PaymentMethodName}";
            }
            else
            {
                status = "Доставка виконується";
            }

            return $"Замовлення №{Order.ID}: {Order.Description}, транспорт: {Transport.GetType().Name}, вартість: {Cost:F2} грн, статус: {status}";
        }
    }

}
