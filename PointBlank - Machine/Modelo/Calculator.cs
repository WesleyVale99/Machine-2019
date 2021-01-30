namespace PointBlank___Machine
{
    public class Calculator
    {
        public int seed;

        static readonly Calculator INSTANCE = new Calculator();
        public  static Calculator INST() => INSTANCE;
        public int GetNextSessionSeed()
        {
            return seed = (ushort)(seed * 214013 + 2531011 >> 16 & short.MaxValue);
        }
    }
}
