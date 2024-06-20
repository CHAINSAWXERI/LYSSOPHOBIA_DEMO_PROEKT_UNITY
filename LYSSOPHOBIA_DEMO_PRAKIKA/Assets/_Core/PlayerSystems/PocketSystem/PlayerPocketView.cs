using PlayerSystems;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace PocketSystem
{
    public class PlayerPocketView : MonoBehaviour
    {
        [SerializeField] private TMP_Text pocketText;
        [SerializeField] public PlayerPocket playerPocket;

        void Update()
        {
            pocketText.text = playerPocket.pocketSO.coins + " Coins";
        }
    }
}