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
        public float score;
        public float negativeScore;
        public float totalNegativeScore = 1;

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
            statsText.text = "Score: " + score + " (" + negativeScore + ")   -   Wave: " + Mathf.RoundToInt(waveDistance) + "m";
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
            rewardText.text = "Score: " + score + "\nLevel: " + SpawnNextPatternManager.Instance.levelNumber;
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
