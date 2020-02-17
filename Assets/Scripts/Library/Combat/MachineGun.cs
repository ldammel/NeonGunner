using Library.Combat.Enemy;
using Library.Combat.Pooling;
using Library.Events;
using UnityEngine;

namespace Library.Combat
{
    public class MachineGun : MonoBehaviour
    {
        [SerializeField] private float damage;
        [SerializeField] private float range;
        [SerializeField] private float fireRate;
        [SerializeField] private Camera cam;
        [SerializeField] private GameObject vfx;
        [SerializeField] private BulletPooled bp;

        private float _fireTimer;

        private void Start()
        {
            _fireTimer = 0;
            if (cam == null)
            {
                cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
            }
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
                var eh = hit.collider.gameObject.GetComponent<EnemyHealth>();
                if(eh != null) eh.TakeDamage(damage);
            }

            Instantiate(vfx, hit.point, hit.collider.transform.rotation);
        }
    }
}
