using System.Collections;
using Lean.Pool;
using Library.Combat.Pooling;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Library.Data
{
    public class SpawnBuildingsInPattern : MonoBehaviour
    {
        [SerializeField] private Transform[] spawnPoints;
        [SerializeField] private EnemySpawner spawner;
        [SerializeField] private LeanGameObjectPool[] pools;
        public int enemySpawners = 0;

        public bool preMadeRoom;
        public bool startRoom;

        private void Start()
        {
            if (spawner == null) spawner = gameObject.GetComponentInChildren<EnemySpawner>();
            if(SpawnNextPatternManager.Instance.levelNumber > 11 && gameObject.GetComponent<ObjectActivator>() != null) gameObject.GetComponent<ObjectActivator>().ActivateObjects();
            if (preMadeRoom) return;
            pools = new LeanGameObjectPool[4];
            var x = GameObject.FindGameObjectsWithTag("patterns");
            pools[0] = x[0].GetComponent<LeanGameObjectPool>();
            pools[1] = x[1].GetComponent<LeanGameObjectPool>();
            pools[2] = x[2].GetComponent<LeanGameObjectPool>();
            pools[3] = x[3].GetComponent<LeanGameObjectPool>();
            PlaceBuildings();
        }

        public void SpawnEnemies()
        {
            if(SpawnNextPatternManager.Instance.levelNumber > 11 && gameObject.GetComponent<ObjectActivator>() != null) gameObject.GetComponent<ObjectActivator>().ActivateObjects();
            StartCoroutine(Enemies());
        }

        private void PlaceBuildings()
        {
            if (preMadeRoom) return;
            foreach (var t1 in spawnPoints)
            {
                if(!t1.gameObject.activeSelf) continue;
                var transform1 = t1.transform;
                var go = pools[Random.Range(0, pools.Length)];
                var spawned = go.Spawn(transform1.position, transform1.rotation, transform);
                spawned.GetComponent<EnemyPooled>().Pool = go;
                var es = spawned.GetComponentsInChildren<EnemySpawnPoint>();
                foreach (var t in es)
                {
                    spawner.spawnPoints[enemySpawners] = t.point;
                    enemySpawners++;
                }
            }
            if(startRoom) SpawnEnemies();
        }

        private IEnumerator Enemies()
        {
            yield return new WaitForSeconds(0.5f);
            spawner.SpawnEnemies();
        }
    }
}
