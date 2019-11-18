using SweetTask.BaseModel.SweetBox;
using SweetTask.BaseModel.Sweets;
using System;

namespace SweetTask.ConsoleManager
{
    /// <summary>
    /// Main class of console management for working with a sweet box. 
    /// </summary>
    public class ConsoleSweetBoxManager
    {
        const string BeginStr =
            "1. Create new sweet box \n" +
            "2. Get exist sweet box \n" +
            "3. Print sweet box \n" +
            "4. Use function \n" +
            ". \n" +
            "9. Close program \n";

        public ISweetBuilder SweetBuilder { get; }
        public ISweetBoxBuilder SweetBoxBuilder { get; }
        public SweetBox SweetBox { get; set; }

        public ConsoleSweetBoxManager(ISweetBuilder sweetBuilder, ISweetBoxBuilder sweetBoxBuilder)
        {
            SweetBuilder = sweetBuilder ?? throw new ArgumentNullException(nameof(sweetBuilder));
            SweetBoxBuilder = sweetBoxBuilder ?? throw new ArgumentNullException(nameof(sweetBoxBuilder));
        }

        public void Begin()
        {
            int answer = 0;

            do
            {
                Console.Clear();
                Console.WriteLine("Sweet box: " + SweetBox?.Name);
                Console.Write(BeginStr);

                answer = GetKey(4, true);

                switch (answer)
                {
                    case 1:
                        SweetBox = new ConsoleSweetBoxBuilder().Create(SweetBuilder);
                        break;
                    case 2:
                        GetSweetBox();
                        break;
                    case 3:
                        PrintSweetBox();
                        break;
                    case 4:
                        ManipulateSweetBox();
                        break;
                }
            } while (answer != 9);
        }

        private void ManipulateSweetBox()
        {
            if (SweetBox != null)
            {
                new ConsoleSweetBoxManipulator().Begin(SweetBox);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("You can't because sweet box is null.");
                Console.WriteLine("Press any key...");
                Console.ReadKey(true);
            }
        }

        /// <summary>
        /// Method to get number 1-9 from console.
        /// </summary>
        /// <param name="max"> Max number to get. </param>
        /// <param name="includeNine"> Would you like to get also '9' if max < 9 </param>
        /// <returns> int 1-9 </returns>
        internal static int GetKey(int max = 9, bool includeNine = false)
        {
            int answer;
            do
            {
                var a = Console.ReadKey(true);
                int.TryParse(a.KeyChar.ToString(), out answer);
            } while (answer == 0 || answer > max && (!includeNine || includeNine && answer != 9));
            return answer;
        }

        private void GetSweetBox()
        {
            Console.Clear();
            Console.WriteLine("Enter name of sweet box: ");
            string sweetBoxName = Console.ReadLine();
            SweetBox sweetBox = SweetBoxBuilder[sweetBoxName];
            if (sweetBox != null)
            {
                SweetBox = sweetBox;
                Console.Clear();
                Console.WriteLine("Sweet box succesfully received. \nPress any key.");
                Console.ReadKey(true);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Sorry, this sweet box don't exist. \nPress any key.");
                Console.ReadKey(true);
            }
        }

        private void PrintSweetBox()
        {
            if (SweetBox != null)
            {
                Console.Clear();
                Console.Write(SweetBox.ToPrint() + "\nPress any key to return.");
                Console.ReadKey(true);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("You can't because sweet box is null.");
                Console.WriteLine("Press any key...");
                Console.ReadKey(true);
            }
        }
    }
}
