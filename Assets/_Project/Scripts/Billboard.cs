using UnityEngine;

namespace Relanima
{
    public class Billboard : MonoBehaviour
    {
        public Transform cam;

        private void LateUpdate()
        {
            transform.LookAt(transform.position + cam.forward);    
        }
    }
}