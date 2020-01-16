using System;
using Library.Character.ScriptableObjects;
using Library.Combat.Enemy;
using Library.Events;
using Library.Tools;
using UnityEngine;

namespace Library.Combat
{
    public class MachineGun : MonoBehaviour
    {
        public float damage;
        public float range;

        [SerializeField] private WeaponValues values;
        [SerializeField] private Camera cam;
        [SerializeField] private GameObject vfx;
        
        public float fireRate;
        public GameObject soundObject;

        private float _fireTimer;

        private void Start()
        {
            _fireTimer = 0;
            if (cam == null)
            {
                cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
            }
            fireRate = values.mgFireRate;
            damage = values.mgDamage;
            range = values.mgRange;
        }


        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                if (PauseMenu.Instance.pauseActive) return;
                if (_fireTimer >= fireRate)
                {
                    _fireTimer = 0;
                    Shoot();
                }
            }
            _fireTimer += Time.deltaTime;
        }

        private void Shoot()
        {
            RaycastHit hit;
            if (!Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range)) return;
            
            if (hit.collider.gameObject.CompareTag("Enemy"))
            {
                hit.collider.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
            }
            else if (hit.collider.gameObject.CompareTag("Sign"))
            {
               hit.collider.gameObject.GetComponentInParent<SignActivation>().active = !hit.collider.gameObject.GetComponentInParent<SignActivation>().active;
            }
            
            Instantiate(vfx, hit.point, hit.collider.transform.rotation);
            Instantiate(soundObject,gameObject.transform);
        }
    }
}
