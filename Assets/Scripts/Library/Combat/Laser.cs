using Library.Combat.Enemy;
using UnityEngine;

namespace Library.Combat
{
    public class Laser : MonoBehaviour
    {
        [SerializeField] private LineRenderer laser;
        [SerializeField] private float maxLaserLength;
        [SerializeField] private BoxCollider col;

        public float damage;
        
        

        // Start is called before the first frame update
        private void Start()
        {
            laser.SetPosition(1,new Vector3(0,0,0));
            col.size = new Vector3(0,0,0);
            col.center = new Vector3(0,0,0);
            laser.enabled = false;
        }

        // Update is called once per frame
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                laser.enabled = true;
                laser.SetPosition(1, new Vector3(0,0,Mathf.Lerp(0,maxLaserLength,2)));
                col.size = new Vector3(0.3f,0.3f,laser.GetPosition(1).z);
                col.center = new Vector3(0,0,laser.GetPosition(1).z/2);
            }
            else if (Input.GetMouseButtonUp(0))
            {
                laser.enabled = false;
                col.size = new Vector3(0,0,0);
                col.center = new Vector3(0,0,0);
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (!other.CompareTag("Enemy")) return;
            if(other.gameObject.GetComponent<EnemyHealth>() != null)other.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
    }
}
