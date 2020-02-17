using System.Collections.Generic;
using Lean.Pool;
using Library.Character;
using Library.Combat.Pooling;
using TMPro;
using UnityEngine;

namespace Library.Data
{
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
        [SerializeField] private GameObject laneImages;

        public bool tutorial;
        private void Start()
        {
            playerSpeed = GameObject.Find("---PLAYER---/Player").GetComponent<WaypointMovement>();
        }

        public void UpdateLevelText(TextMeshProUGUI text)
        {
            if(text != null)text.text = "LEVEL: " + levelNumber;
        }

        public void SpawnNextRoom(Component endPoint, int patternNumber)
        {
            if (pool == null)
            {
                Debug.LogError("Could not find a Room!");
                return;
            }
            if(playerSpeed.moveSpeed< playerSpeed.maxSpeed)playerSpeed.moveSpeed += speedModifier;
            var transform1 = endPoint.transform;
            var room = pool[patternNumber].Spawn(transform1.position,transform1.rotation, pool[patternNumber].transform);
            room.GetComponent<EnemyPooled>().Pool = pool[patternNumber];
            spawned.Add(room);
            if(room.GetComponent<SpawnBuildingsInPattern>() != null)room.GetComponent<SpawnBuildingsInPattern>().SpawnEnemies();
            laneImages.SetActive(levelNumber > 12);
            if (levelNumber > 9 && !tutorial)
            {
                spawned[0].GetComponent<EnemyPooled>().ReturnToPool();
                spawned.Remove(spawned[0]);
            }
            else if (tutorial && levelNumber > 20)
            {
                spawned[0].GetComponent<EnemyPooled>().ReturnToPool();
                spawned.Remove(spawned[0]);
            }
            levelNumber++;
            var text = room.GetComponentInChildren<TextMeshProUGUI>();
            UpdateLevelText(text);
        }
    }
}
