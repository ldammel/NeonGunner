using System.Collections.Generic;
using Library.Combat.Enemy;
using UnityEngine;
using UnityEngine.UI;

namespace Library.UI
{
    public class RocketStrikeUI : MonoBehaviour {
        public static RocketStrikeUI Instance;
    
        [SerializeField]
        private GameObject targetPrefab;
        private List<EnemyTarget> targets = new List<EnemyTarget>();
        private Camera mainCamera;

        private struct EnemyTarget {
            public EnemyTarget(EnemyHealth enemy, GameObject targetUi) {
                this.enemy = enemy;
                targetUI = targetUi;
            }

            private EnemyHealth enemy;
            public GameObject targetUI;

            public void Reposition(Camera camera) {
                targetUI.transform.position = camera.WorldToScreenPoint(enemy.transform.position);
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
            mainCamera = GameObject.Find("----CAMERAS----/Camera").GetComponent<Camera>();
        
            if (mainCamera == null) {
                Debug.Log("Could not find camera in " + nameof(RocketStrikeUI), this);
                Application.Quit();
            }
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
    }
}
