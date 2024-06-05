using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BrainSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] public DataForUpgradeStore upgradeStoreData;
    private DragUpgrade currentObject;

    public void ProcessUpgrade(DragUpgrade upgrade)
    {
        if (currentObject != null)
        {
            currentObject.transform.SetParent(currentObject.OriginParent);
            currentObject = null;
        }

        upgrade.transform.SetParent(transform, false);
        currentObject = upgrade;

        Debug.Log($"Объект '{upgrade.name}' был помещен в слот мозга.");
    }

    public void OnDrop(PointerEventData eventData)
    {
        DragUpgrade upgrade = eventData.pointerDrag.GetComponent<DragUpgrade>();

        if (upgrade != null)
        {
            upgrade.DefaultParent = transform;
            upgradeStoreData.UpdatePlayerData(upgrade.StatsData);
            ProcessUpgrade(upgrade);
        }
    }

    private void Update()
    {
        if (currentObject != null)
        {
            //currentObject.StatsData;
        }
    }
}
