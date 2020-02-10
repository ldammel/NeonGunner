using System.Collections;
using Library.Character;
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
        private Material baseMat;

        private GameObject mov;

        private bool switching;

        private void Start()
        {
            baseMat = rend.material;
            mov = GameObject.Find("---PLAYER---/Player");
        }

        private void Update()
        {
            if (Vector3.Distance(transform.position, mov.transform.position) < 10 && mov.transform.position.x == transform.position.x) Explode();
            if (!switching || this.gameObject.activeSelf) StartCoroutine(SwitchMat());
        }

        private void Explode()
        {
            mov.GetComponent<EnemyHealth>().TakeDamage(damage);
            Instantiate(explosionVfx, transform.position, transform.rotation);
            SoundManager.Instance.PlaySound("Explosion");
            LevelEnd.Instance.enemiesKilled = 0;
            gameObject.GetComponent<EnemyPooled>().ReturnToPool();
        }

        IEnumerator SwitchMat()
        {
            switching = true;
            rend.material = switchMat;
            yield return new WaitForSeconds(switchTime);
            rend.material = baseMat;
            yield return new WaitForSeconds(0.2f);
            switching = false;
        }
    }
}
