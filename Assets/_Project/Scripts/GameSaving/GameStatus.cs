using System.Collections.Generic;
using Relanima.GameManager;
using Relanima.Rewards;
using UnityEngine;

namespace Relanima.GameSaving
{
    public class GameStatus : MonoBehaviour, IGameStatus
    {
        public static GameStatus instance;

        public string playerName;

        public static int resources;

        public List<Extension> boughtExtensions = new List<Extension>
            {Extension.Cow, Extension.Deer};

        private void Awake()
        {
            if (instance)
            {
                Destroy(this);
            }
            else
            {
                instance = this;
            }
        }

        public void SaveGameStatus()
        {
            resources = GameManagerElement.instance.GetResources();
            SaveSystem.SaveGameStatus(this);
        }

        public void LoadGameStatus()
        {
            var data = SaveSystem.LoadGameStatus(GetPlayerName());
            if (data == null) return;
            GameManagerElement.instance.SetResources(data.resources);
        }

        public void LoadGameStatusByName(string plrName)
        {
            var data = SaveSystem.LoadGameStatus(plrName);
            GameManagerElement.instance.SetResources(data.resources);
            playerName = plrName;
        }

        public void ResetGameStatus()
        {
            playerName = "";
            resources = 0;
        }

        public string GetPlayerName()
        {
            Debug.Log(playerName);
            return playerName;
        }

        public int GetResources()
        {
            return resources;
        }

        public List<Extension> GetBoughtExtensionsList()
        {
            return boughtExtensions;
        }
    }
}