using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    [Header("Weapon Stats")]
    [SerializeField] protected WeaponStats stats;

    [SerializeField] protected Transform shootPoint;

    protected float fireRate;
    protected float damage;
    protected LayerMask hitMask;
    protected GameObject ammoPrefab;
    public abstract void Shoot();
}
