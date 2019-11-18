using SweetTask.BaseModel.Sweets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SweetTask.BaseModel.SweetBox
{
    /// <summary>
    /// Gift box with different types of sweets.
    /// </summary>
    public class SweetBox
    {
        private ICollection<Sweet> Sweets { get; set; }
        public Guid Id { get; }
        /// <summary> Manufacturer Defined Name </summary>
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

        /// <summary>
        /// Add one or more sweets with the same name
        /// </summary>
        /// <param name="item"> Certain sweet </param>
        /// <param name="count"> Amount of sweets </param>
        public void AddItem(Sweet item, int count = 1)
        {
            if (count < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }
            if (item == null)
            {
                return;
            }

            for (int i = 0; i < count; i++)
            {
                Sweets.Add(item.Clone());
            }
        }

        /// <summary>
        /// Add sweets of different types
        /// </summary>
        public void AddItems(params Sweet[] items)
        {
            foreach (var item in items)
            {
                Sweets.Add(item);
            }
        }

        /// <summary>
        /// Remove one sweet.
        /// </summary>
        public void RemoveItem(Sweet item)
        {
            if (item == null)
            {
                return;
            }
            Sweet element = Sweets.FirstOrDefault((sweet) => sweet.Name == item.Name);
            if (element != null)
            {
                Sweets.Remove(element);
            }
        }
        /// <summary>
        /// Remove one sweet.
        /// </summary>
        /// <param name="name"> Sweet name </param>
        public void RemoveItem(string name)
        {
            Sweet element = Sweets.FirstOrDefault((sweet) => sweet.Name == name);
            if (element != null)
            {
                Sweets.Remove(element);
            }
        }

        /// <summary>
        /// Remove all sweets with same name.
        /// </summary>
        public void RemoveItems(Sweet item)
        {
            if (item == null)
            {
                return;
            }
            var items = from sweet in Sweets
                        where sweet.Name == item.Name
                        select sweet;
            Sweets = Sweets.Except(items).ToList();
        }
        /// <summary>
        /// Remove all sweets with same name.
        /// </summary>
        /// <param name="name"> Sweet name </param>
        public void RemoveItems(string name)
        {
            var items = from sweet in Sweets
                        where sweet.Name == name
                        select sweet;
            Sweets = Sweets.Except(items).ToList();
        }

        /// <summary>
        /// Get the total weight of the box.
        /// </summary>
        public float GetWeight()
        {
            return Sweets.Aggregate(0f, (total, sweet) => total + sweet.Weight);
        }

        /// <summary>
        /// Get first sweet by condition.
        /// </summary>
        public Sweet SearchItem(Predicate<Sweet> predicate)
        {
            return Sweets.FirstOrDefault((sweet) => predicate(sweet));
        }

        /// <summary>
        /// Get first sweet from sugar range.
        /// </summary>
        /// <param name="min"> Bottom bound </param>
        /// <param name="max"> Upper bound </param>
        public Sweet SearchItemBySugar(float min = 0, float max = 100)
        {
            return Sweets.FirstOrDefault((sweet) => sweet.Sugar >= min && sweet.Sugar <= max);
        }

        /// <summary>
        /// Get a collection sorted by name
        /// </summary>
        public IEnumerable<Sweet> SortItems()
        {
            return from Sweet sweet in Sweets
                   orderby sweet.Name
                   select sweet;
        }
        /// <summary>
        /// Get a collection sorted by name with certain type.
        /// </summary>
        public IEnumerable<Sweet> SortItems(Type type)
        {
            return from Sweet sweet in Sweets
                   where sweet.GetType() == type
                   orderby sweet.Name
                   select sweet;
        }

        /// <summary>
        /// Print the name and the contain of the box to the console.
        /// </summary>
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