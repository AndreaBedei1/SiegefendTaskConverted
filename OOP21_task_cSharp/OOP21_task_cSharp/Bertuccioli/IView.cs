using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP21_task_cSharp.Bertuccioli
{
    public interface IView
    {
        void Start();
    }

    public interface IView<C> : IView where C : IController
    {
        void SetController(C controller);
    }
}
