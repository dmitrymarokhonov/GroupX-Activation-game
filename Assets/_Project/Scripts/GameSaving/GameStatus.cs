using System;
using System.Collections;
using System.Collections.Generic;
using Relanima.Rewards;
using TMPro;
using UnityEditorInternal.VersionControl;
using UnityEngine;
using UnityEngine.UI;

namespace Relanima
{
    public class GameStatus : MonoBehaviour
    {
        public static GameStatus instance;

        public string playerName;

        public static int resources;

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
            resources = RewardManager.RewardCount();
            SaveSystem.SaveGameStatus(this);
        }

        public void LoadGameStatus()
        {
            var data = SaveSystem.LoadGameStatus(GetPlayerName());
            if (data == null) return;
            RewardManager.instance.SetRewardCollected(data.resources);
        }

        public void LoadGameStatusByName(string name)
        {
            var data = SaveSystem.LoadGameStatus(name);
            RewardManager.instance.SetRewardCollected(data.resources);
            playerName = name;
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
    }
}