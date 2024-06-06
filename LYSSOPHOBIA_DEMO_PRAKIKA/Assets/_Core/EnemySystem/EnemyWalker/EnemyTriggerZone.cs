using EnemyWalker;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyTriggerZone : MonoBehaviour
{
    [SerializeField] private LayerMask triggeredLayer;
    private bool seePlayer = false;
    private IEnemy enemy;
    private Collider2D Player;

    private void Start()
    {
        enemy = transform.parent.gameObject.GetComponent<EnemyWalkerAI>();
    }

    void Update()
    {
        if (seePlayer)
        {
            enemy.AttackMode(Player.transform);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (((1 << other.gameObject.layer) & triggeredLayer) != 0)
        {
            seePlayer = true;
            Player = other;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (((1 << other.gameObject.layer) & triggeredLayer) != 0)
        {
            seePlayer = false;
            Player = null;
        }
    }
}