using UnityEngine;

namespace Billboard
{
    public class Billboard : MonoBehaviour
    {
        private Camera mainCamera;
        private Transform mainCameraT;

        private void LateUpdate()
        {
            mainCamera = Camera.main;
            mainCameraT = mainCamera.transform;
            transform.LookAt(transform.position + mainCameraT.forward);
        }
    }
}