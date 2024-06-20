using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UpgradeStoreSystem
{
    public class DragUpgrade : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField] private CanvasGroup canvasGroup;
        [field: SerializeField] public UpgradesSO StatsData { get; private set; }
        private Camera MainCamera;
        private Vector3 offset;
        public Transform OriginParent { get; private set; }
        public Transform DefaultParent;
        public bool lastStr = false;


        void Awake()
        {
            MainCamera = Camera.allCameras[0];
            OriginParent = transform.parent;
            DefaultParent = transform.parent;
        }

        //outBrain.upgradeStoreData.playerData.pocket.pocketSO.coins > StatsData.price
        public void OnBeginDrag(PointerEventData eventData)
        {
            BrainSlot outBrain = DefaultParent.GetComponent<BrainSlot>();
            offset = transform.position - MainCamera.ScreenToWorldPoint(eventData.position);
            DefaultParent = transform.parent;
            transform.SetParent(DefaultParent.parent);
            canvasGroup.blocksRaycasts = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            Vector3 newPos = MainCamera.ScreenToWorldPoint(eventData.position);
            newPos.z = 0;
            transform.position = newPos + offset;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            transform.SetParent(DefaultParent);
            canvasGroup.blocksRaycasts = true;
        }
    }
}