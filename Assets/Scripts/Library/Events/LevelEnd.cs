using Library.Character;
using Library.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
        [SerializeField] private TextMeshProUGUI reduceStatsText;
        [SerializeField] private TextMeshProUGUI comboText;
        [SerializeField] private Image comboImage;
        [SerializeField] private TextMeshProUGUI waveText;
        [SerializeField] private GameObject rewardObj;
        [SerializeField] private GameObject nova;
        
        public float score;
        public float negativeScore;
        public float totalNegativeScore = 1;
        public int comboNeed = 25;
        public float enemiesKilled = 0;
        public float waveDistance = 180;

        private int _reward;
        private WaypointMovement _waypointMovement;

        private void Start()
        {
            _waypointMovement = GameObject.Find("---PLAYER---/Player").GetComponent<WaypointMovement>();
            if (PlayerPrefs.GetString("Difficulty") == "Easy")
            {
                comboNeed = 50;
            }
            else if (PlayerPrefs.GetString("Difficulty") == "Medium")
            {
                comboNeed = 40;
            }
            else if (PlayerPrefs.GetString("Difficulty") == "Hard")
            {
                comboNeed = 30;
            }
        }

        private void Update()
        {
            statsText.text = "" + score;
            waveText.text = Mathf.Round(waveDistance) + " m";
            reduceStatsText.text = "" + negativeScore;
            comboText.text = enemiesKilled + "/" + comboNeed;
            comboImage.fillAmount = enemiesKilled / comboNeed;
            if (enemiesKilled >= comboNeed) SpawnNova();
        }

        public void End()
        {
            LevelManager.Instance.winScreen.SetActive(true);
            _waypointMovement.moveSpeed = 0;
            CalculateReward();
            PauseMenu.Instance.pauseActive = true;
        }

        private void SpawnNova()
        {
            nova.SetActive(true);
            enemiesKilled = 0;
        }

        public void CalculateReward()
        {
            rewardText.text = "Score: " + score + "\nLevel: " + SpawnNextPatternManager.Instance.levelNumber;
            rewardObj.SetActive(true);
            statsText.gameObject.SetActive(false);
        }

        public void ReduceScore()
        {
            score += negativeScore;
            negativeScore = 0;
        }

    }
}
