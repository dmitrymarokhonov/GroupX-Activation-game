using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditorInternal.VersionControl;
using UnityEngine;
using UnityEngine.UI;

namespace Relanima
{
    public class GameStatus : MonoBehaviour
    {
        public GameObject playerNameField;
        public GameObject savedGamesList;
        public GameObject listItemPrefab;
        public int resources;
        public TextMeshProUGUI resourceDisplay;

        private void GetAllSavedGames()
        {
            var saveDatalist = SaveSystem.GetAllSavedFiles();
            var listContent = savedGamesList.GetComponentInChildren<VerticalLayoutGroup>();

            foreach (var dataItem in saveDatalist)
            {
                var obj = Instantiate(listItemPrefab, listContent.transform);
                var texts = obj.GetComponentsInChildren<Text>();
                texts[0].text = dataItem.Item1;
                texts[1].text = dataItem.Item2;
            }
        }
        
        private void DestroyAllChildrenOf(GameObject obj)
        {
            foreach (Transform child in obj.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }

        private void DisplayGameStatus()
        {
            resourceDisplay.text = resources.ToString();
        }
        public void PrintTest()
        {
            Debug.Log("Button pressed");
        }
        
        

        public void SaveGameStatus()
        {
            SaveSystem.SaveGameStatus(this);
            DestroyAllChildrenOf(savedGamesList.GetComponentInChildren<VerticalLayoutGroup>().gameObject);
            GetAllSavedGames();
        }

        public void LoadGameStatus()
        {
            var data = SaveSystem.LoadGameStatus(GetPlayerName());
            if (data == null) return;

            resources = data.resources;
            DisplayGameStatus();
        }

        public void LoadGameStatusByName(string name)
        {
            var data = SaveSystem.LoadGameStatus(name);
            resources = data.resources;
            playerNameField.GetComponentInChildren<TMP_InputField>().text = name;
            DisplayGameStatus();
        }

        public void ResetGameStatus()
        {
            playerNameField.GetComponentInChildren<TMP_InputField>().text = "";
            resources = 0;
            DisplayGameStatus();
        }

        public string GetPlayerName()
        {
            //playerNameField.GetComponentInChildren<TMP_InputField>().text = "player_name";
            //return playerNameField.GetComponentInChildren<TMP_InputField>().text;
            return "player_name";
        }

    }
}
