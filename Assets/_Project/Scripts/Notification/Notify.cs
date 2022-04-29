using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

namespace Relanima.Notification
{
    public class Notify : MonoBehaviour
    {
        [SerializeField] private Color infoBackgroundColor;
        [SerializeField] private Color warningBackgroundColor;
        [SerializeField] private Color errorBackgroundColor;
        [SerializeField] private float secondsUntilDisappear;

        private CanvasGroup _canvasGroup;
        private TMP_Text _notificationText;
        private Image _backgroundImage;

        private bool _isShowing;
        
        private const float FadeTime = 1f;
        
        private void Awake()
        {
            _canvasGroup = transform.parent.gameObject.GetComponent<CanvasGroup>();
            _notificationText = GetComponentInChildren<TMP_Text>();
            _backgroundImage = GetComponent<Image>();
            _backgroundImage.color = infoBackgroundColor;
            _notificationText.text = "";
        }

        public void ShowInfo(string text)
        {
            Show(text, infoBackgroundColor);
        }

        public void ShowWarning(string text)
        {
            Show(text, warningBackgroundColor);
        }

        public void ShowError(string text)
        {
            Show(text, errorBackgroundColor);
        }

        public void EmptyPlayerName()
        {
            var localizedMessage =
                LocalizationSettings
                    .StringDatabase
                    .GetLocalizedStringAsync("ErrorMessages", "EMPTY_PLAYER_NAME");
            
            if (localizedMessage.IsDone)
                ShowWarning(localizedMessage.Result);
            else
                localizedMessage.Completed += (message) => Debug.Log(message.Result);
        }
        
        public void SaveFileNotFound()
        {
            var localizedMessage =
                LocalizationSettings
                    .StringDatabase
                    .GetLocalizedStringAsync("ErrorMessages", "SAVE_FILE_NOT_FOUND");
            
            if (localizedMessage.IsDone)
                ShowWarning(localizedMessage.Result);
            else
                localizedMessage.Completed += (message) => Debug.Log(message.Result);
        }

        public void SaveFileDeleted()
        {
            var localizedMessage =
                LocalizationSettings
                    .StringDatabase
                    .GetLocalizedStringAsync("ErrorMessages", "SAVE_FILE_DELETED");
            
            if (localizedMessage.IsDone)
                ShowWarning(localizedMessage.Result);
            else
                localizedMessage.Completed += (message) => Debug.Log(message.Result);
        }

        public void SaveFileDeletionUnsuccessful()
        {
            var localizedMessage =
                LocalizationSettings
                    .StringDatabase
                    .GetLocalizedStringAsync("ErrorMessages", "SAVE_FILE_NOT_DELETED");
            
            if (localizedMessage.IsDone)
                ShowWarning(localizedMessage.Result);
            else
                localizedMessage.Completed += (message) => Debug.Log(message.Result);
        }
        
        private void Show(string text, Color notificationTypeColor)
        {
            if (_isShowing) return;
            _backgroundImage.color = notificationTypeColor;
            StartCoroutine(ShowHide(text));
        }

        private IEnumerator ShowHide(string text)
        {
            _isShowing = true;
            _notificationText.text = text;
            yield return FadeIn();
            yield return new WaitForSeconds(secondsUntilDisappear);
            yield return FadeOut();
            _notificationText.text = "";
            _isShowing = false;
        }

        private IEnumerator FadeIn()
        {
            while (_canvasGroup.alpha < 1)
            {
                _canvasGroup.alpha += Time.deltaTime / FadeTime;
                yield return null;
            }
        }

        private IEnumerator FadeOut()
        {
            while (_canvasGroup.alpha > 0)
            {
                _canvasGroup.alpha -= Time.deltaTime / FadeTime;
                yield return null;
            }
        }
    }
}
