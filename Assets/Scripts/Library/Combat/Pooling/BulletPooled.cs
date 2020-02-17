using Library.Events;
using UnityEngine;

namespace Library.Combat.Pooling
{
    public class BulletPooled : MonoBehaviour
    {
        public float fireRate;
        public float range;

        [SerializeField] private BulletShotPool objectPool;

        private float _fireTimer;

        public bool isEnemy = false;
        public bool canFire;

        private GameObject _playerTarget;
        private GameObject _player;
        private GameObject _thisEnemy;

        private void Start()
        {
            _player = GameObject.Find("---PLAYER---/Player");
            _playerTarget = GameObject.Find("---PLAYER---/Player/SlotTwo");
            _thisEnemy = transform.parent.gameObject;
        }

        private void Update()
        {
            if (PauseMenu.Instance.pauseActive) return;
            if (Input.GetMouseButton(0) && !isEnemy)
            {
                if (_fireTimer >= fireRate)
                {
                    _fireTimer = 0;
                    Fire();
                }
            }

            if (isEnemy)
            {
                if(!canFire) return;
                if (Vector3.Distance(transform.position,_player.transform.position) > range) return;
                if (_player.transform.position.z > _thisEnemy.transform.position.z) return;
                if (_fireTimer >= fireRate)
                {
                    gameObject.transform.LookAt(_playerTarget.transform);
                    _fireTimer = 0;
                    Fire();
                }
            }

            _fireTimer += Time.deltaTime;
        }

        public void Fire()
        {
            var shot = objectPool.Get();
            var transform1 = transform;
            shot.transform.position = transform1.position;
            shot.transform.rotation = transform1.rotation;
            shot.gameObject.SetActive(true);
        }
    }
}