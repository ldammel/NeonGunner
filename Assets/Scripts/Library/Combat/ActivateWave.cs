using UnityEngine;

namespace Library.Combat
{
    public class ActivateWave : MonoBehaviour
    {

        [SerializeField] private GameObject[] enemies;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            foreach (var e in enemies)
            {
                e.SetActive(true);
            }
        }
    }
}
