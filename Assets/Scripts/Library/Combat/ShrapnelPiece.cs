using Library.Combat.Enemy;
using UnityEngine;

namespace Library.Combat
{
    public class ShrapnelPiece : MonoBehaviour
    {
        public int damage;
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                var e = other.gameObject.GetComponent<EnemyHealth>();
                e.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
