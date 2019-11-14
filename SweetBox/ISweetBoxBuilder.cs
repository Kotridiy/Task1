using System;
using System.Collections.Generic;
using System.Text;

namespace SweetTask.Base
{
    public interface ISweetBoxBuilder
    {
        SweetBox this[string name] { get; }
    }
}
