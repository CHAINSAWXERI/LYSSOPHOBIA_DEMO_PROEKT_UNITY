using PlayerSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpgradeStoreSystem
{
    public class UpgradeStoreTriggerZone : MonoBehaviour
    {
        [SerializeField] private GameObject ButtonActivateStoreUI;
        [SerializeField] private DataForUpgradeStore UpgradeStoreUI;
        [SerializeField] private KeyCode ButtonActivateStore;
        [SerializeField] private LayerMask TriggerLayer;
        private PlayerData player;
        private bool IsPlayerInsideTrigger;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == TriggerLayer)
            {
                ButtonActivateStoreUI.SetActive(true);
                IsPlayerInsideTrigger = true;
                player = collision.gameObject.GetComponent<PlayerData>();
            }
        }


        private void FixedUpdate()
        {
            if (Input.GetKeyDown(ButtonActivateStore))
            {
                if (IsPlayerInsideTrigger)
                {
                    player.gameObject.SetActive(false);
                    UpgradeStoreUI.gameObject.SetActive(true);
                }
            }
        }


        private void OnTriggerExit2D(Collider2D collision)
        {
            ButtonActivateStoreUI.SetActive(false);
            IsPlayerInsideTrigger = false;
        }
    }
}