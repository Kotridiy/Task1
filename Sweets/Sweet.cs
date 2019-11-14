using System;
using System.Collections.Generic;
using System.Text;

namespace SweetTask.Base
{
    public abstract class Sweet
    {
        public Guid Id { get; private set; }
        public float Weight { get; private set; }
        public float Sugar { get; private set; }
        public string Name { get; private set; }
        public string ManufactureCountry { get; private set; }
        
        public Sweet(string name, string country, float weight, float sugar)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (weight < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(weight));
            }
            if (sugar < 0 || sugar > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(sugar));
            }

            Name = name;
            Weight = weight;
            Sugar = sugar;
            ManufactureCountry = country;
        }

        internal virtual Sweet Clone()
        {
            return (Sweet) MemberwiseClone();
        }

        public override string ToString()
        {
            return $"{Name}, {ManufactureCountry}, W = {Weight}, Sug = {Sugar}";
        }
        
        public virtual string ToPrint()
        {
            return $"{Name} from {ManufactureCountry}, weight = {Weight}g, sugar = {Sugar}g / 100g";
        }
    }
}
