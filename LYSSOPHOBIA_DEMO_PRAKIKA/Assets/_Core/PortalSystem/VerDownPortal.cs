using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerLeftPortal : MonoBehaviour, IPortal
{
    [SerializeField] public Transform exitPortal;
    [SerializeField] public LayerMask triggeredLayer;
    public VerRightPortal secondPortal { private get; set; }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (triggeredLayer == (triggeredLayer | (1 << other.gameObject.layer)))
        {
            TeleportPlayer(other.gameObject);
        }
    }

    public void TeleportPlayer(GameObject player)
    {
        player.transform.position = secondPortal.exitPortal.position;
    }

}
