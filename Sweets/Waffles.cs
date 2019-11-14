using System;

namespace SweetTask.Base
{
    public class Waffles : Sweet
    {
        public WaffleType WaffleType { get; private set; }
        public int WaffleCount { get; private set; }
        public bool Glased { get; private set; }

        public Waffles(string name, string country, float weight, float sugar,
            WaffleType waffleType, int waffleCount = 6, bool glased = false)
            : base(name, country, weight, sugar)
        {
            if (waffleCount < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(waffleCount));
            }

            WaffleType = waffleType;
            WaffleCount = waffleCount;
            Glased = glased;
        }

        internal override Sweet Clone()
        {
            return (Waffles)MemberwiseClone();
        }

        public override string ToString()
        {
            return base.ToString() + $", C = {WaffleCount}";
        }

        public override string ToPrint()
        {
            return base.ToString() + $", {WaffleCount} waffles";
        }
    }
}
