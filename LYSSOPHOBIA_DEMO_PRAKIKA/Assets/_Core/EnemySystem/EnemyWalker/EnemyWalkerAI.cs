using BulletSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemyWalker
{
    public class EnemyWalkerAI : MonoBehaviour, IEnemy
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] public int health;
        [SerializeField] public int damage;
        [SerializeField] private LayerMask BulletLayer;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (((1 << collision.gameObject.layer) & BulletLayer) != 0)
            {
                Bullet bullet = collision.gameObject.GetComponent<Bullet>();
                health -= bullet.Damage;
                if (health <= 0)
                {
                    gameObject.SetActive(false);
                    // Спавн Лута
                }
            }
        }

        public void AttackMode(Transform target)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.fixedDeltaTime);
        }
    }
}