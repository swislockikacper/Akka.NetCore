using System;
using System.Collections.Generic;
using System.Linq;
using Akka.Actor;
using Akka.NetCore.DTO;
using Akka.NetCore.Messages;

namespace Akka.NetCore.Domain
{
    public class ProductsManagerActor : ReceiveActor
    {
        private readonly Dictionary<Guid, Product> products = new Dictionary<Guid, Product>();

        public ProductsManagerActor()
        {
            Receive<CreateProduct>(command =>
            {
                var newProduct = new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = command.Name,
                    Amount = command.Amount,
                    Cost = command.Cost
                };

                products.Add(newProduct.Id, newProduct);
            });

            Receive<GetProductById>(query =>
            {
                if (products.TryGetValue(query.Id, out var product))
                    Sender.Tell(GetProductDTO(product));
                else
                    Sender.Tell(ProductNotFound.Instance);
            });

            Receive<GetProducts>(query =>
            {
                Sender.Tell(products.Select(p => GetProductDTO(p.Value)).ToList());
            });
        }

        private ProductDTO GetProductDTO(Product product)
            => new ProductDTO()
            {
                Id = product.Id,
                Name = product.Name,
                Amount = product.Amount,
                Cost = product.Cost
            };
    }
}