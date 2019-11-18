using System;

namespace SweetTask.BaseModel.Sweets
{
    /// <summary>
    /// Class defines some sweet which can be put in sweet box. 
    /// </summary>
    public abstract class Sweet
    {
        public Guid Id { get; protected set; }
        /// <summary> Sweet weight in grams </summary>
        public float Weight { get; private set; }
        /// <summary> Amount of sugar in a sweet in 100 grams </summary>
        public float Sugar { get; private set; }
        /// <summary> Manufacturer Defined Name </summary>
        public string Name { get; private set; }
        /// <summary> Country of production </summary>
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

            Id = Guid.NewGuid();
            Name = name;
            Weight = weight;
            Sugar = sugar;
            ManufactureCountry = country;
        }

        internal abstract Sweet Clone();

        public override string ToString()
        {
            return $"{Name}, {ManufactureCountry}, W = {Weight}, Sug = {Sugar}";
        }
        
        /// <summary>
        /// Print to console.
        /// </summary>
        public virtual string ToPrint()
        {
            return $"{Name} from {ManufactureCountry}, weight = {Weight}g, sugar = {Sugar}g / 100g";
        }
    }
}
