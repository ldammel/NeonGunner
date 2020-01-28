using Library.Combat.Pooling;
using UnityEngine;

namespace Library.Combat.Enemy
{
    public class ExplodingEnemy : MonoBehaviour
    {
        public GameObject explosionVfx;
        public int damage;
        private void OnTriggerEnter(Collider other)
        {
            if(!other.CompareTag("Player")) return;
            other.GetComponent<EnemyHealth>().TakeDamage(damage);
            Instantiate(explosionVfx, transform.position, transform.rotation);
            gameObject.GetComponent<EnemyPooled>().ReturnToPool();
        }
    }
}
