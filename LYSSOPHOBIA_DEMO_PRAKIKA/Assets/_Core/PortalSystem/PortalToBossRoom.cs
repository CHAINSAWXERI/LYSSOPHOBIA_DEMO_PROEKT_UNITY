using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PortalSystem
{
    public class PortalToBossRoom : MonoBehaviour
    {
        [SerializeField] public Transform bossroomPortal;
        [SerializeField] public LayerMask triggeredLayer;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (triggeredLayer == (triggeredLayer | (1 << other.gameObject.layer)))
            {
                other.transform.position = bossroomPortal.position;
            }
        }
    }
}