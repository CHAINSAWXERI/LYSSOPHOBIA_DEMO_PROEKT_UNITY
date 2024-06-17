using EnemySystem;
using PortalSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpawnerSystem
{
    public class DungeonSpawner : MonoBehaviour
    {
        [SerializeField]
        public enum SpawnlType
        {
            BossRoomDoor,
            EnemySpawner
        }

        [SerializeField] private SpawnlType spawnlType;
        [SerializeField] private List<GameObject> enemies;
        [SerializeField] private GameObject portalToBossRoom;

        private System.Random _rnd = new System.Random();
        

        void Start()
        {
            for (int i =0; i < enemies.Count; i++)
            {
                enemies[i].SetActive(false);
            }
            portalToBossRoom.SetActive(false);
        }

        public void Spawn()
        {
            if (spawnlType == SpawnlType.EnemySpawner)
            {
                int rndIndex = _rnd.Next(0, enemies.Count);
                //int rndIndex = Random.Range(0, enemies.Count);
                enemies[rndIndex].SetActive(true);
            }
            if (spawnlType == SpawnlType.BossRoomDoor)
            {
                int rndIndex = _rnd.Next(0, enemies.Count);
                //int rndIndex = Random.Range(0, 6);
                if (rndIndex == 3) 
                {
                    portalToBossRoom.SetActive(true);
                }
            }
        }
    }
}