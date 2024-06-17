using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerSystems;

namespace EnemyWalker
{
    public class EnemyAttackZone : MonoBehaviour
    {
        [SerializeField] private LayerMask playerLayer;
        [SerializeField] private EnemyWalkerAI enemy;
        [SerializeField] private float punchTime;
        private PlayerBody playerBody;

        private float lastPrintTime;

        void Start()
        {
            lastPrintTime = Time.timeSinceLevelLoad;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (((1 << collision.gameObject.layer) & playerLayer) != 0)
            {
                playerBody = collision.gameObject.GetComponent<PlayerBody>();
            }
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (((1 << collision.gameObject.layer) & playerLayer) != 0)
            {
                if (Time.timeSinceLevelLoad - lastPrintTime >= punchTime)
                {
                    Punch();
                    lastPrintTime = Time.timeSinceLevelLoad;
                }
            }
        }

        private void Punch()
        {
            playerBody.TakeDamage(enemy.damage);
        }
    }
}