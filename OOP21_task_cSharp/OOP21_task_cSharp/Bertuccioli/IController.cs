using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP21_task_cSharp.Bertuccioli
{
    public interface IController { }

    public interface IController<V> : IController where V : IView
    {
        void SetView(V view);
    }
}
