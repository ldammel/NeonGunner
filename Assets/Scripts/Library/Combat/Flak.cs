using System;
using Library.Combat.Enemy;
using UnityEngine;

namespace Library.Combat
{
    public class Flak : MonoBehaviour
    {
        public float radius = 5;
        public float damage;

        private void OnCollisionEnter(Collision other)
        {
            AreaDamageEnemies(other.GetContact(0).point, radius, damage);
        }

        private static void AreaDamageEnemies(Vector3 location, float area, float hitDamage)
        {
            var objects = Physics.OverlapSphere(location, area);
            foreach (var col in objects)
            {
                var enemy = col.GetComponent<EnemyHealth>();
                if (enemy == null) continue;
                enemy.TakeDamage(hitDamage);
            }
        }
    }
}
