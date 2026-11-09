namespace Module1
{
    internal abstract class Transport
    {
        public int ID { get; }
        public double MaxWeight { get; }
        public bool IsBusy { get; private set; }

        protected Transport(int id, double maxWeight)
        {
            ID = id;
            MaxWeight = maxWeight;
            IsBusy = false;
        }

        public abstract double CalculateCost(Order order);

        public virtual bool CanTake(Order order)
        {
            return order.Weight <= MaxWeight;
        }

        public void MarkAsBusy()
        {
            IsBusy = true;
        }

        public void MarkAsAvailable()
        {
            IsBusy = false;
        }
    }
}
