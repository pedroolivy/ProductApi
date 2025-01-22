namespace ProductApi.Domain.ValueObjects
{
    public class Price
    {
        public decimal Value { get; private set; }

        private Price() { }

        private Price(decimal value)
        {
            Value = value;
        }

        public static Price Create(decimal value)
        {
            Validate(value);
            return new Price(value);
        }

        private static void Validate(decimal value)
        {
            if (value <= 0)
                throw new ArgumentException("O preço deve ser maior que zero");
        }
    }
}
