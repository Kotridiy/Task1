﻿using SweetTask.Base;

namespace SweetTask.DemoBuilders
{
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
                        box.AddItem(sweetBuilder["Шоколад \"Белый\""], 1);   
                        box.AddItem(sweetBuilder["Яшкино"], 1);   
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