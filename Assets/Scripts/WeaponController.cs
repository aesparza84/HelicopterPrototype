using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [Header("Weapon Holders")]
    [SerializeField] private GameObject launcherOnePrefab;
    [SerializeField] private GameObject launcherTwoPrefab;
    [SerializeField] private Transform rightMissileRack;
    [SerializeField] private Transform leftMissileRack;

    private WeaponBase rightLauncher;
    private WeaponBase leftLauncher;

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
}
