using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerSystems
{
    public class PlayerHealthModel
    {
        public int healthPoints { get; private set; }
        public int maxhealthPoints { get; private set; }

        public PlayerHealthModel(int initialHealth)
        {
            healthPoints = initialHealth;
            maxhealthPoints = initialHealth;
        }

        public void DecreaseHealth(int amount)
        {
            healthPoints -= amount;
            Debug.Log("УДАР " + amount);
            Debug.Log("Здоровье " + healthPoints);
            if (healthPoints < 0)
            {
                healthPoints = 0;
            }
        }

        public void IncreaseHealth(int amount)
        {
            healthPoints += amount;
            if (healthPoints > maxhealthPoints)
            {
                healthPoints = maxhealthPoints;
            }
        }

        public void NewMaxHealth(int initialHealth)
        {
            maxhealthPoints = initialHealth;
            healthPoints = initialHealth;
        }

        public int GetHealth()
        {
            return healthPoints;
        }
    }
}