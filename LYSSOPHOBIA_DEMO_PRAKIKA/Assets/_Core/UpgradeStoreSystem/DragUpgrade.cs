﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragUpgrade : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private CanvasGroup canvasGroup;
    [field: SerializeField] public UpgradesSO StatsData { get; private set; }
    private Camera MainCamera;
    private Vector3 offset;
    public Transform OriginParent { get; private set; }
    public Transform DefaultParent;

    void Awake()
    {
        MainCamera = Camera.allCameras[0];
        OriginParent = transform.parent;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
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