using BulletSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerSystems
{
    public class PlayerBody : MonoBehaviour
    {
        [SerializeField] private LayerMask dangerLayerMaskBullet;
        [SerializeField] private LayerMask dangerLayerMaskEnemy;
        public PlayerHealthView playerHealthView { private get; set; }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.layer == dangerLayerMaskBullet)
            {
                Bullet bullet;
                bullet = collision.gameObject.GetComponent<Bullet>();
                playerHealthView.DecreaseHealth(bullet.Damage);
                Debug.Log(bullet.Damage);
            }

            if (collision.gameObject.layer == dangerLayerMaskEnemy)
            {
                /*
                Enemy enemy;
                if (this.TryGetComponent<Enemy>(out enemy))
                {
                    playerHealthView.DecreaseHealth(Enemy.Damage);
                }
                */
            }
        }
    }
}