using System.Collections.Generic;
using Library.Combat.Enemy;
using UnityEngine;

namespace Library.Combat
{
    public class ParticleDamage : MonoBehaviour
    {
        public ParticleSystem part;
        public List<ParticleCollisionEvent> collisionEvents;
        private EnemyHealth eh;

        void Start()
        {
            eh = GetComponent<EnemyHealth>();
            collisionEvents = new List<ParticleCollisionEvent>();
        }

        void OnParticleCollision(GameObject other)
        {
            int numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);

            Rigidbody rb = other.GetComponent<Rigidbody>();
            int i = 0;

            while (i < numCollisionEvents)
            {
                eh.TakeDamage(20);
                Debug.Log(eh.curHealth);
                i++;
            }
        }
    }
}
