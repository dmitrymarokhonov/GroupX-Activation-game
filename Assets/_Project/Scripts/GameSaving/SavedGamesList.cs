using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Relanima.GameSaving
{
    public class SavedGamesList : MonoBehaviour
    {
        [SerializeField] private GameObject listContent;
        [SerializeField] private GameObject listItemPrefab;

        private List<Tuple<string, string>> _savedFileList = new List<Tuple<string, string>>();
        private InputField _loadGameUserInput;
        
        private void Start()
        {
            RefreshSavedGamesList();
            _loadGameUserInput = GameObject.Find("Load Game Input Username").GetComponent<InputField>();
            _loadGameUserInput.onValueChanged.AddListener(FilterListByName);
        }

        private void FetchSavedGameItems()
        {
            _savedFileList = SaveSystem.GetAllSavedFiles();
        }

        private void DestroyAllListItems()
        {
            foreach (Transform child in listContent.transform)
            {
                Destroy(child.gameObject);
            }
        }

        public void RefreshSavedGamesList()
        {
            DestroyAllListItems();
            _savedFileList.Clear();
            FetchSavedGameItems();
            InstantiateListItems(_savedFileList);
        }

        public void FilterListByName(string playerName)
        {
            if (_savedFileList.Count == 0) return;

            DestroyAllListItems();

            if (playerName.Length == 0)
            {
                InstantiateListItems(_savedFileList);
            }
            else
            {
                var savedFileList = _savedFileList.FindAll(item => item.Item1.ToUpper().Contains(playerName.ToUpper()));
                InstantiateListItems(savedFileList);
            }
        }

        private void InstantiateListItems(List<Tuple<string,string>> savedFileList)
        {
            if (savedFileList.Count == 0) return;
            
            foreach (var saveFile in savedFileList)
            {
                var obj = Instantiate(listItemPrefab, listContent.transform);
                var textFields = obj.GetComponentsInChildren<TMP_Text>();

                // Player name
                textFields[0].text = saveFile.Item1;
                // Date
                textFields[2].text = saveFile.Item2;
            }
        }
    }
}