using System.Collections.Generic;
using System.Linq;
using Library.Character;
using Library.Combat.Pooling;
using TMPro;
using UnityEngine;
using Object = UnityEngine.Object;
using Lean.Pool;

public class SpawnNextPatternManager : MonoBehaviour
{
    public static SpawnNextPatternManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There can only be one SpawnNextPatternManager!");
            Application.Quit();
        }

        Instance = this;
    }

    public int levelNumber;

    [SerializeField] private LeanGameObjectPool[] pool;

    [SerializeField] private WaypointMovement playerSpeed;
    [SerializeField] private float speedModifier;

    [SerializeField] private List<GameObject> spawned;
    private void Start()
    {
        playerSpeed = GameObject.Find("---PLAYER---/Player").GetComponent<WaypointMovement>();
    }

    public void UpdateLevelText(TextMeshProUGUI text)
    {
        text.text = "LEVEL: " + levelNumber;
    }

    public void SpawnNextRoom(Component endPoint, int patternNumber)
    {
        if (pool == null) return;
        if(playerSpeed.moveSpeed< playerSpeed.maxSpeed)playerSpeed.moveSpeed += speedModifier;
        var transform1 = endPoint.transform;
        var room = pool[patternNumber].Spawn(transform1.position,transform1.rotation, pool[patternNumber].transform);
        room.GetComponent<EnemyPooled>().Pool = pool[patternNumber];
        spawned.Add(room);
        room.GetComponent<SpawnBuildingsInPattern>().SpawnEnemies();
        if (levelNumber > 9)
        {
            spawned[0].GetComponent<EnemyPooled>().ReturnToPool();
            spawned.Remove(spawned[0]);
        }
        levelNumber++;
        var text = room.GetComponentInChildren<TextMeshProUGUI>();
        UpdateLevelText(text);
    }
}
