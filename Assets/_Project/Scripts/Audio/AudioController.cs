using UnityEngine;

namespace Relanima.Audio
{
    public class AudioController : MonoBehaviour
    {
        [SerializeField] private AudioClip[] notes;
        [SerializeField] private AudioClip titleScreenMusic;
        [SerializeField] private AudioClip gameFieldMusic;
        
        private AudioSource _audioSource;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            _audioSource.loop = true;
        }

        public void PlayClip(float value)
        {
            var index = NormalizeValueToRange(value);
        
            if (index < 0 || index > notes.Length - 1)
            {
                Debug.Log("PlayClip index out of bounds with index value: " + index);
                return;
            }
        
            _audioSource.PlayOneShot(notes[index], 1);
        }

        public void ToggleMuteAudio()
        {
            _audioSource.mute = !_audioSource.mute;
        }

        public void SetMuteAudio(bool isMuted)
        {
            if (_audioSource == null)
            {
                Debug.Log("AudioSource null");
            }
            _audioSource.mute = isMuted;
        }

        public bool IsAudioMuted()
        {
            return _audioSource.mute;
        }
        
        private int NormalizeValueToRange(float value)
        {
            var max = notes.Length - 1;
            var normalizedValue = (int)Mathf.Floor(value * max);
        
            if (normalizedValue > max)
                normalizedValue %= max;
        
            return normalizedValue;
        }

        public void PlayTitleScreenMusic()
        {
            _audioSource.clip = titleScreenMusic;
            _audioSource.Play();
        }

        public void PlayGameFieldMusic()
        {
            _audioSource.clip = gameFieldMusic;
            _audioSource.Play();
        }
    }
}
