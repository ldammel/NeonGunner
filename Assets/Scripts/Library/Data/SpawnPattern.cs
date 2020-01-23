using System;
using TMPro;
using UnityEngine;

namespace Library.Data
{
    public class SpawnPattern : MonoBehaviour
    {
        [SerializeField] private Transform endPoint;
        [SerializeField] private GameObject objectToRemove;
        [SerializeField] private int patternNumber;

        private void OnTriggerEnter(Collider other)
        {
            SpawnNextPatternManager.Instance.SpawnNextRoom(endPoint,objectToRemove,patternNumber);
            gameObject.GetComponent<Collider>().enabled = false;
        }
    }
}