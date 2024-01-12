using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Cameras")]
    [SerializeField] private CinemachineVirtualCamera pilotCam;
    private CinemachineVirtualCamera currentCam;

    private Vector2 centerScreenPoint;
    public Vector3 lookPoint;
    public Vector3 lookDirection;

    Ray rayToCenter;

    //Ref to the main camera;
    private Camera mainCam;

    void Start()
    {
        mainCam = Camera.main;
        currentCam = pilotCam;
    }

    void Update()
    {
        //Get the center screen point
        centerScreenPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);

        rayToCenter = mainCam.ScreenPointToRay(centerScreenPoint);
        lookDirection = mainCam.ViewportToWorldPoint(currentCam.transform.forward);

        lookPoint = mainCam.ScreenToWorldPoint(centerScreenPoint) + rayToCenter.direction * 50f;

        lookDirection = lookPoint - mainCam.transform.position;
    }

    private void FixedUpdate()
    {
        
    }
}
