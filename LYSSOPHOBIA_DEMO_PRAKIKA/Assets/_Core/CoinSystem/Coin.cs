using PlayerSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoinSystem
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] public int value;
        [SerializeField] public PlayerPocketSO playerPocket;
        [SerializeField] private LayerMask playerLayer;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (((1 << collision.gameObject.layer) & playerLayer) != 0)
            {
                playerPocket.coins += value;
                gameObject.SetActive(false);
            }
        }
    }
}