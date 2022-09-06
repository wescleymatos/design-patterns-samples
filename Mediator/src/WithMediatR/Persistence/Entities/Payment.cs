namespace WithMediatR.Persistence.Entities
{
    public sealed class Payment
    {
        public Guid Id { get; private set; }
        public decimal Value { get; private set; }
        public bool Paid { get; private set; }

        public Payment(Guid id, decimal value, bool paid)
        {
            Id = id;
            Value = value;
            Paid = paid;
        }

        public void Pay()
        {
            Paid = true;
        }
    }
}
