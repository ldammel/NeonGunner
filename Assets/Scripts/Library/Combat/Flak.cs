using System;
using Library.Combat.Enemy;
using Library.Tools;
using UnityEngine;

namespace Library.Combat
{
    public class Flak : MonoBehaviour
    {
        public float radius = 5;
        public float damage;
        public AudioSource explosion;

        private void Start()
        {
            explosion = GameObject.Find("---PLAYER---/Sounds/ExplosionSound").GetComponent<AudioSource>();
        }


        private void OnCollisionEnter(Collision other)
        {
            AreaDamageEnemies(other.GetContact(0).point, radius, damage);
        }

        public void AreaDamageEnemies(Vector3 location, float area, float hitDamage)
        {
            explosion.Play();
            var objects = Physics.OverlapSphere(location, area);
            if (objects.Length == 0) return;
            foreach (var col in objects)
            {
                var enemy = col.GetComponent<EnemyHealth>();
                if (enemy == null) continue;
                enemy.TakeDamage(hitDamage);
            }
        }
    }
}
