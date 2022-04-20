using UnityEngine;

namespace Relanima
{
    public class AudioToggler : MonoBehaviour
    {
        private bool _isAudioEnabled = true;

        [SerializeField] private GameObject audioOnObject;
        [SerializeField] private GameObject audioOffObject;
        
        public void ToggleAudio()
        {
            _isAudioEnabled = !_isAudioEnabled;
            if (_isAudioEnabled)
            {
                audioOnObject.SetActive(true);
                audioOffObject.SetActive(false);
            }
            else
            {
                audioOnObject.SetActive(false);
                audioOffObject.SetActive(true);
            }
        }
    }
}
