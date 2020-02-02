using System;
using Library.Character;
using Library.Combat.Enemy;
using Library.Data;
using TMPro;
using UnityEngine;

namespace Library.Events
{
    public class LevelEnd : MonoBehaviour
    {
        public static LevelEnd Instance;

        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("There can only be one end in a scene!");
                Application.Quit();
                return;
            }
            Instance = this;
        }

        [SerializeField] private TextMeshProUGUI rewardText;
        [SerializeField] private TextMeshProUGUI statsText;
        [SerializeField] private GameObject rewardObj;
        [SerializeField] private CurrencyObject cur;
        public int score;
        public int negativeScore;

        public float enemiesKilled;
        public float totalEnemies;
        public float totalShots;
        public float enemiesMissed;

        public float waveDistance = 180;

        private int _reward;

        private void Start()
        {
            UpdateEnemies();
        }

        public void UpdateEnemies()
        {
            var enemy = FindObjectsOfType<EnemyHealth>();

            for (int i = 0; i < enemy.Length - 1; i++)
            {
                totalEnemies++;
            }
        }

        private void Update()
        {
            statsText.text = "Score: " + score + " (" + negativeScore + ")   -   Wave: " + waveDistance + "m" + "   -   Killed: " + enemiesKilled + " / " + totalEnemies;
        }

        public void End()
        {
            LevelManager.Instance.winScreen.SetActive(true);
            FindObjectOfType<WaypointMovement>().moveSpeed = 0;
            CalculateReward();
            PauseMenu.Instance.pauseActive = true;
        }
        
        public void CalculateReward()
        {
            _reward = Mathf.RoundToInt(enemiesKilled * ((enemiesKilled/totalEnemies)*2) * (SpawnNextPatternManager.Instance.levelNumber/2));
            cur.currentCurrency += _reward;
            score += _reward;
            rewardText.text = "Score: " + score;
            rewardObj.SetActive(true);
            statsText.gameObject.SetActive(false);
        }

        public void ReduceScore()
        {
            score -= negativeScore;
            negativeScore = 0;
        }

    }
}
