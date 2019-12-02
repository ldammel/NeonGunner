using System;
using Library.Combat.Enemy;
using TMPro;
using UnityEngine;

namespace Library.Data.Missions
{
    public class MissionController : MonoBehaviour
    {
        public static MissionController Instance;

        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("There can only be one MissionManager in this Scene!");
                Application.Quit();
            }

            Instance = this;
        }
        
        

        [SerializeField]
        private Mission[] missions;
        [SerializeField]
        private CurrencyObject currency;
        [SerializeField] 
        private TextMeshProUGUI[] missionDisplay;
        [SerializeField] 
        private TextMeshProUGUI[] progressDisplay;

        private void Update()
        {
            for (int i = 0; i < missions.Length; i++)
            {
                if (missionDisplay[i] == null || progressDisplay[i] == null) return;
                missionDisplay[i].text = missions[i].missionDescription;
                if (missions[i].missionType == Mission.MissionType.Kill)
                {
                progressDisplay[i].text =EnemySpawnController.killedEnemies + " / " + missions[i].missionGoal;
                    if (EnemySpawnController.killedEnemies >= missions[i].missionGoal)
                    {
                        currency.currentCurrency += missions[i].reward;
                    }
                }
            }
        }
    }
}
