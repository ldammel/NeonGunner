using System;
using Library.Character;
using Library.Combat.Enemy;
using UnityEngine;

namespace Library.Combat.Pooling
{
    public class BulletShot : MonoBehaviour, IGameObjectPooled
    {
        [SerializeField] private float moveSpeed = 30f;
        [SerializeField] private float lifeTime;
        [SerializeField] private float maxLifeTime;
        [SerializeField] private float damage;
        [SerializeField] private GameObject vfx;
        [SerializeField] private bool isEnemy;

        private EnemyHealth _player;
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
            lifeTime = 0f;
            _player = GameObject.Find("---PLAYER---/Player").GetComponent<EnemyHealth>();
            if (PlayerPrefs.GetString("Difficulty") == "Easy") damage = 50;
        }


        private void Update()
        {
            transform.Translate(Time.deltaTime * moveSpeed * Vector3.forward);
            lifeTime += Time.deltaTime;
            if (!(lifeTime > maxLifeTime)) return;
            _pool.ReturnToPool(gameObject);
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.collider.CompareTag("Player") && isEnemy)
            {
                _player.TakeDamage(damage);
                if(vfx != null)Instantiate(vfx, other.GetContact(0).point, other.collider.transform.rotation, other.collider.transform);
                other.gameObject.GetComponentInChildren<WaypointMovement>().SwitchMaterial(0.15f);
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