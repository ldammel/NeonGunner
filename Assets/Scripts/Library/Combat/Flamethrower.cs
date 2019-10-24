using System;
using System.Collections.Generic;
using Library.Combat.Enemy;
using UnityEngine;
using UnityEngine.Serialization;

namespace Library.Combat
{
    public class Flamethrower : MonoBehaviour
    {
        [SerializeField] private ParticleSystem flameFx;
        [SerializeField] private float damage;
        public List<ParticleCollisionEvent> collisionEvents;

        private void Start()
        {
            var coll = flameFx.collision;
            coll.enabled = true;
            collisionEvents = new List<ParticleCollisionEvent>();
        }

        void OnParticleCollision(GameObject other)
        {
            int numCollisionEvents = flameFx.GetCollisionEvents(other, collisionEvents);
            int i = 0;

            while (i < numCollisionEvents)
            {
                other.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
                i++;
            }
        }
    }
}
