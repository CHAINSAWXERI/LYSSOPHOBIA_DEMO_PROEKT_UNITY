using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PlayerSystems
{
    public class PlayerData : MonoBehaviour
    {
        public PlayerShooting playerShooting { private get; set; }
        public PlayerHealthModel playerHealthModel { private get; set; }
        public PlayerController playerController { private get; set; }

        [SerializeField] public PlayerStatsSO playerStats;
        [SerializeField] public PlayerPocket pocket;

        [HideInInspector] public float moveSpeed;
        [HideInInspector] public int damageBullet;
        [HideInInspector] public int healthPoints;

        void Awake()
        {
            moveSpeed = playerStats.moveSpeed;
            damageBullet = playerStats.damageBullet;
            healthPoints = playerStats.healthPoints;
        }

        void Start()
        {
            playerController.SpeedUpdate(moveSpeed);
            playerShooting.DamageUpdate(damageBullet);
        }

        public void UpdateData() 
        {
            playerController.SpeedUpdate(moveSpeed);
            playerShooting.DamageUpdate(damageBullet);
            playerHealthModel.NewMaxHealth(healthPoints);
        }
    }
}