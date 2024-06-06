using BulletSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerSystems
{
    public class PlayerBody : MonoBehaviour
    {
        [SerializeField] private int dangerLayerMaskBullet;
        [SerializeField] private int dangerLayerMaskEnemy;
        public PlayerHealthView playerHealthView { private get; set; }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.layer == dangerLayerMaskBullet)
            {
                Bullet bullet;
                bullet = collision.gameObject.GetComponent<Bullet>();
                TakeDamage(bullet.Damage);
            }
        }

        public void TakeDamage(int damage)
        {
            playerHealthView.DecreaseHealth(damage);
        }
    }
}