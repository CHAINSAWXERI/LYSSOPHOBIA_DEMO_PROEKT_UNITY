using BulletPoolSystem;
using BulletSystem;
using EnemyShooter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boss_DN1
{
    public class TurretBoss : MonoBehaviour
    {
        [SerializeField] public BulletPool bulletPool;
        [SerializeField] public GameObject firePoint;
        [SerializeField] public GameObject targetPoint;
        [SerializeField] public LayerMask playerLayer;
        [SerializeField] public EnemyAiming enemyAiming;
        [SerializeField] public int damage;
        [SerializeField] private float shootTime;

        private float lastPrintTime;
        private bool isTriggered = false;
        private GameObject Target;

        void Awake()
        {
            bulletPool.firePoint = firePoint.transform;
            bulletPool.targetPoint = targetPoint.transform;
            lastPrintTime = Time.timeSinceLevelLoad;
            bulletPool.damageBullet = damage;
        }

        private void Update()
        {
            if (isTriggered)
            {
                enemyAiming.Aiming(Target.transform);
                if (Time.timeSinceLevelLoad - lastPrintTime >= shootTime)
                {
                    Fire();
                    lastPrintTime = Time.timeSinceLevelLoad;
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (((1 << collision.gameObject.layer) & playerLayer) != 0)
            {
                isTriggered = true;
                Target = collision.gameObject;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (((1 << collision.gameObject.layer) & playerLayer) != 0)
            {
                isTriggered = false;
                Target = null;
            }
        }

        void Fire()
        {
            Bullet currentBullet = bulletPool.GetBullet();
            currentBullet.transform.position = firePoint.transform.position;
        }
    }
}