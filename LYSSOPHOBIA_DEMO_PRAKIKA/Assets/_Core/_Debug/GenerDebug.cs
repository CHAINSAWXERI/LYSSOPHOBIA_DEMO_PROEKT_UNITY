using BulletSystem;
using PlayerSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerDebug : MonoBehaviour
{
    [SerializeField] private LayerMask PlayerMask;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("1");
        if (((1 << collision.gameObject.layer) & PlayerMask) != 0)
        {
            Debug.Log("2");
            spriteRenderer.color = new Color32(0, 255, 0, 100);
        }
    }
}
