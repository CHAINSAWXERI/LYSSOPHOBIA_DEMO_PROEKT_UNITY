using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class ChangeScene : MonoBehaviour
    {
        public void NewScene(int SceneNumber)
        {
            SceneManager.LoadScene(SceneNumber);
        }

    }
}