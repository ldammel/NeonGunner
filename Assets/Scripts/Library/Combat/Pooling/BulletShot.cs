using System;
using Library.Combat.Enemy;
using UnityEngine;

namespace Library.Combat.Pooling
{
    public class BulletShot : MonoBehaviour, IGameObjectPooled
    {
        public float moveSpeed = 30f;
        public float damage = 10;
        private float _lifeTime;
        public float maxLifeTime;
        [SerializeField] private GameObject vfx;
        private Flak flak;

        private BulletShotPool _pool;
        private bool _isflakNotNull;

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
            flak = gameObject.GetComponent<Flak>();
        }

        private void Start()
        {
            _isflakNotNull = flak != null;
        }


        private void Update()
        {
            transform.Translate(Time.deltaTime * moveSpeed * Vector3.forward);
            _lifeTime += Time.deltaTime;
            if (!(_lifeTime > maxLifeTime)) return;
            
            if (_isflakNotNull)
            {
                flak.AreaDamageEnemies(transform.position, flak.radius, flak.damage);
                Instantiate(vfx, transform.position, transform.rotation);
            }

            _pool.ReturnToPool(gameObject);
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                var e = other.gameObject.GetComponent<EnemyHealth>();
                e.TakeDamage(damage);
            }

            if (gameObject.CompareTag("EnemyBullet") && other.gameObject.CompareTag("Player"))
            {
                var e = other.gameObject.GetComponent<EnemyHealth>();
                e.TakeDamage(damage);
            }

            Instantiate(vfx, other.GetContact(0).point, other.transform.rotation);
            _pool.ReturnToPool(gameObject);
        }
    }
    
    internal interface IGameObjectPooled
    {
        BulletShotPool Pool { get; set; }
    }
}