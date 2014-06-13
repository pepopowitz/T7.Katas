namespace T7.Katas.Bowling
{
    public class BallContext
    {
        public char Raw { get; set; }
        public int Value { get; set; }
        public int IncludeNextThrows { get; set; }
        public int Frame { get; set; }
    }
}