using System.Collections;
using Lean.Pool;
using Library.Character;
using Library.Events;
using Library.UI;
using UnityEngine;

namespace Library.Combat.Enemy
{
    public class SpawnCloseEnemies : MonoBehaviour
    {
        public static SpawnCloseEnemies Instance;


        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("There can only be one Instance of SpawnCloseEnemy!");
                Application.Quit();
            }

            Instance = this;
        }

        [SerializeField] private Transform[] spawnPoints;
        [SerializeField] private LeanGameObjectPool pool;
        [SerializeField] private int amountUntilReset;
        [SerializeField] private int maxEnemyAmount;
        [SerializeField] private int waitTime;
        public GameObject warningImage;
        public int spawnedAmount;
        public bool onPoint;


        private bool _started;
        private IEnumerator _enumerator;

        private void Start()
        {
            _enumerator = SpawnEnemies(waitTime);
        }
        
        private void Update()
        {
            if (PlayerPrefs.GetString("Difficulty") == "Easy") return;
            if (PlayerPrefs.GetString("Difficulty") == "Medium") return;
            if (spawnedAmount <= amountUntilReset && !_started) StartCoroutine(_enumerator);
            warningImage.SetActive(onPoint);
            if(onPoint)WaveMovement.Instance.ReducePosition();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.name.Contains("Close") && GameObject.Find("---PLAYER---/Player").GetComponent<WaypointMovement>().moveSpeed > 15)
            {
                NotificationManager.Instance.SetNewNotification("Enemies Incoming from behind!", 2f, Color.red);
                onPoint = true;
            }
            else
            {
                onPoint = false;
            }
        }

        private IEnumerator SpawnEnemies(float initialWait)
        {
            _started = true;
            onPoint = false;
            UpdatePos();
            yield return new WaitForSeconds(initialWait);
            onPoint = false;
            while (spawnedAmount < maxEnemyAmount)
            {
                foreach (var t in spawnPoints)
                {
                    yield return new WaitForSeconds(0.5f);
                    var s = pool.Spawn(t.position, t.rotation, pool.transform);
                    s.GetComponent<CloseEnemy>().spawn = this;
                    spawnedAmount++;
                }
            }
            _started = false;
        }

        private void UpdatePos()
        {
            LevelEnd.Instance.ReduceScore();
            onPoint = false;
        }
        
        
    }
}
