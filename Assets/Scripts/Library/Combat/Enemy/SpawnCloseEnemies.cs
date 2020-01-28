using System;
using System.Collections;
using Lean.Pool;
using Library.Combat.Pooling;
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
        public int spawnedAmount;

        private bool _started;

        private void Update()
        {
            if (spawnedAmount <= amountUntilReset && !_started) StartCoroutine(SpawnEnemies(waitTime));
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Enemy")) NotificationManager.Instance.SetNewNotification("Enemies Incoming from behind!", 5f);
        }

        IEnumerator SpawnEnemies(float initialWait)
        {
            _started = true;
            yield return new WaitForSeconds(initialWait);
            while (spawnedAmount < maxEnemxAmount)
            {
                for (int i = 0; i < spawnPoints.Length; i++)
                {
                    yield return new WaitForSeconds(0.5f);
                    var s = pool.Spawn(spawnPoints[i].position, spawnPoints[i].rotation, pool.transform);
                    spawnedAmount++;
                }
            }
            _started = false;
        }
    }
}
