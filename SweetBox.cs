using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SweetTask
{
    class SweetBox
    {
        public Guid Id { get; }
        public string Name { get; set; }
        public ICollection<ItemsPack> Items { get; private set; }

        private SweetBox(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }
            Name = name;
            //Items = null;
        }

        public SweetBox(string name, params ItemsPack[] packs) : this(name)
        {
            Items = new List<ItemsPack>(packs); // Array to ICollection
            //Items.Add(packs[0]);
        }

        public SweetBox(string name, Item item, int count = 1) : this(name)
        {
            Items = new List<ItemsPack> { new ItemsPack(item, count) };
        }

        public void AddItem(ItemsPack pack)
        {
            Items.Add(pack);
        }

        public void AddItem(Item item, int count = 1)
        {
            Items.Add(new ItemsPack(item, count));
        }

        public void AddRangeItems(params ItemsPack[] packs)
        {
            foreach (var pack in packs)
            {
                Items.Add(pack);
            }
        }

        public void RemoveItem(Item item)
        {
            
        }

        public float GetWeight()
        {
            return Items.Aggregate(0f, (total, next) => total += next.GetWeight());

            /*
            return Items.Aggregate(
                0f,
                (total, next) => total += next.GetWeight()
            );
            */
        }

        public Item SearchItem(Predicate<Item> predicate)
        {
            foreach (var pack in Items)
            {
                if (predicate(pack.Item))
                {
                    return pack.Item;
                }
            }

            return null;
        }

        public IEnumerable<Item> SortItems(Predicate<Item> predicate)
        {
            return from ItemsPack pack in Items
                   orderby predicate(pack.Item)
                   select pack.Item;
        }
        public IEnumerable<Item> SortItems(Predicate<Item> predicate, Type type)
        {
            return from ItemsPack pack in Items
                   where pack.Item.GetType() == type
                   orderby predicate(pack.Item)
                   select pack.Item;
        }
    }
}
