using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Relanima
{
    public class SceneSwitcher : MonoBehaviour
    {
        [SerializeField] private Animator transition;
        private static readonly int Start = Animator.StringToHash("start");
        [SerializeField] private float transitionTime;

        private enum Scenes
        {
            TitleScreen,
            GameField
        }

        public void GoToGameField()
        {
            GoTo(Scenes.GameField);
        }

        public void GoToTitleScreen()
        {
            GoTo(Scenes.TitleScreen);
        }

        private void GoTo(Scenes scene)
        {
            StartCoroutine(LoadScene(scene.GetHashCode()));
        }

        private IEnumerator LoadScene(int sceneIndex)
        {
            transition.SetTrigger(Start);

            yield return new WaitForSeconds(transitionTime);
            
            SceneManager.LoadScene(sceneIndex);
        }
    }
}