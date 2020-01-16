using System.Collections.Generic;
using Library.Combat.Enemy;
using Library.Tools;
using UnityEngine;

namespace Library.Combat
{
    public class ParticleDamage : MonoBehaviour
    {
        public ParticleSystem part;
        public List<ParticleCollisionEvent> collisionEvents;
        public float damage;
        public float cooldown;
        private bool soundPlaying;
        private float _fireTimer;

        private void Start()
        {
            var coll = part.collision;
            coll.enabled = true;
            collisionEvents = new List<ParticleCollisionEvent>();
            _fireTimer = cooldown;
        }
        
        private void Update()
        {
            var fxMain = part.main;
            if (Input.GetMouseButtonDown(0) && _fireTimer >= cooldown)
            {
                part.Play();
                if (!soundPlaying)
                {
                    SoundManager.Instance.PlaySound("Flame");
                    soundPlaying = true;
                }
                _fireTimer = 0;
            }
            else
            {
                
                if(SoundManager.Instance != null)SoundManager.Instance.PlaySound("Stop");
                soundPlaying = false;
            }
            _fireTimer += Time.deltaTime;
        }

        private void OnParticleCollision(GameObject other)
        {
            var numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);
            int i = 0;

            while (i < numCollisionEvents && other.tag == "Enemy")
            {
                other.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
                i++;
            }
        }
    }
}
