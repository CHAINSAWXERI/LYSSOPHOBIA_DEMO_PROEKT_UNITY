using BulletPoolSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BulletPoolSystem;
using UnityEngine.UI;
using BulletSystem;

namespace PlayerSystems
{
    public class PlayerShooting : MonoBehaviour
    {
        [SerializeField] public BulletPool bulletPool;
        [SerializeField] public KeyCode FireButton;
        [SerializeField] public Camera mainCamera;
        [field: SerializeField] public Transform firePoint { private get; set; }
        [field: SerializeField] public int damageBullet { private get; set; }

        void Start()
        {
            bulletPool.damageBullet = damageBullet;
        }

        void Update()
        {
            if (Input.GetKeyDown(FireButton))
            {
                Fire();
            }
        }

        void Fire()
        {
            Bullet currentBullet = bulletPool.GetBullet();
            currentBullet.transform.position = firePoint.transform.position;
        }

        public void DamageUpdate(int newDamage)
        {
            bulletPool.damageBullet = newDamage;
        }
    }
}
