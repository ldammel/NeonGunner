using System;
using Library.Events;
using Library.Tools;
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
        private GameObject player;

        private void Start()
        {
            player = GameObject.Find("---PLAYER---/Player/SlotTwo");
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
                if (Vector3.Distance(transform.position,player.transform.position) > range) return;
                if (_fireTimer >= fireRate)
                {
                    gameObject.transform.LookAt(player.transform);
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