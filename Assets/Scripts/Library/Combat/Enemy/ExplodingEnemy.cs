using System;
using System.Collections;
using Library.Combat.Pooling;
using Library.Events;
using Library.Tools;
using UnityEngine;

namespace Library.Combat.Enemy
{
    public class ExplodingEnemy : MonoBehaviour
    {
        public GameObject explosionVfx;
        public int damage;
        public float switchTime;
        public MeshRenderer rend;
        public Material switchMat;
        private Material _baseMat;

        private GameObject _mov;

        private bool _switching;
        private EnemyHealth _enemyHealth;
        private EnemyPooled _enemyPooled;

        private void Start()
        {
            _baseMat = rend.material;
            _mov = GameObject.Find("---PLAYER---/Player");
            _enemyHealth = _mov.GetComponent<EnemyHealth>();
            _enemyPooled = gameObject.GetComponent<EnemyPooled>();
        }

        private void Update()
        {
            if (Vector3.Distance(transform.position, _mov.transform.position) < 10 && Math.Abs(_mov.transform.position.x - transform.position.x) < 0.2) Explode();
            if (this.gameObject.activeSelf && !_switching) StartCoroutine(SwitchMat());
        }

        private void Explode()
        {
            _enemyHealth.TakeDamage(damage);
            Instantiate(explosionVfx, transform.position, transform.rotation);
            SoundManager.Instance.PlaySound("Explosion");
            LevelEnd.Instance.enemiesKilled = 0;
            _enemyPooled.ReturnToPool();
        }

        IEnumerator SwitchMat()
        {
            _switching = true;
            rend.material = switchMat;
            yield return new WaitForSeconds(switchTime);
            rend.material = _baseMat;
            yield return new WaitForSeconds(0.2f);
            _switching = false;
        }
    }
}
