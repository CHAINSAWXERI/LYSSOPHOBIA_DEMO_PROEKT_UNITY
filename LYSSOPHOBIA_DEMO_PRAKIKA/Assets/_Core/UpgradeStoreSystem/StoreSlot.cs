using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UpgradeStoreSystem
{
    public class StoreSlot : MonoBehaviour, IDropHandler
    {

        public DataForUpgradeStore upgradeStoreData;
        private DragUpgrade currentObject;

        /*
        public void ProcessUpgrade(DragUpgrade upgrade)
        {
            if (currentObject != null)
            {
                currentObject.transform.SetParent(currentObject.OriginParent);
                upgradeStoreData.UpdatePlayerDataMinus(currentObject.StatsData);
                currentObject = null;
            }

            upgrade.transform.SetParent(transform, false);
            currentObject = upgrade;
        }
        */

        public void OnDrop(PointerEventData eventData)
        {
            DragUpgrade upgrade = eventData.pointerDrag.GetComponent<DragUpgrade>();

            if (upgrade != null)
            {
                upgrade.DefaultParent = transform;
                upgradeStoreData.UpdatePlayerDataMinus(upgrade.StatsData);
                //ProcessUpgrade(upgrade);
            }
        }
    }
}