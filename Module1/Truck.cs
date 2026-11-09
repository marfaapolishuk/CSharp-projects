namespace Module1
{
    internal class Truck : Transport
    {

        public Truck(int id) : base(id, 1000)
        {
        }

        public override double CalculateCost(Order order)
        {
            return 200 + 15 * order.Distance + 0.5 * order.Weight;
        }
    }
}
