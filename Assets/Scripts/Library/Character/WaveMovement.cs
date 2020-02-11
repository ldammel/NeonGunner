using Library.Events;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Library.Character
{
    public class WaveMovement : MonoBehaviour
    {
        public static WaveMovement Instance;

        private float _distanceToWave;
        private float _baseDistance = 200;

        public float zValue;

        public bool testing;
        
        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("There can only be one instance of WaveMovement!");
                Application.Quit();
            }

            Instance = this;
        }

        public void ReducePosition()
        {
            if (testing) return;
            if (LevelEnd.Instance.totalNegativeScore <= 0) return;
            zValue = 200*(LevelEnd.Instance.totalNegativeScore / LevelEnd.Instance.score);
            transform.localPosition = new Vector3(0,0,_baseDistance + zValue);
            _distanceToWave = 360 - transform.localPosition.z;
            LevelEnd.Instance.waveDistance = _distanceToWave;
            if( transform.localPosition.z >= 365 || _distanceToWave <= 0) LevelEnd.Instance.End();
        }
    }
}
