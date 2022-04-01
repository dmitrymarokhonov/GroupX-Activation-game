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

        private bool isAutoRotate, isMoving, isMovingOnXZPlane;
        const float zoomFactorOut = 1.2f;
        const float zoomFactorIn = 1 / zoomFactorOut;
        const float cameraHeightFactor = 1.315f;
        const float cameraXAxisRotationAngle = 4.3f;

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
            const int zoomInOrOut = 1;

            if ((Mathf.Sqrt(Mathf.Pow(transform.position.x, 2.0f) + Mathf.Pow(transform.position.z, 2.0f)) <= 190)
                && (Mathf.Sqrt(Mathf.Pow(transform.position.x, 2.0f) + Mathf.Pow(transform.position.z, 2.0f)) >= 60))
            {
                // Start horizontal zooming.
                isMovingOnXZPlane = true;
                StartCoroutine(TransitionZoom(zoomFactorIn, zoomInOrOut, isMovingOnXZPlane));
            }
            else
            {
                isMovingOnXZPlane = false;
            }

            if (Mathf.Sqrt(Mathf.Pow(transform.position.x, 2.0f) + Mathf.Pow(transform.position.z, 2.0f)) <= 190) return;

            StartCoroutine(TransitionZoom(zoomFactorIn, zoomInOrOut, isMovingOnXZPlane));
        }

        public void ZoomOut()
        {        
            const int zoomInOrOut = -1;

            if (Mathf.Sqrt(Mathf.Pow(transform.position.x, 2.0f) + Mathf.Pow(transform.position.z, 2.0f)) <= 135)
            {
                // Start horizontal zooming.
                isMovingOnXZPlane = true;
                StartCoroutine(TransitionZoom(zoomFactorOut, zoomInOrOut, isMovingOnXZPlane));
            }
            else
            {
                isMovingOnXZPlane = false;
            }

            if (Mathf.Sqrt(Mathf.Pow(transform.position.x, 2.0f) + Mathf.Pow(transform.position.z, 2.0f)) >= 820) return;

            StartCoroutine(TransitionZoom(zoomFactorOut, zoomInOrOut, isMovingOnXZPlane));      
        }

        // Smooth rotation.
        private IEnumerator RotateObject(int rotationDirection)
        {
            if (!isMoving)
            {
                isMoving = true;
                bool isAutoRotateOn = isAutoRotate; 
                isAutoRotate = false;

                yield return StartCoroutine(SmoothRotate(rotationDirection));

                isMoving = false;

                if (isAutoRotateOn)
                {
                    isAutoRotate = true;
                }

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
        private IEnumerator TransitionZoom(float zoomFactor, int zoomInOrOut, bool isMovingOnXZPlane)
        {
            if (!isMoving)
            {
                isMoving = true;
                bool isAutoRotateOn = isAutoRotate;
                isAutoRotate = false;

                yield return StartCoroutine(SmoothTransition(zoomFactor, zoomInOrOut, isMovingOnXZPlane));

                isMoving = false;

                if (isAutoRotateOn)
                {
                    isAutoRotate = true;
                }

                yield return null;
            }
            else
            {
                yield return null;
            }
        }

        private IEnumerator SmoothTransition(float zoomFactor, int zoomInOrOut, bool isMovingOnXZPlane)
        {
            float counter = 0;
            const float duration = 0.5f;

            Vector3 targetPosition = transform.position;
            Quaternion targetRotation = transform.rotation;

            if (!isMovingOnXZPlane)
            {
                targetPosition = zoomFactor * transform.position;

                if (zoomInOrOut == 1)
                {
                    targetPosition.y = 1 / cameraHeightFactor * transform.position.y;
                    targetRotation = transform.rotation * Quaternion.AngleAxis(cameraXAxisRotationAngle, Vector3.left);
                }
                else
                {
                    targetPosition.y = cameraHeightFactor * transform.position.y;
                    targetRotation = transform.rotation * Quaternion.AngleAxis(cameraXAxisRotationAngle, Vector3.right);
                }
            }
            else if (isMovingOnXZPlane)
            {

                targetPosition.x = zoomFactor * transform.position.x;
                targetPosition.z = zoomFactor * transform.position.z;
            }

            while (counter < duration)
            {
                counter += Time.deltaTime;
                transform.position = Vector3.Lerp(transform.position, targetPosition, counter / duration);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, counter / duration);
                yield return null;
            }
        }
    }
}
