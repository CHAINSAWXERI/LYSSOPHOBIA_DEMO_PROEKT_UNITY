using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemyWalker
{
    public interface IEnemy
    {
        void AttackMode(Transform target);
    }
}