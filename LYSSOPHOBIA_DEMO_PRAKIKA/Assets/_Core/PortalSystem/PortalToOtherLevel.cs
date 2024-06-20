using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

public class PortalToOtherLevel : MonoBehaviour
{
    [SerializeField] private ChangeScene changeScene;
    [SerializeField] public LayerMask playerLayer;
    [SerializeField] public int newSceneNum;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (playerLayer == (playerLayer | (1 << other.gameObject.layer)))
        {
            changeScene.NewScene(newSceneNum);
        }
    }
}
