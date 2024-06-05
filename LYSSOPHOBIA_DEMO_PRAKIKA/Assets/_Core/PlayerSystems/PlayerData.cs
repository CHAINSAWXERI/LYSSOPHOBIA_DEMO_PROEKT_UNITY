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

        [field: SerializeField] public float moveSpeed { get; set; }
        [field: SerializeField] public int damageBullet { get; set; }
        [field: SerializeField] public int healthPoints { get; set; }

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