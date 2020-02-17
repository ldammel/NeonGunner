using Lean.Pool;
using UnityEngine;

namespace Library.Combat.Enemy
{
    public class SpawnBomb : MonoBehaviour
    {
        public LeanGameObjectPool objectPool;
        public Transform[] spawnPoints;
        

        private void Awake()
        {
            objectPool= GameObject.Find("---MANAGERS---/PatternPools/ExplodingEnemyPool").GetComponent<LeanGameObjectPool>();
        }

        private void SpawnEnemies()
        {
            if (PlayerPrefs.GetString("Difficulty") == "Easy") return;
            foreach (var t in spawnPoints)
            {
                if(t == null) continue;
                var transform1 = t.transform;
                objectPool.Spawn(transform1.position,transform1.rotation, objectPool.transform);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player")) SpawnEnemies();
        }
    }
}
