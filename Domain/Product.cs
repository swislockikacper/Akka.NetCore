using System;

namespace Akka.NetCore.Domain
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public int Amount { get; set; }
    }
}