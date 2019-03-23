using System;

namespace Akka.NetCore.Messages
{
    public class GetProductById
    {
        public GetProductById(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }

    public class ProductNotFound
    {
        private ProductNotFound() 
        { 
        }

        public static ProductNotFound Instance { get; } = new ProductNotFound();
    }
}