using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    [Header("Weapon Stats")]
    [SerializeField] protected WeaponStats stats;

    [SerializeField] protected Transform shootPoint;

    protected float fireRate;
    protected float timeToFire;
    protected float damage;
    protected LayerMask hitMask;
    protected GameObject ammoPrefab;
    public abstract void Shoot();
    public abstract void Shoot(Vector3 direction);
    protected abstract void SetStats();

    protected void resetFireRate()
    {        
        if (timeToFire > 0.0f)
        {
            timeToFire -= Time.deltaTime;            
        }
        else { timeToFire = 0.0f; }
    }
}
