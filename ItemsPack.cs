﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SweetTask
{
    class ItemsPack
    {
        private int count;

        public Guid Id { get; }
        public Item Item { get; }
        public int GetCount() => count;
        public float GetWeight() => count * Item.Weight;

        public ItemsPack(Item item, int count = 1)
        {
            if (count <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            Item = item;
            this.count = count;
        }

        static int CountByWeight(Item item, float weight)
        {
            return (int)Math.Floor(weight / item.Weight);
        }

        static ItemsPack ItemsPackByWeight(Item item, float weight)
        {
            return new ItemsPack(item, CountByWeight(item, weight));
        }

        public override string ToString()
        {
            return Item.ToString() + $", count = {count}";
        }
    }
}