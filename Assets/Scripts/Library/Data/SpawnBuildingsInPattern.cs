using System.Collections;
using Library.Combat.Pooling;
using UnityEngine;
using Random = UnityEngine.Random;
using Lean.Pool;

public class SpawnBuildingsInPattern : MonoBehaviour
{
    [SerializeField] private Transform[] spawnpoints;
    [SerializeField] private EnemySpawner spawner;
    [SerializeField] private LeanGameObjectPool[] pools;
    public int enemySpawners = 0;

    public bool premadeRoom;
    public bool startRoom;

    private void Start()
    {
        if(SpawnNextPatternManager.Instance.levelNumber >= 12) gameObject.GetComponent<ObjectActivator>().ActivateObjects();
        if (premadeRoom) return;
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
        StartCoroutine(Enemies());
    }

    public void PlaceBuildings()
    {
        if (premadeRoom) return;
        for (int i = 0; i < spawnpoints.Length; i++)
        {
            if(!spawnpoints[i].gameObject.activeSelf) continue;
            var transform1 = spawnpoints[i].transform;
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
        if (spawner == null) spawner = gameObject.GetComponentInChildren<EnemySpawner>();
        yield return new WaitForSeconds(0.5f);
        spawner.SpawnEnemies();
    }
}
