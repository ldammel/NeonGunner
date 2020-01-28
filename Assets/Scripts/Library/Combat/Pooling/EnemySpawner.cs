using System;
using Lean.Pool;
using Library.Events;
using Library.Tools;
using UnityEngine;

namespace Library.Combat.Pooling
{
    public class EnemySpawner : MonoBehaviour
    {

        public SpawnBuildingsInPattern pat;
        public LeanGameObjectPool objectPool;
        public Transform[] spawnPoints;
        

        private void Awake()
        {
            if(!pat.premadeRoom)spawnPoints = new Transform[100];
            objectPool= GameObject.Find("---MANAGERS---/PatternPools/EnemyPool").GetComponent<LeanGameObjectPool>();
        }

        public void SpawnEnemies()
        {
            for (int i = 0; i < spawnPoints.Length; i++)
            {
                if(spawnPoints[i] == null || !spawnPoints[i].gameObject.activeSelf) continue;
                var transform1 = spawnPoints[i].transform;
                objectPool.Spawn(transform1.position,transform1.rotation, objectPool.transform);
            }
            LevelEnd.Instance.UpdateEnemies();
        }
    }
}