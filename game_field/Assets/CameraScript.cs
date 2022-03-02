using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Camera position, angle and radius rotation point.
    // Vector3 CameraPosition = new Vector3(-400.0f, 250.0f, 0.0f);
    // Vector3 CameraAngle = new Vector3(0.0f, 35.0f, 0.0f);
    //Vector3 CameraRotateAroundRadius = new Vector3(0.0f, 0.0f, 0.0f);
    Vector3 CameraPosition = new Vector3(400.0f, 250.0f, 0.0f);
    Vector3 CameraAngle = new Vector3(0.0f, 35.0f, 0.0f);
    Vector3 CameraRotateAroundRadius = new Vector3(0.0f, 0.0f, 0.0f);

    // Start is called before the first frame update.
    void Start()
    {
        // Sets the camera's starting position and angle on the screen in the beginning.
        transform.position = CameraPosition;
        transform.LookAt(CameraAngle);
    }

    // Update is called once per frame.
    void Update()
    {
        // Camera rotation values for orbiting the island.
        transform.RotateAround(CameraRotateAroundRadius, -Vector3.up, 10 * Time.deltaTime);
    }
}
