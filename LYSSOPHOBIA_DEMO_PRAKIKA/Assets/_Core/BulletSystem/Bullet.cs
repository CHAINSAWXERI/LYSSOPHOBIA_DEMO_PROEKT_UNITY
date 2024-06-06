using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace BulletSystem
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float lifetime;
        [SerializeField] private Rigidbody2D rb;
        public int Damage;

        public Vector2 vectorBetweenPoints;
        private float currentLifeTime;

        void Start()
        {
            currentLifeTime = lifetime;
        }

        void Update()
        {
            Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y);
            Vector2 newPosition = currentPosition + vectorBetweenPoints * speed * Time.deltaTime;

            transform.position = new Vector3(newPosition.x, newPosition.y, 0);

            currentLifeTime -= Time.deltaTime;

            if (currentLifeTime <= 0)
            {
                DestroyBullet();
            }
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            DestroyBullet();
        }

        void DestroyBullet()
        {
            ResetLifeTime();
            gameObject.SetActive(false);
        }

        public void ResetLifeTime()
        {
            currentLifeTime = lifetime;
        }
    }
}