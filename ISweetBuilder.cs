using System;
using System.Collections.Generic;
using System.Text;

namespace SweetTask
{
    interface ISweetBuilder
    {
        Sweet this[string name] { get; }
    }
}
