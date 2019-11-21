using System;
using Library.Events;
using Library.Tools;
using UnityEngine;

namespace Library.Combat.Pooling
{
    public class BulletPooled : MonoBehaviour
    {
        public float fireRate;

        [SerializeField] private BulletShotPool objectPool;

        private float _fireTimer;

        public bool isEnemy = false;
        public bool canFire;

        private void Update()
        {
            if (PauseMenu.Instance.pauseActive) return;
            if (Input.GetMouseButton(0) && !isEnemy)
            {
                if (_fireTimer >= fireRate)
                {
                    _fireTimer = 0;
                    Fire();
                    SoundManager.Instance.PlaySound("Flak");
                }
            }

            if (isEnemy)
            {
                //if (!canFire) return;
                if (_fireTimer >= fireRate)
                {
                    gameObject.transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
                    _fireTimer = 0;
                    Fire();
                }
            }

            _fireTimer += Time.deltaTime;
        }

        private void Fire()
        {
            var shot = objectPool.Get();
            var transform1 = transform;
            shot.transform.position = transform1.position;
            shot.transform.rotation = transform1.rotation;
            shot.gameObject.SetActive(true);
        }
    }
}