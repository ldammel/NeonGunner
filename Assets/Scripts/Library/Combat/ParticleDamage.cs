using System.Collections.Generic;
using Library.Combat.Enemy;
using UnityEngine;

namespace Library.Combat
{
    public class ParticleDamage : MonoBehaviour
    {
        public ParticleSystem part;
        public List<ParticleCollisionEvent> collisionEvents;
        private EnemyHealth _eh;

        private void Start()
        {
            _eh = GetComponent<EnemyHealth>();
            collisionEvents = new List<ParticleCollisionEvent>();
        }

        private void OnParticleCollision(GameObject other)
        {
            int numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);

            var rb = other.GetComponent<Rigidbody>();
            var i = 0;

            while (i < numCollisionEvents)
            {
                _eh.TakeDamage(20);
                Debug.Log(_eh.curHealth);
                i++;
            }
        }
    }
}
