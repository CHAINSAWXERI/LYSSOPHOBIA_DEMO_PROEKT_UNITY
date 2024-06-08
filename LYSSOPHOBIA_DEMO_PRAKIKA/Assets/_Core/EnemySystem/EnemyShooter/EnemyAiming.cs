using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemyShooter
{
    public class EnemyAiming : MonoBehaviour
    {
        [SerializeField] public float offset;
        public void Aiming(Transform target)
        {
            Vector2 _difference = target.position - transform.position;
            float _rotz = Mathf.Atan2(_difference.y, _difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, _rotz + offset);
        }
    }
}