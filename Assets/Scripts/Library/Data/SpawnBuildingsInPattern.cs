
using System;
using Library.Combat.Pooling;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnBuildingsInPattern : MonoBehaviour
{
    [SerializeField] private GameObject[] buildings;
    [SerializeField] private Transform[] spawnpoints;
    [SerializeField] private EnemySpawner spawner;
    public int _enemySpawners = 0;

    private void Start()
    {
        PlaceBuildings();
    }

    public void PlaceBuildings()
    {
        for (int i = 0; i < spawnpoints.Length; i++)
        {
           var go = Instantiate(buildings[Random.Range(0, buildings.Length)], spawnpoints[i]);
           var es = go.GetComponentsInChildren<EnemySpawnPoint>();
           foreach (var t in es)
           {
               spawner.spawnPoints[_enemySpawners] = t.point;
               _enemySpawners++;
           }
        }
        spawner.SpawnEnemies();
    }

}
