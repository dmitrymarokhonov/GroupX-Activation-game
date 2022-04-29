using Relanima.Notification;
using TMPro;
using UnityEngine;

namespace Relanima.GameSaving
{
    public class DeleteSavedGame : MonoBehaviour
    {
        public void DeleteFile()
        {
            var textElements = GetComponentsInChildren<TMP_Text>();
            var playerName = textElements[0].text;
            var notifier = FindObjectOfType<Notify>();
            
            if (SaveSystem.DeleteSaveFile(playerName))
            {
                notifier.SaveFileDeleted();
                GetComponentInParent<SavedGamesList>().RefreshSavedGamesList();
            }
            else
            {
                notifier.SaveFileDeletionUnsuccessful();
            }
            
        }
    }
}