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

        public void UpdateViewCoin(PlayerPocketSO pocketSO)
        {
            pocketText.text = pocketSO.coins + " Coins";
        }
    }
}