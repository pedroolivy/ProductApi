using ProductApi.Domain.Enums;
using ProductApi.Domain.ValueObjects;

namespace ProductApi.Domain.Entities
{
    public class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public ProductType Type { get; private set; }
        public Price Price { get; private set; }

        private Product() { }

        public Product(string name, ProductType type, Price price)
        {
            ValidateName(name);
            ValidateType(type);

            Name = name;
            Type = type;
            Price = price;
        }

        public void Update(string name, ProductType type, Price price)
        {
            ValidateName(name);
            ValidateType(type);

            Name = name;
            Type = type;
            Price = price;
        }

        private static void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("O nome do produto é necessário");
        }

        private static void ValidateType(ProductType type)
        {
            if (!Enum.IsDefined(typeof(ProductType), type))
                throw new ArgumentException("Tipo de produto inválido");
        }
    }
}
