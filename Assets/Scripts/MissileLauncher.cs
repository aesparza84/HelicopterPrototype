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
            setStats();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Shoot()
    {
        GameObject temp = Instantiate(ammoPrefab, shootPoint.position, shootPoint.rotation);
    }

    private void setStats()
    {
        fireRate = stats.FireRate;
        damage = stats.Damage;
        hitMask = stats.hitMask;
        ammoPrefab = stats.ammoPrefab;
    }
}
