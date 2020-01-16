﻿using System;
using System.Collections;
using Library.Combat.Enemy;
using Library.Events;
using Library.Tools;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Library.Combat
{
    public class Flak : MonoBehaviour
    {
        public float radius = 5;
        public float damage;
        public AudioSource explosionSoundSource;
        private bool canExplode;

        private void Start()
        {
            var c = gameObject.GetComponent<MeshRenderer>().enabled = true;
            explosionSoundSource = GameObject.Find("---PLAYER---/Sounds/ExplosionSound").GetComponent<AudioSource>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Sign"))
            {
                other.gameObject.GetComponentInParent<SignActivation>().active = !other.gameObject.GetComponentInParent<SignActivation>().active;
            }
        }


        private void OnCollisionEnter(Collision other)
        {
            AreaDamageEnemies(other.GetContact(0).point, radius, damage);
        }

        public void AreaDamageEnemies(Vector3 location, float area, float hitDamage)
        {
            explosionSoundSource.Play();
            var objects = Physics.OverlapSphere(location, area);
            if (objects.Length == 0) return;
            foreach (var col in objects)
            {
                var enemy = col.GetComponent<EnemyHealth>();
                if (enemy == null) continue;
                enemy.TakeDamage(hitDamage);
            }

            var c = gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
