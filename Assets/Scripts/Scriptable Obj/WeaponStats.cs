using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponStats", menuName = "New Weapon Stats")]
public class WeaponStats : ScriptableObject
{
    public float FireRate;
    public float Damage;
    public LayerMask hitMask;
    public GameObject ammoPrefab;
}
