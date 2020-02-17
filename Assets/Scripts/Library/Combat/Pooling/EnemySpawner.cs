using Lean.Pool;
using Library.Data;
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
            if(!pat.preMadeRoom)spawnPoints = new Transform[100];
            objectPool= GameObject.Find("---MANAGERS---/PatternPools/EnemyPool").GetComponent<LeanGameObjectPool>();
        }

        public void SpawnEnemies()
        {
            foreach (var t in spawnPoints)
            {
                if(t == null || !t.gameObject.activeSelf) continue;
                var transform1 = t.transform;
                objectPool.Spawn(transform1.position,transform1.rotation, objectPool.transform);
            }
        }
    }
}