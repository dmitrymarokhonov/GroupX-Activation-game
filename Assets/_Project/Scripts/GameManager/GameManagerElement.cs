using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Relanima.GameManager
{
    public enum Extension
    {
        Cow,
        Deer,
        Panda,
        Giraffe
    }

    public class GameManagerElement : MonoBehaviour
    {
        public string playerName;
        public int playerScore;
        
        public GameObject cowPrefab;
        public GameObject deerPrefab;
        public GameObject pandaPrefab;
        public GameObject giraffePrefab;

        private List<Extension> boughtExtensions = new List<Extension> { Extension.Cow };
        private Dictionary<Extension, GameObject> extensionPrefab = new Dictionary<Extension, GameObject>();

        private void Start()
        {
            extensionPrefab.Add(Extension.Cow, cowPrefab);
            extensionPrefab.Add(Extension.Deer, deerPrefab);
            extensionPrefab.Add(Extension.Panda, pandaPrefab);
            extensionPrefab.Add(Extension.Giraffe, giraffePrefab);
            foreach (var extension in boughtExtensions)
            {
                ExtensionMethods.InstantiateBoughtExtension(extension, extensionPrefab[extension]);
            }
        }

        public void AddBoughtAnimalToTheGame(Extension extension)
        {
            ExtensionMethods.InstantiateBoughtExtension(extension, extensionPrefab[extension]);
            boughtExtensions.Add(extension);
            Debug.Log("abc");
        }
    }
}