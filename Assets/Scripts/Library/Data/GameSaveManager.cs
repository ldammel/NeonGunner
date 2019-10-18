using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
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

        public bool IsSaveFile()
        {
            return Directory.Exists(Application.persistentDataPath + "/Data");
        }

        public void SaveGame()
        {
            if (!IsSaveFile())
            {
                Directory.CreateDirectory(Application.persistentDataPath + "/Data");
            }

            if (!Directory.Exists(Application.persistentDataPath + "/Data/Files"))
            {
                Directory.CreateDirectory(Application.persistentDataPath + "/Data/Files");
            }
            
            BinaryFormatter bf = new BinaryFormatter();

            foreach (var obj in objects)
            {
                FileStream file = File.Create(Application.persistentDataPath + "/Data/Files/" + obj.Name);
                var json = JsonUtility.ToJson(obj);
                bf.Serialize(file,json);
            
                file.Close();
            }
        }

        public void LoadGame()
        {
            if (!Directory.Exists(Application.persistentDataPath + "/Data/Files")) return;
            foreach (var obj in objects)
            {
                if (!File.Exists(Application.persistentDataPath + "/Data/Files/" + obj.Name)) return;
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath + "/Data/Files/"+ obj.Name, FileMode.Open);
                JsonUtility.FromJsonOverwrite((string) bf.Deserialize(file), obj);
                file.Close();
            }
        }
    }
}
