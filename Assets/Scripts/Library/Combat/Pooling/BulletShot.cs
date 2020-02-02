using System;
using Library.Combat.Enemy;
using UnityEngine;

namespace Library.Combat.Pooling
{
    public class BulletShot : MonoBehaviour, IGameObjectPooled
    {
        public float moveSpeed = 30f;
        private float _lifeTime;
        public float maxLifeTime;
        public float damage;

        public bool isEnemy;

        private EnemyHealth player;
        private BulletShotPool _pool;

        public BulletShotPool Pool
        {
            get => _pool;
            set
            {
                if (_pool == null)
                    _pool = value;
                else 
                    throw new Exception("Bad pool use, this should only get set once!");
            }
        }
        private void OnEnable()
        {
            _lifeTime = 0f;
            player = GameObject.Find("---PLAYER---/Player").GetComponent<EnemyHealth>();
        }


        private void Update()
        {
            transform.Translate(Time.deltaTime * moveSpeed * Vector3.forward);
            _lifeTime += Time.deltaTime;
            if (!(_lifeTime > maxLifeTime)) return;
            _pool.ReturnToPool(gameObject);
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.collider.CompareTag("Player") && isEnemy)
            {
                player.TakeDamage(damage);
            }
            _pool.ReturnToPool(gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("shield") && isEnemy)
            {
                _pool.ReturnToPool(gameObject);
            }
        }
    }
    
    internal interface IGameObjectPooled
    {
        BulletShotPool Pool { get; set; }
    }
}