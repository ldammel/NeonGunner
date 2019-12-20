using System;
using System.Collections;
using Library.Combat.Enemy;
using Library.Tools;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Library.Combat
{
    public class Flak : MonoBehaviour
    {
        public float radius = 5;
        public float damage;
        public AudioSource explosionSoundSource;

        public GameObject shrapnelBullet;
        public int shrapnelAmount;

        public bool isShrapnel;

        private bool canExplode;

        private void Start()
        {
            var c = gameObject.GetComponent<MeshRenderer>().enabled = true;
            explosionSoundSource = GameObject.Find("---PLAYER---/Sounds/ExplosionSound").GetComponent<AudioSource>();
            canExplode = false;
            StartCoroutine(ShrapnelStart());
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && isShrapnel)
            {
                if (!canExplode) return;
                canExplode = false;
                for (int i = 0; i < shrapnelAmount; i++)
                {
                    var go = Instantiate(shrapnelBullet, Random.insideUnitSphere * radius+ transform.position, Quaternion.identity);
                    var rb = go.gameObject.GetComponent<Rigidbody>();
                    rb.AddRelativeForce(Random.Range(-1000,1000),-500,Random.Range(-1000,1000));
                    Destroy(go,0.5f);
                }
                AreaDamageEnemies(transform.position, radius, damage);
            }
        }


        private void OnCollisionEnter(Collision other)
        {
            AreaDamageEnemies(other.GetContact(0).point, radius, damage);
        }

        public void AreaDamageEnemies(Vector3 location, float area, float hitDamage)
        {
            explosionSoundSource.Play();
            var objects = Physics.OverlapSphere(location, area);
            if (objects.Length == 0) return;
            foreach (var col in objects)
            {
                var enemy = col.GetComponent<EnemyHealth>();
                if (enemy == null) continue;
                enemy.TakeDamage(hitDamage);
            }

            var c = gameObject.GetComponent<MeshRenderer>().enabled = false;
        }

        IEnumerator ShrapnelStart()
        {
            yield return new WaitForSeconds(0.3f);
            canExplode = true;
        }
    }
}
