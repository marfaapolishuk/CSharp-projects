namespace Module1
{
    internal class Car : Transport
    {

        public Car(int id) : base(id, 100)
        {
        }

        public override double CalculateCost(Order order)
        {
            return 50 + 8 * order.Distance + order.Weight;
        }
    }
}
