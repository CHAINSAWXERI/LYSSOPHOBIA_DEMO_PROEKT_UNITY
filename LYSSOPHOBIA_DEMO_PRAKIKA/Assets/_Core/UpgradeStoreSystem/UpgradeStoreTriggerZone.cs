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
        [SerializeField] private int TriggerLayer;
        private PlayerData player;
        private PlayerController playerController;
        private bool IsPlayerInsideTrigger;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == TriggerLayer)
            {
                ButtonActivateStoreUI.SetActive(true);
                IsPlayerInsideTrigger = true;
                player = collision.gameObject.GetComponent<PlayerData>();
                playerController = collision.gameObject.GetComponent<PlayerController>();
                UpgradeStoreUI.playerData = player;
            }
        }


        private void FixedUpdate()
        {
            if (Input.GetKeyDown(ButtonActivateStore))
            {
                if (IsPlayerInsideTrigger)
                {
                    playerController.enabled = false;
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