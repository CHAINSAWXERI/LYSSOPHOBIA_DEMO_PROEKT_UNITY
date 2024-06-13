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
        [SerializeField] public PlayerController playerController;

        [SerializeField] public PlayerData playerData;

        void Awake()
        {
            playerShooting.firePoint = firePoint;
            bulletPool.firePoint = firePoint;
            bulletPool.targetPoint = targetPoint;


            PlayerHealthModel newPlayerHealthModel = new PlayerHealthModel(playerData.playerStats.healthPoints);
            playerHealthView.playerHealth = newPlayerHealthModel;
            playerBody.playerHealthView = playerHealthView;

            playerData.playerHealthModel = newPlayerHealthModel;
            playerData.playerShooting = playerShooting;
            playerData.playerController = playerController;
        }
    }
}