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

        public float moveSpeed;
        public int damageBullet;
        public int healthPoints;

        void Awake()
        {
            playerStats.moveSpeed = moveSpeed;
            playerStats.damageBullet = damageBullet;
            playerStats.healthPoints = healthPoints;
        }

        void Start()
        {
            playerController.SpeedUpdate(moveSpeed);
            playerShooting.DamageUpdate(damageBullet);
            playerHealthModel.NewMaxHealth(healthPoints);
        }

        public void UpdateData() 
        {
            playerController.SpeedUpdate(moveSpeed);
            playerShooting.DamageUpdate(damageBullet);
            playerHealthModel.NewMaxHealth(healthPoints);
        }
    }
}