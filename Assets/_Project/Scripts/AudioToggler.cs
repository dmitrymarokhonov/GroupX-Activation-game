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

        private bool _isAudioMuted;
        private Image _image;
        private Shadow _shadow;
        private Vector2 _originalShadowDistance;
        private AudioSource _audioSource;

        private void Awake()
        {
            if (UnityEngine.Camera.main != null) _audioSource = UnityEngine.Camera.main.GetComponent<AudioSource>();
            _shadow = GetComponent<Shadow>();
            _originalShadowDistance = _shadow.effectDistance;
            _image = GetComponent<Image>();
        }

        public void ToggleAudio()
        {
            _isAudioMuted = !_isAudioMuted;

            DisplayAudioIcon(_isAudioMuted);
            SetButtonBackgroundColor(_isAudioMuted);
            SetButtonShadowSize(_isAudioMuted);
            SetAudioSourceMute(_isAudioMuted);
        }

        private void SetButtonShadowSize(bool isMuted)
        {
            _shadow.effectDistance = isMuted ? new Vector2(0, 0) : _originalShadowDistance;
        }

        private void SetButtonBackgroundColor(bool isMuted)
        {
            _image.color = isMuted ? audioOffColor : audioOnColor;
        }

        private void DisplayAudioIcon(bool isMuted)
        {
            audioOnObject.SetActive(!isMuted);
            audioOffObject.SetActive(isMuted);
        }

        private void SetAudioSourceMute(bool isMuted)
        {
            _audioSource.mute = isMuted;
        }
    }
}
