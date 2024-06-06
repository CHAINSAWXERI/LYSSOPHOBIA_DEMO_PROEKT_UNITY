using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerSystems;

namespace UpgradeStoreSystem
{
    public class DataForUpgradeStore : MonoBehaviour
    {
        public PlayerData playerData;
        [SerializeField] public List<StoreSlot> storeSlots = new List<StoreSlot>();

        public void Start()
        {
            for(int i = 0; i < storeSlots.Count; i++)
            {
                storeSlots[i].upgradeStoreData = this;
            }
            
        }

        public void UpdatePlayerDataPlus(UpgradesSO upgradeData)
        {
            playerData.pocket.pocketSO.coins -= upgradeData.price;
            playerData.moveSpeed += upgradeData.speed;
            playerData.damageBullet += upgradeData.damage;
            playerData.healthPoints += upgradeData.health;
            playerData.UpdateData();
        }

        public void UpdatePlayerDataMinus(UpgradesSO upgradeData)
        {
            playerData.pocket.pocketSO.coins += upgradeData.price;
            playerData.moveSpeed -= upgradeData.speed;
            playerData.damageBullet -= upgradeData.damage;
            playerData.healthPoints -= upgradeData.health;
            playerData.UpdateData();
        }
    }
}