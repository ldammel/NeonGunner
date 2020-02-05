using Library.Character;
using Library.Events;
using UnityEngine;

namespace Library.Data
{
    public class SpawnPattern : MonoBehaviour
    {
        [SerializeField] private Transform endPoint;
        [SerializeField] private int patternNumber;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            SpawnNextPatternManager.Instance.SpawnNextRoom(endPoint,patternNumber);
            Debug.Log("Spawned room "+ patternNumber);
        }
    }
}