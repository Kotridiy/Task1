using SweetTask.BaseModel.Enums;
using System;

namespace SweetTask.BaseModel.Sweets
{
    public class Chocolate : Sweet
    {
        public int Rows { get; private set; }
        public int Columns { get; private set; }
        public ChocolateType ChocolateType { get; private set; }
        public ChocolateFilling Filling { get; private set; }

        public Chocolate(string name, string country, float weight, float sugar,
            ChocolateType chocolateType, ChocolateFilling filling, int rows = 4, int columns = 3)
            : base(name, country, weight, sugar)
        {
            if (rows < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(rows));
            }
            if (columns < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(columns));
            }

            Rows = rows;
            Columns = columns;
            ChocolateType = chocolateType;
            Filling = filling;
        }

        public Chocolate(string name, string country, float weight, float sugar,
            ChocolateType chocolateType, int rows = 4, int columns = 3)
            : this(name, country, weight, sugar, chocolateType, ChocolateFilling.None, rows, columns)
        {

        }

        internal override Sweet Clone()
        {
            Chocolate clone = (Chocolate)MemberwiseClone();
            clone.Id = Guid.NewGuid();
            return clone;
        }

        public override string ToString()
        {
            return base.ToString() + $", {Rows}X{Columns}";
        }

        /// <summary>
        /// Print to console.
        /// </summary>
        public override string ToPrint()
        {
            return base.ToString() + $", {Rows}X{Columns} bars";
        }
    }    
}