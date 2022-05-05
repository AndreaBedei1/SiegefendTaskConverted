namespace OOP21_task_cSharp.Notaro
{
    /// <summary>
    /// Interface for the class responsible for the process of map reading from file.
    /// </summary>
    public interface IMapLoader
    {
        /// <summary>
        /// Property that returns the map created.
        /// </summary>
        public IMap Map { get; }
    }
}