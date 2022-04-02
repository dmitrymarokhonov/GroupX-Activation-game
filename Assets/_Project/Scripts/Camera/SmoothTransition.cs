using System;
using System.Collections;
using UnityEngine;

namespace Relanima.Camera
{
    public class SmoothTransition : MonoBehaviour
    {
        private bool _isMoving;
        private bool _isAutoRotateOn;
        private const float TransitionDuration = 0.5f;
        private const float RotationAngle = 45.0f;
        private Vector3 _orbitPoint;
        
        private void Update()
        {
            if (!_isAutoRotateOn) return;
            
            transform.RotateAround(_orbitPoint, -Vector3.up, 5 * Time.deltaTime);
        }

        public void StartTransition(Vector3 targetPosition, Quaternion targetRotation)
        {
            StartCoroutine(SmoothRotationOrTransition(Transition(targetPosition, targetRotation)));
        }

        public void StartRotation(Vector3 rotationDirection)
        {
            StartCoroutine(SmoothRotationOrTransition(Rotate(rotationDirection)));
        }

        public void ToggleAutoRotation()
        {
            _isAutoRotateOn = !_isAutoRotateOn;
        }

        public void SetOrbitPoint(Vector3 orbitPoint)
        {
            _orbitPoint = orbitPoint;
        }
        
        private IEnumerator SmoothRotationOrTransition(IEnumerator routine)
        {
            if (!_isMoving)
            {
                _isMoving = true;
                var wasAutoRotateOn = _isAutoRotateOn;
                _isAutoRotateOn = false;
                
                yield return StartCoroutine(routine);

                _isAutoRotateOn = wasAutoRotateOn;
                _isMoving = false;
            }

            yield return null;
        }
        
        private IEnumerator Rotate(Vector3 rotationDirection)
        {
            float counter = 0;

            while (counter < TransitionDuration)
            {
                counter += Time.deltaTime;
                transform.RotateAround(_orbitPoint, rotationDirection, RotationAngle * Time.deltaTime);
                yield return null;
            }
        }

        private IEnumerator Transition(Vector3 targetPosition, Quaternion targetRotation)
        {
            float counter = 0;

            while (counter < TransitionDuration)
            {
                counter += Time.deltaTime;
                transform.position = Vector3.Lerp(transform.position, targetPosition, counter / TransitionDuration);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, counter / TransitionDuration);
                yield return null;
            }
        }
    }
}