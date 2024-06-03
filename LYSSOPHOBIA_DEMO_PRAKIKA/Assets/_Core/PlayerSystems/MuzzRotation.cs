using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerSystems
{
    public class MuzzRotation : MonoBehaviour
    {
        [SerializeField] public float offset;
        void Update()
        {
            Vector2 _difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float _rotz = Mathf.Atan2(_difference.y, _difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, _rotz + offset);
        }
    }
}