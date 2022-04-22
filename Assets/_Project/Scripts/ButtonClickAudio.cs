using UnityEngine;
using UnityEngine.UI;

namespace Relanima
{
    public class ButtonClickAudio : MonoBehaviour
    {
        [SerializeField] private AudioClip clickSound;

        private AudioSource _audioSource;
        private Button _button;

        private void Awake()
        {
            if (UnityEngine.Camera.main != null) _audioSource = UnityEngine.Camera.main.GetComponent<AudioSource>();
            _button = GetComponent<Button>();
            _button.onClick.AddListener(() => _audioSource.PlayOneShot(clickSound, 1));
        }
    }
}