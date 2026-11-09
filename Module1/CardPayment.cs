namespace Module1
{
    internal class CardPayment : IPaymentMethod
    {
        public string Name => "Карткою";

        public bool Pay(double amount)
        {
            Console.WriteLine($"Оплата карткою: {amount:F2} грн.");

            return true;
        }
    }
}
