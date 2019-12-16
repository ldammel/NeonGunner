using System;
using System.Collections.Generic;
using System.Globalization;
using JetBrains.Annotations;
using Library.Combat.Enemy;
using Library.Tools;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Library.Combat
{
    public class Flamethrower : MonoBehaviour
    {
        [SerializeField] private ParticleSystem flameFx;
        public List<ParticleCollisionEvent> collisionEvents;
        private bool soundPlaying;

        private void Start()
        {
            var coll = flameFx.collision;
            coll.enabled = true;
            collisionEvents = new List<ParticleCollisionEvent>();
        }


        void OnParticleCollision(GameObject other)
        {
            var numCollisionEvents = flameFx.GetCollisionEvents(other, collisionEvents);
            int i = 0;

            while (i < numCollisionEvents)
            {
                float damage = 50;
                other.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
                i++;
            }
        }
    }
}
