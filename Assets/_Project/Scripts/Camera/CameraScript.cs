using UnityEngine;

namespace Relanima.Camera
{
    [RequireComponent(typeof(SmoothTransition))]
    public class CameraScript : MonoBehaviour
    {
        // Camera position, angle and centre rotation points.
        private readonly Vector3 _cameraPosition = new Vector3(400.0f, 250.0f, 0.0f);
        private readonly Vector3 _cameraAngle = new Vector3(0.0f, 35.0f, 0.0f);
        private readonly Vector3 _worldCentre = new Vector3(0.0f, 0.0f, 0.0f);

        private const float ZoomFactorOut = 1.2f;
        private const float ZoomFactorIn = 1 / ZoomFactorOut;
        private const float CameraHeightFactor = 1.315f;
        private const float CameraXAxisRotationAngle = 4.3f;

        private SmoothTransition _smoothTransition;

        private void Awake()
        {
            _smoothTransition = gameObject.AddComponent<SmoothTransition>();
        }

        private void Start()
        {
            transform.position = _cameraPosition;
            transform.LookAt(_cameraAngle);
            
            _smoothTransition.SetOrbitPoint(_worldCentre);
        }

        public void ToggleAutoRotation()
        {
            _smoothTransition.ToggleAutoRotation();
        }

        public void RotateClockwise()
        {
            _smoothTransition.StartRotation(Vector3.down);
        }

        public void RotateCounterClockwise()
        {
            _smoothTransition.StartRotation(Vector3.up);
        }

        public void ZoomIn()
        {
            if (PositionInXZPlane() < 60) return;

            Vector3 targetPosition;
            var targetRotation = transform.rotation;

            if (PositionInXZPlane() <= 190)
            {
                targetPosition = TargetPositionOnXZPlane(ZoomFactorIn);
            }
            else
            {
                targetPosition = transform.position * ZoomFactorIn;
                targetPosition.y = transform.position.y * (1 / CameraHeightFactor);
                targetRotation *=  Quaternion.AngleAxis(CameraXAxisRotationAngle, Vector3.left);    
            }            
            
            _smoothTransition.StartTransition(targetPosition, targetRotation);
        }

        public void ZoomOut()
        {
            if (PositionInXZPlane() >= 820) return;

            Vector3 targetPosition;
            var targetRotation = transform.rotation;

            if (PositionInXZPlane() <= 135)
            {
                targetPosition = TargetPositionOnXZPlane(ZoomFactorOut);
            }
            else
            {
                targetPosition = transform.position * ZoomFactorOut;
                targetPosition.y = transform.position.y * CameraHeightFactor;
                targetRotation *= Quaternion.AngleAxis(CameraXAxisRotationAngle, Vector3.right);    
            }
            
            _smoothTransition.StartTransition(targetPosition, targetRotation);
        }

        private Vector3 TargetPositionOnXZPlane(float zoomFactor)
        {
            var targetPosition = transform.position;
            targetPosition.x *= zoomFactor;
            targetPosition.z *= zoomFactor;
            return targetPosition;
        }
        
        private float PositionInXZPlane()
        {
            var pos = transform.position;
            return Mathf.Sqrt(pos.x * pos.x + pos.z * pos.z);
        }
    }
}