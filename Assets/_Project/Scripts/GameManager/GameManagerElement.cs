using System.Collections.Generic;
using UnityEngine;

namespace Relanima.GameManager
{
    public class GameManagerElement : MonoBehaviour
    {
        public string playerName;
        public int playerScore;
        
        public GameObject cowPrefab;
        public GameObject deerPrefab;
        public GameObject pandaPrefab;
        public GameObject giraffePrefab;

        private readonly List<Extension> boughtExtensions = new List<Extension> { Extension.Cow };
        private readonly Dictionary<Extension, GameObject> extensionPrefab = new Dictionary<Extension, GameObject>();

        public static GameManagerElement instance;

        private void Awake()
        {
            if (instance != null)
            {
                Destroy(this);
            }
            else
            {
                instance = this;
            }
        }

        private void Start()
        {
            extensionPrefab.Add(Extension.Cow, cowPrefab);
            extensionPrefab.Add(Extension.Deer, deerPrefab);
            extensionPrefab.Add(Extension.Panda, pandaPrefab);
            extensionPrefab.Add(Extension.Giraffe, giraffePrefab);
            
            foreach (var extension in boughtExtensions)
            {
                ExtensionMethods.AddAnimals(extensionPrefab[extension]);
            }
        }

        public void AddBoughtAnimalToTheGame(Extension extension)
        {
            ExtensionMethods.AddAnimals(extensionPrefab[extension]);
            boughtExtensions.Add(extension);
        }

        public List<Extension> GetBoughtExtensionsList()
        {
            return boughtExtensions;
        }

        public void AddBoughtExtension(Extension extension)
        {
            boughtExtensions.Add(extension);
        }

        public void AddScore()
        {
            playerScore++;
        }

        public void SetScore(int amount)
        {
            playerScore = amount;
        }

        public void ReduceRewardsBy(int amount)
        {
            playerScore -= amount;
        }

        public int GetScore()
        {
            return playerScore;
        }
    }
}