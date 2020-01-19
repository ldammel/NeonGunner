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

        public float enemiesKilled;
        public float totalEnemies;
        public float totalShots;

        private float _accuracy;

        private int _reward;

        private void Start()
        {
            var enemy = FindObjectsOfType<EnemyHealth>();

            for (int i = 0; i < enemy.Length -1; i++)
            {
                totalEnemies++;
            }
        }

        private void Update()
        {
            _accuracy = Mathf.Round((enemiesKilled / totalShots)*100);
            if (float.IsNaN(_accuracy)) _accuracy = 0;
            if (_accuracy <= 0) _accuracy = 0;
            statsText.text = "Kills: " + enemiesKilled + " / " + totalEnemies+ "\n" + "\nAccuracy: "+ _accuracy + "%\n";
        }

        private void OnCollisionEnter(Collision other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            LevelManager.Instance.winScreen.SetActive(true);
            FindObjectOfType<WaypointMovement>().moveSpeed = 0;
            CalculateReward();
            PauseMenu.Instance.pauseActive = true;
        }
        
        public void CalculateReward()
        {
            _reward = Mathf.RoundToInt((enemiesKilled * (_accuracy/100))*((enemiesKilled/totalEnemies)*2));
            cur.currentCurrency += _reward;
            rewardText.text = "Kills: " + enemiesKilled + " / " + totalEnemies+ "\n" + "\nAccuracy: "+ _accuracy + "%\n" + "\nReward: " + _reward;
            rewardObj.SetActive(true);
            statsText.gameObject.SetActive(false);
        }

    }
}
