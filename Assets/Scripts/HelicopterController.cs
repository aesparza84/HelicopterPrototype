using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterController : MonoBehaviour
{
    [Header("Body componenets")]
    [SerializeField] private Rigidbody helicopterBody;
    [SerializeField] private Collider helicopterCollider;

    [Header("Inputs")]
    [SerializeField] private InputManager playerInput;

    [Header("Momvement Stats")]
    [SerializeField] private float maxSpeed;
    [SerializeField] private float currentSpeed;
    [SerializeField] private float deAccelSpeed;
    [SerializeField] private float accelSpeed;

    [Header("Movement Vectors")]
    [SerializeField] private Vector3 horizontalVector;
    [SerializeField] private Vector3 verticalVector;

    private Vector3 moveVector;
    private Vector3 limitVelocity;

    [SerializeField] private Vector3 currentVelocity;

    private bool horizontalInput;
    private bool verticalInput;

    private void Awake()
    {
        helicopterBody = GetComponent<Rigidbody>();
        playerInput = GetComponent<InputManager>();
    }

    void Start()
    {
        //Zero the vectors at Start
        horizontalVector = Vector3.zero;
        verticalVector = Vector3.zero;
        moveVector = Vector3.zero;
        limitVelocity = Vector3.zero;

        horizontalInput = false;
        verticalInput = false;

        //Adding Player input events -MUST be in Start method
        playerInput.input.PlayerHelicopter.HorizontalMove.performed += OnHorizontalPerformed;
        playerInput.input.PlayerHelicopter.HorizontalMove.canceled += OnHorizontalStopped;

        playerInput.input.PlayerHelicopter.VerticalMove.performed += OnVerticalUpPerformed;
        playerInput.input.PlayerHelicopter.VerticalMove.canceled += OnVerticalStopped;
    }

    //Move - Vertical Performed
    private void OnVerticalUpPerformed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        verticalVector.y = obj.ReadValue<float>();
        currentSpeed = maxSpeed;
        verticalInput = true;
    }


    //Move - Vertical Stopped
    private void OnVerticalStopped(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        verticalVector.y = 0;
        currentSpeed = 0;
        verticalInput = false;
    }


    //Move - Horizontal Stopped
    private void OnHorizontalStopped(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        horizontalVector = Vector3.zero;
        currentSpeed = 0;
        horizontalInput = false;
    }

    //Move - Horizontal Performed
    private void OnHorizontalPerformed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        horizontalVector.x = obj.ReadValue<Vector2>().x;
        horizontalVector.z = obj.ReadValue<Vector2>().y;

        currentSpeed = maxSpeed;
        horizontalInput = true;
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        movement();
    }

    private void movement()
    {
        currentVelocity = helicopterBody.velocity;

        currentVelocity.x = Mathf.Clamp(currentVelocity.x, -maxSpeed, maxSpeed);
        currentVelocity.z = Mathf.Clamp(currentVelocity.z, -maxSpeed, maxSpeed);

        if (!horizontalInput)
        {
            currentVelocity.x = Mathf.Lerp(currentVelocity.x, 0, Time.deltaTime * deAccelSpeed);
        }

        if (!verticalInput)
        {
            currentVelocity.y = Mathf.Lerp(currentVelocity.y, 0, Time.deltaTime * deAccelSpeed);
        }

        //Velocity we want to apply
        moveVector = (horizontalVector + verticalVector) * currentSpeed;

        limitVelocity = moveVector - currentVelocity;
        limitVelocity = Vector3.ClampMagnitude(limitVelocity, maxSpeed);

        helicopterBody.AddForce(limitVelocity.normalized * accelSpeed, ForceMode.Force);

    }    
}
