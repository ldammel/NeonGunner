using System;
using System.Collections.Generic;
using System.Linq;
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
        private List<Mission> missions;
        [SerializeField]
        private CurrencyObject currency;
        [SerializeField] 
        private List<TextMeshProUGUI> missionDisplay;
        [SerializeField] 
        private List<TextMeshProUGUI> progressDisplay;

        private void Start()
        {
            missions = missions.OrderBy(i => i.index).ToList();
        }

        private void Update()
        {
            if (missions == null) return;
            for (int i = 0; i < missionDisplay.Count; i++)
            {
                if (missionDisplay[i] == null || progressDisplay[i] == null) return;
                missionDisplay[i].gameObject.SetActive(missions[i] != null);
                progressDisplay[i].gameObject.SetActive(missions[i] != null);
                if (missions[i] == null) continue;
                missionDisplay[i].text = missions[i].missionDescription;
                progressDisplay[i].text =EnemySpawnController.killedEnemies + " / " + missions[i].missionGoal;
                if (EnemySpawnController.killedEnemies < missions[i].missionGoal) continue;
                currency.currentCurrency += missions[i].reward;
                RemoveMission(i);
            }
        }

        private void RemoveMission(int missionIndex)
        {
            for (int i = 0; i < missions.Count; i++)
            {
                if (i != missionIndex) continue;
                missions.Remove(missions[missionIndex]);
                missions.Add(null);
            }
        }
    }
}
