﻿using System;
using System.Collections.Generic;
using System.Globalization;
using JetBrains.Annotations;
using Library.Combat.Enemy;
using Library.Events;
using Library.Tools;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Library.Combat
{
    public class Flamethrower : MonoBehaviour
    {
        [SerializeField] private ParticleSystem flameFx;
         public float damage;
         public float range;
         public float spread;
        [HideInInspector] public float ammoConsumptionPerSecond;
        [HideInInspector] public float ammoRefreshPerSecond;
        [HideInInspector] public float maxAmmo;
        [SerializeField]  private float ammo;
        [SerializeField]  private TextMeshProUGUI ammoCountDisplay;
        public List<ParticleCollisionEvent> collisionEvents;
        private bool soundPlaying;

        private void Start()
        {
            var coll = flameFx.collision;
            coll.enabled = true;
            collisionEvents = new List<ParticleCollisionEvent>();
            ammoCountDisplay = GameObject.Find("---UI---/Canvas/FlameAmmo").GetComponent<TextMeshProUGUI>();
        }

        private void Update()
        {
            var o = flameFx.gameObject;
            var localScale = o.transform.localScale;
            localScale = new Vector3(spread,localScale.y, range);
            o.transform.localScale = localScale;
            ammoCountDisplay.text = Mathf.Round(ammo).ToString(CultureInfo.CurrentCulture);
            var flameFxMain = flameFx.main;
            if (Input.GetMouseButton(0))
            {
                flameFxMain.maxParticles = 130;
                if (!soundPlaying)
                {
                    SoundManager.Instance.PlaySound("Flame");
                    soundPlaying = true;
                }
            }
            else
            {
                flameFxMain.maxParticles = 0;
                if(SoundManager.Instance != null)SoundManager.Instance.PlaySound("Stop");
                soundPlaying = false;
            }

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
            var numCollisionEvents = flameFx.GetCollisionEvents(other, collisionEvents);
            int i = 0;

            while (i < numCollisionEvents)
            {
                if (other.CompareTag("Enemy"))
                {
                    other.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
                    i++;
                }
                else if (other.CompareTag("Sign"))
                {
                    other.gameObject.GetComponentInParent<SignActivation>().active = !other.gameObject.GetComponentInParent<SignActivation>().active;
                    return;
                }
            }
        }
    }
}
