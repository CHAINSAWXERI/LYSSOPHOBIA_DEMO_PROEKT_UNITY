using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerRightPortal : MonoBehaviour, IPortal
{
    [SerializeField] public Transform exitPortal;
    [SerializeField] public LayerMask triggeredLayer;
    public VerLeftPortal secondPortal { private get; set; }

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
