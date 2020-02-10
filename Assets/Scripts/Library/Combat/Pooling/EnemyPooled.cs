using Lean.Pool;
using Library.Combat.Enemy;
using Library.Events;
using UnityEngine;

namespace Library.Combat.Pooling
{
    public class EnemyPooled : MonoBehaviour
    {
        public LeanGameObjectPool pool;
        public bool isCloseEnemy;
        public bool isBomb;

        public LeanGameObjectPool Pool
        {
            get => pool;
            set
            {
                if (pool == null)
                    pool = value;
            }
        }

        private void Start()
        {
            if(gameObject.CompareTag("Enemy") && !isCloseEnemy && !isBomb)Pool = GameObject.FindGameObjectWithTag("EnemyPool").GetComponent<LeanGameObjectPool>();
            if(gameObject.CompareTag("Enemy") && isCloseEnemy)Pool = GameObject.Find("---PLAYER---/Player/SpawnPoints/CloseEnemyPool").GetComponent<LeanGameObjectPool>();
            if(gameObject.CompareTag("Enemy") && isBomb)Pool = GameObject.Find("---MANAGERS---/PatternPools/ExplodingEnemyPool").GetComponent<LeanGameObjectPool>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("PlayerRear")) return;
            if (gameObject.CompareTag("Enemy"))ReturnToPool();
        }

        public void ReturnToPool()
        {
            Pool.Despawn(gameObject);
        }
    }
}