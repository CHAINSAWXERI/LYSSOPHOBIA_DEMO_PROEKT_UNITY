using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PocketSystem;

namespace PlayerSystems
{
    public class PlayerPocket : MonoBehaviour
    {
        [SerializeField] public PlayerPocketView playerPocketView;
        [SerializeField] public PlayerPocketSO pocketSO;

        public void Start()
        {
            playerPocketView.UpdateViewCoin(pocketSO);
        }

        public void NewCoinValuePlus(int value)
        {
            pocketSO.coins += value;
            playerPocketView.UpdateViewCoin(pocketSO);
        }

        public void NewCoinValueMinus(int value)
        {
            pocketSO.coins -= value;
            playerPocketView.UpdateViewCoin(pocketSO);
        }
    }
}