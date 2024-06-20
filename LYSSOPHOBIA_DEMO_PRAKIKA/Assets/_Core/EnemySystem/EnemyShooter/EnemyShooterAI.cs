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
        [SerializeField] public Rigidbody2D rb;
        [SerializeField] public GameObject Loot;
        private Vector3 startTransform;

        void Start()
        {
            startTransform = transform.position;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (((1 << collision.gameObject.layer) & BulletLayer) != 0)
            {
                Bullet bullet = collision.gameObject.GetComponent<Bullet>();
                health -= bullet.Damage;
                if (health <= 0)
                {
                    Instantiate(Loot, transform.position, transform.rotation);
                    transform.position = startTransform;
                    gameObject.SetActive(false);
                }
            }
        }

        public void ActiveMode(Transform target)
        {
            Vector3 moveDirection = transform.position - target.position; // Изменено на противоположное направление
            rb.MovePosition(transform.position + moveDirection.normalized * moveSpeed * Time.fixedDeltaTime);
            //transform.position = Vector2.MoveTowards(transform.position, target.position, -moveSpeed * Time.fixedDeltaTime);
        }

    }
}