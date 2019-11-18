using SweetTask.BaseModel.SweetBox;
using SweetTask.BaseModel.Sweets;
using System;

namespace SweetTask.ConsoleManager
{
    /// <summary>
    /// Part of console management. Get user control to use some functions.
    /// </summary>
    class ConsoleSweetBoxManipulator
    {
        const string ManipulateMenuStr =
            "1. Show sweet box weight. \n" +
            "2. Search by sugar. \n" +
            "3. Search by manufacture country. \n" +
            "4. Sort sweets. \n" +
            "5. Sort candies only. \n" +
            ". \n" +
            "9. End. \n";

        private SweetBox SweetBox { get; set; }

        internal void Begin(SweetBox sweetBox)
        {
            SweetBox = sweetBox ?? throw new ArgumentNullException(nameof(sweetBox));

            int answer;
            do
            {
                Console.Clear();
                Console.WriteLine("Sweet box: " + SweetBox?.Name);
                Console.Write(ManipulateMenuStr);
                answer = ConsoleSweetBoxManager.GetKey(5, true);
                switch (answer)
                {
                    case 1:
                        ShowWeight();
                        break;
                    case 2:
                        SearchBySugar();
                        break;
                    case 3:
                        SearchByCountry();
                        break;
                    case 4:
                        SortSweets();
                        break;
                    case 5:
                        SortCandies();
                        break;
                }
            } while (answer != 9);
        }

        private void ShowWeight()
        {
            Console.Clear();
            Console.WriteLine($"Sweet box weight = {SweetBox.GetWeight().ToString()}");
            Console.WriteLine("Press any key...");
            Console.ReadKey(true);
        }

        private void SearchBySugar()
        {
            float min, max;
            Console.Clear();
            Console.WriteLine("Enter sugar range. ");
            Console.Write("Bottom bound: ");
            float.TryParse(Console.ReadLine(), out min);
            Console.Write("Upper bound: ");
            float.TryParse(Console.ReadLine(), out max);

            Console.Clear();
            Console.WriteLine($"Range: [{min.ToString()}; {max.ToString()}]");
            Sweet sweet = SweetBox.SearchItemBySugar(min, max);
            if (sweet != null)
            {
                Console.WriteLine("Found: " + sweet.ToPrint());
            }
            else
            {
                Console.WriteLine("Sweet not found.");
            }
            Console.WriteLine("Press any key...");
            Console.ReadKey(true);
        }

        private void SearchByCountry()
        {
            string country;
            Console.Clear();
            Console.Write("Enter country name: ");
            country = Console.ReadLine();

            Console.Clear();
            Sweet sweet = SweetBox.SearchItem(item => item.ManufactureCountry == country);
            if (sweet != null)
            {
                Console.WriteLine("Found: " + sweet.ToPrint());
            }
            else
            {
                Console.WriteLine("Sweet not found.");
            }
            Console.WriteLine("Press any key...");
            Console.ReadKey(true);
        }

        private void SortSweets()
        {
            var sweets = SweetBox.SortItems();
            Console.Clear();
            foreach (var sweet in sweets)
            {
                Console.WriteLine(sweet.ToPrint());
            }
            Console.WriteLine();
            Console.WriteLine("Press any key...");
            Console.ReadKey(true);
        }

        private void SortCandies()
        {
            var candies = SweetBox.SortItems(typeof(Candy));
            Console.Clear();
            foreach (var candy in candies)
            {
                Console.WriteLine(candy.ToPrint());
            }
            Console.WriteLine();
            Console.WriteLine("Press any key...");
            Console.ReadKey(true);
        }
    }
}
