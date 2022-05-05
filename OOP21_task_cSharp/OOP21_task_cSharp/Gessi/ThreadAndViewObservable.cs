using OOP21_task_cSharp.Bertuccioli;
using System;
using System.Collections.Generic;

namespace OOP21_task_cSharp.Gessi
{
    /// <summary>
    /// Disclaimer:
    /// I didn't originally write this class, but now I'm going to write it because I need it and I'm going to do it by simply transcribing (and adapting) the code from Java to C#.
    /// </summary>
    public class ThreadAndViewObservable
    {
        private static readonly List<IStoppable> STOPPABLE_LIST = new List<IStoppable>();

        private ThreadAndViewObservable() { }

        /// <summary>
        /// This method is used to register every Manager and View.
        /// </summary>
        /// <param name="stoppable"></param>
        /// <exception cref="NotImplementedException"></exception>
        public static void Register(IStoppable stoppable)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method is called just before exiting the game to stop every Manager thread and every View.
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public static void Stop()
        {
            throw new NotImplementedException();
        }
    }
}