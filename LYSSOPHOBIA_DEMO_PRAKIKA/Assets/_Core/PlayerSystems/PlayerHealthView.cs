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
            float p = ((float)playerHealth.healthPoints / (float)playerHealth.maxhealthPoints) * 100;
            healthText.text = (int)p + " %";
        }

        public void DecreaseHealth(int amount)
        {
            playerHealth.DecreaseHealth(amount);
            if (playerHealth.healthPoints == 0)
            {
                Debug.Log("ЛОГИКА ПРОИГРЫША");
            }
            float p = ((float)playerHealth.healthPoints / (float)playerHealth.maxhealthPoints) * 100;
            healthText.text = (int)p + " %";
        }

        public void IncreaseHealth(int amount)
        {
            playerHealth.IncreaseHealth(amount);
            float p = ((float)playerHealth.healthPoints / (float)playerHealth.maxhealthPoints) * 100;
            healthText.text = (int)p + " %";
        }

        public int GetHealth()
        {
            return playerHealth.GetHealth();
        }
    }
}