using System.Collections;
using UnityEngine;

namespace Relanima
{
    public class CameraScript : MonoBehaviour
    {
        // Camera position, angle and centre rotation points.
        private readonly Vector3 cameraPosition = new Vector3(400.0f, 250.0f, 0.0f);
        private readonly Vector3 cameraAngle = new Vector3(0.0f, 35.0f, 0.0f);
        private readonly Vector3 worldCentre = new Vector3(0.0f, 0.0f, 0.0f);

        private bool isAutoRotate;
        private bool isMoving;

        // Start is called before the first frame update.
        private void Start()
        {
            // Sets the camera's starting position and angle on the screen in the beginning.
            transform.position = cameraPosition;
            transform.LookAt(cameraAngle);
        }

        // Update is called once per frame.
        private void Update()
        {
            // Camera rotation values for orbiting the island.
            if (!isAutoRotate) return;
            
            transform.LookAt(cameraAngle);
            transform.RotateAround(worldCentre, -Vector3.up, 5 * Time.deltaTime);
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
            if (transform.position.y <= 72) return;
            
            const int zoomInOrOut = 1;
            const float zoomFactor = 0.8f;

            StartCoroutine(TransitionZoom(zoomFactor, zoomInOrOut));
        }
    
        public void ZoomOut()
        {
            if (transform.position.y >= 500) return;
            
            const int zoomInOrOut = -1;
            const float zoomFactor = 1.2f;

            StartCoroutine(TransitionZoom(zoomFactor, zoomInOrOut));
        }

        // Smooth rotation.
        private IEnumerator RotateObject(int rotationDirection)
        {
            if (!isMoving)
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

        private IEnumerator SmoothRotate(int rotationDirection)
        {
            float counter = 0;
            const float duration = 1.0f;

            while (counter < duration)
            {
                counter += Time.deltaTime;
                transform.RotateAround(worldCentre, rotationDirection * Vector3.up, 45 * Time.deltaTime);
                yield return null;
            }
        }

        // Smooth zoom.
        private IEnumerator TransitionZoom(float zoomFactor, int zoomInOrOut)
        {
            if (!isMoving)
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

        private IEnumerator SmoothTransition(float zoomFactor, int zoomInOrOut)
        {
            float counter = 0; 
            const float duration = 0.5f;
            Vector3 targetPosition = zoomFactor * transform.position + zoomInOrOut * new Vector3(0.0f, 10.0f, 0.0f);
        
            while (counter < duration)
            {
                counter += Time.deltaTime;
                transform.position = Vector3.Lerp(transform.position, targetPosition, counter / duration);
                yield return null;
            }        
        }
    }
}
