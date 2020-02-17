using Library.Combat.Enemy;
using Library.Events;
using UnityEngine;

namespace Library.Character
{
    public class WaveMovement : MonoBehaviour
    {
        public static WaveMovement Instance;
        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("There can only be one instance of WaveMovement!");
                Application.Quit();
            }

            Instance = this;
        }
        
        public float zValue;
        public bool testing;

        private float _distanceToWave;
        private const float BaseDistance = 200;

        public void ReducePosition()
        {
            if (testing) return;
            if (LevelEnd.Instance.totalNegativeScore <= 0) return;
            zValue = 200*(LevelEnd.Instance.totalNegativeScore / LevelEnd.Instance.score);
            var transform1 = transform;
            transform1.localPosition = new Vector3(0,0,BaseDistance + zValue);
            _distanceToWave = 360 - transform1.localPosition.z;
            LevelEnd.Instance.waveDistance = _distanceToWave;
            if( transform.localPosition.z >= 365 || _distanceToWave <= 0) LevelEnd.Instance.End();
        }
    }
}
