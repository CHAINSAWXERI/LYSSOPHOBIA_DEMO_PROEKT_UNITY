using EnemySystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpawnerSystem
{
    public class DungeonSpawnerTrigger : MonoBehaviour
    {
        [SerializeField] private LayerMask PlayerMask;
        [SerializeField] private List<DungeonSpawner> spawners;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (((1 << collision.gameObject.layer) & PlayerMask) != 0)
            {
                for (int i = 0; i < spawners.Count; i++)
                {
                    spawners[i].Spawn();
                }
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (((1 << collision.gameObject.layer) & PlayerMask) != 0)
            {
                for (int i = 0; i < spawners.Count; i++)
                {
                    spawners[i].Destroy();
                }
            }
        }
    }
}