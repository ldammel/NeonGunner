using System;
using System.Collections;
using Library.Combat.Enemy;
using Library.Events;
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
        public GameObject upgradeScreen;
        public GameObject failScreen;
        public GameObject winScreen;

        private void Start()
        {
            StartCoroutine(StartGame());
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
            EnemySpawnController.totalKills = 0;
            EnemySpawnController.killedEnemies = 0;
            foreach (var e in enemies)
            {
                Destroy(e);
            }
        }

        IEnumerator StartGame()
        {
            levelSelection.SetActive(true);
            upgradeScreen.SetActive(true);
            yield return new WaitForSeconds(0.03f);
            upgradeScreen.SetActive(false);
            levelSelection.SetActive(false);
        }
    }
}
