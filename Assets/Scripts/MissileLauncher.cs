using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileLauncher : WeaponBase
{

    // Start is called before the first frame update
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
    public override void Shoot()
    {
        if (timeToFire == 0)
        {
            GameObject temp = Instantiate(ammoPrefab, shootPoint.position, shootPoint.rotation);
            timeToFire = fireRate;
        }
    }

    protected override void SetStats()
    {
        fireRate = stats.FireRate;
        damage = stats.Damage;
        hitMask = stats.hitMask;
        ammoPrefab = stats.ammoPrefab;
    }

    public override void Shoot(Vector3 direction)
    {

    }
}
