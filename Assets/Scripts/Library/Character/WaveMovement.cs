using System;
using Library.Events;
using UnityEngine;

namespace Library.Character
{
    public class WaveMovement : MonoBehaviour
    {
        public static WaveMovement Instance;

        private float _distanceToWave;

        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("There can only be one instance of WaveMovement!");
                Application.Quit();
            }

            Instance = this;
        }
        

        public void UpdatePosition(int scoreChange)
        {
            var zValue = scoreChange / 100;
            transform.localPosition = new Vector3(0,0,transform.localPosition.z - zValue);
            _distanceToWave = 360 - transform.localPosition.z;
            LevelEnd.Instance.waveDistance = _distanceToWave;
            if( transform.localPosition.z >= 365) LevelEnd.Instance.End();
        }
        
        
        public void ReducePosition(int scoreChange)
        {
            var zValue = scoreChange / 50;
            transform.localPosition = new Vector3(0,0,transform.localPosition.z - zValue);
            _distanceToWave = 360 - transform.localPosition.z;
            LevelEnd.Instance.waveDistance = _distanceToWave;
            if( transform.localPosition.z >= 365) LevelEnd.Instance.End();
        }
    }
}
