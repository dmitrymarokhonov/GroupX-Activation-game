using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Relanima.GameSaving
{
    public class SaveSystem : MonoBehaviour
    {
        public static bool SaveGameStatus(IGameStatus status)
        {
            var playerName = status.GetPlayerName(); 
            
            if (playerName.Length < 1)
            {
                Debug.LogWarning("Empty name given");
                return false;
            }
            
            BinaryFormatter formatter = new BinaryFormatter();
            string path = GetSaveFilePath(status.GetPlayerName());
            FileStream stream = new FileStream(path, FileMode.Create);

            GameData data = new GameData(status.GetResources(), status.GetBoughtExtensionsList());
            
            formatter.Serialize(stream, data);
            stream.Close();

            return true;
        }

        public static GameData LoadGameStatus(string playerName)
        {
            string path = GetSaveFilePath(playerName);
            if (!File.Exists(path))
            {
                Debug.LogWarning("Save file does not exists in " + path);
                return null;
            }

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            
            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();
            
            return data;
        }

        public static List<Tuple<string, string>> GetAllSavedFiles()
        {
            if (!Directory.Exists(Application.persistentDataPath))
            {
                return new List<Tuple<string, string>>();
            }

            List<Tuple<string, string>> saves = new List<Tuple<string, string>>();
            DirectoryInfo directoryInfo = new DirectoryInfo(Application.persistentDataPath);
            foreach (var file in directoryInfo.GetFiles(".*save"))
            {
                var name = Path.GetFileNameWithoutExtension(file.FullName);
                var time = file.LastWriteTime.ToLocalTime().ToString();
                saves.Add(new Tuple<string, string>(name, time));
            }

            return saves;
        }

        private static string GetSaveFilePath(string playerName)
        {
            return Application.persistentDataPath + "/" + playerName + ".save";
        }
    }
}