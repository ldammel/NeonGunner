using Library.Combat.Enemy;
using Library.Events;
using UnityEngine;

namespace Library.Combat
{
    public class Laser : MonoBehaviour
    {
        public float damage;

        private void OnTriggerStay(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            if(other.gameObject.GetComponent<EnemyHealth>() != null)other.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage*Time.deltaTime);
        }

    }
}
