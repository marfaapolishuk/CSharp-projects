namespace Module1
{
    internal class Order
    {
        public int ID { get; }
        public string Description { get; }
        public double Weight { get; }
        public double Distance { get; }

        public Order(int id, string description, double weight, double distance)
        {
            ID = id;
            Description = description;
            Weight = weight;
            Distance = distance;
        }

        public override string ToString()
        {
            return $"Замовлення №{ID}: {Description}, вага: {Weight} кг, відстань: {Distance} км";

        }
    }
}
