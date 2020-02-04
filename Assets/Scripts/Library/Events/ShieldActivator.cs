using System.Collections;
using UnityEngine;

public class ShieldActivator : MonoBehaviour
{
        [SerializeField] private GameObject shield;
        [SerializeField] private float activeTime;

        private SphereCollider col;
        private MeshRenderer rend;

        private void Start()
        {
                col = gameObject.GetComponent<SphereCollider>();
                rend = gameObject.GetComponent<MeshRenderer>();
        }

        public void ActivateShield()
        {
                StartCoroutine(Activate());
        }

        IEnumerator Activate()
        {
                shield.SetActive(true);
                col.enabled = false;
                rend.enabled = false;
                yield return new WaitForSeconds(activeTime);
                col.enabled = true;
                rend.enabled = true;
                shield.SetActive(false);
        }
}
