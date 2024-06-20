using BulletSystem;
using SpawnerSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

namespace Boss_DN1
{
    public class FirstDungeonBoss : MonoBehaviour, IBoss
    {
        [SerializeField] public LayerMask bulletLayer;
        [SerializeField] public int health;
        [SerializeField] public int damage;
        [SerializeField] public GameObject ExitFromDungeon;
        [SerializeField] public Slider healthSlider;
        [SerializeField] public float shootTimeFirstPhase;
        [SerializeField] public float shootTimeSecondPhase;
        [SerializeField] public float shootTimeThirdPhase;
        [SerializeField] public int MaxHitCounter;
        [SerializeField] public List<TurretBoss> Turrets;
        [SerializeField] public List<Transform> Positions;

        private int maxhealth;
        public int hitCounter = 0;
        private Transform currentTransform;
        private System.Random _rnd = new System.Random();

        public void StartBossBattle()
        {
            for (int i = 0; i < Turrets.Count; i++)
            {
                Turrets[i].damage = damage;
                Turrets[i].gameObject.SetActive(false);
            }
            ExitFromDungeon.SetActive(true);
            ExitFromDungeon.SetActive(false);
            maxhealth = health;

            int rndIndex = _rnd.Next(0, Positions.Count);
            transform.position = Positions[rndIndex].position;
            currentTransform = Positions[rndIndex];
            hitCounter = 0;

            FirstPhase();
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
                    for (int i = 0; i < Turrets.Count; i++)
                    {
                        Turrets[i].gameObject.SetActive(false);
                    }
                }
                else
                {
                    if ((maxhealth / 4) == health)
                    {
                        ThirdPhase();
                    }
                    else
                    {
                        if ((maxhealth / 2) == health)
                        {
                            SecondPhase();
                        }
                    }
                }

                if (hitCounter == MaxHitCounter)
                {
                    int rndIndex = _rnd.Next(0, Positions.Count);
                    while (currentTransform == Positions[rndIndex])
                    {
                        rndIndex = _rnd.Next(0, Positions.Count);
                    }
                    transform.position = Positions[rndIndex].position;
                    hitCounter = 0;
                }
                else
                {
                    hitCounter++;
                }
                
            }
        }

        public void FirstPhase()
        {
            int maxIndexActiveTurrets = Turrets.Count / 3;
            for (int i = 0; i < maxIndexActiveTurrets; i++)
            {
                Turrets[i].gameObject.SetActive(true);
                Turrets[i].shootTime = shootTimeThirdPhase;
                Turrets[i].shootTime = shootTimeThirdPhase;
            }
        }

        public void SecondPhase()
        {
            int maxIndexActiveTurrets = Turrets.Count / 2;
            for (int i = 0; i < maxIndexActiveTurrets; i++)
            {
                Turrets[i].gameObject.SetActive(true);
                Turrets[i].shootTime = shootTimeSecondPhase;
            }
        }

        public void ThirdPhase()
        {
            for (int i = 0; i < Turrets.Count; i++)
            {
                Turrets[i].gameObject.SetActive(true);
                Turrets[i].shootTime = shootTimeFirstPhase;
            }
        }
    }
}