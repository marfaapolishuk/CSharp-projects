namespace Module1
{
    internal interface IPaymentMethod
    {
        string Name { get; }

        bool Pay(double amount);
    }
}
