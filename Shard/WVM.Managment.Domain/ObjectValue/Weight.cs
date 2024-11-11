namespace WVM.Managment.Domain.ObjectValue
{
    public record Weight
    {
        public decimal Value { get; init; }

        public Weight(decimal value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Weight value Not Valid");
            }
            Value = value;
        }
    }
}
