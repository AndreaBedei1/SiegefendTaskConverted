namespace OOP21_task_cSharp.Bertuccioli
{
    /// <summary>
    /// Non-generic base interface for a controller.
    /// </summary>
    public interface IController { }

    /// <summary>
    /// Base interface for a controller.
    /// </summary>
    /// <typeparam name="V">the view type accepted by the controller</typeparam>
    public interface IController<V> : IController where V : IView
    {
        /// <summary>
        /// Sets the view associated to the controller. Can only be called once.
        /// </summary>
        /// <param name="view">the view to associate</param>
        void SetView(V view);
    }
}
