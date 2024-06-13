using BulletSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerSystems
{
    public class PlayerBody : MonoBehaviour
    {
        [SerializeField] private LayerMask dangerLayerMaskBullet;

        public PlayerHealthView playerHealthView { private get; set; }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (((1 << collision.gameObject.layer) & dangerLayerMaskBullet) != 0)
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