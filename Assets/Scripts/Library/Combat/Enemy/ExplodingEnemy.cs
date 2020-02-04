using Library.Character;
using Library.Combat.Pooling;
using UnityEngine;

namespace Library.Combat.Enemy
{
    public class ExplodingEnemy : MonoBehaviour
    {
        public GameObject explosionVfx;
        public int damage;

        private WaypointMovement mov;
        public BoxCollider col;

        private void Start()
        {
            if(col == null)col = GetComponent<BoxCollider>();
            mov = GameObject.Find("---PLAYER---/Player").GetComponent<WaypointMovement>();
        }

        private void Update()
        {
            col.center = new Vector3(0,0.54f, -(mov.moveSpeed / 6));
            
        }

        private void OnTriggerEnter(Collider other)
        {
            if(!other.CompareTag("Player")) return;
            other.GetComponent<EnemyHealth>().TakeDamage(damage);
            Instantiate(explosionVfx, transform.position, transform.rotation);
            gameObject.GetComponent<EnemyPooled>().ReturnToPool();
        }
    }
}
