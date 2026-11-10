namespace Module1
{
    internal class Bike : Transport
    {

        public Bike(int id) : base(id, 5)
        {
        }

        public override double CalculateCost(Order order)
        {
            return 20 + 5 * order.Distance;
        }

        public override bool CanTake(Order order)
        {
            return base.CanTake(order) && order.Distance <= 10;
        }
    }
}
