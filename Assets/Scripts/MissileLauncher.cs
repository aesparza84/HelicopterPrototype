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
    }
    public override void Shoot()
    {
        GameObject temp = Instantiate(ammoPrefab, shootPoint.position, shootPoint.rotation);
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
