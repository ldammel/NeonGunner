using System;
using Library.Data.Missions;
using UnityEngine;

namespace Library.Combat.Enemy
{
    public class EnemySpawnController : MonoBehaviour
    {
        [SerializeField] private GameObject[] enemyPrefab;
        [SerializeField] private Transform[] spawnPoints;
        [SerializeField] private Transform rootObj;
        [SerializeField] private ushort spawnAmount;
        public static ushort killedEnemies;
        public static ushort totalKills;

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
