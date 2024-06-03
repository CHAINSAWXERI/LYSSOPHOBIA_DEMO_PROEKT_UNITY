using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpgradeStoreSystem
{
    public class UpgradeStoreTriggerZone : MonoBehaviour
    {
        [SerializeField] private GameObject ButtonActivateStoreUI;
        [SerializeField] private GameObject UpgradeStoreUI;
        [SerializeField] private KeyCode ButtonActivateStore;
        private GameObject player;
        private bool IsPlayerInsideTrigger;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            ButtonActivateStoreUI.SetActive(true);
            IsPlayerInsideTrigger = true;
            player = collision.gameObject;
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