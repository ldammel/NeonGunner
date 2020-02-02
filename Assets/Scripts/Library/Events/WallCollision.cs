using System;
using Library.Character;
using UnityEngine;

namespace Library.Events
{
    public class WallCollision : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            other.GetComponentInChildren<WaveMovement>().ReducePosition(-2000);
        }
    }
}
