using System;
using System.Collections;
using System.Collections.Generic;
using Relanima.Audio;
using Relanima.GameSaving;
using Relanima.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Relanima.GameManager
{
    public class GameManagerElement : MonoBehaviour, IGameStatus
    {
        public static GameManagerElement instance;
        
        public string playerName;
        private int _playerResources;

        public GameObject cowPrefab;
        public GameObject deerPrefab;
        public GameObject pandaPrefab;
        public GameObject giraffePrefab;

        private List<Extension> _boughtExtensions = new List<Extension> { Extension.Cow };
        private readonly Dictionary<Extension, GameObject> _extensionPrefab = new Dictionary<Extension, GameObject>();
        
        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(this);
            }
            else
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }

        private void Start()
        {
            _extensionPrefab.Add(Extension.Cow, cowPrefab);
            _extensionPrefab.Add(Extension.Deer, deerPrefab);
            _extensionPrefab.Add(Extension.Panda, pandaPrefab);
            _extensionPrefab.Add(Extension.Giraffe, giraffePrefab);
            
            foreach (var extension in _boughtExtensions)
            {
                ExtensionMethods.AddAnimals(_extensionPrefab[extension]);
            }
        }

        public void AddBoughtAnimalToTheGame(Extension extension)
        {
            ExtensionMethods.AddAnimals(_extensionPrefab[extension]);
            _boughtExtensions.Add(extension);
        }

        public List<Extension> GetBoughtExtensionsList()
        {
            return _boughtExtensions;
        }

        public void AddBoughtExtension(Extension extension)
        {
            _boughtExtensions.Add(extension);
        }

        public void AddScore()
        {
            _playerResources++;
        }

        public void SetResources(int amount)
        {
            _playerResources = amount;
        }

        public void ReduceRewardsBy(int amount)
        {
            _playerResources -= amount;
        }

        public int GetResources()
        {
            return _playerResources;
        }

        public string GetPlayerName()
        {
            return playerName;
        }

        public void SetPlayerName(string plrName)
        {
            playerName = plrName;
        }

        private void ResetGameStatus()
        {
            playerName = "";
            _playerResources = 0;
            _boughtExtensions.Clear();
            _boughtExtensions.Add(Extension.Cow);
            Debug.Log("Game Status is reset.");
        }

        public void SaveGame()
        {
            Debug.Log("Game saved");
            
            var success = SaveSystem.SaveGameStatus(this);
            
            if (!success)
                CancelInvoke();
        }

        public void LoadGame()
        {
            var data = SaveSystem.LoadGameStatus(playerName);
            SetResources(data.resources);
            _boughtExtensions = data.boughtExtensions;
            
            GoToGameField();
        }

        public void GoToGameField()
        {
            StartCoroutine(LoadScene(1, InitiateStartGameActions));
            InvokeRepeating(nameof(SaveGame), 0, 5f);
        }

        private IEnumerator LoadScene(int index, Action doBeforeFadeIn = null)
        {
            var fader = FindObjectOfType<Fader>(true);
            
            yield return fader.FadeOut(2f);
            yield return SceneManager.LoadSceneAsync(index);
            doBeforeFadeIn?.Invoke();
            yield return fader.FadeIn(2f);
        }

        public void LogOut()
        {
            CancelInvoke();
            SaveGame();
            StartCoroutine(LoadScene(0, InitiateLogOutActions));
        }

        private void InitiateStartGameActions()
        {
            var audioController = FindObjectOfType<AudioController>();
            audioController.PlayGameFieldMusic();
        }
        
        private void InitiateLogOutActions()
        {
            var audioController = FindObjectOfType<AudioController>();
            audioController.PlayTitleScreenMusic();
            ResetGameStatus();
        }
    }
}