using System;
using System.Collections.Generic;
using SweetTask.BaseModel.Enums;
using SweetTask.BaseModel.SweetBox;
using SweetTask.BaseModel.Sweets;

namespace SweetTask.ConsoleManager
{
    /// <summary>
    /// Part of console management. Get user control and create new sweet box.
    /// </summary>
    class ConsoleSweetBoxBuilder
    {
        const string CreateBoxStr =
            "1. Add sweet. \n" +
            "2. Remove sweet. \n" +
            "3. Print sweet box. \n" +
            "4. Create random candy \n" +
            "5. End. \n";

        private SweetBox SweetBox { get; set; }
        private ISweetBuilder SweetBuilder { get; set; }

        internal SweetBox Create(ISweetBuilder sweetBuilder)
        {
            SweetBuilder = sweetBuilder ?? throw new ArgumentNullException(nameof(sweetBuilder));

            Console.WriteLine("Enter name for sweet box: ");
            string boxName = Console.ReadLine();
            SweetBox = new SweetBox(boxName);
            AddSweet();

            int answer;
            do
            {
                Console.Clear();
                Console.WriteLine("Sweet box: " + SweetBox.Name);
                Console.Write(CreateBoxStr);
                answer = ConsoleSweetBoxManager.GetKey(5);
                switch (answer)
                {
                    case 1:
                        AddSweet();
                        break;
                    case 2:
                        RemoveSweet();
                        break;
                    case 3:
                        PrintSweetBox();
                        break;
                    case 4:
                        SweetBox.AddItem(CreateRandomCandy());
                        break;
                }
            } while (answer != 5);

            return SweetBox;
        }

        private void PrintSweetBox()
        {
            Console.Clear();
            Console.Write(SweetBox.ToPrint() + "\nPress any key to return.");
            Console.ReadKey();
        }

        private void AddSweet()
        {
            Console.Clear();
            Console.WriteLine("Enter name of sweet: ");
            string sweetName = Console.ReadLine();
            Sweet sweet = SweetBuilder[sweetName];
            if (sweet != null)
            {
                Console.Clear();
                Console.WriteLine("How many this sweets you want to add: ");
                int sweetsCount;
                int.TryParse(Console.ReadLine(), out sweetsCount);
                while (sweetsCount == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Wrong number. Please, try again:");
                    int.TryParse(Console.ReadLine(), out sweetsCount);
                }
                SweetBox.AddItem(sweet, sweetsCount);
                Console.Clear();
                Console.WriteLine("Sweet succesfully added. \nPress any key.");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Sorry, this sweet don't exist. \nPress any key.");
                Console.ReadKey();
            }
        }

        private void RemoveSweet()
        {
            Console.Clear();
            Console.WriteLine("Enter name of sweet: ");
            string sweetName = Console.ReadLine();
            Sweet sweet = SweetBox.SearchItem((item) => item.Name == sweetName);

            if (sweet != null)
            {
                Console.Clear();
                Console.Write(
                    "1. Remove one. \n" +
                    "2. Remove all. \n"
                    );
                int answer = ConsoleSweetBoxManager.GetKey(2);
                switch (answer)
                {
                    case 1:
                        SweetBox.RemoveItem(sweet);
                        break;
                    case 2:
                        SweetBox.RemoveItems(sweet);
                        break;
                }
                Console.Clear();
                Console.WriteLine("Sweet succesfully removed. \nPress any key.");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Sorry, this sweet don't exist. \nPress any key.");
                Console.ReadKey();
            }
        }

        private Candy CreateRandomCandy()
        {
            Console.Clear();
            Console.WriteLine("Enter name of candy: ");
            string name = Console.ReadLine();

            Random random = new Random();
            string[] countries = { "Russia", "Ukraine", "Belarus", "USA", "Lithuania", "Latvia", "Germania" };
            string manufacturer = countries[random.Next(countries.Length)];
            float weight = (float)(1 + random.NextDouble() * 100);
            float sugar = (float)(random.NextDouble() * 100);

            CandyGlaze glaze = (CandyGlaze)GetRandomEnum(typeof(CandyGlaze), random);

            List<CandyFilling> fillings = new List<CandyFilling>();
            int fillCount = random.Next(1, 4);
            for (int i = 0; i < fillCount; i++)
            {
                fillings.Add((CandyFilling)GetRandomEnum(typeof(CandyFilling), random));
            }

            Candy candy = new Candy(name, manufacturer, weight, sugar, glaze, fillings.ToArray());

            Console.Clear();
            Console.WriteLine(candy.ToPrintFull());
            Console.WriteLine("Press any key...");
            Console.ReadKey(true);
            return candy;
        }

        private object GetRandomEnum(Type T, Random random)
        {
            if (!T.IsEnum) throw new ArgumentException("Type must be enum.");
            var values = Enum.GetValues(T);
            return values.GetValue(random.Next(values.Length));
        }
    }
}