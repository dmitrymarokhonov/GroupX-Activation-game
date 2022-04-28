using UnityEngine;
using UnityEngine.UI;

namespace Relanima.Audio
{
    public class ButtonClickAudio : MonoBehaviour
    {
        [SerializeField] private AudioClip clickSound;

        private AudioSource _audioSource;
        private Button _button;

        private void Awake()
        {
            _audioSource = FindObjectOfType<AudioSource>();
            _button = GetComponent<Button>();
            _button.onClick.AddListener(() => _audioSource.PlayOneShot(clickSound, 1));
        }
    }
}