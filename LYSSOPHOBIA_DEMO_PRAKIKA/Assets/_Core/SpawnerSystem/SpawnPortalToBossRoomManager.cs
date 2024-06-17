using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SpawnerSystem.DungeonSpawner;

namespace SpawnerSystem
{
    public class SpawnPortalToBossRoomManager : MonoBehaviour
    {
        [SerializeField] private List<DungeonSpawner> dungeonSpawners;
        private System.Random _rnd = new System.Random();

        void Start()
        {
            for (int i = 0; i < dungeonSpawners.Count; i++)
            {
                if (dungeonSpawners[i].spawnlType != SpawnlType.BossRoomDoor)
                {
                    dungeonSpawners.Remove(dungeonSpawners[i]);
                }
            }

            int rndIndex = _rnd.Next(0, dungeonSpawners.Count);
            Debug.Log(rndIndex);
            dungeonSpawners[rndIndex].SpawnPortalToBossRoom();

        }
    }
}