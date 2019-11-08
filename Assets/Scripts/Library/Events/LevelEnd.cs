using System;
using System.Globalization;
using Library.Character.Upgrades;
using Library.Combat.Enemy;
using Library.Data;
using Library.Tools;
using Library.UI;
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

        private float _reward;
        private float _timeTaken;
        public float timeLimitSeconds;
        public int timeLimitMinutes;
        private UpgradeManager _manager;
        private float baseSeconds;
        private int baseMinutes;
        [SerializeField] private TextMeshProUGUI timeText;
        [SerializeField] private TextMeshProUGUI timeTakenText;
        

        private void Start()
        {
            _manager = FindObjectOfType<UpgradeManager>();
            _timeTaken = 0;
            baseMinutes = timeLimitMinutes;
            baseSeconds = timeLimitSeconds;
        }

        private void Update()
        {
            if (PauseMenu.Instance.pauseActive) return;
            
            timeLimitSeconds -= 1 * Time.deltaTime;
            _timeTaken += 1 * Time.deltaTime;
            if (timeLimitSeconds <= 0 && timeLimitMinutes > 0)
            {
                timeLimitSeconds = 59;
                timeLimitMinutes--;
            }
            else if (timeLimitSeconds <= 0 && timeLimitMinutes == 0)
            {
                //GameOver
            }

            timeText.text = Mathf.RoundToInt(timeLimitMinutes) + ":" + Mathf.RoundToInt(timeLimitSeconds);
            timeTakenText.text = Mathf.RoundToInt(_timeTaken).ToString(CultureInfo.CurrentCulture);
        }

        private void OnCollisionEnter(Collision other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            LevelManager.Instance.winScreen.SetActive(true);
            CalculateReward(3);
            PauseMenu.Instance.pauseActive = true;
        }
        
        public void CalculateReward(int reward)
        {
            _reward = Mathf.Round((((EnemySpawnController.totalKills * Design.Instance.currencyGainPerEnemy)/(_timeTaken/10)) +(GameObject.FindGameObjectWithTag("Player").GetComponent<EnemyHealth>().curHealth/50))*reward);
            _manager.upgrades.currentCurrency += (int)_reward;
            _timeTaken = 0;
            EnemySpawnController.totalKills = 0;
            EnemySpawnController.killedEnemies = 0;
            timeLimitMinutes = baseMinutes;
            timeLimitSeconds = baseSeconds;
            NotificationManager.Instance.SetNewNotification("Gained " +_reward+ " Money",3);
        }

    }
}
