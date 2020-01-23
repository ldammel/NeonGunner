using System;
using Library.Events;
using Library.Tools;
using UnityEngine;

namespace Library.Combat.Pooling
{
    public class EnemySpawner : MonoBehaviour
    {

        public EnemyPool objectPool;
        public Transform[] spawnPoints;

        private void Awake()
        {
            spawnPoints = new Transform[100];
        }

        public void SpawnEnemies()
        {
            for (int i = 0; i < spawnPoints.Length; i++)
            {
                if(spawnPoints[i] == null) continue;
                var enemy = objectPool.Get();
                var transform1 = spawnPoints[i].transform;
                enemy.transform.position = transform1.position;
                enemy.transform.rotation = transform1.rotation;
                enemy.gameObject.SetActive(true);
                LevelEnd.Instance.UpdateEnemies();
            }
        }
    }
}