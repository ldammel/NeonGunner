using System;
using Library.Combat.Enemy;
using UnityEngine;

namespace Library.Combat
{
    public class Flak : MonoBehaviour
    {
        public float radius = 5;
        [SerializeField] private float damage;


        private void OnCollisionEnter(Collision other)
        {
            AreaDamageEnemies(other.GetContact(0).point, radius, damage);
        }

        public void AreaDamageEnemies(Vector3 location, float radius, float damage)
        {
            var objects = Physics.OverlapSphere(location, radius);
            foreach (var col in objects)
            {
                var enemy = col.GetComponent<EnemyHealth>();
                if (enemy == null) continue;
                enemy.TakeDamage(damage);
            }
        }
    }
}
