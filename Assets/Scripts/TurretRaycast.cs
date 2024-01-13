using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRaycast : WeaponBase
{
    [Header("Range for the Raycasting")]
    [SerializeField] private float turretRange;

    [Header("Tracer for firing")]
    [SerializeField] private TrailRenderer bulletTracerRender;

    void Start()
    {
        if (stats != null)
        {
            SetStats();
        }
    }


    private void FixedUpdate()
    {
        resetFireRate();
        //Debug.Log(timeToFire);
    }

    public override void Shoot(Vector3 direction)
    {
        if (timeToFire == 0)
        {
            RaycastHit shotHit;
            
            if (Physics.Raycast(shootPoint.position, direction, out shotHit, turretRange))
            {
                Debug.DrawRay(shootPoint.position, direction.normalized * turretRange, Color.red);
            }



            timeToFire = fireRate;
        }
    }

    protected override void SetStats()
    {
        fireRate = stats.FireRate;
        damage = stats.Damage;
        hitMask = stats.hitMask;
    }

    public override void Shoot()
    {

    }
}
