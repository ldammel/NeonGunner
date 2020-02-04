using System.Collections;
using Library.Events;
using UnityEngine;

namespace Library.Character
{
    public class WaypointMovement : MonoBehaviour
    {
        public float moveSpeed;
        public float maxSpeed;

        [SerializeField] private MeshRenderer rend;
        [SerializeField] private Material wallMaterial;
        private Material baseMaterial;
        public GameObject trackingObject;
        public bool player;

        private bool updated;
        public float prevDist;


        private void Start()
        {
            if (rend == null) return;
            baseMaterial = rend.material;
        }

        IEnumerator SwitchMat(float waitTime)
        {
            rend.material = wallMaterial;
            yield return new WaitForSeconds(waitTime);
            rend.material = baseMaterial;
        }

        public void SwitchMaterial(float waitTime)
        {
            StartCoroutine(SwitchMat(waitTime));
        }

        private void Update()
        {
            if (PauseMenu.Instance.pauseActive) return;
            
            gameObject.transform.Translate(0,0,moveSpeed * Time.deltaTime);
            if (!updated && player) StartCoroutine(ScoreUpdate());
        }

        IEnumerator ScoreUpdate()
        {
            if (PauseMenu.Instance.pauseActive) yield break;
            updated = true;
            LevelEnd.Instance.score += Mathf.RoundToInt(trackingObject.transform.position.z - prevDist);
            prevDist = trackingObject.transform.position.z;
            yield return new WaitForSeconds(1f);
            updated = false;
        }
    }
}
