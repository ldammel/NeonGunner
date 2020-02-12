using Library.Character.ScriptableObjects;
using Library.Combat.Enemy;
using Library.Combat.Pooling;
using Library.Events;
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
        [SerializeField] private BulletPooled bp;
        
        public float fireRate;

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
            bp = gameObject.GetComponent<BulletPooled>();
        }


        private void Update()
        {
            if (PauseMenu.Instance.pauseActive) return;
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
            bp.Fire();
            
            if (hit.collider.gameObject.CompareTag("Enemy"))
            {
                if(hit.collider.gameObject.GetComponent<EnemyHealth>() != null) hit.collider.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
            }

            Instantiate(vfx, hit.point, hit.collider.transform.rotation);
        }
    }
}
