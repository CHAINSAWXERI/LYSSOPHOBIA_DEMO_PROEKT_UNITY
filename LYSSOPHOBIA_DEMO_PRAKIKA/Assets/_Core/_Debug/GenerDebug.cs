﻿using BulletSystem;
using PlayerSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Debug
{
    public class GenerDebug : MonoBehaviour
    {
        [SerializeField] private LayerMask PlayerMask;
        [SerializeField] private SpriteRenderer spriteRenderer;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (((1 << collision.gameObject.layer) & PlayerMask) != 0)
            {
                spriteRenderer.color = new Color32(0, 255, 0, 100);
            }
        }
    }
}