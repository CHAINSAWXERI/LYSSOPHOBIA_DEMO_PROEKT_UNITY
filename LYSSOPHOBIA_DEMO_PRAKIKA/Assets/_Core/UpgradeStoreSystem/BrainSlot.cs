using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UpgradeStoreSystem
{
    public class BrainSlot : MonoBehaviour, IDropHandler
    {
        [SerializeField] public DataForUpgradeStore upgradeStoreData;
        private DragUpgrade currentObject;

        public void ProcessUpgrade(DragUpgrade upgrade)
        {
            if (currentObject != null)
            {
                Debug.Log("1");
                currentObject.transform.SetParent(currentObject.OriginParent);
                currentObject = null;
            }
            else
            {
                Debug.Log("2");
                upgrade.transform.SetParent(transform, false);
                currentObject = upgrade;
            }
        }

        public void OnDrop(PointerEventData eventData)
        {
            DragUpgrade upgrade = eventData.pointerDrag.GetComponent<DragUpgrade>();

            ProcessUpgrade(upgrade);

            if ((upgrade.lastStr == false))
            {
                upgrade.lastStr = true;
                upgrade.DefaultParent = transform;
                upgradeStoreData.UpdatePlayerDataPlus(upgrade.StatsData);
            }
        }
    }
}