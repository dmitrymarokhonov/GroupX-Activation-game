using UnityEngine;

namespace Relanima
{
    public class AudioController : MonoBehaviour
    {
        public AudioClip[] notes;
        private AudioSource _audioSource;
        private int _notesLength;
    
        // Start is called before the first frame update
        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            _notesLength = notes.Length;
        }

        /// <summary>
        /// Get the length of the audio clip array for click sound effects
        /// </summary>
        /// <returns>Length of the audio clip array</returns>
        public int GetNotesLength()
        {
            return _notesLength;
        }
    
        /// <summary>
        /// Plays the correct audio clip based on GameObject's normalized happiness value 
        /// </summary>
        /// <param name="value">Happiness value of a GameObject (Animal)</param>
        public void PlayClip(float value)
        {
            var index = NormalizeValueToRange(value);
        
            if (index < 0 || index > notes.Length - 1)
            {
                Debug.Log("PlayClip index out of bounds with index value: " + index);
                return;
            }
        
            _audioSource.PlayOneShot(notes[index]);
        }

        public void ToggleMuteAudio()
        {
            _audioSource.mute = !_audioSource.mute;
        }

        /// <summary>
        /// Scales given normalized value to accomodate noteArray length.
        /// </summary>
        /// <param name="value">A normalized value in float</param>
        /// <returns>Scaled integer value between 0 and AudioController noteArray length</returns>
        private int NormalizeValueToRange(float value)
        {
            var max = _notesLength - 1;
            var normalizedValue = (int)Mathf.Floor(value * max);
        
            if (normalizedValue > max)
                normalizedValue %= max;
        
            return normalizedValue;
        }
    }
}
