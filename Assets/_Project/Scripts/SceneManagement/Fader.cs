using System;
using System.Collections;
using UnityEngine;

namespace Relanima.SceneManagement
{
    public class Fader : MonoBehaviour
    {
        private CanvasGroup _canvasGroup;

        private void Start()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
            gameObject.SetActive(false);
        }

        public IEnumerator FadeOut(float time)
        {
            gameObject.SetActive(true);
            while (_canvasGroup.alpha < 1)
            {
                _canvasGroup.alpha += Time.deltaTime / time;
                yield return null;
            }
        }
        
        public IEnumerator FadeIn(float time)
        {
            while (_canvasGroup.alpha > 0)
            {
                _canvasGroup.alpha -= Time.deltaTime / time;
                yield return null;
            }
            gameObject.SetActive(false);
        }
    }
}
