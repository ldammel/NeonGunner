using Lean.Pool;
using Library.Combat.Enemy;
using Library.Events;
using UnityEngine;

namespace Library.Combat.Pooling
{
    public class EnemyPooled : MonoBehaviour
    {
        public LeanGameObjectPool _pool;
        public bool isBuilding;
        public bool isCloseEnemy;
        public bool isBomb;

        public LeanGameObjectPool Pool
        {
            get => _pool;
            set
            {
                if (_pool == null)
                    _pool = value;
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
            if (gameObject.CompareTag("Enemy"))
            {
                GameObject.Find("---PLAYER---/Player").GetComponent<EnemyHealth>().TakeDamage(10);
                LevelEnd.Instance.enemiesMissed++;
                ReturnToPool();
            }
        }

        public void ReturnToPool()
        {
            Pool.Despawn(gameObject);
        }
    }
}