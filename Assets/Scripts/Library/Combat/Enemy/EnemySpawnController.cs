using System;
using UnityEngine;

namespace Library.Combat.Enemy
{
    public class EnemySpawnController : MonoBehaviour
    {
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private Transform[] spawnPoints;
        [SerializeField] private Transform rootObj;
        public ushort spawnAmount;

        public static ushort killedEnemies;
        public static ushort totalKills;

        private void Start()
        {
            SpawnEnemys(spawnAmount);
        }

        private void Update()
        {
            if (killedEnemies < spawnAmount * spawnPoints.Length) return;
            SpawnEnemys(spawnAmount);
            killedEnemies = 0;
        }

        public void SpawnEnemys(ushort count)
        {
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < spawnPoints.Length; j++)
                {
                    Instantiate(enemyPrefab,spawnPoints[j].position, Quaternion.identity, rootObj);
                }
            }
        }
    }
}
