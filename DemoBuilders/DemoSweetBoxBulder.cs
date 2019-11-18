using SweetTask.BaseModel.SweetBox;
using SweetTask.BaseModel.Sweets;

namespace SweetTask.DemoBuilders
{
    /// <summary>
    /// Sweet box builder. For testing only.
    /// </summary>
    class DemoSweetBoxBulder : ISweetBoxBuilder
    {
        ISweetBuilder sweetBuilder;

        public DemoSweetBoxBulder(ISweetBuilder sweetBuilder)
        {
            this.sweetBuilder = sweetBuilder;
        }

        public SweetBox this[string name]
        {
            get
            {
                SweetBox box = new SweetBox(name);

                switch (name)
                {
                    case "Конфетный бум":
                        box.AddItem(sweetBuilder["Crazy Bee"], 10);
                        box.AddItem(sweetBuilder["Ромашка"], 7);
                        box.AddItem(sweetBuilder["Дуэт"], 5);
                        box.AddItem(sweetBuilder["Фруктовое ассорти"], 20);
                        break;
                    case "Радость для ребёнка":
                        box.AddItem(sweetBuilder["Crazy Bee"], 8);
                        box.AddItem(sweetBuilder["Ромашка"], 5);
                        box.AddItem(sweetBuilder["Milk chocolate \"Nougat\""], 3);
                        box.AddItem(sweetBuilder["Шоколад \"Белый\""]);   
                        box.AddItem(sweetBuilder["Яшкино"]);   
                        break;
                    default:
                        box = null;
                        break;
                }

                return box;
            }
        }
    }
}
