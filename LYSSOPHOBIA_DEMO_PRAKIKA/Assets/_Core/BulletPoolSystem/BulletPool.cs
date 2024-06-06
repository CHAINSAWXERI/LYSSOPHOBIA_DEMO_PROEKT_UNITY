using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BulletSystem;

namespace BulletPoolSystem
{
    public class BulletPool : MonoBehaviour
    {
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private int poolSize;
        public Transform firePoint { private get; set; }
        public Transform targetPoint { private get; set; }
        private List<Bullet> pool = new List<Bullet>();

        public int damageBullet { private get; set; }

        public void Start()
        {
            for (int i = 0; i < poolSize; i++)
            {
                InstantiateBullet(firePoint.transform.position);
            }
        }

        public Bullet InstantiateBullet(Vector2 position)
        {
            Bullet newBulletObject = Instantiate(bulletPrefab, position, transform.rotation);
            newBulletObject.gameObject.SetActive(false);
            pool.Add(newBulletObject);
            return newBulletObject;
        }

        public Bullet GetBullet()
        {
            foreach (Bullet bullet in pool)
            {
                if (!bullet.gameObject.activeInHierarchy)
                {
                    bullet.gameObject.SetActive(true);
                    bullet.Damage = damageBullet;
                    bullet.vectorBetweenPoints = targetPoint.position - firePoint.position;
                    bullet.vectorBetweenPoints.Normalize();
                    return bullet;
                }
            }
            return InstantiateBullet(Vector2.zero);
        }

    }
}