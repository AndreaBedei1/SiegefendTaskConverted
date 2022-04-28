using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP21_task_cSharp.Bertuccioli
{
    /// <summary>
    /// This interface is implemented by all views and managers. We want them to be stoppable in order to stop them before exit game.
    /// </summary>
    public interface IStoppable
    {
        /// <summary>
        /// Method that stops thread and view, called just before exiting the game.
        /// </summary>
        void Stop();
    }
}
