using System;
using Library.Character;
using Library.Combat.Pooling;
using Library.Events;
using TMPro;
using UnityEngine;
using Object = UnityEngine.Object;

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

    [SerializeField] private int levelNumber;

    [SerializeField] private EnemyPool[] pool;

    [SerializeField] private WaypointMovement playerSpeed;
    [SerializeField] private float speedModifier;

    private void Start()
    {
        playerSpeed = GameObject.Find("---PLAYER---/Player").GetComponent<WaypointMovement>();
    }

    public void UpdateLevelText(TextMeshProUGUI text)
    {
        text.text = "LEVEL: " + levelNumber;
    }

    public void SpawnNextRoom(Component endPoint, Object objectToRemove, int patternNumber)
    {
        if (pool == null) return;
        playerSpeed.moveSpeed += speedModifier;
        var room = pool[patternNumber].Get();
        var transform1 = endPoint.transform;
        room.transform.position = transform1.position;
        room.transform.rotation = transform1.rotation;
        room.gameObject.SetActive(true);
        if(objectToRemove != null) Destroy(objectToRemove);
        levelNumber++;
        var text = room.GetComponentInChildren<TextMeshProUGUI>();
        UpdateLevelText(text);
    }
}
