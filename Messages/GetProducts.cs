namespace Akka.NetCore.Messages
{
    public class GetProducts
    {
        private GetProducts()
        {
        }

        public static GetProducts Instance { get; } = new GetProducts();
    }
}