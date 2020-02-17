using System.Collections;
using Library.Events;
using UnityEngine;

namespace Library.Character
{
    public class WaypointMovement : MonoBehaviour
    {
        public float moveSpeed;
        public float maxSpeed;
        public GameObject trackingObject;
        public bool player;
        public float prevDist;

        [SerializeField] private MeshRenderer rend;
        [SerializeField] private Material wallMaterial;

        private Material _baseMaterial;
        private bool _updated;


        private void Start()
        {
            if (rend == null) return;
            _baseMaterial = rend.material;
            if (PlayerPrefs.GetString("Difficulty") == "Easy")
            {
                moveSpeed = 25;
            }
            else if (PlayerPrefs.GetString("Difficulty") == "Medium")
            {
                moveSpeed = 50;
            }
            else if (PlayerPrefs.GetString("Difficulty") == "Hard")
            {
                moveSpeed = 75;
            }
        }

        private IEnumerator SwitchMat(float waitTime)
        {
            rend.material = wallMaterial;
            yield return new WaitForSeconds(waitTime);
            rend.material = _baseMaterial;
        }

        public void SwitchMaterial(float waitTime)
        {
            StartCoroutine(SwitchMat(waitTime));
        }

        private void Update()
        {
            if (PauseMenu.Instance.pauseActive) return;
            
            gameObject.transform.Translate(0,0,moveSpeed * Time.deltaTime);
            if (!_updated && player) StartCoroutine(ScoreUpdate());
        }

        IEnumerator ScoreUpdate()
        {
            if (trackingObject.transform.position.z - prevDist < 0) yield break;
            if (PauseMenu.Instance.pauseActive) yield break;
            _updated = true;
            var position = trackingObject.transform.position;
            LevelEnd.Instance.score += Mathf.RoundToInt(position.z - prevDist);
            prevDist = position.z;
            yield return new WaitForSeconds(.5f);
            _updated = false;
        }
    }
}
