namespace SweetTask.BaseModel.Sweets
{
    /// <summary>
    /// Defines indexator that allow get sweet by name.
    /// </summary>
    public interface ISweetBuilder
    {
        Sweet this[string name] { get; }
    }
}
