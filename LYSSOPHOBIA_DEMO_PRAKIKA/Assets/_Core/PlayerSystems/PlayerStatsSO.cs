using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SOstats", menuName = "ScriptableObjects/PlayerStatsSO", order = 3)]
public class PlayerStatsSO : ScriptableObject
{
    [SerializeField] public float moveSpeed;
    [SerializeField] public int damageBullet;
    [SerializeField] public int healthPoints;
}
