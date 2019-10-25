using System;
using System.Collections.Generic;
using JetBrains.Annotations;
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

        private void Update()
        {
            var flameFxMain = flameFx.main;
            flameFxMain.maxParticles = Input.GetMouseButton(0) ? 130 : 0;
        }

        void OnParticleCollision(GameObject other)
        {
            int numCollisionEvents = flameFx.GetCollisionEvents(other, collisionEvents);
            int i = 0;

            while (i < numCollisionEvents)
            {
                other.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage*Time.unscaledDeltaTime);
                i++;
            }
        }
    }
}
