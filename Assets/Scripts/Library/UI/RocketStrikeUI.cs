using System.Collections.Generic;
using Library.Combat.Enemy;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

public class RocketStrikeUI : MonoBehaviour {
    public static RocketStrikeUI Instance;
    
    [SerializeField, Required]
    private GameObject targetPrefab;
    
    [SerializeField, Required]
    private Image imageRocketIndicator;

    private int activeRocketIndicatorSegments;
    public List<EnemyTarget> targets = new List<EnemyTarget>();
    private Camera mainCamera;
    private const int ROCKET_COUNT = 16;

    public struct EnemyTarget {
        public EnemyTarget(EnemyHealth enemy, GameObject targetUi) {
            this.enemy = enemy;
            targetUI = targetUi;
        }

        private EnemyHealth enemy;
        public GameObject targetUI;

        public void Reposition(Camera camera)
        {
            if (enemy == null) return;
            targetUI.transform.position = camera.WorldToScreenPoint(enemy.gameObject.transform.position);
            var newScale = 1f - Mathf.PingPong(Time.time * 0.25f, 0.2f);
            targetUI.transform.localScale = new Vector3(newScale, newScale, newScale);
            targetUI.transform.Rotate(new Vector3(0f, 0f, 5f));
            targetUI.gameObject.SetActive(targetUI.transform.position.z >= 0);
        }
    }

    private void Start() {
        if (Instance != null) {
            Debug.LogWarning(nameof(RocketStrikeUI) + " is a singleton class and may only be initialized once", this);
            Application.Quit();
        }

        Instance = this;
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        
        if (mainCamera == null) {
            Debug.Log("Could not find camera");
            Application.Quit();
        }

        activeRocketIndicatorSegments = ROCKET_COUNT;
    }

    private void Update() {
        targets.ForEach(t => t.Reposition(mainCamera));
    }

    public static void AddRocketTarget(EnemyHealth enemy) {
        var enemyTarget = new EnemyTarget(enemy, Instantiate(Instance.targetPrefab, Instance.transform));
        Instance.targets.Add(enemyTarget);
    }

    public static void ResetTargets() {
        Instance.targets.ForEach(t => Destroy(t.targetUI));
        Instance.targets.Clear();
    }

    public static void ReduceRocketIndicator() {
        Instance.imageRocketIndicator.fillAmount = --Instance.activeRocketIndicatorSegments / (float)ROCKET_COUNT;
    }

    public static void ResetRocketIndicator() {
        Instance.activeRocketIndicatorSegments = ROCKET_COUNT;
        Instance.imageRocketIndicator.fillAmount = 1f;
    }
}
