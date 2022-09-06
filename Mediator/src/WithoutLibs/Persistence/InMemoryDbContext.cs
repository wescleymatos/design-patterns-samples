using WithoutLibs.Extensions;
using WithoutLibs.Persistence.Entities;

namespace WithoutLibs.Persistence
{
    public sealed class InMemoryDbContext
    {
        public List<Payment> Payments { get; private set; } = new();

        public InMemoryDbContext()
        {
            var rnd = new Random(5000);

            for (int i = 0; i < 10; i++)
            {
                Payments.Add(new Payment(Guid.NewGuid(), rnd.NextDecimal(), false));
            }
        }
    }
}
