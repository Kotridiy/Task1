using System;

namespace SweetTask
{
    class Candy : Sweet
    {
        public CandyFilling[] Fillings { get; private set; }
        public CandyGlaze Glaze { get; private set; }
        //public CandySprinkle Sprinkle { get; }

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
            Candy clone = (Candy) base.Clone();
            clone.Glaze = Glaze;
            clone.Fillings = (CandyFilling[]) Fillings.Clone();
            return clone;
        }

        public override string ToString()
        {
            return base.ToString();
        }
        
        public override string ToPrint()
        {
            return base.ToString();
        }
    }

    /*enum CandySprinkle
    {
        None,
        CocoaPowder,
        SugarPowder,
        ChokolatePowder,
        Nutes,
        WaffelChips,
        CoconutFlakes
    }*/
}
