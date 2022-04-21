using UnityEngine;
using UnityEngine.UI;

namespace Relanima
{
    public class AudioToggler : MonoBehaviour
    {
        [SerializeField] private GameObject audioOnObject;
        [SerializeField] private Color audioOnColor;
        [SerializeField] private GameObject audioOffObject;
        [SerializeField] private Color audioOffColor;

        private bool _isAudioEnabled = true;
        private Image _image;
        private Shadow _shadow;
        private Vector2 _originalShadowDistance;
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = UnityEngine.Camera.main.GetComponent<AudioSource>();
            _shadow = GetComponent<Shadow>();
            _originalShadowDistance = _shadow.effectDistance;
            _image = GetComponent<Image>();
        }

        public void ToggleAudio()
        {
            _isAudioEnabled = !_isAudioEnabled;
            if (_isAudioEnabled)
            {
                audioOnObject.SetActive(true);
                audioOffObject.SetActive(false);
                _image.color = audioOnColor;
                _shadow.effectDistance = _originalShadowDistance;
                _audioSource.mute = false;
            }
            else
            {
                audioOnObject.SetActive(false);
                audioOffObject.SetActive(true);
                _image.color = audioOffColor;
                _shadow.effectDistance = new Vector2(0, 0);
                _audioSource.mute = true;
            }
        }
    }
}
