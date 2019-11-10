using System;
using System.Collections.Generic;
using System.Text;

namespace SweetTask
{
    class Candy : Item
    {
        private readonly CandyFilling[] fillings;
        private readonly CandyGlaze glaze;
        private readonly CandySprinkle sprinkle;

        public float Sugar { get; }
        /*private readonly float sugar;
        public float Sugar
        {
            get => sugar;
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentOutOfRangeException();
                }
                sugar = value;
            }
        }*/

        public CandyFilling[] GetFillings => fillings;
        public CandyGlaze GetGlaze => glaze;
        public CandySprinkle GetSprinkle => sprinkle;

        private Candy(string name, float weight,string country, float sugar, 
            CandyGlaze glaze, CandySprinkle sprinkle)
            : base(name, weight, country)
        {
            if (sugar < 0 || sugar > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(sugar));
            }

            Sugar = sugar;

            this.glaze = glaze;
            this.sprinkle = sprinkle;
        }

        public Candy(string name, float weight, string country, float sugar,
            CandyGlaze glaze, CandySprinkle sprinkle, params CandyFilling[] fillings)
            : this(name, weight, country, sugar, glaze, sprinkle)
        {
            if (fillings.Length == 0)
            {
                throw new ArgumentNullException(nameof(fillings));
            }
            this.fillings = fillings;
        }

        public Candy(string name, float weight, string country, float sugar,
            CandyGlaze glaze, CandySprinkle sprinkle, CandyFilling filling)
            : this(name, weight,country, sugar, glaze, sprinkle)
        {
            this.fillings = new CandyFilling[] { filling };
        }

        public Candy(string name, float weight, string country, float sugar, CandyFilling filling)
            : this(name, weight, country, sugar, CandyGlaze.None, CandySprinkle.None, filling)
        {

        }

        public Candy(string name, float weight, string country, float sugar, params CandyFilling[] fillings)
            : this(name, weight, country, sugar, CandyGlaze.None, CandySprinkle.None, fillings)
        {
            
        }
    }

    enum CandyFilling
    {
        Iris,
        Waffle,
        BubbleGum,
        Caramel,
        Loloipop,
        Fondant,
        Milk,
        Praline,
        Fruit,
        Jelli,
        JelliFruit,
        Cream,
        Marzipan,
        Liquor,
        BlastedCereal,
        Roasting
    }

    enum CandyGlaze
    {
        None = 0,
        Chokolate = 1,
        Caramel = 2,
        Fondant = 3,
        Fat = 4
    }

    enum CandySprinkle
    {
        None,
        CocoaPowder,
        SugarPowder,
        ChokolatePowder,
        Nutes,
        WaffelChips,
        CoconutFlakes
    }
}
