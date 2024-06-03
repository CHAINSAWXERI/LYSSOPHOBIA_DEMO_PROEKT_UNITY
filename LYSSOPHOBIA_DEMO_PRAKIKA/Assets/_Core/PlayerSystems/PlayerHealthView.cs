using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace PlayerSystems
{
    public class PlayerHealthView : MonoBehaviour
    {
        [SerializeField] private TMP_Text healthText;
        public PlayerHealthModel playerHealth;
        void Start()
        {
            int p = (playerHealth.maxhealthPoints / 100) * playerHealth.healthPoints;
            healthText.text = p + " %";
        }

        public void DecreaseHealth(int amount)
        {
            playerHealth.DecreaseHealth(amount);
            if (playerHealth.healthPoints == 0)
            {
                Debug.Log("ЛОГИКА ПРОИГРЫША");
            }
            int p = (playerHealth.maxhealthPoints / 100) * playerHealth.healthPoints;
            healthText.text = p + " %";
        }

        public void IncreaseHealth(int amount)
        {
            playerHealth.IncreaseHealth(amount);
            int p = (playerHealth.maxhealthPoints / 100) * playerHealth.healthPoints;
            healthText.text = p + " %";
        }

        public int GetHealth()
        {
            return playerHealth.GetHealth();
        }
    }
}