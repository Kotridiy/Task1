using System;
using System.Collections.Generic;
using System.Text;

namespace SweetTask.Base
{
    public interface ISweetBuilder
    {
        Sweet this[string name] { get; }
    }
}
