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

        [SerializeField] public SpawnlType spawnlType;
        [SerializeField] private List<GameObject> enemies;
        [SerializeField] private GameObject portalToBossRoom;

        private System.Random _rnd = new System.Random();
        

        void Awake()
        {
            for (int i = 0; i < enemies.Count; i++)
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
        }

        public void SpawnPortalToBossRoom()
        {
            portalToBossRoom.SetActive(true);
        }

        public void Destroy()
        {
            if (spawnlType == SpawnlType.EnemySpawner)
            {
                for (int i = 0; i < enemies.Count; i++)
                {
                    enemies[i].transform.position = transform.position;
                    enemies[i].SetActive(false);
                }
            }
        }
    }
}