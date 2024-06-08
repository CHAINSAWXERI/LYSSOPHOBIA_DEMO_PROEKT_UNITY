using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemySystem
{
    public interface IEnemy
    {
        void ActiveMode(Transform target);
    }
}