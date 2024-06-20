using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

public class PlayerRestartLevel : MonoBehaviour
{
    [SerializeField] public KeyCode keyCode;
    [SerializeField] public ChangeScene changeScene;
    [SerializeField] public int NumScene;

    void Update()
    {
        if (Input.GetKeyDown(keyCode))
        {
            changeScene.NewScene(NumScene);
        }
    }
}
