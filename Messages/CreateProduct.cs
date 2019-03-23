namespace Akka.NetCore.Messages
{
    public class CreateProduct
    {
        public CreateProduct(string name, double cost, int amount)
        {
            Name = name;
            Cost = cost;
            Amount = amount;
        }

        public string Name { get; }
        public double Cost { get; }
        public int Amount { get; }
    }
}