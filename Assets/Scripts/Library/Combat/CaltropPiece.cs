using System;
using System.Collections;
using System.Collections.Generic;
using Library.Combat.Enemy;
using UnityEngine;

namespace Library.Combat
{
    public class CaltropPiece : MonoBehaviour
    {
        [SerializeField] private float timeUntilDelete;
        [SerializeField] private ParticleSystem flameFx;
        [SerializeField] private float damage;
        public List<ParticleCollisionEvent> collisionEvents;

        private Rigidbody rb;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            StartCoroutine(StartForce());
            collisionEvents = new List<ParticleCollisionEvent>();
        }

        IEnumerator StartForce()
        {
            yield return new WaitForSeconds(0.2f);
            flameFx.gameObject.SetActive(true);
            var coll = flameFx.collision;
            coll.enabled = true;
            Destroy(gameObject, timeUntilDelete);
        }
        
        void OnParticleCollision(GameObject other)
        {
            var numCollisionEvents = flameFx.GetCollisionEvents(other, collisionEvents);
            int i = 0;

            while (i < numCollisionEvents)
            {
                other.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
                i++;
            }
        }

    }
}
