using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.AccessControl;
using Library.Base;
using UnityEngine;

namespace Library.Data
{
    public class GameSaveManager : MonoBehaviour
    {
        public static GameSaveManager Instance;

        public BaseScriptableObject[] objects;

        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("There can only be one instance of GameSaveManager!");
                Destroy(this);
            }
            Instance = this;
            DontDestroyOnLoad(this);
        }

        private void Start()
        {
            Instance.SaveGame();
        }

        public bool IsSaveFile()
        {
            return Directory.Exists(Application.dataPath + "/Data");
        }

        public void SaveGame()
        {
            if (!IsSaveFile())
            {
                Directory.CreateDirectory(Application.dataPath + "/Data");
            }

            if (!Directory.Exists(Application.dataPath + "/Data/Files"))
            {
                Directory.CreateDirectory(Application.dataPath + "/Data/Files");
            }

            BinaryFormatter bf = new BinaryFormatter();

            foreach (var obj in objects)
            {
                FileStream file = File.Create(Application.dataPath + "/Data/Files/" + obj.Name, 265, FileOptions.Encrypted, new FileSecurity(obj.name,AccessControlSections.All));
                var json = JsonUtility.ToJson(obj);
                bf.Serialize(file,json);
            
                file.Close();
            }
        }

        public void LoadGame()
        {
            if (!Directory.Exists(Application.dataPath + "/Data/Files")) return;
            foreach (var obj in objects)
            {
                if (!File.Exists(Application.dataPath + "/Data/Files/" + obj.Name)) return;
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(Application.dataPath + "/Data/Files/"+ obj.Name, FileMode.Open);
                JsonUtility.FromJsonOverwrite((string) bf.Deserialize(file), obj);
                file.Close();
            }
        }
    }
}
