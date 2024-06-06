using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SOpocket", menuName = "ScriptableObjects/PocketSO", order = 2)]
public class PlayerPocketSO : ScriptableObject
{
    [SerializeField] public int coins;
}
