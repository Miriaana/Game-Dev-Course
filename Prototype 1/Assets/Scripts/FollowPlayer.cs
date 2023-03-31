using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;

    private Vector3 offsetBehindCar = new Vector3(0, 5, -7);
    private Vector3 offsetInCar = new Vector3(0, 2, 0.3f);
    private bool cameraViewToggled = false;

    void Start()
    {
        
    }

    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            cameraViewToggled = !cameraViewToggled;
        }

        if (cameraViewToggled)
        {
            transform.position = player.transform.position + offsetInCar;
            transform.rotation = player.transform.rotation;
        }
        else
        {
            transform.position = player.transform.position + offsetBehindCar;
            transform.rotation = Quaternion.Euler(20, 0, 0);
        }
        
    }
}
