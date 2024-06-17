using BulletSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace Boss_DN1
{
    public class FirstDungeonBoss : MonoBehaviour, IBoss
    {
        [SerializeField] public LayerMask bulletLayer;
        [SerializeField] public int health;
        [SerializeField] public GameObject ExitFromDungeon;


        void Start()
        {
            ExitFromDungeon.SetActive(false);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (((1 << collision.gameObject.layer) & bulletLayer) != 0)
            {
                Bullet bullet = collision.gameObject.GetComponent<Bullet>();
                health -= bullet.Damage;
                if (health <= 0)
                {
                    ExitFromDungeon.SetActive(true);
                    gameObject.SetActive(false);
                }
            }
        }
    }
}