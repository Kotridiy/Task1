using System;

namespace SweetTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var fillings = new CandyFilling[] { CandyFilling.Cream, CandyFilling.Fondant, CandyFilling.Fruit };
            Candy candy = new Candy("Demo candy", 10, "RASSEA", 80, fillings);
            ItemsPack pack1 = new ItemsPack(candy, 15);
            ItemsPack pack2 = new ItemsPack(candy, 20);
            SweetBox box = new SweetBox("Demo box", pack1);

            box.Items.Add(pack2);
        }
    }
}
