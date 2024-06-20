using Boss_DN1;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerStartBossBattle : MonoBehaviour
{
    [SerializeField] private FirstDungeonBoss boss;  // [SerializeField] private IBoss boss; 
    [SerializeField] private LayerMask PlayerMask;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & PlayerMask) != 0)
        {
            boss.StartBossBattle();
        }
    }
}
