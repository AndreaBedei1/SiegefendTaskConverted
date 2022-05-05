using System;

namespace OOP21_task_cSharp.Bertuccioli
{
    /// <summary>
    /// Non-generic base interface for a view.
    /// </summary>
    public interface IView
    {
        /// <summary>
        /// Enables the view to start working. Throws <see cref="InvalidOperationException"/> if the
        /// controller has not been set
        /// </summary>
        void Start();
    }

    /// <summary>
    /// Base interface for a view.
    /// </summary>
    /// <typeparam name="C">the controller type accepted by the view</typeparam>
    public interface IView<C> : IView where C : IController
    {
        /// <summary>
        /// Sets the controller associated to the view. Can only be called once.
        /// </summary>
        /// <param name="controller">the controller to associate</param>
        void SetController(C controller);
    }
}
