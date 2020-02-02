using System;
using Library.Character;
using Library.Combat.Pooling;
using Library.Events;
using TMPro;
using UnityEngine;

namespace Library.Data
{
    public class SpawnPattern : MonoBehaviour
    {
        [SerializeField] private Transform endPoint;
        [SerializeField] private int patternNumber;
        [SerializeField] private int scoreAdd;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            SpawnNextPatternManager.Instance.SpawnNextRoom(endPoint,patternNumber);
            
            LevelEnd.Instance.score += scoreAdd * SpawnNextPatternManager.Instance.levelNumber;
            WaveMovement.Instance.UpdatePosition(scoreAdd * SpawnNextPatternManager.Instance.levelNumber);
        }
    }
}