using System;
using UnityEngine;

namespace Library.Combat.Enemy
{
    public class EnemySpawnController : MonoBehaviour
    {
        [SerializeField] private GameObject[] enemyPrefab;
        [SerializeField] private Transform[] spawnPoints;
        [SerializeField] private Transform rootObj;
        public ushort spawnAmount;

        public static ushort killedEnemies;
        public static ushort totalKills;

        private void Start()
        {
           // SpawnEnemies(spawnAmount);
        }

        private void Update()
        {
           //if (killedEnemies < spawnAmount * spawnPoints.Length) return;
          //  SpawnEnemies(spawnAmount);
          //  killedEnemies = 0;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            SpawnEnemies(spawnAmount);

        }

        public void SpawnEnemies(ushort count)
        {
            for (int i = 0; i < count; i++)
            {
                foreach (var t in spawnPoints)
                {
                    Instantiate(enemyPrefab[0],t.position, Quaternion.identity, rootObj);
                }
            }
        }
    }
}
