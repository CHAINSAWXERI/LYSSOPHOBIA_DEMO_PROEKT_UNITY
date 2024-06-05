using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UpgradeStoreSystem
{
    public class StoreSlot : MonoBehaviour, IDropHandler
    {
        public void OnDrop(PointerEventData eventData)
        {
            DragUpgrade upgrade = eventData.pointerDrag.GetComponent<DragUpgrade>();

            if (upgrade != null)
            {
                upgrade.DefaultParent = transform;
            }
        }
    }
}