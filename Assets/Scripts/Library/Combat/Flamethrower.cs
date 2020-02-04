using System.Collections.Generic;
using Library.Combat.Enemy;
using Library.Data;
using Library.Events;
using Library.Tools;
using UnityEngine;

namespace Library.Combat
{
    public class Flamethrower : MonoBehaviour
    {
        [SerializeField] private ParticleSystem flameFx;
         public float damage;
         public float range;
         public float spread;
         public List<ParticleCollisionEvent> collisionEvents;
        private bool soundPlaying;

        private void Start()
        {
            var coll = flameFx.collision;
            coll.enabled = true;
            collisionEvents = new List<ParticleCollisionEvent>();
        }

        private void OnDisable()
        {
            var flameFxMain = flameFx.main;
            flameFxMain.maxParticles = 0;
            if(SoundManager.Instance != null)SoundManager.Instance.PlaySound("Stop");
            soundPlaying = false;
        }

        private void Update()
        {
            var o = flameFx.gameObject;
            var localScale = o.transform.localScale;
            localScale = new Vector3(spread,localScale.y, range);
            o.transform.localScale = localScale;
            var flameFxMain = flameFx.main;
            if (Input.GetMouseButton(0))
            {
                LevelEnd.Instance.totalShots++;
                flameFxMain.maxParticles = 130;
                if (soundPlaying) return;
                SoundManager.Instance.PlaySound("Flame");
                soundPlaying = true;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                flameFxMain.maxParticles = 0;
                if(SoundManager.Instance != null)SoundManager.Instance.PlaySound("Stop");
                soundPlaying = false;
            }
        }



        void OnParticleCollision(GameObject other)
        {
            if (other.CompareTag("SelectWeapon"))
            {
                other.gameObject.GetComponent<SelectWeapon>().ActivateWeapon();
                return;
            }
            if (!other.CompareTag("Enemy")) return;
            var numCollisionEvents = flameFx.GetCollisionEvents(other, collisionEvents);
            int i = 0;

            while (i < numCollisionEvents)
            {
                if (other.CompareTag("Enemy"))
                {
                    other.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
                    i++;
                }
            }
        }
    }
}
