using BulletPoolSystem;
using BulletSystem;
using EnemySystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemyShooter
{
    public class EnemyShooterAI : MonoBehaviour, IEnemy
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] public int health;
        [SerializeField] public int damage;
        [SerializeField] private LayerMask BulletLayer;
        [SerializeField] private EnemyShootZone enemyShoot;
        [SerializeField] public BulletPool bulletPool;
        
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
        
        public void ActiveMode(Transform target)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, -moveSpeed * Time.fixedDeltaTime);
        }
    }
}