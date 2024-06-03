using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SOupgrade", menuName = "ScriptableObjects/UpgradeSO", order = 1)]
public class UpgradesSO : ScriptableObject
{
    [field: SerializeField] public int health { get; private set; }
    [field: SerializeField] public float speed { get; private set; }
    [field: SerializeField] public int damage { get; private set; }
}
