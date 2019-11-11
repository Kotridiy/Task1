using System;
using System.Collections.Generic;
using System.Text;

namespace SweetTask
{
    abstract class Item
    {
        /*private readonly float weight;
        private readonly float volume;

        public float Weight 
        { 
            get => weight;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                weight = value;
            }
        }*/

        public Guid Id { get; }
        public float Weight { get; }
        public string Name { get; set; }
        public string ManufactureCountry { get; }
        
        public Item(string name, float weight, string country)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (weight < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(weight));
            }

            Name = name;
            Weight = weight;
            ManufactureCountry = country;
        }

        public override string ToString()
        {
            return $"{Name} from {ManufactureCountry}, weight = {Weight}";
        }
    }
}
