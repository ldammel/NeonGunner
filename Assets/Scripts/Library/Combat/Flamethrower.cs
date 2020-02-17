using System.Collections.Generic;
using Library.Combat.Enemy;
using Library.Events;
using Library.Tools;
using UnityEngine;

namespace Library.Combat
{
    public class Flamethrower : MonoBehaviour
    {
        [SerializeField] private ParticleSystem flameFx;
        public float damage;
        public List<ParticleCollisionEvent> collisionEvents;
        private bool _soundPlaying;
        private bool _isInstanceNotNull;

        private void Start()
        {
            _isInstanceNotNull = SoundManager.Instance != null;
            var coll = flameFx.collision;
            coll.enabled = true;
            collisionEvents = new List<ParticleCollisionEvent>();
        }

        private void OnDisable()
        {
            var flameFxMain = flameFx.main;
            flameFxMain.maxParticles = 0;
            if(SoundManager.Instance != null)SoundManager.Instance.PlaySound("Stop");
            _soundPlaying = false;
        }

        private void Update()
        {
            if (PauseMenu.Instance.pauseActive) return;
            if (Input.GetMouseButton(1))
            {
                var flameFxMain = flameFx.main;
                flameFxMain.maxParticles = 130;
                if (_soundPlaying) return;
                SoundManager.Instance.PlaySound("Flame");
                _soundPlaying = true;
            }
            else if (Input.GetMouseButtonUp(1))
            {
                var flameFxMain = flameFx.main;
                flameFxMain.maxParticles = 0;
                if(_isInstanceNotNull)SoundManager.Instance.PlaySound("Stop");
                _soundPlaying = false;
            }
        }


        private void OnParticleCollision(GameObject other)
        {
            if (!other.CompareTag("Enemy")) return;
            var numCollisionEvents = flameFx.GetCollisionEvents(other, collisionEvents);
            var i = 0;

            while (i < numCollisionEvents)
            {
                if (!other.CompareTag("Enemy")) continue;
                other.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
                i++;
            }
        }
    }
}
