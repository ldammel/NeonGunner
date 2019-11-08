using System;
using System.Collections.Generic;
using System.Globalization;
using JetBrains.Annotations;
using Library.Combat.Enemy;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Library.Combat
{
    public class Flamethrower : MonoBehaviour
    {
        [SerializeField] private ParticleSystem flameFx;
        [HideInInspector]public float damage;
        [HideInInspector]public float range;
        [HideInInspector]public float spread;
        [HideInInspector] public float ammoConsumptionPerSecond;
        [HideInInspector] public float ammoRefreshPerSecond;
        [HideInInspector]public float maxAmmo;
        [SerializeField] private float ammo;
        [SerializeField] private TextMeshProUGUI ammoCountDisplay;
        public List<ParticleCollisionEvent> collisionEvents;

        private void Start()
        {
            var coll = flameFx.collision;
            coll.enabled = true;
            collisionEvents = new List<ParticleCollisionEvent>();

        }

        private void Update()
        {
            var localScale = flameFx.gameObject.transform.localScale;
            localScale = new Vector3(spread,localScale.y, range);
            flameFx.gameObject.transform.localScale = localScale;
            ammoCountDisplay.text = Mathf.Round(ammo).ToString(CultureInfo.CurrentCulture);
            var flameFxMain = flameFx.main;
            flameFxMain.maxParticles = Input.GetMouseButton(0) ? 130 : 0;
            if (flameFxMain.maxParticles != 0)
            {
                ammo -= ammoConsumptionPerSecond * Time.deltaTime;
            }

            if (ammo < maxAmmo && flameFxMain.maxParticles == 0)
            {
                ammo += ammoRefreshPerSecond * Time.deltaTime;
            }
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
