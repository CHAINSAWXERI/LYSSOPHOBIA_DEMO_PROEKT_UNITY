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

        [SerializeField] private float moveSpeed;
        [SerializeField] public int damageBullet;
        [SerializeField] public int healthPoints;

        void Start()
        {
            playerController.SpeedUpdate(moveSpeed);
            playerShooting.DamageUpdate(damageBullet);
            playerHealthModel.NewMaxHealth(healthPoints);
        }
    }
}