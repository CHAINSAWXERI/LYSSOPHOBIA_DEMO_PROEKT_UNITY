using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerSystems
{
    public class PlayerPocket : MonoBehaviour
    {
        [SerializeField] public PlayerPocketSO pocketSO;

        public void AddCoin(int value)
        {
            pocketSO.coins = value;
        }
    }
}