using System;
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
        public GameObject failScreen;
        public GameObject winScreen;

        public void RoundEnd(string condition)
        {
            RemoveEnemies();
            levelSelection.SetActive(true);
            switch (condition)
            {
                case "Win":
                    winScreen.SetActive(false);
                    return;
                case "Fail":
                    failScreen.SetActive(false);
                    return;
                default:
                    Debug.LogError("Unknown Condition");
                    return;
            }
        }

        public void Restart()
        {
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
    }
}
