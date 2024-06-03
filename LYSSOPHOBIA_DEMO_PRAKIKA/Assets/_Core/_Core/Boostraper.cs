using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerSystems;
using BulletPoolSystem;

namespace Core
{
    public class Boostraper : MonoBehaviour
    {
        [SerializeField] public PlayerShooting playerShooting;
        [SerializeField] public BulletPool bulletPool;
        [SerializeField] public Transform firePoint;
        [SerializeField] public Transform targetPoint;

        [SerializeField] public PlayerHealthView playerHealthView;
        [SerializeField] public PlayerBody playerBody;

        [SerializeField] public int playerHealth;

        void Awake()
        {
            playerShooting.firePoint = firePoint;
            bulletPool.firePoint = firePoint;
            bulletPool.targetPoint = targetPoint;

            playerHealthView.playerHealth = new PlayerHealthModel(playerHealth);
            playerBody.playerHealthView = playerHealthView;
        }
    }
}