namespace WithoutLibs.Extensions
{
    public static class RandomExtensions
    {
        public static decimal NextDecimal(this Random rng)
        {
            byte scale = (byte)rng.Next(29);
            bool sign = rng.Next(2) == 1;
            return new decimal(rng.Next(),
                               rng.Next(),
                               rng.Next(),
                               sign,
                               scale);
        }
    }
}
