using System;

namespace Akka.NetCore.DTO
{
    public class ProductDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public int Amount { get; set; }
    }
}