using System.Collections;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Camera position, angle and centre rotation points.
    // Vector3 cameraPosition = new Vector3(400.0f, 250.0f, 0.0f);
    // Vector3 cameraAngle = new Vector3(0.0f, 35.0f, 0.0f);
    // Vector3 worldCentre = new Vector3(0.0f, 0.0f, 0.0f);
    Vector3 cameraPosition = new Vector3(400.0f, 250.0f, 0.0f);
    Vector3 cameraAngle = new Vector3(0.0f, 35.0f, 0.0f);
    Vector3 worldCentre = new Vector3(0.0f, 0.0f, 0.0f);

    private bool isAutoRotate;
    bool isMoving = false;
    private int zoomInOrOut;
    private float zoomFactor;
    

    // Start is called before the first frame update.
    void Start()
    {
        // Sets the camera's starting position and angle on the screen in the beginning.
        transform.position = cameraPosition;
        transform.LookAt(cameraAngle);
    }

    // Update is called once per frame.
    void Update()
    {
        // Camera rotation values for orbiting the island.
        if (isAutoRotate)
        {
            transform.LookAt(cameraAngle);
            transform.RotateAround(worldCentre, -Vector3.up, 5 * Time.deltaTime);
        }
    }

    public void ToggleAutoRotation()
    {
        isAutoRotate = !isAutoRotate;
    }

    public void RotateClockwise()
    {
        StartCoroutine(RotateObject(-1));
    }

    public void RotateCounterClockwise()
    {
        StartCoroutine(RotateObject(1));
    }

    public void ZoomIn()
    {
        if (transform.position.y > 72)
        {
            zoomInOrOut = 1;
            zoomFactor = 0.8f;

            StartCoroutine(TransitionZoom(zoomFactor, zoomInOrOut));
        }
    }
    
    public void ZoomOut()
    {
        if (transform.position.y < 500)
        {
            zoomInOrOut = -1;
            zoomFactor = 1.2f;

            StartCoroutine(TransitionZoom(zoomFactor, zoomInOrOut));
        }
    }

    // Smooth rotation.
    IEnumerator RotateObject(int rotationDirection)
    {
        if (isMoving == false)
        {
            isMoving = true;
            yield return StartCoroutine(SmoothRotate(rotationDirection));
            isMoving = false;
            yield return null;
        }
        else
        {
            yield return null;
        }
    }

    IEnumerator SmoothRotate(int rotationDirection)
    {
        float counter = 0, duration = 1.0f;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            transform.RotateAround(worldCentre, rotationDirection * Vector3.up, 100 * Time.deltaTime);
            yield return null;
        }
    }

    // Smooth zoom.
    IEnumerator TransitionZoom(float zoomFactor, int zoomInOrOut)
    {
        if (isMoving == false)
        {
            isMoving = true;
            yield return StartCoroutine(SmoothTransition(zoomFactor, zoomInOrOut));
            isMoving = false;
            yield return null;
        }
        else
        {
            yield return null;
        }
    }

    IEnumerator SmoothTransition(float zoomFactor, int zoomInOrOut)
    {
        float counter = 0, duration = 0.5f;
        Vector3 targetPosition = zoomFactor * transform.position + zoomInOrOut * new Vector3(0.0f, 10.0f, 0.0f);
        
        while (counter < duration)
        {
            counter += Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, targetPosition, counter / duration);
            yield return null;
        }        
    }
}
