using UnityEngine;

namespace Relanima
{
    public class AudioController : MonoBehaviour
    {
        public AudioClip[] notes;
        private AudioSource _audioSource;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
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
        
        private int NormalizeValueToRange(float value)
        {
            var max = notes.Length - 1;
            var normalizedValue = (int)Mathf.Floor(value * max);
        
            if (normalizedValue > max)
                normalizedValue %= max;
        
            return normalizedValue;
        }
    }
}
