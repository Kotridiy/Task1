using System;
using System.Collections.Generic;
using System.Text;

namespace SweetTask.Base
{
    /// <summary>
    /// Defines indexator that allow get sweet by name.
    /// </summary>
    public interface ISweetBuilder
    {
        Sweet this[string name] { get; }
    }
}
