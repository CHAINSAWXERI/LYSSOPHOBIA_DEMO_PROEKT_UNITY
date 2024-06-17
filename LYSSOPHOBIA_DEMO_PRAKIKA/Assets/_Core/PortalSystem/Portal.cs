using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PortalSystem
{
    public class Portal : MonoBehaviour
    {
        [SerializeField]
        public enum PortalType
        {
            VerLeftPortal,
            VerRightPortal,
            HorUpPortal,
            HorDownPortal
        }

        [SerializeField] public Transform exitPortal;
        [SerializeField] public LayerMask triggeredLayer;
        [SerializeField] public PortalType portalType;
        [SerializeField] public int portalIndex;
        [SerializeField] public GameObject block;

        [HideInInspector] public Portal secondPortal;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (triggeredLayer == (triggeredLayer | (1 << other.gameObject.layer)))
            {
                TeleportPlayer(other.gameObject);
            }
        }

        public void TeleportPlayer(GameObject teleportingObject)
        {
            teleportingObject.transform.position = secondPortal.exitPortal.position;
        }

        public void BlockSecondPortal()
        {
            if (secondPortal == null)
            {
                block.SetActive(true);
            }
            else
            {
                block.SetActive(false);
            }
        }
    }
}