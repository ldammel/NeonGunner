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
        [SerializeField] private int maxEnemxAmount;
        [SerializeField] private int waitTime;
        public GameObject warningImage;
        public int spawnedAmount;
        public bool onPoint;


        private bool _started;

        private void Update()
        {
            if (spawnedAmount <= amountUntilReset && !_started) StartCoroutine(SpawnEnemies(waitTime));
            warningImage.SetActive(onPoint);
            WaveMovement.Instance.ReducePosition();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy") && GameObject.Find("---PLAYER---/Player").GetComponent<WaypointMovement>().moveSpeed > 15)
            {
                NotificationManager.Instance.SetNewNotification("Enemies Incoming from behind!", 2f, Color.red);
                onPoint = true;
            }
            else
            {
                onPoint = false;
            }
        }

        IEnumerator SpawnEnemies(float initialWait)
        {
            _started = true;
            onPoint = false;
            UpdatePos();
            yield return new WaitForSeconds(initialWait);
            onPoint = false;
            while (spawnedAmount < maxEnemxAmount)
            {
                for (int i = 0; i < spawnPoints.Length; i++)
                {
                    yield return new WaitForSeconds(0.5f);
                    var s = pool.Spawn(spawnPoints[i].position, spawnPoints[i].rotation, pool.transform);
                    s.GetComponent<CloseEnemy>().spawn = this;
                    spawnedAmount++;
                }
            }
            _started = false;
        }

        public void UpdatePos()
        {
            LevelEnd.Instance.ReduceScore();
            onPoint = false;
        }
        
        
    }
}
