using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerSystems;

namespace UpgradeStoreSystem
{
    public class DataForUpgradeStore : MonoBehaviour
    {
        public PlayerData playerData;

        public void UpdatePlayerData(UpgradesSO upgradeData)
        {
            playerData.moveSpeed += upgradeData.speed;
            playerData.damageBullet += upgradeData.damage;
            playerData.healthPoints += upgradeData.health;
            playerData.UpdateData();
        }
    }
}