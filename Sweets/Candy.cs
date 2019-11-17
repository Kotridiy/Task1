using System;

namespace SweetTask.Base
{
    public class Candy : Sweet
    {
        /// <summary>
        /// One or more candy bases and fillers.
        /// </summary>
        public CandyFilling[] Fillings { get; private set; }
        /// <summary>
        /// Candy glaze.
        /// </summary>
        public CandyGlaze Glaze { get; private set; }

        private Candy(string name, string country, float weight, float sugar,
            CandyGlaze glaze)
            : base(name, country, weight, sugar)
        {
            Glaze = glaze;
        }

        public Candy(string name, string country, float weight, float sugar,
            CandyGlaze glaze, params CandyFilling[] fillings)
            : this(name, country, weight, sugar, glaze)
        {
            if (fillings.Length == 0)
            {
                throw new ArgumentNullException(nameof(fillings));
            }
            this.Fillings = fillings;
        }

        public Candy(string name, string country, float weight, float sugar,
            CandyGlaze glaze, CandyFilling filling)
            : this(name, country, weight, sugar, glaze)
        {
            this.Fillings = new CandyFilling[] { filling };
        }

        public Candy(string name, string country, float weight, float sugar, CandyFilling filling)
            : this(name, country, weight, sugar, CandyGlaze.None, filling)
        {

        }

        public Candy(string name, string country, float weight, float sugar, params CandyFilling[] fillings)
            : this(name, country, weight, sugar, CandyGlaze.None, fillings)
        {
            
        }

        internal override Sweet Clone()
        {
            Candy clone = (Candy)MemberwiseClone();
            clone.Id = Guid.NewGuid();
            clone.Fillings = (CandyFilling[]) Fillings.Clone();
            return clone;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        /// <summary>
        /// Print to console.
        /// </summary>
        public override string ToPrint()
        {
            return base.ToString();
        }
    }
}