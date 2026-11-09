namespace Module1
{
    internal class CashPayment : IPaymentMethod
    {
        public string Name => "Готівкою";

        public bool Pay(double amount)
        {
            Console.WriteLine($"Оплата готівкою: {amount:F2} грн.");

            return true;
        }
    }
}
