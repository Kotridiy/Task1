using System;
using System.Collections.Generic;
using System.Text;

namespace SweetTask
{
    interface ISweetBoxBuilder
    {
        SweetBox this[string name] { get; }
    }
}
