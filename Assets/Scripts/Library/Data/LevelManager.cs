using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Library.Data
{
    public class LevelManager : MonoBehaviour
    {
        public static LevelManager Instance;
        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("There can only be one LevelManager in this Scene !");
                Application.Quit();
            }
            Instance = this;
        }

        public GameObject levelSelection;
        public GameObject failScreen;
        public GameObject winScreen;

        private void Start()
        {
            SaveData.Instance.LoadAllData();
        }

        public void RoundEnd()
        {
            RemoveEnemies();
            winScreen.SetActive(false);
            failScreen.SetActive(false);
            levelSelection.SetActive(true);
        }

        public void Restart()
        {
            SaveData.Instance.SaveAllData();
            SceneManager.LoadScene(1);
        }

        public void RemoveEnemies()
        {
            var enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (var e in enemies)
            {
                Destroy(e);
            }
        }
    }
}
