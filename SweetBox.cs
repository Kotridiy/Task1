using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SweetTask
{
    class SweetBox
    {
        private IList<Sweet> Sweets { get; set; }
        public Guid Id { get; }
        public string Name { get; }

        private SweetBox(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }
            Name = name;
            //Items = null;
        }

        public SweetBox(string name, params Sweet[] items) : this(name)
        {
            Sweets = new List<Sweet>(items);
        }

        public SweetBox(string name, Sweet item, int count = 1) : this(name)
        {
            Sweets = new List<Sweet>();
            AddItem(item, count);
        }

        public void AddItem(Sweet item, int count = 1)
        {
            if (count < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            for (int i = 0; i < count; i++)
            {
                Sweets.Add(item.Clone());
            }
        }

        public void AddItems(params Sweet[] items)
        {
            foreach (var item in items)
            {
                Sweets.Add(item);
            }
        }

        public void RemoveItem(Sweet item)
        {
            Sweet element = Sweets.FirstOrDefault((sweet) => sweet.Name == item.Name);
            if (element != null)
            {
                Sweets.Remove(element);
            }
        }

        public void RemoveItems(Sweet item)
        {
            var items = from sweet in Sweets
                        where sweet.Name == item.Name
                        select sweet;
            Sweets = Sweets.Except(items).ToList();
        }

        public float GetWeight()
        {
            return Sweets.Aggregate(0f, (total, sweet) => total + sweet.Weight);
        }

        public Sweet SearchItem(Predicate<Sweet> predicate)
        {
            return Sweets.FirstOrDefault((sweet) => predicate(sweet));
        }

        public Sweet SearchItemBySugar(float min = 0, float max = 100)
        {
            return Sweets.FirstOrDefault((sweet) => sweet.Sugar >= min && sweet.Sugar <= max);
        }

        public IEnumerable<Sweet> SortItems(Predicate<Sweet> predicate)
        {
            return from Sweet sweet in Sweets
                   orderby predicate(sweet)
                   select sweet;
        }
        public IEnumerable<Sweet> SortItems(Predicate<Sweet> predicate, Type type)
        {
            return from Sweet sweet in Sweets
                   where sweet.GetType() == type
                   orderby predicate(sweet)
                   select sweet;
        }

        public string ToPrint()
        {
            StringBuilder str = new StringBuilder($"Sweet box {Name} contains:\n");
            foreach (var sweet in Sweets)
            {
                str.AppendLine(sweet.ToPrint());
            }

            return str.ToString();
        }
    }
}
