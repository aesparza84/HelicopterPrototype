using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [Header("Weapon Holders")]
    [SerializeField] private GameObject launcherOnePrefab;
    [SerializeField] private GameObject launcherTwoPrefab;
    [SerializeField] private GameObject turretPrefab;

    [SerializeField] private Transform rightMissileRack;
    [SerializeField] private Transform leftMissileRack;
    [SerializeField] private Transform turretTransform;

    private WeaponBase rightLauncher;
    private WeaponBase leftLauncher;
    private WeaponBase turret;

    [Header("Player Inputs")]
    [SerializeField] private InputManager playerInput;

    private bool shootLeft;

    private void Awake()
    {
        if (launcherOnePrefab == null || launcherTwoPrefab == null)
        {
            Debug.LogWarning("A missile prefab not Set");
        }
        else
        {
            if (launcherOnePrefab != null)
            {
                GameObject left = Instantiate(launcherOnePrefab, leftMissileRack);
                leftLauncher = left.GetComponent<MissileLauncher>();
            }

            if (launcherTwoPrefab != null)
            {
                GameObject right = Instantiate(launcherTwoPrefab, rightMissileRack);
                rightLauncher = right.GetComponent<MissileLauncher>();
            }
        }

        if (turretPrefab == null)
        {
            Debug.LogWarning("Turret prefab not set");
        }
        else
        {
            GameObject newTurret = Instantiate(turretPrefab, turretTransform);
            turret = newTurret.GetComponent<TurretRaycast>();
        }
        

        playerInput = GetComponent<InputManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        shootLeft = false;

        playerInput.input.PlayerHelicopter.PrimaryWeaponFire.performed += OnPrimaryFire;
        playerInput.input.PlayerHelicopter.PrimaryWeaponFire.canceled += OnPrimaryStop;

        playerInput.input.PlayerHelicopter.SecondaryWeaponFire.performed += OnSecondaryFire;
        playerInput.input.PlayerHelicopter.SecondaryWeaponFire.canceled += OnSecondaryStop;
    }

    private void OnSecondaryStop(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {

    }

    private void OnSecondaryFire(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        
        handleSecondaryShooting();
    }

    private void OnPrimaryStop(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {

    }

    private void OnPrimaryFire(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        handlePrimaryShooting(transform.forward);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void handleSecondaryShooting()
    {
        shootLeft = !shootLeft;
        if (shootLeft)
        {
            leftLauncher.Shoot();
        }
        else
        {
            rightLauncher.Shoot();
        }        
    }

    private void handlePrimaryShooting(Vector3 direction)
    {
        turret.Shoot(direction);
    }
}
