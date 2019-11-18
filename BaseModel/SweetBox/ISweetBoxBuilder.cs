using System;
using System.Collections.Generic;
using System.Text;

namespace SweetTask.BaseModel.SweetBox
{
    /// <summary>
    /// Defines indexator that allow get sweet box by name.
    /// </summary>
    public interface ISweetBoxBuilder
    {
        SweetBox this[string name] { get; }
    }
}
