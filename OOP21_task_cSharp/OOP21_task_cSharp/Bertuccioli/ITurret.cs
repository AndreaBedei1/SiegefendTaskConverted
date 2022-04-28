using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace OOP21_task_cSharp.Bertuccioli
{
    interface ITurret
    {
        int GetID();

        object GetPosition();

        void SetPosition(object p);

        double GetRange();

        double GetAngle();

        void SetAngle(double angle);

        void SetState(bool state);

        bool IsAttacking();

        object CreateBullet();

        double GetFireRate();

        object GetTarget();

        void SetTarget(object target);

        int GetPrice();

        ITurret GetClone();
    }
}
