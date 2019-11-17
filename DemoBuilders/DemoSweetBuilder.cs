using SweetTask.Base;

namespace SweetTask.DemoBuilders
{
    /// <summary>
    /// Sweets builder. For testing only.
    /// </summary>
    class DemoSweetBuilder : ISweetBuilder
    {
        public Sweet this[string name]
        {
            get
            {
                Sweet sweet;
                switch (name)
                {
                    case "Crazy Bee":
                        sweet = new Candy(name, "Ukraine", 10, 80, CandyFilling.Jelli);
                        break;
                    case "Ромашка":
                        sweet = new Candy(name, "Belarus", 15, 70, CandyGlaze.Chokolate, CandyFilling.Caramel);
                        break;
                    case "Черёмушки":
                        sweet = new Candy(name, "Belarus", 15, 75, CandyGlaze.Chokolate, CandyFilling.Praline);
                        break;
                    case "Дуэт":
                        sweet = new Candy(name, "Belarus", 15, 70, CandyGlaze.Chokolate,
                            CandyFilling.Honey, CandyFilling.Fondant, CandyFilling.Liquor);
                        break;
                    case "Фруктовое ассорти":
                        sweet = new Candy(name, "Belarus", 7, 97, CandyFilling.Caramel);
                        break;
                    case "Шоколад \"Спартак\" без сахара":
                        sweet = new Chocolate(name, "Belarus", 90, 39, ChocolateType.Bitter);
                        break;
                    case "Шоколад \"Белый\"":
                        sweet = new Chocolate(name, "Belarus", 90, 59, ChocolateType.White);
                        break;
                    case "Milk chocolate \"Nougat\"":
                        sweet = new Chocolate(name, "Belarus", 24, 66, ChocolateType.Milk, ChocolateFilling.Nougat, 1, 1);
                        break;
                    case "Черноморские":
                        sweet = new Waffles(name, "Belarus", 89, 57, WaffleType.Chocolate);
                        break;
                    case "Яшкино":
                        sweet = new Waffles(name, "Russia", 200, 57, WaffleType.Chocolate, 8, true);
                        break;
                    default:
                        sweet = null;
                        break;
                }
                return sweet;
            }
        }
    }
}
