using Lean.Pool;
using Library.Events;
using UnityEngine;

public class SpawnBomb : MonoBehaviour
{
    public LeanGameObjectPool objectPool;
    public Transform[] spawnPoints;
        

    private void Awake()
    {
        objectPool= GameObject.Find("---MANAGERS---/PatternPools/ExplodingEnemyPool").GetComponent<LeanGameObjectPool>();
    }
    
    public void SpawnEnemies()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if(spawnPoints[i] == null) continue;
            var transform1 = spawnPoints[i].transform;
            objectPool.Spawn(transform1.position,transform1.rotation, objectPool.transform);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) SpawnEnemies();
    }
}
