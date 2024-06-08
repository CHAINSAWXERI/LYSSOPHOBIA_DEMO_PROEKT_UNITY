using EnemySystem;
using EnemyWalker;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemyShooter
{
    public class EnemyTriggerZoneRunaway : MonoBehaviour
    {
        [SerializeField] private LayerMask triggeredLayer;
        private bool seePlayer = false;
        private IEnemy enemy;
        private Collider2D Player;

        private void Start()
        {
            enemy = transform.parent.gameObject.GetComponent<EnemyShooterAI>();
        }

        void Update()
        {
            if (seePlayer)
            {
                enemy.ActiveMode(Player.transform);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (((1 << other.gameObject.layer) & triggeredLayer) != 0)
            {
                seePlayer = true;
                Player = other;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (((1 << other.gameObject.layer) & triggeredLayer) != 0)
            {
                seePlayer = false;
                Player = null;
            }
        }
    }
}